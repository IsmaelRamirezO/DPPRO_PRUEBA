
Option Explicit On 

Imports DportenisPro.DpTienda.Core


Public Class AvisosFacturaManager

    Private oApplicationContext As ApplicationContext
    Private oAvisosFacturaDG As AvisosFacturaDataGateWay



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oAvisosFacturaDG = New AvisosFacturaDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oAvisosFacturaDG = Nothing

    End Sub

#End Region



#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

#End Region



#Region "Methods"

    Public Function Create() As AvisosFactura

        Dim oNuevoAvisosFactura As AvisosFactura
        oNuevoAvisosFactura = New AvisosFactura(Me)

        Return oNuevoAvisosFactura

    End Function



    Public Function Load(ByVal Modulo As String) As AvisosFactura

        If (Modulo = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Modulo")
        End If

        If (Modulo.Length > 30) Then
            Throw New ArgumentException("El Modulo no debe exceder los 30 caracteres de longitud.")
        End If

        Dim oReadedAvisosFactura As AvisosFactura

        oReadedAvisosFactura = oAvisosFacturaDG.SelectByID(Modulo)

        Return oReadedAvisosFactura

    End Function



    Public Sub Save(ByVal pAvisosFactura As AvisosFactura)

        If (pAvisosFactura Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Avisos Factura no puede ser nulo.")
        End If
        oAvisosFacturaDG.Insert(pAvisosFactura)
      
    End Sub

    Public Function LoadEnabled(ByVal Modulo As String, ByVal Disponible As Boolean) As DataSet

        If (Modulo = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Modulo")
        End If

        If (Modulo.Length > 30) Then
            Throw New ArgumentException("El Modulo no debe exceder los 30 caracteres de longitud.")
        End If

        Dim oReadedAvisosFactura As DataSet

        oReadedAvisosFactura = oAvisosFacturaDG.SelectEnabled(Modulo, Disponible)

        Return oReadedAvisosFactura

    End Function


    Public Sub Delete(ByVal Modulo As String)

        If (Modulo = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Modulo de Avisos Factura")
        End If

        oAvisosFacturaDG.Delete(Modulo)

    End Sub


    Public Function GetAll(ByVal Modulo As String) As DataSet

        Return oAvisosFacturaDG.SelectAll(Modulo)

    End Function

#End Region

End Class
