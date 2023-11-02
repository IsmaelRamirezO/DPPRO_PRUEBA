Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Imports Janus.Windows.GridEX

Imports System.Collections.Generic

Public Class ClientesFromSAPOpenRecordDialogViewDPVale


    Implements IOpenFromSAPRecordDialogViewClientesDPVale

    Dim oS2Credit As New ProcesosS2Credit

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenFromSAPRecordDialogViewClientesDPVale.AllowFilterBy
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenFromSAPRecordDialogViewClientesDPVale.AllowGroupBy
        Get
            Return False
            'para que no te deje agrupar
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX, ByVal strCriterio As String, ByVal GrupoDeCuentas As String, ByVal S2Credit As Boolean) Implements IOpenFromSAPRecordDialogViewClientesDPVale.SetupDataBinding

        Dim ds As New DataSet

        Dim oSAPMgr As ProcesoSAPManager
        Dim oClientesMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        'Dim strValor As String = oClientesMgr.GetCongif("GuardarServer").Trim

        'If strValor.Trim = "" Then strValor = "SI"

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)


        'If GrupoDeCuentas.Trim = "" Then

        '    '--------------------------------------------------------------------------------
        '    ' JNAVA (11.07.2016): Si esta activo S2Credit Buscamos ahi en base a l criterio
        '    '--------------------------------------------------------------------------------
        '    If S2Credit Then
        '        ds.Tables.Add(ObtenerClienteS2Credit(strCriterio, GrupoDeCuentas))
        '    Else
        '        ds.Tables.Add(oSAPMgr.ZBAPI_OBTENER_CLIENTES_DPVALE(strCriterio))
        '        'If strValor.Trim = "SI" Then
        '        ds.Tables.Add(oClientesMgr.GetAllPGFromServer(strCriterio))
        '        'Else
        '        '    ds.Tables.Add(oClientesMgr.GetAllPG(strCriterio))
        '        'End If
        '    End If
        '    '--------------------------------------------------------------------------------

        'ElseIf GrupoDeCuentas.Trim = "PG" Then

        '    If S2Credit Then
        '        ds.Tables.Add(ObtenerClienteS2Credit(strCriterio))
        '    Else
        '        'If strValor.Trim = "SI" Then
        '        ds.Tables.Add(oClientesMgr.GetAllPGFromServer(strCriterio))
        '        'Else
        '        '    ds.Tables.Add(oClientesMgr.GetAllPG(strCriterio))
        '        'End If
        '    End If

        'Else
        '--------------------------------------------------------------------------------
        ' JNAVA (11.07.2016): Si esta activo S2Credit Buscamos ahi en base a l criterio
        '--------------------------------------------------------------------------------
        If S2Credit Then
            ds.Tables.Add(oS2Credit.ObtenerCliente(strCriterio, GrupoDeCuentas))
        Else
            ds.Tables.Add(oSAPMgr.ZBAPI_OBTENER_CLIENTES_DPVALE(strCriterio))
        End If

        'End If

        Dim dtView As DataView
        Dim dtTemp As DataTable = ds.Tables(0).Clone


        'dtTemp.TableName = "TZCOMPRADORESFILTRADA"

        'If GrupoDeCuentas = "D005" Then

        dtView = New DataView(ds.Tables(0), "KTOKD = 'D005'", "KUNNR", DataViewRowState.CurrentRows)
        For Each odrView As DataRowView In dtView
            dtTemp.ImportRow(odrView.Row)
        Next
        dtTemp.AcceptChanges()

        dtView = New DataView(ds.Tables(0), "KTOKD = 'D004'", "KUNNR", DataViewRowState.CurrentRows)
        For Each odrView As DataRowView In dtView
            dtTemp.ImportRow(odrView.Row)
        Next
        dtTemp.AcceptChanges()

        'ElseIf GrupoDeCuentas = "PG" Then

        '    dtTemp = ds.Tables(0).Copy

        'Else

        '    If GrupoDeCuentas.Trim <> "" Then
        '        dtView = New DataView(ds.Tables(0), "KTOKD = '" & GrupoDeCuentas & "'", "KUNNR", DataViewRowState.CurrentRows)

        '        For Each odrView As DataRowView In dtView
        '            dtTemp.ImportRow(odrView.Row)
        '        Next
        '        dtTemp.AcceptChanges()
        '    Else
        '        dtTemp = ds.Tables(0).Copy
        '        For Each oRow As DataRow In ds.Tables(1).Rows
        '            dtTemp.ImportRow(oRow)
        '        Next
        '        dtTemp.AcceptChanges()
        '    End If

        'End If

        dtTemp.TableName = "TZCOMPRADORESFILTRADA"

        ds.Tables.Add(dtTemp)

        With TargetGridEx
            '.SetDataBinding(ds, ds.Tables(1).TableName)
            .SetDataBinding(ds, "TZCOMPRADORESFILTRADA")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenFromSAPRecordDialogViewClientesDPVale.SetupView

        With TargetGridEx.Tables("TZCOMPRADORESFILTRADA")

            For intCol As Integer = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next

            .Columns("KUNNR").Caption = "Código SAP"
            .Columns("KUNNR").Width = 100
            .Columns("KUNNR").HeaderAlignment = TextAlignment.Center
            .Columns("KUNNR").Visible = True

            .Columns("NAME1").Caption = "Nombre"
            .Columns("NAME1").Width = 300
            .Columns("NAME1").HeaderAlignment = TextAlignment.Center
            .Columns("NAME1").Visible = True

            .Columns("NAME2").Caption = "Nombre"
            .Columns("NAME2").Width = 120
            .Columns("NAME2").HeaderAlignment = TextAlignment.Center
            .Columns("NAME2").Visible = False

            .Columns("KTOKD").Caption = "GrupoDeCuentas"

        End With

    End Sub

End Class
