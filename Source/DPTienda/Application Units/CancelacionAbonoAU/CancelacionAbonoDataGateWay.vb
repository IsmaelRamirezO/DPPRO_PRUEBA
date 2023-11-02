
Option Explicit On 

Imports System.Data.SqlClient


Public Class CancelacionAbonoDataGateWay

    Private oParent As CancelacionAbonoManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CancelacionAbonoManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"


    Public Sub Delete(ByVal ID As Integer, ByVal ApartadoID As Integer)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdDelete As SqlCommand
        sccmdDelete = New SqlCommand

        With sccmdDelete

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodBanco", System.Data.DataRowVersion.Original, Nothing))

            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int, 4))


        End With

        Try

            sccnnConnection.Open()

            With sccmdDelete
                'Assign Parameters Values
                .Parameters("@AbonoApartadoID").Value = ID
                .Parameters("@ApartadoID").Value = ApartadoID

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

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            'Throw New ApplicationException("El registro no pudo ser insertado debido a un error de aplicación.", ex)

        End Try


        sccmdDelete.Dispose()
        sccmdDelete = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


    Public Sub ActualizaDOCNUMFB01(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[AbonosApartadosFB01Upd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AbonoApartadoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DocNumFB01", System.Data.SqlDbType.VarChar, 10))


        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@AbonoApartadoID").Value = ApartadoID
                .Parameters("@DocNumFB01").Value = DOCNUMFB01

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

            Throw New ApplicationException(oSqlException.Message, oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException(ex.Message, ex)

        End Try


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub


#End Region

End Class
