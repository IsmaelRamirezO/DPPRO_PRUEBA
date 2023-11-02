Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports Janus.Windows.GridEX

Public Class CatalogoCodigosPostales

    Implements IOpenRecordDialogView

    Dim m_strCodEstado As String = ""
    Dim m_strCodMunicipio As String = ""
    Dim m_strColonia As String = ""

    Public Sub New(ByVal CodEst As String, ByVal CodMun As String, ByVal strColonia As String)
        CodEstado = CodEst
        CodMunicipio = CodMun
        Colonia = strColonia
    End Sub

#Region "Properties"

    Public ReadOnly Property AllowFilterBy() As Boolean Implements IOpenRecordDialogView.AllowFilterBy
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property AllowGroupBy() As Boolean Implements IOpenRecordDialogView.AllowGroupBy
        Get
            Return True
        End Get
    End Property

    Public Property CodEstado() As String
        Get
            Return m_strCodEstado
        End Get
        Set(ByVal Value As String)
            m_strCodEstado = Value
        End Set
    End Property

    Public Property CodMunicipio() As String
        Get
            Return m_strCodMunicipio
        End Get
        Set(ByVal Value As String)
            m_strCodMunicipio = Value
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value
        End Set
    End Property

#End Region



#Region "Private Methods"

    Public Sub SetupDataBinding(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupDataBinding

        Dim dsDataSource As DataSet
        Dim oAlmacenesMgr As New CatalogoAlmacenesManager(oAppContext)

        dsDataSource = oAlmacenesMgr.GetCodigosPostalesByColonia(CodEstado, CodMunicipio, Colonia)

        With TargetGridEx
            .SetDataBinding(dsDataSource, "CodigosPostales")
            .RetrieveStructure()
        End With

    End Sub

    Public Sub SetupView(ByVal TargetGridEx As Janus.Windows.GridEX.GridEX) Implements IOpenRecordDialogView.SetupView

        With TargetGridEx.Tables("CodigosPostales")

            .Columns("CP").Caption = "Código"
            .Columns("CP").Width = 70

            .Columns("Asentamiento").Caption = "Colonia"
            .Columns("Asentamiento").Visible = True
            .Columns("Asentamiento").Width = 320

        End With

    End Sub

#End Region

End Class
