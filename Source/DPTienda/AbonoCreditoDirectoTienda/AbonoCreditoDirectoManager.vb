Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale
Public Class AbonoCreditoDirectoManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oAbonoCreditoDirectoDG As AbonoCreditoDirectoDataGateway
    Private oAbonoCreditoDirecto As AbonoCreditoDirecto


#Region "Properties"

    Public ReadOnly Property ApplicationContext() As DportenisPro.DPTienda.Core.ApplicationContext
        Get
            Return oAppContext
        End Get
    End Property

#End Region

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oAppContext = ApplicationContext

        oAbonoCreditoDirectoDG = New AbonoCreditoDirectoDataGateway(Me)

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As AbonoCreditoDirecto

        Dim oAbonoCreditoDirecto As AbonoCreditoDirecto
        oAbonoCreditoDirecto = New AbonoCreditoDirecto(Me)

        Return oAbonoCreditoDirecto

    End Function


    '***** Procedimientos Nuevos

    'Public Function SelectCreditoDirectoAll(ByVal OnlyEnabledRecords As Boolean) As DataSet

    '    oAbonoCreditoDirectoDG = New AbonoCreditoDirectoDataGateway(Me)
    '    Return oAbonoCreditoDirectoDG.SelectCreditoDirectoAll(OnlyEnabledRecords)

    'End Function

    'Public Function SelectCreditoDirectoByID(ByVal AsociadoID As Integer) As AbonoCreditoDirecto

    '    oAbonoCreditoDirectoDG = New AbonoCreditoDirectoDataGateway(Me)
    '    Return oAbonoCreditoDirectoDG.SelectCreditoDirectoByID(AsociadoID)

    'End Function

    'Public Sub Save(ByVal oAbonoCreditoDirecto As AbonoCreditoDirecto, ByVal oAbonoDPVale As AbonoDPVale)

    '    If (oAbonoCreditoDirecto Is Nothing) Then
    '        Throw New ArgumentNullException("El parámetro Folio no puede ser nulo.")
    '    End If

    '    If (oAbonoDPVale.IsNew) Then
    '        oAbonoCreditoDirectoDG.Insert(oAbonoCreditoDirecto, oAbonoDPVale)
    '    End If

    'End Sub

    'Public Sub Delete(ByVal oAbonoCreditoDirecto As AbonoCreditoDirecto, ByVal oAbonoDPVale As AbonoDPVale)
    '    oAbonoCreditoDirectoDG.Delete(oAbonoCreditoDirecto, oAbonoDPVale)
    'End Sub

    'Public Function GetByDate(ByVal Fecha As DateTime, ByVal Almacen As String) As DataSet

    '    Return oAbonoCreditoDirectoDG.SelectByDate(Fecha, Almacen)

    'End Function

    'Public Function SelectAbonosFacturas(ByVal AbonoID As Integer, ByVal CodAlmacen As String, ByVal CodCaja As String, ByVal Fecha As DateTime) As DataSet
    '    Return oAbonoCreditoDirectoDG.SelectAbonosFacturas(AbonoID, CodAlmacen, CodCaja, Fecha.Date)
    'End Function

    'Public Function SelectAbonosFacturasByAsociadoID(ByVal AsociadoID As Integer) As DataSet
    '    Return oAbonoCreditoDirectoDG.SelectFacturasByID(AsociadoID)
    'End Function

    'Public Function GetUltimoAbono(ByVal CodSegmentoCredito As String, ByVal AsociadoID As Integer) As AbonoDPVale

    '    Return oAbonoCreditoDirectoDG.GetUltimoAbono(CodSegmentoCredito, AsociadoID)

    'End Function

#End Region

#Region "SQL"

    Public Function GetSelectNombreBanco(ByVal strTipoPago As String, ByVal strCentro As String) As String()

        Return oAbonoCreditoDirectoDG.SelectNombreBanco(strTipoPago, strCentro)

    End Function

    Public Function GetSelectFolioFacturaDPBySDSAP(ByVal strClienteID As String, ByVal strFolioSap As String) As String

        Return oAbonoCreditoDirectoDG.SeleccionaFolioFacturaDPBySDSAP(strClienteID, strFolioSap)

    End Function

    Public Function GetSelectFolioFacturaDPBySDSAP(ByVal strFolioSap As String) As String

        Return oAbonoCreditoDirectoDG.SeleccionaFolioFacturaDPBySDSAP(strFolioSap)

    End Function

    Public Function GetSelectFolioFacturaDPByFISAP(ByVal strClienteID As String, ByVal strFolioSap As String) As String

        Return oAbonoCreditoDirectoDG.SeleccionaFolioFacturaDPByFISAP(strClienteID, strFolioSap)

    End Function

    Public Function GetSelectFolioFacturaSDSAP(ByVal intFolioDp As Integer) As String

        Return oAbonoCreditoDirectoDG.SeleccionaFolioSDSAPFactura(intFolioDp)

    End Function

    Public Function GetSelectFolioFacturaSDSAP(ByVal intFolioDp As Integer, ByVal CodCaja As String) As String

        Return oAbonoCreditoDirectoDG.SeleccionaFolioSDSAPFactura(intFolioDp, CodCaja)

    End Function

    Public Function GetSelectNCByCaja(ByVal CodCaja As String) As Integer

        Return oAbonoCreditoDirectoDG.SeleccionaFolioNCByCaja(CodCaja)

    End Function

    Public Function UpdateCatalogoCajasAbonoCDT(ByVal dblabono As Double, ByVal strOpc As String)

        oAbonoCreditoDirectoDG.UpdateCatalogoCajasAbonoCDT(dblabono, strOpc)

    End Function


    Public Function InsertAbonoCDT(ByVal strTienda As String, ByVal strCliente As String, ByVal dblImporte As Double, _
                                 ByVal strFacturaFI As String, ByVal strClaCobr As String, ByVal strBanco As String, _
                                ByVal strFactDpPro As String, ByVal strDocnumFB01 As String, ByVal strDocnumFB05 As String)

        oAbonoCreditoDirectoDG.InsertAbonoCDT(strTienda, strCliente, dblImporte, strFacturaFI, strClaCobr, strBanco, strFactDpPro, strDocnumFB01, strDocnumFB05)

    End Function


    Public Sub InsertAbonoCDTDetalles(ByVal strAsociado As String, ByVal strTipoPago As String, ByVal strTerminal As String, ByVal dblMonto As Decimal, ByVal strTipoTarj As String, _
                                        ByVal strNumTar As String, ByVal strNumAutoriz As String, ByVal strFolioValeCaja As String)
        oAbonoCreditoDirectoDG.InsertAbonoCDTDetalles(strAsociado, strTipoPago, strTerminal, dblMonto, strTipoTarj, strNumTar, strNumAutoriz, strFolioValeCaja)

    End Sub

    ''ToReport
    Public Sub InsertAbonoCDTDetalles(ByVal intAbonoID As Integer, ByVal strTipoPago As String, ByVal dblMonto As Double)
        oAbonoCreditoDirectoDG.InsertAbonoCDTDetalles(intAbonoID, strTipoPago, dblMonto)
    End Sub

    Public Function InsertAbonoCDT(ByVal intAbonoID As Integer, ByVal intFactDpPro As Integer, ByVal strFolioSAP As String, ByVal decSaldo As Decimal, ByVal dblImporte As Double)

        oAbonoCreditoDirectoDG.InsertAbonoCDT(intAbonoID, intFactDpPro, strFolioSAP, decSaldo, dblImporte)

    End Function

    Public Function InsertAbonoCDTGeneral(ByVal strCliente As String, ByVal decAbono As Double, ByVal strNombre As String) As Integer
        Return oAbonoCreditoDirectoDG.InsertAbonoCDTGeneral(strCliente, decAbono, strNombre)
    End Function

    Public Function AbonosCreditoDirectoSelByDate(ByVal Fecha As Date) As DataSet
        Return oAbonoCreditoDirectoDG.AbonosCreditoDirectoSelByDate(Fecha)
    End Function

    Public Function AbonosCreditoDirectoFoliosGET(ByVal AbonoID As Integer) As DataSet
        Return oAbonoCreditoDirectoDG.AbonosCreditoDirectoFoliosGETDGW(AbonoID)
    End Function
    Public Function AbonosCreditoDirectoFoliosGETFB05(ByVal FolioSAP As String, ByVal FolioFactura As String, ByVal Monto As Decimal) As DataSet
        Return oAbonoCreditoDirectoDG.AbonosCreditoDirectoFoliosGETDGWFB05(FolioSAP, FolioFactura, Monto)
    End Function

    Public Function AbonosCDTFacturasByIDAbonos(ByVal AbonoID As Integer) As DataSet
        Return oAbonoCreditoDirectoDG.AbonosCDTFacturasByIDAbonos(AbonoID)
    End Function
    Public Function FolioSAPGET(ByVal FolioFactura As String, ByVal CodCaja As String) As DataSet
        Return oAbonoCreditoDirectoDG.FolioSAPGET(FolioFactura, CodCaja)
    End Function

    Public Function AbonosCDTFormasPagosByIDAbonos(ByVal AbonoID As Integer) As DataSet
        Return oAbonoCreditoDirectoDG.AbonosCDTFormasPagoByIDAbonos(AbonoID)
    End Function

#End Region


End Class
