Imports System.Collections.Generic

Public Class Root
    Public Property mandt As String
    Public Property fecha As String
    Public Property idPedido As String
    Public Property referencia As String
    Public Property numOrdenEc As String
    Public Property codAlmacen As String
    Public Property codTipoVta As String
    Public Property canal As String
    Public Property sector As String
    Public Property clienteId As String
    Public Property codVendedor As String
    Public Property descTotal As Double
    Public Property subtotal As Double
    Public Property impuesto As Double
    Public Property flete As Double
    Public Property total As Double
    Public Property posiciones As List(Of Posicione)
    Public Property mediosPago As List(Of MediosPago)
    Public Property mediosPagoDev As List(Of MediosPagoDev)
End Class
