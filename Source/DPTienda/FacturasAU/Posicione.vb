Imports System.Collections.Generic

Public Class Posicione
    Public Property posicion As String
    Public Property articulo As String
    Public Property descripcion As String
    Public Property cantidad As Double
    Public Property precioUnit As Double
    Public Property impuesto As Double
    Public Property subtotal As Double
    Public Property flete As Double
    Public Property numero As String
    Public Property numFactura As String
    Public Property facturado As String
    Public Property devuelto As Double
    Public Property descuentosOut As List(Of DescuentosOut)
End Class

