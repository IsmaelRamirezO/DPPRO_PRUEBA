Imports System
Imports System.Data
Imports System.Data.SqlClient

Friend Class ClientesExtendedDataGateway
    Private oParent As ClientesManager
    Private m_strConnectionString As String

    Public Sub New(ByVal Parent As ClientesManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#Region "Methods"

    Friend Function LoadAllStates(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoEstadosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oEstadosAdapter As SqlDataAdapter
        oEstadosAdapter = New SqlDataAdapter
        oEstadosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oEstadosAdapter.Fill(oResult, "CatalogoEstados")

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

        Return oResult.Tables(0)

    End Function

    Friend Function LoadAllMunicipio(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoMunicipiosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oMunicipiosAdapter As SqlDataAdapter
        oMunicipiosAdapter = New SqlDataAdapter
        oMunicipiosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oMunicipiosAdapter.Fill(oResult, "CatalogoCiudades")

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

        Return oResult.Tables(0)

    End Function

    Friend Function LoadAllPlazas(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoPlazasSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oPlazasAdapter As SqlDataAdapter
        oPlazasAdapter = New SqlDataAdapter
        oPlazasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oPlazasAdapter.Fill(oResult, "CatalogoPlazas")

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

        Return oResult.Tables(0)

    End Function

    Friend Function LoadAllAlmacen(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoAlmacenesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oAlmacenesAdapter As SqlDataAdapter
        oAlmacenesAdapter = New SqlDataAdapter
        oAlmacenesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oAlmacenesAdapter.Fill(oResult, "CatalogoAlmacenes")

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

        Return oResult.Tables(0)

    End Function

    Friend Function LoadZipCode(ByVal CodEstado As Integer, ByVal CodCiudad As Integer, ByVal CodPostal As String) As Boolean

        Dim oResult As Boolean = False
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "SELECT ID, CodPostal FROM CatalogoCodigoPostal WHERE CodEstado = " & CodEstado & _
                            " And CodMunicipio = " & CodCiudad & " And CodPostal = '" & CodPostal & "'"
            .CommandType = System.Data.CommandType.Text

        End With

        Dim oAlmacenesAdapter As SqlDataAdapter
        oAlmacenesAdapter = New SqlDataAdapter
        oAlmacenesAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            scdrReader = sccmdSelect.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scdrReader.Read()

            If scdrReader.HasRows Then

                oResult = True

            Else

                oResult = False

            End If


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

    Public Function [Select](ByVal ID As String, ByVal CodMuni As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaCiudades As SqlDataAdapter
        Dim dsCiudades As DataSet

        sccmdSelectAll = New SqlCommand
        scdaCiudades = New SqlDataAdapter
        dsCiudades = New DataSet("Codigos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "SELECT Min(CodPostal) as Rango1, Max(CodPostal)as Rango2 FROM CatalogoCodigoPostal WHERE CodEstado like '" & ID & "' And CodMunicipio =" & CodMuni
            '"SELECT distinct (CodPostal) FROM CatalogoCodigoPostal WHERE CodEstado = " & ID & " And CodMunicipio = " & CodMuni & " order by CodPostal"
            .CommandType = System.Data.CommandType.Text

        End With

        scdaCiudades.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            'Fill DataSet
            scdaCiudades.Fill(dsCiudades, "Codigos")

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsCiudades

    End Function

#End Region

End Class
