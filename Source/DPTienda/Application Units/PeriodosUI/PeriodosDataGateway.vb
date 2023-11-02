Option Explicit On 

Imports System.Data.SqlClient
'Imports DPSoft.Core
Imports System.Windows.Forms
'Imports DPSoft.Core.ApplicationContext
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.Core.ApplicationContext


Public Class PeriodosDataGateway

    Private oParent As PeriodosManager

    Dim strConn As String = ("workstation id=PCOBX;packet size=4096;user id=sa;data source=OPERACIONES;persist security info=True;initial catalog=CreditoDP;password=sa")

    'Dim wsPeriodos As New wsPeriodos.PeriodosWS
    'Dim wsPeriodosInfo As New wsPeriodos.PeriodoInfo


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As PeriodosManager)

        oParent = Parent
        If Not oParent.ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then
            'wsPeriodos.Url = oParent.ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd("/") & "/" & _
            'wsPeriodos.strURL.TrimStart("/")
        End If

    End Sub

#End Region

#Region "Methods"

    Public Sub Insert(ByVal pPeriodos As Periodos)


        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdPeriodosIns As SqlCommand
        sccmdPeriodosIns = New SqlCommand

        With sccmdPeriodosIns

            .CommandText = "[PeriodoIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumDiasPeriodo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodos", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCorte1", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCorte2", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiaPago1", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiaPago2", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiasCorte", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD1", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD2", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD3", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD4", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD5", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@ID").Value = pPeriodos.PeriodoID
            .Parameters("@Anno").Value = pPeriodos.Anno
            .Parameters("@NumDiasPeriodo").Value = pPeriodos.NumDiasPeriodo
            .Parameters("@NumPeriodos").Value = pPeriodos.NumPeriodos
            .Parameters("@FechaCorte1").Value = pPeriodos.FechaCorte1
            .Parameters("@FechaCorte2").Value = pPeriodos.FechaCorte2
            .Parameters("@DiaPago1").Value = pPeriodos.DiaPago1
            .Parameters("@DiaPago2").Value = pPeriodos.DiaPago2
            .Parameters("@DiasCorte").Value = pPeriodos.DiasCorte
            .Parameters("@PorcLimPagoD1").Value = pPeriodos.PorcLimPagoD1
            .Parameters("@PorcLimPagoD2").Value = pPeriodos.PorcLimPagoD2
            .Parameters("@PorcLimPagoD3").Value = pPeriodos.PorcLimPagoD3
            .Parameters("@PorcLimPagoD4").Value = pPeriodos.PorcLimPagoD4
            .Parameters("@PorcLimPagoD5").Value = pPeriodos.PorcLimPagoD5
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

    Public Sub Update(ByVal pPeriodos As Periodos)

        Dim sccnnDPTienda As New SqlConnection(strConn)

        Dim sccmdPeriodosUpd As SqlCommand
        sccmdPeriodosUpd = New SqlCommand

        With sccmdPeriodosUpd
            .CommandText = "[PeriodosUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumDiasPeriodo", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodos", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCorte1", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaCorte2", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiaPago1", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiaPago2", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@DiasCorte", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD1", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD2", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD3", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD4", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PorcLimPagoD5", System.Data.SqlDbType.Int, 4))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

            .Parameters("@ID").Value = pPeriodos.PeriodoID
            .Parameters("@Anno").Value = pPeriodos.Anno
            .Parameters("@NumDiasPeriodo").Value = pPeriodos.NumDiasPeriodo
            .Parameters("@NumPeriodos").Value = pPeriodos.NumPeriodos
            .Parameters("@FechaCorte1").Value = pPeriodos.FechaCorte1
            .Parameters("@FechaCorte2").Value = pPeriodos.FechaCorte2
            .Parameters("@DiaPago1").Value = pPeriodos.DiaPago1
            .Parameters("@DiaPago2").Value = pPeriodos.DiaPago2
            .Parameters("@DiasCorte").Value = pPeriodos.DiasCorte
            .Parameters("@PorcLimPagoD1").Value = pPeriodos.PorcLimPagoD1
            .Parameters("@PorcLimPagoD2").Value = pPeriodos.PorcLimPagoD2
            .Parameters("@PorcLimPagoD3").Value = pPeriodos.PorcLimPagoD3
            .Parameters("@PorcLimPagoD4").Value = pPeriodos.PorcLimPagoD4
            .Parameters("@PorcLimPagoD5").Value = pPeriodos.PorcLimPagoD5
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

            .CommandText = "[PeriodoDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
            .Parameters("@PeriodoID").Value = ID

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


    
    Public Function [Select](ByVal ID As Integer, Optional ByVal Periodos As Periodos = Nothing) As Periodos

        Try

            Dim oResult As Periodos

            'wsPeriodosInfo = wsPeriodos.Load(ID)
            'If Not wsPeriodosInfo Is Nothing Then
            '    oResult = oParent.Create
            '    oResult.PeriodoID = wsPeriodosInfo.PeriodoID
            '    oResult.Anno = wsPeriodosInfo.Anno
            '    oResult.NumDiasPeriodo = wsPeriodosInfo.NumDiasPeriodo
            '    oResult.NumPeriodos = wsPeriodosInfo.NumPeriodos
            '    oResult.FechaCorte1 = wsPeriodosInfo.FechaCorte1
            '    oResult.FechaCorte2 = wsPeriodosInfo.FechaCorte2
            '    oResult.DiaPago1 = wsPeriodosInfo.DiaPago1
            '    oResult.DiaPago2 = wsPeriodosInfo.DiaPago2
            '    oResult.DiasCorte = wsPeriodosInfo.DiasCorte
            '    oResult.PorcLimPagoD1 = wsPeriodosInfo.PorcLimPagoD1
            '    oResult.PorcLimPagoD2 = wsPeriodosInfo.PorcLimPagoD2
            '    oResult.PorcLimPagoD3 = wsPeriodosInfo.PorcLimPagoD3
            '    oResult.PorcLimPagoD4 = wsPeriodosInfo.PorcLimPagoD4
            '    oResult.PorcLimPagoD5 = wsPeriodosInfo.PorcLimPagoD5
            '    oResult.Usuario = wsPeriodosInfo.Usuario
            '    oResult.Fecha = wsPeriodosInfo.Fecha
            '    oResult.StatusRegistro = wsPeriodosInfo.StatusRegistro
            'End If

            Return oResult

        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try
        


        'Dim sccnnDPTienda As New SqlConnection(strConn)

        ''(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        'Dim sccmdPeriodosSel As SqlCommand
        'sccmdPeriodosSel = New SqlCommand

        'With sccmdPeriodosSel
        '    .CommandText = "[PeriodosSel]"
        '    .CommandType = System.Data.CommandType.StoredProcedure
        '    .Connection = sccnnDPTienda

        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
        '    .Parameters("@PeriodoID").Value = ID
        'End With

        'Try

        '    sccnnDPTienda.Open()

        '    Dim scsdrReader As SqlDataReader

        '    scsdrReader = sccmdPeriodosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

        '    scsdrReader.Read()

        '    If (scsdrReader.HasRows) Then

        '        If (Periodos Is Nothing) Then
        '            oResult = oParent.Create
        '        Else
        '            oResult = Periodos
        '        End If

        '        With scsdrReader

        '            oResult.PeriodoID = .GetInt32(0)
        '            oResult.Anno = .GetInt32(1)
        '            oResult.NumDiasPeriodo = .GetInt32(2)
        '            oResult.NumPeriodos = .GetInt32(3)
        '            oResult.FechaCorte1 = .GetInt32(4)
        '            oResult.FechaCorte2 = .GetInt32(5)
        '            oResult.DiaPago1 = .GetDateTime(6)
        '            oResult.DiaPago2 = .GetDateTime(7)
        '            oResult.DiasCorte = .GetInt32(8)
        '            oResult.PorcLimPagoD1 = .GetInt32(9)
        '            oResult.PorcLimPagoD2 = .GetInt32(10)
        '            oResult.PorcLimPagoD3 = .GetInt32(11)
        '            oResult.PorcLimPagoD4 = .GetInt32(12)
        '            oResult.PorcLimPagoD5 = .GetInt32(13)
        '            oResult.Usuario = .GetString(14)
        '            oResult.Fecha = .GetDateTime(15)


        '        End With

        '        scsdrReader.Close()

        '        oResult.ResetFlagNew()
        '        oResult.ResetFlagDirty()

        '    Else
        '        MessageBox.Show("Código no existe", "DPCredito", MessageBoxButtons.OK, MessageBoxIcon.Information)
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




#End Region

End Class
