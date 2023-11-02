Imports DportenisPro.DPTienda.Core

Public Class AsociadosManager

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

    Public Function Create() As Asociado

        Dim oNuevoAsociado As Asociado
        oNuevoAsociado = New Asociado(Me)

        Return oNuevoAsociado

    End Function

    'Public Function Load(ByVal ID As Integer) As Asociado

    '    Dim oAsociadosDG As AsociadosWSProxy
    '    oAsociadosDG = New AsociadosWSProxy

    '    Return oAsociadosDG.Select(ID)

    'End Function

    Public Sub [LoadInto](ByVal ID As Integer, ByVal pAsociado As Asociado)

        Dim oAsociadosDG As AsociadosWSProxy
        oAsociadosDG = New AsociadosWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oAsociadosDG.oWSAsociados.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & oAsociadosDG.oWSAsociados.strURL.TrimStart(CChar("/"))

        End If

        oAsociadosDG.Select(ID, pAsociado)

        oAsociadosDG = Nothing

    End Sub

    Public Sub [LoadIntoByClienteID](ByVal ClienteID As Integer, ByVal pAsociado As Asociado)

        Dim oAsociadosDG As AsociadosWSProxy
        oAsociadosDG = New AsociadosWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oAsociadosDG.oWSAsociados.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & oAsociadosDG.oWSAsociados.strURL.TrimStart(CChar("/"))

        End If

        oAsociadosDG.SelectByClienteID(ClienteID, pAsociado)

        oAsociadosDG = Nothing

    End Sub

    Public Function Save(ByVal AsociadoID As Integer, ByVal pAsociado As Asociado) As Integer

        Dim oAsociadosDG As New AsociadosWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oAsociadosDG.oWSAsociados.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & oAsociadosDG.oWSAsociados.strURL.TrimStart(CChar("/"))

        End If

        If (pAsociado.IsNew) Then

            Return oAsociadosDG.Insert(pAsociado)

        Else

            oAsociadosDG.Update(AsociadoID, pAsociado)

            Return AsociadoID

        End If

    End Function

    Public Sub Delete(ByVal AsociadoID As Integer)

        Dim oAsociadosDG As AsociadosWSProxy
        oAsociadosDG = New AsociadosWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oAsociadosDG.oWSAsociados.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & oAsociadosDG.oWSAsociados.strURL.TrimStart(CChar("/"))

        End If

        oAsociadosDG.Delete(AsociadoID)

        oAsociadosDG = Nothing

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oAsociadosDG As AsociadosWSProxy
        oAsociadosDG = New AsociadosWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oAsociadosDG.oWSAsociados.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimEnd(CChar("/")) _
            '                   & "/" & oAsociadosDG.oWSAsociados.strURL.TrimStart(CChar("/"))

        End If

        Return oAsociadosDG.Select(EnabledRecordsOnly)

    End Function

#End Region

End Class