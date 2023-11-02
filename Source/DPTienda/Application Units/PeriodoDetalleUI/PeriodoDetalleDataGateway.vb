Option Explicit On 

Imports System.Data.SqlClient
'Imports DPSoft.Core
Imports System.Windows.Forms
'Imports DPSoft.Core.ApplicationContext

Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext

Public Class PeriodoDetalleDataGateway


    Private oParent As PeriodoDetalleManager

    Dim strConn As String = ("workstation id=PCOBX;packet size=4096;user id=sa;data source=OPERACIONES;persist security info=True;initial catalog=CreditoDP;password=sa")

    'Private wsPeriodoDetalle As New wsPeriodoDetalle.PeriodoDetalleWS
    'Private wsPeriodoDetalleInfo As New wsPeriodoDetalle.PeriodoDetalleInfo

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As PeriodoDetalleManager)

        oParent = Parent

        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'wsPeriodoDetalle.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'wsPeriodoDetalle.strURL.TrimStart("/")
        End If

    End Sub

#End Region



#Region "Methods"

    Public Sub Insert(ByVal pPeriodos As PeriodoDetalle)


        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdPeriodosIns As SqlCommand
        sccmdPeriodosIns = New SqlCommand

        With sccmdPeriodosIns

            .CommandText = "[PeriodoDetalleIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaPago", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@ID").Value = pPeriodos.PeriodoDetalleID
            .Parameters("@Anno").Value = pPeriodos.Anno
            .Parameters("@PeriodoID").Value = pPeriodos.PeriodoID
            .Parameters("@NumPeriodo").Value = pPeriodos.NumPeriodo
            .Parameters("@FechaInicial").Value = pPeriodos.FechaInicial
            .Parameters("@FechaFinal").Value = pPeriodos.FechaFinal
            .Parameters("@FechaPago").Value = pPeriodos.FechaPago
            .Parameters("@Usuario").Value = pPeriodos.Usuario
            .Parameters("@Fecha").Value = pPeriodos.Fecha
            .Parameters("@StatusRegistro").Value = pPeriodos.StatusRegistro


        End With

        Try
            sccnnDPTienda.Open()

            sccmdPeriodosIns.ExecuteNonQuery()

            'MsgBox(sccmdControlDPValesIns.Parameters("@ID").Value.ToString)

            pPeriodos.PeriodoID = sccmdPeriodosIns.Parameters("@ID").Value

            pPeriodos.ResetFlagNew()
            pPeriodos.ResetFlagDirty()

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

        sccmdPeriodosIns.Dispose()
        sccmdPeriodosIns = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Update(ByVal pPeriodos As PeriodoDetalle)

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdPeriodosUpd As SqlCommand
        sccmdPeriodosUpd = New SqlCommand

        With sccmdPeriodosUpd
            .CommandText = "[PeriodoDetalleUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaPago", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@PeriodoDetalleID").Value = pPeriodos.PeriodoDetalleID
            .Parameters("@Anno").Value = pPeriodos.Anno
            .Parameters("@PeriodoID").Value = pPeriodos.PeriodoID
            .Parameters("@NumPeriodo").Value = pPeriodos.NumPeriodo
            .Parameters("@FechaInicial").Value = pPeriodos.FechaInicial
            .Parameters("@FechaFinal").Value = pPeriodos.FechaFinal
            .Parameters("@FechaPago").Value = pPeriodos.FechaPago
            .Parameters("@Usuario").Value = pPeriodos.Usuario
            .Parameters("@Fecha").Value = pPeriodos.Fecha
            .Parameters("@StatusRegistro").Value = pPeriodos.StatusRegistro


        End With

        Try
            sccnnDPTienda.Open()

            sccmdPeriodosUpd.ExecuteNonQuery()

            pPeriodos.ResetFlagNew()
            pPeriodos.ResetFlagDirty()

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

        sccmdPeriodosUpd.Dispose()
        sccmdPeriodosUpd = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdPeriodosDel As SqlCommand
        sccmdPeriodosDel = New SqlCommand

        With sccmdPeriodosDel

            .CommandText = "[PeriodoDetalleDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
            .Parameters("@PeriodoDetalleID").Value = ID

        End With

        Try
            sccnnDPTienda.Open()

            sccmdPeriodosDel.ExecuteNonQuery()

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

        sccmdPeriodosDel.Dispose()
        sccmdPeriodosDel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Liquidar(ByVal ID As Integer, ByVal Liquidado As Boolean, ByVal PagoMin As Decimal, ByVal AsociadoID As Integer)

        Try

            'wsPeriodoDetalle.Liquidar(ID, Liquidado, PagoMin, AsociadoID)

        Catch ex As Exception

        End Try


        'Dim sccnnDPTienda As New SqlConnection(strConn)

        'Dim sccmdPeriodosDel As SqlCommand
        'sccmdPeriodosDel = New SqlCommand

        'With sccmdPeriodosDel

        '    .CommandText = "[SaldoPeriodoDPLiquidar]"
        '    .CommandType = System.Data.CommandType.StoredProcedure
        '    .Connection = sccnnDPTienda

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Liquidado", System.Data.SqlDbType.Bit, 1))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Pago", System.Data.SqlDbType.Decimal))
        '    .Parameters("@PeriodoID").Value = ID
        '    .Parameters("@Liquidado").Value = Liquidado
        '    .Parameters("@Pago").Value = PagoMin

        'End With

        'Try
        '    sccnnDPTienda.Open()

        '    sccmdPeriodosDel.ExecuteNonQuery()

        'Catch ex As Exception

        '    Throw ex

        'Finally

        '    If (sccnnDPTienda.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnDPTienda.Close()
        '        Catch
        '        End Try
        '    End If

        'End Try

        'sccmdPeriodosDel.Dispose()
        'sccmdPeriodosDel = Nothing

        'sccnnDPTienda.Dispose()
        'sccnnDPTienda = Nothing

    End Sub


    Public Function [Select](ByVal ID As Integer, Optional ByVal Periodos As PeriodoDetalle = Nothing) As PeriodoDetalle

        Dim oResult As PeriodoDetalle

        Dim sccnnDPTienda As New SqlConnection(strConn)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdPeriodosSel As SqlCommand
        sccmdPeriodosSel = New SqlCommand

        With sccmdPeriodosSel
            .CommandText = "[PeriodoDetalleSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
            .Parameters("@PeriodoDetalleID").Value = ID
        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdPeriodosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                If (Periodos Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = Periodos
                End If

                With scsdrReader

                    oResult.PeriodoDetalleID = .GetInt32(0)
                    oResult.PeriodoID = .GetInt32(1)
                    oResult.Anno = .GetInt32(2)
                    oResult.NumPeriodo = .GetInt32(3)
                    oResult.FechaInicial = .GetDateTime(4)
                    oResult.FechaFinal = .GetDateTime(5)
                    oResult.FechaPago = .GetDateTime(6)
                    oResult.Usuario = .GetString(7)
                    oResult.Fecha = .GetDateTime(8)
                    oResult.StatusRegistro = .GetBoolean(9)


                End With

                scsdrReader.Close()

                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()

            Else
                MessageBox.Show("Código no existe", "DPCredito", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        sccmdPeriodosSel.Dispose()
        sccmdPeriodosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function


    Public Function SelectByNumPeriodo(ByVal NumPeriodo As Integer, ByVal AsociadoID As String) As PeriodoDetalle

        Try
            Dim oResult As PeriodoDetalle

            'wsPeriodoDetalleInfo = wsPeriodoDetalle.SelectByNumPeriodo(NumPeriodo, AsociadoID)


            'If Not wsPeriodoDetalleInfo Is Nothing Then
            '    oResult = oParent.Create
            '    oResult.PeriodoDetalleID = wsPeriodoDetalleInfo.PeriodoDetalleID
            '    oResult.PeriodoID = wsPeriodoDetalleInfo.PeriodoID
            '    oResult.Anno = wsPeriodoDetalleInfo.Anno
            '    oResult.NumPeriodo = wsPeriodoDetalleInfo.NumPeriodo
            '    oResult.FechaInicial = wsPeriodoDetalleInfo.FechaInicial
            '    oResult.FechaFinal = wsPeriodoDetalleInfo.FechaFinal
            '    oResult.FechaPago = wsPeriodoDetalleInfo.FechaPago
            '    oResult.Usuario = wsPeriodoDetalleInfo.Usuario
            '    oResult.Fecha = wsPeriodoDetalleInfo.Fecha
            '    oResult.StatusRegistro = wsPeriodoDetalleInfo.StatusRegistro
            '    oResult.Liquidado = wsPeriodoDetalleInfo.Liquidado
            '    oResult.PagoMinimo = wsPeriodoDetalleInfo.PagoMinimo
            'End If
            Return oResult

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        'Dim sccnnDPTienda As New SqlConnection(strConn)

        ''(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        'Dim sccmdPeriodosSel As SqlCommand
        'sccmdPeriodosSel = New SqlCommand

        'With sccmdPeriodosSel
        '    .CommandText = "[PeriodoDetalleSelByNumPeriodo]"
        '    .CommandType = System.Data.CommandType.StoredProcedure
        '    .Connection = sccnnDPTienda

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodo", System.Data.SqlDbType.Int, 4))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@AsociadoID", System.Data.SqlDbType.Int, 4))
        '    .Parameters("@AsociadoID").Value = AsociadoID
        '    .Parameters("@NumPeriodo").Value = NumPeriodo

        'End With

        'Try

        '    sccnnDPTienda.Open()

        '    Dim scsdrReader As SqlDataReader

        '    scsdrReader = sccmdPeriodosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

        '    scsdrReader.Read()

        '    If (scsdrReader.HasRows) Then

        '        With scsdrReader

        '            oResult = oParent.Create

        '            oResult.PeriodoDetalleID = .GetInt32(.GetOrdinal("PeriodoDetalleID"))
        '            oResult.PeriodoID = .GetInt32(.GetOrdinal("PeriodoID"))
        '            oResult.Anno = .GetInt32(.GetOrdinal("Anno"))
        '            oResult.NumPeriodo = .GetInt32(.GetOrdinal("NumPeriodo"))
        '            oResult.FechaInicial = .GetDateTime(.GetOrdinal("FechaInicial"))
        '            oResult.FechaFinal = .GetDateTime(.GetOrdinal("FechaFinal"))
        '            oResult.FechaPago = .GetDateTime(.GetOrdinal("FechaPago"))
        '            oResult.Usuario = .GetString(.GetOrdinal("Usuario"))
        '            oResult.Fecha = .GetDateTime(.GetOrdinal("Fecha"))
        '            oResult.StatusRegistro = .GetBoolean(.GetOrdinal("StatusRegistro"))
        '            oResult.Liquidado = .GetBoolean(.GetOrdinal("Liquidado"))
        '            oResult.PagoMinimo = .GetDecimal(.GetOrdinal("PagoMinimo"))


        '        End With

        '        scsdrReader.Close()

        '        oResult.ResetFlagNew()
        '        oResult.ResetFlagDirty()

        '    Else
        '        MessageBox.Show("La referencia del corte no existe", "DPCredito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If


        'Catch ex As Exception

        '    MessageBox.Show(ex.ToString)

        'Finally

        '    If (sccnnDPTienda.State <> ConnectionState.Closed) Then
        '        Try
        '            sccnnDPTienda.Close()
        '        Catch
        '        End Try
        '    End If

        'End Try

        'sccmdPeriodosSel.Dispose()
        'sccmdPeriodosSel = Nothing

        'sccnnDPTienda.Dispose()
        'sccnnDPTienda = Nothing

        'Return oResult

    End Function


    'Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

    '    Dim oResult As DataSet

    '    Dim sccnnDPTienda As New SqlConnection(strConn)

    '    Dim sccmdControlDPValesSel As SqlCommand
    '    sccmdControlDPValesSel = New SqlCommand

    '    With sccmdControlDPValesSel
    '        .CommandText = "[ControlDPValesSelAll]"
    '        .CommandType = System.Data.CommandType.StoredProcedure
    '        .Connection = sccnnDPTienda
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
    '        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

    '        .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly
    '    End With

    '    Dim scdaRetirosAdapter As SqlDataAdapter
    '    scdaRetirosAdapter = New SqlDataAdapter

    '    scdaRetirosAdapter.SelectCommand = sccmdControlDPValesSel


    '    Try

    '        sccnnDPTienda.Open()

    '        oResult = New DataSet

    '        scdaRetirosAdapter.Fill(oResult, "DPVale")

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

    '    sccmdControlDPValesSel.Dispose()
    '    sccmdControlDPValesSel = Nothing

    '    sccnnDPTienda.Dispose()
    '    sccnnDPTienda = Nothing

    '    Return oResult


    'End Function

    Public Function SelectPeriodoActual(ByVal Fecha) As Integer

        Try
            Dim oResult As Integer

            'oResult = wsPeriodoDetalle.SelectPeriodoActual(Fecha)

            Return oResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

End Class
