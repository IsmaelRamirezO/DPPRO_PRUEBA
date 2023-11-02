Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class FirmaDataGateway

    Private oParent As FirmaManager
    Private m_strConnectionString As String
    Private m_strConnectionStringDP As String 'Cadena para validar los descuentos permitidos


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As FirmaManager)

        oParent = Parent

        m_strConnectionString = "Data Source=" & oParent.FirmaConfig.ServerFirma & "; Initial Catalog=" & oParent.FirmaConfig.BaseDatosFirmas & "; User Id=" & oParent.FirmaConfig.UserFirma & " ;Password=" & oParent.FirmaConfig.PassFirma & ";TimeOut=120;"
        'm_strConnectionStringDP = "Data Source=" & oParent.FirmaConfig.ServerFirma & "; Initial Catalog=Separaciones; User Id= sa ;Password=01012006;TimeOut=120;"
        m_strConnectionStringDP = "Data Source=" & oParent.FirmaConfig.ServerSeparaciones & "; Initial Catalog=" & oParent.FirmaConfig.BDSeparaciones & "; User Id=" & oParent.FirmaConfig.UserSeparaciones & ";Password=" & oParent.FirmaConfig.PassSeparaciones & ";TimeOut=120;"

    End Sub

#End Region

    Public Function SelectImagenFirmaAsociado(ByVal strAsociado As String) As Byte()

        Dim sccnnConnection As New SqlConnection(m_strConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[ImagenFirmaAsociadoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAsociado", System.Data.SqlDbType.VarChar, 10))
            .Parameters("@CodAsociado").Value = strAsociado

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    With scdrReader

                        SelectImagenFirmaAsociado = .GetValue(0)
                        '2147483647
                    End With

                Else
                    SelectImagenFirmaAsociado = Nothing
                End If

            End With

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

        Return SelectImagenFirmaAsociado

    End Function

    Public Function SelectDescuentosPermitidos(ByVal strDescuento As String, ByVal Centro As String) As Boolean

        Dim sccnnConnection As New SqlConnection(m_strConnectionStringDP)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader
        Dim bolPermitido As Boolean

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = "[DescuentoPermitidoSel]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.VarChar, 5))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 5))
            .Parameters("@Descuento").Value = strDescuento
            .Parameters("@CodAlmacen").Value = Centro

        End With


        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    bolPermitido = True

                Else

                    bolPermitido = False

                End If

            End With

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

        Return bolPermitido

    End Function

#Region "Codigo Proveedor"
    Public Function GetItemsColor(ByVal item As String, ByVal talla As String) As DataTable
        Dim items As New DataTable
        Dim conexion As New SqlConnection(m_strConnectionString)
        Dim command As New SqlCommand("", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodArtProv", item)
            command.Parameters.AddWithValue("@Talla", talla)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(items)
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(sql.Message, sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return items
    End Function
#End Region

End Class
