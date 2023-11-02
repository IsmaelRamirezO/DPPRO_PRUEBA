Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosDPVale

Public Class AbonosDPValeManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oAbonosDataGate As AbonoDPValeDataGateWay2

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

        oAbonosDataGate = New AbonoDPValeDataGateWay2(Me)

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As AbonoDPVale

        Dim oNewAbonoDPVale As AbonoDPVale
        oNewAbonoDPVale = New AbonoDPVale(Me)

        Return oNewAbonoDPVale

    End Function

    'Public Sub Save(ByVal AbonoDPVale As AbonoDPVale)

    '    If (AbonoDPVale Is Nothing) Then
    '        Throw New ArgumentNullException("El parámetro Folio no puede ser nulo.")
    '    End If

    '    If (AbonoDPVale.IsNew) Then
    '        oAbonosDataGate.Insert(AbonoDPVale)
    '    Else
    '        'oAbonosDataGate.Update(AbonoDPVale)
    '    End If

    'End Sub

    'Public Function GetUltimoAbono(ByVal CodSegmentoCredito As String, ByVal AsociadoID As Integer) As AbonoDPVale

    '    Return oAbonosDataGate.GetUltimoAbono(CodSegmentoCredito, AsociadoID)

    'End Function

    'Public Function GetAll(ByVal EnabledRecordOnly As Boolean) As DataSet

    '    Return oAbonosDataGate.SelectCreditoDPValeAll(EnabledRecordOnly)

    'End Function

    'Public Sub Delete(ByVal oAbonoDPVale As AbonoDPVale)
    '    oAbonosDataGate.Delete(oAbonoDPVale)
    'End Sub
#End Region

End Class
