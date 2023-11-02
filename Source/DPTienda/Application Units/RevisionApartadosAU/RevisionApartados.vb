Public Class RevisionApartados

#Region "Variables"
    Private m_datDetalle As New DataSet

    Private m_strResponsable As String

    Private m_strAdministrativo As String

    Private m_strSucursal As String

    Private m_intFolio As Integer
#End Region
    

#Region "Object Status Flags"

    Private bolIsDirty As Boolean
    Private bolIsNew As Boolean

    Public Function IsDirty() As Boolean
        Return bolIsDirty
    End Function

    Public Function IsNew() As Boolean
        Return bolIsNew
    End Function

    Friend Sub SetFlagDirty()
        bolIsDirty = True
    End Sub

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Propiedades"
    Public Property Folio() As Integer
        Get
            Return m_intFolio
        End Get
        Set(ByVal Value As Integer)
            m_intFolio = Value
        End Set
    End Property

    Public Property Sucursal() As String
        Get
            Return m_strSucursal
        End Get
        Set(ByVal Value As String)
            m_strSucursal = Value
        End Set
    End Property

    Public Property Administrativo() As String
        Get
            Return m_strAdministrativo
        End Get
        Set(ByVal Value As String)
            m_strAdministrativo = Value
        End Set
    End Property

    Public Property Responsable() As String
        Get
            Return m_strResponsable
        End Get
        Set(ByVal Value As String)
            m_strResponsable = Value
        End Set
    End Property

    Public Property Detalle() As DataSet
        Get
            Return m_datDetalle
        End Get
        Set(ByVal Value As DataSet)
            m_datDetalle = Value
        End Set
    End Property
#End Region

  

End Class
