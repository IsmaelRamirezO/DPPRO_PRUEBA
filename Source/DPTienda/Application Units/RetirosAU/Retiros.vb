Imports DportenisPro.DPTienda.Core

Public Class Retiros

    Private oParent As RetirosManager

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

    Private m_decCantidadRetiro As Decimal
    Private m_strReferencia As String
    Private m_intFicha As Integer
    Private m_strCodBanco As String
    Private m_strCodCaja As String
    Private m_strCodAlmacen As String
    Private m_intRetiroID As Integer

    Private m_bRecordEnabled As Boolean
    Private m_datRecordCreatedOn As Date
    Private m_strRecordCreatedBy As String


    Public Event CantidadRetiroChanged As EventHandler
    Public Event ReferenciaChanged As EventHandler
    Public Event FichaChanged As EventHandler
    Public Event CodBancoChanged As EventHandler
    Public Event CodCajaChanged As EventHandler
    Public Event CodAlmacenChanged As EventHandler
    Public Event RetiroIDChanged As EventHandler

    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordCreatedByChanged As EventHandler
    Public Event RecordEnabledChanged As EventHandler


    Public Property RetiroID() As Integer
        Get
            Return m_intRetiroID
        End Get
        Set(ByVal Value As Integer)
            m_intRetiroID = Value
            RaiseEvent RetiroIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
            RaiseEvent CodAlmacenChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
            RaiseEvent CodCajaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodBanco() As String
        Get
            Return m_strCodBanco
        End Get
        Set(ByVal Value As String)
            m_strCodBanco = Value
            RaiseEvent CodBancoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Ficha() As Integer
        Get
            Return m_intFicha
        End Get
        Set(ByVal Value As Integer)
            m_intFicha = Value
            RaiseEvent FichaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_strReferencia
        End Get
        Set(ByVal Value As String)
            m_strReferencia = Value
            RaiseEvent ReferenciaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CantidadRetiro() As Decimal
        Get
            Return m_decCantidadRetiro
        End Get
        Set(ByVal Value As Decimal)
            m_decCantidadRetiro = Value
            RaiseEvent CantidadRetiroChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            m_strRecordCreatedBy = Value

            RaiseEvent RecordCreatedByChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return m_datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            m_datRecordCreatedOn = Value

            RaiseEvent RecordCreatedOnChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

    Public Property RecordEnabled() As Boolean
        Get
            Return m_bRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            m_bRecordEnabled = Value

            RaiseEvent RecordEnabledChanged(Me, New EventArgs)
            SetFlagDirty()
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As RetirosManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Private Sub ClearFields()

        m_decCantidadRetiro = 0
        m_strReferencia = String.Empty
        m_intFicha = 0
        m_strCodBanco = String.Empty
        m_strCodCaja = String.Empty
        m_strCodAlmacen = String.Empty
        m_intRetiroID = 0
        ' m_datFecha = Date.Now

        m_bRecordEnabled = False
        m_datRecordCreatedOn = Date.Now
        'TODO: Asignar SessionLoginName del CurrentUser
        m_strRecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.ID

        SetFlagNew()
        ResetFlagDirty()

    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete()

        oParent.Delete(Me.RetiroID)

    End Sub

#End Region






End Class
