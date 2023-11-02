

Public Class NotaCredito

    Private m_strFolioSAP As String


    Private oParent As NotasCreditoManager



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

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As NotasCreditoManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region


#Region "Fields"

    Private m_intClientePGID As Integer
    Private m_intNotaCreditoID As Integer
    Private m_intNotaCreditoFolio As Integer
    Private m_strFolioApartado As String
    Private m_strCodAlmacen As String
    Private m_strCodCaja As String
    Private m_intClienteID As String
    Private m_strCodTipoDevolucion As String
    Private m_strCodTipoVenta As String
    Private m_decImporte As Decimal
    Private m_decIVA As Decimal
    Private m_strAplicada As String
    Private m_strDevDinero As String
    Private m_strObservaciones As String
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bolStatusRegistro As Boolean
    Private m_strCodVendedor As String
    Private m_dsDetalle As DataSet
    Private m_strFIDOCUMENT As String
    Private m_strSALESDOCUMENT As String
    Private m_strDevAnterior As String
    Private m_strRevale As String
    Private m_Referencia As String


    'Variables para la validacion NC
    Private m_strNCE_RESULT As String
    Private m_strNCDOCSD As String
    Private m_strNCDOCFI As String
    Private m_strNCFactura As String
    Private m_strNCAsociado As String
    Private m_datNCDetalle As DataTable

#End Region



#Region "Properties"

    Public Property ClientePGID() As Integer
        Get
            Return m_intClientePGID
        End Get
        Set(ByVal Value As Integer)
            m_intClientePGID = Value
        End Set
    End Property

    Public Property Parent() As NotasCreditoManager
        Get
            Return oParent
        End Get
        Set(ByVal Value As NotasCreditoManager)
            oParent = Value
        End Set
    End Property

    Public Property SALESDOCUMENT() As String
        Get
            Return m_strSALESDOCUMENT
        End Get
        Set(ByVal Value As String)
            m_strSALESDOCUMENT = Value
        End Set
    End Property

    Public Property DEVANTERIOR() As String
        Get
            Return m_strDevAnterior
        End Get
        Set(ByVal Value As String)
            m_strDevAnterior = Value
        End Set
    End Property


    Public Property FIDOCUMENT() As String
        Get
            Return m_strFIDOCUMENT
        End Get
        Set(ByVal Value As String)
            m_strFIDOCUMENT = Value
        End Set
    End Property

    Public Property REVALE() As String
        Get
            Return m_strRevale
        End Get
        Set(ByVal Value As String)
            m_strRevale = Value
        End Set
    End Property


    Public Property ID() As Integer

        Get
            Return m_intNotaCreditoID
        End Get

        Set(ByVal Value As Integer)
            m_intNotaCreditoID = Value
        End Set

    End Property


    Public Property NotaCreditoFolio() As Integer

        Get
            Return m_intNotaCreditoFolio
        End Get

        Set(ByVal Value As Integer)
            m_intNotaCreditoFolio = Value
        End Set

    End Property


    Public Property FolioApartado() As String

        Get
            Return m_strFolioApartado
        End Get

        Set(ByVal Value As String)
            m_strFolioApartado = Value
        End Set

    End Property


    Public Property AlmacenID() As String

        Get
            Return m_strCodAlmacen
        End Get

        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set

    End Property


    Public Property CajaID() As String

        Get
            Return m_strCodCaja
        End Get

        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set

    End Property


    Public Property ClienteID() As String

        Get
            Return m_intClienteID
        End Get

        Set(ByVal Value As String)
            m_intClienteID = Value.PadLeft(10, "0")
        End Set

    End Property


    Public Property TipoDevolucionID() As String

        Get
            Return m_strCodTipoDevolucion
        End Get

        Set(ByVal Value As String)
            m_strCodTipoDevolucion = Value
        End Set

    End Property


    Public Property TipoVentaID() As String

        Get
            Return m_strCodTipoVenta
        End Get

        Set(ByVal Value As String)
            m_strCodTipoVenta = Value
        End Set

    End Property


    Public Property Importe() As Decimal

        Get
            Return m_decImporte
        End Get

        Set(ByVal Value As Decimal)
            m_decImporte = Value
        End Set

    End Property


    Public Property IVA() As Decimal

        Get
            Return m_decIVA
        End Get

        Set(ByVal Value As Decimal)
            m_decIVA = Value
        End Set

    End Property


    Public Property Aplicada() As String

        Get
            Return m_strAplicada
        End Get

        Set(ByVal Value As String)
            m_strAplicada = Value
        End Set

    End Property


    Public Property DevDinero() As String

        Get
            Return m_strDevDinero
        End Get

        Set(ByVal Value As String)
            m_strDevDinero = Value
        End Set

    End Property


    Public Property Observaciones() As String

        Get
            Return m_strObservaciones
        End Get

        Set(ByVal Value As String)
            m_strObservaciones = Value
        End Set

    End Property


    Public Property Usuario() As String

        Get
            Return m_strUsuario
        End Get

        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set

    End Property


    Public Property Fecha() As Date

        Get
            Return m_datFecha
        End Get

        Set(ByVal Value As Date)
            m_datFecha = Value
        End Set

    End Property


    Public Property StatusRegistro() As Boolean

        Get
            Return m_bolStatusRegistro
        End Get

        Set(ByVal Value As Boolean)
            m_bolStatusRegistro = Value
        End Set

    End Property


    Public Property Detalle() As DataSet

        Get
            Return m_dsDetalle
        End Get

        Set(ByVal Value As DataSet)
            m_dsDetalle = Value
        End Set

    End Property


    Public Property PlayerID() As String

        Get
            Return m_strCodVendedor
        End Get

        Set(ByVal Value As String)
            m_strCodVendedor = Value
        End Set

    End Property
    Public Property FolioSAP() As String
        Get
            Return m_strFolioSAP
        End Get
        Set(ByVal Value As String)
            m_strFolioSAP = Value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return m_Referencia
        End Get
        Set(value As String)
            m_Referencia = value
        End Set
    End Property

#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_intClientePGID = 0
        m_intNotaCreditoID = 0
        m_intNotaCreditoFolio = 0
        m_strFolioApartado = String.Empty
        m_strCodAlmacen = String.Empty
        m_strCodCaja = String.Empty
        m_intClienteID = 0
        m_strCodTipoDevolucion = String.Empty
        m_decImporte = 0.0
        m_decIVA = 0.0
        m_strAplicada = String.Empty
        m_strDevDinero = String.Empty
        m_strObservaciones = String.Empty
        m_strUsuario = String.Empty
        m_datFecha = Date.Now
        m_bolStatusRegistro = False
        m_strRevale = String.Empty
        m_strFIDOCUMENT = String.Empty
        m_strSALESDOCUMENT = String.Empty

        'm_dsDetalle = New DataSet
        m_dsDetalle = Nothing


        SetFlagNew()
        ResetFlagDirty()


        'Variables para la validacion de NC
        m_strNCE_RESULT = String.Empty
        m_strNCDOCSD = String.Empty
        m_strNCDOCFI = String.Empty
        m_strNCFactura = String.Empty
        m_strNCAsociado = String.Empty
        m_datNCDetalle = Nothing

    End Sub



    Public Sub Save(ByVal EnvioServerPG As Boolean, ByVal FolioPedido As String, Optional ByRef strError As String = "")

        '----------------------------------------------------------------------------------------
        'JNAVA (19.02.2015): Agregamos parametro nuevo para cuando es NC de Factura de SH
        '----------------------------------------------------------------------------------------
        oParent.Save(Me, EnvioServerPG, FolioPedido, strError)

    End Sub



    Public Sub Delete()

        'oParent.Delete(Me.ID)

    End Sub

#End Region



#Region "Propiedades Valida NC"

    Public Property NCAsociado() As String
        Get
            Return m_strNCAsociado
        End Get
        Set(ByVal Value As String)
            m_strNCAsociado = Value
        End Set
    End Property

    Public Property NCFactura() As String
        Get
            Return m_strNCFactura
        End Get
        Set(ByVal Value As String)
            m_strNCFactura = Value
        End Set
    End Property

    Public Property NCDOCFI() As String
        Get
            Return m_strNCDOCFI
        End Get
        Set(ByVal Value As String)
            m_strNCDOCFI = Value
        End Set
    End Property

    Public Property NCDOCSD() As String
        Get
            Return m_strNCDOCSD
        End Get
        Set(ByVal Value As String)
            m_strNCDOCSD = Value
        End Set
    End Property

    Public Property NCE_RESULT() As String
        Get
            Return m_strNCE_RESULT
        End Get
        Set(ByVal Value As String)
            m_strNCE_RESULT = Value
        End Set
    End Property

    Public Property NCDetalle() As DataTable
        Get
            Return m_datNCDetalle
        End Get
        Set(ByVal Value As DataTable)
            m_datNCDetalle = Value
        End Set
    End Property

#End Region






End Class
