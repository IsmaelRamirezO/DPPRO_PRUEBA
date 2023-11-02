Imports System.Data.SqlClient

Public Class LiveUpdateDataGateway

    Dim oParent As LiveUpdateManager
    Dim m_strConnectionString As String

#Region "Constructor / Destructor"

    Public Sub New(ByVal Parent As LiveUpdateManager)

        oParent = Parent
        'm_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString
        m_strConnectionString = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                oParent.ConfigCierreFI.BaseDatosHuellas & "; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                oParent.ConfigCierreFI.PassHuellas()

    End Sub

#End Region

#Region "Methods"

    Public Function SelectUltimaVersion(ByVal Sistema As String, ByRef Critica As Boolean, ByVal Almacen As String) As Long

        Dim decResult As Long

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString)

        Dim sccmdUltimaVSel As SqlCommand
        sccmdUltimaVSel = New SqlCommand

        With sccmdUltimaVSel
            .CommandText = "[SelectUltimaVersion]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 4, "CodAlmacen"))

            .Parameters("@CodAlmacen").Value = Almacen.Trim 'Sistema
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdUltimaVSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    If Sistema.Trim = "UV" Then
                        decResult = CLng(.GetString(.GetOrdinal("Version"))) 'Version
                    Else
                        decResult = CLng(.GetString(.GetOrdinal("LiveUpdate")))
                    End If
                    Critica = .GetBoolean(.GetOrdinal("Critica"))
                End With
                scsdrReader.Close()

            Else

                decResult = 0

            End If


        Catch oSqlException As SqlException

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                    decResult = 0
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)
            MessageBox.Show("El registro no pudo ser leido debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

        Catch ex As Exception

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                    decResult = 0
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
            MessageBox.Show("El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString)

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdUltimaVSel.Dispose()
        sccmdUltimaVSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return decResult

    End Function

    Public Function SelectVersionSucursal(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As String) As Long

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim decResult As Long

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[VersionSucursalSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "Codigo Almacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3, "Codigo CodCaja"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@CodAlmacen").Value = CodAlmacen
                .Parameters("@CodCaja").Value = CodCaja.Trim

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        decResult = CLng(.GetString(.GetOrdinal(Version)))

                    End With

                Else

                    decResult = 0

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

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)
            MessageBox.Show("El registro no pudo ser leido debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)
            MessageBox.Show("El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return decResult

    End Function

    Public Sub VersionSucursalUpdate(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As Long, ByVal Campo As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[VersionSucursalUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3, "CodCaja"))
            .Parameters.Add(New SqlParameter("@Version", SqlDbType.VarChar, 10, "Version"))
            .Parameters.Add(New SqlParameter("@Campo", SqlDbType.VarChar, 15, "Campo"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = CodAlmacen
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@Version").Value = CStr(Version)
                .Parameters("@Campo").Value = Campo

                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            MessageBox.Show("El registro no pudo ser leido debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            MessageBox.Show("El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString)

        End Try


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    '--------------------------------------------------------------------------------------------------------------
    ' FLIZARRAGA 12/01/2018: Metodo para actualizar la version de windows sql, fecha y ciudad en la tabla de VersionSucursal
    '--------------------------------------------------------------------------------------------------------------
    Public Sub VersionSucursalUpdateWindowsSQL(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Windows As String, ByVal SQL As String, ByVal Ciudad As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[VersionSucursalUpdWindowsSQL]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3, "CodCaja"))
            .Parameters.Add(New SqlParameter("@Windows", SqlDbType.VarChar, 50, "Windows"))
            .Parameters.Add(New SqlParameter("@SQL", SqlDbType.VarChar, 50, "SQL"))
            .Parameters.Add(New SqlParameter("@Ciudad", SqlDbType.VarChar, 113, "Ciudad"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = CodAlmacen
                .Parameters("@CodCaja").Value = CodCaja
                .Parameters("@Windows").Value = Windows
                .Parameters("@SQL").Value = SQL
                .Parameters("@Ciudad").Value = Ciudad
                'Execute Command
                .ExecuteNonQuery()

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MessageBox.Show("El registro no pudo ser leido debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MessageBox.Show("El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString)

        End Try

        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region

End Class
