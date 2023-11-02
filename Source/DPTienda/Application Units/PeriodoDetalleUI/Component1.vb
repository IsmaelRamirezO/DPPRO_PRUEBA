Public Class Component1
    Inherits System.ComponentModel.Component

#Region " Código generado por el Diseñador de componentes "

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
        Container.Add(me)
    End Sub

    Public Sub New()
        MyBase.New()

        'El Diseñador de componentes requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Component reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
    'Se puede modificar utilizando el Diseñador de componentes.
    'No lo modifique con el editor de código.
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand2 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand3 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlCommand4 As System.Data.SqlClient.SqlCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlCommand2 = New System.Data.SqlClient.SqlCommand
        Me.SqlCommand3 = New System.Data.SqlClient.SqlCommand
        Me.SqlCommand4 = New System.Data.SqlClient.SqlCommand
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=OBXS;packet size=4096;user id=sa;data source=OPERACIONES;persist s" & _
        "ecurity info=True;initial catalog=CreditoDP;password=sa"
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "dbo.[PeriodoDetalleDel]"
        Me.SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand1.Connection = Me.SqlConnection1
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
        '
        'SqlCommand2
        '
        Me.SqlCommand2.CommandText = "dbo.[PeriodoDetalleIns]"
        Me.SqlCommand2.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand2.Connection = Me.SqlConnection1
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodo", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaPago", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand2.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
        '
        'SqlCommand3
        '
        Me.SqlCommand3.CommandText = "dbo.[PeriodoDetalleSel]"
        Me.SqlCommand3.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand3.Connection = Me.SqlConnection1
        Me.SqlCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand3.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
        '
        'SqlCommand4
        '
        Me.SqlCommand4.CommandText = "dbo.[PeriodoDetalleUpd]"
        Me.SqlCommand4.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand4.Connection = Me.SqlConnection1
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoDetalleID", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PeriodoID", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Anno", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumPeriodo", System.Data.SqlDbType.Int, 4))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaPago", System.Data.SqlDbType.DateTime, 8))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand4.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

    End Sub

#End Region

End Class
