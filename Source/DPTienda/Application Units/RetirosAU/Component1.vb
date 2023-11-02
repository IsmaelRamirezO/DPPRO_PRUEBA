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
    Friend WithEvents CatalogoBancosSelAll As System.Data.SqlClient.SqlCommand
    Friend WithEvents RetirosDel As System.Data.SqlClient.SqlCommand
    Friend WithEvents RetirosIns As System.Data.SqlClient.SqlCommand
    Friend WithEvents RetirosSel As System.Data.SqlClient.SqlCommand
    Friend WithEvents RetirosSelAll As System.Data.SqlClient.SqlCommand
    Friend WithEvents RetirosUpd As System.Data.SqlClient.SqlCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.CatalogoBancosSelAll = New System.Data.SqlClient.SqlCommand
        Me.RetirosDel = New System.Data.SqlClient.SqlCommand
        Me.RetirosIns = New System.Data.SqlClient.SqlCommand
        Me.RetirosSel = New System.Data.SqlClient.SqlCommand
        Me.RetirosSelAll = New System.Data.SqlClient.SqlCommand
        Me.RetirosUpd = New System.Data.SqlClient.SqlCommand
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=PCOBX;packet size=4096;user id=sa;data source=Operaciones;persist " & _
        "security info=True;initial catalog=PTVenta;password=sa"
        '
        'CatalogoBancosSelAll
        '
        Me.CatalogoBancosSelAll.CommandText = "dbo.[CatalogoBancosSelAll]"
        Me.CatalogoBancosSelAll.CommandType = System.Data.CommandType.StoredProcedure
        Me.CatalogoBancosSelAll.Connection = Me.SqlConnection1
        Me.CatalogoBancosSelAll.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.CatalogoBancosSelAll.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        '
        'RetirosDel
        '
        Me.RetirosDel.CommandText = "dbo.[RetirosDel]"
        Me.RetirosDel.CommandType = System.Data.CommandType.StoredProcedure
        Me.RetirosDel.Connection = Me.SqlConnection1
        Me.RetirosDel.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosDel.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
        '
        'RetirosIns
        '
        Me.RetirosIns.CommandText = "dbo.[RetirosIns]"
        Me.RetirosIns.CommandType = System.Data.CommandType.StoredProcedure
        Me.RetirosIns.Connection = Me.SqlConnection1
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ficha", System.Data.SqlDbType.Int, 4))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 40))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadRetiro", System.Data.SqlDbType.Money, 4))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosIns.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))
        '
        'RetirosSel
        '
        Me.RetirosSel.CommandText = "dbo.[RetirosSel]"
        Me.RetirosSel.CommandType = System.Data.CommandType.StoredProcedure
        Me.RetirosSel.Connection = Me.SqlConnection1
        Me.RetirosSel.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosSel.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
        '
        'RetirosSelAll
        '
        Me.RetirosSelAll.CommandText = "dbo.[RetirosSelAll]"
        Me.RetirosSelAll.CommandType = System.Data.CommandType.StoredProcedure
        Me.RetirosSelAll.Connection = Me.SqlConnection1
        Me.RetirosSelAll.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosSelAll.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))
        '
        'RetirosUpd
        '
        Me.RetirosUpd.CommandText = "dbo.[RetirosUpd]"
        Me.RetirosUpd.CommandType = System.Data.CommandType.StoredProcedure
        Me.RetirosUpd.Connection = Me.SqlConnection1
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RetiroID", System.Data.SqlDbType.Int, 4))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodBanco", System.Data.SqlDbType.VarChar, 4))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ficha", System.Data.SqlDbType.Int, 4))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Referencia", System.Data.SqlDbType.VarChar, 40))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CantidadRetiro", System.Data.SqlDbType.Money, 4))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.RetirosUpd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1))

    End Sub

#End Region

End Class
