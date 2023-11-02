Option Explicit On 

Imports DportenisPro.DpTienda.Core


Public Class AbonosApartadosManager

    Private oApplicationContext As ApplicationContext
    Private oAbonosApartadosDG As AbonosApartadosDataGateWay



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oAbonosApartadosDG = New AbonosApartadosDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oAbonosApartadosDG = Nothing

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

    Public Function Create() As AbonosApartados

        Dim oNuevoAbonoApartados As AbonosApartados
        oNuevoAbonoApartados = New AbonosApartados(Me)

        Return oNuevoAbonoApartados

    End Function



    Public Function Load(ByVal ID As String) As AbonosApartados

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Folio de Abono")
        End If

        '''If (ID.Length > 4) Then
        '''    Throw New ArgumentException("El Folio de Abono no debe exceder los 4 caracteres de longitud.")
        '''End If


        Dim oReadedAbonosApartados As AbonosApartados

        oReadedAbonosApartados = oAbonosApartadosDG.SelectByID(ID)

        Return oReadedAbonosApartados

    End Function



    Public Sub Save(ByVal pAbonosApartados As AbonosApartados)

        If (pAbonosApartados Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Abono no puede ser nulo.")
        End If

        If (pAbonosApartados.IsNew) Then
            oAbonosApartadosDG.Insert(pAbonosApartados)
        End If

    End Sub

    Public Sub ActualizaDocFI(ByVal intAbono As Integer, ByVal strDocFi As String)

        oAbonosApartadosDG.UpdateAbonosApartadosDocFi(intAbono, strDocFi)

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oAbonosApartadosDG.SelectAll(EnabledRecordsOnly)

    End Function

    Public Function GetByDate(ByVal Fecha As DateTime) As DataSet

        Return oAbonosApartadosDG.SelectByDate(Fecha)

    End Function

    Public Function GetAbonosDPCardByDate(ByVal Fecha As DateTime) As DataTable

        Return oAbonosApartadosDG.SelectAbonosDPCardByDate(Fecha)

    End Function

    Public Function Folios() As Integer

        Dim oAbonosApartadosDG As New AbonosApartadosDataGateWay(Me)


        Return oAbonosApartadosDG.AbonosApartadosFolios

        oAbonosApartadosDG = Nothing

    End Function

#End Region

    Public Function SelectByDateRerpote(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Return oAbonosApartadosDG.SelectByDateRerpote(FechaDe, FechaAl, CodCaja)

    End Function

    Public Function SelectByDateCancelados(ByVal FechaDe As DateTime, ByVal FechaAl As DateTime, ByVal CodCaja As String) As DataSet

        Return oAbonosApartadosDG.SelectByDateCancelados(FechaDe, FechaAl, CodCaja)

    End Function

    Public Function SelectNombreTienda(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Return oAbonosApartadosDG.SelectNombreTienda(strTipoPago, strCentro)

    End Function

    Public Sub SelectCtaMayor(ByVal strTienda As String, ByVal strClaCobr As String, ByRef CuentaMAyor As String, ByRef GSBER As String, ByRef Werks As String)

        oAbonosApartadosDG.CtaMayorSel(strTienda, strClaCobr, CuentaMAyor, GSBER, Werks)

    End Sub

    Public Function SelectDivision(ByVal strTipoPago As String, ByVal strCentro As String) As String

        Return oAbonosApartadosDG.SelectDivision(strTipoPago, strCentro)

    End Function

    Public Function SelectByApartadoID(ByVal Apartadoid As Integer) As DataSet

        Return oAbonosApartadosDG.SelectByApartadoID(Apartadoid)

    End Function

End Class
