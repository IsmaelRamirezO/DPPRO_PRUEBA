Imports DportenisPro.DPTienda.ApplicationUnits.Clientes.wsCRM.Clientes

Public Class ClientesWSProxy

    'Web Method - DataGateWay
    'Public oWSClientes As CRMClientes

    'Web Fields
    'Private oDatosClientes As ClienteInfo

    Public Sub New()
        'oWSClientes = New CRMClientes
        
    End Sub


#Region "Methods"

    Public Function Insert(ByVal Cliente As Clientes) As Integer

        ''Set Values for Insert
        'oDatosClientes = New ClienteInfo
        'oDatosClientes.ClienteID = 0
        'oDatosClientes.Nombre = Cliente.Nombre
        'oDatosClientes.ApellidoPaterno = Cliente.ApellidoPaterno
        'oDatosClientes.ApellidoMaterno = Cliente.ApellidoMaterno
        'oDatosClientes.Sexo = Cliente.Sexo
        'oDatosClientes.EstadoCivil = Cliente.EstadoCivil
        'oDatosClientes.Domicilio = Cliente.Domicilio
        'oDatosClientes.Estado = Cliente.Estado
        'oDatosClientes.Ciudad = Cliente.Ciudad
        'oDatosClientes.Colonia = Cliente.Colonia
        'oDatosClientes.CodigoPostal = Cliente.CP
        'oDatosClientes.Telefono = Cliente.Telefono
        'oDatosClientes.FechaNacimiento = Cliente.FechaNac
        'oDatosClientes.Email = Cliente.Email
        'oDatosClientes.AlmacenID = Cliente.CodAlmacen
        'oDatosClientes.PlazaID = Cliente.CodPlaza
        'oDatosClientes.CedulaFiscal = Cliente.CedulaFiscal
        'oDatosClientes.DatosFiscalesNombre = "No Aplica"
        'oDatosClientes.DatosFiscalesDomicilio = "No Aplica"
        'oDatosClientes.DatosFiscalesColonia = "No Aplica"
        'oDatosClientes.DatosFiscalesCiudad = "No Aplica"
        'oDatosClientes.DatosFiscalesEstado = "No Aplica"
        'oDatosClientes.DatosFiscalesCodigoPostal = "00000"
        'oDatosClientes.EmitirleFacturas = Cliente.Facturar
        'oDatosClientes.EsAsociado = Cliente.EsAsociado
        'oDatosClientes.EsSocioClubDP = Cliente.EsSocioClubDP
        'oDatosClientes.EsFacilito = Cliente.EsFacilito
        'oDatosClientes.EsFonacot = Cliente.EsFonacot
        'oDatosClientes.RecordCreatedBy = Cliente.RecordCreatedBy
        'oDatosClientes.RecordCreatedOn = Now.ToShortTimeString
        'oDatosClientes.RecordStatus = True
        ''Call Web Service for Insert
        'Return oWSClientes.CreateCliente(oDatosClientes)

    End Function

    Public Sub Update(ByVal Cliente As Clientes)

        ''Set Values for Insert
        'oDatosClientes = New ClienteInfo
        'oDatosClientes.ClienteID = Cliente.ClienteID
        'oDatosClientes.Nombre = Cliente.Nombre
        'oDatosClientes.ApellidoPaterno = Cliente.ApellidoPaterno
        'oDatosClientes.ApellidoMaterno = Cliente.ApellidoMaterno
        'oDatosClientes.Sexo = Cliente.Sexo
        'oDatosClientes.EstadoCivil = Cliente.EstadoCivil
        'oDatosClientes.Domicilio = Cliente.Domicilio
        'oDatosClientes.Estado = Cliente.Estado
        'oDatosClientes.Ciudad = Cliente.Ciudad
        'oDatosClientes.Colonia = Cliente.Colonia
        'oDatosClientes.CodigoPostal = Cliente.CP
        'oDatosClientes.Telefono = Cliente.Telefono
        'oDatosClientes.FechaNacimiento = Cliente.FechaNac
        'oDatosClientes.Email = Cliente.Email
        'oDatosClientes.AlmacenID = Cliente.CodAlmacen
        'oDatosClientes.PlazaID = Cliente.CodPlaza
        'oDatosClientes.CedulaFiscal = Cliente.CedulaFiscal
        'oDatosClientes.DatosFiscalesNombre = Cliente.DFNombre
        'oDatosClientes.DatosFiscalesDomicilio = Cliente.DFDireccion
        'oDatosClientes.DatosFiscalesColonia = Cliente.DFColonia
        'oDatosClientes.DatosFiscalesCiudad = Cliente.DFCiudad
        'oDatosClientes.DatosFiscalesEstado = Cliente.DFEstado
        'oDatosClientes.DatosFiscalesCodigoPostal = Cliente.DFCP
        'oDatosClientes.EmitirleFacturas = Cliente.Facturar
        'oDatosClientes.EsAsociado = Cliente.EsAsociado
        'oDatosClientes.EsSocioClubDP = Cliente.EsSocioClubDP
        'oDatosClientes.EsFacilito = Cliente.EsFacilito
        'oDatosClientes.EsFonacot = Cliente.EsFonacot
        'oDatosClientes.RecordCreatedBy = Cliente.RecordCreatedBy
        'oDatosClientes.RecordCreatedOn = Cliente.RecordCreatedOn
        'oDatosClientes.RecordStatus = Cliente.RecordEnabled

        ''Call Web Service for Update
        'oWSClientes.UpdateCliente(oDatosClientes)

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        'Call Web Service for Load
        'oWSClientes.DeleteCliente(ID)

    End Sub

    Public Sub [Select](ByVal ID As Integer, ByVal Cliente As Clientes)

        'oDatosClientes = New ClienteInfo

        'Call Web Service for Load
        'oDatosClientes = oWSClientes.GetCliente(ID)

        'If (oDatosClientes.ClienteID = 0) Then

        '    Cliente.ClienteID = 0

        'Else

        '    Cliente.ClienteID = oDatosClientes.ClienteID
        '    Cliente.Nombre = oDatosClientes.Nombre
        '    Cliente.ApellidoPaterno = oDatosClientes.ApellidoPaterno
        '    Cliente.ApellidoMaterno = oDatosClientes.ApellidoMaterno
        '    Cliente.Sexo = oDatosClientes.Sexo
        '    Cliente.EstadoCivil = oDatosClientes.EstadoCivil
        '    Cliente.Domicilio = oDatosClientes.Domicilio
        '    Cliente.Estado = oDatosClientes.Estado
        '    Cliente.Ciudad = oDatosClientes.Ciudad
        '    Cliente.Colonia = oDatosClientes.Colonia
        '    Cliente.CP = oDatosClientes.CodigoPostal
        '    Cliente.Telefono = oDatosClientes.Telefono
        '    Cliente.FechaNac = oDatosClientes.FechaNacimiento
        '    Cliente.Email = oDatosClientes.Email
        '    Cliente.CodAlmacen = oDatosClientes.AlmacenID
        '    Cliente.CodPlaza = oDatosClientes.PlazaID
        '    Cliente.CedulaFiscal = oDatosClientes.CedulaFiscal
        '    Cliente.DFNombre = oDatosClientes.DatosFiscalesNombre
        '    Cliente.DFDireccion = oDatosClientes.DatosFiscalesDomicilio
        '    Cliente.DFColonia = oDatosClientes.DatosFiscalesColonia
        '    Cliente.DFCiudad = oDatosClientes.DatosFiscalesCiudad
        '    Cliente.DFEstado = oDatosClientes.DatosFiscalesEstado
        '    Cliente.DFCP = oDatosClientes.DatosFiscalesCodigoPostal
        '    Cliente.Facturar = oDatosClientes.EmitirleFacturas
        '    Cliente.EsAsociado = oDatosClientes.EsAsociado
        '    Cliente.EsSocioClubDP = oDatosClientes.EsSocioClubDP
        '    Cliente.EsFacilito = oDatosClientes.EsFacilito
        '    Cliente.EsFonacot = oDatosClientes.EsFonacot
        '    Cliente.RecordCreatedBy = oDatosClientes.RecordCreatedBy
        '    Cliente.RecordCreatedOn = oDatosClientes.RecordCreatedOn
        '    Cliente.RecordEnabled = oDatosClientes.RecordStatus
        '    Cliente.SetFlagDirty()
        '    Cliente.ResetFlagNew()

        'End If

    End Sub

    'Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet
    Public Function [Select](ByVal strCodPlaza As String, ByVal strSelCriterio As String, ByVal strCriterio As String) As DataSet

        'Dim dsClientes As DataSet = New DataSet("Clientes")

        ''dsClientes = oWSClientes.GetClientes(EnabledRecordsOnly)

        'dsClientes = oWSClientes.GetClientesQuickSearchSomeFields(strCodPlaza, strSelCriterio, strCriterio)

        'Return dsClientes

    End Function

#End Region

End Class
