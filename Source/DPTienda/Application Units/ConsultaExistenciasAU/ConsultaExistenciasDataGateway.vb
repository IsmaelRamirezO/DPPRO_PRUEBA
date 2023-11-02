Imports System
Imports System.Data
Imports System.Data.SqlClient

Friend Class ConsultaExistenciasDataGateway

    Private oParent As ConsultaExistenciasAbstract
    Private m_strConnectionString As String


#Region "Constructors"

    Public Sub New(ByVal Parent As ConsultaExistenciasAbstract)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region
    Public Function [Select](ByVal ArticuloID As String, ByVal AlmacenID As String, ByVal BuscaPadre As Boolean) As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim dsExistencias As New DataSet

        sccmdSelect = New SqlCommand
        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ConsultaExistenciasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@BuscaPadre", System.Data.SqlDbType.Bit, 1))
            .Parameters("@CodArticulo").Value = ArticuloID
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim 'AlmacenID
            .Parameters("@BuscaPadre").Value = BuscaPadre
        End With

        Try
            sccnnConnection.Open()
            Dim adExistencias As New SqlDataAdapter(sccmdSelect)
            adExistencias.Fill(dsExistencias, "Existencias")
            sccnnConnection.Close()

            '------------------------------------------------------------------
            ' JNAVA (31.03.2016): Ponemos acento a almacen
            '------------------------------------------------------------------
            dsExistencias.Tables("Existencias").Columns("Almacen").ColumnName = "Almacén"

            Return dsExistencias
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
        Return Nothing
    End Function




    Public Function SelectByID(ByVal ID As Integer) As ResultadoConsultaExistencias
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim pResultadoCE As ResultadoConsultaExistencias

        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ConsultaExistenciasSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
        End With

        Try
            sccnnConnection.Open()
            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodArticulo").Value = ID
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                'Assign Other Values
                scdrReader.Read()
                If (scdrReader.HasRows) Then
                    With scdrReader
                        pResultadoCE.ArticuloID = .GetString(0)
                        pResultadoCE.Descripcion = .GetString(1)
                        'Reset New State of ResultadoConsultaExistencias Object 
                        pResultadoCE.ResetStateNew()
                        pResultadoCE.ResetStateDirty()
                    End With
                Else
                    pResultadoCE = Nothing
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

        If (pResultadoCE Is Nothing) Then
            Throw New ApplicationException("El registro no pudo ser leido debido a que el ID de Uso no existe.")
        End If

        Return pResultadoCE

    End Function



    Public Function SelectAll(ByVal EnabledRecordsOnly As Boolean) As DataSet
        'Dim sccnnConnection As New SqlConnection(m_strConnectionString)
        'Dim sccmdSelectAll As SqlCommand
        'Dim scdaUsos As SqlDataAdapter
        'Dim dsUsos As DataSet

        'sccmdSelectAll = New SqlCommand
        'scdaUsos = New SqlDataAdapter
        'dsUsos = New DataSet("CatalogoUsos")

        'With sccmdSelectAll

        '    .Connection = sccnnConnection

        '    .CommandText = "[CatalogoUsosSelAll]"
        '    .CommandType = System.Data.CommandType.StoredProcedure

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

        'End With

        'scdaUsos.SelectCommand = sccmdSelectAll

        'Try

        '    sccnnConnection.Open()

        '    scdaUsos.SelectCommand.Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        '    'Fill DataSet
        '    scdaUsos.Fill(dsUsos, "CatalogoUsos")

        '    sccnnConnection.Close()

        'Catch oSqlException As SqlException

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        'Catch ex As Exception

        '    If (sccnnConnection.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnConnection.Close()
        '        Catch
        '        End Try
        '    End If

        '    Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        'End Try

        'Return dsUsos
    End Function


    Public Function [SelectPlaza](ByVal ArticuloID As String, ByVal PlazaID As String) As DataSet


        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand

        Dim dsExistencias As New DataSet


        sccmdSelect = New SqlCommand

        With sccmdSelect

            .CommandText = "[ConsultaExistenciasPlazaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@CodArticulo").Value = ArticuloID
            .Parameters("@CodPlaza").Value = PlazaID

        End With


        Try

            sccnnConnection.Open()

            Dim adExistencias As New SqlDataAdapter(sccmdSelect)

            adExistencias.Fill(dsExistencias, "ExistenciasPlaza")


            sccnnConnection.Close()

            Return dsExistencias

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


        Return Nothing


    End Function
End Class



