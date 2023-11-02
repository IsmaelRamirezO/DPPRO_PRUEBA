Imports System.Data.SqlClient

'---------------------------------------------------------------------------------------------------------------------------------
'JNAVA 26/09/2014: Clase para tratar el detalle de Otros Pagos
'---------------------------------------------------------------------------------------------------------------------------------
Public Class OtrosPagosDetalle

#Region "Constructores"

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Constructor para crear un PedidoDetalle nuevo
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New()

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Constructor para cargar un PedidoDetalle
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New(ByVal OtrosPagosDetalleID As Integer)
        Me.LoadData(OtrosPagosDetalleID)
    End Sub

#End Region

#Region "Variables de Detalle"

    Private m_OtrosPagosDetalleID As Integer
    Private m_OtrosPagosID As Integer
    Private m_CodFormasPago As String
    Private m_CodBanco As String
    Private m_CodTipoTarjeta As String
    Private m_NumeroTarjeta As String
    Private m_Promocion As Integer
    Private m_NumeroAutorizacion As String
    Private m_MontoPago As Decimal
    Private m_Fecha As DateTime
    Private m_IsNew As Boolean = True
    Private m_IsDirty As Boolean = False

#End Region

#Region "Propiedades"

    Public ReadOnly Property OtrosPagosDetalleID() As Integer
        Get
            Return m_OtrosPagosDetalleID
        End Get
    End Property

    Public Property OtrosPagosID() As Integer
        Get
            Return m_OtrosPagosID
        End Get
        Set(ByVal Value As Integer)
            Me.m_IsDirty = True
            m_OtrosPagosID = Value
        End Set
    End Property

    Public Property CodFormasPago() As String
        Get
            Return m_CodFormasPago
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodFormasPago = Value
        End Set
    End Property

    Public Property CodBanco() As String
        Get
            Return m_CodBanco
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodBanco = Value
        End Set
    End Property

    Public Property CodTipoTarjeta() As String
        Get
            Return m_CodTipoTarjeta
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodTipoTarjeta = Value
        End Set
    End Property

    Public Property NumeroTarjeta() As String
        Get
            Return m_NumeroTarjeta
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_NumeroTarjeta = Value
        End Set
    End Property

    Public Property Promocion() As Integer
        Get
            Return m_Promocion
        End Get
        Set(ByVal Value As Integer)
            Me.m_IsDirty = True
            m_Promocion = Value
        End Set
    End Property

    Public Property NumeroAutorizacion() As String
        Get
            Return m_NumeroAutorizacion
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_NumeroAutorizacion = Value
        End Set
    End Property

    Public Property MontoPago() As Decimal
        Get
            Return m_MontoPago
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_MontoPago = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal Value As DateTime)
            Me.m_IsDirty = True
            m_Fecha = Value
        End Set
    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return m_IsNew
        End Get
    End Property

    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return m_IsDirty
        End Get
    End Property

#End Region

#Region "Metodos Privados"

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Carga un detalle por medio de OtrosPagosDetalleID
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function LoadData(ByVal ID As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("LoadDataOtrosPagosDetalle", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@OtrosPagosDetalleID", ID)
            reader = command.ExecuteReader()
            While reader.Read()
                m_OtrosPagosDetalleID = CInt(reader("OtrosPagosDetalleID"))
                OtrosPagosID = CInt(reader("OtrosPagosID"))
                CodFormasPago = CStr(reader("CodFormasPago"))
                CodBanco = CStr(reader("CodBanco"))
                CodTipoTarjeta = CStr(reader("CodTipoTarjeta"))
                NumeroTarjeta = CStr(reader("NumeroTarjeta"))
                Promocion = CInt(reader("Promocion"))
                NumeroAutorizacion = CStr(reader("NumeroAutorizacion"))
                MontoPago = CDec(reader("MontoPago"))
                Fecha = CDate(reader("Fecha"))
            End While
            reader.Close()
            command.Dispose()
            conexion.Close()
            Me.m_IsDirty = False
            Me.m_IsNew = False
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

#End Region

#Region "Metodos de Movimientos"

    '--------------------------------------------------------------------------------------------------------------------------------
    ' Obtiene todos los OtrosPagosDetalle Por el OtrosPagosID
    '--------------------------------------------------------------------------------------------------------------------------------
    Public Shared Function GetOtrosPagosDetalleByOtrosPagosID(ByVal OtrosPagosID As Integer) As OtrosPagosDetalle()
        Dim detalles() As OtrosPagosDetalle
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("OtrosPagosDetalleSelByOtrosPagosID", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim datos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@OtrosPagosID ", OtrosPagosID)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            If Not datos Is Nothing Then
                If datos.Rows.Count > 0 Then
                    ReDim detalles(datos.Rows.Count - 1)
                    Dim index As Integer = 0
                    For Each row As DataRow In datos.Rows
                        Dim IdDetalle As Integer = CInt(row!OtrosPagosDetalleID)
                        detalles(index) = New OtrosPagosDetalle(IdDetalle)
                        index += 1
                    Next
                End If
            End If
            adapter.Dispose()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return detalles
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Guarda para insertar y actualizar OtrosPagosDetalles
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function Save() As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("OtrosPagosDetallesSave", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            Dim ParameterID As New SqlParameter("@OtrosPagosDetalleID", SqlDbType.Int)
            ParameterID.Direction = ParameterDirection.InputOutput
            ParameterID.Value = Me.m_OtrosPagosDetalleID
            command.Parameters.Add(ParameterID)
            command.Parameters.Add("@OtrosPagosID", Me.OtrosPagosID)
            command.Parameters.Add("@CodFormasPago", Me.CodFormasPago)
            command.Parameters.Add("@CodBanco", Me.CodBanco)
            command.Parameters.Add("@CodTipoTarjeta", Me.CodTipoTarjeta)
            command.Parameters.Add("@NumeroTarjeta", Me.NumeroTarjeta)
            command.Parameters.Add("@Promocion", Me.Promocion)
            command.Parameters.Add("@NumeroAutorizacion", Me.NumeroAutorizacion)
            command.Parameters.Add("@MontoPago", Me.MontoPago)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.ExecuteScalar()
            If Not ParameterID.Value Is DBNull.Value Then
                Me.m_OtrosPagosDetalleID = ParameterID.Value
                Me.m_IsDirty = False
                Me.m_IsNew = False
            End If
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw sql
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw ex 'New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

#End Region

End Class
