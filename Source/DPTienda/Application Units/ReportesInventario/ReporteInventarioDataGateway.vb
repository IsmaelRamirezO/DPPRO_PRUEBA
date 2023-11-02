Imports System.Data.SqlClient

'Procedimientos Almacenados
' - Reporte Inventario por Codigo
'   RepInvXCod(Mes, Almacen)
'
' - RepInvXExistNeg (Mes, Almacen)
'   Reporte Inventario Existencia Negativa
'
' - RepInvXApartados (Almacen)
'   Reporte Inventario Apartados
'
' - RepInvXUniPares (Mes, MinPares, Almacen)
'   Reporte Inventario Unicos Pares


'#Region "Constructors"

'Public Sub New(ByVal Parent As ConsultaExistenciasAbstract)

'    oParent = Parent

'    m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

'End Sub

'#End Region
Public Class ReporteInventarioDataGateway

    Private m_strConnectionString As String

    Public Sub New(ByVal ConnectionString As String)
        m_strConnectionString = ConnectionString
    End Sub

#Region "Methods"

    Public Function GetInventarioNormal(ByVal Almacen As String, ByVal Mes As String) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXCod

        'El sproc RepInvXCod tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvXCod As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvXCod

        With scRepInvXCod

            .CommandText = "dbo.[RepInvxCod]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodAlmacen").Value = Almacen

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            'dsFormatedResult = FormatDataSet(dsResult)
            dsFormatedResult = FormatDataSetInvCodigo(dsResult)

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

    Public Function GetInventarioNegativo(ByVal Almacen As String, ByVal Mes As String) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXExistNeg

        'El sproc RepInvXExistNeg tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvXCod As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvXCod

        With scRepInvXCod

            .CommandText = "RepInvxExisNeg"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodAlmacen").Value = Almacen

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet
            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = FormatDataSetInvNeg(dsResult)

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

    Public Function GetInventarioApartado(ByVal Almacen As String) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXApartados

        'El sproc RepInvXApartados tiene los parametros
        '   - Almacen: Almacen que se desea obtener la informacion


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvXApartados As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvXApartados

        With scRepInvXApartados

            .CommandText = "dbo.[RepInvxApartados]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters("@CodAlmacen").Value = Almacen


        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = FormatDataSetInvNeg(dsResult)

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

    Public Function GetInventarioUnicosPares(ByVal Almacen As String, ByVal Mes As String, ByVal MinPares As Integer, ByVal Tipo As Integer) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXUniPares

        'El sproc RepInvXUniPares tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion
        '   - MinPares: Numero minimo de pares a reportar

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvxUniPares As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvxUniPares

        With scRepInvxUniPares

            .CommandText = "dbo.[RepInvxUniPares]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MinPares", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4))

            .Parameters("@Mes").Value = Mes
            .Parameters("@MinPares").Value = MinPares
            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@Tipo").Value = Tipo

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = Me.FormatDataSetInvNeg(dsResult)

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

    Public Function GetInventarioMovimientoArticulosGeneral(ByVal Almacen As String, ByVal Mes As String, ByVal ArticuloID As String) As InventarioMovimientoArticulosReporter


        'TODO: CLM - Ejecutar el sproc RepInvXUniPares

        'El sproc RepInvXUniPares tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion
        '   - MinPares: Numero minimo de pares a reportar


        Dim scdrReader As SqlDataReader
        Dim oIMArticulos As New InventarioMovimientoArticulosReporter

        ' oIMArticulos = oParent.Create

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scRepInvMovxArticulos As New SqlCommand



        With scRepInvMovxArticulos

            .CommandText = "dbo.[RepMovArticulos]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@CodArticulo").Value = ArticuloID


        End With



        Try

            scConnection.Open()

            With scRepInvMovxArticulos
                'Assign Parameters Values
                .Parameters("@Mes").Value = Mes
                .Parameters("@CodAlmacen").Value = Almacen
                .Parameters("@CodArticulo").Value = ArticuloID

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oIMArticulos.SaldoFinal = .GetDecimal(2)
                        oIMArticulos.SaldoInicial = .GetDecimal(3)
                        'Reset New State of Linea Object 
                        'oCaja.ResetFlagNew()
                        'oCaja.ResetFlagDirty()

                    End With

                Else
                    oIMArticulos = Nothing
                End If

                scdrReader.Close()
            End With

            scConnection.Close()

        Catch oSqlException As SqlException

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (scConnection.State <> ConnectionState.Closed) Then
                Try
                    scConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        'If (oIMArticulos Is Nothing) Then
        '    Throw New ApplicationException("El registro no pudo ser leido debido a que el ID no existe.")
        'End If

        scConnection.Dispose()
        scConnection = Nothing

        Return oIMArticulos

    End Function

    Public Function GetInventarioMovimientoArticulosDetalle(ByVal Almacen As String, ByVal Mes As String, ByVal Articulo As String) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXUniPares

        'El sproc RepInvXUniPares tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion
        '   - MinPares: Numero minimo de pares a reportar

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepMovArticulosDetalles As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepMovArticulosDetalles

        With scRepMovArticulosDetalles

            .CommandText = "dbo.[RepMovArticulosDetalle]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.SmallInt, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodArticulo").Value = Articulo
            .Parameters("@CodAlmacen").Value = Almacen


        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            'dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            'dsFormatedResult = FormatDataSetMov(dsResult)

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

    Public Function GetInventarioArticulosSinMovimiento(ByVal Almacen As String, ByVal Dias As Integer) As DataSet

        'TODO: CLM - Ejecutar el sproc RepInvXUniPares

        'El sproc RepInvXUniPares tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   - Almacen: Almacen que se desea obtener la informacion
        '   - MinPares: Numero minimo de pares a reportar

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepArtSinMovimiento As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepArtSinMovimiento

        With scRepArtSinMovimiento


            .CommandText = "[RepArtSinMovimiento]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Dias", System.Data.SqlDbType.Int, 4))

            .Parameters("@CodAlmacen").Value = Almacen
            .Parameters("@Dias").Value = Dias

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult)

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = FormatDataSet(dsResult)

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

    Public Function GetConsultaCorrida(ByVal Articulo As String) As InventarioMovimientoArticulosReporter

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim oCorrida As New InventarioMovimientoArticulosReporter


        'oFamilias = oParent.Create

        sccmdSelect = New SqlCommand

        With sccmdSelect



            .CommandText = "[ConsultaCorridaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))


        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = Articulo
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        oCorrida.CorridaIni = .GetDecimal(0)
                        oCorrida.CorridaFin = .GetDecimal(1)
                        oCorrida.CorDescripcion = .GetString(2)


                        'Reset New State of Linea Object 
                        'oFamilias.ResetFlagNew()
                        'oFamilias.ResetFlagDirty()

                    End With

                Else
                    oCorrida = Nothing
                End If

                scdrReader.Close()
            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        If (oCorrida Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de línea no existe.")
        End If

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oCorrida

    End Function

    Public Function FormatDataSet(ByVal Source As DataSet) As DataSet
        Try


            Dim dsTarget As New DataSet("ReporteInventario")
            Dim dtMainTable As New DataTable("ReporteInventario")

            'Columna: Codigo
            Dim dcCodigo As DataColumn = New DataColumn
            With dcCodigo
                .DataType = System.Type.GetType("System.String")
                .Caption = "Codigo"
                .ColumnName = "Codigo"
            End With
            dtMainTable.Columns.Add(dcCodigo)


            'Columna:   CodigoAnterior
            Dim dcCodigoAnterior As DataColumn = New DataColumn
            With dcCodigoAnterior
                .DataType = System.Type.GetType("System.String")
                .Caption = "CodigoAnterior"
                .ColumnName = "CodigoAnterior"
            End With
            dtMainTable.Columns.Add(dcCodigoAnterior)


            'Columna: Descripcion
            Dim dcDescripcion As DataColumn = New DataColumn
            With dcDescripcion
                .DataType = System.Type.GetType("System.String")
                .Caption = "Descripcion"
                .ColumnName = "Descripcion"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcDescripcion)

            'Columna: Total Artículos
            Dim dcTotalA As DataColumn = New DataColumn
            With dcTotalA
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Total Artículos"
                .ColumnName = "TotalA"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcTotalA)

            'Columna: Color
            Dim dcColor As DataColumn = New DataColumn
            With dcColor
                .DataType = System.Type.GetType("System.String")
                .Caption = "Total Artículos"
                .ColumnName = "Color"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcColor)

            'Columna: Tallas
            Dim dcTalla As DataColumn
            Dim intTalla As Integer
            For intTalla = 1 To 50
                dcTalla = New DataColumn
                With dcTalla
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "Talla" & intTalla.ToString("00")
                    .ColumnName = "Talla" & intTalla.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTalla)

            Next

            'Columna: Totales
            Dim dcTotal As DataColumn
            Dim intTotal As Integer
            For intTotal = 1 To 50
                dcTotal = New DataColumn
                With dcTotal
                    .DataType = System.Type.GetType("System.Int32")
                    .Caption = "Total" & intTotal.ToString("00")
                    .ColumnName = "Total" & intTotal.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTotal)
            Next

            'Columna: Precio Venta
            Dim dcPrecioVenta As DataColumn = New DataColumn
            With dcPrecioVenta
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Precio Venta"
                .ColumnName = "PrecioVenta"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcPrecioVenta)

            'Columna: PrecioStock 
            Dim dcPrecioStock As DataColumn = New DataColumn
            With dcPrecioStock
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Precio Stock"
                .ColumnName = "PrecioStock"
                '.DefaultValue = 25
                .Expression = "PrecioVenta * TotalA"
            End With
            dtMainTable.Columns.Add(dcPrecioStock)

            ''Columna: CodMarca
            'Dim dcCodMarca As DataColumn = New DataColumn
            'With dcCodMarca
            '    .DataType = System.Type.GetType("System.String")
            '    .Caption = "Marca"
            '    .ColumnName = "CodMarca"
            '    '.DefaultValue = 25
            '    '.Expression = "PrecioVenta * TotalA"
            'End With
            'dtMainTable.Columns.Add(dcCodMarca)

            dsTarget.Tables.Add(dtMainTable)

            '<TraspasarInformacion>

            Dim oSourceRow As DataRow
            Dim oTargetSource As DataRow

            Dim strCodigo As String
            Dim intColTalla As Integer
            Dim TotalArt As Decimal
            Dim TotalResult As Decimal
            Dim TotalResultArt As Decimal
            Dim TotalMonto As Decimal

            For Each oSourceRow In Source.Tables(0).Rows

                If (strCodigo <> oSourceRow.Item(0).ToString) Then

                    If (Not oTargetSource Is Nothing) Then

                        dtMainTable.Rows.Add(oTargetSource)
                        oTargetSource("TotalA") = TotalResult
                        TotalResult = 0

                    End If

                    strCodigo = oSourceRow.Item(0).ToString
                    oTargetSource = dtMainTable.NewRow()

                    oTargetSource("Codigo") = UCase(strCodigo)
                    'oTargetSource("CodMarca") = oSourceRow("CodMarca")
                    oTargetSource("CodigoAnterior") = oSourceRow("codigoanterior")
                    oTargetSource("Descripcion") = oSourceRow.Item(1).ToString
                    oTargetSource("Descripcion") = UCase(CStr(oSourceRow("Descripcion")))
                    'oTargetSource("PrecioVenta") = oSourceRow("PrecioOferta")
                    intColTalla = 1

                End If

                oTargetSource("Talla" & intColTalla.ToString("00")) = oSourceRow("Numero")
                oTargetSource("Total" & intColTalla.ToString("00")) = oSourceRow("TotalMes")



                intColTalla += 1
                TotalArt = CType(oSourceRow("TotalMes"), Integer)
                TotalResult += TotalArt
                TotalResultArt += TotalArt

            Next
            oTargetSource("TotalA") = TotalResult
            dtMainTable.Rows.Add(oTargetSource)

            oTargetSource = dtMainTable.NewRow()
            oTargetSource("TotalA") = TotalResultArt
            oTargetSource("Codigo") = "TOTAL DE PARES"
            dtMainTable.Rows.Add(oTargetSource)

            dtMainTable.AcceptChanges()

            '</TraspasarInformacion>

            Return dsTarget
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function FormatDataSetInvNeg(ByVal Source As DataSet) As DataSet
        Try


            Dim dsTarget As New DataSet("ReporteInventario")
            Dim dtMainTable As New DataTable("ReporteInventario")

            'Columna: Codigo
            Dim dcCodigo As DataColumn = New DataColumn
            With dcCodigo
                .DataType = System.Type.GetType("System.String")
                .Caption = "Codigo"
                .ColumnName = "Codigo"
            End With
            dtMainTable.Columns.Add(dcCodigo)

            'Columna: Descripcion
            Dim dcDescripcion As DataColumn = New DataColumn
            With dcDescripcion
                .DataType = System.Type.GetType("System.String")
                .Caption = "Descripcion"
                .ColumnName = "Descripcion"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcDescripcion)

            'Columna: Total Artículos
            Dim dcTotalA As DataColumn = New DataColumn
            With dcTotalA
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Total Artículos"
                .ColumnName = "TotalA"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcTotalA)

            'Columna: Color
            Dim dcColor As DataColumn = New DataColumn
            With dcColor
                .DataType = System.Type.GetType("System.String")
                .Caption = "Total Artículos"
                .ColumnName = "Color"
                '.DefaultValue = 25
            End With
            dtMainTable.Columns.Add(dcColor)

            'Columna: Tallas
            Dim dcTalla As DataColumn
            Dim intTalla As Integer
            For intTalla = 1 To 20
                dcTalla = New DataColumn
                With dcTalla
                    .DataType = System.Type.GetType("System.String")
                    .Caption = "Talla" & intTalla.ToString("00")
                    .ColumnName = "Talla" & intTalla.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTalla)

            Next

            'Columna: Totales
            Dim dcTotal As DataColumn
            Dim intTotal As Integer
            For intTotal = 1 To 20
                dcTotal = New DataColumn
                With dcTotal
                    .DataType = System.Type.GetType("System.Int32")
                    .Caption = "Total" & intTotal.ToString("00")
                    .ColumnName = "Total" & intTotal.ToString("00")
                End With
                dtMainTable.Columns.Add(dcTotal)
            Next

            dsTarget.Tables.Add(dtMainTable)
            '<TraspasarInformacion>

            Dim oSourceRow As DataRow
            Dim oTargetSource As DataRow

            Dim strCodigo As String
            Dim intColTalla As Integer
            Dim TotalArt As Decimal
            Dim TotalResult As Decimal
            Dim TotalResultArt As Decimal
            Dim TotalMonto As Decimal

            For Each oSourceRow In Source.Tables(0).Rows

                If (strCodigo <> oSourceRow.Item(0).ToString) Then

                    If (Not oTargetSource Is Nothing) Then

                        dtMainTable.Rows.Add(oTargetSource)
                        oTargetSource("TotalA") = TotalResult
                        TotalResult = 0

                    End If

                    strCodigo = oSourceRow.Item(0).ToString
                    oTargetSource = dtMainTable.NewRow()

                    oTargetSource("Codigo") = UCase(strCodigo)
                    oTargetSource("Descripcion") = oSourceRow.Item(1).ToString
                    oTargetSource("Descripcion") = UCase(CStr(oSourceRow("Descripcion")))
                    intColTalla = 1

                End If

                oTargetSource("Talla" & intColTalla.ToString("00")) = oSourceRow("Numero")
                oTargetSource("Total" & intColTalla.ToString("00")) = oSourceRow("TotalMes")



                intColTalla += 1
                TotalArt = CType(oSourceRow("TotalMes"), Integer)
                TotalResult += TotalArt
                TotalResultArt += TotalArt

            Next
            oTargetSource("TotalA") = TotalResult
            dtMainTable.Rows.Add(oTargetSource)

            oTargetSource = dtMainTable.NewRow()
            oTargetSource("TotalA") = TotalResultArt
            oTargetSource("Codigo") = "TOTAL DE PARES"
            dtMainTable.Rows.Add(oTargetSource)

            dtMainTable.AcceptChanges()

            '</TraspasarInformacion>

            Return dsTarget
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function FormatDataSetInvCodigo(ByVal Source As DataSet) As DataSet

        Dim dsTarget As New DataSet("ReporteInventario")
        Dim dtMainTable As New DataTable("ReporteInventario")

        'Columna: Codigo
        Dim dcCodigo As DataColumn = New DataColumn
        With dcCodigo
            .DataType = System.Type.GetType("System.String")
            .Caption = "Codigo"
            .ColumnName = "Codigo"
        End With
        dtMainTable.Columns.Add(dcCodigo)

        'Columna: Descripcion
        Dim dcDescripcion As DataColumn = New DataColumn
        With dcDescripcion
            .DataType = System.Type.GetType("System.String")
            .Caption = "Descripcion"
            .ColumnName = "Descripcion"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescripcion)

        'Columna: Total Artículos
        Dim dcTotalA As DataColumn = New DataColumn
        With dcTotalA
            .DataType = System.Type.GetType("System.String")
            .Caption = "Total Artículos"
            .ColumnName = "TotalA"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcTotalA)
        'Columna: Color
        Dim dcColor As DataColumn = New DataColumn
        With dcColor
            .DataType = System.Type.GetType("System.String")
            .Caption = "Total Artículos"
            .ColumnName = "Color"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcColor)

        'Columna: Tallas
        Dim dcTalla As DataColumn
        Dim intTalla As Integer
        For intTalla = 1 To 20
            dcTalla = New DataColumn
            With dcTalla
                .DataType = System.Type.GetType("System.Decimal")
                .Caption = "Talla" & intTalla.ToString("00")
                .ColumnName = "Talla" & intTalla.ToString("00")
            End With
            dtMainTable.Columns.Add(dcTalla)

        Next

        'Columna: Totales
        Dim dcTotal As DataColumn
        Dim intTotal As Integer
        For intTotal = 1 To 20
            dcTotal = New DataColumn
            With dcTotal
                .DataType = System.Type.GetType("System.Int32")
                .Caption = "Total" & intTotal.ToString("00")
                .ColumnName = "Total" & intTotal.ToString("00")
            End With
            dtMainTable.Columns.Add(dcTotal)
        Next

        dsTarget.Tables.Add(dtMainTable)

        Dim oSourceRow As DataRow
        Dim oTargetSource As DataRow

        Dim strCodigo As String
        Dim intColTalla As Integer
        Dim TotalArt As Decimal
        Dim TotalResult As Decimal
        Dim TotalResultArt As Decimal
        Dim TotalMonto As Decimal

        For Each oSourceRow In Source.Tables(0).Rows

            If (strCodigo <> oSourceRow.Item(0).ToString) Then

                If (Not oTargetSource Is Nothing) Then

                    dtMainTable.Rows.Add(oTargetSource)
                    oTargetSource("TotalA") = TotalResult
                    TotalResult = 0

                End If

                strCodigo = oSourceRow.Item(0).ToString
                oTargetSource = dtMainTable.NewRow()

                oTargetSource("Codigo") = UCase(strCodigo)
                oTargetSource("Descripcion") = oSourceRow.Item(1).ToString
                oTargetSource("Descripcion") = UCase(CStr(oSourceRow("Descripcion")))
                oTargetSource("Color") = oSourceRow.Item(2).ToString
                oTargetSource("Color") = UCase(CStr(oSourceRow("Color")))
                intColTalla = 1

            End If

            oTargetSource("Talla" & intColTalla.ToString("00")) = oSourceRow("Numero")
            oTargetSource("Total" & intColTalla.ToString("00")) = oSourceRow("TotalMes")

            intColTalla += 1
            TotalArt = CType(oSourceRow("TotalMes"), Integer)
            TotalResult += TotalArt
            TotalResultArt += TotalArt

            TotalMonto += CType(oSourceRow("Costo"), Decimal)

        Next
        oTargetSource("TotalA") = TotalResult
        dtMainTable.Rows.Add(oTargetSource)

        oTargetSource = dtMainTable.NewRow()
        oTargetSource("Codigo") = "TOTAL COSTO/P.P."
        oTargetSource("Color") = Format(TotalMonto, "currency")
        oTargetSource("TotalA") = TotalResultArt
        dtMainTable.Rows.Add(oTargetSource)

        dtMainTable.AcceptChanges()

        '</TraspasarInformacion>

        Return dsTarget

    End Function

    Private Function FormatDataSetMov(ByVal Source As DataSet) As DataSet

        Dim dsTarget As New DataSet("ReporteInventario")
        Dim dtMainTable As New DataTable("ReporteInventario")

        'Columna: Origen
        Dim dcOrigen As DataColumn = New DataColumn
        With dcOrigen
            .DataType = System.Type.GetType("System.String")
            .Caption = "Origen"
            .ColumnName = "Origen"
        End With
        dtMainTable.Columns.Add(dcOrigen)

        'Columna: Referencia
        Dim dcReferencia As DataColumn = New DataColumn
        With dcReferencia
            .DataType = System.Type.GetType("System.String")
            .Caption = "Referencia"
            .ColumnName = "Referencia"
        End With
        dtMainTable.Columns.Add(dcReferencia)

        'Columna: Fechas
        Dim dcFechas As DataColumn = New DataColumn
        With dcFechas
            .DataType = System.Type.GetType("System.String")
            .Caption = "Fechas"
            .ColumnName = "Fechas"
        End With
        dtMainTable.Columns.Add(dcFechas)

        'Columna: Descripcion
        Dim dcDescripcion As DataColumn = New DataColumn
        With dcDescripcion
            .DataType = System.Type.GetType("System.String")
            .Caption = "Descripcion"
            .ColumnName = "Descripcion"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcDescripcion)

        'Columna: Entrada
        Dim dcEntradas As DataColumn = New DataColumn
        With dcEntradas
            .DataType = System.Type.GetType("System.String")
            .Caption = "Entradas"
            .ColumnName = "Entradas"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcEntradas)

        'Columna: Salida
        Dim dcSalidas As DataColumn = New DataColumn
        With dcSalidas
            .DataType = System.Type.GetType("System.String")
            .Caption = "Salidas"
            .ColumnName = "Salidas"
            '.DefaultValue = 25
        End With
        dtMainTable.Columns.Add(dcSalidas)

        Dim oSourceRow As DataRow
        Dim oTargetSource As DataRow

        Dim strCodigo As String

        For Each oSourceRow In Source.Tables(0).Rows

            strCodigo = oSourceRow.Item(1).ToString

            oTargetSource("Origen") = oSourceRow("CodAlmacen")
            oTargetSource("Referencia") = oSourceRow("Referencia")
            oTargetSource("Fecha") = oSourceRow("Fecha")
            oTargetSource("Descripcion") = oSourceRow("Descripcion")
            oTargetSource("Entradas") = oSourceRow("Entradas")
            oTargetSource("Salidas") = oSourceRow("Salidas")

            dtMainTable.Rows.Add(oTargetSource)
            oTargetSource = dtMainTable.NewRow()
        Next

        dtMainTable.AcceptChanges()

        '</TraspasarInformacion>

        Return dsTarget

    End Function


    Public Function GetInventarioLineaFamilia(ByVal Mes As String, ByVal CodLinea As String, ByVal CodFamilia As String, Optional ByVal band As Boolean = False) As DataSet

        'TODO: CLM - Ejecutar el sproc ReportInvLineaFamilia

        'El sproc ReportInvLineaFamilia tiene los parametros
        '   - Mes: Cadena con el número correspondiente al mes
        '   -CodLinea: Cadena
        '   -CodFamilia: Cadena


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvXCod As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvXCod

        With scRepInvXCod

            .CommandText = "ReportInvLineaFamilia"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@Mes").Value = Mes
            .Parameters("@CodLinea").Value = CodLinea
            .Parameters("@CodFamilia").Value = CodFamilia

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "Inventario")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            If band = False Then
                dsFormatedResult = FormatDataSet(dsResult)
            Else
                dsFormatedResult = dsResult.Copy
            End If


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

    Public Function GetInventarioReportesVarios(ByVal oInventarioReportesVarios As InventarioReportesVarios) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvVarios As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvVarios

        With scRepInvVarios

            If oInventarioReportesVarios.Dip = 1 Then
                .CommandText = "ReporteInventariosVariosDIPSel"
            Else
                .CommandText = "ReporteInventariosVariosSel"
            End If
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodOrigen", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Dip", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoFiltro", System.Data.SqlDbType.Int, 1))

            .Parameters("@CodAlmacen").Value = oInventarioReportesVarios.CodAlmacen
            .Parameters("@Mes").Value = oInventarioReportesVarios.Mes
            .Parameters("@CodMarca").Value = oInventarioReportesVarios.CodMarca
            .Parameters("@CodOrigen").Value = oInventarioReportesVarios.CodOrigen
            .Parameters("@CodLinea").Value = oInventarioReportesVarios.CodLinea
            .Parameters("@CodFamilia").Value = oInventarioReportesVarios.CodFamilia
            .Parameters("@Dip").Value = oInventarioReportesVarios.Dip
            .Parameters("@TipoFiltro").Value = oInventarioReportesVarios.TipoFiltro

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "Inventario")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = FormatDataSet(dsResult)

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

    Public Function GetReporteCostoInventarios(ByVal CodAlmacen As String, ByVal Marca As String, ByVal CodLinea As String, ByVal CodFamilia As String) As DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("ReporteCostoInventario", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim result As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            With command
                .Parameters.Add("@CodAlmacen", CodAlmacen)
                .Parameters.Add("@Marca", Marca)
                .Parameters.Add("@CodLinea", CodLinea)
                .Parameters.Add("@CodFamilia", CodFamilia)
            End With
            adapter = New SqlDataAdapter(command)
            adapter.Fill(result)
            command.Dispose()
            conexion.Close()
        Catch sql As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error al generar el reporte de Costos de Inventario", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return result
    End Function

    Public Function GetInventarioReportesVariosToReport(ByVal oInventarioReportesVarios As InventarioReportesVarios) As DataSet


        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvVarios As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvVarios

        With scRepInvVarios

            If oInventarioReportesVarios.Dip = 1 Then
                .CommandText = "ReporteInventariosVariosDIPSel"
            Else
                .CommandText = "ReporteInventariosVariosSel"
            End If
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodOrigen", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Dip", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipoFiltro", System.Data.SqlDbType.Int, 1))

            .Parameters("@CodAlmacen").Value = oInventarioReportesVarios.CodAlmacen
            .Parameters("@Mes").Value = oInventarioReportesVarios.Mes
            .Parameters("@CodMarca").Value = oInventarioReportesVarios.CodMarca
            .Parameters("@CodOrigen").Value = oInventarioReportesVarios.CodOrigen
            .Parameters("@CodLinea").Value = oInventarioReportesVarios.CodLinea
            .Parameters("@CodFamilia").Value = oInventarioReportesVarios.CodFamilia
            .Parameters("@Dip").Value = oInventarioReportesVarios.Dip
            .Parameters("@TipoFiltro").Value = oInventarioReportesVarios.TipoFiltro

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "Inventario")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = dsResult.Copy
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


    Public Function GetInventarioReporteDefectuosos(ByVal strAlmacen As String) As DataSet

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvDefectuosos As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet

        scReporteInventarioAdapter.SelectCommand = scRepInvDefectuosos

        With scRepInvDefectuosos

            .CommandText = "ReporteInventarioDefectuososSel"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodAlmacen").Value = strAlmacen

        End With

        Try

            scConnection.Open()

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "Defectuosos")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = FormatDataSet(dsResult)

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

#End Region

#Region "Inventario Articulos Sin Movimientos"

    Public Function GetArticulosSinMovimientos(ByVal CodMarca As String, ByVal CodLinea As String, ByVal CodFamilia As String, ByVal Dias As Integer, ByVal CodAlmacen As String) As DataSet

        Dim scConnection As New SqlConnection(m_strConnectionString)
        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim scRepInvXCod As New SqlCommand
        Dim dsResult As DataSet
        Dim dsFormatedResult As DataSet



        With scRepInvXCod

            .CommandText = "[ReporteArticulosSinMovimientos]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = scConnection

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Dias", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@Dias").Value = Dias
            .Parameters("@CodMarca").Value = CodMarca
            .Parameters("@CodLinea").Value = CodLinea
            .Parameters("@CodFamilia").Value = CodFamilia
            .Parameters("@CodAlmacen").Value = CodAlmacen

        End With

        Try

            scConnection.Open()

            scReporteInventarioAdapter.SelectCommand = scRepInvXCod

            dsResult = New DataSet
            dsFormatedResult = New DataSet

            scReporteInventarioAdapter.Fill(dsResult, "Inventario")

            If dsResult.Tables(0).Rows.Count = 0 Then
                dsResult = Nothing
                Exit Function
            End If

            dsFormatedResult = dsResult.Copy



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

#End Region


#Region "Inventario Articulos Mas Vendidos"

    Public Function MasVendidos(ByVal num As Integer, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim dsResult As New DataSet

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        scReporteInventarioAdapter.SelectCommand = sccmdInsert

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "SELECT DISTINCT TOP " & num & " FacturaCorrida.CodArticulo, " & _
                            "						CatalogoArticulos.Descripcion,  " & _
                            "						CatalogoFamilias.Descripcion AS Familia,  " & _
                            "						CatalogoLineas.Descripcion AS Linea,  " & _
                            "						CatalogoArticulos.CodCorrida, " & _
                            "						CASE FacturaCorrida.DescuentoSistema " & _
                            "							WHEN 0 THEN	 " & _
                            "								CASE FacturaCorrida.Descuento " & _
                            "										WHEN  0 THEN SUM(FacturaCorrida.PrecioUnit)  " & _
                            "										ELSE SUM(FacturaCorrida.PrecioUnit - (FacturaCorrida.PrecioUnit * (FacturaCorrida.Descuento/100))) " & _
                            "								END " & _
                            "							ELSE	 " & _
                            "								CASE FacturaCorrida.Descuento " & _
                            "											WHEN  0 THEN SUM(FacturaCorrida.PrecioUnit - (FacturaCorrida.PrecioUnit * (FacturaCorrida.DescuentoSistema/100))) " & _
                            "											ELSE  SUM((FacturaCorrida.PrecioUnit - ((FacturaCorrida.PrecioUnit * (FacturaCorrida.DescuentoSistema/100)) * (FacturaCorrida.Descuento/100)))) " & _
                            "								END									" & _
                            "							END AS MontoConDescuento " & _
                            "FROM         CatalogoArticulos  " & _
                            "INNER JOIN " & _
                            "                      FacturaCorrida ON CatalogoArticulos.CodArticulo = FacturaCorrida.CodArticulo  " & _
                            "INNER JOIN " & _
                            "                      CatalogoLineas ON CatalogoArticulos.CodLinea = CatalogoLineas.CodLinea  " & _
                            "INNER JOIN " & _
                            "                      CatalogoFamilias ON CatalogoArticulos.CodFamilia = CatalogoFamilias.CodFamilia " & _
                            "WHERE     (FacturaCorrida.Fecha BETWEEN convert(datetime, '" & datFechaIni.ToShortDateString & "', 103) AND convert(datetime, '" & datFechaFin.ToShortDateString & "', 103))" & _
                            "GROUP BY  " & _
                            "					FacturaCorrida.CodArticulo,  " & _
                            "					CatalogoArticulos.Descripcion,  " & _
                            "					CatalogoFamilias.Descripcion,  " & _
                            "					CatalogoLineas.Descripcion, " & _
                            "					CatalogoArticulos.CodCorrida,  " & _
                            "                   FacturaCorrida.Descuento,  " & _
                            "					FacturaCorrida.DescuentoSistema " & _
                            "ORDER BY MontoConDescuento DESC, FacturaCorrida.CodArticulo "

            '"WHERE     (FacturaCorrida.Fecha BETWEEN '" & Format(datFechaIni, "dd/MM/yyyy") & "' AND '" & Format(datFechaFin, "dd/MM/yyyy") & "')" & _
            .CommandType = System.Data.CommandType.Text
            .Connection = sccnnConnection
        End With

        Try

            sccnnConnection.Open()

            scReporteInventarioAdapter.Fill(dsResult)

            Return dsResult


            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Nothing

    End Function

    Public Function CodigosMasVendidos(ByVal num As Integer, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime, ByVal TopTen As Boolean) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim dsResult As New DataSet

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        scReporteInventarioAdapter.SelectCommand = sccmdInsert

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "ReporteMasMenosVendidos"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection

            .Parameters.Add(New SqlParameter("@Num", SqlDbType.VarChar, 4, "Numero de Articulos a Mostrar"))
            .Parameters.Add(New SqlParameter("@FechaIni", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@FechaFin", SqlDbType.VarChar, 10))
            .Parameters.Add(New SqlParameter("@Top", SqlDbType.Bit, 1, "1 = Top 10, 0 = Last 10"))
        End With

        Try

            With sccmdInsert
                .Parameters("@Num").Value = num.ToString
                .Parameters("@FechaIni").Value = datFechaIni.ToShortDateString
                .Parameters("@FechaFin").Value = datFechaFin.ToShortDateString
                .Parameters("@Top").Value = TopTen
            End With

            sccnnConnection.Open()

            scReporteInventarioAdapter.Fill(dsResult)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsResult.Tables(0)

    End Function

    Public Function ArticuloFactCorrida(ByVal strCodArticulo As String) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim dsResult As New DataSet

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        scReporteInventarioAdapter.SelectCommand = sccmdInsert

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "SELECT Numero, SUM(Libre) AS Total " & _
                            " FROM Existencias " & _
                            " WHERE CodArticulo='" & strCodArticulo & "'" & _
                            " GROUP BY  Numero"
            .CommandType = System.Data.CommandType.Text
            .Connection = sccnnConnection
        End With

        Try

            sccnnConnection.Open()

            scReporteInventarioAdapter.Fill(dsResult)

            Return dsResult


            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Nothing

    End Function

    Public Function Corrida(ByVal CORR As String) As DataSet


        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim scReporteInventarioAdapter As New SqlDataAdapter
        Dim dsResult As New DataSet

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand
        scReporteInventarioAdapter.SelectCommand = sccmdInsert

        With sccmdInsert
            .Connection = sccnnConnection
            .CommandText = "SELECT     C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C13, C14, C15, C16, C17, C12, C18, C19, C20 " & _
                           "FROM CatalogoCorridas " & _
                           "WHERE   CODCORRIDA='" & CORR & "'"
            .CommandType = System.Data.CommandType.Text
            .Connection = sccnnConnection
        End With

        Try

            sccnnConnection.Open()

            scReporteInventarioAdapter.Fill(dsResult)

            Return dsResult


            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing
        Return Nothing


    End Function

    Public Function ArticulosVendidos(ByVal strCodArticulo As String, ByVal strTalla As String, ByVal datFechaIni As DateTime, ByVal datFechaFin As DateTime) As Decimal

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim oResult As Decimal

        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "  SELECT    SUM(Cantidad)  as ArtVendidos" & _
                            " FROM      FacturaCorrida " & _
                            " WHERE     (convert(varchar(10),Fecha,101) BETWEEN convert(varchar(10),cast('" & datFechaIni.ToShortDateString & "' as datetime),101) AND convert(varchar(10),cast('" & datFechaFin.ToShortDateString & "' as datetime),101)) " & _
                            " AND CodArticulo='" & strCodArticulo & "' and Numero='" & strTalla & "'"
            .CommandType = System.Data.CommandType.Text

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    If scdReader.IsDBNull(0) = True Then

                        oResult = 0

                    Else

                        oResult = scdReader.GetDecimal(0)

                    End If

                Else

                    oResult = 0

                End If

                scdReader = Nothing

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult


    End Function

#End Region

#Region "Reporte Inventarios Descuentos"
    Public Function GetReporteInventarios(ByVal limInf As Integer, ByVal limSup As Integer, ByVal codMarca As String, ByVal codLinea As String, ByVal codFamilia As String, ByVal codUso As String) As DataTable
        Dim dtReporte As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("GetInventarioDescuentos", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@LimInf", limInf)
            command.Parameters.Add("@LimSup", limSup)
            command.Parameters.Add("@CodMarca", codMarca)
            command.Parameters.Add("@CodLinea", codLinea)
            command.Parameters.Add("@CodFamilia", codFamilia)
            command.Parameters.Add("@CodUso", codUso)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtReporte)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message)
        End Try
        Return dtReporte
    End Function
#End Region


#Region "Venta de Electronicos"

    Public Function GetInventarioElectronicos(ByVal Almacen As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ReporteInventarioElectronicos]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters("@CodAlmacen").Value = Almacen

        End With

        Dim oFacturaAdapter As SqlDataAdapter
        oFacturaAdapter = New SqlDataAdapter
        oFacturaAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oFacturaAdapter.Fill(oResult, "ReporteInvElectronicos")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

#End Region


End Class
