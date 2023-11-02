Public Class cDPValeSAP

#Region "Variables"

    'Private m_datFechaCobro As Date = Nothing
    'ASANCHEZ 09/06/2021 se cambio para que tome la fecha actual
    Private m_datFechaCobro As Date = New Date()
    Private strIDAsociado As String = String.Empty
    Private strNombreAsociado As String = String.Empty
    Private strIDCliente As String = String.Empty
    Private strNombreCliente As String = String.Empty
    Private strIDDPVale As String = String.Empty
    Private datFechaCreacion As Date
    Private datFechaInicial As Date
    Private datFechaExpedicion As Date
    Private decMontoUtilizado As Decimal = 0
    Private strUsuario As String = String.Empty
    Private strTipoVenta As String = String.Empty
    Private decTotalFactura As Decimal = 0
    Private decEBPago As Decimal = 0
    Private intParesPzas As Integer = 0
    Private decMONTODPVALE As Decimal = 0
    Private intNUMDE As Integer = 0
    Private bolREVALE As Boolean = False
    Private decRMONTODPVALE As Decimal = 0
    Private intRPARES_PZAS As Integer = 0
    Private dtInfoDPVALE As DataTable
    Private strPlaza As String = String.Empty
    Private decLimiteCredito As Decimal = 0
    Private strCongelado As String = String.Empty
    Private bolIsReReVale As Boolean = False
    Private bolIsReVale As Boolean = False
    '-------------------------------------------------------------------------------------------------
    'FLIZARRAGA 18/08/2017: Se agregan los valores y configuraciones para el vale electronico
    '-------------------------------------------------------------------------------------------------
    Private m_ValeElectronico As Boolean = False
    Private m_MontoElectronico As Decimal = 0
    Private m_EsCalzado As Boolean = False
    Private m_PromocionValeElectronico As Integer

#End Region

#Region "Fields Accessors"

    Public Property FechaCobro() As Date
        Get
            Return m_datFechaCobro
        End Get
        Set(ByVal Value As Date)
            m_datFechaCobro = Value
        End Set
    End Property

    Public Property LimiteCredito() As Decimal
        Get
            Return decLimiteCredito
        End Get
        Set(ByVal Value As Decimal)
            decLimiteCredito = Value
        End Set
    End Property

    Public Property IDAsociado() As String
        Get
            Return strIDAsociado
        End Get
        Set(ByVal Value As String)
            strIDAsociado = Value
        End Set
    End Property

    Public Property NombreAsociado() As String
        Get
            Return strNombreAsociado
        End Get
        Set(ByVal Value As String)
            strNombreAsociado = Value
        End Set
    End Property

    Public Property IDCliente() As String
        Get
            Return strIDCliente
        End Get
        Set(ByVal Value As String)
            strIDCliente = Value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return strNombreCliente
        End Get
        Set(ByVal Value As String)
            strNombreCliente = Value
        End Set
    End Property

    Public Property IDDPVale() As String
        Get
            Return strIDDPVale
        End Get
        Set(ByVal Value As String)
            strIDDPVale = Value
        End Set
    End Property

    Public Property FechaCreacion() As Date
        Get
            Return datFechaCreacion
        End Get
        Set(ByVal Value As Date)
            datFechaCreacion = Value
        End Set
    End Property

    Public Property FechaInicial() As Date
        Get
            Return datFechaInicial
        End Get
        Set(ByVal Value As Date)
            datFechaInicial = Value
        End Set
    End Property

    Public Property FechaExpedicion() As Date
        Get
            Return datFechaExpedicion
        End Get
        Set(ByVal Value As Date)
            datFechaExpedicion = Value
        End Set
    End Property

    Public Property MontoUtilizado() As Decimal
        Get
            Return decMontoUtilizado
        End Get
        Set(ByVal Value As Decimal)
            decMontoUtilizado = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return strUsuario
        End Get
        Set(ByVal Value As String)
            strUsuario = Value
        End Set
    End Property

    Public Property TipoVenta() As String
        Get
            Return strTipoVenta
        End Get
        Set(ByVal Value As String)
            strTipoVenta = Value
        End Set
    End Property

    Public Property TotalFactura() As Decimal
        Get
            Return decTotalFactura
        End Get
        Set(ByVal Value As Decimal)
            decTotalFactura = Value
        End Set
    End Property

    Public Property EBPago() As Decimal
        Get
            Return decEBPago
        End Get
        Set(ByVal Value As Decimal)
            decEBPago = Value
        End Set
    End Property

    Public Property ParesPzas() As Integer
        Get
            Return intParesPzas
        End Get
        Set(ByVal Value As Integer)
            intParesPzas = Value
        End Set
    End Property

    Public Property MONTODPVALE() As Decimal
        Get
            Return decMONTODPVALE
        End Get
        Set(ByVal Value As Decimal)
            decMONTODPVALE = Value
        End Set
    End Property

    Public Property NUMDE() As Integer
        Get
            Return intNUMDE
        End Get
        Set(ByVal Value As Integer)
            intNUMDE = Value
        End Set
    End Property

    Public Property REVALE() As Boolean
        Get
            Return bolREVALE
        End Get
        Set(ByVal Value As Boolean)
            bolREVALE = Value
        End Set
    End Property

    Public Property RMONTODPVALE() As Decimal
        Get
            Return decRMONTODPVALE
        End Get
        Set(ByVal Value As Decimal)
            decRMONTODPVALE = Value
        End Set
    End Property

    Public Property RPARES_PZAS() As Integer
        Get
            Return intRPARES_PZAS
        End Get
        Set(ByVal Value As Integer)
            intRPARES_PZAS = Value
        End Set
    End Property

    Public Property InfoDPVALE() As DataTable
        Get
            Return dtInfoDPVALE
        End Get
        Set(ByVal Value As DataTable)
            dtInfoDPVALE = Value
        End Set
    End Property


    Public Property Plaza() As String
        Get
            Return strPlaza
        End Get
        Set(ByVal Value As String)
            strPlaza = Value
        End Set
    End Property

    Public Property Congelado() As String
        Get
            Return strCongelado
        End Get
        Set(ByVal Value As String)
            strCongelado = Value
        End Set
    End Property

    Public Property IsRevale() As Boolean
        Get
            Return bolIsRevale
        End Get
        Set(ByVal Value As Boolean)
            bolIsRevale = Value
        End Set
    End Property

    Public Property IsReRevale() As Boolean
        Get
            Return bolIsReRevale
        End Get
        Set(ByVal Value As Boolean)
            bolIsReRevale = Value
        End Set
    End Property

    Public Property ValeElectronico As Boolean
        Get
            Return m_ValeElectronico
        End Get
        Set(ByVal value As Boolean)
            m_ValeElectronico = value
        End Set
    End Property

    Public Property MontoElectronico As Decimal
        Get
            Return m_MontoElectronico
        End Get
        Set(ByVal value As Decimal)
            m_MontoElectronico = value
        End Set
    End Property

    Public Property EsCalzado As Boolean
        Get
            Return m_EsCalzado
        End Get
        Set(ByVal value As Boolean)
            m_EsCalzado = value
        End Set
    End Property

    Public Property PromocionValeElectronico As Integer
        Get
            Return m_PromocionValeElectronico
        End Get
        Set(ByVal value As Integer)
            m_PromocionValeElectronico = value
        End Set
    End Property


#End Region

#Region "S2Credit"

#Region "Variables"

    '------------------------------------------------------------
    ' JNAVA (04.04.2017): ID de la Promocion en S2Credit
    '------------------------------------------------------------
    Dim strPromocionID As String = String.Empty
    '------------------------------------------------------------

#End Region

#Region "Propiedades"

    Public Property PromocionID() As String
        Get
            Return strPromocionID
        End Get
        Set(ByVal Value As String)
            strPromocionID = Value
        End Set
    End Property

#End Region

#End Region

End Class
