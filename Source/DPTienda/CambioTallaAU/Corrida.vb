Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class Corrida
    Private ApplicationContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private m_CodCorrida As String
    Private m_Descripcion As String
    Private m_NumInicio As Decimal
    Private m_NumFin As Decimal
    Private m_Salto As Decimal
    Private m_Tope As Decimal
    Private m_Tallas As Dictionary(Of String, String)

    Public Property CodCorrida As String
        Get
            Return m_CodCorrida
        End Get
        Set(value As String)
            m_CodCorrida = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    Public Property NumInicio As Decimal
        Get
            Return m_NumInicio
        End Get
        Set(value As Decimal)
            m_NumInicio = value
        End Set
    End Property

    Public Property NumFin As Decimal
        Get
            Return m_NumFin
        End Get
        Set(value As Decimal)
            m_NumFin = value
        End Set
    End Property

    Public Property Salto As Decimal
        Get
            Return m_Salto
        End Get
        Set(value As Decimal)
            m_Salto = value
        End Set
    End Property

    Public Property Tope As Decimal
        Get
            Return m_Tope
        End Get
        Set(value As Decimal)
            m_Tope = value
        End Set
    End Property

    Public Property Tallas As Dictionary(Of String, String)
        Get
            Return m_Tallas
        End Get
        Set(value As Dictionary(Of String, String))
            m_Tallas = value
        End Set
    End Property

    '----------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 04/03/2016: Inserta o actualiza un elemento en la corrida
    '----------------------------------------------------------------------------------------------------------------------------

    Public Sub Save()
        Dim conexion As New SqlConnection(ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("SaveCorrida", conexion)
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@CodCorrida", Me.CodCorrida)
            command.Parameters.AddWithValue("@Descripcion", Me.Descripcion)
            command.Parameters.AddWithValue("@NumInicio", Me.NumInicio)
            command.Parameters.AddWithValue("@NumFin", Me.NumFin)
            command.Parameters.AddWithValue("@Salto", Me.Salto)
            command.Parameters.AddWithValue("@Tope", Me.Tope)
            command.Parameters.Add(New SqlParameter("@C01", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C02", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C03", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C04", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C05", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C06", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C07", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C08", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C09", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C10", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C11", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C12", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C13", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C14", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C15", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C16", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C17", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C18", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C19", SqlDbType.VarChar))
            command.Parameters.Add(New SqlParameter("@C20", SqlDbType.VarChar))
            Dim rango As String = "C", numero As Integer = 1
            Dim rangoparam As String = ""
            Dim i As Integer = 1
            For i = 1 To 20
                rangoparam = rango & CStr(i).PadLeft(2, "0")
                If Me.Tallas.ContainsKey(rangoparam) Then
                    command.Parameters("@" & rangoparam).Value = Me.Tallas(rangoparam)
                Else
                    command.Parameters("@" & rangoparam).Value = "0"
                End If
            Next
            command.ExecuteNonQuery()
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
    End Sub

    Public Sub New(ByVal context As DportenisPro.DPTienda.Core.ApplicationContext)
        ApplicationContext = context
        m_Tallas = New Dictionary(Of String, String)
    End Sub
End Class
