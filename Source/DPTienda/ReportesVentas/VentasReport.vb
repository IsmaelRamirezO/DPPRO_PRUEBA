Public Class VentasReport

    Private m_oCurrentReporter As IVentasReporter
    Private m_dsData As DataSet


#Region "Properties"

    Public Property CurrentReporter() As IVentasReporter
        Get
            Return m_oCurrentReporter
        End Get
        Set(ByVal Value As IVentasReporter)
            m_oCurrentReporter = Value
        End Set
    End Property

    Public ReadOnly Property Data() As DataSet
        Get
            Return m_dsData
        End Get
    End Property

#End Region


#Region "Constructors"

    Public Sub New()

        Clear()

    End Sub

    Public Sub New(ByVal Reporter As IVentasReporter)

        m_oCurrentReporter = Reporter

    End Sub

#End Region


#Region "Methods"

    Public Function Generate() As DataSet

        m_dsData = New DataSet

        m_dsData = m_oCurrentReporter.Run

        Return m_dsData

    End Function

    Public Function GenerateNew() As DataSet

        m_dsData = New DataSet

        m_dsData = m_oCurrentReporter.RunNew

        Return m_dsData

    End Function


    Public Function GenerateNewPreview() As DataSet

        m_dsData = New DataSet

        m_dsData = m_oCurrentReporter.RunNewPreview

        Return m_dsData

    End Function


    Public Function GenerateFolioSAP() As DataSet

        m_dsData = New DataSet

        m_dsData = m_oCurrentReporter.RunFolioSAP

        Return m_dsData

    End Function

    Public Sub Clear()

        m_oCurrentReporter = Nothing
        m_dsData = Nothing

    End Sub

#End Region



End Class
