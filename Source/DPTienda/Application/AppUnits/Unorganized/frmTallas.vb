Imports DportenisPro.DPTienda.ApplicationUnits.Facturas

Public Class frmTallas

#Region "Variables de instancia"

    Private dtExistencias As DataTable
    Private FacturaMgr As FacturaManager
    Private OldCodArticulo As String
    Private OldColor As String
    Private m_CodArticulo As String
    Private m_CodArtProv As String
    Private m_Numero As String
    Private m_Color As String
    Private m_Cantidad As Integer

#End Region

#Region "Propiedades"

    Public Property CodArticulo As String
        Get
            Return m_CodArticulo
        End Get
        Set(ByVal value As String)
            m_CodArticulo = value
        End Set
    End Property

    Public Property CodArtProv As String
        Get
            Return m_CodArtProv
        End Get
        Set(ByVal value As String)
            m_CodArtProv = value
        End Set
    End Property

    Public Property Numero As String
        Get
            Return m_Numero
        End Get
        Set(ByVal value As String)
            m_Numero = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return m_Color
        End Get
        Set(ByVal value As String)
            m_Color = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return m_Cantidad
        End Get
        Set(ByVal value As Integer)
            m_Cantidad = value
        End Set
    End Property



#End Region

#Region "Constructores"

    Public Sub New(ByVal CodArticulo As String, ByVal Color As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.OldCodArticulo = CodArticulo
        Me.OldColor = Color
        Inicializar()
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub Inicializar()
        FacturaMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        dtExistencias = FacturaMgr.GetExistenciasCambioTalla(oAppContext.ApplicationConfiguration.Almacen, Me.OldCodArticulo, Me.OldColor)
        Me.cmbTallas.DisplayMember = "Numero"
        Me.cmbTallas.ValueMember = "CodArticulo"
        Me.cmbTallas.DataSource = dtExistencias
        Me.cmbTallas.Refresh()
    End Sub

    Private Sub SelectItem()
        If Not cmbTallas.Value Is Nothing Then
            Dim row As DataRowView = CType(cmbTallas.DropDownList.GetRow().DataRow, DataRowView)
            If CInt(txtCantidad.Value) > 0 Then
                If CInt(txtCantidad.Value) <= CInt(row!Libre) Then
                    Me.CodArtProv = CStr(row!CodArtProv)
                    Me.CodArticulo = CStr(row!CodArticulo)
                    Me.Numero = CStr(row!Numero)
                    Me.Color = CStr(row!Color)
                    Me.Cantidad = CInt(txtCantidad.Value)
                    Me.DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("La cantidad no puede ser mayor a la existencia", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("La cantidad debe ser mayor a cero", "Cambio de Talla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not cmbTallas.Value Is Nothing Then
            SelectItem()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub


#End Region

End Class