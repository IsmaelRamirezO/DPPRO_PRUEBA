Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.Collections.Generic

Public Class frmBuscarTrasladoConsignacion

#Region "Variables"

    Private TipoConsignacion As TrasladoConsignacion
    Private m_TrasladoDetalle As DataTable
    Private oSAPMgr As ProcesoSAPManager

#End Region

#Region "Propiedades"

    Public Property TrasladoDetalle As DataTable
        Get
            Return m_TrasladoDetalle
        End Get
        Set(ByVal value As DataTable)
            m_TrasladoDetalle = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal Consignacion As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Me.TipoConsignacion = Consignacion

        Select Case Me.TipoConsignacion
            Case TrasladoConsignacion.ORDENCOMPRA
                Me.lblPedido.Text = "Orden de compra"
                Me.Text = "Ingrese su orden de compra"
            Case TrasladoConsignacion.DEVOLUCION
                Me.lblPedido.Text = "Devolución"
                Me.Text = "Ingrese su pedido de devolución"
        End Select
    End Sub

#End Region

#Region "Metodos y funciones"

    Private Sub BuscarTraslado()
        Dim traslado As String = Me.txtTraslado.Text.Trim()
        Dim result As New Dictionary(Of String, Object)
        If traslado <> "" Then
            Select Case Me.TipoConsignacion
                Case TrasladoConsignacion.ORDENCOMPRA
                    result = oSAPMgr.ZMMOC01(traslado, oSAPMgr.Read_Centros(), oSAPMgr.MSS_GET_SY_DATE_TIME())
                Case TrasladoConsignacion.DEVOLUCION
                    'result = oSAPMgr.ZMMOC01(traslado, oSAPMgr.Read_Centros(), oSAPMgr.MSS_GET_SY_DATE_TIME())
                    result = oSAPMgr.ZMMOD01(traslado, oSAPMgr.Read_Centros, oSAPMgr.MSS_GET_SY_DATE_TIME())
            End Select
            If result.ContainsKey("Success") Then
                If CBool(result("Success")) = True Then
                    Me.TrasladoDetalle = CType(result("Pedido"), DataTable)
                    Me.DialogResult = DialogResult.OK
                    Me.Dispose()
                Else
                    MessageBox.Show(CStr(result("Mensaje")), "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtTraslado.Text = ""
                    Me.txtTraslado.Focus()
                End If
            End If
        Else
            MessageBox.Show("El pedido esta vacio", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        BuscarTraslado()
    End Sub

    Private Sub txtTraslado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTraslado.KeyDown
        If e.KeyCode = Keys.Enter Then
            BuscarTraslado()
        End If
    End Sub

    Private Sub txtTraslado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTraslado.KeyPress
        ValidarNumeros(e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub

#End Region
    
End Class