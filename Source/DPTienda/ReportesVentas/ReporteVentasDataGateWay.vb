Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core


Public Class ReporteVentasDataGateWay

    Private m_strConnectionString As String
    Private m_almacen As String
    Private oParent As ApplicationContext

    Public Sub New(ByVal ConnectionString As String, ByVal Parent As ApplicationContext)
        m_strConnectionString = ConnectionString
        oParent = Parent
    End Sub

#Region "Methods"

    Public Function GetReporteVentasGeneralFolioSAP(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepVentasGeneralFolioSAP]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = FormatDataSetGeneralFolioSAP(dsResult, FechaIni, Almacen, Codcaja)

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Public Function GetReporteVentasGeneral(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepVentasGeneral]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = FormatDataSetGeneral(dsResult)

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Public Function GetReportesVentasTotales(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Codcaja As String, ByVal Almacen As String) As DataSet
        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[GetReporteVentasTotales]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)


        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsResult
    End Function

    Public Function GetReporteVentasDetalle(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepVentasDetalle]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@IVA", System.Data.SqlDbType.Decimal, 9))

            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin
            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@IVA").Value = oParent.ApplicationConfiguration.IVA




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = FormatDataSetDetalle(dsResult)

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function


    Private Function FormatDataSetGeneralFolioSAP(ByVal Source As DataSet, ByVal fecha As Date, ByVal stralmacen As String, ByVal CodCaja As String) As DataSet
        Try
            Dim dsTarget As New DataSet("ReporteVentas")
            Dim dtMainTable As New DataTable("ReporteVentas")

            'Columna: Folio
            Dim dcFolio As DataColumn = New DataColumn
            With dcFolio
                .DataType = System.Type.GetType("System.String")
                .Caption = "Folio"
                .ColumnName = "Folio"
            End With
            dtMainTable.Columns.Add(dcFolio)

            'Columna: Fecha
            Dim dcFecha As DataColumn = New DataColumn
            With dcFecha
                .DataType = System.Type.GetType("System.String")
                .Caption = "Fecha"
                .ColumnName = "Fecha"
            End With
            dtMainTable.Columns.Add(dcFecha)

            'Columna: Total de Artículos
            Dim dcTotalArticulos As DataColumn = New DataColumn
            With dcTotalArticulos
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Total Articulos"
                .ColumnName = "TotalArticulos"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcTotalArticulos)

            'Columna: Importe
            Dim dcImporte As DataColumn = New DataColumn
            With dcImporte
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Importe"
                .ColumnName = "Importe"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcImporte)

            'Columna: Descuento
            Dim dcDescuento As DataColumn = New DataColumn
            With dcDescuento
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Descuento"
                .ColumnName = "Descuento"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcDescuento)

            'Columna: Formas de Pago
            Dim dcFormaPago As DataColumn
            Dim intFormaPago As Integer
            For intFormaPago = 1 To 20
                dcFormaPago = New DataColumn
                With dcFormaPago
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "Forma de Pago" & intFormaPago.ToString("00")
                    .ColumnName = "FormaPago" & intFormaPago.ToString("00")
                End With
                dtMainTable.Columns.Add(dcFormaPago)

            Next

            'Columna: Pago
            Dim dcPago As DataColumn
            Dim intPago As Integer
            For intPago = 1 To 20
                dcPago = New DataColumn
                With dcPago
                    .DataType = System.Type.GetType("System.Decimal")
                    .Caption = "Pago" & intPago.ToString("00")
                    .ColumnName = "Pago" & intPago.ToString("00")
                End With
                dtMainTable.Columns.Add(dcPago)

            Next

            'Columna: Vendedor
            Dim dcVendedor As DataColumn = New DataColumn
            With dcVendedor
                .DataType = System.Type.GetType("System.String")
                .Caption = "Vendedor"
                .ColumnName = "Vendedor"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcVendedor)

            'Columna: Cliente
            Dim dcCliente As DataColumn = New DataColumn
            With dcCliente
                .DataType = System.Type.GetType("System.String")
                .Caption = "Cliente"
                .ColumnName = "Cliente"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcCliente)

            'Columna: Tipo de Venta
            Dim dcTipoVenta As DataColumn = New DataColumn
            With dcTipoVenta
                .DataType = System.Type.GetType("System.String")
                .Caption = "Tipo de Venta"
                .ColumnName = "TipoVenta"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcTipoVenta)

            'Columna: Nota de Crédito
            Dim dcNCred As DataColumn = New DataColumn
            With dcNCred
                .DataType = System.Type.GetType("System.String")
                .Caption = "Nota de Credito"
                .ColumnName = "NCred"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcNCred)

            'Columna: Status
            Dim dcStatus As DataColumn = New DataColumn
            With dcStatus
                .DataType = System.Type.GetType("System.String")
                .Caption = "Status"
                .ColumnName = "Status"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcStatus)

            'Columna: Total de Facturas
            Dim dcTotalFact As DataColumn = New DataColumn
            With dcTotalFact
                .DataType = System.Type.GetType("System.String")
                .Caption = "Total de Facturas"
                .ColumnName = "TotalFacturas"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcTotalFact)

            'Columna: FolioSAP
            Dim dcFolioSAP As DataColumn = New DataColumn
            With dcFolioSAP
                .DataType = System.Type.GetType("System.String")
                .Caption = "Referencia"
                .ColumnName = "Referencia"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcFolioSAP)

            'Columna: CAJA
            Dim dcCodDaja As DataColumn = New DataColumn
            With dcCodDaja
                .DataType = System.Type.GetType("System.String")
                .Caption = "CAJA"
                .ColumnName = "CodCaja"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcCodDaja)

            ''Columna: Formas de Pago
            'Dim dcFolioSAPNC As DataColumn
            'For intFolioSAPnc As Integer = 1 To 5
            '    dcFolioSAPNC = New DataColumn
            '    With dcFolioSAPNC
            '        .DataType = System.Type.GetType("System.String")
            '        .Caption = "FolioSAPNC" & intFolioSAPnc.ToString("00")
            '        .ColumnName = "FolioSAPNC" & intFolioSAPnc.ToString("00")
            '    End With
            '    dtMainTable.Columns.Add(dcFolioSAPNC)

            'Next

            dsTarget.Tables.Add(dtMainTable)

            Dim oSourceRow As DataRow
            Dim oTargetSource As DataRow

            Dim strFolio As String = String.Empty
            Dim strCodCaja As String = String.Empty
            Dim intColFormaPago As Integer = 0
            Dim intColTotalRegistros As Integer = 0
            Dim TotalImporte As Decimal = 0
            Dim TotalResult As Decimal = 0
            Dim TotalResulNC As Decimal = 0
            Dim TotalPzas As Integer

            Dim dat As Date = fecha.Date

            For Each oSourceRow In Source.Tables(0).Rows

                If (strFolio <> oSourceRow.Item(0).ToString) Or (strCodCaja <> oSourceRow.Item(14).ToString) Then

                    If (Not oTargetSource Is Nothing) Then

                        dtMainTable.Rows.Add(oTargetSource)

                    End If

                    strFolio = oSourceRow.Item(0).ToString
                    strCodCaja = oSourceRow.Item(14).ToString

                    '--------------------------Notas de Credito-------------------
                    If dat <> CDate(oSourceRow("Fecha")).Date Then
                        Dim dt As New DataTable
                        dt = SelectConcentrado(CodCaja, CDate(dat), CDate(dat), stralmacen)
                        If dt.Rows.Count > 0 Then

                            'Letrero de Notas de Credito
                            oTargetSource = dtMainTable.NewRow()
                            oTargetSource("Folio") = "NOTAS DE"
                            oTargetSource("Referencia") = "CREDITO"
                            dtMainTable.Rows.Add(oTargetSource)
                            Dim montoNc As Decimal = 0


                            For Each ncRow As DataRow In dt.Rows

                                oTargetSource = dtMainTable.NewRow()

                                oTargetSource("Folio") = ncRow!folionotacredito
                                oTargetSource("Referencia") = ncRow!salesdocument
                                oTargetSource("Fecha") = Format(ncRow!Fecha, "dd/MM/yyyy")
                                oTargetSource("Importe") = Math.Abs(ncRow!Importe)
                                oTargetSource("Vendedor") = ncRow!codvendedor
                                oTargetSource("Cliente") = ncRow!clienteid
                                oTargetSource("CodCaja") = ncRow!codCaja
                                montoNc += Math.Abs(ncRow!Importe)
                                dtMainTable.Rows.Add(oTargetSource)


                            Next

                            oTargetSource = dtMainTable.NewRow()
                            oTargetSource("Folio") = "---------"
                            oTargetSource("Referencia") = "Total NC"
                            oTargetSource("Importe") = montoNc
                            dtMainTable.Rows.Add(oTargetSource)

                            TotalResulNC += montoNc


                        End If

                    End If
                    '--------------------------Notas de Credito-------------------


                    oTargetSource = dtMainTable.NewRow()

                    oTargetSource("Folio") = strFolio
                    oTargetSource("Fecha") = Format(oSourceRow("Fecha"), "dd/MM/yyyy")
                    oTargetSource("TotalArticulos") = oSourceRow("TotalArticulos")
                    oTargetSource("Importe") = oSourceRow.Item(3).ToString
                    oTargetSource("Descuento") = Decimal.Round(oSourceRow("Descuento"), 2)
                    oTargetSource("Vendedor") = oSourceRow("Vendedor")
                    oTargetSource("Cliente") = oSourceRow("Cliente")
                    oTargetSource("TipoVenta") = oSourceRow("TipoVenta")
                    oTargetSource("Status") = oSourceRow("Status")
                    oTargetSource("Referencia") = oSourceRow("Referencia")
                    oTargetSource("CodCaja") = strCodCaja 'oSourceRow("CodCaja")

                    intColFormaPago = 1

                    If oSourceRow("Status") <> "CAN" Then
                        intColTotalRegistros += 1
                    End If

                    TotalImporte = CType(oSourceRow("Total"), Decimal)
                    If TotalImporte > 0 Then
                        TotalResult += TotalImporte
                        'Total PZAS
                        TotalPzas += CInt(oSourceRow("TotalArticulos"))
                    End If


                End If



                oTargetSource("FormaPago" & intColFormaPago.ToString("00")) = oSourceRow("CodFormasPago")
                oTargetSource("Pago" & intColFormaPago.ToString("00")) = oSourceRow("MontoPago")
                intColFormaPago += 1
                'Para las notas de credito
                dat = CDate(oSourceRow("Fecha"))
            Next

            If (Not oTargetSource Is Nothing) Then

                dtMainTable.Rows.Add(oTargetSource)

            End If

            If (intColTotalRegistros <> 0) Then

                '--------------------------Notas de Credito-------------------
                Dim dt As New DataTable
                dt = SelectConcentrado(CodCaja, CDate(dat), CDate(dat), stralmacen)
                If dt.Rows.Count > 0 Then

                    'Letrero de Notas de Credito
                    oTargetSource = dtMainTable.NewRow()
                    oTargetSource("Folio") = "NOTAS DE"
                    oTargetSource("Referencia") = "CREDITO"
                    dtMainTable.Rows.Add(oTargetSource)
                    Dim montoNc As Decimal = 0

                    For Each ncRow As DataRow In dt.Rows

                        oTargetSource = dtMainTable.NewRow()

                        oTargetSource("Folio") = ncRow!folionotacredito
                        oTargetSource("Referencia") = ncRow!salesdocument
                        oTargetSource("Fecha") = Format(ncRow!Fecha, "dd/MM/yyyy")
                        oTargetSource("Importe") = Math.Abs(ncRow!Importe)
                        oTargetSource("Vendedor") = ncRow!codvendedor
                        oTargetSource("Cliente") = ncRow!clienteid
                        oTargetSource("CodCaja") = ncRow!codCaja
                        montoNc += Math.Abs(ncRow!Importe)
                        dtMainTable.Rows.Add(oTargetSource)


                    Next

                    oTargetSource = dtMainTable.NewRow()
                    oTargetSource("Folio") = "---------"
                    oTargetSource("Referencia") = "Total NC"
                    oTargetSource("Importe") = montoNc
                    dtMainTable.Rows.Add(oTargetSource)
                    TotalResulNC += montoNc

                End If
                '--------------------------Notas de Credito-------------------
            End If


            oTargetSource = dtMainTable.NewRow()
            oTargetSource("Importe") = TotalResult - TotalResulNC
            oTargetSource("Folio") = "IMPORTE TOTAL"
            oTargetSource("TotalFacturas") = intColTotalRegistros
            oTargetSource("TotalArticulos") = TotalPzas

            dtMainTable.Rows.Add(oTargetSource)

            If (oTargetSource("TotalFacturas") = 0) Then

                MsgBox("Los datos proporcionados no produjeron resultados.", MsgBoxStyle.Exclamation)

            End If

            dtMainTable.AcceptChanges()

            'Dim oSaveConfigArchivosR As SaveConfigArchivosReader
            'oSaveConfigArchivosR = New SaveConfigArchivosReader(Application.StartupPath & "\configCierre.cml")
            'Dim oSaveConfigArchivos As New SaveConfigArchivos
            'oSaveConfigArchivosR.LoadSettings()

            'Dim dvFechaAutoF As New DataView(dtMainTable, "Fecha >='15/01/2007'", "Folio", DataViewRowState.CurrentRows)
            'For Each oView As DataRowView In dvFechaAutoF
            '    oView.Row.Item(0) = 0
            'Next
            'dtMainTable.AcceptChanges()

            Return dsTarget


        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Private Function FormatDataSetGeneral(ByVal Source As DataSet) As DataSet

        Dim dsTarget As New DataSet("ReporteVentas")
        Dim dtMainTable As New DataTable("ReporteVentas")

        'Columna: Folio
        Dim dcFolio As DataColumn = New DataColumn
        With dcFolio
            .DataType = System.Type.GetType("System.String")
            .Caption = "Folio"
            .ColumnName = "Folio"
        End With
        dtMainTable.Columns.Add(dcFolio)

        'Columna: Fecha
        Dim dcFecha As DataColumn = New DataColumn
        With dcFecha
            .DataType = System.Type.GetType("System.String")
            .Caption = "Fecha"
            .ColumnName = "Fecha"
        End With
        dtMainTable.Columns.Add(dcFecha)

        'Columna: Total de Artículos
        Dim dcTotalArticulos As DataColumn = New DataColumn
        With dcTotalArticulos
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Total Articulos"
            .ColumnName = "TotalArticulos"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalArticulos)

        'Columna: Importe
        Dim dcImporte As DataColumn = New DataColumn
        With dcImporte
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Importe"
            .ColumnName = "Importe"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcImporte)

        'Columna: Descuento
        Dim dcDescuento As DataColumn = New DataColumn
        With dcDescuento
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Descuento"
            .ColumnName = "Descuento"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescuento)

        'Columna: Formas de Pago
        Dim dcFormaPago As DataColumn
        Dim intFormaPago As Integer
        For intFormaPago = 1 To 10
            dcFormaPago = New DataColumn
            With dcFormaPago
                .DataType = System.Type.GetType("System.String")
                .Caption = "Forma de Pago" & intFormaPago.ToString("00")
                .ColumnName = "FormaPago" & intFormaPago.ToString("00")
            End With
            dtMainTable.Columns.Add(dcFormaPago)

        Next

        'Columna: Pago
        Dim dcPago As DataColumn
        Dim intPago As Integer
        For intPago = 1 To 10
            dcPago = New DataColumn
            With dcPago
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Pago" & intPago.ToString("00")
                .ColumnName = "Pago" & intPago.ToString("00")
            End With
            dtMainTable.Columns.Add(dcPago)

        Next

        'Columna: Vendedor
        Dim dcVendedor As DataColumn = New DataColumn
        With dcVendedor
            .DataType = System.Type.GetType("System.String")
            .Caption = "Vendedor"
            .ColumnName = "Vendedor"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcVendedor)

        'Columna: Cliente
        Dim dcCliente As DataColumn = New DataColumn
        With dcCliente
            .DataType = System.Type.GetType("System.String")
            .Caption = "Cliente"
            .ColumnName = "Cliente"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcCliente)

        'Columna: Tipo de Venta
        Dim dcTipoVenta As DataColumn = New DataColumn
        With dcTipoVenta
            .DataType = System.Type.GetType("System.String")
            .Caption = "Tipo de Venta"
            .ColumnName = "TipoVenta"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTipoVenta)

        'Columna: Nota de Crédito
        Dim dcNCred As DataColumn = New DataColumn
        With dcNCred
            .DataType = System.Type.GetType("System.String")
            .Caption = "Nota de Credito"
            .ColumnName = "NCred"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcNCred)

        'Columna: Status
        Dim dcStatus As DataColumn = New DataColumn
        With dcStatus
            .DataType = System.Type.GetType("System.String")
            .Caption = "Status"
            .ColumnName = "Status"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcStatus)

        'Columna: Total de Facturas
        Dim dcTotalFact As DataColumn = New DataColumn
        With dcTotalFact
            .DataType = System.Type.GetType("System.String")
            .Caption = "Total de Facturas"
            .ColumnName = "TotalFacturas"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalFact)

        dsTarget.Tables.Add(dtMainTable)

        Dim oSourceRow As DataRow
        Dim oTargetSource As DataRow

        Dim strFolio As String
        Dim intColFormaPago As Integer
        Dim intColTotalRegistros As Integer
        Dim TotalImporte As Decimal
        Dim TotalResult As Decimal


        For Each oSourceRow In Source.Tables(0).Rows

            If (strFolio <> oSourceRow.Item(0).ToString) Then

                If (Not oTargetSource Is Nothing) Then

                    dtMainTable.Rows.Add(oTargetSource)

                End If

                strFolio = oSourceRow.Item(0).ToString
                oTargetSource = dtMainTable.NewRow()

                oTargetSource("Folio") = strFolio
                oTargetSource("Fecha") = Format(oSourceRow("Fecha"), "dd/MM/yyyy")
                oTargetSource("TotalArticulos") = oSourceRow("TotalArticulos")
                oTargetSource("Importe") = oSourceRow.Item(3).ToString
                oTargetSource("Descuento") = Decimal.Round(oSourceRow("Descuento"), 2)
                oTargetSource("Vendedor") = oSourceRow("Vendedor")
                oTargetSource("Cliente") = oSourceRow("Cliente")
                oTargetSource("TipoVenta") = oSourceRow("TipoVenta")
                oTargetSource("Status") = oSourceRow("Status")
                intColFormaPago = 1
                If oSourceRow("Status") <> "CAN" Then
                    intColTotalRegistros += 1
                End If
                TotalImporte = CType(oSourceRow("Total"), Decimal)

                If TotalImporte > 0 Then
                    TotalResult += TotalImporte
                End If


            End If

            oTargetSource("FormaPago" & intColFormaPago.ToString("00")) = oSourceRow("CodFormasPago")
            oTargetSource("Pago" & intColFormaPago.ToString("00")) = oSourceRow("MontoPago")

            intColFormaPago += 1


        Next

        If (Not oTargetSource Is Nothing) Then

            dtMainTable.Rows.Add(oTargetSource)

        End If


        oTargetSource = dtMainTable.NewRow()
        oTargetSource("Importe") = TotalResult
        oTargetSource("Folio") = "IMPORTE TOTAL"
        oTargetSource("TotalFacturas") = intColTotalRegistros
        dtMainTable.Rows.Add(oTargetSource)

        If (oTargetSource("TotalFacturas") = 0) Then

            MsgBox("Los datos proporcionados no produjeron resultados.", MsgBoxStyle.Exclamation)

        End If

        dtMainTable.AcceptChanges()

        Return dsTarget

    End Function

    Private Function FormatDataSetDetalle(ByVal Source As DataSet) As DataSet

        Dim dsTarget As New DataSet("ReporteVentas")
        Dim dtMainTable As New DataTable("ReporteVentas")

        'Columna: Folio
        Dim dcFolio As DataColumn = New DataColumn
        With dcFolio
            .DataType = System.Type.GetType("System.String")
            .Caption = "Folio"
            .ColumnName = "Folio"
        End With
        dtMainTable.Columns.Add(dcFolio)

        Dim dcFolioSAP As DataColumn = New DataColumn
        With dcFolioSAP
            .DataType = System.Type.GetType("System.String")
            .Caption = "Referencia"
            .ColumnName = "Referencia"
        End With
        dtMainTable.Columns.Add(dcFolioSAP)

        'Columna: Código de Artículo
        Dim dcArticuloID As DataColumn = New DataColumn
        With dcArticuloID
            .DataType = System.Type.GetType("System.String")
            .Caption = "Código Artículo"
            .ColumnName = "ArticuloID"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcArticuloID)

        'Columna: Descripcion
        Dim dcDescripcion As DataColumn = New DataColumn
        With dcDescripcion
            .DataType = System.Type.GetType("System.String")
            .Caption = "Descripcion"
            .ColumnName = "Descripcion"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescripcion)

        'Columna: Cantidad
        Dim dcCantidad As DataColumn = New DataColumn
        With dcCantidad
            .DataType = System.Type.GetType("System.String")
            .Caption = "Cantidad"
            .ColumnName = "Cantidad"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcCantidad)

        'Columna: Talla
        Dim dcTalla As DataColumn = New DataColumn
        With dcTalla
            .DataType = System.Type.GetType("System.String")
            .Caption = "Talla"
            .ColumnName = "Talla"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTalla)

        'Columna: Importe
        Dim dcImporte As DataColumn = New DataColumn
        With dcImporte
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Importe"
            .ColumnName = "Importe"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcImporte)

        'Columna: Total
        Dim dcTotal As DataColumn = New DataColumn
        With dcTotal
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Total"
            .ColumnName = "Total"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotal)

        'Columna: Descuento
        Dim dcDescuento As DataColumn = New DataColumn
        With dcDescuento
            .DataType = System.Type.GetType("System.String")
            .Caption = "Descuento"
            .ColumnName = "Descuento"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescuento)

        'Columna: Cantidad Descuento
        Dim dcCantDescuento As DataColumn = New DataColumn
        With dcCantDescuento
            .DataType = System.Type.GetType("System.Decimal")
            .Caption = "Cantidad Descuento"
            .ColumnName = "CantDescuento"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcCantDescuento)

        'Columna: Fecha
        Dim dcFecha As DataColumn = New DataColumn
        With dcFecha
            .DataType = GetType(Date)
            .Caption = "Fecha"
            .ColumnName = "Fecha"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcFecha)

        'Columna: Total de Registros
        Dim dcTotalRegistros As DataColumn = New DataColumn
        With dcTotalRegistros
            .DataType = System.Type.GetType("System.String")
            .Caption = "Total de Registros"
            .ColumnName = "TotalRegistros"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalRegistros)

        dsTarget.Tables.Add(dtMainTable)


        Dim oSourceRow As DataRow
        Dim oTargetSource As DataRow

        Dim strArticuloID As String
        Dim intColTotalRegistros As Integer
        Dim TotalImporte As Decimal
        Dim TotalImp As Decimal
        Dim strFolio As String

        For Each oSourceRow In Source.Tables(0).Rows

            'If (strFolio <> oSourceRow.Item(0).ToString) Or (strArticuloID <> oSourceRow.Item(1).ToString) Then
            '    oTargetSource = dtMainTable.NewRow()
            '    strFolio = oSourceRow.Item(0).ToString
            '    strArticuloID = oSourceRow.Item(1).ToString
            '    oTargetSource("ArticuloID") = strArticuloID
            '    oTargetSource("Descripcion") = oSourceRow.Item(2).ToString
            'Else
            '    oTargetSource = dtMainTable.NewRow()
            'End If

            oTargetSource = dtMainTable.NewRow()
            strFolio = oSourceRow.Item(0).ToString
            strArticuloID = oSourceRow.Item(1).ToString
            oTargetSource("ArticuloID") = strArticuloID
            oTargetSource("Descripcion") = oSourceRow.Item(2).ToString
            oTargetSource("Referencia") = oSourceRow.Item(10).ToString

            oTargetSource("Folio") = oSourceRow.Item(0).ToString
            oTargetSource("Cantidad") = oSourceRow.Item(3).ToString
            oTargetSource("Talla") = oSourceRow.Item(4).ToString
            oTargetSource("Importe") = oSourceRow.Item(5).ToString
            oTargetSource("Total") = oSourceRow.Item(6).ToString
            oTargetSource("Descuento") = oSourceRow.Item(7).ToString
            oTargetSource("CantDescuento") = CType(oSourceRow.Item(8).ToString, Decimal)

            oTargetSource("Fecha") = oSourceRow.Item(9)

            dtMainTable.Rows.Add(oTargetSource)

            TotalImporte = CType(oSourceRow("Total"), Decimal)

            If TotalImporte > 0 Then
                TotalImp += TotalImporte
            End If


            intColTotalRegistros += 1
        Next

        oTargetSource = dtMainTable.NewRow()
        oTargetSource("Total") = TotalImp
        oTargetSource("TotalRegistros") = intColTotalRegistros
        oTargetSource("ArticuloID") = "TOTALES"
        dtMainTable.Rows.Add(oTargetSource)

        If (oTargetSource("TotalRegistros") = 0) Then

            MsgBox("Los datos proporcionados no produjeron resultados.", MsgBoxStyle.Exclamation)

        End If

        dtMainTable.AcceptChanges()

        '</TraspasarInformacion>

        Return dsTarget

    End Function

    Public Function GetReporteVentasGeneralNew(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepVentasGeneral]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Public Function GetReporteVentasGeneralNewForPreview(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepVentasGeneralPreview]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    Private Function SelectConcentrado(ByVal strCaja As String, ByVal ccDesde As Date, ByVal ccHasta As Date, ByVal stralmacen As String) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim daNotaCredito As SqlDataAdapter
        Dim dtConcentrado As New DataTable("Concentrado")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[NotasCreditoReporteConcentradoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Caja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Caja").Value = strCaja
            .Parameters("@FechaInicial").Value = ccDesde
            .Parameters("@FechaFinal").Value = ccHasta
            .Parameters("@Sucursal").Value = stralmacen

        End With

        daNotaCredito = New SqlDataAdapter(sccmdSelect)

        Try

            daNotaCredito.Fill(dtConcentrado)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daNotaCredito.Dispose()
        daNotaCredito = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtConcentrado

    End Function


#End Region

#Region "Facturacion SiHay"

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/06/2013: Obtiene el reporte de los pedidos totales
    '-------------------------------------------------------------------------------------------------------------------------------

    Public Function GetReportePedido(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Codcaja As String, ByVal Almacen As String) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepVentasGeneral As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepVentasGeneral

        With scRepVentasGeneral


            .CommandText = "[RepPedidosGeneralPreview]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodCaja").Value = Codcaja
            .Parameters("@FechaInicial").Value = FechaIni
            .Parameters("@FechaFinal").Value = FechaFin




        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            dsFormatedResult = dsResult

        Catch ex As Exception

            Throw ex

        Finally

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

        End Try

        Return dsFormatedResult


    End Function

    '--------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/09/2014: Obtiene los pedidos Facturados del Si Hay
    '--------------------------------------------------------------------------------------------

    Public Function GetReportePedidosFacturados(ByVal CodAlmacen As String, ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataSet
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("RepVentasPedidos", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicial", fechaInicio)
            command.Parameters.Add("@FechaFinal", fechaFin)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener los datos error de SQL", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return datos
    End Function

    '-------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/09/2014: Obtiene los pedidos no Facturados del Si Hay
    '-------------------------------------------------------------------------------------------

    Public Function GetPedidosNoFacturados(ByVal CodAlmacen As String, ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataSet
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("RepVentasPedidosNoFacturados", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicial", fechaInicio)
            command.Parameters.Add("@FechaFinal", fechaFin)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener los datos de la consulta error de SQL", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return datos
    End Function

    '-------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/09/2014: Obtiene los pagos hechos para ecommerce en la tienda.
    '-------------------------------------------------------------------------------------------

    Public Function GetPagosEcommerce(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataSet
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("RepPagosEcommerce", conexion)
        Dim adapter As SqlDataAdapter
        Dim datos As New DataSet
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicial", FechaInicio)
            command.Parameters.Add("@FechaFinal", FechaFin)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al obtener los datos de la consulta error de SQL", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return datos
    End Function

#End Region



End Class
