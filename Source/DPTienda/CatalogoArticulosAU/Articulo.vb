Imports System.IO
Public Class Articulo



    Private oParent As CatalogoArticuloManager

#Region "Object Status Flags"

    Private bolWithImage As Boolean
    Private bolWithImageAlter As Boolean
    Private bolIsDirty As Boolean
    Private bolIsNew As Boolean
    Private bolExist As Boolean

    Public Function Exist() As Boolean
        Return bolExist
    End Function

    Public Function WithImage() As Boolean
        Return bolWithImage
    End Function

    Public Function WithImageAlter() As Boolean
        Return bolWithImageAlter
    End Function

    Public Function IsDirty() As Boolean
        Return bolIsDirty
    End Function

    Public Function IsNew() As Boolean
        Return bolIsNew
    End Function

    Friend Sub SetExist()
        bolExist = True
    End Sub

    Friend Sub SetWithImage()
        bolWithImage = True
    End Sub

    Friend Sub SetWithImageAlter()
        bolWithImageAlter = True
    End Sub

    Friend Sub SetFlagDirty()
        bolIsDirty = True
    End Sub

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetExist()
        bolExist = False
    End Sub

    Friend Sub ResetWithImage()
        bolWithImage = False
    End Sub

    Friend Sub ResetWithImageAlter()
        bolWithImageAlter = False
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Fields"

#Region "Fields Storage"

    Private m_strCodArticulo As String
    Private m_strCodArtProv As String
    Private m_strDescripcion As String
    Private m_strCodlinea As String
    Private m_strCodCorrida As String
    Private m_intCodCategoria As String
    Private m_strCodFamilia As String
    Private m_strCodUso As String
    Private m_strCodMarca As String
    Private m_decCostoProm As Decimal
    Private m_decMargenUtilidad As Decimal
    Private m_decPrecioVenta As Decimal
    Private m_decDescuento As Decimal
    Private m_decPrecioOferta As Decimal
    Private m_datFechaOferta As Date
    Private m_strCodUnidadCom As String
    Private m_strCodUnidadVta As String
    Private m_intCodMonedaCom As Integer
    Private m_intCodMonedaVta As Integer
    Private m_bImpCodBarra As Boolean
    Private m_strJerarquia As String
    Private m_bolDip As Boolean
    Private m_strCodigoAnterior As String

    Private m_stmImagen As MemoryStream
    Private m_stmImagenAlter As MemoryStream
    Private m_decPrecioSocio As Decimal
    Private m_decPrecioIva As Decimal


    Private m_DescCodCategoria As String
    Private m_DescCodFamilia As String
    Private m_DescCodUso As String
    Private m_DescCodMarca As String
    Private m_DescCodCorrida As String
    Private m_DescCodLinea As String

    '----------------------------------------------
    'JNAVA (3.12.2014): Venta de electronicos
    '----------------------------------------------
    Private m_strCodElectronico As String

#End Region

#Region "Fields Events"

    'Define Chenge Event
    Public Event CodArticuloChanged As EventHandler
    Public Event CodArtProvChanged As EventHandler
    Public Event DescripcionChanged As EventHandler
    Public Event CodlineaChanged As EventHandler
    Public Event CodCorridaChanged As EventHandler
    Public Event CodCategoriaChanged As EventHandler
    Public Event CodFamiliaChanged As EventHandler
    Public Event CodUsoChanged As EventHandler
    Public Event CodMarcaChanged As EventHandler
    Public Event CostoPromChanged As EventHandler
    Public Event MargenUtilidadChanged As EventHandler
    Public Event PrecioVentaChanged As EventHandler
    Public Event DescuentoChanged As EventHandler
    Public Event PrecioOfertaChanged As EventHandler
    Public Event FechaOfertaChanged As EventHandler
    Public Event CodUnidadComChanged As EventHandler
    Public Event CodUnidadVtaChanged As EventHandler
    Public Event CodMonedaComChanged As EventHandler
    Public Event CodMonedaVtaChanged As EventHandler
    Public Event ImpCodBarraChanged As EventHandler
    Public Event JerarquiaChanged As EventHandler
    Public Event DipChanged As EventHandler
    Public Event PrecioSocioChanged As EventHandler
    Public Event PrecioIvaChanged As EventHandler

    Public Event DescCodCategoriaChanged As EventHandler
    Public Event DescCodFamiliaChanged As EventHandler
    Public Event DescCodUsoChanged As EventHandler
    Public Event DescCodMarcaChanged As EventHandler
    Public Event DescCodCorridaChanged As EventHandler
    Public Event DescCodLineaChanged As EventHandler


#End Region

#Region "Fields Accessors"

    Public Property DescCodLinea() As String

        Get
            Return m_DescCodLinea
        End Get
        Set(ByVal Value As String)
            m_DescCodLinea = Value
            SetFlagDirty()
            RaiseEvent DescCodLineaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property DescCodCorrida() As String

        Get
            Return m_DescCodCorrida
        End Get
        Set(ByVal Value As String)
            m_DescCodCorrida = Value
            SetFlagDirty()
            RaiseEvent DescCodCorridaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property DescCodMarca() As String

        Get
            Return m_DescCodMarca
        End Get
        Set(ByVal Value As String)
            m_DescCodMarca = Value
            SetFlagDirty()
            RaiseEvent DescCodMarcaChanged(Me, New EventArgs)
        End Set

    End Property


    Public Property DescCodUso() As String

        Get
            Return m_DescCodUso
        End Get
        Set(ByVal Value As String)
            m_DescCodUso = Value
            SetFlagDirty()
            RaiseEvent DescCodUsoChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property DescCodFamilia() As String

        Get
            Return m_DescCodFamilia
        End Get
        Set(ByVal Value As String)
            m_DescCodFamilia = Value
            SetFlagDirty()
            RaiseEvent DescCodFamiliaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property DescCodCategoria() As String

        Get
            Return m_DescCodCategoria
        End Get
        Set(ByVal Value As String)
            m_DescCodCategoria = Value
            SetFlagDirty()
            RaiseEvent DescCodCategoriaChanged(Me, New EventArgs)
        End Set

    End Property


    Public Property PrecioIva() As Decimal
        Get
            Return m_decPrecioIva
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecioIva = Value
            SetFlagDirty()
            RaiseEvent PrecioIvaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property PrecioSocio() As Decimal
        Get
            Return m_decPrecioSocio
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecioSocio = Value
            SetFlagDirty()
            RaiseEvent PrecioSocioChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Imagen() As MemoryStream

        Get
            Return m_stmImagen
        End Get
        Set(ByVal Value As MemoryStream)
            m_stmImagen = Value
            SetFlagDirty()
        End Set

    End Property

    Public Property ImagenAlter() As MemoryStream

        Get
            Return m_stmImagenAlter
        End Get
        Set(ByVal Value As MemoryStream)
            m_stmImagenAlter = Value
            SetFlagDirty()
        End Set

    End Property

    Public Property CodArticulo() As String

        Get
            Return m_strCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCodArticulo = Value
            SetFlagDirty()
            RaiseEvent CodArticuloChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodArtProv() As String

        Get
            Return m_strCodArtProv
        End Get
        Set(ByVal Value As String)
            m_strCodArtProv = Value
            SetFlagDirty()
            RaiseEvent CodArtProvChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property Descripcion() As String

        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
            SetFlagDirty()
            RaiseEvent DescripcionChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property Codlinea() As String

        Get
            Return m_strCodlinea
        End Get
        Set(ByVal Value As String)
            m_strCodlinea = Value
            SetFlagDirty()
            RaiseEvent CodlineaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodCorrida() As String

        Get
            Return m_strCodCorrida
        End Get
        Set(ByVal Value As String)
            m_strCodCorrida = Value
            SetFlagDirty()
            RaiseEvent CodCorridaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodCategoria() As Integer

        Get
            Return m_intCodCategoria
        End Get
        Set(ByVal Value As Integer)
            m_intCodCategoria = Value
            RaiseEvent CodCategoriaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodFamilia() As String

        Get
            Return m_strCodFamilia
        End Get
        Set(ByVal Value As String)
            m_strCodFamilia = Value
            SetFlagDirty()
            RaiseEvent CodFamiliaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodUso() As String
        Get
            Return m_strCodUso
        End Get
        Set(ByVal Value As String)
            m_strCodUso = Value
            RaiseEvent CodUsoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodMarca() As String

        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value
            SetFlagDirty()
            RaiseEvent CodMarcaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CostoProm() As Decimal

        Get
            Return m_decCostoProm
        End Get
        Set(ByVal Value As Decimal)
            m_decCostoProm = Value
            RaiseEvent CostoPromChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property MargenUtilidad() As Decimal

        Get
            Return m_decMargenUtilidad
        End Get
        Set(ByVal Value As Decimal)
            m_decMargenUtilidad = Value
            RaiseEvent MargenUtilidadChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property PrecioVenta() As Decimal

        Get
            Return m_decPrecioVenta
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecioVenta = Value
            RaiseEvent PrecioVentaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property Descuento() As Decimal

        Get
            Return m_decDescuento
        End Get
        Set(ByVal Value As Decimal)
            m_decDescuento = Value
            RaiseEvent DescuentoChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property PrecioOferta() As Decimal

        Get
            Return m_decPrecioOferta
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecioOferta = Value
            RaiseEvent PrecioOfertaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property FechaOferta() As Date

        Get
            Return m_datFechaOferta
        End Get
        Set(ByVal Value As Date)
            m_datFechaOferta = Value
            RaiseEvent FechaOfertaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodUnidadCom() As String

        Get
            Return m_strCodUnidadCom
        End Get
        Set(ByVal Value As String)
            m_strCodUnidadCom = Value
            SetFlagDirty()
            RaiseEvent CodUnidadComChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodUnidadVta() As String

        Get
            Return m_strCodUnidadVta
        End Get
        Set(ByVal Value As String)
            m_strCodUnidadVta = Value
            SetFlagDirty()
            RaiseEvent CodUnidadVtaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodMonedaCom() As Integer

        Get
            Return m_intCodMonedaCom
        End Get
        Set(ByVal Value As Integer)
            m_intCodMonedaCom = Value
            RaiseEvent CodMonedaComChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property CodMonedaVta() As Integer

        Get
            Return m_intCodMonedaVta
        End Get
        Set(ByVal Value As Integer)
            m_intCodMonedaVta = Value
            RaiseEvent CodMonedaVtaChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property ImpCodBarra() As Boolean

        Get
            Return m_bImpCodBarra
        End Get
        Set(ByVal Value As Boolean)
            m_bImpCodBarra = Value
            RaiseEvent ImpCodBarraChanged(Me, New EventArgs)
        End Set

    End Property

    Public Property Jerarquia() As String
        Get
            Return m_strJerarquia
        End Get
        Set(ByVal Value As String)
            m_strJerarquia = Value
            RaiseEvent JerarquiaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Dip() As Boolean
        Get
            Return m_bolDip
        End Get
        Set(ByVal Value As Boolean)
            m_bolDip = Value
            RaiseEvent DipChanged(Me, New EventArgs)
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

    Public Property CodElectronico() As String
        Get
            Return m_strCodElectronico
        End Get
        Set(ByVal Value As String)
            m_strCodElectronico = Value
        End Set
    End Property

#End Region

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoArticuloManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_strCodArticulo = String.Empty
        m_strCodArtProv = String.Empty
        m_strDescripcion = String.Empty
        m_strCodlinea = String.Empty
        m_strCodCorrida = String.Empty
        m_intCodCategoria = String.Empty
        m_strCodFamilia = String.Empty
        m_strCodUso = String.Empty
        m_strCodMarca = String.Empty
        m_decCostoProm = 0
        m_decMargenUtilidad = 0
        m_decPrecioVenta = 0
        m_decDescuento = 0
        m_decPrecioOferta = 0
        m_datFechaOferta = Date.Now
        m_strCodUnidadCom = String.Empty
        m_strCodUnidadVta = String.Empty
        m_intCodMonedaCom = 0
        m_intCodMonedaVta = 0
        m_bImpCodBarra = False
        m_strJerarquia = String.Empty
        m_bolDip = False
        m_strCodigoAnterior = String.Empty
        m_DescCodCategoria = String.Empty
        m_DescCodFamilia = String.Empty
        m_DescCodUso = String.Empty
        m_DescCodMarca = String.Empty
        m_DescCodCorrida = String.Empty
        m_decPrecioSocio = 0
        SetFlagNew()
        ResetFlagDirty()
        ResetWithImage()
        ResetWithImageAlter()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete()

        oParent.Delete(Me.CodArticulo)

    End Sub

#End Region




 

End Class
