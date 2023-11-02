Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class MetasDia

#Region "Variables Instancias"
    Private m_MetaDiaTiendaID As Integer
    Private m_Quincena As Integer
    Private m_Fecha As DateTime
    Private m_MetaDia As Decimal
#End Region

#Region "Propiedades"
    Public Property MetaDiaTiendaID() As Integer
        Get
            Return m_MetaDiaTiendaID
        End Get
        Set(ByVal Value As Integer)
            m_MetaDiaTiendaID = Value
        End Set
    End Property

    Public Property Quincena() As Integer
        Get
            Return m_Quincena
        End Get
        Set(ByVal Value As Integer)
            m_Quincena = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal Value As DateTime)
            m_Fecha = Value
        End Set
    End Property

    Public Property MetaDia() As Decimal
        Get
            Return m_MetaDia
        End Get
        Set(ByVal Value As Decimal)
            m_MetaDia = Value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New()
    End Sub

#End Region

#Region "Metodos"
    Public Function Save() As Boolean
        Dim valido As Boolean = False
        Dim ts As SqlTransaction = Nothing
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SaveMetaDiaTienda", conexion)
        Dim parameter As SqlParameter
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            parameter = New SqlParameter("@MetaDiaTiendaID", SqlDbType.Int)
            parameter.Direction = ParameterDirection.InputOutput
            parameter.Value = Me.MetaDiaTiendaID
            command.Parameters.Add(parameter)
            command.Parameters.Add("@Quincena", Me.Quincena)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.Parameters.Add("@MetaDia", Me.MetaDia)
            command.ExecuteNonQuery()
            If IsDBNull(parameter.Value) = False Then
                Me.MetaDiaTiendaID = parameter.Value
            End If
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al guardar la Meta del día")
            Throw ex
        End Try
        Return valido
    End Function

    Public Shared Function GetMetaDias(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As ArrayList
        Dim lstMetas As New ArrayList
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetMetaDiaTienda", conexion)
        Dim metaPlayer As MetaDiaPlayer = Nothing
        Dim reader As SqlDataReader = Nothing
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim meta As MetasDia = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@FechaInicio", FechaInicio)
            command.Parameters.Add("@FechaFin", FechaFin)
            reader = command.ExecuteReader()
            If reader.HasRows = True Then
                While reader.Read()
                    meta = New MetasDia
                    meta.MetaDiaTiendaID = CInt(reader("MetaDiaTiendaID"))
                    meta.Quincena = CInt(reader("Quincena"))
                    meta.Fecha = CDate(reader("Fecha"))
                    meta.MetaDia = CDec(reader("MetaDia"))
                    lstMetas.Add(meta)
                End While
                command.Dispose()
            End If
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al cargar la Meta del Día")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return lstMetas
    End Function

    Public Shared Function GetMetaTiendaDia(ByVal Fecha As DateTime) As MetasDia
        Dim meta As MetasDia = Nothing
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetMetaByTienda", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Fecha", Fecha)
            reader = command.ExecuteReader()
            While reader.Read()
                meta = New MetasDia
                meta.MetaDiaTiendaID = CInt(reader("MetaDiaTiendaID"))
                meta.Quincena = CInt(reader("Quincena"))
                meta.Fecha = CDate(reader("Fecha"))
                meta.MetaDia = CDec(reader("MetaDia"))
            End While
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return meta
    End Function


#End Region

End Class

Public Class MetaDiaPlayer
#Region "Variables Privadas"
    Private m_MetaDiaPlayerID As Integer
    Private m_CodPlayer As String
    Private m_Quincena As Integer
    Private m_Fecha As DateTime
    Private m_MetaDia As Decimal
#End Region

#Region "Propiedades"
    Public Property MetaDiaPlayerID() As Integer
        Get
            Return m_MetaDiaPlayerID
        End Get
        Set(ByVal Value As Integer)
            m_MetaDiaPlayerID = Value
        End Set
    End Property

    Public Property CodPlayer() As String
        Get
            Return m_CodPlayer
        End Get
        Set(ByVal Value As String)
            m_CodPlayer = Value
        End Set
    End Property

    Public Property Quincena() As Integer
        Get
            Return m_Quincena
        End Get
        Set(ByVal Value As Integer)
            m_Quincena = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal Value As DateTime)
            m_Fecha = Value
        End Set
    End Property

    Public Property MetaDia() As Decimal
        Get
            Return m_MetaDia
        End Get
        Set(ByVal Value As Decimal)
            m_MetaDia = Value
        End Set
    End Property
#End Region

#Region "Metodos"

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        Dim ts As SqlTransaction = Nothing
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SaveMetaDiaPlayer", conexion)
        Dim parameter As SqlParameter
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            parameter = New SqlParameter("@MetaDiaPlayerID", SqlDbType.Int)
            parameter.Direction = ParameterDirection.InputOutput
            parameter.Value = Me.MetaDiaPlayerID
            command.Parameters.Add(parameter)
            command.Parameters.Add("@Quincena", Me.Quincena)
            command.Parameters.Add("@CodPlayer", Me.CodPlayer)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.Parameters.Add("@MetaDia", Me.MetaDia)
            command.ExecuteNonQuery()
            If IsDBNull(parameter.Value) = False Then
                Me.MetaDiaPlayerID = parameter.Value
            End If
            ts.Commit()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al guardar la Meta del día del player: " & Me.CodPlayer)
            Throw ex
        End Try
        Return valido
    End Function

    Public Shared Function GetMetasDiasPlayers(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As ArrayList
        Dim lstMetas As New ArrayList
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetMetaDiaPlayer", conexion)
        Dim metaPlayer As MetaDiaPlayer = Nothing
        Dim reader As SqlDataReader = Nothing
        Dim process As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim meta As MetaDiaPlayer = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@FechaInicio", fechaInicio)
            command.Parameters.Add("@FechaFin", fechaFin)
            reader = command.ExecuteReader()
            If reader.HasRows = True Then
                While reader.Read()
                    meta = New MetaDiaPlayer
                    meta.MetaDiaPlayerID = CInt(reader("MetaDiaPlayerID"))
                    meta.Quincena = CInt(reader("Quincena"))
                    meta.CodPlayer = CStr(reader("CodPlayer"))
                    meta.Fecha = CDate(reader("Fecha"))
                    meta.MetaDia = CDec(reader("MetaDia"))
                    lstMetas.Add(meta)
                End While
                command.Dispose()
            End If
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al cargar la Meta del Día")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return lstMetas
    End Function

    Public Shared Function GetMetasVentas(ByVal CodAlmacen As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Dim dtResult As New DataTable
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetVentasTienda", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodAlmacen", CodAlmacen)
            command.Parameters.Add("@FechaInicio", FechaInicio)
            command.Parameters.Add("@FechaFin", FechaFin)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(dtResult)
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error al Obtener las ventas")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return dtResult
    End Function

    Public Shared Function GetMetaByPlayer(ByVal CodPlayer As String, ByVal fecha As DateTime) As MetaDiaPlayer
        Dim meta As MetaDiaPlayer = Nothing
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetMetaByPlayer", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodPlayer", CodPlayer)
            command.Parameters.Add("@Fecha", fecha)
            reader = command.ExecuteReader()
            While reader.Read()
                meta = New MetaDiaPlayer
                meta.MetaDiaPlayerID = CInt(reader("MetaDiaPlayerID"))
                meta.Quincena = CInt(reader("Quincena"))
                meta.CodPlayer = CStr(reader("CodPlayer"))
                meta.Fecha = CDate(reader("Fecha"))
                meta.MetaDia = CDec(reader("MetaDia"))
            End While
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Error al cargar la meta del Player " & CodPlayer)
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return meta
    End Function

    Public Shared Function GetSumaMetaPlayerByRange(ByVal CodPlayer As String, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As Hashtable
        Dim lstMeta As New Hashtable
        Dim meta As Decimal = 0
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetTotalMetaDiariaByPlayer", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CodPlayer", CodPlayer)
            command.Parameters.Add("@FechaInicio", FechaInicio)
            command.Parameters.Add("@FechaFin", FechaFin)
            reader = command.ExecuteReader()
            If reader.HasRows Then
                lstMeta("TieneMeta") = True
                reader.Read()
                meta = CDec(reader("SumaMeta"))
                lstMeta("Meta") = meta
            Else
                lstMeta("TieneMeta") = False
            End If
            command.Dispose()
            conexion.Close()
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            lstMeta("TieneMeta") = False
            EscribeLog(ex.Message, "Error al obtener las metas diarias")
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return lstMeta
    End Function

#End Region
End Class
