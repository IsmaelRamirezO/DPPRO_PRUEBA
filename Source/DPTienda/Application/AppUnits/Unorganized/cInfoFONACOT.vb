Public Class cInfoFONACOT
    Private dcCapital As Decimal
    Private dcInteres As Decimal
    Private dcComision As Decimal
    Private dcCredito As Decimal
    Private dcPagoMensual As Decimal
    Private strIdentificacion As String
    Private strExpedidapor As String
    Private strNumIdentificacion As String
    Private strAnioExpedicion As String

    Public Property Capital() As Decimal
        Get
            Return dcCapital
        End Get
        Set(ByVal Value As Decimal)
            dcCapital = Value
        End Set
    End Property

    Public Property Interes() As Decimal
        Get
            Return dcInteres
        End Get
        Set(ByVal Value As Decimal)
            dcInteres = Value
        End Set
    End Property

    Public Property Comision() As Decimal
        Get
            Return dcComision
        End Get
        Set(ByVal Value As Decimal)
            dcComision = Value
        End Set
    End Property

    Public Property Credito() As Decimal
        Get
            Return dcCredito
        End Get
        Set(ByVal Value As Decimal)
            dcCredito = Value
        End Set
    End Property

    Public Property PagoMensual() As Decimal
        Get
            Return dcPagoMensual
        End Get
        Set(ByVal Value As Decimal)
            dcPagoMensual = Value
        End Set
    End Property

    Public Property Identificacion() As String
        Get
            Return strIdentificacion
        End Get
        Set(ByVal Value As String)
            strIdentificacion = Value
        End Set
    End Property

    Public Property Expedidapor() As String
        Get
            Return strExpedidapor
        End Get
        Set(ByVal Value As String)
            strExpedidapor = Value
        End Set
    End Property

    Public Property NumIdentificacion() As String
        Get
            Return strNumIdentificacion
        End Get
        Set(ByVal Value As String)
            strNumIdentificacion = Value
        End Set
    End Property

    Public Property AnioExpedicion() As String
        Get
            Return strAnioExpedicion
        End Get
        Set(ByVal Value As String)
            strAnioExpedicion = Value
        End Set
    End Property

    Public Sub Limpiar()
        dcCapital = 0
        dcInteres = 0
        dcComision = 0
        dcCredito = 0
        dcPagoMensual = 0
        strIdentificacion = String.Empty
        strExpedidapor = String.Empty
        strNumIdentificacion = String.Empty
        strAnioExpedicion = String.Empty
    End Sub

    Public Sub New()
        Limpiar()
    End Sub

End Class
