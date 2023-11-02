Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class SeparacionesDataGateWay

    Private oParent As SeparacionesManager
    Private m_strConnectionString As String


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As SeparacionesManager)

        oParent = Parent

        'm_strConnectionString = "Data Source=" & oParent.FirmaConfig.ServerFirma & "; Initial Catalog=separaciones; User Id=" & oParent.FirmaConfig.UserFirma & " ;Password=" & oParent.FirmaConfig.PassFirma & ";TimeOut=120;"
        With oParent.FirmaConfig
            m_strConnectionString = "Data Source=" & .ServerSeparaciones & "; Initial Catalog=" & .BDSeparaciones & "; User Id=" & .UserSeparaciones & " ;Password=" & .PassSeparaciones & ";TimeOut=120;"
        End With

    End Sub

#End Region

    Public Function SelectUPCNuevo(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal Todo As Boolean, ByVal CodArticulo As String) As DataSet

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[UPCSelNuevo]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaIni", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFin", System.Data.SqlDbType.VarChar, 10))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Todo", System.Data.SqlDbType.Bit, 1))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 20))
            .Parameters("@FechaIni").Value = datFechaIni.ToString("dd/MM/yyyy")
            .Parameters("@FechaFin").Value = datFechaFin.ToString("dd/MM/yyyy")
            .Parameters("@Todo").Value = Todo
            .Parameters("@Material").Value = CodArticulo

        End With

        Dim oCatalogoAdapter As SqlDataAdapter
        oCatalogoAdapter = New SqlDataAdapter
        oCatalogoAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoAdapter.Fill(oResult)

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

End Class
