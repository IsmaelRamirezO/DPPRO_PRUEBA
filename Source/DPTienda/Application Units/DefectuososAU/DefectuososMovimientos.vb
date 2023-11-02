
Imports DportenisPro.DPTienda.Core

Public Class DefectuososMovimientos


#Region "Environment Var"

    Private m_intCodTipoMov As Integer
    Private m_strTipoMovimiento As String
    Private m_strStatusMov As String
    Private m_strCodAlmacen As String
    Private m_strDestino As String
    Private m_intFolio As Integer
    Private m_strCodArticulo As String
    Private m_strDescripcion As String
    Private m_decNumero As Decimal
    Private m_decTotal As Decimal
    Private m_decApartados As Decimal
    Private m_decDefectuosos As Decimal
    Private m_decPromocion As Decimal
    Private m_decVtasEspeciales As Decimal
    Private m_decConsignacion As Decimal
    Private m_decTransito As Decimal
    Private m_strCodLinea As String
    Private m_strCodMarca As String
    Private m_strCodFamilia As String
    Private m_strCodUnidad As String
    Private m_intCodUso As Integer
    Private m_intCodCategoria As Integer
    Private m_strUsuario As String
    Private m_decCostoUnit As Decimal
    Private m_decPrecioUnit As Decimal
    Private m_strFolioControl As String
    Private m_strCodCaja As String

#End Region


#Region "Constructors / Destructors"

    Friend Sub New()

        ClearFieldsMovimiento()

    End Sub

#End Region


#Region "Fields"

    Public Property CodCajaMov() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set
    End Property

    Public Property FolioControl() As String
        'TODO   :  CAT - FolioControl IS OUT. Deploy?
        Get
            Return m_strFolioControl
        End Get
        Set(ByVal Value As String)
            m_strFolioControl = Value
        End Set
    End Property

    Public Property PrecioUnit() As Decimal
        Get
            Return m_decPrecioUnit
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecioUnit = Value
        End Set
    End Property

    Public Property CostoUnit() As Decimal
        Get
            Return m_decCostoUnit
        End Get
        Set(ByVal Value As Decimal)
            m_decCostoUnit = Value
        End Set
    End Property

    Public Property UsuarioMov() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set
    End Property

    Public Property CodCategoria() As Integer
        Get
            Return m_intCodCategoria
        End Get
        Set(ByVal Value As Integer)
            m_intCodCategoria = Value
        End Set
    End Property

    Public Property CodUso() As Integer
        Get
            Return m_intCodUso
        End Get
        Set(ByVal Value As Integer)
            m_intCodUso = Value
        End Set
    End Property

    Public Property CodUnidad() As String
        Get
            Return m_strCodUnidad
        End Get
        Set(ByVal Value As String)
            m_strCodUnidad = Value
        End Set
    End Property

    Public Property CodFamilia() As String
        Get
            Return m_strCodFamilia
        End Get
        Set(ByVal Value As String)
            m_strCodFamilia = Value
        End Set
    End Property

    Public Property CodMarca() As String
        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value
        End Set
    End Property

    Public Property CodLinea() As String
        Get
            Return m_strCodLinea
        End Get
        Set(ByVal Value As String)
            m_strCodLinea = Value
        End Set
    End Property

    Public Property Transito() As Decimal
        Get
            Return m_decTransito
        End Get
        Set(ByVal Value As Decimal)
            m_decTransito = Value
        End Set
    End Property

    Public Property Consignacion() As Decimal
        Get
            Return m_decConsignacion
        End Get
        Set(ByVal Value As Decimal)
            m_decConsignacion = Value
        End Set
    End Property

    Public Property VtasEspeciales() As Decimal
        Get
            Return m_decVtasEspeciales
        End Get
        Set(ByVal Value As Decimal)
            m_decVtasEspeciales = Value
        End Set
    End Property

    Public Property Promocion() As Decimal
        Get
            Return m_decPromocion
        End Get
        Set(ByVal Value As Decimal)
            m_decPromocion = Value
        End Set
    End Property

    Public Property Defectuosos() As Decimal
        Get
            Return m_decDefectuosos
        End Get
        Set(ByVal Value As Decimal)
            m_decDefectuosos = Value
        End Set
    End Property

    Public Property Apartados() As Decimal
        Get
            Return m_decApartados
        End Get
        Set(ByVal Value As Decimal)
            m_decApartados = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return m_decTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decTotal = Value
        End Set
    End Property

    Public Property NumeroMov() As Decimal
        Get
            Return m_decNumero
        End Get
        Set(ByVal Value As Decimal)
            m_decNumero = Value
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

    Public Property CodArticuloMov() As String
        Get
            Return m_strCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCodArticulo = Value
        End Set
    End Property

    Public Property Folio() As Integer
        Get
            Return m_intFolio
        End Get
        Set(ByVal Value As Integer)
            m_intFolio = Value
        End Set
    End Property

    Public Property Destino() As String
        Get
            Return m_strDestino
        End Get
        Set(ByVal Value As String)
            m_strDestino = Value
        End Set
    End Property

    Public Property CodAlmacenMov() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set
    End Property

    Public Property StatusMov() As String
        Get
            Return m_strStatusMov
        End Get
        Set(ByVal Value As String)
            m_strStatusMov = Value
        End Set
    End Property

    Public Property TipoMovimiento() As String
        Get
            Return m_strTipoMovimiento
        End Get
        Set(ByVal Value As String)
            m_strTipoMovimiento = Value
        End Set
    End Property

    Public Property CodTipoMov() As Integer
        Get
            Return m_intCodTipoMov
        End Get
        Set(ByVal Value As Integer)
            m_intCodTipoMov = Value
        End Set
    End Property

#End Region


#Region "Methods"

    Public Sub ClearFieldsMovimiento()

        m_intCodTipoMov = 0
        m_strTipoMovimiento = String.Empty
        m_strStatusMov = String.Empty
        m_strCodAlmacen = String.Empty
        m_strDestino = String.Empty
        m_intFolio = 0
        m_strCodArticulo = String.Empty
        m_strDescripcion = String.Empty
        m_decNumero = 0
        m_decTotal = 0
        m_decApartados = 0
        m_decDefectuosos = 0
        m_decPromocion = 0
        m_decVtasEspeciales = 0
        m_decConsignacion = 0
        m_decTransito = 0
        m_strCodLinea = String.Empty
        m_strCodMarca = String.Empty
        m_strCodFamilia = String.Empty
        m_strCodUnidad = String.Empty
        m_intCodUso = 0
        m_intCodCategoria = 0
        m_strUsuario = String.Empty
        m_decCostoUnit = 0
        m_decPrecioUnit = 0
        m_strFolioControl = String.Empty
        m_strCodCaja = String.Empty

    End Sub

#End Region


End Class
