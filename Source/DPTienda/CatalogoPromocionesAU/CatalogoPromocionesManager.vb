Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class CatalogoPromocionesManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoPromoDG As CatalogoPromocionesDataGateway
    Private oConfigCierreFI As SaveConfigArchivos

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, ByVal pConfigCierreFI As SaveConfigArchivos)

        oApplicationContext = ApplicationContext

        oConfigCierreFI = pConfigCierreFI

        oCatalogoPromoDG = New CatalogoPromocionesDataGateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oCatalogoPromoDG = Nothing

    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos

        Get
            Return oConfigCierreFI
        End Get

    End Property


#End Region

#Region "Methods"

    Public Function CreatePromocion() As Promocion

        Dim oNuevaPromo As Promocion
        oNuevaPromo = New Promocion(Me)

        Return oNuevaPromo

    End Function

    Public Function CreateAfiliacion() As Afiliacion

        Dim oNewAfil As Afiliacion
        oNewAfil = New Afiliacion(Me)

        Return oNewAfil

    End Function

    Public Function CreateEmisor() As Emisor

        Dim oNewEmisor As Emisor
        oNewEmisor = New Emisor(Me)

        Return oNewEmisor

    End Function

    Public Function CreatePromoBin() As PromoBin

        Dim oNewPromoBin As PromoBin
        oNewPromoBin = New PromoBin(Me)

        Return oNewPromoBin

    End Function

    Public Sub SavePromocion(ByVal oPromo As Promocion)

        If (oPromo.IsNew) Then
            oCatalogoPromoDG.InsertPromocion(oPromo)
        Else
            'oCatalogoPromoDG.Update(oPromo)
        End If

    End Sub

    Public Sub SaveAfiliacion(ByVal oAfil As Afiliacion)

        If (oAfil.IsNew) Then
            oCatalogoPromoDG.InsertAfiliacion(oAfil)
        Else
            'oCatalogoPromoDG.Update(oPromo)
        End If

    End Sub

    Public Sub SaveEmisor(ByVal oEmisor As Emisor)

        If (oEmisor.IsNew) Then
            oCatalogoPromoDG.InsertEmisor(oEmisor)
        Else
            'oCatalogoPromoDG.Update(oPromo)
        End If

    End Sub

    Public Sub SavePromoBin(ByVal oPromoBin As PromoBin)

        If (oPromoBin.IsNew) Then
            oCatalogoPromoDG.InsertPromoBin(oPromoBin)
        Else
            'oCatalogoPromoDG.Update(oPromo)
        End If

    End Sub

    Public Function GetAllByBin(ByVal Bin As Integer, ByVal Importe As Decimal) As DataTable

        Return oCatalogoPromoDG.SelectAllByBin(Bin, Importe)

    End Function

    Public Function GetAllPromociones() As DataTable

        Return oCatalogoPromoDG.SelectAllPromocionesFromServer

    End Function

    Public Function GetAllEmisores() As DataTable

        Return oCatalogoPromoDG.SelectAllEmisoresFromServer

    End Function

    Public Function GetAllPromoBin() As DataTable

        Return oCatalogoPromoDG.SelectAllPromoBinFromServer

    End Function

    Public Function GetAllAfiliaciones() As DataTable

        Return oCatalogoPromoDG.SelectAllAfiliacionesFromServer()

    End Function

    Public Sub DeleteAllPromociones()

        oCatalogoPromoDG.DeleteAllPromociones()

    End Sub

    Public Sub DeleteAllAfiliaciones()

        oCatalogoPromoDG.DeleteAllAfiliaciones()

    End Sub

    Public Sub DeleteAllEmisores()

        oCatalogoPromoDG.DeleteAllEmisores()

    End Sub

    Public Sub DeleteAllPromoBin()

        oCatalogoPromoDG.DeleteAllPromoBin()

    End Sub

#End Region

End Class
