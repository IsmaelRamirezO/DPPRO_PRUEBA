Imports DportenisPro.DPTienda.Core

Public Class ArqueoDeCajaManager
    Dim oApplicationContext As ApplicationContext
    Private oArqueoDeCajaDG As ArqueoDeCajaDataGateWay

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext
        oArqueoDeCajaDG = New ArqueoDeCajaDataGateWay(Me)

    End Sub

    Public Sub dispose()

        MyBase.Finalize()

        oArqueoDeCajaDG = Nothing

    End Sub

    Public Function Create() As ArqueoDeCaja

        Dim oNuevoArqueo As ArqueoDeCaja
        oNuevoArqueo = New ArqueoDeCaja(Me)

        Return oNuevoArqueo

    End Function


#End Region


#Region "Methods"

    Public Function FechaServer() As Date

        Return oArqueoDeCajaDG.FechaServer()

    End Function

    Public Function IngresosDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Return oArqueoDeCajaDG.IngresosEfectivoDia(Fecha, CodCaja, CodAlmacen)

    End Function
    Public Function IngresosDiaREP(ByVal Fecha As Date, ByVal CodAlmacen As String) As Decimal

        Return oArqueoDeCajaDG.IngresosEfectivoDiaREP(Fecha, CodAlmacen)

    End Function
    Public Function DevolucionesDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Return oArqueoDeCajaDG.DevolucionEfectivoDia(Fecha, CodCaja, CodAlmacen)

    End Function
    Public Function IngresosAbonosCDTDia(ByVal Fecha As Date, ByVal CodCaja As String, ByVal CodAlmacen As String) As Decimal

        Return oArqueoDeCajaDG.IngresosAbonosCDTDia(Fecha, CodCaja, CodAlmacen)

    End Function

    Public Function Insert(ByVal pArqueoDeCaja As ArqueoDeCaja) As ArqueoDeCaja

        Return oArqueoDeCajaDG.Insert(pArqueoDeCaja)

    End Function

    Public Function InsertCajaChica(ByVal pArqueoDeCaja As ArqueoDeCaja) As ArqueoDeCaja

        Return oArqueoDeCajaDG.InsertCajaChica(pArqueoDeCaja)

    End Function

    Public Function SelectAll(ByVal OnlyEnabledRecord As Boolean) As DataSet

        Return oArqueoDeCajaDG.SelectAll(OnlyEnabledRecord)

    End Function

    Public Function SelectCajaChicaAll(ByVal OnlyEnabledRecord As Boolean) As DataSet

        Return oArqueoDeCajaDG.SelectCajaChicaAll(OnlyEnabledRecord)

    End Function

    Public Function [Select](ByVal Folio As Integer) As ArqueoDeCaja

        Return oArqueoDeCajaDG.SelectByID(Folio)

    End Function

    Public Function [SelectCajaChica](ByVal Folio As Integer) As ArqueoDeCaja

        Return oArqueoDeCajaDG.SelectCajaChicaByID(Folio)

    End Function

    Public Function SelectFolio(ByVal TipoArqueo As Integer) As Integer

        Return oArqueoDeCajaDG.SelectFolioArqueo(TipoArqueo)

    End Function

#End Region

End Class
