Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class InicioCajaDataGateway

    Private oParent As InicioCajaManager
    Private m_strConnectionString As String

    Public Sub New(ByVal Parent As InicioCajaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub


#Region "Methods"

    Public Sub Insert(ByVal oInicioCaja As InicioCaja)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[InicioCajaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioCajaID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "InicioCajaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int, 4, "InicioDiaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicio", System.Data.SqlDbType.DateTime, 8, "FechaInicio"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioFactura", System.Data.SqlDbType.Int, 4, "FolioFactura"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4, "FolioApartado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaCredito", System.Data.SqlDbType.Int, 4, "FolioNotaCredito"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioAbono", System.Data.SqlDbType.Int, 4, "FolioAbono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fondo", System.Data.SqlDbType.Money, 4, "Fondo"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Retiro", System.Data.SqlDbType.Money, 4, "Retiro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroAutomatico", System.Data.SqlDbType.Money, 4, "RetiroAutomatico"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioNotaVentaManual", System.Data.SqlDbType.Int, 4, "FolioNotaVentaManual"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@InicioCajaID").Value = oInicioCaja.InicioCajaID
                .Parameters("@InicioDiaID").Value = oInicioCaja.InicioDiaID
                .Parameters("@CodCaja").Value = oInicioCaja.CodCaja
                .Parameters("@FechaInicio").Value = oInicioCaja.FechaInicio
                .Parameters("@FolioFactura").Value = oInicioCaja.FolioFactura
                .Parameters("@FolioApartado").Value = oInicioCaja.FolioApartado
                .Parameters("@FolioNotaCredito").Value = oInicioCaja.FolioNotaCredito
                .Parameters("@FolioAbono").Value = oInicioCaja.FolioAbono
                .Parameters("@Fondo").Value = oInicioCaja.Fondo
                .Parameters("@Retiro").Value = oInicioCaja.Retiro
                .Parameters("@RetiroAutomatico").Value = oInicioCaja.RetiroAutomatico
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Fecha").Value = Date.Today
                .Parameters("@StatusRegistro").Value = oInicioCaja.StatusRegistro
                .Parameters("@FolioNotaVentaManual").Value = oInicioCaja.FolioNotaVentaManual

                'Execute Command
                .ExecuteNonQuery()

                oInicioCaja.InicioCajaID = .Parameters("@InicioCajaID").Value

            End With

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

    End Sub

    Public Sub Update(ByVal oInicioCaja As InicioCaja)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Function [Select](ByVal CodCaja As String, ByVal InicioDiaID As Integer) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim oResult As Integer = 0
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[InicioCajaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int, 4, "InicioDiaID"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2, "CodCaja"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@InicioDiaID").Value = InicioDiaID
                .Parameters("@CodCaja").Value = CodCaja

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    oResult = scdReader.GetInt32(0)

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

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

    End Function

#End Region

End Class
