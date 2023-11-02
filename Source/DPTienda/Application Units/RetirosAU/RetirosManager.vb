Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class RetirosManager

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

    Public Function Create() As Retiros

        Dim oNuevoRetiros As Retiros
        oNuevoRetiros = New Retiros(Me)

        Return oNuevoRetiros

    End Function

    Public Function Load(ByVal ID As Integer) As Retiros

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        Return oCatalogoRetirosDG.Select(ID)

    End Function

    Public Sub LoadInto(ByVal ID As Integer, ByVal Retiros As Retiros)

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        oCatalogoRetirosDG.Select(ID, Retiros)

        oCatalogoRetirosDG = Nothing

    End Sub

    Public Sub Save(ByVal pRetiros As Retiros)

        Dim oCatalogoRetirosDG As New RetirosDataGateway(Me)

        If (pRetiros.IsNew) Then
            oCatalogoRetirosDG.Insert(pRetiros)
        Else
            oCatalogoRetirosDG.Update(pRetiros)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        oCatalogoRetirosDG.Delete(ID)

        oCatalogoRetirosDG = Nothing

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        Return oCatalogoRetirosDG.Select(EnabledRecordsOnly)

    End Function

    Public Function SelectByDate(ByVal Fecha As DateTime) As String()

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        Return oCatalogoRetirosDG.Select(Fecha)

    End Function

    Public Function GetAllBancos(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        Return oCatalogoRetirosDG.SelectBancos(EnabledRecordsOnly)

    End Function

    Public Function [SelectFolio]() As Integer

        Dim oCatalogoRetirosDG As RetirosDataGateway
        oCatalogoRetirosDG = New RetirosDataGateway(Me)

        Return oCatalogoRetirosDG.SelectFolio

    End Function

#End Region

End Class
