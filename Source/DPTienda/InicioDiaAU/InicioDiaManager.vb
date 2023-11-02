Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU

Public Class InicioDiaManager

    Private m_bBanderaDesc As Boolean = False

    Dim oApplicationContext As ApplicationContext
    Dim oSAPConfiguration As SAPApplicationConfig

#Region "ApplicationContext"

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

    Public ReadOnly Property SAPApplicationConfig() As SAPApplicationConfig
        Get
            Return oSAPConfiguration
        End Get
    End Property
    Public Property BanderaDesc() As Boolean
        Get
            Return m_bBanderaDesc
        End Get
        Set(ByVal Value As Boolean)
            m_bBanderaDesc = Value
        End Set
    End Property
#End Region


#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As InicioDia

        Dim oNuevoInicioDia As InicioDia
        oNuevoInicioDia = New InicioDia(Me)

        Return oNuevoInicioDia

    End Function

    Public Function Load(ByVal FechaInicioDia As Date, ByVal CodAlmacen As String) As Integer

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.Select(FechaInicioDia, CodAlmacen)

    End Function



    Public Sub LoadInto(ByVal oInicioDia As InicioDia)

        'Dim oInicioDiaDG As InicioDiaDataGateway
        'oInicioDiaDG = New InicioDiaDataGateway(Me)

        'oInicioDiaDG.Select(oInicioDia)

        'oInicioDiaDG = Nothing

    End Sub

    Public Sub Save(ByVal oInicioDia As InicioDia)

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        If oInicioDia.IsNew Then

            oInicioDiaDG.Insert(oInicioDia)

        Else

            oInicioDiaDG.Update(oInicioDia)

        End If

    End Sub

    Public Sub InventarioInicial(ByVal oInicioDia As InicioDia)

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)



        oInicioDiaDG.InventarioInicial(oInicioDia)

    End Sub

    Public Function SelectBitacora(ByVal Fecha As Date) As DataSet

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)
        Return oInicioDiaDG.SelectBitacora(Fecha)

    End Function

    Public Sub SetCargasIniciales()

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        oInicioDiaDG.SetCargasIniciales()

        oInicioDiaDG = Nothing

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        oInicioDiaDG.Delete(ID)

        oInicioDiaDG = Nothing

    End Sub

    Public Function ValidaCierreDia(ByVal CodAlmacen As String) As InicioDia

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.ValidaCierreDia(CodAlmacen)

        oInicioDiaDG = Nothing
    End Function


    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        Return (oInicioDiaDG.Select(EnabledRecordsOnly))

    End Function

    Public Function GetDateBeginDay() As Date

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        Return (oInicioDiaDG.SelectDateBeginDay)

    End Function

    Public Function ObetenerPreciosyDescuentos(ByVal group As Boolean, ByVal IntdescIni As Integer, ByVal IntDescFin As Integer, Optional ByVal bolaccText As Boolean = False) As DataSet

        Dim oInicioDiaDG As InicioDiaDataGateway
        oInicioDiaDG = New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.ObetenerPreciosyDescuentos(group, IntdescIni, IntDescFin, bolaccText)

    End Function

    Public Function ValidaPassword(ByVal Password As String, ByRef Message As String) As Boolean

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.ValidaPassword(Password, Message)

    End Function

    Public Sub RenuevaPassword(ByVal Password As String, ByVal UserID As Integer)

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        oInicioDiaDG.SaveNewPassword(Password, UserID)

        oInicioDiaDG = Nothing

    End Sub

    Public Function ValidaRenuevaPassword(ByVal UserID As Integer) As Boolean

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.IsNeedNewPassword(UserID)

    End Function

    Public Function GetHistorialUserPasswords(ByVal UserID As Integer) As DataTable

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.GetHistorialUserPasswords(UserID)

    End Function

    Public Function GetTablasIniciales(ByVal Tabla As String) As DataTable

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        Return oInicioDiaDG.GetTablasInicialesRecord(Tabla)

    End Function

    Public Sub InsertTabla(ByVal Tabla As String)

        Dim oInicioDiaDG As New InicioDiaDataGateway(Me)

        oInicioDiaDG.InsertTabla(Tabla)

        oInicioDiaDG = Nothing


    End Sub

#End Region

    

End Class
