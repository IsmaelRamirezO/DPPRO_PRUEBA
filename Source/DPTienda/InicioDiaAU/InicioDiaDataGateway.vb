Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU


Friend Class InicioDiaDataGateway

    Private oParent As InicioDiaManager
    Private m_strConnectionString As String
    Dim oProSAPMgr As ProcesoSAPManager



    Public Sub New(ByVal Parent As InicioDiaManager)

        oParent = Parent

        m_strConnectionString = oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString


    End Sub


#Region "Methods"

    Public Sub Insert(ByVal oInicioDia As InicioDia)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[InicioDiaIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@InicioDiaID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "InicioDiaID", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicioDia", System.Data.SqlDbType.DateTime, 8, "FechaInicioDia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Retiros", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Retiros", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tot_Dia", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Tot_Dia", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiferenciaEnCaja", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "DiferenciaEnCaja", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@InicioDiaID").Value = oInicioDia.InicioDiaID
                .Parameters("@CodAlmacen").Value = oInicioDia.CodAlmacen
                .Parameters("@FechaInicioDia").Value = oInicioDia.FechaInicioDia
                .Parameters("@Retiros").Value() = oInicioDia.Retiros
                .Parameters("@Tot_Dia").Value = oInicioDia.Tot_Dia
                .Parameters("@DiferenciaEnCaja").Value = oInicioDia.DiferenciaEnCaja
                .Parameters("@Usuario").Value = oParent.ApplicationContext.Security.CurrentUser.Name
                .Parameters("@Fecha").Value = oInicioDia.Fecha
                .Parameters("@StatusRegistro").Value = oInicioDia.StatusRegistro

                'Execute Command
                .ExecuteNonQuery()

                oInicioDia.InicioDiaID = .Parameters("@InicioDiaID").Value

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

    Public Sub SetCargasIniciales()

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[CargasInicialesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))
            

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@CodAlmacen").Value = oParent.ApplicationContext.ApplicationConfiguration.Almacen

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

            MsgBox("El registro no pudo ser insertado debido a un error de base de datos.", MsgBoxStyle.Information, "DPTIENDA")

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            MsgBox("El registro no pudo ser insertado debido a un error de aplicación.", MsgBoxStyle.Information, "DPTIENDA")

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Sub Update(ByVal oInicioDia As InicioDia)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Function [Select](ByVal FechaInicioDia As Date, ByVal CodAlmacen As String) As Integer

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim oResult As Integer = 0
        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[InicioDiaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicioDia", System.Data.SqlDbType.DateTime, 8, "FechaInicioDia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FechaInicioDia").Value = FechaInicioDia
                .Parameters("@CodAlmacen").Value = CodAlmacen

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

    Public Function ValidaCierreDia(ByVal CodAlmacen As String) As InicioDia

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim oResult As InicioDia
        oResult = oParent.Create

        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ValidaCierreDia]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, "CodAlmacen"))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values

                .Parameters("@CodAlmacen").Value = CodAlmacen

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    oResult.InicioDiaID = scdReader.GetInt32(scdReader.GetOrdinal("InicioDiaID"))
                    oResult.CodAlmacen = scdReader.GetString(scdReader.GetOrdinal("CodAlmacen"))
                    oResult.FechaInicioDia = scdReader.GetDateTime(scdReader.GetOrdinal("FechaInicioDia"))

                    Return oResult

                Else

                    oResult = Nothing

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

    Public Function SelectDateBeginDay() As Date

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim oResult As Date

        Dim scdReader As SqlDataReader
        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[InicioDiaFechaSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicioDia", System.Data.SqlDbType.DateTime, 8, ParameterDirection.Output))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                'Assign Parameters Values
                .Parameters("@FechaInicioDia").Value = Date.Now

                'Execute Reader
                scdReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)
                scdReader.Read()

                If scdReader.HasRows Then

                    If scdReader.IsDBNull(0) = True Then

                        oResult = Date.Now

                    Else

                        oResult = DateAdd(DateInterval.Day, 1, scdReader.GetDateTime(0))

                    End If

                Else

                    oResult = Date.Now

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

    Public Function ObetenerPreciosyDescuentos(ByVal group As Boolean, ByVal IntdescIni As Integer, ByVal IntDescFin As Integer, Optional ByVal bolaccText As Boolean = False) As DataSet
        Dim ds As DataSet
        Dim oRow As DataRow
        oProSAPMgr = New ProcesoSAPManager(oParent.ApplicationContext, oParent.SAPApplicationConfig)
        ds = oProSAPMgr.SeleccionaArticulos(group, bolaccText)

        'Para Poder Agruparlos 
        Dim PorcGroup As New DataColumn
        With PorcGroup
            .ColumnName = "PorcGroup"
            .Caption = "Grupo Porcentaje"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With
        ds.Tables(0).Columns.Add(PorcGroup)
        ds.Tables(0).AcceptChanges()

        For Each oRow In ds.Tables(0).Rows

            Dim oCondicionVenta As New CondicionesVtaSAP
            oCondicionVenta.Jerarquia = oRow!Jerarquia
            oCondicionVenta.CondMat = oRow!CodMarca
            oCondicionVenta.Material = oRow!CodArticulo

            If Not oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                oCondicionVenta.OficinaVtas = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                oCondicionVenta.ListPrec = "Z1"
                oCondicionVenta.CondPrec = "01"
            Else
                GoTo Cambio_053
                'oCondicionVenta.OficinaVtas = "C053"
                'oCondicionVenta.ListPrec = "C1"
                'oCondicionVenta.CondPrec = "01"
            End If

            oProSAPMgr.GetCondicionVenta(oCondicionVenta)

            Dim dblDesc As Decimal = 0
            Dim dblPrecIva As Decimal = 0

            If (oCondicionVenta.DescPorcentaje >= IntdescIni) And (oCondicionVenta.DescPorcentaje <= IntDescFin) Then
                'Porcentaje
                dblPrecIva = (oRow!PrecioIva)
                dblDesc = dblPrecIva * (oCondicionVenta.DescPorcentaje / 100)
                oRow!PrecioDescuento = dblPrecIva - dblDesc
                oRow!Descuento = Math.Round(oCondicionVenta.DescPorcentaje, 2)
                oRow!PorcGroup = DescRangos(oRow!Descuento)
            Else
                If oCondicionVenta.Descmonto > 0 Then
                    'Monto descuento
                    oRow!PrecioDescuento = oRow!PrecioIva - oCondicionVenta.Descmonto
                    oRow!Descuento = Math.Round(oCondicionVenta.Descmonto, 2)
                    oRow!PorcGroup = "Monto" 'Cuando no sea Procentaje
                Else
                    oRow.Delete()
                End If
            End If
        Next
        ds.AcceptChanges()
        Return ds

    End Function

    Private Function DescRangos(ByVal decDesc As Decimal) As String
        If decDesc >= 0 And decDesc < 10 Then
            Return "0%"
        Else
            If decDesc >= 10 And decDesc < 20 Then
                Return "10%"
            Else
                If decDesc >= 20 And decDesc < 30 Then
                    Return "20%"
                Else
                    If decDesc >= 30 And decDesc < 40 Then
                        Return "30%"
                    Else
                        If decDesc >= 40 And decDesc < 50 Then
                            Return "40%"
                        Else
                            If decDesc >= 50 Then
                                Return "50% o Mayores"
                            Else
                                Return "Otros"
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Public Sub InventarioInicial(ByVal oInicioDia As InicioDia)
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdInsert As SqlCommand
        sccmdInsert = New SqlCommand

        With sccmdInsert

            .Connection = sccnnConnection

            .CommandText = "[InventarioInicialIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8))

        End With

        Try

            sccnnConnection.Open()

            With sccmdInsert

                'Assign Parameters Values
                .Parameters("@Fecha").Value = oInicioDia.FechaInicioDia.ToShortDateString
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


    
#End Region

    Public Function SelectBitacora(ByVal Fecha As Date) As DataSet

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaEstados As SqlDataAdapter
        Dim dsBitacoraPRO As DataSet

        sccmdSelectAll = New SqlCommand
        scdaEstados = New SqlDataAdapter
        dsBitacoraPRO = New DataSet("BitacoraDeMovimientos")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[BitacoraEntradasSalidasByDate]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime))

        End With

        scdaEstados.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaEstados.SelectCommand.Parameters("@Fecha").Value = Fecha.ToShortDateString

            'Fill DataSet
            scdaEstados.Fill(dsBitacoraPRO)

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

        Return dsBitacoraPRO

    End Function

    Public Function GetHistorialUserPasswords(ByVal UserID As Integer) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("HistorialPassword")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[UsersPasswordHistorialSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@UserID", SqlDbType.Int, 4))
        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@UserID").Value = UserID

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "Sistemas")

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

        Return dsDPVF.Tables(0)

    End Function

    Public Function ValidaPassword(ByRef Password As String, ByRef Msg As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim bRes As Boolean = False

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ValidaPassword]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.VarChar, 50, "Password"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@Password").Value = Password.Trim

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then

                    With scdrReader

                        bRes = .GetBoolean(.GetOrdinal("Result"))
                        Msg = .GetString(.GetOrdinal("Message"))

                    End With

                Else

                    bRes = False
                    Msg = "El password indicado no cumple con los requisitos mínimos indispensables para cumplir con las políticas de seguridad de Grupo DP"

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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bRes

    End Function

    Public Sub SaveNewPassword(ByVal Password As String, ByVal UserID As Integer)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[RenewPassword]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Password", System.Data.SqlDbType.VarChar, 255, "Password"))
            .Parameters.Add(New SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@Password").Value = Password.Trim
                .Parameters("@UserID").Value = UserID

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


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

    Public Function IsNeedNewPassword(ByRef UserID As Integer) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim bRes As Boolean = False

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ValidaRenuevaPassword]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect

                .Parameters("@UserID").Value = UserID

                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                scdrReader.Read()

                If scdrReader.HasRows Then
                    With scdrReader

                        bRes = .GetBoolean(.GetOrdinal("Result"))

                    End With
                Else
                    bRes = False
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

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return bRes

    End Function



    Public Function GetTablasInicialesRecord(ByVal Tabla As String) As DataTable

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaDPVF As SqlDataAdapter
        Dim dsDPVF As DataSet

        sccmdSelectAll = New SqlCommand
        scdaDPVF = New SqlDataAdapter
        dsDPVF = New DataSet("TablasIniciales")

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[TablasInicialesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Tabla", SqlDbType.VarChar, 50, "Tabla"))
        End With

        scdaDPVF.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            With scdaDPVF.SelectCommand

                .Parameters("@Tabla").Value = Tabla

            End With

            'Fill DataSet
            scdaDPVF.Fill(dsDPVF, "TablasIniciales")

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

        Return dsDPVF.Tables(0)

    End Function


    Public Sub InsertTabla(ByVal Tabla As String)

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdUpdate As SqlCommand
        sccmdUpdate = New SqlCommand

        With sccmdUpdate

            .Connection = sccnnConnection
            .CommandText = "[TablasInicialesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Tabla", System.Data.SqlDbType.VarChar, 50, "Tabla"))
        End With

        Try

            sccnnConnection.Open()

            With sccmdUpdate
                'Assign Parameters Values
                .Parameters("@Tabla").Value = Tabla

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


        sccmdUpdate.Dispose()
        sccmdUpdate = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub




End Class
