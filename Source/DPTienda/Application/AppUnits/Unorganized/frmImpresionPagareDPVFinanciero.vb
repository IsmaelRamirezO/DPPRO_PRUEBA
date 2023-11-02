Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmImpresionPagareDPVFinanciero
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblNoDPVale As System.Windows.Forms.Label
    Friend WithEvents nebNoDPVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.nebNoDPVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.lblNoDPVale = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.nebNoDPVale)
        Me.explorerBar1.Controls.Add(Me.btnImprimir)
        Me.explorerBar1.Controls.Add(Me.lblNoDPVale)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(328, 64)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'nebNoDPVale
        '
        Me.nebNoDPVale.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.nebNoDPVale.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.nebNoDPVale.FormatString = "0000000000"
        Me.nebNoDPVale.Location = New System.Drawing.Point(104, 24)
        Me.nebNoDPVale.Name = "nebNoDPVale"
        Me.nebNoDPVale.Size = New System.Drawing.Size(112, 20)
        Me.nebNoDPVale.TabIndex = 0
        Me.nebNoDPVale.Text = "0000000000"
        Me.nebNoDPVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.nebNoDPVale.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.nebNoDPVale.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(224, 24)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(96, 23)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.Text = "Imprimir Pagaré"
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblNoDPVale
        '
        Me.lblNoDPVale.BackColor = System.Drawing.Color.Transparent
        Me.lblNoDPVale.Location = New System.Drawing.Point(16, 24)
        Me.lblNoDPVale.Name = "lblNoDPVale"
        Me.lblNoDPVale.Size = New System.Drawing.Size(96, 16)
        Me.lblNoDPVale.TabIndex = 9
        Me.lblNoDPVale.Text = "# DPortenis Vale"
        '
        'frmImpresionPagareDPVFinanciero
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 64)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmImpresionPagareDPVFinanciero"
        Me.Text = "Impresion Pagare DPVale Financiero"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim oSAPMgr As ProcesoSAPManager
    Dim oDPVale As cDPVale

    Private Sub ImprimirPagare(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        Dim oRow As DataRow

        oDPVale = New cDPVale
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Try
            'If e.KeyCode = Keys.Enter Then
            oDPVale.INUMVA = CStr(Me.nebNoDPVale.Value).PadLeft(10, "0").Trim
            oDPVale.I_RUTA = "X"
            oDPVale = oSAPMgr.ZBAPI_VALIDA_DPVALE(oDPVale)

            If oDPVale.EEXIST = "S" Then
                Dim NombreCliente As String = ""
                Dim NombreDist As String = ""
                Dim NoCliente As String = ""
                Dim NoDist As String = ""
                Dim Monto As Double = 0
                Dim NoFactura As String = ""
                Dim NoDocFI As String = ""

                oRow = oDPVale.InfoDPVALE.Rows(0)

                If oDPVale.ESTATU = "U" Then

                    If CStr(oRow!DOCDP).ToUpper.Trim <> "PRESTAMO F" Then

                        MsgBox("El vale capturado no está relacionado a un préstamo financiero", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                        oDPVale = Nothing
                        oSAPMgr = Nothing
                        Me.nebNoDPVale.Focus()

                    Else

                        With oRow

                            NoDist = CStr(!KUNNR).PadLeft(10, "0")
                            NombreDist = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(NoDist)
                            NoCliente = CStr(!CODCT).PadLeft(10, "0")
                            NombreCliente = oSAPMgr.ZBAPI_NOMBRE_CLIENTE(NoCliente)
                            Monto = !MONDP
                            NoFactura = !NUMFA
                            NoDocFI = !DOCSP

                        End With

                        Dim oARReport As New rptDPValeFinanciero(NoCliente, NoDist, CStr(nebNoDPVale.Value).PadLeft(10, "0"), _
                                                                 NombreCliente, NombreDist, _
                                                                 CStr(Monto / 8), _
                                                                 oAppSAPConfig.Plaza, "8", NoFactura, _
                                                                 NoDocFI, "")
                        Dim oARReportCopy As New rptDPValeFinancieroCopia(NoCliente, NoDist, _
                                                                          NoDocFI, CStr(nebNoDPVale.Value).PadLeft(10, "0"), NoFactura, _
                                                                          NombreCliente, NombreDist, CStr(Monto / 8), _
                                                                          oAppSAPConfig.Plaza, "8", "")

                        oARReport.Document.Name = "Pagare DPVale Financiero"
                        oARReport.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReport.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReport.PageSettings.Margins.Left = 0.3F

                        oARReport.Run()
                        oARReport.Document.Print(False, False)
                        'Dim oView As New ReportViewerForm
                        'oView.Report = oARReport
                        'oView.Show()

                        oARReportCopy.Document.Name = "Pagare DPVale Financiero Copia"
                        oARReportCopy.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                        oARReportCopy.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed
                        oARReportCopy.PageSettings.Margins.Left = 0.3F

                        oARReportCopy.Run()
                        oARReportCopy.Document.Print(False, False)
                        'oView = New ReportViewerForm
                        'oView.Report = oARReportCopy
                        'oView.Show()

                        MsgBox("La impresión se ha realizado con éxito", MsgBoxStyle.Information, "DPVale Financiero")

                        oDPVale = Nothing
                        oSAPMgr = Nothing

                    End If

                Else
                    If oRow.Item("STATU") = "C" Then
                        MsgBox("El vale capturado está cancelado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    Else
                        MsgBox("El vale capturado no ha sido utilizado", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                    End If
                    Me.oDPVale = Nothing
                    Me.oSAPMgr = Nothing
                    'ClearFields()
                    Me.nebNoDPVale.Focus()
                End If
            Else
                MsgBox("El vale capturado no existe", MsgBoxStyle.Exclamation, "Dportenis Vale Financiero")
                Me.oDPVale = Nothing
                Me.oSAPMgr = Nothing
                'ClearFields()
                Me.nebNoDPVale.Focus()
            End If
            'End If
        Catch ex As Exception
            Me.oDPVale = Nothing
            Me.oSAPMgr = Nothing
        End Try

    End Sub

End Class
