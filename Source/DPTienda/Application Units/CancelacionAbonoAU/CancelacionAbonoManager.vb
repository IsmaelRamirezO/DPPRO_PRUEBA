

Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CancelacionAbonoManager

    Private oApplicationContext As ApplicationContext
    Private oCancelacionAbonoDG As CancelacionAbonoDataGateWay



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCancelacionAbonoDG = New CancelacionAbonoDataGateWay(Me)

    End Sub



    Public Sub Dispose()

        MyBase.Finalize()

        oCancelacionAbonoDG = Nothing

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

    Public Function Create() As CancelacionAbono

        Dim oNuevaCancelacionAbono As CancelacionAbono
        oNuevaCancelacionAbono = New CancelacionAbono(Me)

        Return oNuevaCancelacionAbono

    End Function



    'Public Function Load(ByVal ID As String) As CancelacionAbono

    '   If (ID = String.Empty) Then
    '       Throw New ArgumentException("Debe especificar un Código de Caja")
    '   End If

    '    If (ID.Length > 2) Then
    '        Throw New ArgumentException("El Código de Caja no debe exceder los 2 caracteres de longitud.")
    '    End If

    'Dim oReadedCaja As CancelacionAbono

    'oReadedCaja = oCancelacionAbonoDG.SelectByID(ID)

    'Return oReadedCaja

    'End Function



    'Public Sub Save(ByVal pCaja As CancelacionAbono)

    'If (pCaja Is Nothing) Then
    '    Throw New ArgumentNullException("El parámetro Caja no puede ser nulo.")
    'End If

    'If (pCaja.IsNew) Then
    '    oCatalogoCajaDG.Insert(pCaja)
    'Else
    '    oCatalogoCajaDG.Update(pCaja)
    'End If

    'End Sub



    Public Sub Delete(ByVal ID As Integer, ByVal ApartadoId As Integer)

        If (ID <= 0) Then
            Throw New ArgumentException("Debe especificar un Número de Abono")
        End If

        ' If (ID.Length > 2) Then
        'Throw New ArgumentException("El Código de Caja no debe exceder los 2 caracteres de longitud.")
        'End If

        oCancelacionAbonoDG.Delete(ID, ApartadoId)

    End Sub

    'ActualizaDOCNUMFB01
    Public Sub ActualizaDOCNUMFB01(ByVal ApartadoID As Integer, ByVal DOCNUMFB01 As String)

        oCancelacionAbonoDG.ActualizaDOCNUMFB01(ApartadoID, DOCNUMFB01)

    End Sub


    '    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    '    Return oCatalogoCajaDG.SelectAll(EnabledRecordsOnly)

    'End Function

#End Region

End Class
