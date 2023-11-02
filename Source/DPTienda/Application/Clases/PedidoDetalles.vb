Imports System.Data.SqlClient

Public Class PedidoDetalles

#Region "Constructores"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Constructor para crear un PedidoDetalle nuevo
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub New()

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Constructor para cargar un PedidoDetalle
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub New(ByVal PedidoDetalleID As Integer)
        Me.LoadData(PedidoDetalleID)
    End Sub

#End Region

#Region "Variables de Detalles"
    Private m_PedidoDetalleID As Integer
    Private m_PedidoID As Integer
    Private m_CodArticulo As String
    Private m_Cantidad As Decimal
    Private m_Numero As String
    Private m_CostoUnit As Decimal
    Private m_PrecioUnit As Decimal
    Private m_PrecioOferta As Decimal
    Private m_Total As Decimal
    Private m_CodTipoDescuento As String
    Private m_Descuento As Decimal
    Private m_DescuentoSistema As Decimal
    Private m_CantDescuentoSistema As Decimal
    Private m_Condicion As String
    Private m_Usuario As String
    Private m_Fecha As DateTime
    Private m_StatusRegistro As Boolean
    Private m_IsNew As Boolean = True
    Private m_IsDirty As Boolean = False
    Private m_Descripcion As String = ""
    '---------------------------------------------------------------------
    'FLIZARRAGA 16/01/2017: Se agrego el código proveedor
    '---------------------------------------------------------------------
    Private m_CodProveedor As String = ""

#End Region

#Region "Propiedades"

    Public ReadOnly Property PedidoDetalleID() As Integer
        Get
            Return m_PedidoDetalleID
        End Get
    End Property

    Public Property PedidoID() As Integer
        Get
            Return m_PedidoID
        End Get
        Set(ByVal Value As Integer)
            Me.m_IsDirty = True
            m_PedidoID = Value
        End Set
    End Property

    Public Property CodArticulo() As String
        Get
            Return m_CodArticulo
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodArticulo = Value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return m_Cantidad
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_Cantidad = Value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return m_Numero
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Numero = Value
        End Set
    End Property

    Public Property CostoUnit() As Decimal
        Get
            Return m_CostoUnit
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_CostoUnit = Value
        End Set
    End Property

    Public Property PrecioUnit() As Decimal
        Get
            Return m_PrecioUnit
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_PrecioUnit = Value
        End Set
    End Property

    Public Property PrecioOferta() As Decimal
        Get
            Return m_PrecioOferta
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_PrecioOferta = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return m_Total
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_Total = Value
        End Set
    End Property

    Public Property CodTipoDescuento() As String
        Get
            Return m_CodTipoDescuento
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodTipoDescuento = Value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return m_Descuento
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_Descuento = Value
        End Set
    End Property

    Public Property DescuentoSistema() As Decimal
        Get
            Return m_DescuentoSistema
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_DescuentoSistema = Value
        End Set
    End Property

    Public Property CantDescuentoSistema() As Decimal
        Get
            Return m_CantDescuentoSistema
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_CantDescuentoSistema = Value
        End Set
    End Property

    Public Property Condicion() As String
        Get
            Return m_Condicion
        End Get
        Set(ByVal Value As String)
            m_Condicion = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Usuario = Value
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

    Public Property StatusRegistro() As Boolean
        Get
            Return m_StatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            Me.m_IsDirty = True
            m_StatusRegistro = Value
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

    Public Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    Public Property CodProveedor As String
        Get
            Return m_CodProveedor
        End Get
        Set(value As String)
            m_CodProveedor = value
        End Set
    End Property

#End Region

#Region "Metodos Privados"

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Carga un detalle por medio de PedidoDetalleID
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function LoadData(ByVal ID As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("LoadDataPedidoDetalle", conexion)
        Dim reader As SqlDataReader = Nothing
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoDetalleID", ID)
            reader = command.ExecuteReader()
            While reader.Read()
                Me.m_PedidoDetalleID = CInt(reader("PedidoDetalleID"))
                Me.PedidoID = CInt(reader!PedidoID)
                Me.CodArticulo = CStr(reader("CodArticulo"))
                Me.Cantidad = CDec(reader!Cantidad)
                Me.Numero = CStr(reader("Numero"))
                Me.CostoUnit = CDec(reader("CostoUnit"))
                Me.PrecioUnit = CDec(reader("PrecioUnit"))
                Me.PrecioOferta = CDec(reader("PrecioOferta"))
                Me.Total = CDec(reader("Total"))
                Me.CodTipoDescuento = CStr(reader("CodTipoDescuento"))
                Me.Descuento = CDec(reader("Descuento"))
                Me.DescuentoSistema = CDec(reader("DescuentoSistema"))
                Me.CantDescuentoSistema = CDec(reader("CantDescuentoSistema"))
                Me.Usuario = CStr(reader("Usuario"))
                Me.Fecha = CDate(reader("Fecha"))
                Me.StatusRegistro = CBool(reader("StatusRegistro"))
                Me.Condicion = IIf(IsDBNull(reader("Condicion")), "", CStr(reader("Condicion")))
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

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Limpia los valores del objeto
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function ClearValues()
        Me.m_PedidoDetalleID = 0
        Me.PedidoID = 0
        Me.CodArticulo = ""
        Me.Cantidad = 0
        Me.Numero = ""
        Me.CostoUnit = 0
        Me.PrecioUnit = 0
        Me.PrecioOferta = 0
        Me.Total = 0
        Me.CodTipoDescuento = ""
        Me.Descuento = 0
        Me.DescuentoSistema = 0
        Me.CantDescuentoSistema = 0
        Me.Condicion = ""
        Me.Usuario = ""
        Me.Fecha = DateTime.Now
        Me.StatusRegistro = False
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Elimina los detalles y el pedido en caso de surgir un error
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Function RollBack(ByVal ID As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("RollBackPedidosDetalles", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", ID)
            command.ExecuteScalar()
            ts.Commit()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al hacer el rollback el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al hacer el rollback en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

#End Region

#Region "Metodos de Movimientos"
    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Guarda para insertar y actualizar los pedidos detalles
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SavePedidoDetalle", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            Dim ParameterID As New SqlParameter("@PedidoDetalleID", SqlDbType.Int)
            ParameterID.Direction = ParameterDirection.InputOutput
            ParameterID.Value = Me.m_PedidoDetalleID
            command.Parameters.Add(ParameterID)
            command.Parameters.Add("@PedidoID", Me.PedidoID)
            command.Parameters.Add("@CodArticulo", Me.CodArticulo)
            command.Parameters.Add("@Cantidad", Me.Cantidad)
            command.Parameters.Add("@Numero", Me.Numero)
            command.Parameters.Add("@CostoUnit", Me.CostoUnit)
            command.Parameters.Add("@PrecioUnit", Me.PrecioUnit)
            command.Parameters.Add("@PrecioOferta", Me.PrecioOferta)
            command.Parameters.Add("@Total", Me.Total)
            command.Parameters.Add("@CodTipoDescuento", Me.CodTipoDescuento)
            command.Parameters.Add("@Descuento", Me.Descuento)
            command.Parameters.Add("@DescuentoSistema", Me.DescuentoSistema)
            command.Parameters.Add("@CantDescuentoSistema", Me.CantDescuentoSistema)
            command.Parameters.Add("@Usuario", Me.Usuario)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.Parameters.Add("@StatusRegistro", Me.StatusRegistro)
            command.Parameters.Add("@Condicion", Me.Condicion)
            command.ExecuteScalar()
            If Not ParameterID.Value Is DBNull.Value Then
                Me.m_PedidoDetalleID = ParameterID.Value
                Me.m_IsDirty = False
                Me.m_IsNew = False
            End If
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                'RollBack(Me.PedidoID)
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw sql
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                'RollBack(Me.PedidoID)
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw ex 'New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Elimina el PedidoDetalle cargado
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Function Delete() As Boolean
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("DeletePedidoDetalle", conexion)
        Dim valido As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoDetalleID", Me.PedidoDetalleID)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
            valido = True
            ClearValues()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al eliminar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA: 25/04/2013 Elimina El pedido Detalle por medio de su ID
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function Delete(ByVal PedidoDetalleID) As Boolean
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("DeletePedidoDetalle", conexion)
        Dim valido As Boolean = False
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoDetalleID", PedidoDetalleID)
            command.ExecuteScalar()
            command.Dispose()
            conexion.Close()
            valido = True
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al eliminar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Obtiene todos los PedidosDetalles Por el PedidoID
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Shared Function GetPedidoDetallesByPedidoID(ByVal Id As Integer) As PedidoDetalles()
        Dim detalles() As PedidoDetalles
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetPedidosDetalleByPedidoID", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim datos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", Id)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            If Not datos Is Nothing Then
                If datos.Rows.Count > 0 Then
                    ReDim detalles(datos.Rows.Count - 1)
                    Dim index As Integer = 0
                    For Each row As DataRow In datos.Rows
                        Dim IdDetalle As Integer = CInt(row!PedidoDetalleID)
                        detalles(index) = New PedidoDetalles(IdDetalle)
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

    Public Shared Function GetPedidoDetallesDataTableByPedidoID(ByVal Id As Integer) As DataTable
        Dim detalles() As PedidoDetalles
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("GetPedidosDetalleByPedidoID", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim datos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@PedidoID", Id)
            adapter = New SqlDataAdapter(command)
            adapter.Fill(datos)
            
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
        Return datos
    End Function

    '--------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/04/2013: Guarda el Pedido Detalle en SAP
    '--------------------------------------------------------------------------------------------------------------------------------

    Public Function SaveSAP() As Boolean
        Dim valido As Boolean = False
        Return valido
    End Function

#End Region

End Class
