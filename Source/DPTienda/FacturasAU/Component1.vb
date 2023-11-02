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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=PCCATW2003;packet size=4096;user id=sa;data source=""192.168.1.33"";" & _
        "persist security info=False;initial catalog=PTVENTA"
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "dbo.[CondicionesVentaFacturaSel]"
        Me.SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand1.Connection = Me.SqlConnection1
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVtas", System.Data.SqlDbType.VarChar, 4))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Jerarquia", System.Data.SqlDbType.VarChar, 18))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondMat", System.Data.SqlDbType.VarChar, 2))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CondPrec", System.Data.SqlDbType.VarChar, 2))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Material", System.Data.SqlDbType.VarChar, 18))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ListPrec", System.Data.SqlDbType.VarChar, 2))

    End Sub

#End Region

End Class
