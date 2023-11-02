Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoMarcas

Public Class frmPromosAplicadasCS
    Inherits System.Windows.Forms.Form

    Dim dvSource As DataView
    Dim Modulo As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strModulo As String, Optional ByVal dtPromosAplicadas As DataTable = Nothing, Optional ByVal dtPromosVigentes As DataTable = Nothing, Optional ByVal dtCS As DataTable = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Modulo = strModulo
        FormatearInfo(dtPromosAplicadas, dtPromosVigentes, dtCS)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents grdPromos As Janus.Windows.GridEX.GridEX
    Friend WithEvents expCS As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grdCS As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPromosAplicadasCS))
        Dim GridEXLayout2 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdPromos = New Janus.Windows.GridEX.GridEX()
        Me.expCS = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.grdCS = New Janus.Windows.GridEX.GridEX()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdPromos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.expCS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expCS.SuspendLayout()
        CType(Me.grdCS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.grdPromos)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(546, 288)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'grdPromos
        '
        Me.grdPromos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdPromos.DesignTimeLayout = GridEXLayout1
        Me.grdPromos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPromos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdPromos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPromos.GroupByBoxVisible = False
        Me.grdPromos.Location = New System.Drawing.Point(0, 0)
        Me.grdPromos.Name = "grdPromos"
        Me.grdPromos.Size = New System.Drawing.Size(546, 288)
        Me.grdPromos.TabIndex = 1
        Me.grdPromos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'expCS
        '
        Me.expCS.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.expCS.Controls.Add(Me.grdCS)
        Me.expCS.Controls.Add(Me.lblMessage)
        Me.expCS.Controls.Add(Me.lblMensaje)
        Me.expCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.expCS.Location = New System.Drawing.Point(0, 0)
        Me.expCS.Name = "expCS"
        Me.expCS.Size = New System.Drawing.Size(546, 288)
        Me.expCS.TabIndex = 1
        Me.expCS.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'grdCS
        '
        Me.grdCS.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEXLayout2.LayoutString = resources.GetString("GridEXLayout2.LayoutString")
        Me.grdCS.DesignTimeLayout = GridEXLayout2
        Me.grdCS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdCS.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grdCS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCS.GroupByBoxVisible = False
        Me.grdCS.Location = New System.Drawing.Point(0, 80)
        Me.grdCS.Name = "grdCS"
        Me.grdCS.Size = New System.Drawing.Size(546, 208)
        Me.grdCS.TabIndex = 5
        Me.grdCS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMessage.Location = New System.Drawing.Point(9, 40)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(528, 32)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Podrías aprovechar las siguientes promociones si te llevas un artículo más que cu" & _
    "mpla con las condiciones que se muestran a continuación:"
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Location = New System.Drawing.Point(8, 8)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(528, 56)
        Me.lblMensaje.TabIndex = 3
        Me.lblMensaje.Text = "Espera ... Te estas perdiendo de una o varias promociones"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmPromosAplicadasCS
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(546, 288)
        Me.Controls.Add(Me.expCS)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPromosAplicadasCS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Promociones Aplicadas"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdPromos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.expCS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expCS.ResumeLayout(False)
        CType(Me.grdCS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MostrarGrid()

        Select Case Modulo.Trim.ToUpper
            Case "PA"
                Me.grdPromos.DataSource = Nothing
                Me.grdPromos.DataSource = dvSource
                Me.grdPromos.Refresh()
            Case "CS"
                Me.grdCS.DataSource = Nothing
                Me.grdCS.DataSource = dvSource
                Me.grdCS.Refresh()
        End Select

    End Sub

    Private Sub FormatearInfo(ByVal dtPromoA As DataTable, ByVal dtPromoV As DataTable, ByVal dtCS As DataTable)

        Dim dtTemp As DataTable
        Dim oRow As DataRow

        Select Case Modulo.Trim.ToUpper
            Case "PA" 'Promociones Aplicadas
                dtTemp = dtPromoA.Copy

                dtTemp.Columns.Add("PromoDesc", GetType(String))
                dtTemp.AcceptChanges()

                Dim dvPromoVig As New DataView(dtPromoV)

                For Each oRow In dtTemp.Rows
                    dvPromoVig.RowFilter = "ID = '" & CStr(oRow!Promocion).Trim & "'"
                    If dvPromoVig.Count > 0 Then
                        oRow!PromoDesc = CStr(dvPromoVig(0)!Promocion_Text).Trim & " - " & CStr(dvPromoVig(0)!Descripcion).Trim
                    End If
                    oRow!descto_promo_pje /= 100
                Next

                dvSource = New DataView(dtTemp, "Promocion <> ''", "", DataViewRowState.CurrentRows)
            Case "CS" 'Cross Selling

                Dim oNewRow As DataRow, dvCond As DataView

                dtTemp = New DataTable("CS")
                dtTemp.Columns.Add("PromoID", GetType(String))
                dtTemp.Columns.Add("PromoDesc", GetType(String))
                dtTemp.Columns.Add("Condicion", GetType(String))
                dtTemp.Columns.Add("CondicionDesc", GetType(String))
                dtTemp.AcceptChanges()

                dvCond = New DataView(dtTemp, "", "", DataViewRowState.CurrentRows)

                For Each oRow In dtCS.Rows
                    If CStr(oRow!Falta).Trim.ToUpper = "X" Then
                        If oRow!Condicion = "MCA" Then
                            dvCond.RowFilter = "Condicion = '" & oRow!Condicion & "' and PromoID = '" & oRow!ID & "'"
                            If dvCond.Count > 0 Then
                                dvCond(0)!CondicionDesc = FormatearCondicion(oRow!condicion, oRow!operador, oRow!valor, oRow!bolsa_ref, dtCS, dvCond(0).Row)
                            Else
                                GoTo NewRow
                            End If
                        Else
NewRow:
                            oNewRow = dtTemp.NewRow
                            With oNewRow
                                !PromoID = oRow!ID
                                !PromoDesc = oRow!Promocion_Text & " - " & oRow!Descripcion
                                !Condicion = oRow!Condicion
                                !CondicionDesc = FormatearCondicion(oRow!condicion, oRow!operador, oRow!valor, oRow!bolsa_ref, dtCS)
                            End With
                            dtTemp.Rows.Add(oNewRow)
                        End If
                    End If
                Next

                dvSource = New DataView(dtTemp, "", "", DataViewRowState.CurrentRows)

        End Select

    End Sub

    Private Function FormatearCondicion(ByVal Codigo As String, ByVal Op As String, ByVal Valor As String, ByVal Bolsa As String, _
                                        ByVal dtCS As DataTable, Optional ByVal oRowCond As DataRow = Nothing) As String

        Dim strCond As String = ""
        Dim dvBolsa As DataView
        Dim oMarcaMgr As New CatalogoMarcasManager(oAppContext)

        Select Case Codigo.Trim.ToUpper
            Case "PRE" 'Precio
                strCond = "Precio " & OperadorToString(Op)
                If Valor.Trim.ToUpper = "BOLSA" Then
                    dvBolsa = New DataView(dtCS, "Bolsa = '" & Bolsa & "'", "", DataViewRowState.CurrentRows)
                    strCond &= " la bolsa """ & CStr(dvBolsa(0)!Descripcion_b).Trim & """"
                Else
                    strCond &= " " & Valor
                End If
            Case "MCA" 'Marca
                If oRowCond Is Nothing Then
                    strCond = "Marca " & OperadorToString(Op) & " " & oMarcaMgr.Load(Valor.Trim).Descripcion.Trim
                Else
                    strCond = oRowCond!CondicionDesc & ", " & oMarcaMgr.Load(Valor.Trim).Descripcion.Trim
                End If
            Case "FAM" 'Familia
        End Select

        Return strCond.Trim

    End Function

    Private Function OperadorToString(ByVal Op As String) As String

        Dim strOp As String = ""

        Select Case Op.Trim
            Case "="
                strOp = "igual que"
            Case "<="
                strOp &= "menor o igual que"
            Case ">="
                strOp = "mayor o igual que"
            Case "<"
                strOp = "menor que"
            Case ">"
                strOp = "mayor que"
        End Select

        Return strOp.Trim
    End Function

    Private Sub frmPromosAplicadasCS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case Modulo.Trim.ToUpper
            Case "PA" 'Promicones Aplicadas
                Me.expCS.Visible = False
            Case "CS" 'Cross Selling
                Me.expCS.Visible = True
                Me.Text = "Cross Selling"
        End Select
        MostrarGrid()
    End Sub

End Class
