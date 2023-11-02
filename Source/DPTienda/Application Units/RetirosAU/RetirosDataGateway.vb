Option Explicit On 

Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core
Imports System.Windows.Forms
Imports DportenisPro.DPTienda.Core.ApplicationContext


Public Class RetirosDataGateway

    Private oParent As RetirosManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As RetirosManager)

        oParent = Parent

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pRetiros As Retiros)


        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosIns As SqlCommand
        sccmdRetirosIns = New SqlCommand

        With sccmdRetirosIns

            .CommandText = "[RetirosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ficha", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadRetiro", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, "Fecha"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@RetiroID").Value = pRetiros.RetiroID
            .Parameters("@CodAlmacen").Value = pRetiros.CodAlmacen
            .Parameters("@CodCaja").Value = pRetiros.CodCaja
            .Parameters("@CodBanco").Value = pRetiros.CodBanco
            .Parameters("@Ficha").Value = pRetiros.Ficha
            .Parameters("@Referencia").Value = pRetiros.Referencia
            .Parameters("@CantidadRetiro").Value = pRetiros.CantidadRetiro
            .Parameters("@Usuario").Value = pRetiros.RecordCreatedBy
            .Parameters("@Fecha").Value = pRetiros.RecordCreatedOn
            .Parameters("@StatusRegistro").Value = pRetiros.RecordEnabled

        End With

        Try
            sccnnDPTienda.Open()

            sccmdRetirosIns.ExecuteNonQuery()

            pRetiros.ResetFlagNew()
            pRetiros.ResetFlagDirty()

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

        sccmdRetirosIns.Dispose()
        sccmdRetirosIns = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Update(ByVal pRetiros As Retiros)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosUpd As SqlCommand
        sccmdRetirosUpd = New SqlCommand

        With sccmdRetirosUpd
            .CommandText = "[RetirosUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ficha", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 40))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadRetiro", System.Data.SqlDbType.Money, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@RetiroID").Value = pRetiros.RetiroID
            .Parameters("@CodAlmacen").Value = pRetiros.CodAlmacen
            .Parameters("@CodCaja").Value = pRetiros.CodCaja
            .Parameters("@CodBanco").Value = pRetiros.CodBanco
            .Parameters("@Ficha").Value = pRetiros.Ficha
            .Parameters("@Referencia").Value = pRetiros.Referencia
            .Parameters("@CantidadRetiro").Value = pRetiros.CantidadRetiro
            .Parameters("@Usuario").Value = pRetiros.RecordCreatedBy
            .Parameters("@Fecha").Value = pRetiros.RecordCreatedOn
            .Parameters("@StatusRegistro").Value = pRetiros.RecordEnabled
        End With

        Try
            sccnnDPTienda.Open()

            sccmdRetirosUpd.ExecuteNonQuery()

            pRetiros.ResetFlagNew()
            pRetiros.ResetFlagDirty()

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

        sccmdRetirosUpd.Dispose()
        sccmdRetirosUpd = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosDel As SqlCommand
        sccmdRetirosDel = New SqlCommand

        With sccmdRetirosDel

            .CommandText = "[RetirosDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
            .Parameters("@RetiroID").Value = ID

        End With

        Try
            sccnnDPTienda.Open()

            sccmdRetirosDel.ExecuteNonQuery()

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

        sccmdRetirosDel.Dispose()
        sccmdRetirosDel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Function [Select](ByVal ID As Integer, Optional ByVal Retiros As Retiros = Nothing) As Retiros

        Dim oResult As Retiros

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosSel As SqlCommand
        sccmdRetirosSel = New SqlCommand

        With sccmdRetirosSel
            .CommandText = "[RetirosSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters("@RetiroID").Value = ID
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdRetirosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                If (Retiros Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = Retiros
                End If

                With scsdrReader

                    oResult.RetiroID = .GetInt32(0)                          'Retiro,
                    oResult.CodAlmacen = .GetString(1)                 'CodAlmacen,
                    oResult.CodCaja = .GetString(2)                     'CodCaja,
                    oResult.CodBanco = .GetString(3)                   'CodBanco,
                    oResult.Ficha = .GetInt32(4)                        'Ficha,
                    oResult.Referencia = .GetString(5)                   'Referencia,
                    oResult.CantidadRetiro = .GetDecimal(6)             'CantidadRetiro,
                    oResult.RecordCreatedBy = .GetString(7)            'Usuario,
                    oResult.RecordCreatedOn = .GetDateTime(8)                 'Fecha,
                    oResult.RecordEnabled = .GetBoolean(9)             'Status,


                End With

                scsdrReader.Close()

                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()

            Else
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdRetirosSel.Dispose()
        sccmdRetirosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

    'Public Function [Select](ByVal Fecha As DateTime) As DataSet

    '    Dim oResult As DataSet

    '    Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

    '    Dim sccmdRetirosSel As SqlCommand
    '    sccmdRetirosSel = New SqlCommand

    '    With sccmdRetirosSel
    '        .CommandText = "[RetirosSelByDate]"
    '        .CommandType = System.Data.CommandType.StoredProcedure
    '        .Connection = sccnnDPTienda
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EFEC", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "EFEC", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T1", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T2", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T2", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T3", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T3", System.Data.DataRowVersion.Current, Nothing))


    '        .Parameters("@Fecha").Value = Format(Fecha, "Short Date")
    '    End With

    '    Dim scdaRetirosAdapter As SqlDataAdapter
    '    scdaRetirosAdapter = New SqlDataAdapter

    '    scdaRetirosAdapter.SelectCommand = sccmdRetirosSel


    '    Try

    '        sccnnDPTienda.Open()

    '        oResult = New DataSet

    '        scdaRetirosAdapter.Fill(oResult, "Retiros")

    '    Catch ex As Exception

    '        Throw ex

    '    Finally

    '        If (sccnnDPTienda.State <> ConnectionState.Closed) Then
    '            Try
    '                sccnnDPTienda.Close()
    '            Catch
    '            End Try
    '        End If

    '    End Try

    '    sccmdRetirosSel.Dispose()
    '    sccmdRetirosSel = Nothing

    '    sccnnDPTienda.Dispose()
    '    sccnnDPTienda = Nothing

    '    Return oResult


    'End Function

    Public Function [Select](ByVal Fecha As DateTime) As String()
        Dim strTotales(3) As String
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection
            .CommandText = "[RetirosSelByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@EFEC", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "EFEC", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T1", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T2", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T2", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@T3", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "T3", System.Data.DataRowVersion.Current, Nothing))



        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert
                'Assign Parameters Values
                .Parameters("@Fecha").Value = Format(Fecha, "Short Date")

                'Execute Command
                .ExecuteNonQuery()

                'Assign Other Values

                strTotales(0) = IIf(IsDBNull(.Parameters("@EFEC").Value), "$0.0", .Parameters("@EFEC").Value)
                strTotales(1) = IIf(IsDBNull(.Parameters("@T1").Value), "$0.0", .Parameters("@T1").Value)
                strTotales(2) = IIf(IsDBNull(.Parameters("@T2").Value), "$0.0", .Parameters("@T2").Value)
                strTotales(3) = IIf(IsDBNull(.Parameters("@T3").Value), "$0.0", .Parameters("@T3").Value)

            End With

            Return strTotales

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

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosSel As SqlCommand
        sccmdRetirosSel = New SqlCommand

        With sccmdRetirosSel
            .CommandText = "[RetirosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))

            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly
            .Parameters("@CodCaja").Value = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        End With

        Dim scdaRetirosAdapter As SqlDataAdapter
        scdaRetirosAdapter = New SqlDataAdapter

        scdaRetirosAdapter.SelectCommand = sccmdRetirosSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaRetirosAdapter.Fill(oResult, "Retiros")

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

        sccmdRetirosSel.Dispose()
        sccmdRetirosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Friend Function [SelectBancos](ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[CatalogoBancosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly

        End With

        Dim oBancosAdapter As SqlDataAdapter
        oBancosAdapter = New SqlDataAdapter
        oBancosAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oBancosAdapter.Fill(oResult, "CatalogoBancos")

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


    Public Function [SelectFolio]() As Integer

        Dim oResult As Integer

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdRetirosSel As SqlCommand
        sccmdRetirosSel = New SqlCommand

        With sccmdRetirosSel
            .CommandText = "[RetirosSelFolio]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdRetirosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then


                With scsdrReader

                    oResult = .GetInt32(0)

                End With

                scsdrReader.Close()

            Else
                MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdRetirosSel.Dispose()
        sccmdRetirosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

#End Region


End Class
