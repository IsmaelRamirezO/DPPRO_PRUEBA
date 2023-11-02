Imports DportenisPro.DPTienda.Core

Public Class CatalogoUPCManager

    Dim oApplicationContext As ApplicationContext
    Dim oConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos
    Private oCatalogoMarcasDG As CatalogoUPCDataGateway

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Public ReadOnly Property SaveConfigArchivos() As ConfigSaveArchivos.SaveConfigArchivos
        Get
            Return oConfigCierreFI
        End Get
    End Property

#Region "Constructors / Destructors"
    Public Sub New(ByVal ApplicationContext As ApplicationContext,ByVal SaveConfigArchivos as ConfigSaveArchivos.SaveConfigArchivos )
        oApplicationContext = ApplicationContext
        oConfigCierreFI = SaveConfigArchivos
    End Sub

    Public Sub dispose()
        MyBase.Finalize()
        oCatalogoMarcasDG = Nothing
    End Sub
#End Region


#Region "Methods"

    Public Function Create() As UPC
        Dim oNuevoUPC As UPC
        oNuevoUPC = New UPC(Me)
        Return oNuevoUPC
    End Function

    Public Function Load(ByVal ID As String) As UPC
        Dim oUPC As New UPC(Me)
        Dim oUPC2 As New DataSet

        Dim oCatalogoUPCDG As CatalogoUPCDataGateway
        oCatalogoUPCDG = New CatalogoUPCDataGateway(Me)

        oUPC = oCatalogoUPCDG.Select(ID.PadLeft(18, "0"))
        If oUPC.CodArticulo = String.Empty Then
            'Buscamos código en Operaciones
            'oUPC2 = oCatalogoUPCDG.SelectOper2(ID.PadLeft(18, "0"))
            'If oUPC2.Tables(0).Rows.Count > 0 Then
            '    oCatalogoUPCDG.InsertarUPC_From_Separaciones(oUPC2)
            'End If
            'oUPC = oCatalogoUPCDG.Select(ID.PadLeft(18, "0"))
            Return oUPC
        Else
            Return oUPC
        End If
    End Function

    Public Function Load2(ByVal ID As String) As DataTable
        Dim oUPC As New DataSet

        Dim oCatalogoUPCDG As CatalogoUPCDataGateway
        oCatalogoUPCDG = New CatalogoUPCDataGateway(Me)

        oUPC = oCatalogoUPCDG.Select2(ID)
        If oUPC.Tables(0).Rows.Count <= 0 Then
            'Buscamos código en Operaciones
            oUPC = oCatalogoUPCDG.SelectOper2(ID)
            If oUPC.Tables(0).Rows.Count > 0 Then
                oCatalogoUPCDG.InsertarUPC_From_Separaciones(oUPC)
            End If
            oUPC = oCatalogoUPCDG.Select2(ID)
            Return oUPC.Tables(0)
        Else
            Return oUPC.Tables(0)
        End If
    End Function

    Public Function IsSkuOrMaterial(ByVal Code As String) As String
        Dim oCatalogoUPCDG As CatalogoUPCDataGateway
        oCatalogoUPCDG = New CatalogoUPCDataGateway(Me)
        Return oCatalogoUPCDG.IsSkuOrMaterial(Code)
    End Function

#End Region

End Class
