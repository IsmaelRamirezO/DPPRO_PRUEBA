Imports DportenisPro.DPTienda.Core

Public Class InicioCajaManager

    Dim oApplicationContext As ApplicationContext

#Region "ApplicationContext"

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#End Region

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As InicioCaja

        Dim oNuevoInicioCaja As InicioCaja
        oNuevoInicioCaja = New InicioCaja(Me)

        Return oNuevoInicioCaja

    End Function

    Public Function Load(ByVal CodCaja As String, ByVal InicioDiaID As Integer) As Integer

        Dim oInicioCajaDG As InicioCajaDataGateway
        oInicioCajaDG = New InicioCajaDataGateway(Me)

        Return oInicioCajaDG.Select(CodCaja, InicioDiaID)

    End Function

    Public Sub LoadInto(ByVal oIniciocaja As InicioCaja)

    End Sub

    Public Sub Save(ByVal oInicioCaja As InicioCaja)

        Dim oInicioCajaDG As InicioCajaDataGateway
        oInicioCajaDG = New InicioCajaDataGateway(Me)

        If (oInicioCaja.IsNew) Then

            oInicioCajaDG.Insert(oInicioCaja)

        Else

            oInicioCajaDG.Update(oInicioCaja)

        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

    End Sub

    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    End Function

#End Region

End Class
