Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmItemColor

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeDataTable()
        LoadItemsColor()
    End Sub

    Public Sub New(ByVal item As String, ByVal talla As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        m_Item = item
        m_Talla = talla
        InitializeDataTable()
        LoadItemsColor()
    End Sub

#Region "Variables"
    Private m_Code As String
    Private m_Item As String
    Private m_Talla As String
    Private m_Color As String
    Private dtItemsColor As DataTable
    Private m_Action As System.Windows.Forms.DialogResult
#End Region

#Region "Propiedades"
    Public Property ItemsColor As DataTable
        Get
            Return dtItemsColor
        End Get
        Set(value As DataTable)
            dtItemsColor = value
        End Set
    End Property

    Public Property Code As String
        Get
            Return m_Code
        End Get
        Set(value As String)
            m_Code = value
        End Set
    End Property

    Public Property Item As String
        Get
            Return m_Item
        End Get
        Set(value As String)
            m_Item = value
        End Set
    End Property

    Public Property Talla As String
        Get
            Return m_Talla
        End Get
        Set(value As String)
            m_Talla = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return m_Color
        End Get
        Set(value As String)
            m_Color = value
        End Set
    End Property

    Public Property Action As System.Windows.Forms.DialogResult
        Get
            Return m_Action
        End Get
        Set(value As System.Windows.Forms.DialogResult)
            m_Action = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Private Sub InitializeDataTable()
        dtItemsColor = New DataTable()
        dtItemsColor.Columns.Add("CodArticulo", GetType(String))
        dtItemsColor.Columns.Add("CodArtProv", GetType(String))
        dtItemsColor.Columns.Add("Numero", GetType(String))
        dtItemsColor.Columns.Add("Color", GetType(String))
        dtItemsColor.AcceptChanges()
    End Sub

    Private Sub LoadItemsColor()
        Dim oFacturas As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim dtItem As DataTable = oFacturas.GetItemsColor(Item, Talla)
        Me.gridItemsColor.DataSource = dtItem
    End Sub

    Private Sub GetItemSelected()
        If gridItemsColor.RowCount > 0 Then
            Dim row As DataRowView = CType(gridItemsColor.GetRow().DataRow, DataRowView)
            Me.Code = CStr(row!CodArticulo)
            Me.Color = CStr(row!Color)
            Action = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If
    End Sub

#End Region

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Action = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub btnSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionar.Click
        GetItemSelected()
    End Sub

    Private Sub gridItemsColor_RowDoubleClick(sender As System.Object, e As Janus.Windows.GridEX.RowActionEventArgs) Handles gridItemsColor.RowDoubleClick
        GetItemSelected()
    End Sub
End Class