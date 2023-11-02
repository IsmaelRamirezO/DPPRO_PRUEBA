Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports Janus.Windows.GridEX
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas


Public Class DefectuososEcommerceOpenRecordDialogView
    Implements IOpenRecordDialogView2



    Public Function FieldCodigo() As String Implements IOpenRecordDialogView2.FieldCodigo

        Return "Código"

    End Function



    Public Function FieldDescripcion() As String Implements IOpenRecordDialogView2.FieldDescripcion

        Return "Descripción"

    End Function

    Public Function FieldCodProveedor() As String Implements IOpenRecordDialogView2.FieldCodProveedor
        Return "CodArtProv"
    End Function



    Public Function SetupDataBinding() As System.Data.DataSet Implements IOpenRecordDialogView2.SetupDataBinding

        Dim oFacturaMgr As FacturaManager
        Dim dsDataSource As New DataSet
        Dim dtDef As DataTable
        Dim oSapMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim oArtMgr As New CatalogoArticuloManager(oAppContext)
        Dim oArtTemp As Articulo
        Dim dtTemp As New DataTable("CatalogoArticulos")
        Dim oNewRow As DataRow, Codigos As String = ""

        'dtDef = oSapMgr.ZPOL_GET_DEFT_CENTRO
        oFacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        'dtDef = GetCodigosDefectuososEC()
        dtDef = oFacturaMgr.BajaCalidadSel
        dtTemp.Columns.Add("Código", GetType(String))
        dtTemp.Columns.Add("Proveedor", GetType(String))
        dtTemp.Columns.Add("Descripcion", GetType(String))
        dtTemp.AcceptChanges()

        For Each oRow As DataRow In dtDef.Rows
            If InStr(Codigos.Trim, CStr(oRow!Material).Trim) <= 0 Then
                Codigos &= CStr(oRow!Material).Trim & ","
                oArtTemp = Nothing
                oArtTemp = oArtMgr.Load(CStr(oRow!MATERIAL).Trim)
                If Not oArtTemp Is Nothing Then
                    oNewRow = dtTemp.NewRow
                    oNewRow!Código = oArtTemp.CodArticulo.Trim
                    oNewRow!Proveedor = oArtTemp.CodArtProv.Trim
                    oNewRow!Descripcion = oArtTemp.Descripcion.Trim
                    dtTemp.Rows.Add(oNewRow)
                End If
            End If
        Next

        dsDataSource.Tables.Add(dtTemp)

        Return dsDataSource

    End Function

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView2.SetupView

        With TargetGridEx.Tables("CatalogoArticulos")

            .Columns("Código").Caption = "Código"
            .Columns("Código").Width = 150
            .Columns("Código").HeaderAlignment = TextAlignment.Center

            .Columns("Descripcion").Caption = "Descripcion"
            .Columns("Descripcion").Width = 270
            .Columns("Descripcion").HeaderAlignment = TextAlignment.Center

        End With

    End Sub

End Class
