Imports System.IO

Public Class ResultadoConsultaExistencias

    Private m_strArticuloID As String
    Private m_strDescripcion As String
    Private m_strColor As String
    Private m_dblPrecio As Double
    Private m_strPromocion As Double
    Private m_strDescuento As Double
    Private m_strLinea As String
    Private m_strFamilia As String
    'Private m_strUso As Integer
    Private m_strUso As String
    Private m_objFoto As MemoryStream
    Private m_dsExistencias As DataSet
    Private m_bHaveImage As Boolean
    Private m_bHaveImageAlter As Boolean
    Private m_objFotoAlter As MemoryStream
    Private m_strCodAlt1 As String
    Private m_strCodAlt2 As String
    Private m_strCodAlt3 As String
    Private m_strCodCorrida As String
    Private m_strJerarquia As String
    Private m_strCodMarca As String
    Private m_strCodArtProv As String

#Region "Object Status Flags"

    Dim bolDirty As Boolean
    Dim bolNew As Boolean

    Public Function IsDirty() As Boolean
        Return bolDirty
    End Function

    Friend Sub SetStateDirty()
        bolDirty = True
    End Sub

    Friend Sub ResetStateDirty()
        bolDirty = False
    End Sub

    Public Function IsNew() As Boolean
        Return bolNew
    End Function

    Friend Sub SetStateNew()
        bolNew = True
    End Sub

    Friend Sub ResetStateNew()
        bolNew = False
    End Sub

#End Region

    Public Property CodMarca() As String
        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value
        End Set
    End Property

    Public Property Jeraquia() As String
        Get
            Return m_strJerarquia
        End Get
        Set(ByVal Value As String)
            m_strJerarquia = Value
        End Set
    End Property

    Public Property HaveImage() As Boolean
        Get
            Return m_bHaveImage
        End Get
        Set(ByVal Value As Boolean)
            m_bHaveImage = Value
        End Set
    End Property



    Public Property HaveImageAlter() As Boolean
        Get
            Return m_bHaveImageAlter
        End Get
        Set(ByVal Value As Boolean)
            m_bHaveImageAlter = Value
        End Set
    End Property


    Public Property ArticuloID() As String
        Get
            Return m_strArticuloID
        End Get
        Set(ByVal Value As String)
            m_strArticuloID = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
        End Set
    End Property

    Public Property Color() As String
        Get
            Return m_strColor
        End Get
        Set(ByVal Value As String)
            m_strColor = Value
        End Set
    End Property

    Public Property Precio() As Double
        Get
            Return m_dblPrecio
        End Get
        Set(ByVal Value As Double)
            m_dblPrecio = Value
        End Set
    End Property

    Public Property Promocion() As Double


        Get
            Return m_strPromocion
        End Get
        Set(ByVal Value As Double)
            m_strPromocion = Value
        End Set
    End Property

    Public Property Descuento() As Double
        Get
            Return m_strDescuento
        End Get
        Set(ByVal Value As Double)
            m_strDescuento = Value
        End Set
    End Property

    Public Property Linea() As String
        Get
            Return m_strLinea
        End Get
        Set(ByVal Value As String)
            m_strLinea = Value
        End Set
    End Property

    Public Property Familia() As String
        Get
            Return m_strFamilia
        End Get
        Set(ByVal Value As String)
            m_strFamilia = Value
        End Set
    End Property

    Public Property Uso() As String
        Get
            Return m_strUso
        End Get
        Set(ByVal Value As String)
            m_strUso = Value
        End Set
    End Property

    Public Property Foto() As MemoryStream

        Get
            Return m_objFoto
        End Get
        Set(ByVal Value As MemoryStream)
            m_objFoto = Value
        End Set

    End Property

    Public Property FotoAlter() As MemoryStream

        Get
            Return m_objFotoAlter
        End Get
        Set(ByVal Value As MemoryStream)
            m_objFotoAlter = Value
        End Set

    End Property


    Public Property Existencias() As DataSet
        Get
            Return m_dsExistencias
        End Get
        Set(ByVal Value As DataSet)
            m_dsExistencias = Value
        End Set
    End Property

    Public Property CodAlt1() As String

        Get
            Return m_strCodAlt1
        End Get
        Set(ByVal Value As String)
            m_strCodAlt1 = Value
        End Set

    End Property

    Public Property CodAlt2() As String

        Get
            Return m_strCodAlt2
        End Get
        Set(ByVal Value As String)
            m_strCodAlt2 = Value
        End Set

    End Property

    Public Property CodAlt3() As String

        Get
            Return m_strCodAlt3
        End Get
        Set(ByVal Value As String)
            m_strCodAlt3 = Value
        End Set

    End Property


    Public Property CodCorrida() As String
        Get
            Return m_strCodCorrida
        End Get
        Set(ByVal Value As String)
            m_strCodCorrida = Value
        End Set
    End Property

    Public Property CodArtProv() As String
        Get
            Return m_strCodArtProv
        End Get
        Set(ByVal Value As String)
            m_strCodArtProv = Value           
        End Set
    End Property

End Class
