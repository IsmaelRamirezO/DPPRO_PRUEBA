Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos
Imports DataDynamics.ActiveReports.Export.Pdf
Imports DataDynamics.ActiveReports.Export.Xls
Imports System.IO

Public Class frmReporteDefectusosEC
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
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
    Friend WithEvents grdDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteDefectusosEC))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnExportar = New Janus.Windows.EditControls.UIButton()
        Me.grdDetalle = New Janus.Windows.GridEX.GridEX()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.btnSalir)
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.btnExportar)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(882, 320)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(576, 280)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(144, 32)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowColumnDrag = False
        Me.grdDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdDetalle.AlternatingColors = True
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grdDetalle.DesignTimeLayout = GridEXLayout1
        Me.grdDetalle.GroupByBoxVisible = False
        Me.grdDetalle.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.grdDetalle.Location = New System.Drawing.Point(0, 8)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.Size = New System.Drawing.Size(870, 264)
        Me.grdDetalle.TabIndex = 1
        Me.grdDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(426, 280)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(144, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Icon = CType(resources.GetObject("btnSalir.Icon"), System.Drawing.Icon)
        Me.btnSalir.Location = New System.Drawing.Point(726, 280)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(144, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'frmReporteDefectusosEC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(882, 320)
        Me.Controls.Add(Me.grdDetalle)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReporteDefectusosEC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Articulos de Baja Calidad"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oSAPMgr As ProcesoSAPManager
    Dim dtDetalle As DataTable
    Dim oArtMgr As CatalogoArticuloManager

    Private Sub Inicializar()

        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oArtMgr = New CatalogoArticuloManager(oAppContext)

        If oConfigCierreFI.BloqueaBajaCalidad = False Then
            dtDetalle = oSAPMgr.ZPOL_GET_DEFT_CENTRO
            btnImprimir.Location = New Point(8, 280)
            btnExportar.Location = New Point(160, 280)
            btnSalir.Location = New Point(376, 280)
            Me.Size = New Size(536, 352)
            Me.grdDetalle.RootTable.Columns("Fecha").Visible = False
            Me.grdDetalle.RootTable.Columns("Hora").Visible = False
            Me.grdDetalle.RootTable.Columns("Responsable").Visible = False
        Else
            dtDetalle = oSAPMgr.ZPOL_GET_DEFT_CENTRO(, "X")
        End If


        ComplementarDetalle()

    End Sub

    Private Sub ComplementarDetalle()

        Dim oArticulo As Articulo
        Dim oRow As DataRow
        Dim strFecha As String = ""
        Dim strHora As String = ""

        dtDetalle.Columns.Add("Descripcion", GetType(String))

        For Each oRow In dtDetalle.Rows
            oArticulo = Nothing
            oArticulo = oArtMgr.Load(CStr(oRow!Material).Trim)
            If Not oArticulo Is Nothing Then
                oRow!Descripcion = oArticulo.Descripcion.Trim
            End If
            '------------------------------------------------------------------------------------------------------------------------------------
            'FLIZARRAGA 15/06/2015: Se le da formato a la fecha y Hora en caso de que este activada la configuracion de Bloqueos de Baja Calidad
            '------------------------------------------------------------------------------------------------------------------------------------
            If oConfigCierreFI.BloqueaBajaCalidad = True Then
                strFecha = CStr(oRow!Fecha)
                strHora = CStr(oRow!Hora)
                If strFecha <> "" Then
                    oRow("Fecha") = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                End If
                If strHora <> "" Then
                    oRow("Hora") = strHora.Substring(0, 2) & ":" & strHora.Substring(2, 2) & ":" & strHora.Substring(4, 2)
                End If
            End If
        Next

        

        dtDetalle.AcceptChanges()

        ActualizarGrid()

    End Sub

    Private Sub ActualizarGrid()

        Me.grdDetalle.DataSource = dtDetalle
        Me.grdDetalle.Refresh()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        If dtDetalle.Rows.Count > 0 Then
            Dim rptDefecEC As New rptDefectuososEC(dtDetalle)
            rptDefecEC.Document.Name = "Reporte de Marcados como Baja Calidad para Ecommerce"
            rptDefecEC.Run()

            Dim oView As New ReportViewerForm
            oView.Report = rptDefecEC

            oView.Show()
        End If

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        If dtDetalle.Rows.Count > 0 Then
            Dim ruta As String = ""
            Dim oFileRuta As New SaveFileDialog
            If oConfigCierreFI.BloqueaBajaCalidad = True Then
                oFileRuta.Filter = "XLS|*.xls"
            Else
                oFileRuta.Filter = "PDF|*.pdf"
            End If
            oFileRuta.ShowDialog()
            If oFileRuta.FileName.Trim <> "" Then
                Dim rptDefecEC As New rptDefectuososEC(dtDetalle)
                rptDefecEC.Document.Name = "Reporte de Marcados como Baja Calidad para Ecommerce"
                rptDefecEC.Run()

                
                '--------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 03/07/2015: Para productos de bloqueos de Baja Calidad
                '--------------------------------------------------------------------------------------------------------------
                If oConfigCierreFI.BloqueaBajaCalidad = True Then
                    Dim oXLS As New XlsExport
                    oXLS.Export(rptDefecEC.Document, oFileRuta.FileName.Trim & ".xls")
                Else
                    Dim oPDF As New PdfExport
                    oPDF.Export(rptDefecEC.Document, oFileRuta.FileName.Trim & ".pdf")
                End If
                
                MessageBox.Show("Archivo Guardado Correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

End Class
