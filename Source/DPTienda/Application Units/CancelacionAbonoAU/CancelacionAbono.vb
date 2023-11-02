Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CancelacionAbono

    Private oParent As CancelacionAbonoManager

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

    Private m_intID As Integer
    Private m_intApartadoID As Integer

    Public Property ID() As Integer
        Get
            Return m_intID

        End Get

        Set(ByVal Valor As Integer)

            m_intID = Valor

        End Set

    End Property

    Public Property ApartadoID() As Integer
        Get
            Return m_intApartadoID

        End Get

        Set(ByVal Valor As Integer)

            m_intApartadoID = Valor

        End Set

    End Property

#End Region



#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As CancelacionAbonoManager)

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

        m_intID = String.Empty
        m_intApartadoID = String.Empty

      
        SetFlagNew()
        ResetFlagDirty()

    End Sub


    ' Public Sub Save()

    'oParent.Save(Me)

    'End Sub



    Public Sub Delete()
        oParent.Delete(Me.ID, Me.ApartadoID)
    End Sub

#End Region


End Class
