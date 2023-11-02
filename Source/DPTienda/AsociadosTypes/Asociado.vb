Imports DportenisPro.CommonTypes.Contacto

Public Class Asociado
    Inherits DportenisPro.CommonTypes.Contacto.Contacto


#Region "Fields"

    Private m_datFechaNacimiento As Date
    Private m_strEmail As String
    Private m_strPlazaID As String
    Private m_strBanco As String
    Private m_strNumeroCIE As String
    Private m_decLimiteCreditoBancario As Decimal
    Private m_strCedulaFiscal As String
    Private m_intFormaPagoMayoreoID As Integer
    Private m_intFormaPagoCatalogoID As Integer
    Private m_intFormaPagoDPValeID As Integer
    Private m_intFormaPagoAsociadosID As Integer
    Private m_decLimiteCreditoMayoreo As Decimal
    Private m_decLimiteCreditoCatalogo As Decimal
    Private m_decLimiteCreditoDPVale As Decimal
    Private m_decLimiteCreditoAsociado As Decimal
    Private m_bEsAsociadoMayoreo As Boolean
    Private m_bEsAsociadoCatalogo As Boolean
    Private m_bEsAsociadoDPVale As Boolean
    Private m_bEsAsociado As Boolean
    Private m_bEsAsociadoOtro As Boolean
    'private m_oFoto As System.Drawing.Image
    'Private m_oFirmaDigital As System.Drawing.Image
    Private m_oAval As Contacto.Contacto

    Public Event FechaNacimientoChanged As EventHandler
    Public Event EmailChanged As EventHandler
    Public Event PlazaIDChanged As EventHandler
    Public Event BancoChanged As EventHandler
    Public Event NumeroCIEChanged As EventHandler
    Public Event LimiteCreditoBancarioChanged As EventHandler
    Public Event CedulaFiscalChanged As EventHandler
    Public Event FormaPagoMayoreoIDChanged As EventHandler
    Public Event FormaPagoCatalogoIDChanged As EventHandler
    Public Event FormaPagoDPValeIDChanged As EventHandler
    Public Event FormaPagoAsociadosIDChanged As EventHandler
    Public Event LimiteCreditoMayoreoChanged As EventHandler
    Public Event LimiteCreditoCatalogoChanged As EventHandler
    Public Event LimiteCreditoDPValeChanged As EventHandler
    Public Event LimiteCreditoAsociadoChanged As EventHandler
    Public Event EsAsociadoMayoreoChanged As EventHandler
    Public Event EsAsociadoCatalogoChanged As EventHandler
    Public Event EsAsociadoDPValeChanged As EventHandler
    Public Event EsAsociadoChanged As EventHandler
    Public Event EsAsociadoOtroChanged As EventHandler
    'Public Event FotoChanged As EventHandler
    'Public Event FirmaDigitalChanged As EventHandler


    Public Property FechaNacimiento() As Date
        Get
            Return m_datFechaNacimiento
        End Get
        Set(ByVal Value As Date)
            m_datFechaNacimiento = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent FechaNacimientoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Email() As String
        Get
            Return m_strEmail
        End Get
        Set(ByVal Value As String)
            m_strEmail = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EmailChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property PlazaID() As String
        Get
            Return m_strPlazaID
        End Get
        Set(ByVal Value As String)
            m_strPlazaID = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent PlazaIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Banco() As String
        Get
            Return m_strBanco
        End Get
        Set(ByVal Value As String)
            m_strBanco = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent BancoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property NumeroCIE() As String
        Get
            Return m_strNumeroCIE
        End Get
        Set(ByVal Value As String)
            m_strNumeroCIE = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent NumeroCIEChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoBancario() As Decimal
        Get
            Return m_decLimiteCreditoBancario
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoBancario = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent LimiteCreditoBancarioChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property CedulaFiscal() As String
        Get
            Return m_strCedulaFiscal
        End Get
        Set(ByVal Value As String)
            m_strCedulaFiscal = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent CedulaFiscalChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property FormaPagoMayoreoID() As Integer
        Get
            Return m_intFormaPagoMayoreoID
        End Get
        Set(ByVal Value As Integer)
            m_intFormaPagoMayoreoID = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent FormaPagoMayoreoIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property FormaPagoCatalogoID() As Integer
        Get
            Return m_intFormaPagoCatalogoID
        End Get
        Set(ByVal Value As Integer)
            m_intFormaPagoCatalogoID = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent FormaPagoCatalogoIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property FormaPagoDPValeID() As Integer
        Get
            Return m_intFormaPagoDPValeID
        End Get
        Set(ByVal Value As Integer)
            m_intFormaPagoDPValeID = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent FormaPagoDPValeIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property FormaPagoAsociadosID() As Integer
        Get
            Return m_intFormaPagoAsociadosID
        End Get
        Set(ByVal Value As Integer)
            m_intFormaPagoAsociadosID = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent FormaPagoAsociadosIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoMayoreo() As Decimal
        Get
            Return m_decLimiteCreditoMayoreo
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoMayoreo = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent LimiteCreditoMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoCatalogo() As Decimal
        Get
            Return m_decLimiteCreditoCatalogo
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoCatalogo = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent LimiteCreditoCatalogoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoDPVale() As Decimal
        Get
            Return m_decLimiteCreditoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoDPVale = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent LimiteCreditoDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoAsociado() As Decimal
        Get
            Return m_decLimiteCreditoAsociado
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoAsociado = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent LimiteCreditoAsociadoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsAsociadoMayoreo() As Boolean
        Get
            Return m_bEsAsociadoMayoreo
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociadoMayoreo = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EsAsociadoMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsAsociadoCatalogo() As Boolean
        Get
            Return m_bEsAsociadoCatalogo
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociadoCatalogo = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EsAsociadoCatalogoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsAsociadoDPVale() As Boolean
        Get
            Return m_bEsAsociadoDPVale
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociadoDPVale = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EsAsociadoDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsAsociado() As Boolean
        Get
            Return m_bEsAsociado
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociado = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EsAsociadoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsAsociadoOtro() As Boolean
        Get
            Return m_bEsAsociadoOtro
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociadoOtro = Value

            MyBase.SetFlagIsDirty()
            RaiseEvent EsAsociadoOtroChanged(Me, New EventArgs)
        End Set
    End Property

    'Public Property Foto() As System.Drawing.Image
    '    Get
    '        Return m_oFoto
    '    End Get
    '    Set(ByVal Value As System.Drawing.Image)
    '        m_oFoto = Value

    '        MyBase.SetFlagIsDirty()
    '        RaiseEvent FotoChanged(Me, New EventArgs)
    '    End Set
    'End Property

    'Public Property FirmaDigital() As System.Drawing.Image
    '    Get
    '        Return m_oFirmaDigital
    '    End Get
    '    Set(ByVal Value As System.Drawing.Image)
    '        m_oFirmaDigital = Value

    '        MyBase.SetFlagIsDirty()
    '        RaiseEvent FirmaDigitalChanged(Me, New EventArgs)
    '    End Set
    'End Property

    Public Property Aval() As Contacto.Contacto
        Get
            Return m_oAval
        End Get
        Set(ByVal Value As Contacto.Contacto)
            MyBase.SetFlagIsDirty()
            m_oAval = Value
        End Set
    End Property

#End Region


#Region "Constructors / Destructors"

    Public Sub New()
        MyBase.New()

        m_oAval = New Contacto.Contacto

        Me.Clear()
    End Sub

#End Region


#Region "Methods"

    Public Shadows Sub Clear()
        'MyBase.Clear()

        Me.Nombre = String.Empty
        Me.ApellidoPaterno = String.Empty
        Me.ApellidoMaterno = String.Empty
        Me.EsAsociadoMayoreo = False
        Me.EsAsociadoCatalogo = False
        Me.EsAsociadoDPVale = False
        Me.EsAsociado = False
        Me.EsAsociadoOtro = False
        Me.Domicilio = String.Empty
        Me.Colonia = String.Empty
        Me.Estado = String.Empty
        Me.Ciudad = String.Empty
        Me.CodigoPostal = String.Empty
        Me.Telefono = String.Empty
        Me.FechaNacimiento = Date.Today
        Me.Sexo = String.Empty
        Me.Email = String.Empty
        Me.PlazaID = String.Empty
        Me.Banco = String.Empty
        Me.NumeroCIE = String.Empty
        Me.LimiteCreditoBancario = 0
        Me.CedulaFiscal = String.Empty
        Me.FormaPagoMayoreoID = 0
        Me.FormaPagoCatalogoID = 0
        Me.FormaPagoDPValeID = 0
        Me.FormaPagoAsociadosID = 0
        Me.LimiteCreditoMayoreo = 0
        Me.LimiteCreditoCatalogo = 0
        Me.LimiteCreditoDPVale = 0
        Me.LimiteCreditoAsociado = 0

        'TODO: CAT - Verificar que no se generen errores al vincular con un control Picture
        'Me.Foto = New System.Drawing.Bitmap(1, 1, Drawing.Imaging.PixelFormat.DontCare)

        'TODO: CAT - Verificar que no se generen errores al vincular con un control Picture
        'Me.FirmaDigital = Nothing

        m_oAval.Clear()

        MyBase.ResetFlagIsDirty()
        MyBase.SetFlagIsNew()

    End Sub

#End Region

End Class
