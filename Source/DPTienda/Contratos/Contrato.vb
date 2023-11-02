
Imports DportenisPro.DPTienda.Core


Public Class Contrato

    Private oParent As ContratoManager

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

    Friend Sub New(ByVal Parent As ContratoManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region


#Region "Fields"

    Private m_intID As Integer
    Private m_intFolioApartado As Integer
    Private m_strPlayerID As String
    Private m_intClienteID As String
    Private m_decImporte As Decimal
    Private m_decSaldo As Decimal
    Private m_decDescuentoTotal As Decimal
    Private m_decIVA As Decimal
    Private m_strEntregada As String
    Private m_strComentarioDesc As String
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bolStatusRegistro As Boolean
    Private m_strTipoDescuentoID As String
    Private m_dsDetalle As DataSet
    Private m_strCodCaja As String
    Private m_strContratoSAP As String
    Private m_Referencia As String
    Private m_SerialId As String

    Public Property SerialId As String
        Get
            Return m_SerialId
        End Get
        Set(value As String)
            m_SerialId = value
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


    Public Property ContratoSAP() As String
        Get
            Return m_strContratoSAP
        End Get
        Set(ByVal Value As String)
            m_strContratoSAP = Value
        End Set
    End Property


    Public Property ID() As Integer
        Get
            Return m_intID
        End Get
        Set(ByVal Value As Integer)
            m_intID = Value
        End Set
    End Property


    Public Property FolioApartado() As Integer
        Get
            Return m_intFolioApartado
        End Get
        Set(ByVal Value As Integer)
            m_intFolioApartado = Value
        End Set
    End Property


    Public Property PlayerID() As String
        Get
            Return m_strPlayerID
        End Get
        Set(ByVal Value As String)
            m_strPlayerID = Value
        End Set
    End Property


    Public Property ClienteID() As String
        Get
            Return m_intClienteID
        End Get
        Set(ByVal Value As String)
            m_intClienteID = Value
        End Set
    End Property


    Public Property ImporteTotal() As Decimal
        Get
            Return m_decImporte
        End Get
        Set(ByVal Value As Decimal)
            m_decImporte = Value
        End Set
    End Property


    Public Property Saldo() As Decimal
        Get
            Return m_decSaldo
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldo = Value
        End Set
    End Property


    Public Property DescuentoTotal() As Decimal
        Get
            Return m_decDescuentoTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decDescuentoTotal = Value
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


    Public Property Entregada() As String
        Get
            Return m_strEntregada
        End Get
        Set(ByVal Value As String)
            m_strEntregada = Value
        End Set
    End Property


    Public Property ComentarioDesc() As String
        Get
            Return m_strComentarioDesc
        End Get
        Set(ByVal Value As String)
            m_strComentarioDesc = Value
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


    Public Property TipoDescuentoID() As String
        Get
            Return m_strTipoDescuentoID
        End Get
        Set(ByVal Value As String)
            m_strTipoDescuentoID = Value
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


    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
        End Set
    End Property


#End Region



#Region "Methods"

    Private Sub ClearFields()

        m_intID = 0
        m_intFolioApartado = 0
        m_strPlayerID = String.Empty
        m_intClienteID = "0"
        m_decImporte = 0.0
        m_decSaldo = 0.0
        m_decDescuentoTotal = 0.0
        m_decIVA = 0.0
        m_strEntregada = String.Empty
        m_strComentarioDesc = String.Empty
        m_strUsuario = String.Empty
        m_datFecha = Date.Now
        m_bolStatusRegistro = False
        m_strCodCaja = String.Empty
        m_strContratoSAP = String.Empty


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

End Class
