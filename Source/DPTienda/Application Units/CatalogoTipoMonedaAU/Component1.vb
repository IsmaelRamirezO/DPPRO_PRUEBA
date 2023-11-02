Public Class Component1
    Inherits System.ComponentModel.Component

#Region " C�digo generado por el Dise�ador de componentes "

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requerido para la compatibilidad con el Dise�ador de composiciones de clases Windows.Forms
        Container.Add(me)
    End Sub

    Public Sub New()
        MyBase.New()

        'El Dise�ador de componentes requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicializaci�n despu�s de la llamada a InitializeComponent()

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

    'Requerido por el Dise�ador de componentes
    Private components As System.ComponentModel.IContainer

    'NOTA: el Dise�ador de componentes requiere el siguiente procedimiento
    'Se puede modificar utilizando el Dise�ador de componentes.
    'No lo modifique con el editor de c�digo.
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlCommand1 As System.Data.SqlClient.SqlCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=MARCELA;packet size=4096;user id=sa;data source=OPERACIONES;persis" & _
        "t security info=True;initial catalog=PTVenta;password=sa"
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "dbo.[CatalogoTipoMonedaSelAll]"
        Me.SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure
        Me.SqlCommand1.Connection = Me.SqlConnection1
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

    End Sub

#End Region

End Class
