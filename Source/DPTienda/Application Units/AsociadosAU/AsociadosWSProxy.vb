
'Imports DportenisPro.DPTienda.ApplicationUnits.Asociados.ws.Asociados

Public Class AsociadosWSProxy

    'Web Method - DataGateWay
    'Public oWSAsociados As CreditoAsociados

    ''Web Fields
    'Private oDatosAsociados As AsociadoInfo

    Public Sub New()

        'oWSAsociados = New CreditoAsociados


    End Sub

#Region "Methods"

    Public Function Insert(ByVal pAsociado As Asociado) As Integer

        'oDatosAsociados = New AsociadoInfo

        'With oDatosAsociados

        '    .ClienteID = pAsociado.ClienteID
        '    .Foto = pAsociado.Foto
        '    .RecordCreatedBy = pAsociado.Usuario
        '    .RecordCreatedOn = pAsociado.Fecha
        '    .RecordStatus = pAsociado.StatusRegistro
        '    .TelefonoTrabajo = pAsociado.TeleFonoTrabajo
        '    .TelefonoOtro = pAsociado.TeleFonoOtro
        '    .Observaciones = pAsociado.Observaciones

        'End With

        'Return oWSAsociados.CreateAsociado(oDatosAsociados)

    End Function

    Public Sub Update(ByVal ID As Integer, ByVal pAsociado As Asociado)

        'oDatosAsociados = New AsociadoInfo

        'With oDatosAsociados

        '    .AsociadoID = pAsociado.AsociadoID
        '    .ClienteID = pAsociado.ClienteID
        '    .Foto = pAsociado.Foto
        '    .RecordCreatedBy = pAsociado.Usuario
        '    .RecordCreatedOn = pAsociado.Fecha
        '    .RecordStatus = pAsociado.StatusRegistro
        '    .TelefonoTrabajo = pAsociado.TeleFonoTrabajo
        '    .TelefonoOtro = pAsociado.TeleFonoOtro
        '    .Observaciones = pAsociado.Observaciones

        'End With

        'oWSAsociados.UpdateAsociado(oDatosAsociados)

    End Sub

    Public Sub Delete(ByVal AsociadoID As Integer)

        'oWSAsociados.DeleteAsociado(AsociadoID)

    End Sub

    Public Sub [Select](ByVal ID As Integer, ByVal pAsociado As Asociado)

        ''Dim oAsociadoInfo As AsociadoInfo

        ''oAsociadoInfo = oWSAsociados.GetAsociado(ID)

        'If (oAsociadoInfo.AsociadoID = 0) Then

        '    pAsociado.AsociadoID = 0

        'Else

        '    pAsociado.AsociadoID = oAsociadoInfo.AsociadoID
        '    pAsociado.ClienteID = oAsociadoInfo.ClienteID
        '    pAsociado.EsCreditoMayoreo = oAsociadoInfo.TieneCreditoMayoreo
        '    pAsociado.EsCreditoDirectoTienda = oAsociadoInfo.TieneCreditoEnTienda
        '    pAsociado.EsCreditoDPVale = oAsociadoInfo.TieneCreditoDPVale
        '    pAsociado.LimiteCreditoMayoreo = oAsociadoInfo.LimiteCreditoMayoreo
        '    pAsociado.LimiteCreditoDPVale = oAsociadoInfo.LimiteCreditoDPVale
        '    pAsociado.LimiteCreditoDirectoTienda = oAsociadoInfo.LimiteCreditoEnTienda
        '    pAsociado.SaldoMayoreo = oAsociadoInfo.SaldoActualCreditoMayoreo
        '    pAsociado.SaldoDirectoTienda = oAsociadoInfo.SaldoActualCreditoEnTienda
        '    pAsociado.SaldoDPVale = oAsociadoInfo.SaldoActualCreditoDPVale
        '    pAsociado.SaldoVencMayoreo = oAsociadoInfo.SaldoVencidoCreditoMayoreo
        '    pAsociado.SaldoVencDirectoTienda = oAsociadoInfo.SaldoVencidoCreditoEnTienda
        '    pAsociado.SaldoVencDPVale = oAsociadoInfo.SaldoVencidoCreditoDPVale
        '    pAsociado.Foto = oAsociadoInfo.Foto
        '    pAsociado.Usuario = oAsociadoInfo.RecordCreatedBy
        '    pAsociado.Fecha = oAsociadoInfo.RecordCreatedOn
        '    pAsociado.StatusRegistro = oAsociadoInfo.RecordStatus
        '    pAsociado.TeleFonoTrabajo = oAsociadoInfo.TelefonoTrabajo
        '    pAsociado.TeleFonoOtro = oAsociadoInfo.TelefonoOtro
        '    pAsociado.Observaciones = oAsociadoInfo.Observaciones
        '    pAsociado.CodigoSAP = oAsociadoInfo.CodigoSAP

        'End If

    End Sub

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        'Dim dsAsociados As DataSet = New DataSet("Asociados")

        'dsAsociados = oWSAsociados.GetAsociados(EnabledRecordsOnly)

        'Return dsAsociados

    End Function

    Public Sub [SelectByClienteID](ByVal ClienteID As Integer, ByVal pAsociado As Asociado)

        'Dim oAsociadoInfo As AsociadoInfo

        'oAsociadoInfo = oWSAsociados.GetAsociadoByClienteID(ClienteID)

        'If (oAsociadoInfo.AsociadoID = 0) Then

        '    pAsociado.AsociadoID = 0

        'Else

        '    pAsociado.AsociadoID = oAsociadoInfo.AsociadoID
        '    pAsociado.ClienteID = oAsociadoInfo.ClienteID
        '    pAsociado.EsCreditoMayoreo = oAsociadoInfo.TieneCreditoMayoreo
        '    pAsociado.EsCreditoDirectoTienda = oAsociadoInfo.TieneCreditoEnTienda
        '    pAsociado.EsCreditoDPVale = oAsociadoInfo.TieneCreditoDPVale
        '    pAsociado.LimiteCreditoMayoreo = oAsociadoInfo.LimiteCreditoMayoreo
        '    pAsociado.LimiteCreditoDPVale = oAsociadoInfo.LimiteCreditoDPVale
        '    pAsociado.LimiteCreditoDirectoTienda = oAsociadoInfo.LimiteCreditoEnTienda
        '    pAsociado.SaldoMayoreo = oAsociadoInfo.SaldoActualCreditoMayoreo
        '    pAsociado.SaldoDirectoTienda = oAsociadoInfo.SaldoActualCreditoEnTienda
        '    pAsociado.SaldoDPVale = oAsociadoInfo.SaldoActualCreditoDPVale
        '    pAsociado.SaldoVencMayoreo = oAsociadoInfo.SaldoVencidoCreditoMayoreo
        '    pAsociado.SaldoVencDirectoTienda = oAsociadoInfo.SaldoVencidoCreditoEnTienda
        '    pAsociado.SaldoVencDPVale = oAsociadoInfo.SaldoVencidoCreditoDPVale
        '    pAsociado.Foto = oAsociadoInfo.Foto
        '    pAsociado.Usuario = oAsociadoInfo.RecordCreatedBy
        '    pAsociado.Fecha = oAsociadoInfo.RecordCreatedOn
        '    pAsociado.StatusRegistro = oAsociadoInfo.RecordStatus
        '    pAsociado.TeleFonoTrabajo = oAsociadoInfo.TelefonoTrabajo
        '    pAsociado.TeleFonoOtro = oAsociadoInfo.TelefonoOtro
        '    pAsociado.Observaciones = oAsociadoInfo.Observaciones
        '    pAsociado.CodigoSAP = oAsociadoInfo.CodigoSAP

        'End If

    End Sub

#End Region


End Class
