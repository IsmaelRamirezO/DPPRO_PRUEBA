Imports DportenisPro.DPTienda.Core

Public Class TomadeInventarioManager

    Private oApplicationContext As ApplicationContext
    Private oTomaInventarioDG As TomadeInventarioDataGateway

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oTomaInventarioDG = New TomadeInventarioDataGateway(Me)

    End Sub

    Public Sub Dispose()

        MyBase.Finalize()

        oTomaInventarioDG = Nothing

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

    Public Function Create() As TomadeInventarioInfo

        Dim oNuevoTomaInventario As TomadeInventarioInfo
        oNuevoTomaInventario = New TomadeInventarioInfo(Me)

        Return oNuevoTomaInventario

    End Function

    Public Sub LoadInto(ByVal intFolio As Integer, ByVal oTomadeInventario As TomadeInventarioInfo)

        oTomaInventarioDG.LoadInto(intFolio, oTomadeInventario)

    End Sub

    Public Sub Save(ByVal oTomadeInventario As TomadeInventarioInfo)

        If (oTomadeInventario.IsNew) Then

            oTomaInventarioDG.Insert(oTomadeInventario)

        End If

    End Sub

    Public Function GetFolio() As Integer

        Return oTomaInventarioDG.GetFolioTomaInventario

    End Function

    Public Function GetStockTotal(ByVal CodAlmacen As String, _
                            ByVal CodArticulo As String, _
                                ByVal Talla As String) As Integer

        Return oTomaInventarioDG.LoadStockTotal(CodAlmacen, CodArticulo, Talla)

    End Function

    Public Function UserDescription(ByVal strUser As String) As String

        Return oTomaInventarioDG.GetUserDescription(strUser)

    End Function

#End Region

End Class
