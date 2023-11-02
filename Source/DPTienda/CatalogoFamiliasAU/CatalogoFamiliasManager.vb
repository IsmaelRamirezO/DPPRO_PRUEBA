Imports DportenisPro.DPTienda.Core



Public Class CatalogoFamiliasManager

    Dim oApplicationContext As ApplicationContext

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)
        oApplicationContext = ApplicationContext
    End Sub

#End Region

#Region "Methods"

    Public Function Create() As Familias


        Dim oNuevoFamilias As Familias

        oNuevoFamilias = New Familias(Me)

        Return oNuevoFamilias

    End Function

    Public Function Load(ByVal ID As String) As Familias

        Dim oCatalogoFamiliasDG As CatalogoFamiliasDataGateway

        oCatalogoFamiliasDG = New CatalogoFamiliasDataGateway(Me)

        Return oCatalogoFamiliasDG.SelectByID(ID)

    End Function

    Public Sub Save(ByVal pFamilias As Familias)

        Dim oCatalogoFamiliasDG As New CatalogoFamiliasDataGateway(Me)

        If (pFamilias.IsNew) Then
            oCatalogoFamiliasDG.Insert(pFamilias)
        Else
            oCatalogoFamiliasDG.Update(pFamilias)
        End If

    End Sub

    Public Sub Delete(ByVal ID As String)

        Dim oCatalogoFamiliasDG As CatalogoFamiliasDataGateway

        oCatalogoFamiliasDG = New CatalogoFamiliasDataGateway(Me)

        oCatalogoFamiliasDG.Delete(ID)

        oCatalogoFamiliasDG = Nothing

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oCatalogoFamiliasDG As CatalogoFamiliasDataGateway


        oCatalogoFamiliasDG = New CatalogoFamiliasDataGateway(Me)

        Return oCatalogoFamiliasDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

End Class



