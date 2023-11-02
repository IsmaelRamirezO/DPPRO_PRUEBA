
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Export
Imports DataDynamics.ActiveReports.Export.Html
Imports DataDynamics.ActiveReports.Export.Pdf
Imports DataDynamics.ActiveReports.Export.Rtf
Imports DataDynamics.ActiveReports.Export.Text
Imports DataDynamics.ActiveReports.Export.Tiff
Imports DataDynamics.ActiveReports.Export.Xls


Public Class ExportForm
    Inherits System.Windows.Forms.Form
    Private pnlTop As System.Windows.Forms.Panel
    Private pnlBottom As System.Windows.Forms.Panel
    Private lblTitle As System.Windows.Forms.Label
    Private lblSubTitle As System.Windows.Forms.Label
    Private pnlFill As System.Windows.Forms.Panel
    Private WithEvents cboExportFormat As System.Windows.Forms.ComboBox
    Private lblExportFormat As System.Windows.Forms.Label
    Private lblFilename As System.Windows.Forms.Label
    Private txtFilename As System.Windows.Forms.TextBox
    Private WithEvents btnSaveFile As System.Windows.Forms.Button

    Private doc As DataDynamics.ActiveReports.Document.Document
    Private WithEvents btnOk As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private pnlOptions As System.Windows.Forms.Panel
    Private pg As System.Windows.Forms.PropertyGrid

    Private components As System.ComponentModel.Container = Nothing

    Private export As Object = Nothing


    Public Sub New(ByVal doc As DataDynamics.ActiveReports.Document.Document)
        InitializeComponent()

        Me.doc = doc
    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose


    '
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.lblSubTitle = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.pnlFill = New System.Windows.Forms.Panel
        Me.pnlOptions = New System.Windows.Forms.Panel
        Me.pg = New System.Windows.Forms.PropertyGrid
        Me.btnSaveFile = New System.Windows.Forms.Button
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblExportFormat = New System.Windows.Forms.Label
        Me.cboExportFormat = New System.Windows.Forms.ComboBox
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlFill.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.SystemColors.Window
        Me.pnlTop.Controls.Add(Me.lblSubTitle)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(506, 48)
        Me.pnlTop.TabIndex = 0
        '
        'lblSubTitle
        '
        Me.lblSubTitle.Location = New System.Drawing.Point(16, 24)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Size = New System.Drawing.Size(360, 16)
        Me.lblSubTitle.TabIndex = 1
        Me.lblSubTitle.Text = "Seleciona el formato y Nombre de exportación."
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 20)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Exportar Reporte"
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnOk)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 128)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(506, 48)
        Me.pnlBottom.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(360, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancelar"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(264, 16)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 24)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&OK"
        '
        'pnlFill
        '
        Me.pnlFill.Controls.Add(Me.pnlOptions)
        Me.pnlFill.Controls.Add(Me.btnSaveFile)
        Me.pnlFill.Controls.Add(Me.txtFilename)
        Me.pnlFill.Controls.Add(Me.cboExportFormat)
        Me.pnlFill.Controls.Add(Me.lblFilename)
        Me.pnlFill.Controls.Add(Me.lblExportFormat)
        Me.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFill.Location = New System.Drawing.Point(0, 48)
        Me.pnlFill.Name = "pnlFill"
        Me.pnlFill.Size = New System.Drawing.Size(506, 80)
        Me.pnlFill.TabIndex = 2
        '
        'pnlOptions
        '
        Me.pnlOptions.Controls.Add(Me.pg)
        Me.pnlOptions.Location = New System.Drawing.Point(56, 56)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(440, 88)
        Me.pnlOptions.TabIndex = 5
        '
        'pg
        '
        Me.pg.CommandsVisibleIfAvailable = True
        Me.pg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pg.HelpVisible = False
        Me.pg.LargeButtons = False
        Me.pg.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.pg.Location = New System.Drawing.Point(0, 0)
        Me.pg.Name = "pg"
        Me.pg.PropertySort = System.Windows.Forms.PropertySort.NoSort
        Me.pg.Size = New System.Drawing.Size(440, 88)
        Me.pg.TabIndex = 0
        Me.pg.Text = "PropertyGrid"
        Me.pg.ToolbarVisible = False
        Me.pg.ViewBackColor = System.Drawing.SystemColors.Window
        Me.pg.ViewForeColor = System.Drawing.SystemColors.WindowText
        Me.pg.Visible = False
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Location = New System.Drawing.Point(464, 32)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(32, 20)
        Me.btnSaveFile.TabIndex = 4
        Me.btnSaveFile.Text = "..."
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(152, 32)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(312, 22)
        Me.txtFilename.TabIndex = 3
        Me.txtFilename.Text = ""
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Location = New System.Drawing.Point(11, 34)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(135, 18)
        Me.lblFilename.TabIndex = 2
        Me.lblFilename.Text = "Nombre y Ruta de archivo:"
        '
        'lblExportFormat
        '
        Me.lblExportFormat.AutoSize = True
        Me.lblExportFormat.Location = New System.Drawing.Point(37, 10)
        Me.lblExportFormat.Name = "lblExportFormat"
        Me.lblExportFormat.Size = New System.Drawing.Size(109, 18)
        Me.lblExportFormat.TabIndex = 1
        Me.lblExportFormat.Text = "Formato exportación:"
        '
        'cboExportFormat
        '
        Me.cboExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExportFormat.Items.AddRange(New Object() {"HTML Format (HTM)", "Portable Document Format (PDF)", "Rich Text Format (RTF)", "TIFF Format (TIF)", "Text Format (TXT)", "Microsoft Excel (XLS)"})
        Me.cboExportFormat.Location = New System.Drawing.Point(152, 8)
        Me.cboExportFormat.Name = "cboExportFormat"
        Me.cboExportFormat.Size = New System.Drawing.Size(344, 24)
        Me.cboExportFormat.TabIndex = 0
        '
        'ExportForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(506, 176)
        Me.Controls.Add(Me.pnlFill)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlFill.ResumeLayout(False)
        Me.pnlOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent

    Private Sub cboExportFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExportFormat.SelectedIndexChanged
        txtFilename.Text = ""
        Me.export = Nothing
        pg.SelectedObject = Nothing

        Select Case cboExportFormat.SelectedIndex
            Case 0 ' html
                Me.export = New HtmlExport()
            Case 1 ' pdf
                Me.export = New PdfExport()
                pg.SelectedObject = Me.export
            Case 2 ' rtf
                Me.export = New RtfExport()
            Case 3 ' tiff
                Me.export = New TiffExport()
                pg.SelectedObject = Me.export
            Case 4 ' txt
                Me.export = New TextExport()
            Case 5 ' xls
                Me.export = New XlsExport()
                pg.SelectedObject = Me.export
            Case Else
                Me.export = Nothing
        End Select
        pg.SelectedObject = Me.export
    End Sub 'cboExportFormat_SelectedIndexChanged


    Private Sub ExportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboExportFormat.SelectedIndex = 1 ' pdf
    End Sub 'ExportForm_Load


    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub 'btnCancel_Click


    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If txtFilename.Text.Length = 0 Then
                Return
            End If
            If File.Exists(txtFilename.Text) Then
                If MessageBox.Show(Me, "Sobreescribir el archivo existente?", "Sobreescribir archivo", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Return
                End If
            End If

            Select Case cboExportFormat.SelectedIndex
                Case 0
                    CType(export, HtmlExport).Export(Me.doc, Me.txtFilename.Text)
                Case 1
                    CType(export, PdfExport).Export(Me.doc, Me.txtFilename.Text)
                Case 2
                    CType(export, RtfExport).Export(Me.doc, Me.txtFilename.Text)
                Case 3
                    CType(export, TiffExport).Export(Me.doc, Me.txtFilename.Text)
                Case 4
                    CType(export, TextExport).Export(Me.doc, Me.txtFilename.Text)
                Case 5
                    CType(export, XlsExport).Export(Me.doc, Me.txtFilename.Text)
            End Select
            Me.Close()
        Catch exp As Exception
            MessageBox.Show(Me, exp.ToString())
        End Try
        Return
    End Sub 'btnOk_Click


    Private Sub btnSaveFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveFile.Click
        Dim sfd As New SaveFileDialog()
        sfd.Title = "Export Report Document"
        sfd.AddExtension = True

        Select Case cboExportFormat.SelectedIndex
            Case 0
                sfd.DefaultExt = "htm"
                sfd.Filter = "HTML Files (*.htm;*.html)|*.htm;*.htm"
            Case 1
                sfd.DefaultExt = "htm"
                sfd.Filter = "PDF Files (*.pdf)|*.pdf"
            Case 2
                sfd.DefaultExt = "rtf"
                sfd.Filter = "Rich Text Files (*.rtf)|*.rtf"
            Case 3
                sfd.DefaultExt = "tif"
                sfd.Filter = "Tiff Image Files (*.tif)|*.tif"
            Case 4
                sfd.DefaultExt = "txt"
                sfd.Filter = "Text Files (*.txt)|*.txt"
            Case 5
                sfd.DefaultExt = "xls"
                sfd.Filter = "Microsoft Excel Files (*.xls)|*.xls"
        End Select
        If sfd.ShowDialog() = DialogResult.OK Then
            txtFilename.Text = sfd.FileName
        End If
    End Sub 'btnSaveFile_Click
End Class 'ExportForm