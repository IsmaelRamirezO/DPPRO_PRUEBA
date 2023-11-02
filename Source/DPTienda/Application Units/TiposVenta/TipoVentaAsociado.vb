Public Class TipoVentaAsociado

    Inherits TipoVentaBase

    Private oFormaPagoValeDeCaja As FormaPagoValeDeCaja
    Private oFormaPagoEfectivo As FormaPagoEfectivo
    Private oFormaPagoTarjetaDebito As FormaPagoTarjetaDebito
    Private oFormaPagoTarjetaCredito As FormaPagoTarjetaCredito
    Private oFormaPagoCredito As FormaPagoCredito

    Public Sub New()

        Me.strID = "A"
        Me.strDescription = "Asociado-Dip's"

        oFormaPagoValeDeCaja = New FormaPagoValeDeCaja
        oFormaPagoEfectivo = New FormaPagoEfectivo
        oFormaPagoTarjetaDebito = New FormaPagoTarjetaDebito
        oFormaPagoTarjetaCredito = New FormaPagoTarjetaCredito
        oFormaPagoCredito = New FormaPagoCredito

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

    Public ReadOnly Property FormaPagoCredito() As FormaPagoCredito
        Get
            Return oFormaPagoCredito
        End Get
    End Property

    Protected Overrides Sub FillFormasPagoList()

        Me.AddFormaPagoToList(oFormaPagoCredito)
        Me.AddFormaPagoToList(oFormaPagoValeDeCaja)
        Me.AddFormaPagoToList(oFormaPagoEfectivo)
        Me.AddFormaPagoToList(oFormaPagoTarjetaDebito)
        'Me.AddFormaPagoToList(oFormaPagoTarjetaCredito)

    End Sub

End Class
