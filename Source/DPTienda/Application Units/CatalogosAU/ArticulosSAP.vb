Public Class ArticulosSAP

#Region "Variables"

    Private m_strCodarticulo As String
    Private m_strCodartprov As String
    Private m_strDescripcion As String
    Private m_strCodlinea As String
    Private m_strCodcorrida As String
    Private m_strCodcategoria As String
    Private m_strCodfamilia As String
    Private m_strCodUso As String
    Private m_dbCostopromedio As Double
    Private m_strCodunidadcom As String
    Private m_strCodunidadvta As String
    Private m_strJerarquia As String
    Private m_strCodigoAnterior As String
    Private m_blDip As Boolean


#End Region

#Region "Fields Accessors"

    Public Property Dip()
        Get
            Return m_blDip
        End Get
        Set(ByVal Value)
            m_blDip = Value
        End Set
    End Property

    Public Property Codarticulo()
        Get
            Return m_strCodarticulo
        End Get
        Set(ByVal Value)
            m_strCodarticulo = Value
        End Set
    End Property

    Public Property Codartprov()
        Get
            Return m_strCodartprov
        End Get
        Set(ByVal Value)
            m_strCodartprov = Value
        End Set
    End Property

    Public Property Descripcion()
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value)
            m_strDescripcion = Value
        End Set
    End Property

    Public Property Codlinea()
        Get
            Return m_strCodlinea
        End Get
        Set(ByVal Value)
            m_strCodlinea = Value
        End Set
    End Property

    Public Property Codcorrida()
        Get
            Return m_strCodcorrida
        End Get
        Set(ByVal Value)
            m_strCodcorrida = Value
        End Set
    End Property

    Public Property Codcategoria()
        Get
            Return m_strCodcategoria
        End Get
        Set(ByVal Value)
            m_strCodcategoria = Value
        End Set
    End Property

    Public Property Codfamilia()
        Get
            Return m_strCodfamilia
        End Get
        Set(ByVal Value)
            m_strCodfamilia = Value
        End Set
    End Property

    Public Property CodUso()
        Get
            Return m_strCodUso
        End Get
        Set(ByVal Value)
            m_strCodUso = Value
        End Set
    End Property

    Public Property Costopromedio()
        Get
            Return m_dbCostopromedio
        End Get
        Set(ByVal Value)
            m_dbCostopromedio = Value
        End Set
    End Property

    Public Property Codunidadcom()
        Get
            Return m_strCodunidadcom
        End Get
        Set(ByVal Value)
            m_strCodunidadcom = Value
        End Set
    End Property

    Public Property Codunidadvta()
        Get
            Return m_strCodunidadvta
        End Get
        Set(ByVal Value)
            m_strCodunidadvta = Value
        End Set
    End Property

    Public Property Jerarquia()
        Get
            Return m_strJerarquia
        End Get
        Set(ByVal Value)
            m_strJerarquia = Value
        End Set
    End Property

    Public Property CodigoAnterior() As String
        Get
            Return m_strCodigoAnterior
        End Get
        Set(ByVal Value As String)
            m_strCodigoAnterior = Value
        End Set
    End Property

#End Region

End Class
