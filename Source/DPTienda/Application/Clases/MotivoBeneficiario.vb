Imports System.Data.SqlClient
Public Class MotivoBeneficiario
    Private conexion As SqlConnection = Nothing
    Private command As SqlCommand = Nothing
    Private adapter As SqlDataAdapter = Nothing
    Private dtMotivos As DataTable

#Region "Constructores"
    Public Sub New()
        Me.conexion = New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Me.command = New SqlCommand("GetCatalogoMotivosBeneficiarios", conexion)
        Try
            Me.conexion.Open()
            Me.command.CommandText = "GetCatalogoMotivosBeneficiarios"
            Me.command.CommandType = CommandType.StoredProcedure
            Me.adapter = New SqlDataAdapter(Me.command)
            Me.MotivosBeneficiarios = New DataTable
            Me.adapter.Fill(Me.MotivosBeneficiarios)
            Me.command.Dispose()
            Me.conexion.Close()
        Catch sql As SqlException
            If Me.conexion.State <> ConnectionState.Closed Then
                Me.conexion.Close()
            End If
            Throw New ApplicationException("Error al obtener datos en la base de datos", sql)
            EscribeLog(sql.Message, "Error en la base de datos")
        Catch ex As Exception
            If Me.conexion.State <> ConnectionState.Closed Then
                Me.conexion.Close()
            End If
            Throw New ApplicationException("Error en la aplicación", ex)
            EscribeLog(ex.Message, "Error en la aplicación")
        End Try
    End Sub
#End Region

#Region "Propiedades"
    Public Property MotivosBeneficiarios() As DataTable
        Get
            Return dtMotivos
        End Get
        Set(ByVal Value As DataTable)
            dtMotivos = Value
        End Set
    End Property
#End Region


End Class
