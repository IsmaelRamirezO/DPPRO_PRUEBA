Option Explicit On 

Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext


Public Class RevisionApartadosDataGateWay

#Region "Constructors / Destructors"

    Private oParent As RevisionApartadosManager
    Dim strConn As String

    Public Sub New(ByVal Parent As RevisionApartadosManager)

        oParent = Parent
        strConn = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    End Sub

#End Region


    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdControlDPValesSel As SqlCommand
        sccmdControlDPValesSel = New SqlCommand

        With sccmdControlDPValesSel
            .CommandText = "[RevisionApartadosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly
        End With

        Dim scdaRetirosAdapter As SqlDataAdapter
        scdaRetirosAdapter = New SqlDataAdapter

        scdaRetirosAdapter.SelectCommand = sccmdControlDPValesSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaRetirosAdapter.Fill(oResult, "RevisionApartados")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdControlDPValesSel.Dispose()
        sccmdControlDPValesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function Insert(ByVal oRevisionApartados As RevisionApartados) As Integer

        oRevisionApartados.Detalle.AcceptChanges()

        'Dim myTransaction As SqlClient.SqlTransaction
        Dim sccnnConnection As New SqlConnection(strConn)
        Dim Folio As Integer
        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand


        'Insertado Detalle

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[RevisionApartadosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnConnection
            .Parameters.Clear()

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Folio", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Faltantes", System.Data.SqlDbType.TinyInt, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Vencidos", System.Data.SqlDbType.TinyInt, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NoRegistrados", System.Data.SqlDbType.TinyInt, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observaciones", System.Data.SqlDbType.VarChar, 50))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Sucursal", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Administrativo", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Responsable", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioMovimiento", System.Data.SqlDbType.TinyInt, 1))
            .Parameters("@FolioMovimiento").Direction = ParameterDirection.Output

        End With

        Try

            sccnnConnection.Open()
            'myTransaction = sccnnConnection.BeginTransaction()
            'sccmdInsert.Transaction = myTransaction
            With sccmdInsert
                'Assign Parameters Values

                For Each row As DataRow In oRevisionApartados.Detalle.Tables(0).Rows

                    If (CInt(row("Faltantes")) > 0) Or (CInt(row("Vencidos")) > 0) Or (CInt(row("NoRegistrados")) > 0) Then

                        .Parameters("@Folio").Value = Folio
                        .Parameters("@CodArticulo").Value = row("CodArticulo")
                        .Parameters("@Faltantes").Value = row("Faltantes")
                        .Parameters("@Vencidos").Value = row("Vencidos")
                        .Parameters("@NoRegistrados").Value = row("NoRegistrados")
                        .Parameters("@Observaciones").Value = row("Observaciones")
                        .Parameters("@Sucursal").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
                        .Parameters("@Administrativo").Value = oRevisionApartados.Administrativo
                        .Parameters("@Responsable").Value = oRevisionApartados.Responsable
                        .Parameters("@Fecha").Value = Now.Date
                        .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                        .Parameters("@StatusRegistro").Value = True
                        .Parameters("@FolioMovimiento").Value = Folio

                        'Execute Command
                        .ExecuteNonQuery()
                        Folio = .Parameters("@FolioMovimiento").Value


                    End If


                Next


                'Assign Other Values

                'myTransaction.Commit()

            End With



            sccnnConnection.Close()

            Return Folio


        Catch oSqlException As SqlException

            'myTransaction.Rollback()

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser insertado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            'myTransaction.Rollback()

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


    End Function

    Public Function [SelectByID](ByVal Folio As Integer) As RevisionApartados

        Dim oResult As RevisionApartados

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdControlDPValesSel As SqlCommand
        sccmdControlDPValesSel = New SqlCommand

        With sccmdControlDPValesSel
            .CommandText = "[RevisionApartadosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioMovimiento", System.Data.SqlDbType.TinyInt, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))

            .Parameters("@FolioMovimiento").Value = Folio
            .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        End With

        Dim scdaRetirosAdapter As SqlDataAdapter
        scdaRetirosAdapter = New SqlDataAdapter

        scdaRetirosAdapter.SelectCommand = sccmdControlDPValesSel


        Try

            sccnnDPTienda.Open()

            oResult = New RevisionApartados

            scdaRetirosAdapter.Fill(oResult.Detalle, "RevisionApartados")

            If oResult.Detalle.Tables(0).Rows.Count > 0 Then

                oResult.SetFlagDirty()
                oResult.Administrativo = oResult.Detalle.Tables(0).Rows(0)("Administrativo")
                oResult.Sucursal = oResult.Detalle.Tables(0).Rows(0)("Sucursal")
                oResult.Responsable = oResult.Detalle.Tables(0).Rows(0)("Responsable")
                oResult.Folio = oResult.Detalle.Tables(0).Rows(0)("FolioMovimiento")

            Else

                oResult.ResetFlagDirty()

            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdControlDPValesSel.Dispose()
        sccmdControlDPValesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function [SelectFolio]() As Integer

        Dim oResult As Integer

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdControlDPValesSel As SqlCommand
        sccmdControlDPValesSel = New SqlCommand

        With sccmdControlDPValesSel
            .CommandText = "[RevisionApartadosSelFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioMovimiento", System.Data.SqlDbType.TinyInt, 1))
            .Parameters("@Foliomovimiento").Direction = ParameterDirection.Output

            .Parameters("@FolioMovimiento").Value = 0

        End With


        Try

            sccnnDPTienda.Open()
            sccmdControlDPValesSel.ExecuteNonQuery()
            oResult = sccmdControlDPValesSel.Parameters("@FolioMovimiento").Value


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdControlDPValesSel.Dispose()
        sccmdControlDPValesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

End Class
