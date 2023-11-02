Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneral
Imports Janus.Windows.GridEX

Public Class AjustesOpenRecordDialogView
    Implements IOpenRecordDialogView

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get

        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get

        End Get
    End Property

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding
        Dim dsDataSource As DataSet
        Dim oAjustesMgr As New AjusteGeneralManager(oAppContext)

        dsDataSource = oAjustesMgr.GetAll(TipoAjuste)
        With TargetGridEx
            .SetDataBinding(dsDataSource, "Ajustes")
            .RetrieveStructure()
        End With
    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Ajustes")
            .Columns("Folio").Caption = "Folio Ajuste"
        End With
    End Sub

    Private m_strTipoAjuste As String

    Public Property TipoAjuste() As String
        Get
            Return m_strTipoAjuste
        End Get
        Set(ByVal Value As String)
            m_strTipoAjuste = Value
        End Set
    End Property

End Class
