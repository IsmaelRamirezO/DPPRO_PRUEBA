Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports Janus.Windows.GridEX

Public Class AjustesOpenRecordNuevoDialogView

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

        dsDataSource = oAjustesMgr.GetAllESNuevo(TipoConsulta)
        With TargetGridEx
            .SetDataBinding(dsDataSource, "Ajustes")
            .RetrieveStructure()
        End With


    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView
        With TargetGridEx.Tables("Ajustes")
            .Columns("FolioAjuste").Caption = "Folio Ajuste"
            .Columns("FolioAJS").Caption = "Ajuste Salida"
            .Columns("FolioAJE").Caption = "Ajuste Entrada"
        End With
    End Sub

    Private m_strTipoConsulta As String

    Public Property TipoConsulta() As String
        Get
            Return m_strTipoConsulta
        End Get
        Set(ByVal Value As String)
            m_strTipoConsulta = Value
        End Set
    End Property

End Class
