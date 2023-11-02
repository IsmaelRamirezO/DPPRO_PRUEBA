Public Class TraspasoSalida
    Inherits Traspaso

    Private m_strPedidoEC As String = ""
    Private m_strModulo As String = ""
    Private m_strTEOrigen As String = ""
    Private m_datdtMotivos As DataTable
    Private oParent As TraspasosSalidaManager

#Region "Object Status Flags"

    Private bolFlagIsDirty As Boolean
    Private bolFlagIsNew As Boolean

    Friend Shadows Sub SetFlagIsDirty()
        MyBase.SetFlagIsDirty()
    End Sub

    Friend Shadows Sub ResetFlagIsDirty()
        MyBase.ResetFlagIsDirty()
    End Sub

    Friend Shadows Sub SetFlagIsNew()
        MyBase.SetFlagIsNew()
    End Sub

    Friend Shadows Sub ResetFlagIsNew()
        MyBase.ResetFlagIsNew()
    End Sub

#End Region


#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As TraspasosSalidaManager)
        oParent = Parent

        'dtMotivos
        m_datdtMotivos = Nothing
        m_datdtMotivos = New DataTable

        CreateDtMotivos()
    End Sub

#End Region


#Region "Properties"

    Public Property PedidoEC() As String
        Get
            Return m_strPedidoEC
        End Get
        Set(ByVal Value As String)
            m_strPedidoEC = Value
        End Set
    End Property

    Public Property Modulo() As String
        Get
            Return m_strModulo
        End Get
        Set(ByVal Value As String)
            m_strModulo = Value
        End Set
    End Property

    Public Property TEOrigen() As String
        Get
            Return m_strTEOrigen
        End Get
        Set(ByVal Value As String)
            m_strTEOrigen = Value
        End Set
    End Property

    Public Property Parent() As TraspasosSalidaManager
        Get
            Return oParent
        End Get
        Set(ByVal Value As TraspasosSalidaManager)
            oParent = Value
        End Set
    End Property
    Public Property dtMotivos() As DataTable
        Get
            Return m_datdtMotivos
        End Get
        Set(ByVal Value As DataTable)
            m_datdtMotivos = Value
        End Set
    End Property
#End Region


#Region "Methods"

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Private Sub CreateDtMotivos()

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "FolioFactura"
        dCol.Caption = "FolioFactura"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Tienda"
        dCol.Caption = "Tienda"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 3
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Articulo"
        dCol.Caption = "Articulo"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 30
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Talla"
        dCol.Caption = "Talla"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Integer)
        dCol.ColumnName = "IdMotivo"
        dCol.Caption = "IdMotivo"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = False
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Date)
        dCol.ColumnName = "Fecha"
        dCol.Caption = "Fecha"
        dCol.DefaultValue = Now.Date.ToShortDateString
        dCol.AllowDBNull = False
        m_datdtMotivos.Columns.Add(dCol)

        m_datdtMotivos.AcceptChanges()

    End Sub

    Public Sub Delete()

        oParent.Delete(Me.TraspasoID)

    End Sub



#End Region


End Class
