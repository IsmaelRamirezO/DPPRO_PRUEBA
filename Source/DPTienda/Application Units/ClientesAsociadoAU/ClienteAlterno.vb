Imports DportenisPro.DPTienda.Core


Public Class ClienteAlterno

    Private m_intRazonRechazoID As Integer = 0

    Private m_strRazonNoEmail As String = ""

    Private m_strNumInt As String = ""

    Private m_strNumExt As String = ""

    Private m_intCodigoClienteDPVALE As Integer

    Private m_strNombreCompleto As String = ""

#Region "Object Status Flags"

    Private bolIsDirty As Boolean
    Private bolIsNew As Boolean

    Public Function IsDirty() As Boolean
        Return bolIsDirty
    End Function

    Public Function IsNew() As Boolean
        Return bolIsNew
    End Function

    Friend Sub SetFlagDirty()
        bolIsDirty = True
    End Sub

    Public Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Public Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Propiedades"

#Region "Fields"
    'Para parchar cuando pones el RFC y no se pierda
    Private m_strRFCMoral As String

    Private m_strEsEmpresa As Boolean = False
    Public Event EsEmpresaChanged As EventHandler

    Private m_strGrupoTesoreria As String

    Private m_strApellido As String
    Public Event ApellidoChanged As EventHandler

    Private m_strApellidoMaterno As String
    Public Event ApellidoMaternoChanged As EventHandler

    Private m_strApellidoPaterno As String
    Public Event ApellidoPaternoChanged As EventHandler

    Private m_bFiscal As Boolean
    Private Event FiscalChanged As EventHandler

    Private m_strIndicadorRelevante As String = "X"
    Private Event IndicadorRelevanteChanged As EventHandler

    Private m_strGrupoImputacion As String = "01"
    Public Event GrupoImputacionChanged As EventHandler

    Private m_strMaxEntregasParciales As String = "9"
    Public Event MaxEntregasParcialesChanged As EventHandler

    Private m_strIndicadorAgrupamiento As String = "X"
    Public Event IndicadorAgrupamientoChanged As EventHandler


    Private m_strPrioridadEntrega As String = "02"
    Public Event PrioridadEntregaChanged As EventHandler

    Private m_strTipoListaPrecios As String = "Z1"
    Public Event TipoListaPreciosChanged As EventHandler

    Private m_strGrupoPrecios As String = "01"
    Public Event GrupoPreciosChanged As EventHandler

    Private m_strGrupoCliente As String = "01"
    Public Event GrupoClienteChanged As EventHandler

    Private m_strDistrito As String = "MEXICO"
    Public Event DistritoChanged As EventHandler

    Private m_strClasificacacionFiscal As String = "1"
    Public Event ClasificacionFiscalChanged As EventHandler

    Private m_strCondicionExpedicion As String = "01"
    Public Event CondicionExpedicionChanged As EventHandler

    Private m_strGrupoEstadistica As String = "1"
    Public Event GrupoEstadisticaChanged As EventHandler

    Private m_strMoneda As String = "MXN"
    Public Event MonedaChanged As EventHandler

    Private m_strCodPlayer As String = "001"
    Public Event CodPlayerChanged As EventHandler

    Private m_strZonaVentas As String = ""
    Public Event ZonaVentasChanged As EventHandler

    Private m_strClaveCondicionesPago As String = "0001"
    Public Event ClaveCondicionesPagoChanged As EventHandler

    Private m_strCuentaContabilidad As String = "121000001"
    Public Event CuentaContabilidadChanged As EventHandler

    Private m_strClavePais As String = "MX"
    Public Event ClavePaisChanged As EventHandler

    Private m_strSector As String = "VG"
    Public Event SectorChanged As EventHandler

    Private m_strCanalDistribucion As String = "T1"
    Public Event CanalDistribucionChanged As EventHandler

    Private m_strOrganizacionVentas As String = "CDPT"
    Public Event OrganizacionVentasChanged As EventHandler

    Private m_strGrupoDeCuentas As String = ""
    Public Event GrupoDeCuentasChanged As EventHandler

    Private m_strEMail As String = ""
    Public Event EMailChanged As EventHandler

    Private m_strTelefono As String = ""
    Public Event TelefonoChanged As EventHandler

    Private m_strRFC As String = ""
    Public Event RFCChanged As EventHandler

    Private m_strSexo As String = ""
    Public Event SexoChanged As EventHandler

    Private m_strEstadoCivil As String = ""
    Public Event EstadoCivilChanged As EventHandler

    Private m_datFechaNacimiento As Date
    Public Event FechaNacimientoChanged As EventHandler

    Private m_intCP As String = ""
    Public Event CPChanged As EventHandler

    Private m_strEstado As String = ""
    Public Event EstadoChanged As EventHandler

    Private m_strCiudad As String = ""
    Public Event CiudadChanged As EventHandler

    Private m_strColonia As String = ""
    Public Event ColoniaChanged As EventHandler

    Private m_strDireccion As String = ""
    Public Event DireccionChanged As EventHandler

    Private m_strNombre As String = ""
    Public Event NombreChanged As EventHandler

    Private m_strTipoVenta As String = ""
    Public Event TipoVentaChanged As EventHandler

    Private m_strCodPlaza As String = ""
    Public Event CodPlazaChanged As EventHandler

    Private m_strCodAlmacen As String = ""
    Public Event CodAlmacenChanged As EventHandler

    Private m_strCodigoAlterno As String = ""
    Public Event CodigoAlternoChanged As EventHandler

    Private m_intCodigoCliente As Integer = 0
    Public Event CodigoClienteChanged As EventHandler

    Private m_I_SORTL As String = ""
    Public Event I_SORTLChanged As EventHandler

    Private m_bolGenerateRFC As Boolean = True

#End Region

#Region "Field Accessors"


    Public Property GrupoTesoreria() As String
        Get
            Return m_strGrupoTesoreria
        End Get
        Set(ByVal Value As String)
            m_strGrupoTesoreria = Value
        End Set
    End Property


    Public Property GenerateRFC() As Boolean
        Get
            Return m_bolGenerateRFC
        End Get
        Set(ByVal Value As Boolean)
            m_bolGenerateRFC = Value
        End Set
    End Property

    Public Property RFCMoral() As String
        Get
            Return m_strRFCMoral
        End Get
        Set(ByVal Value As String)
            m_strRFCMoral = Value
        End Set
    End Property

    Public Property I_SORTL() As String
        Get
            Return m_I_SORTL
        End Get
        Set(ByVal Value As String)
            m_I_SORTL = Value
            RaiseEvent I_SORTLChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodigoCliente() As Integer
        Get
            Return m_intCodigoCliente
        End Get
        Set(ByVal Value As Integer)
            m_intCodigoCliente = Value
            RaiseEvent CodigoClienteChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodigoAlterno() As String
        Get
            Return m_strCodigoAlterno
        End Get
        Set(ByVal Value As String)
            m_strCodigoAlterno = Value.PadLeft(10, "0")
            RaiseEvent CodigoAlternoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
            RaiseEvent CodAlmacenChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodPlaza() As String
        Get
            Return m_strCodPlaza
        End Get
        Set(ByVal Value As String)
            m_strCodPlaza = Value
            RaiseEvent CodPlazaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property TipoVenta() As String
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strTipoVenta = Value

            If Value.Trim = "D" OrElse Value.Trim = "DP" Then '"K" OrElse Value = "F" OrElse Value = "O" OrElse Value = "I" OrElse Value = "A" Then

                Me.GrupoDeCuentas = "D005"
                Me.ClaveCondicionesPago = "CP04"
                Me.ClasificacionFiscal = "1"
                Me.ZonaVentas = "000001"
                Me.GrupoCliente = "02"
                Me.GrupoPrecios = "01"
                Me.TipoListaPrecios = "01"
                Me.CuentaContabilidad = "112100001"

                'If Value = "F" Then
                '    Me.ZonaVentas = "FONA"
                '    Me.GrupoCliente = "09"
                '    Me.GrupoPrecios = "01"

                'ElseIf Value = "K" Then

                '    Me.ZonaVentas = "TFON"
                '    Me.GrupoCliente = "16"
                '    Me.GrupoPrecios = "01"

                'ElseIf Value = "O" Then

                '    Me.ZonaVentas = "FACI"
                '    Me.GrupoCliente = "10"
                '    Me.GrupoPrecios = "01"

                'ElseIf Value = "I" Then

                '    Me.GrupoDeCuentas = "D018"
                '    Me.ZonaVentas = "EFEC"
                '    Me.GrupoCliente = "06"
                '    Me.GrupoPrecios = "06"

                'ElseIf Value = "A" Then
                '    Me.GrupoDeCuentas = "D018"
                '    Me.ZonaVentas = "EFEC"
                '    Me.GrupoCliente = "01"
                '    Me.GrupoPrecios = "01"

                'End If

            Else

                Me.GrupoDeCuentas = ""
                Me.ClaveCondicionesPago = ""
                Me.ClasificacionFiscal = ""
                Me.ZonaVentas = ""
                Me.GrupoCliente = ""
                Me.GrupoPrecios = ""

                'ElseIf Value = "V" Or Value = "VL" Then

                '    Me.GrupoDeCuentas = "D005"
                '    Me.ClaveCondicionesPago = "0001"
                '    Me.ClasificacionFiscal = "1"
                '    Me.ZonaVentas = "DPVL"
                '    Me.GrupoCliente = "03"
                '    Me.GrupoPrecios = "03"

                'ElseIf Value = "S" Then
                '    'Cambio_053
                '    'Me.CanalDistribucion = "C1"
                '    Me.CanalDistribucion = "T1"
                '    Me.GrupoDeCuentas = "D006"
                '    Me.ClaveCondicionesPago = "0001"
                '    Me.ClasificacionFiscal = "1"
                '    Me.ZonaVentas = "EFEC"
                '    Me.GrupoCliente = "04"
                '    Me.GrupoPrecios = "04"
                '    'Me.TipoListaPrecios = "C1"
                '    Me.TipoListaPrecios = "02"
                '    Me.Sector = "VG"
                '    Me.CuentaContabilidad = "112100001"
                '    'Me.GrupoImputacion = "03"
                '    Me.GrupoImputacion = "01"
                'ElseIf Value = "P" Then
                '    Me.GrupoDeCuentas = ""
            End If

            RaiseEvent TipoVentaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Value As String)
            m_strNombre = Value
            m_strNombreCompleto = Value + " " + m_strApellido
            AddHandler Me.NombreChanged, AddressOf GetRFC
            RaiseEvent NombreChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ApellidoPaterno() As String
        Get
            Return m_strApellidoPaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoPaterno = Value
            m_strApellido = Value + " " + ApellidoMaterno
            m_strNombreCompleto = Nombre + " " + m_strApellido
            AddHandler Me.ApellidoPaternoChanged, AddressOf GetRFC
            RaiseEvent ApellidoPaternoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ApellidoMaterno() As String
        Get
            Return m_strApellidoMaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoMaterno = Value
            m_strApellido = ApellidoPaterno + " " + Value
            m_strNombreCompleto = Nombre + " " + m_strApellido
            AddHandler Me.ApellidoMaternoChanged, AddressOf GetRFC
            RaiseEvent ApellidoMaternoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FechaNacimiento() As Date
        Get
            Return m_datFechaNacimiento
        End Get
        Set(ByVal Value As Date)
            m_datFechaNacimiento = Value
            AddHandler Me.FechaNacimientoChanged, AddressOf GetRFC
            RaiseEvent FechaNacimientoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return m_strDireccion
        End Get
        Set(ByVal Value As String)
            m_strDireccion = Value
            RaiseEvent DireccionChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value
            RaiseEvent ColoniaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Value As String)
            m_strCiudad = Value
            RaiseEvent CiudadChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Value As String)
            m_strEstado = Value
            RaiseEvent EstadoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CP() As String
        Get
            Return m_intCP
        End Get
        Set(ByVal Value As String)
            m_intCP = Value
            RaiseEvent CPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EstadoCivil() As String
        Get
            Return m_strEstadoCivil
        End Get
        Set(ByVal Value As String)
            m_strEstadoCivil = Value
            RaiseEvent EstadoCivilChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Sexo() As String
        Get
            Return m_strSexo
        End Get
        Set(ByVal Value As String)
            m_strSexo = Value
            RaiseEvent SexoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return m_strRFC.Trim
        End Get
        Set(ByVal Value As String)
            m_strRFC = Value.Trim
            RaiseEvent RFCChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EMail() As String
        Get
            Return m_strEMail
        End Get
        Set(ByVal Value As String)
            m_strEMail = Value
            RaiseEvent EMailChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property GrupoDeCuentas() As String
        Get
            Return m_strGrupoDeCuentas
        End Get
        Set(ByVal Value As String)
            m_strGrupoDeCuentas = Value
            RaiseEvent GrupoDeCuentasChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property OrganizacionVentas() As String
        Get
            Return m_strOrganizacionVentas
        End Get
        Set(ByVal Value As String)
            m_strOrganizacionVentas = Value
            RaiseEvent OrganizacionVentasChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CanalDistribucion() As String
        Get
            Return m_strCanalDistribucion
        End Get
        Set(ByVal Value As String)
            m_strCanalDistribucion = Value
            RaiseEvent CanalDistribucionChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Sector() As String
        Get
            Return m_strSector
        End Get
        Set(ByVal Value As String)
            m_strSector = Value
            RaiseEvent SectorChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ClavePais() As String
        Get
            Return m_strClavePais
        End Get
        Set(ByVal Value As String)
            m_strClavePais = Value
            RaiseEvent ClavePaisChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_strTelefono
        End Get
        Set(ByVal Value As String)
            m_strTelefono = Value
            RaiseEvent TelefonoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CuentaContabilidad() As String
        Get
            Return m_strCuentaContabilidad
        End Get
        Set(ByVal Value As String)
            m_strCuentaContabilidad = Value
            RaiseEvent CuentaContabilidadChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ClaveCondicionesPago() As String
        Get
            Return m_strClaveCondicionesPago
        End Get
        Set(ByVal Value As String)
            m_strClaveCondicionesPago = Value
            RaiseEvent ClaveCondicionesPagoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ZonaVentas() As String
        Get
            Return m_strZonaVentas
        End Get
        Set(ByVal Value As String)
            m_strZonaVentas = Value
            RaiseEvent ZonaVentasChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodPlayer() As String
        Get
            Return m_strCodPlayer
        End Get
        Set(ByVal Value As String)
            m_strCodPlayer = Value
            RaiseEvent CodPlayerChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return m_strMoneda
        End Get
        Set(ByVal Value As String)
            m_strMoneda = Value
            RaiseEvent MonedaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property GrupoEstadistica() As String
        Get
            Return m_strGrupoEstadistica
        End Get
        Set(ByVal Value As String)
            m_strGrupoEstadistica = Value
            RaiseEvent GrupoEstadisticaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CondicionExpedicion() As String
        Get
            Return m_strCondicionExpedicion
        End Get
        Set(ByVal Value As String)
            m_strCondicionExpedicion = Value
            RaiseEvent CondicionExpedicionChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ClasificacionFiscal() As String
        Get
            Return m_strClasificacacionFiscal
        End Get
        Set(ByVal Value As String)
            m_strClasificacacionFiscal = Value
            RaiseEvent ClasificacionFiscalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Distrito() As String
        Get
            Return m_strDistrito
        End Get
        Set(ByVal Value As String)
            m_strDistrito = Value
            RaiseEvent DistritoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property GrupoCliente() As String
        Get
            Return m_strGrupoCliente
        End Get
        Set(ByVal Value As String)
            m_strGrupoCliente = Value
            RaiseEvent GrupoClienteChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property GrupoPrecios() As String
        Get
            Return m_strGrupoPrecios
        End Get
        Set(ByVal Value As String)
            m_strGrupoPrecios = Value
            RaiseEvent GrupoPreciosChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property TipoListaPrecios() As String
        Get
            Return m_strTipoListaPrecios
        End Get
        Set(ByVal Value As String)
            m_strTipoListaPrecios = Value
            RaiseEvent TipoListaPreciosChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property PrioridadEntrega() As String
        Get
            Return m_strPrioridadEntrega
        End Get
        Set(ByVal Value As String)
            m_strPrioridadEntrega = Value
            RaiseEvent PrioridadEntregaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property IndicadorAgrupamiento() As String
        Get
            Return m_strIndicadorAgrupamiento
        End Get
        Set(ByVal Value As String)
            m_strIndicadorAgrupamiento = Value
            RaiseEvent IndicadorAgrupamientoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property MaxEntregasParciales() As String
        Get
            Return m_strMaxEntregasParciales
        End Get
        Set(ByVal Value As String)
            m_strMaxEntregasParciales = Value
            RaiseEvent MaxEntregasParcialesChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property GrupoImputacion() As String
        Get
            Return m_strGrupoImputacion
        End Get
        Set(ByVal Value As String)
            m_strGrupoImputacion = Value
            RaiseEvent GrupoImputacionChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property IndicadorRelevante() As String
        Get
            Return m_strIndicadorRelevante
        End Get
        Set(ByVal Value As String)
            m_strIndicadorRelevante = Value
            RaiseEvent IndicadorRelevanteChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Fiscal() As Boolean
        Get
            Return m_bFiscal
        End Get
        Set(ByVal Value As Boolean)
            m_bFiscal = Value
            RaiseEvent FiscalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public ReadOnly Property Apellido() As String
        Get
            Return m_strApellido
        End Get
    End Property

    Public ReadOnly Property NombreCompleto() As String
        Get
            Return m_strNombreCompleto
        End Get
    End Property


#End Region

#End Region

#Region "Record Information"

    Public _strRecordCreatedBy As String
    Public _datRecordCreatedOn As Date
    Public _bolRecordEnabled As Boolean

    Public Event RecordCreatedByChanged As EventHandler
    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordEnabledChanged As EventHandler

    Public Property RecordCreatedBy() As String
        Get
            Return _strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            _strRecordCreatedBy = Value
            RaiseEvent RecordCreatedByChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return _datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            _datRecordCreatedOn = Value
            RaiseEvent RecordCreatedOnChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RecordEnabled() As Boolean
        Get
            Return _bolRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            _bolRecordEnabled = Value
            RaiseEvent RecordEnabledChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As ClientesManager)

        MyBase.New()

        oParent = Parent

        Me.SetFlagNew()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub Clear()
        Me.FechaNacimiento = Now
        Me.ApellidoPaterno = String.Empty
        Me.ApellidoMaterno = String.Empty
        Me.Estado = String.Empty
        Me.Ciudad = String.Empty
        Me.CodAlmacen = String.Empty
        Me.CodigoAlterno = String.Empty
        Me.CodigoCliente = 0
        Me.CodPlaza = String.Empty
        Me.Colonia = String.Empty
        Me.CP = String.Empty
        Me.Direccion = String.Empty
        Me.EstadoCivil = String.Empty
        Me.Nombre = String.Empty
        Me.RFC = String.Empty
        Me.Sexo = String.Empty
        Me.TipoVenta = String.Empty
        Me.Telefono = String.Empty
        Me.EMail = String.Empty
        Me.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.Name
        Me.RecordCreatedOn = Now.ToShortDateString
        Me.RecordEnabled = 1
        Me.CodPlayer = String.Empty
        Me.RFCMoral = String.Empty
        Me.GenerateRFC = True
        Me.NumExt = ""
        Me.NumInt = ""
        Me.RazonNoEmail = ""
        Me.RazonRechazoID = 0
        Me.EsEmpresa = False
        ResetFlagDirty()
        SetFlagNew()

        If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
            'Cambio_053
            'Me.CanalDistribucion = "C1"
            Me.CanalDistribucion = "T1"
        End If

    End Sub

#End Region

    Private oParent As ClientesManager


    Private Sub GetRFC(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.GenerateRFC = True Then
            If Me.EsEmpresa = False AndAlso Not (Me.Nombre = String.Empty OrElse Me.ApellidoMaterno = String.Empty OrElse Me.ApellidoPaterno = String.Empty) Then
                Me.RFC = oParent.GetRFC(Me)
            ElseIf Me.EsEmpresa AndAlso Not Me.Nombre = String.Empty Then
                Me.RFC = oParent.GetRFC(Me)
            End If
        End If

    End Sub

    Public Property CodigoClienteDPVALE() As Integer
        Get
            Return m_intCodigoClienteDPVALE
        End Get
        Set(ByVal Value As Integer)
            m_intCodigoClienteDPVALE = Value
        End Set
    End Property

    Public Property NumExt() As String
        Get
            Return m_strNumExt
        End Get
        Set(ByVal Value As String)
            m_strNumExt = Value
        End Set
    End Property

    Public Property NumInt() As String
        Get
            Return m_strNumInt
        End Get
        Set(ByVal Value As String)
            m_strNumInt = Value
        End Set
    End Property

    Public Property EsEmpresa() As Boolean
        Get
            Return m_strEsEmpresa
        End Get
        Set(ByVal Value As Boolean)
            m_strEsEmpresa = Value
            AddHandler Me.EsEmpresaChanged, AddressOf GetRFC
            RaiseEvent EsEmpresaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RazonNoEmail() As String
        Get
            Return m_strRazonNoEmail
        End Get
        Set(ByVal Value As String)
            m_strRazonNoEmail = Value
        End Set
    End Property

    Public Property RazonRechazoID() As Integer
        Get
            Return m_intRazonRechazoID
        End Get
        Set(ByVal Value As Integer)
            m_intRazonRechazoID = Value
        End Set
    End Property

End Class

'Namespace DportenisPro.DPTienda.ApplicationUnits.Clientes
'    Public Class Tel

'        Private m_strTelefono As String

'        Public Property ConFormato() As String
'            Get
'                Return m_strTelefono
'            End Get
'            Set(ByVal Value As String)
'                m_strTelefono = Value
'            End Set
'        End Property

'        Public Function SinFormato() As String

'            Dim strTelefono As String
'            strTelefono = ConFormato
'            strTelefono = strTelefono.Replace("-", "")
'            strTelefono = strTelefono.Replace("(", "")
'            strTelefono = strTelefono.Replace(")", "")

'            Return strTelefono

'        End Function
'    End Class
'End Namespace








