Public Class Periodos

    Private oParent As PeriodosManager

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
    Private m_intPorcLimPagoD5 As Integer
    Private m_intPorcLimPagoD4 As Integer
    Private m_intPorcLimPagoD3 As Integer
    Private m_intPorcLimPagoD2 As Integer
    Private m_intPorcLimPagoD1 As Integer
    Private m_intDiasCorte As Integer
    Private m_datDiaPago2 As Date
    Private m_datDiaPago1 As Date
    Private m_intFechaCorte2 As Integer
    Private m_intFechaCorte1 As Integer
    Private m_intNumDiasPeriodo As Integer
    Private m_intAnno As Integer
    Private m_intPeriodoID As Integer
    Private m_intNumPeriodos As Integer

    Public Event PeriodoIDChanged As EventHandler
    Public Event AnnoChanged As EventHandler
    Public Event NumDiasPeriodoChanged As EventHandler
    Public Event FechaCorte1Changed As EventHandler
    Public Event FechaCorte2Changed As EventHandler
    Public Event DiaPago1Changed As EventHandler
    Public Event DiaPago2Changed As EventHandler
    Public Event DiasCorteChanged As EventHandler
    Public Event PorcLimPagoD1Changed As EventHandler
    Public Event PorcLimPagoD2Changed As EventHandler
    Public Event PorcLimPagoD3Changed As EventHandler
    Public Event PorcLimPagoD4Changed As EventHandler
    Public Event PorcLimPagoD5Changed As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event NumPeriodosChanged As EventHandler


    Public Property PeriodoID() As Integer
        Get
            Return m_intPeriodoID
        End Get
        Set(ByVal Value As Integer)
            m_intPeriodoID = Value
        End Set
    End Property

    Public Property NumPeriodos() As Integer
        Get
            Return m_intNumPeriodos
        End Get
        Set(ByVal Value As Integer)
            m_intNumPeriodos = Value
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

    Public Property NumDiasPeriodo() As Integer
        Get
            Return m_intNumDiasPeriodo
        End Get
        Set(ByVal Value As Integer)
            m_intNumDiasPeriodo = Value
        End Set
    End Property

    Public Property FechaCorte1() As Integer
        Get
            Return m_intFechaCorte1
        End Get
        Set(ByVal Value As Integer)
            m_intFechaCorte1 = Value
        End Set
    End Property

    Public Property FechaCorte2() As Integer
        Get
            Return m_intFechaCorte2
        End Get
        Set(ByVal Value As Integer)
            m_intFechaCorte2 = Value
        End Set
    End Property

    Public Property DiaPago1() As Date
        Get
            Return m_datDiaPago1
        End Get
        Set(ByVal Value As Date)
            m_datDiaPago1 = Value
        End Set
    End Property

    Public Property DiaPago2() As Date
        Get
            Return m_datDiaPago2
        End Get
        Set(ByVal Value As Date)
            m_datDiaPago2 = Value
        End Set
    End Property

    Public Property DiasCorte() As Integer
        Get
            Return m_intDiasCorte
        End Get
        Set(ByVal Value As Integer)
            m_intDiasCorte = Value
        End Set
    End Property

    Public Property PorcLimPagoD1() As Integer
        Get
            Return m_intPorcLimPagoD1
        End Get
        Set(ByVal Value As Integer)
            m_intPorcLimPagoD1 = Value
        End Set
    End Property

    Public Property PorcLimPagoD2() As Integer
        Get
            Return m_intPorcLimPagoD2
        End Get
        Set(ByVal Value As Integer)
            m_intPorcLimPagoD2 = Value
        End Set
    End Property

    Public Property PorcLimPagoD3() As Integer
        Get
            Return m_intPorcLimPagoD3
        End Get
        Set(ByVal Value As Integer)
            m_intPorcLimPagoD3 = Value
        End Set
    End Property

    Public Property PorcLimPagoD4() As Integer
        Get
            Return m_intPorcLimPagoD4
        End Get
        Set(ByVal Value As Integer)
            m_intPorcLimPagoD4 = Value
        End Set
    End Property

    Public Property PorcLimPagoD5() As Integer
        Get
            Return m_intPorcLimPagoD5
        End Get
        Set(ByVal Value As Integer)
            m_intPorcLimPagoD5 = Value
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

    Friend Sub New(ByVal Parent As PeriodosManager)

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
        m_intPorcLimPagoD5 = 0
        m_intPorcLimPagoD4 = 0
        m_intPorcLimPagoD3 = 0
        m_intPorcLimPagoD2 = 0
        m_intPorcLimPagoD1 = 0
        m_intDiasCorte = 0
        m_datDiaPago2 = Date.Now
        m_datDiaPago1 = Date.Now
        m_intFechaCorte2 = 0
        m_intFechaCorte1 = 0
        m_intNumDiasPeriodo = 0
        m_intAnno = 0

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

#End Region
End Class
