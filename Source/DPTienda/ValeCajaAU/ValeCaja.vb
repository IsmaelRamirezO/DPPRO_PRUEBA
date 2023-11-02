
Imports DportenisPro.DPTienda.Core


Public Class ValeCaja

    Private m_strFolioFITrasladoSaldo As String = ""

    Private oParent As ValeCajaManager



#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ValeCajaManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region



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

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region



#Region "Fields"

    Private m_bStastusRegistro As Boolean
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_strMotivo As String
    Private m_bDevEfectivo As Boolean
    Private m_intValeGenerado As Integer
    Private m_decMontoUtilizado As Decimal
    Private m_decImporte As Decimal
    Private m_strNombre As String
    Private m_intFolioDocumento As String
    Private m_strTipoDocumento As String
    Private m_strCodCliente As String
    Private m_intValeCajaID As Integer
    Private m_intDocumentoID As Integer
    Private m_decDocumentoImporte As Decimal
    Private m_FolioFISAP As String

    Private m_dsDistribucionDetalle As DataSet



    Public Property ValeCajaID() As Integer
        Get
            Return m_intValeCajaID
        End Get
        Set(ByVal Value As Integer)
            m_intValeCajaID = Value
        End Set
    End Property


    Public Property TipoDocumento() As String
        Get
            Return m_strTipoDocumento
        End Get
        Set(ByVal Value As String)
            m_strTipoDocumento = Value
        End Set
    End Property


    Public Property FolioDocumento() As String
        Get
            Return m_intFolioDocumento
        End Get
        Set(ByVal Value As String)
            m_intFolioDocumento = Value
        End Set
    End Property


    Public Property CodCliente() As String
        Get
            Return m_strCodCliente
        End Get
        Set(ByVal Value As String)
            m_strCodCliente = Value
        End Set
    End Property


    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Value As String)
            m_strNombre = Value
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


    Public Property MontoUtilizado() As Decimal
        Get
            Return m_decMontoUtilizado
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoUtilizado = Value
        End Set
    End Property


    Public Property ValeGenerado() As Integer
        Get
            Return m_intValeGenerado
        End Get
        Set(ByVal Value As Integer)
            m_intValeGenerado = Value
        End Set
    End Property


    Public Property DevEfectivo() As Boolean
        Get
            Return m_bDevEfectivo
        End Get
        Set(ByVal Value As Boolean)
            m_bDevEfectivo = Value
        End Set
    End Property


    Public Property Motivo() As String
        Get
            Return m_strMotivo
        End Get
        Set(ByVal Value As String)
            m_strMotivo = Value
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


    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set
    End Property


    Public Property StastusRegistro() As Boolean
        Get
            Return m_bStastusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStastusRegistro = Value
        End Set
    End Property


    Public Property DocumentoID() As Integer
        Get
            Return m_intDocumentoID
        End Get
        Set(ByVal Value As Integer)
            m_intDocumentoID = Value
        End Set
    End Property


    Public Property DocumentoImporte() As Decimal
        Get
            Return m_decDocumentoImporte
        End Get
        Set(ByVal Value As Decimal)
            m_decDocumentoImporte = Value
        End Set
    End Property


    Public Property DistribucionDetalle() As DataSet
        Get
            Return m_dsDistribucionDetalle
        End Get
        Set(ByVal Value As DataSet)
            m_dsDistribucionDetalle = Value
        End Set
    End Property

    Public Property FolioFISAP() As String
        Get
            Return m_FolioFISAP
        End Get
        Set(ByVal Value As String)
            m_FolioFISAP = Value
        End Set
    End Property

#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_bStastusRegistro = False
        m_strUsuario = oParent.ApplicationContext.Security.CurrentUser.Name
        m_datFecha = Date.Now
        m_strMotivo = String.Empty
        m_bDevEfectivo = False
        m_intValeGenerado = 0
        m_decMontoUtilizado = 0
        m_decImporte = 0
        m_strNombre = String.Empty
        m_intFolioDocumento = 0
        m_strTipoDocumento = String.Empty
        m_strCodCliente = "0"
        m_intValeCajaID = 0
        m_intDocumentoID = 0
        m_decDocumentoImporte = 0
        m_strFolioFITrasladoSaldo = ""


        On Error Resume Next

        m_dsDistribucionDetalle.Dispose()
        m_dsDistribucionDetalle = Nothing


        SetFlagNew()
        ResetFlagDirty()

    End Sub



    Public Sub Save()

        oParent.Save(Me)

    End Sub



    Public Sub Delete()

        'oParent.Delete(Me.ID)

    End Sub

#End Region

    Public Property FolioFITrasladoSaldo() As String
        Get
            Return m_strFolioFITrasladoSaldo
        End Get
        Set(ByVal Value As String)
            m_strFolioFITrasladoSaldo = Value
        End Set
    End Property

End Class
