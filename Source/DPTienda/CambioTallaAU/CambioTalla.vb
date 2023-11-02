Imports DportenisPro.DPTienda.Core

Public Class CambioTalla

    Inherits CambioTallaMovimiento

#Region "Environment Var"

    Private m_intID As Integer
    Private m_strCodAlmacen As String
    Private m_strCodCaja As String
    Private m_intFactura As Integer
    Private m_strCodArticuloAnt As String
    Private m_strNumeroAnt As String
    Private m_decCantidadAnt As Decimal
    Private m_strCodArticuloNvo As String
    Private m_decNumeroNvo As Decimal
    Private m_decCantidadNvo As Decimal
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatusRegistro As Boolean

    Private oMovimiento As New CambioTallaMovimiento

    Public Event CodAlmacenChanged As EventHandler
    Public Event CodCajaChanged As EventHandler
    Public Event FacturaChanged As EventHandler
    Public Event CodArticuloAntChanged As EventHandler
    Public Event NumeroAntChanged As EventHandler
    Public Event CantidadAntChanged As EventHandler
    Public Event CodArticuloNvoChanged As EventHandler
    Public Event NumeroNvoChanged As EventHandler
    Public Event CantidadNvoChanged As EventHandler

#End Region

    Private oParent As CambioTallaManager

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

#Region "Fields"

    Public Property ID() As Integer
        Get
            Return m_intID
        End Get
        Set(ByVal Value As Integer)
            m_intID = Value
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value

            Me.SetFlagDirty()
            RaiseEvent CodAlmacenChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value

            Me.SetFlagDirty()
            RaiseEvent CodCajaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Factura() As Integer
        Get
            Return m_intFactura
        End Get
        Set(ByVal Value As Integer)
            m_intFactura = Value

            Me.SetFlagDirty()
            RaiseEvent FacturaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property CodArticuloAnt() As String
        Get
            Return m_strCodArticuloAnt
        End Get
        Set(ByVal Value As String)
            m_strCodArticuloAnt = Value

            Me.SetFlagDirty()
            RaiseEvent CodArticuloAntChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NumeroAnt() As String
        Get
            Return m_strNumeroAnt
        End Get
        Set(ByVal Value As String)
            m_strNumeroAnt = Value

            Me.SetFlagDirty()
            RaiseEvent NumeroAntChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property CantidadAnt() As Decimal
        Get
            Return m_decCantidadAnt
        End Get
        Set(ByVal Value As Decimal)
            m_decCantidadAnt = Value

            Me.SetFlagDirty()
            RaiseEvent CantidadAntChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property CodArticuloNvo() As String
        Get
            Return m_strCodArticuloNvo
        End Get
        Set(ByVal Value As String)
            m_strCodArticuloNvo = Value

            Me.SetFlagDirty()
            RaiseEvent CodArticuloNvoChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NumeroNvo() As Decimal
        Get
            Return m_decNumeroNvo
        End Get
        Set(ByVal Value As Decimal)
            m_decNumeroNvo = Value

            Me.SetFlagDirty()
            RaiseEvent NumeroNvoChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property CantidadNvo() As Decimal
        Get
            Return m_decCantidadNvo
        End Get
        Set(ByVal Value As Decimal)
            m_decCantidadNvo = Value

            Me.SetFlagDirty()
            RaiseEvent CantidadNvoChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As Date)
            m_datFecha = Value
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
        End Set
    End Property

    Public Property Movimiento() As CambioTallaMovimiento
        Get
            Return oMovimiento
        End Get
        Set(ByVal Value As CambioTallaMovimiento)
            oMovimiento = Value
        End Set
    End Property


#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CambioTallaManager)

        MyBase.New()

        oParent = Parent

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intID = 0
        m_strCodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen()
        m_strCodCaja = String.Empty
        m_intFactura = 0
        m_strCodArticuloAnt = String.Empty
        m_strNumeroAnt = 0
        m_decCantidadAnt = 0
        m_strCodArticuloNvo = String.Empty
        m_decNumeroNvo = 0
        m_decCantidadNvo = 0
        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name
        m_datFecha = Date.Today
        m_bStatusRegistro = False

        oMovimiento.ClearFieldsMovimiento()

        'SetFlagNew()
        'ResetFlagDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        oParent.Delete(ID)

    End Sub

    Public Function [Select](ByVal ID As Integer) As CambioTalla

        Return oParent.Load(ID)

    End Function

#End Region

End Class

