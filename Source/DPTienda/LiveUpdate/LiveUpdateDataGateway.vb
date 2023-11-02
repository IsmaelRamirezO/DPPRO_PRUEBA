Imports System.Data.SqlClient
'Imports 
'Imports Microsoft.SqlServer.Management.Smo

Public Class LiveUpdateDataGateway

    'Private oParent As LiveUpdateManager
    Dim m_strConnectionString As String = ""

#Region "Constructors / Destructors"

    Public Sub New(ByVal ConnectionString As String)
        'oParent = Parent
        m_strConnectionString = ConnectionString
    End Sub

#End Region

    Public Function SelectUltimaVersion(ByVal Sistema As String, ByVal Almacen As String) As Long

        Dim decResult As Long

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionString) 'oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdUltimaVSel As SqlCommand
        sccmdUltimaVSel = New SqlCommand

        With sccmdUltimaVSel
            .CommandText = "[SelectUltimaVersion]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New SqlParameter("@CodAlmacen", SqlDbType.VarChar, 4, "CodAlmacen"))

            .Parameters("@CodAlmacen").Value = Almacen.Trim
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdUltimaVSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    If Sistema.Trim.ToUpper = "UV" Then
                        decResult = CLng(.GetString(.GetOrdinal("Version"))) 'Version
                    Else
                        decResult = CLng(.GetString(.GetOrdinal("LiveUpdate")))
                    End If
                End With

            Else

                decResult = 0

            End If

            scsdrReader.Close()

        Catch oSqlException As SqlException

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            MessageBox.Show("El registro no pudo ser insertado debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

        Catch ex As Exception

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
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

        Dim sccnnConnection As New SqlConnection(m_strConnectionString) 'oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim decResult As Long

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[VersionSucursalSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "Codigo Almacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 3, "Codigo Caja"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@CodAlmacen").Value = CodAlmacen
                .Parameters("@CodCaja").Value = CodCaja

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
            MessageBox.Show("El registro no pudo ser leido debido a un error de aplicación." & vbCrLf & ex.ToString)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return decResult

    End Function

    Public Sub VersionSucursalUpdate(ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Version As Long, ByVal Campo As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString) 'oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

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
                .Parameters("@CodCaja").Value = CodCaja.Trim
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
            MessageBox.Show("El registro no pudo ser insertado debido a un error de base de datos." & vbCrLf & oSqlException.ToString)

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

    Public Function EjecutaSPVersion(ByVal query As String) As Boolean

        'Dim sccnnConnection As New SqlConnection(m_strConnectionString) 'oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccnnConnection As New SqlConnection("Server=" & strServer & ";Data Source=" & strServer & ";Initial Catalog=" & strDatabase & ";User ID=" & _
                      strUser & ";Password=" & strPassword & ";Application Name=;Connection Timeout=120;")

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        Dim bRes As Boolean = False

        With sccmdUpdate

            .Connection = sccnnConnection
            '.CommandText = query '"[VersionSucursalUpd]"
            .CommandType = System.Data.CommandType.Text

        End With
        Dim linea As Integer = 0
        Dim strQuery As String = ""
1:      Dim strQuerys() As String = query.Split("|")
        Try

            ' Dim scsdrReader As SqlDataReader
            

2:          sccnnConnection.Open()

            With sccmdUpdate

3:              For Each strQuery In strQuerys
4:                  If Not strQuery Is Nothing AndAlso strQuery.Trim <> "" Then

5:                      .CommandText = strQuery.Trim
                        'Execute Command
6:                      .ExecuteNonQuery()
                        linea += 1
                    End If
                Next

7:              bRes = True
                'scsdrReader = .ExecuteReader(CommandBehavior.SingleResult)

            End With

8:          sccnnConnection.Close()

        Catch oSqlException As SqlException
            Console.WriteLine("Aqui lloro " & CStr(linea))
            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            bRes = False
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)
            'MessageBox.Show("El registro no pudo ser insertado debido a un error de base de datos." & vbCrLf & oSqlException.ToString)
            EscribeLog(oSqlException.ToString, "Error al ejecutar el SP en la base de datos: Linea " & Err.Erl)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            bRes = False
            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)
            'MessageBox.Show("El registro no pudo ser insertado debido a un error de aplicación." & vbCrLf & ex.ToString)
            EscribeLog(ex.ToString, "Error de aplicación al ejecutar el SP de la versión: Linea " & Err.Erl)

        End Try

        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bRes

    End Function

End Class
