Public Class TipoVentaDPVale
    Inherits TipoVentaBase

    Private oFormaPagoDPVale As FormaPagoDPVale
    Private oFormaPagoValeDeCaja As FormaPagoValeDeCaja
    Private oFormaPagoEfectivo As FormaPagoEfectivo
    Private oFormaPagoTarjetaDebito As FormaPagoTarjetaDebito
    Private oFormaPagoTarjetaCredito As FormaPagoTarjetaCredito

    Public Sub New()

        Me.strID = "V"
        Me.strDescription = "DPVale"

        oFormaPagoDPVale = New FormaPagoDPVale
        oFormaPagoValeDeCaja = New FormaPagoValeDeCaja
        oFormaPagoEfectivo = New FormaPagoEfectivo
        oFormaPagoTarjetaDebito = New FormaPagoTarjetaDebito
        oFormaPagoTarjetaCredito = New FormaPagoTarjetaCredito

    End Sub

    Public ReadOnly Property FormaPagoDPVale() As FormaPagoDPVale
        Get
            Return oFormaPagoDPVale
        End Get
    End Property

    Public ReadOnly Property FormaPagoValeDeCaja() As FormaPagoValeDeCaja
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


    Protected Overrides Sub FillFormasPagoList()
        Me.AddFormaPagoToList(oFormaPagoDPVale)
        Me.AddFormaPagoToList(oFormaPagoValeDeCaja)
        Me.AddFormaPagoToList(oFormaPagoEfectivo)
        Me.AddFormaPagoToList(oFormaPagoTarjetaDebito)
        'Me.AddFormaPagoToList(oFormaPagoTarjetaCredito)
    End Sub

End Class

