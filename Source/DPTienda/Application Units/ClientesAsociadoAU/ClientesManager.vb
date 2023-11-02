Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.ConfiguracionSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos

Public Class ClientesManager

    Dim oApplicationContext As ApplicationContext
    Dim oSAPConfiguration As SAPApplicationConfig
    Dim oConfigCierreFI As SaveConfigArchivos

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

    Public ReadOnly Property ConfigCierreFI() As SaveConfigArchivos
        Get
            Return oConfigCierreFI
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext, Optional ByVal SAPConfiguration As SAPApplicationConfig = Nothing, Optional ByVal ConfigCierre As SaveConfigArchivos = Nothing)

        oApplicationContext = ApplicationContext
        oSAPConfiguration = SAPConfiguration
        oConfigCierreFI = ConfigCierre

    End Sub

#End Region

#Region "Methods Web Service"

    Public Function Create() As Clientes

        Dim oNuevoCliente As Clientes
        oNuevoCliente = New Clientes(Me)

        Return oNuevoCliente

    End Function

    Public Function CreateAlterno() As ClienteAlterno

        Dim oNuevoCliente As ClienteAlterno
        oNuevoCliente = New ClienteAlterno(Me)

        Return oNuevoCliente

    End Function

    Public Sub LoadInto(ByVal ID As Integer, ByVal Cliente As Clientes)

        Dim oClientesWSProxy As ClientesWSProxy
        oClientesWSProxy = New ClientesWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oClientesWSProxy.oWSClientes.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimStart("/") & "/" & _
            'oClientesWSProxy.oWSClientes.strURL.TrimEnd("/")

        End If

        oClientesWSProxy.Select(ID, Cliente)

        oClientesWSProxy = Nothing

        'MsgBox("No debe entrar ClientesManager.VB Linea 66")

    End Sub

    Public Sub LoadInto(ByVal ID As Integer, ByVal Cliente As ClienteAlterno)

        'Dim oClientesWSProxy As ClientesWSProxy
        'oClientesWSProxy = New ClientesWSProxy

        'If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

        '    oClientesWSProxy.oWSClientes.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimStart("/") & "/" & _
        '    oClientesWSProxy.oWSClientes.strURL.TrimEnd("/")

        'End If

        'oClientesWSProxy.Select(ID, Cliente)

        'oClientesWSProxy = Nothing

        'MsgBox("No debe entrar ClientesManager.VB Linea 66")
    End Sub

    Public Function Save(ByVal Cliente As Clientes) As Integer

        Dim oClientesWSProxy As ClientesWSProxy
        oClientesWSProxy = New ClientesWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oClientesWSProxy.oWSClientes.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimStart("/") & "/" & _
            'oClientesWSProxy.oWSClientes.strURL.TrimEnd("/")

        End If


        If (Cliente.IsNew) Then

            Return oClientesWSProxy.Insert(Cliente)

        Else

            oClientesWSProxy.Update(Cliente)

        End If

    End Function



    Public Sub Delete(ByVal ID As Integer)

        Dim oClientesWSProxy As ClientesWSProxy
        oClientesWSProxy = New ClientesWSProxy

        If Not ApplicationContext.ApplicationConfiguration.WSUrl = String.Empty Then

            'oClientesWSProxy.oWSClientes.Url = ApplicationContext.ApplicationConfiguration.WSUrl.TrimStart("/") & "/" & _
            'oClientesWSProxy.oWSClientes.strURL.TrimEnd("/")

        End If


        oClientesWSProxy.Delete(ID)

        oClientesWSProxy = Nothing

    End Sub

    'Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

    Public Function GetAll(ByVal strSelCriterio As String, ByVal strCriterio As String, ByVal GrupoDeCuentas As String) As DataSet

        Dim oClientes As New ClientesDataGateWay(Me)
        Return oClientes.SelectByFiltro(strSelCriterio, strCriterio, GrupoDeCuentas)

    End Function

    Public Function GetAllPG(ByVal strCriterio As String) As DataTable

        Dim oClientes As New ClientesDataGateWay(Me)
        Return oClientes.SelectByFiltroPG(strCriterio)

    End Function

    Public Function GetAllPGFromServer(ByVal strCriterio As String) As DataTable

        Dim oClientes As New ClientesDataGateWay(Me)
        Return oClientes.SelectByFiltroPGFromServer(strCriterio)

    End Function

    Public Function GetCongif(ByVal param As String) As String

        Dim oClientesDG = New ClientesDataGateWay(Me)

        Return oClientesDG.SelectConfig(param)

    End Function

#End Region

#Region "Methods Extended"

    Public Function GetAllStates(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.LoadAllStates(EnabledRecordsOnly)

        oClientesExtendedDG = Nothing

    End Function

    Public Function GetAllMunicipio(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.LoadAllMunicipio(EnabledRecordsOnly)

        oClientesExtendedDG = Nothing

    End Function

    Public Function GetZipCode(ByVal CodEstado As Integer, ByVal CodCiudad As Integer, ByVal CodPostal As String) As Boolean

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.LoadZipCode(CodEstado, CodCiudad, CodPostal)

        oClientesExtendedDG = Nothing

    End Function

    Public Function GetRange(ByVal ID As String, ByVal CodMuni As Integer) As DataSet

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.Select(ID, CodMuni)

        oClientesExtendedDG = Nothing

    End Function

    Public Function GetAllPlazas(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.LoadAllPlazas(EnabledRecordsOnly)

        oClientesExtendedDG = Nothing

    End Function

    Public Function GetAllAlmacenes(ByVal EnabledRecordsOnly As Boolean) As DataTable

        Dim oClientesExtendedDG As ClientesExtendedDataGateway
        oClientesExtendedDG = New ClientesExtendedDataGateway(Me)

        Return oClientesExtendedDG.LoadAllAlmacen(EnabledRecordsOnly)

        oClientesExtendedDG = Nothing

    End Function

#End Region

#Region "Cliente Alterno"

    Public Function Save(ByVal Cliente As ClienteAlterno, ByVal EsDPVale As Boolean, ByVal ExisteClienteRetail As Boolean) As Boolean

        Dim oClientes As ClientesDataGateWay
        oClientes = New ClientesDataGateWay(Me)

        If (Cliente.IsNew) Then

            If oClientes.Insert(Cliente, EsDPVale) Then

                Return True

            Else

                Return False

            End If


        Else

            If oClientes.Update(Cliente, EsDPVale) Then

                Return True

            Else

                Return False

            End If

        End If

    End Function


    Public Function GetClienteByRFC(ByVal RFC As String) As DataTable

        Dim oClientesDG As New ClientesDataGateWay(Me)

        Return oClientesDG.SelectClienteByRFC(RFC)

    End Function

    Public Function ExisteCorreoCliente(ByVal Email As String, ByRef strError As String) As Boolean

        Dim oClientesDG As New ClientesDataGateWay(Me)

        Return oClientesDG.SelectEmail(Email, 0, strError)

    End Function

    Public Function SaveEmailCliente(ByVal ClienteID As String, ByVal Email As String, ByRef strError As String) As Integer

        Dim oClientesDG As New ClientesDataGateWay(Me)

        Return oClientesDG.InsertEmailClienteInServer(ClienteID, Email, strError)

    End Function

    Public Sub UpdateSAPX(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
                            ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
                            , ByVal strColonia As String)

        Dim oClientes As ClientesDataGateWay
        oClientes = New ClientesDataGateWay(Me)

        oClientes.UpdateSAPX(strClienteID, strCalleNum, strCp, strPoblacion, strEstado, strTelefono, stremail, strColonia)


    End Sub

    Public Function ActualizaClientes(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
                    ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
                    , ByVal strColonia As String) As String

        Dim oClientes As ClientesDataGateWay
        oClientes = New ClientesDataGateWay(Me)

        Return oClientes.ActualizaClientes(strClienteID, strCalleNum, strCp, strPoblacion, strEstado, strTelefono, stremail, strColonia)


    End Function


    Public Function Load(ByVal ID As String, ByRef oCliente As ClienteAlterno, Optional ByVal strTipoVenta As String = "") As ClienteAlterno

        Dim oClientesDG As ClientesDataGateWay
        oClientesDG = New ClientesDataGateWay(Me)

        Return oClientesDG.SelectByID(ID, oCliente, strTipoVenta)

    End Function

    Public Function LoadPG(ByVal ID As String, ByRef oCliente As ClienteAlterno) As ClienteAlterno

        Dim oClientesDG As ClientesDataGateWay
        oClientesDG = New ClientesDataGateWay(Me)

        Return oClientesDG.SelectByIDPG(ID, oCliente)

    End Function

    Public Function LoadPGFromServer(ByVal ID As String, ByRef oCliente As ClienteAlterno) As ClienteAlterno

        Dim oClientesDG As ClientesDataGateWay
        oClientesDG = New ClientesDataGateWay(Me)

        Return oClientesDG.SelectByIDPGFromServer(ID, oCliente)

    End Function

    Public Function GetRFC(ByVal oCliente As ClienteAlterno) As String

        Dim oClientes As ClientesDataGateWay
        oClientes = New ClientesDataGateWay(Me)

        Return oClientes.GetRFC(oCliente)

    End Function

    Public Function GetTipoVenta(ByVal IDCliente As String) As String

        Dim oClienteDG As ClientesDataGateWay
        oClienteDG = New ClientesDataGateWay(Me)

        Return oClienteDG.GetTipoVenta(IDCliente)

    End Function

#End Region

#Region " Proyecto SiHay "
    '--------------------------------------------------------------------------------------------
    'JNAVA (20/05/2013) - Concretar Cita del cliente para el pedido insurtible
    '--------------------------------------------------------------------------------------------
    Public Sub SaveConcretarCitaSH(ByVal FolioPedido As String, ByVal FechaCita As Date)

        Dim oClientesDG As ClientesDataGateWay
        oClientesDG = New ClientesDataGateWay(Me)

        oClientesDG.InsertConcretarCitaSH(FolioPedido, FechaCita)

        oClientesDG = Nothing

    End Sub

#End Region

#Region "DPVALE AFS"

#End Region

End Class
