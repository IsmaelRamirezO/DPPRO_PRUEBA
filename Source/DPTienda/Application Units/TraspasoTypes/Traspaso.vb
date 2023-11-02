Public Class Traspaso

#Region "Object Status Flags"

    Private bolFlagIsDirty As Boolean
    Private bolFlagIsNew As Boolean

    Public Overridable Function IsDirty() As Boolean
        Return bolFlagIsDirty
    End Function

    Public Overridable Function IsNew() As Boolean
        Return bolFlagIsNew
    End Function

    Protected Friend Overridable Sub SetFlagIsDirty()
        bolFlagIsDirty = True
    End Sub

    Protected Friend Overridable Sub ResetFlagIsDirty()
        bolFlagIsDirty = False
    End Sub

    Protected Friend Overridable Sub SetFlagIsNew()
        bolFlagIsNew = True
    End Sub

    Protected Friend Overridable Sub ResetFlagIsNew()
        bolFlagIsNew = False
    End Sub

#End Region


#Region "Fields"

    Private m_strObservaciones As String
    Private m_datTraspasoRecibidoEl As Date
    Private m_strGuia As String
    Private m_intTotalBultos As Integer    
    Private m_strAutorizadoPorID As String
    Private m_strRecordCreatedBy As String
    Private m_decCargos As Decimal
    Private m_decSubTotal As Decimal
    Private m_decParidadMonetaria As Decimal
    Private m_strMonedaID As String
    Private m_datTraspasoCreadoEl As Date
    Private m_strTransportistaID As String
    Private m_strStatus As String
    Private m_strAlmacenDestinoID As String
    Private m_strAlmacenOrigenID As String
    Private m_strReferencia As String
    Private m_intTraspasoID As Integer
    Private m_dsDetalle As DataSet
    Private m_strFolio As String
    Private m_strFolioSAP As String
    Private m_intNumConsecutivo As Integer
    Private m_Entrega As String
    Private m_strTraspasoConFaltante As String


    Public Event ObservacionesChanged As EventHandler
    Public Event TraspasoRecibidoElChanged As EventHandler
    Public Event GuiaChanged As EventHandler
    Public Event TotalBultosChanged As EventHandler
    Public Event AutorizadoPorIDChanged As EventHandler
    Public Event RecordCreatedByChanged As EventHandler
    Public Event CargosChanged As EventHandler
    Public Event SubTotalChanged As EventHandler
    Public Event ParidadMonetariaChanged As EventHandler
    Public Event MonedaIDChanged As EventHandler
    Public Event TraspasoCreadoElChanged As EventHandler
    Public Event TransportistaIDChanged As EventHandler
    Public Event StatusChanged As EventHandler
    Public Event AlmacenDestinoIDChanged As EventHandler
    Public Event AlmacenOrigenIDChanged As EventHandler
    Public Event ReferenciaChanged As EventHandler
    Public Event TraspasoIDChanged As EventHandler



    Public Property TraspasoID() As Integer
        Get
            Return m_intTraspasoID
        End Get
        Set(ByVal Value As Integer)

            m_intTraspasoID = Value

            SetFlagIsDirty()

            RaiseEvent TraspasoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_strReferencia
        End Get
        Set(ByVal Value As String)

            m_strReferencia = Value

            SetFlagIsDirty()

            RaiseEvent ReferenciaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property AlmacenOrigenID() As String
        Get
            Return m_strAlmacenOrigenID
        End Get
        Set(ByVal Value As String)

            m_strAlmacenOrigenID = Value

            SetFlagIsDirty()

            RaiseEvent AlmacenOrigenIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property AlmacenDestinoID() As String
        Get
            Return m_strAlmacenDestinoID
        End Get
        Set(ByVal Value As String)

            m_strAlmacenDestinoID = Value

            SetFlagIsDirty()

            RaiseEvent AlmacenDestinoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Status() As String
        Get
            Return m_strStatus
        End Get
        Set(ByVal Value As String)

            m_strStatus = Value

            SetFlagIsDirty()

            RaiseEvent StatusChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property TransportistaID() As String
        Get
            Return m_strTransportistaID
        End Get
        Set(ByVal Value As String)

            m_strTransportistaID = Value

            SetFlagIsDirty()

            RaiseEvent TransportistaIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property TraspasoCreadoEl() As Date
        Get
            Return m_datTraspasoCreadoEl
        End Get
        Set(ByVal Value As Date)

            m_datTraspasoCreadoEl = Value

            SetFlagIsDirty()

            RaiseEvent TraspasoCreadoElChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property MonedaID() As String
        Get
            Return m_strMonedaID
        End Get
        Set(ByVal Value As String)

            m_strMonedaID = Value

            SetFlagIsDirty()

            RaiseEvent MonedaIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property ParidadMonetaria() As Decimal
        Get
            Return m_decParidadMonetaria
        End Get
        Set(ByVal Value As Decimal)

            m_decParidadMonetaria = Value

            SetFlagIsDirty()

            RaiseEvent ParidadMonetariaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return m_decSubTotal
        End Get
        Set(ByVal Value As Decimal)

            m_decSubTotal = Value

            SetFlagIsDirty()

            RaiseEvent SubTotalChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Cargos() As Decimal
        Get
            Return m_decCargos
        End Get
        Set(ByVal Value As Decimal)

            m_decCargos = Value

            SetFlagIsDirty()

            RaiseEvent CargosChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
        Set(ByVal Value As String)

            m_strRecordCreatedBy = Value

            SetFlagIsDirty()

            RaiseEvent RecordCreatedByChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property AutorizadoPorID() As String
        Get
            Return m_strAutorizadoPorID
        End Get
        Set(ByVal Value As String)

            m_strAutorizadoPorID = Value

            SetFlagIsDirty()

            RaiseEvent AutorizadoPorIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property TotalBultos() As Integer
        Get
            Return m_intTotalBultos
        End Get
        Set(ByVal Value As Integer)

            m_intTotalBultos = Value

            SetFlagIsDirty()

            RaiseEvent TotalBultosChanged(Me, New EventArgs)

        End Set
    End Property


    Public Property Guia() As String
        Get
            Return m_strGuia
        End Get
        Set(ByVal Value As String)

            m_strGuia = Value

            SetFlagIsDirty()

            RaiseEvent GuiaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property TraspasoRecibidoEl() As Date
        Get
            Return m_datTraspasoRecibidoEl
        End Get
        Set(ByVal Value As Date)

            m_datTraspasoRecibidoEl = Value

            SetFlagIsDirty()

            RaiseEvent TraspasoRecibidoElChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return m_strObservaciones
        End Get
        Set(ByVal Value As String)

            m_strObservaciones = Value

            SetFlagIsDirty()

            RaiseEvent ObservacionesChanged(Me, New EventArgs)

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


    Public Property Folio() As String
        Get
            Return m_strFolio
        End Get

        Set(ByVal Valor As String)
            m_strFolio = Valor
        End Set

    End Property

    Public Property FolioSAP() As String
        Get
            Return m_strFolioSAP
        End Get

        Set(ByVal Valor As String)
            m_strFolioSAP = Valor
        End Set

    End Property

    Public Property TraspasoConFaltante() As String
        Get
            Return m_strTraspasoConFaltante
        End Get

        Set(ByVal Valor As String)
            m_strTraspasoConFaltante = Valor
        End Set

    End Property

    Public Property NumConsecutivo() As Integer
        Get
            Return m_intNumConsecutivo
        End Get
        Set(ByVal Value As Integer)
            m_intNumConsecutivo = Value
        End Set
    End Property

    Public Property Entrega As String
        Get
            Return m_Entrega
        End Get
        Set(value As String)
            m_Entrega = value
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Public Sub New()

        Clear()

    End Sub

#End Region


#Region "Methods"

    Public Overridable Sub Clear()

        Me.TraspasoID = 0
        Me.Referencia = String.Empty
        Me.AlmacenOrigenID = String.Empty
        Me.AlmacenDestinoID = String.Empty
        Me.Status = String.Empty
        Me.TransportistaID = String.Empty
        Me.TraspasoCreadoEl = Date.MinValue
        Me.MonedaID = String.Empty
        Me.ParidadMonetaria = 0
        Me.SubTotal = 0
        Me.Cargos = 0
        Me.RecordCreatedBy = String.Empty
        Me.AutorizadoPorID = String.Empty
        Me.TotalBultos = 0
        Me.Guia = String.Empty
        Me.TraspasoRecibidoEl = Date.MinValue
        Me.Observaciones = String.Empty
        Me.NumConsecutivo = 0

        Me.Detalle = New DataSet

        'ResetFlagIsDirty()
        'ResetFlagIsNew()

        SetFlagIsDirty()
        SetFlagIsNew()

    End Sub

#End Region

End Class
