Public Class TipoVentaFonacot
    Inherits TipoVentaBase

    Private oFormaPagoValeDeCaja As FormaPagoValeDeCaja
    Private oFormaPagoEfectivo As FormaPagoEfectivo
    Private oFormaPagoTarjetaDebito As FormaPagoTarjetaDebito
    Private oFormaPagoTarjetaCredito As FormaPagoTarjetaCredito
    Private oFormaPagoFonacot As FormaPagoFonacot

    Public Sub New()

        Me.strID = "F"
        Me.strDescription = "Fonacot"

        oFormaPagoValeDeCaja = New FormaPagoValeDeCaja
        oFormaPagoEfectivo = New FormaPagoEfectivo
        oFormaPagoTarjetaDebito = New FormaPagoTarjetaDebito
        oFormaPagoTarjetaCredito = New FormaPagoTarjetaCredito
        oFormaPagoFonacot = New FormaPagoFonacot

    End Sub

    Public ReadOnly Property FormaPagoAnticipoCliente() As FormaPagoValeDeCaja
        Get
            Return oFormaPagoValeDeCaja
        End Get
    End Property

    Public ReadOnly Property FormaPagoEfectivo() As FormaPagoEfectivo
        Get
            Return oFormaPagoEfectivo
        End Get
    End Property

    Public ReadOnly Property FormaPagoTarjetaDebito() As FormaPagoTarjetaDebito
        Get
            Return oFormaPagoTarjetaDebito
        End Get
    End Property

    Public ReadOnly Property FormaPagoTarjetaCredito() As FormaPagoTarjetaCredito
        Get
            Return oFormaPagoTarjetaCredito
        End Get
    End Property

    Public ReadOnly Property FormaPagoFonacot() As FormaPagoFonacot
        Get
            Return oFormaPagoFonacot
        End Get
    End Property

    Protected Overrides Sub FillFormasPagoList()

        Me.AddFormaPagoToList(oFormaPagoFonacot)
        Me.AddFormaPagoToList(oFormaPagoValeDeCaja)
        Me.AddFormaPagoToList(oFormaPagoEfectivo)
        Me.AddFormaPagoToList(oFormaPagoTarjetaDebito)
        'Me.AddFormaPagoToList(oFormaPagoTarjetaCredito)

    End Sub

End Class
