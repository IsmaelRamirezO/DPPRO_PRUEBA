Public Class PeriodoDetalle

    Private m_bLiquidado As Boolean

    Private m_decPagoMinimo As Decimal

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

    Public Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Fields"


    Private m_bStatusRegistro As Boolean
    Private m_datFecha As Date
    Private m_strUsuario As String
    Private m_datFechaPago As Date
    Private m_datFechaFinal As Date
    Private m_datFechaInicial As Date
    Private m_intNumPeriodo As Integer
    Private m_intAnno As Integer
    Private m_intPeriodoID As Integer
    Private m_intPeriodoDetalleID As Integer


    Public Event PeriodoDetalleIDChanged As EventHandler
    Public Event PeriodoIDChanged As EventHandler
    Public Event AnnoChanged As EventHandler
    Public Event NumPeriodoChanged As EventHandler
    Public Event FechaInicialChanged As EventHandler
    Public Event FechaFinalChanged As EventHandler
    Public Event FechaPagoChanged As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event StatusRegistroChanged As EventHandler


    Private oParent As PeriodoDetalleManager



    Public Property PeriodoDetalleID() As Integer
        Get
            Return m_intPeriodoDetalleID
        End Get
        Set(ByVal Value As Integer)
            m_intPeriodoDetalleID = Value
        End Set
    End Property
    Public Property PeriodoID() As Integer
        Get
            Return m_intPeriodoID
        End Get
        Set(ByVal Value As Integer)
            m_intPeriodoID = Value
        End Set
    End Property
    Public Property Anno() As Integer
        Get
            Return m_intAnno
        End Get
        Set(ByVal Value As Integer)
            m_intAnno = Value
        End Set
    End Property
    Public Property NumPeriodo() As Integer
        Get
            Return m_intNumPeriodo
        End Get
        Set(ByVal Value As Integer)
            m_intNumPeriodo = Value
        End Set
    End Property
    Public Property FechaInicial() As Date
        Get
            Return m_datFechaInicial
        End Get
        Set(ByVal Value As Date)
            m_datFechaInicial = Value
        End Set
    End Property
    Public Property FechaFinal() As Date
        Get
            Return m_datFechaFinal
        End Get
        Set(ByVal Value As Date)
            m_datFechaFinal = Value
        End Set
    End Property
    Public Property FechaPago() As Date
        Get
            Return m_datFechaPago
        End Get
        Set(ByVal Value As Date)
            m_datFechaPago = Value
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


#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As PeriodoDetalleManager)

        oParent = Parent

        Clear()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Shadows Sub Clear()

        m_bStatusRegistro = False
        m_datFecha = Date.Now
        m_strUsuario = String.Empty
        m_intAnno = 0
        m_datFechaInicial = Date.Now
        m_datFechaFinal = Date.Now
        m_datFechaPago = Date.Now
        m_intNumPeriodo = 0
        m_intPeriodoID = 0


        SetFlagNew()
        ResetFlagDirty()


    End Sub

    Public Sub Save()

        oParent.Save(Me)

    End Sub

    Public Sub Delete()

        oParent.Delete(Me.PeriodoID)

    End Sub

    Public Sub Liquidar(ByVal AsociadoID As Integer)

        oParent.Liquidar(Me.NumPeriodo, Me.Liquidado, Me.PagoMinimo, AsociadoID)

    End Sub

#End Region


    Public Property PagoMinimo() As Decimal
        Get
            Return m_decPagoMinimo
        End Get
        Set(ByVal Value As Decimal)
            m_decPagoMinimo = Value
        End Set
    End Property

    Public Property Liquidado() As Boolean
        Get
            Return m_bLiquidado
        End Get
        Set(ByVal Value As Boolean)
            m_bLiquidado = Value
        End Set
    End Property

End Class
