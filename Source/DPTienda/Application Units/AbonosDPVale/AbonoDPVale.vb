Public Class AbonoDPVale









    Private oParent As AbonosDPValeManager

    Public Event IDAbonoChanged As EventHandler
    Public Event SaldNuevoChanged As EventHandler
    Public Event MontoPagoChanged As EventHandler
    Public Event PagoMinChanged As EventHandler
    Public Event SaldoAntChanged As EventHandler
    Public Event CodTipAbonoChanged As EventHandler
    Public Event CodSegCredChanged As EventHandler
    Public Event IDAsociadoChanged As EventHandler
    Public Event IDClienteChanged As EventHandler
    Public Event SaldoDPValeChanged As EventHandler
    Public Event AsociadoIDChanged As EventHandler


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

#Region "Fields"

    Private m_strReferencia As String
    Private m_strPlazaConsecutivo As String
    Private m_bStatusRegistro As Boolean
    Private m_datFecha As Date
    Private m_strUsuario As String
    Private m_dblSaldNuevo As Double
    Private m_dblMontoPago As Double
    Private m_dblPagoMin As Double
    Private m_dblSaldoAnt As Double
    Private m_intCodTipAbono As Integer
    Private m_strCodSegCred As String
    Private m_strIDCliente As String
    Private m_strCodCaja As String
    Private m_strCodAlmacen As String
    Private m_intIDAbono As Integer
    Private m_dsDetalle As DataSet
    Private m_decSaldoDPVale As Decimal
    Private m_strAsociadoID As String
    Private m_dblBonificacion As Double


    Public Property IDAbono() As Integer
        Get
            Return m_intIDAbono
        End Get
        Set(ByVal Value As Integer)
            m_intIDAbono = Value
            SetStateDirty()
            RaiseEvent IDAbonoChanged(Me, New EventArgs)
        End Set
    End Property

    Public ReadOnly Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
    End Property

    Public Sub SetCodAlmacen(ByVal Value As String)
        m_strCodAlmacen = Value
        SetStateDirty()
    End Sub

    Public ReadOnly Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
    End Property

    Public Sub SetCodCaja(ByVal Value As String)
        m_strCodCaja = Value
        SetStateDirty()
    End Sub


    Public Property IDCliente() As String
        Get
            Return m_strIDCliente
        End Get
        Set(ByVal Value As String)
            m_strIDCliente = Value
            SetStateDirty()
            RaiseEvent IDClienteChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodSegCred() As String
        Get
            Return m_strCodSegCred
        End Get
        Set(ByVal Value As String)
            m_strCodSegCred = Value
            SetStateDirty()
            RaiseEvent CodSegCredChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CodTipAbono() As Integer
        Get
            Return m_intCodTipAbono
        End Get
        Set(ByVal Value As Integer)
            m_intCodTipAbono = Value
            SetStateDirty()
            RaiseEvent CodTipAbonoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoAnt() As Double
        Get
            Return m_dblSaldoAnt
        End Get
        Set(ByVal Value As Double)
            m_dblSaldoAnt = Value
            SetStateDirty()
            RaiseEvent SaldoAntChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property PagoMin() As Double
        Get
            Return m_dblPagoMin
        End Get
        Set(ByVal Value As Double)
            m_dblPagoMin = Value
            SetStateDirty()
            RaiseEvent PagoMinChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property MontoPago() As Double
        Get
            Return m_dblMontoPago
        End Get
        Set(ByVal Value As Double)
            m_dblMontoPago = Value
            SetStateDirty()
            RaiseEvent MontoPagoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldNuevo() As Double
        Get
            Return m_dblSaldNuevo
        End Get
        Set(ByVal Value As Double)
            m_dblSaldNuevo = Value
            SetStateDirty()
            RaiseEvent SaldNuevoChanged(Me, New EventArgs)
        End Set
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
    End Property

    Public Sub SetUsuario(ByVal Value As String)
        m_strUsuario = Value
        SetStateDirty()
    End Sub



    Public Sub SetFecha(ByVal Value As Date)
        m_datFecha = Value
        SetStateDirty()
    End Sub

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
        End Set
    End Property

    Public Property Detalle() As DataSet
        Get
            Return m_dsDetalle
        End Get
        Set(ByVal Value As DataSet)
            m_dsDetalle = Value
        End Set
    End Property

    Public Property SaldoDPVale() As Decimal
        Get
            Return m_decSaldoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoDPVale = Value
        End Set
    End Property

    Public Property AsociadoID() As String
        Get
            Return m_strAsociadoID
        End Get
        Set(ByVal Value As String)
            m_strAsociadoID = Value
        End Set
    End Property

    Public Property PlazaConsecutivo() As String
        Get
            Return m_strPlazaConsecutivo
        End Get
        Set(ByVal Value As String)
            m_strPlazaConsecutivo = Value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_strReferencia
        End Get
        Set(ByVal Value As String)
            m_strReferencia = Value
        End Set
    End Property

#End Region

#Region "Constructors"

    Friend Sub New(ByVal Parent As AbonosDPValeManager)

        oParent = Parent

        Me.Clear()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oParent = Nothing
    End Sub

#End Region

#Region "Methods"

    Friend Sub Clear()

        m_bStatusRegistro = False
        m_datFecha = Date.Today
        m_strUsuario = String.Empty
        m_dblSaldNuevo = 0
        m_dblMontoPago = 0
        m_dblPagoMin = 0
        m_dblSaldoAnt = 0
        m_intCodTipAbono = 0
        m_strCodSegCred = String.Empty
        m_strIDCliente = String.Empty
        m_strAsociadoID = String.Empty
        m_strCodCaja = String.Empty
        m_strCodAlmacen = String.Empty
        m_intIDAbono = 0
        Detalle = New DataSet
        m_dblBonificacion = 0

        SetStateNew()
        ResetStateDirty()

    End Sub

    Public Sub Save()

        'oParent.Save(Me)

    End Sub

#End Region



    Public Property Bonificacion() As Double
        Get
            Return m_dblBonificacion
        End Get
        Set(ByVal Value As Double)
            m_dblBonificacion = Value
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

End Class
