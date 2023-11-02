Imports DportenisPro.DPTienda.Core

Public Class PromoBin

    Private oParent As CatalogoPromocionesManager

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

#Region "Fields"

    Private m_intBin As Integer
    Private m_intIDPromo As Integer
    Private m_decImporteMin As Decimal
    Private m_decImporteMax As Decimal

    Public Property Bin() As Integer
        Get
            Return m_intBin
        End Get

        Set(ByVal Valor As Integer)
            m_intBin = Valor
        End Set

    End Property

    Public Property IDPromo() As Integer
        Get
            Return m_intIDPromo
        End Get

        Set(ByVal Valor As Integer)
            m_intIDPromo = Valor
        End Set

    End Property

    Public Property ImporteMinimo() As Decimal
        Get
            Return m_decImporteMin
        End Get
        Set(ByVal Value As Decimal)
            m_decImporteMin = Value
        End Set
    End Property

    Public Property ImporteMaximo() As Decimal
        Get
            Return m_decImporteMax
        End Get
        Set(ByVal Value As Decimal)
            m_decImporteMax = Value
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CatalogoPromocionesManager)

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Private Sub ClearFields()

        m_intBin = 0
        m_intIDPromo = 0
        m_decImporteMin = 0
        m_decImporteMax = 0

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
