
Imports System.Data.SqlClient


Public Class ImpresionEtiquetaDataGateway

    Private oParent As ImpresionEtiquetaManager


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ImpresionEtiquetaManager)

        oParent = Parent

    End Sub

#End Region



#Region "Properties"

    Public Property Parent() As ImpresionEtiquetaManager

        Get

            Return oParent

        End Get


        Set(ByVal Value As ImpresionEtiquetaManager)

            oParent = Value

        End Set

    End Property

#End Region



#Region "Methods"

    Public Function [Select](ByVal bolopc As Boolean, ByVal strCodArticulo As String, ByVal strCodMarca As String, ByVal strCodFamilia As String, _
                             ByVal strCodLinea As String, ByVal strCodTipoPrecio As String, ByVal strCodCategoria As String, ByVal strTalla As String, _
                             ByVal Tipo As Integer) As DataSet

        Dim sccnnConnection As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdaImpresion As SqlDataAdapter
        Dim dsImpresion As DataSet

        sccmdSelect = New SqlCommand
        scdaImpresion = New SqlDataAdapter
        dsImpresion = New DataSet("CatalogoArticulos")

        With sccmdSelect

            .Connection = sccnnConnection

            If bolopc Then

                If strCodArticulo <> String.Empty Then

                    'Tienda 53 especifica
                    .CommandText = "[ImpresionEtiquetaTienda53]"
                Else
                    'Tienda 53 Varias
                    .CommandText = "[ImpresionEtiquetaZebraAll]"

                End If
            Else
                If (strCodArticulo <> String.Empty) Then

                    'Opción Específico :

                    .CommandText = "[ImpresionEtiquetaEspecifico]"

                Else

                    'Opción Precio Normal y Precio Oferta :

                    .CommandText = "[ImpresionEtiquetaPrecioNormalPrecioOferta]"

                End If

            End If


            .CommandType = System.Data.CommandType.StoredProcedure
            If bolopc And strCodArticulo <> String.Empty Then 'Tienda 53 especifica
                .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
            Else
                If (strCodArticulo <> String.Empty) Then
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodArticulo", System.Data.SqlDbType.VarChar, 20))
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Talla", System.Data.SqlDbType.VarChar, 20))
                Else
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodMarca", System.Data.SqlDbType.VarChar, 2))
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodFamilia", System.Data.SqlDbType.VarChar, 2))
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodLinea", System.Data.SqlDbType.VarChar, 3))
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCategoria", System.Data.SqlDbType.VarChar, 3))
                    .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.Int, 4))
                    If Not bolopc Then 'Tienda 53 varias
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodTipoPrecio", System.Data.SqlDbType.VarChar, 1))
                    End If
                End If
            End If

        End With

        scdaImpresion.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            With scdaImpresion.SelectCommand
                If bolopc And strCodArticulo <> String.Empty Then 'Tienda 53 especifica
                    .Parameters("@CodArticulo").Value = strCodArticulo
                Else
                    If (strCodArticulo <> String.Empty) Then
                        .Parameters("@CodArticulo").Value = strCodArticulo
                        .Parameters("@Talla").Value = strTalla
                    Else
                        .Parameters("@CodMarca").Value = strCodMarca
                        .Parameters("@CodFamilia").Value = strCodFamilia
                        .Parameters("@CodLinea").Value = strCodLinea
                        .Parameters("@CodCategoria").Value = strCodCategoria
                        .Parameters("@Tipo").Value = Tipo
                        If Not bolopc Then 'Tienda 53 varias
                            .Parameters("@CodTipoPrecio").Value = strCodTipoPrecio
                        End If
                    End If
                End If


            End With

            'Fill DataSet
            scdaImpresion.Fill(dsImpresion, "CatalogoArticulos")

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

        Return dsImpresion

    End Function

    Public Function GetCorrida(ByVal CodArticulo As String, ByVal CodAlmacen As String) As DataTable
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetCorrida", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim dtResult As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodArticulo", CodArticulo)
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtResult)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtResult
    End Function

    Public Function GetExistenciaArticulo(ByVal CodArticulo As String, ByVal talla As String) As Integer
        Dim conexion As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetExistenciaByCodArticulo", conexion)
        Dim cuenta As Integer = 0
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodArticulo", CodArticulo)
            command.Parameters.Add("@Numero", talla)
            cuenta = CInt(command.ExecuteScalar())
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return cuenta
    End Function

    '-------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 03/06/2014: Función para obtener las tallas con existencias de un articulo
    '-------------------------------------------------------------------------------------------------------------------



    Public Function GetCorridaExistencia(ByVal CodArticulo As String, ByVal numero As String) As DataTable
        Dim dtResult As New DataTable
        Dim conexion As New SqlConnection(Parent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetCorridaExistencia", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandText = "SELECT Numero FROM Existencias WHERE CodArticulo='" & CodArticulo & "' AND Numero IN (" & numero & ") AND Libre>0 AND CodAlmacen='" + oParent.ApplicationContext.ApplicationConfiguration.Almacen + "' ORDER BY Numero"
            'command.CommandType = CommandType.StoredProcedure
            'command.Parameters.Add("@CodArticulo", CodArticulo)
            'command.Parameters.Add(New SqlParameter("@Numeros", SqlDbType.VarChar))
            'Console.WriteLine(numero)
            'command.Parameters("@Numeros").Value = numero
            'reader = command.ExecuteReader()
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtResult)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtResult
    End Function

#End Region


End Class
