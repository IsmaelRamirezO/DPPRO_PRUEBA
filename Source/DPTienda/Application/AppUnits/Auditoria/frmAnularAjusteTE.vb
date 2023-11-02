Imports DportenisPro.DPTienda.ApplicationUnits.traspasos.TraspasosEntrada
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
'AJS
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo


Public Class frmAnularAjusteTE
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        oTraspasoEntradaMgr = New TraspasosEntradaManager(oAppContext)
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiBSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiBAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnularAjusteTE))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.UiBSalir = New Janus.Windows.EditControls.UIButton()
        Me.UiBAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.ebFolio)
        Me.ExplorerBar1.Controls.Add(Me.UiBSalir)
        Me.ExplorerBar1.Controls.Add(Me.UiBAceptar)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Anular Ajuste por Traspaso de Entrada"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(344, 165)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebFolio
        '
        Me.ebFolio.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolio.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolio.Location = New System.Drawing.Point(160, 56)
        Me.ebFolio.MaxLength = 10
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(160, 23)
        Me.ebFolio.TabIndex = 1
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiBSalir
        '
        Me.UiBSalir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBSalir.Location = New System.Drawing.Point(192, 104)
        Me.UiBSalir.Name = "UiBSalir"
        Me.UiBSalir.Size = New System.Drawing.Size(96, 32)
        Me.UiBSalir.TabIndex = 3
        Me.UiBSalir.Text = "&Salir"
        Me.UiBSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'UiBAceptar
        '
        Me.UiBAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiBAceptar.Location = New System.Drawing.Point(72, 104)
        Me.UiBAceptar.Name = "UiBAceptar"
        Me.UiBAceptar.Size = New System.Drawing.Size(96, 32)
        Me.UiBAceptar.TabIndex = 2
        Me.UiBAceptar.Text = "&Anular"
        Me.UiBAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Folio Ajuste SAP:"
        '
        'frmAnularAjusteTE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 165)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAnularAjusteTE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anulación Ajuste"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables miembros"
    Private oTraspasoEntradaMgr As TraspasosEntradaManager
    Private oSAPMgr As ProcesoSAPManager

    'Declaracion
    'AJS
    Dim oAjusteMgr As AjusteGeneralManager
    Dim oAjusteAJS As AjusteGeneralInfo
#End Region


#Region "Metodos privados"

    Private Function GuardarDP(ByVal strTipoAjuste As String, ByVal strFolioSAP As String) As Integer
        If strTipoAjuste = "S" Then
            Dim dsInfo As New DataSet
            dsInfo = oTraspasoEntradaMgr.SelectInfoFolioAjuste(Me.ebFolio.Text.PadLeft(10, "0"))

            If dsInfo.Tables(0).Rows.Count > 0 Then
                'Asigno los datos de los articulos al detalle del oAjusteAJE
                For Each oRow1 As DataRow In dsInfo.Tables(0).Rows
                    Dim oRow As DataRow = oAjusteAJS.Detalle.NewRow
                    oRow!Codigo = oRow1.Item("Codigo")
                    oRow!Descripcion = ""
                    oRow!Talla = oRow1.Item("Talla")
                    oRow!Cantidad = oRow1.Item("Cantidad")
                    oRow!Importe = 0
                    oRow!FolioSAP = strFolioSAP
                    oAjusteAJS.Detalle.Rows.Add(oRow)
                Next
                oAjusteAJS.Detalle.AcceptChanges()



                'Guardar en DP Ajustes de Salida
                Me.oAjusteAJS.Usuario = oAppContext.Security.CurrentUser.Name
                Me.oAjusteAJS.Observaciones = "Ajuste de Salida por Anulación de Ajuste de Entrada"
                Me.oAjusteAJS.FolioSAP = "1"
                Me.oAjusteAJS.CostoTotal = 0
                Me.oAjusteAJS.TipoAjuste = "S"
                Me.oAjusteAJS.FechaAjuste = Now.Date.Today.ToShortDateString
                Me.oAjusteAJS.TotalCodigos = oAjusteAJS.Detalle.Rows.Count
                Me.oAjusteMgr.Save(Me.oAjusteAJS)
                'Me.nbFolioAUT.Value = Me.oAjusteAJS.FolioAjuste
                GuardarDP = Me.oAjusteAJS.FolioAjuste


            End If



        End If

    End Function

    Public Sub GuardarFoliosSAp(ByVal strTipoAjuste As String, ByVal StrFolioAjuste As String, ByVal strFolioSAP As String)
        If strTipoAjuste = "S" Then

            If StrFolioAjuste <> "" Then

                oAjusteMgr.UpdateESNuevoDettalleFolioSAP(StrFolioAjuste, strFolioSAP, "S")

            End If

        End If

    End Sub

    Private Function Validar(ByVal strFolio As String) As Boolean
        Validar = False


        Dim dsInfo As New DataSet
        dsInfo = oTraspasoEntradaMgr.SelectInfoFolioAjuste(strFolio)

        If dsInfo.Tables(0).Rows.Count > 0 Then
            Dim strObs As String = Mid(CStr(dsInfo.Tables(0).Rows(0).Item("Observaciones")), 1, 42)
            If strObs = "Ajuste por Sobrante en Traspaso de Entrada" Then
                Validar = True
            Else
                MsgBox("¡El ajuste no fue generado por un Traspaso de Entrada!", MsgBoxStyle.Information, Me.Text)
            End If
        Else
            MsgBox("¡El folio del ajuste no existe!", MsgBoxStyle.Information, Me.Text)
        End If


    End Function

#End Region

    Private Sub UiBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBSalir.Click
        Me.Close()
    End Sub

    Private Sub UiBAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBAceptar.Click
        If Int64.Parse(Me.ebFolio.Text.Trim) = 0 Or Me.ebFolio.Text = "" Then
            MsgBox("¡Se requiere el folio!", MsgBoxStyle.Information, Me.Text)
            Exit Sub
        End If



        If Not Validar(Me.ebFolio.Text.PadLeft(10, "0")) Then Exit Sub
        Dim strDato As String
        Dim strArreglo() As String

        strDato = oSAPMgr.ZBAPI_ANULAR_AJUSTE_TE(Me.ebFolio.Text.PadLeft(10, "0"))

        strArreglo = strDato.Split("/")

        If strArreglo(1) = "X" Then
            MsgBox("El proceso de anulación no se realizo en SAP", MsgBoxStyle.Information, Me.Text)
        Else
            Dim strFolioAjuste As Integer
            strFolioAjuste = GuardarDP("S", strArreglo(0))
            '--------------------------
            'GuardarFoliosSAp("S", strFolioAjuste, strArreglo(0))
            '--------------------------
            Me.oAjusteAJS.TipoAjuste = "S"
            If strFolioAjuste > 0 Then
                Me.oAjusteMgr.PutMovimiento(Me.oAjusteAJS)
            End If


            MsgBox("¡El proceso de anulación se realizo satisfactoriamente!", MsgBoxStyle.Information, Me.Text)
            Me.ebFolio.Text = ""
            Me.ebFolio.Focus()

        End If
    End Sub

    Private Sub frmAnularAjusteTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AJS
        oAjusteMgr = New AjusteGeneralManager(oAppContext)
        Me.oAjusteAJS = oAjusteMgr.Create("S")
        oAjusteAJS.TipoAjuste = "S"
        oAjusteAJS.Detalle.Columns("Cantidad").DefaultValue = 0
        oAjusteAJS.Detalle.Columns("Talla").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("FolioSAP").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("Codigo").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("descripcion").DefaultValue = String.Empty
        oAjusteAJS.Detalle.Columns("importe").DefaultValue = 0
        oAjusteAJS.Detalle.Columns("Total").Expression = "Cantidad * Importe"
        oAjusteAJS.Detalle.AcceptChanges()
    End Sub

    Private Sub frmAnularAjusteTE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
