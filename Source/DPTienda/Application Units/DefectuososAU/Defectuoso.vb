
Option Explicit On 

Imports DportenisPro.DPTienda.Core

Public Class Defectuoso

    Inherits DefectuososMovimientos

    Private m_strFolioSAP As String = "0"

    Private m_strFIDOCUMENT As String

    Private m_strObservaciones As String

    Private m_intFolioMovimiento As Integer

    Private m_datFecha_Tras As Date

    Private m_strFolio_Tras As String

    Private m_datFecha_Desm As Date

    Private m_decCosto As Decimal

    '---------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 11/06/2015: Bloqueo de Artículos de Baja Calidad
    '---------------------------------------------------------------------------------------------------------------------
    Private m_BloqueadoEcommerce As Boolean = False
    Private m_BloqueadoSiHay As Boolean = False

    '---------------------------------------------------------------------------------------------------------------------
    ' JNAVA (13.02.2016): Saber si se marcara o se desmarcara
    '---------------------------------------------------------------------------------------------------------------------
    Private m_Marcar As Boolean = True


#Region "Environment Var"

    Private oParent As DefectuososManager
    Private oMovimiento As New DefectuososMovimientos

    Private m_intID As Integer
    Private m_strCodAlmacen As String
    Private m_strCodCaja As String
    Private m_intFacturaID As Integer
    Private m_intFolioFactura As Integer
    Private m_strCodArticulo As String
    Private m_decNumero As String
    Private m_decCantidad As Decimal
    Private m_strDefectoNota As String
    Private m_strAutorizo As String

    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatus As Boolean

#End Region


#Region "Events"

    Public Event DefectuosoIDChanged As EventHandler
    Public Event CodAlmacenChanged As EventHandler
    Public Event CodCajaChanged As EventHandler
    Public Event FacturaIDChanged As EventHandler
    Public Event FolioFacturaChanged As EventHandler
    Public Event CodArticuloChanged As EventHandler
    Public Event NumeroChanged As EventHandler
    Public Event CantidadChanged As EventHandler
    Public Event DefectoNotaChanged As EventHandler
    Public Event AutorizoChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event StatusChanged As EventHandler
    Public Event FolioSAPChanged As EventHandler

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

    Public Sub SetFlagNew()
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

            Me.SetFlagDirty()

            RaiseEvent DefectuosoIDChanged(Me, New EventArgs)

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


    Public Property FacturaID() As Integer
        Get
            Return m_intFacturaID
        End Get
        Set(ByVal Value As Integer)
            m_intFacturaID = Value

            Me.SetFlagDirty()

            RaiseEvent FacturaIDChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property FolioFactura() As Integer
        Get
            Return m_intFolioFactura
        End Get
        Set(ByVal Value As Integer)
            m_intFolioFactura = Value

            Me.SetFlagDirty()

            RaiseEvent FolioFacturaChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property CodArticulo() As String
        Get
            Return m_strCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCodArticulo = Value

            Me.SetFlagDirty()

            RaiseEvent CodArticuloChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property Numero() As String
        Get
            Return m_decNumero
        End Get
        Set(ByVal Value As String)
            m_decNumero = Value

            Me.SetFlagDirty()

            RaiseEvent NumeroChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property Cantidad() As Decimal
        Get
            Return m_decCantidad
        End Get
        Set(ByVal Value As Decimal)
            m_decCantidad = Value

            RaiseEvent AutorizoChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property DefectoNota() As String
        Get
            Return m_strDefectoNota
        End Get
        Set(ByVal Value As String)
            m_strDefectoNota = Value

            Me.SetFlagDirty()

            RaiseEvent DefectoNotaChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property Autorizo() As String
        Get
            Return m_strAutorizo
        End Get
        Set(ByVal Value As String)
            m_strAutorizo = Value

            Me.SetFlagDirty()

            RaiseEvent AutorizoChanged(Me, New EventArgs)

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

            RaiseEvent FechaChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property Status() As Boolean
        Get
            Return m_bStatus
        End Get
        Set(ByVal Value As Boolean)
            m_bStatus = Value

            Me.SetFlagDirty()

            RaiseEvent StatusChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Movimiento() As DefectuososMovimientos
        Get
            Return oMovimiento
        End Get
        Set(ByVal Value As DefectuososMovimientos)
            oMovimiento = Value
        End Set
    End Property

    Public Property Marcar() As Boolean
        Get
            Return m_Marcar
        End Get
        Set(ByVal Value As Boolean)
            m_Marcar = Value
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As DefectuososManager)

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

        m_intID = 0
        m_strCodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen()
        m_strCodCaja = String.Empty
        m_intFacturaID = 0
        m_intFolioFactura = 0
        m_strCodArticulo = String.Empty
        m_decNumero = 0
        m_strDefectoNota = String.Empty
        m_strAutorizo = String.Empty

        m_strUsuario = String.Empty
        m_strAutorizo = String.Empty
        m_datFecha = Date.Now
        m_bStatus = True

        SetFlagNew()
        ResetFlagDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        oParent.Delete(ID)

    End Sub

    Public Function [Select](ByVal ID As Integer) As Defectuoso

        Return oParent.Load(ID)

    End Function

#End Region


    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 11/06/2015: Bloqueo de Artículos de Baja Calidad
    '---------------------------------------------------------------------------------------------------------------------------

    Public Property BloqueadoEcommerce() As Boolean
        Get
            Return m_BloqueadoEcommerce
        End Get
        Set(ByVal Value As Boolean)
            m_BloqueadoEcommerce = Value
        End Set
    End Property

    Public Property BloqueadoSiHay() As Boolean
        Get
            Return m_BloqueadoSiHay
        End Get
        Set(ByVal Value As Boolean)
            m_BloqueadoSiHay = Value
        End Set
    End Property

    Public Property Fecha_Desm() As Date
        Get
            Return m_datFecha_Desm
        End Get
        Set(ByVal Value As Date)
            m_datFecha_Desm = Value
        End Set
    End Property

    Public Property Folio_Tras() As String
        Get
            Return m_strFolio_Tras
        End Get
        Set(ByVal Value As String)
            m_strFolio_Tras = Value
        End Set
    End Property

    Public Property Fecha_Tras() As Date
        Get
            Return m_datFecha_Tras
        End Get
        Set(ByVal Value As Date)
            m_datFecha_Tras = Value
        End Set
    End Property

    Public Property FolioMovimiento() As Integer
        Get
            Return m_intFolioMovimiento
        End Get
        Set(ByVal Value As Integer)
            m_intFolioMovimiento = Value
        End Set
    End Property

    Public Property FIDOCUMENT() As String
        Get
            Return m_strFIDOCUMENT
        End Get
        Set(ByVal Value As String)
            m_strFIDOCUMENT = Value.PadLeft(10, "0")
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return m_strObservaciones
        End Get
        Set(ByVal Value As String)
            m_strObservaciones = Value
        End Set
    End Property


    Public Property FolioSAP() As String
        Get
            Return m_strFolioSAP
        End Get
        Set(ByVal Value As String)
            m_strFolioSAP = Value

            Me.SetFlagDirty()

            RaiseEvent FolioSAPChanged(Me, New EventArgs)

        End Set
    End Property

End Class
