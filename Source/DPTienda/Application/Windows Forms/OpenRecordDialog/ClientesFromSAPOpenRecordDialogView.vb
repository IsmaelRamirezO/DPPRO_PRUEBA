Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes

Imports Janus.Windows.GridEX

Public Class ClientesFromSAPOpenRecordDialogView
    'este

    Implements IOpenFromSAPRecordDialogViewClientes

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenFromSAPRecordDialogViewClientes.AllowFilterBy
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenFromSAPRecordDialogViewClientes.AllowGroupBy
        Get
            Return False
            'para que no te deje agrupar
        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX, ByVal strCriterio As String, ByVal GrupoDeCuentas As String, Optional ByVal Tipo As Integer = 0, Optional ByVal TipoVenta As String = "") Implements IOpenFromSAPRecordDialogViewClientes.SetupDataBinding

        Dim ds As New DataSet
        Dim oRetail As New ProcesosRetail("/pos/clientes", "POST")
        Dim oSAPMgr As ProcesoSAPManager
        Dim oClientesMgr As New ClientesManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
        Dim tipoCliente As Integer = GetTipoCliente(TipoVenta)
        'Dim strValor As String = oClientesMgr.GetCongif("GuardarServer").Trim

        'If strValor.Trim = "" Then strValor = "SI"

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        'If GrupoDeCuentas.Trim = "" Then
        '    '--------------------------------------------------------------------------------
        '    'Roket (29.12.2015): Implementacion de Servicios REST para SAP Retail
        '    '--------------------------------------------------------------------------------
        '    'ds.Tables.Add(oSAPMgr.ZBAPI_OBTENER_CLIENTES(strCriterio))

        '    ds.Tables.Add(oRetail.ZbapiObtenerClientes(strCriterio, Tipo, tipoCliente, GrupoDeCuentas))

        '    'If strValor.Trim = "SI" Then
        '    'ds.Tables.Add(oClientesMgr.GetAllPGFromServer(strCriterio))
        '    'Else
        '    '    ds.Tables.Add(oClientesMgr.GetAllPG(strCriterio))
        '    'End If
        'ElseIf GrupoDeCuentas.Trim = "PG" Then
        '    'If strValor.Trim = "SI" Then
        '    ds.Tables.Add(oClientesMgr.GetAllPGFromServer(strCriterio))
        '    'Else
        '    '    ds.Tables.Add(oClientesMgr.GetAllPG(strCriterio))
        '    'End If
        'Else
        '--------------------------------------------------------------------------------
        'Roket (29.12.2015): Implementacion de Servicios REST para SAP Retail
        '--------------------------------------------------------------------------------
        'ds.Tables.Add(oSAPMgr.ZBAPI_OBTENER_CLIENTES(strCriterio))
        'ds.Tables.Add(oRetail.ZbapiObtenerClientes(strCriterio, Tipo, tipoCliente, GrupoDeCuentas))
        'End If

        '-----------------------------------------------------------------------------------------
        ' JNAVA (29.02.2016): Adecuacion para Retail
        '-----------------------------------------------------------------------------------------
        Dim Filtro As String = String.Empty
        Dim Apellidos() As String
        Dim ApellidoM As String = String.Empty

        '-----------------------------------------------------------------------------------------
        ' JNAVA (29.02.2016): Validamos si busca por apellidos para separarlos por paterno y materno
        '-----------------------------------------------------------------------------------------
        If Tipo = 2 Then
            strCriterio = strCriterio.Replace("_", " ")
            Apellidos = strCriterio.Split(" ")
            For Each Apellido As String In Apellidos
                If Filtro.Trim = String.Empty Then
                    Filtro = Apellido.TrimEnd ' Seteamos Apellidop Paterno
                Else
                    ApellidoM = Apellido.TrimEnd ' Seteamos Apellidop Materno
                    Exit For
                End If
            Next
        Else
            Filtro = strCriterio
        End If
        '-----------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------
        ' JNAVA (29.02.2016): Hacemos busqueda en SAP
        '-----------------------------------------------------------------------------------------
        'ds.Tables.Add(oRetail.ZbapiObtenerClientes(Filtro, Tipo, tipoCliente, GrupoDeCuentas))
        ds.Tables.Add(oSAPMgr.ZBAPI_OBTENER_CLIENTES(Filtro, Tipo, tipoCliente, IIf(GrupoDeCuentas.Trim.ToUpper = "D005", True, False)))
        '-----------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------
        ' JNAVA (29.02.2016): Hacemos busqueda en SAP
        '-----------------------------------------------------------------------------------------
        Dim dtTemp As DataTable
        If Tipo = "2" Then
            Dim dtView As DataView
            If ApellidoM <> String.Empty Then 'Si es el apellido paterno
                dtTemp = ds.Tables(0).Clone
                dtView = New DataView(ds.Tables(0), "NAME3 = '" & ApellidoM & "'", "KUNNR", DataViewRowState.CurrentRows)
                For Each odrView As DataRowView In dtView
                    dtTemp.ImportRow(odrView.Row)
                Next
                dtTemp.AcceptChanges()
            Else
                dtTemp = ds.Tables(0).Copy
            End If
        Else
            dtTemp = ds.Tables(0).Copy
        End If
        '-----------------------------------------------------------------------------------------

        'If GrupoDeCuentas = "VL" Then

        '    dtView = New DataView(ds.Tables(0), "TIPO_CLIENTE = 'VL'", "KUNNR", DataViewRowState.CurrentRows)
        '    For Each odrView As DataRowView In dtView
        '        dtTemp.ImportRow(odrView.Row)
        '    Next
        '    dtTemp.AcceptChanges()

        '    'dtView = New DataView(ds.Tables(0), "TIPO_CLIENTE = 'VL'", "KUNNR", DataViewRowState.CurrentRows)
        '    'For Each odrView As DataRowView In dtView
        '    '    dtTemp.ImportRow(odrView.Row)
        '    'Next
        '    'dtTemp.AcceptChanges()

        'ElseIf GrupoDeCuentas = "PG" Then

        '    dtTemp = ds.Tables(0).Copy

        '    'ElseIf GrupoDeCuentas = "D005" Then
        '    '    For Each row As DataRow In ds.Tables(0).Rows
        '    '        dtTemp.ImportRow(row)
        '    '    Next
        '    '    dtTemp.AcceptChanges()
        'Else

        '    If GrupoDeCuentas.Trim <> "" Then

        '        dtView = New DataView(ds.Tables(0), "TIPO_CLIENTE = '" & GrupoDeCuentas & "'", "KUNNR", DataViewRowState.CurrentRows)

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

    Private Function GetTipoCliente(ByVal CodTipoVenta As String) As Integer
        Dim tipoCliente As Integer = 0
        Select Case CodTipoVenta.ToUpper()
            Case "D"
                tipoCliente = 1
            Case Is <> String.Empty '"C", "P", "F", "O", "I", "V", "A", "K"
                tipoCliente = 2
            Case ""
                tipoCliente = 3
        End Select
        Return tipoCliente
    End Function

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenFromSAPRecordDialogViewClientes.SetupView

        With TargetGridEx.Tables("TZCOMPRADORESFILTRADA")

            For intCol As Integer = 0 To .Columns.Count - 1
                .Columns(intCol).Visible = False
            Next

            .Columns("KUNNR").Caption = "Código SAP"
            .Columns("KUNNR").Width = 100
            .Columns("KUNNR").HeaderAlignment = TextAlignment.Center
            .Columns("KUNNR").Visible = True

            .Columns("NAME1").Caption = "Nombre"
            .Columns("NAME1").Width = 150
            .Columns("NAME1").HeaderAlignment = TextAlignment.Center
            .Columns("NAME1").Visible = True

            .Columns("NAME2").Caption = "Apellido Paterno"
            .Columns("NAME2").Width = 90
            .Columns("NAME2").HeaderAlignment = TextAlignment.Center
            .Columns("NAME2").Visible = True

            .Columns("NAME3").Caption = "Apellido Materno"
            .Columns("NAME3").Width = 90
            .Columns("NAME3").HeaderAlignment = TextAlignment.Center
            .Columns("NAME3").Visible = True

            .Columns("TIPO_CLIENTE").Caption = "GrupoDeCuentas"

        End With

    End Sub

End Class
