Imports Microsoft.Win32
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.Traspasos.TraspasosEntrada
Imports Microsoft.Office.Interop
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmReporteDiferenciasTraspasos
    Inherits System.Windows.Forms.Form

    Dim oAlmacenMgr As CatalogoAlmacenesManager
    Dim oTraspasoEMgr As TraspasosEntradaManager
    Dim dsDiferencias As DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oAlmacenMgr = New CatalogoAlmacenesManager(oAppContext, oConfigCierreFI)
        oTraspasoEMgr = New TraspasosEntradaManager(oAppContext, oConfigCierreFI)
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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents cmbDesde As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbHasta As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteDiferenciasTraspasos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.cmbHasta = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDesde = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.cmbHasta)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.cmbDesde)
        Me.ExplorerBar1.Controls.Add(Me.lblLabel1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(386, 104)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Icon = CType(resources.GetObject("btnGenerar.Icon"), System.Drawing.Icon)
        Me.btnGenerar.ImageSize = New System.Drawing.Size(30, 30)
        Me.btnGenerar.Location = New System.Drawing.Point(216, 16)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(152, 64)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'cmbHasta
        '
        '
        '
        '
        Me.cmbHasta.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbHasta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHasta.Location = New System.Drawing.Point(72, 56)
        Me.cmbHasta.Name = "cmbHasta"
        Me.cmbHasta.Size = New System.Drawing.Size(136, 27)
        Me.cmbHasta.TabIndex = 1
        Me.cmbHasta.TodayButtonText = "Hoy"
        Me.cmbHasta.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Hasta"
        '
        'cmbDesde
        '
        '
        '
        '
        Me.cmbDesde.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.cmbDesde.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesde.Location = New System.Drawing.Point(72, 16)
        Me.cmbDesde.Name = "cmbDesde"
        Me.cmbDesde.Size = New System.Drawing.Size(136, 27)
        Me.cmbDesde.TabIndex = 0
        Me.cmbDesde.TodayButtonText = "Hoy"
        Me.cmbDesde.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(16, 16)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(56, 16)
        Me.lblLabel1.TabIndex = 1
        Me.lblLabel1.Text = "Desde"
        '
        'frmReporteDiferenciasTraspasos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(386, 104)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReporteDiferenciasTraspasos"
        Me.Text = "Reporte Diferencias X Trapasos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

        If Me.cmbHasta.Value < Me.cmbDesde.Value Then
            MessageBox.Show("La fecha final tiene que ser igual o mayor que la inicial.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbHasta.Focus()
        Else
            dsDiferencias = oTraspasoEMgr.GeneraReporteDiferencias(Me.cmbDesde.Value, Me.cmbHasta.Value)
            If Not dsDiferencias Is Nothing AndAlso dsDiferencias.Tables.Count > 0 Then
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Mostramos mensaje de Espera
                '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Dim oFrmMessage As New frmMessages
                With oFrmMessage
                    .lblMessage.Text = "Generando Reporte" & vbCrLf & "Favor de Esperar..."
                    .Text = "Generando Reporte ..."
                    .Show()
                End With
                Application.DoEvents()

                ExportarArchivo()

                oFrmMessage.Close()
                Application.DoEvents()
            End If
        End If

    End Sub

    Public Function VerificarVersionExcel() As String

        Dim reg As RegistryKey
        Dim regTemp As RegistryKey
        Dim strVersiones As String = ""
        Dim str As String = ""

        strVersiones = ""
        reg = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Office", False)
        If Not reg Is Nothing Then
            For Each str In reg.GetSubKeyNames
                regTemp = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Office\" & str)
                If Not regTemp Is Nothing Then
                    For Each str2 As String In regTemp.GetSubKeyNames
                        If str2.Trim.ToUpper = "Excel".ToUpper Then
                            strVersiones &= str & ","
                            Exit For
                        End If
                    Next
                End If
            Next

            Dim strTemp As String() = strVersiones.Trim.Split(",")
            Dim Mayor As Decimal = 0

            For Each str In strTemp
                If str.Trim <> "" Then
                    If CDec(str.Trim) > Mayor Then
                        Mayor = CDec(str.Trim)
                    End If
                End If
            Next

            Select Case Mayor
                Case 11.0
                    str = "2003"
                Case 12.0
                    str = "2007"
                Case 14.0
                    str = "2010"
            End Select

        End If

        regTemp = Nothing
        reg = Nothing

        Return str

    End Function

    Private Sub ExportarArchivo()

        Dim sfd As New SaveFileDialog
        Dim FileName As String = ""
        Dim strVersion As String = ""

        sfd.Title = "Export Report Document"
        sfd.AddExtension = False

        strVersion = VerificarVersionExcel()

        Select Case strVersion.Trim
            Case "2003"
                sfd.DefaultExt = "xls"
            Case "2007", "2010"
                sfd.DefaultExt = "xlsx"
        End Select

        'sfd.DefaultExt = "xls"
        sfd.Filter = "Microsoft Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx"

        If sfd.ShowDialog() = DialogResult.OK Then
            FileName = sfd.FileName.Trim
            'EscribeLog(FileName, "Ruta")
        Else
            Exit Sub
        End If

        'Me.exbExportando.Dock = DockStyle.Bottom
        'Me.exbExportando.Visible = True
        Application.DoEvents()

        'Dim oExcel As Excel.Application
        Dim oExcel As Object
        Dim oLibro As Excel.Workbook
        Dim oHoja As Excel.Worksheet

        'oExcel = New Excel.Application
        oExcel = CreateObject("Excel.Application")

        oLibro = oExcel.Workbooks.Add(Application.StartupPath & "\ReporteDiferenciasTraslados.xls")
        oHoja = oLibro.Worksheets(1)

        With oHoja

            '.Range("B3").Value = Format(Desde, "dd/MM/yyyy")
            '.Range("B4").Value = Format(Hasta, "dd/MM/yyyy")
            .Range("M2").Value = Format(Today, "dd/MM/yyyy")
            .Range("A2").Value = "Caja #" & oAppContext.ApplicationConfiguration.NoCaja.Trim
            .Range("A3").Value = "Desde:  " & Format(Me.cmbDesde.Value, "dd/MM/yyyy") & "  Hasta:  " & Format(Me.cmbHasta.Value, "dd/MM/yyyy")

            Dim oAlmacen As Almacen
            Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
            oAlmacen = oAlmacenMgr.Load(oSAPMgr.read_centros) 'oAppContext.ApplicationConfiguration.Almacen)
            If Not oAlmacen Is Nothing Then
                .Range("A4").Value = "SUCURSAL " & oAppContext.ApplicationConfiguration.Almacen & " " & oAlmacen.Descripcion
            End If

            Dim dtSobrantes As DataTable = dsDiferencias.Tables(0)
            Dim dtFaltaAjustar As DataTable = dsDiferencias.Tables(1)
            Dim dtAjustadosAS As DataTable = dsDiferencias.Tables(2)
            Dim dtAjustadosTS As DataTable = dsDiferencias.Tables(3)

            Dim i As Integer = 7

            For Each oRow As DataRow In dtSobrantes.Rows

                .Range("A" & i).Value = CStr(oRow!TrasladoOrigen).Trim
                .Range("B" & i).Value = Format(CDate(oRow!Fecha), "dd/MM/yyyy").Trim
                .Range("C" & i).Value = CStr(oRow!Codigo).Trim
                .Range("D" & i).Value = CStr(oRow!Descripcion).Trim
                .Range("E" & i).Value = CStr(oRow!Talla).Trim
                .Range("F" & i).Value = CStr(oRow!Cantidad).Trim
                .Range("G" & i).Value = CStr(oRow!CostoUnit).Trim
                .Range("H" & i).Value = CStr(oRow!CostoTotal).Trim
                .Range("I" & i).Value = CStr(oRow!Vendedor).Trim
                .Range("J" & i).Value = CStr(oRow!DoctoSAP).Trim
                .Range("K" & i).Value = CStr(oRow!Tipo).Trim
                .Range("L" & i).Value = CStr(oRow!TipoMovimiento).Trim
                If CStr(oRow!FechaMovimiento).Trim = "" Then
                    .Range("M" & i).Value = ""
                Else
                    .Range("M" & i).Value = Format(CDate(oRow!FechaMovimiento), "dd/MM/yyyy")
                End If

                i += 1
            Next

            For Each oRow As DataRow In dtFaltaAjustar.Rows

                .Range("A" & i).Value = CStr(oRow!TrasladoOrigen).Trim
                .Range("B" & i).Value = Format(CDate(oRow!Fecha), "dd/MM/yyyy").Trim
                .Range("C" & i).Value = CStr(oRow!Codigo).Trim
                .Range("D" & i).Value = CStr(oRow!Descripcion).Trim
                .Range("E" & i).Value = CStr(oRow!Talla).Trim
                .Range("F" & i).Value = CStr(oRow!Cantidad).Trim
                .Range("G" & i).Value = CStr(oRow!CostoUnit).Trim
                .Range("H" & i).Value = CStr(oRow!CostoTotal).Trim
                .Range("I" & i).Value = CStr(oRow!Vendedor).Trim
                .Range("J" & i).Value = CStr(oRow!DoctoSAP).Trim
                .Range("K" & i).Value = CStr(oRow!Tipo).Trim
                .Range("L" & i).Value = CStr(oRow!TipoMovimiento).Trim
                If CStr(oRow!FechaMovimiento).Trim = "" Then
                    .Range("M" & i).Value = ""
                Else
                    .Range("M" & i).Value = Format(CDate(oRow!FechaMovimiento), "dd/MM/yyyy")
                End If

                i += 1
            Next

            For Each oRow As DataRow In dtAjustadosAS.Rows

                .Range("A" & i).Value = CStr(oRow!TrasladoOrigen).Trim
                .Range("B" & i).Value = Format(CDate(oRow!Fecha), "dd/MM/yyyy").Trim
                .Range("C" & i).Value = CStr(oRow!Codigo).Trim
                .Range("D" & i).Value = CStr(oRow!Descripcion).Trim
                .Range("E" & i).Value = CStr(oRow!Talla).Trim
                .Range("F" & i).Value = CStr(oRow!Cantidad).Trim
                .Range("G" & i).Value = CStr(oRow!CostoUnit).Trim
                .Range("H" & i).Value = CStr(oRow!CostoTotal).Trim
                .Range("I" & i).Value = CStr(oRow!Vendedor).Trim
                .Range("J" & i).Value = CStr(oRow!DoctoSAP).Trim
                .Range("K" & i).Value = CStr(oRow!Tipo).Trim
                .Range("L" & i).Value = CStr(oRow!TipoMovimiento).Trim
                If CStr(oRow!FechaMovimiento).Trim = "" Then
                    .Range("M" & i).Value = ""
                Else
                    .Range("M" & i).Value = Format(CDate(oRow!FechaMovimiento), "dd/MM/yyyy")
                End If

                i += 1
            Next

            For Each oRow As DataRow In dtAjustadosTS.Rows

                .Range("A" & i).Value = CStr(oRow!TrasladoOrigen).Trim
                .Range("B" & i).Value = Format(CDate(oRow!Fecha), "dd/MM/yyyy").Trim
                .Range("C" & i).Value = CStr(oRow!Codigo).Trim
                .Range("D" & i).Value = CStr(oRow!Descripcion).Trim
                .Range("E" & i).Value = CStr(oRow!Talla).Trim
                .Range("F" & i).Value = CStr(oRow!Cantidad).Trim
                .Range("G" & i).Value = Format(CDec(oRow!CostoUnit), "$#,##0.0").Trim
                .Range("H" & i).Value = Format(CDec(oRow!CostoTotal), "$#,##0.0").Trim
                .Range("I" & i).Value = CStr(oRow!Vendedor).Trim
                .Range("J" & i).Value = CStr(oRow!DoctoSAP).Trim
                .Range("K" & i).Value = CStr(oRow!Tipo).Trim
                .Range("L" & i).Value = CStr(oRow!TipoMovimiento).Trim
                If CStr(oRow!FechaMovimiento).Trim = "" Then
                    .Range("M" & i).Value = ""
                Else
                    .Range("M" & i).Value = Format(CDate(oRow!FechaMovimiento), "dd/MM/yyyy")
                End If

                i += 1
            Next

        End With

        Try
            oLibro.SaveAs(FileName)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar archivo de excel")
        End Try

        oLibro = Nothing
        oExcel.Quit()
        oExcel = Nothing

        KillExcel()

    End Sub

    Private Sub frmReporteDiferenciasTraspasos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select

    End Sub

End Class
