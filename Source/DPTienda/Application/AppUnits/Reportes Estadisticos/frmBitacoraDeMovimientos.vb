Imports DportenisPro.DPTienda.ApplicationUnits.InicioDia
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmBitacoraDeMovimientos
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ccmbFechaF As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ccmbFechaI As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ccmbFechaF = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ccmbFechaI = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.ccmbFechaF)
        Me.ExplorerBar1.Controls.Add(Me.ccmbFechaI)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(328, 110)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(128, 72)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(176, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "a.-"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "De.-"
        '
        'ccmbFechaF
        '
        '
        '
        '
        Me.ccmbFechaF.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbFechaF.Location = New System.Drawing.Point(200, 24)
        Me.ccmbFechaF.Name = "ccmbFechaF"
        Me.ccmbFechaF.Size = New System.Drawing.Size(96, 20)
        Me.ccmbFechaF.TabIndex = 3
        Me.ccmbFechaF.Value = New Date(2007, 11, 12, 0, 0, 0, 0)
        Me.ccmbFechaF.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'ccmbFechaI
        '
        '
        '
        '
        Me.ccmbFechaI.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ccmbFechaI.Location = New System.Drawing.Point(72, 24)
        Me.ccmbFechaI.Name = "ccmbFechaI"
        Me.ccmbFechaI.Size = New System.Drawing.Size(96, 20)
        Me.ccmbFechaI.TabIndex = 2
        Me.ccmbFechaI.Value = New Date(2007, 11, 12, 0, 0, 0, 0)
        Me.ccmbFechaI.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'frmBitacoraDeMovimientos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 110)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Name = "frmBitacoraDeMovimientos"
        Me.Text = "...::: Bitacora de Movimientos :::..."
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Variables"
    Dim oInicioDiaMgr As InicioDiaManager
    Dim oProSAPMgr As ProcesoSAPManager
    Dim frmLoad As Boolean
#End Region

    Private Sub frmBitacoraDeMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oInicioDiaMgr = New InicioDiaManager(oAppContext, oAppSAPConfig)
        oProSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Me.ccmbFechaI.Value = Now
        Me.ccmbFechaF.MinDate = Me.ccmbFechaI.Value
        Me.ccmbFechaI.MaxDate = Me.ccmbFechaF.Value

        frmLoad = True
    End Sub

    Private Sub ccmbFechaI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ccmbFechaI.ValueChanged
        If frmLoad = True Then
            Me.ccmbFechaF.MinDate = Me.ccmbFechaI.Value
        End If

    End Sub

    Private Sub ccmbFechaF_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ccmbFechaF.ValueChanged
        If frmLoad = True Then
            Me.ccmbFechaI.MaxDate = Me.ccmbFechaF.Value
        End If
    End Sub

    Private Sub GenerarBitacoraXLS()

        Dim oExcel 'As Excel.ApplicationClass
        Dim oBook 'As Excel.WorkbookClass
        Dim oBooks 'As Excel.Workbooks
        Dim wsxl 'As Excel.Worksheet

        Dim intRow As Integer 'counter

        Dim oRow As DataRow

        'Variables Ciclo Rango Fecha
        Dim Fecha As Date
        Dim cDias, tDias As Integer
        Dim IPRO, ISAP As Integer 'Info PRO, Info SAP

        On Error Resume Next

        oExcel = GetObject(, "Excel.Application")

        If oExcel Is Nothing Then
            oExcel = CreateObject("Excel.Application")
            If oExcel Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Separaciones")
                Exit Sub
            End If
        Else
            oExcel = CreateObject("Excel.Application")
        End If

        oBooks = oExcel.Workbooks
        oBook = oBooks.Open(Application.StartupPath.TrimEnd("\") & "\BITACORA.xlsx")
        wsxl = oExcel.Sheets(1)
        wsxl.Name = "Bitacora"
        intRow = 1



        'Ponemos Los Datos
        'wsxl.Cells(2, 3) = ("C2")<--Ejemplo

        '''Informacion Tienda (Cabecera)
        Dim oAlmacen As Almacen
        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)

        oAlmacen = oAlmacenMgr.Create
        oAlmacen = oAlmacenMgr.Load("2" & oAppContext.ApplicationConfiguration.Almacen)

        wsxl.Cells(5, 4) = Format(Now, "dd/MM/yyyy") 'Fecha Reporte
        wsxl.Cells(5, 7) = oAlmacen.ID & " " & oAlmacen.Descripcion  'Tienda


        'Ciclamos Fecha Ini a Fecha Fin
        tDias = DateDiff(DateInterval.Day, Me.ccmbFechaI.Value, Me.ccmbFechaF.Value)
        Fecha = Me.ccmbFechaI.Value
        IPRO = 9
        ISAP = 10
        For cDias = 0 To tDias

            wsxl.Cells(IPRO, 1) = "PRO"
            wsxl.Cells(ISAP, 1) = "SAP"

            wsxl.Cells(IPRO, 2) = Fecha
            wsxl.Cells(ISAP, 2) = Fecha
            'Obtenemos Informacion PRO.
            Dim dsBitacoraPRO As DataSet

            dsBitacoraPRO = Me.oInicioDiaMgr.SelectBitacora(Fecha)

            '''Movimientos PRO
            'wsxl.Range("F" & IPRO & ":F" & IPRO).BorderAround(, 2, 0, )
            For Each oRow In dsBitacoraPRO.Tables(0).Rows
                If CStr(oRow(0)) = "Factura" Then
                    wsxl.Cells(IPRO, 10) = oRow(1) 'Venta

                ElseIf CStr(oRow(0)) = "Cancelado" Then
                    wsxl.Cells(IPRO, 8) = oRow(1) 'Venta Cancelada

                ElseIf CStr(oRow(0)) = "Devolucion" Then
                    wsxl.Cells(IPRO, 7) = oRow(1) 'Devolucion (Entrada)

                ElseIf CStr(oRow(0)) = "TraspasoE" Then
                    wsxl.Cells(IPRO, 4) = oRow(1) 'Traspado Entrada

                ElseIf CStr(oRow(0)) = "TraspasoS" Then
                    wsxl.Cells(IPRO, 12) = oRow(1) 'Traspaso de Salida


                ElseIf CStr(oRow(0)) = "EAjusteCM" Then
                    wsxl.Cells(IPRO, 5) = oRow(1) 'Ajuste CM (Entrada)

                ElseIf CStr(oRow(0)) = "SAjusteCM" Then
                    wsxl.Cells(IPRO, 13) = oRow(1) 'Ajuste CM (Salida)

                ElseIf CStr(oRow(0)) = "CambioTalla" Then
                    wsxl.Cells(IPRO, 6) = oRow(1) 'Ajuste CT (Entrada)
                    wsxl.Cells(IPRO, 14) = oRow(1) 'Ajuste CT (Salida)
                Else

                End If
            Next

            wsxl.Cells(IPRO, 3) = 0 'Inventario Inicial
            wsxl.Cells(ISAP, 3) = 0 'Inventario Inicial
            For Each oRow In dsBitacoraPRO.Tables(1).Rows
                wsxl.Cells(IPRO, 3) = oRow(1) 'Inventario Inicial
                wsxl.Cells(ISAP, 3) = oRow(1) 'Inventario Inicial
            Next


            '''Movimientos SAP
            Dim dtBitacoraSAP As DataTable
            dtBitacoraSAP = oProSAPMgr.Read_BitacoraSAP(Fecha)



            wsxl.Cells(ISAP, 4) = 0 'Traspado Entrada     (101)
            wsxl.Cells(ISAP, 5) = 0 'Ajuste CM (Entrada)  (552)
            wsxl.Cells(ISAP, 13) = 0 'Ajuste CT (Salida)  (309)
            wsxl.Cells(ISAP, 6) = 0 'Ajuste CT (Entrada)  (309)
            wsxl.Cells(ISAP, 7) = 0 'Devolucion (Entrada) (653)
            wsxl.Cells(ISAP, 10) = 0 'Venta                (601)
            wsxl.Cells(ISAP, 11) = 0 'Traspaso de Salida   (351)
            wsxl.Cells(ISAP, 12) = 0 'Ajuste CM (Salida)  (551)
            wsxl.Range("G" & ISAP & ":H" & ISAP).Merge()


            For Each oRow In dtBitacoraSAP.Rows
                Select Case oRow("BWART")
                    Case "101"
                        wsxl.Cells(ISAP, 4) = oRow("MENGE") 'Traspado Entrada     (101)

                    Case "954"
                        wsxl.Cells(ISAP, 5) = oRow("MENGE") 'Ajuste CM (Entrada)  (552)

                    Case "955"
                        If CStr(oRow("SHKZG")) = "H" Then
                            wsxl.Cells(ISAP, 14) = oRow("MENGE") 'Ajuste CT (Salida)  (309)
                        Else
                            wsxl.Cells(ISAP, 6) = oRow("MENGE") 'Ajuste CT (Entrada)  (309)
                        End If
                    Case "651"
                        wsxl.Cells(ISAP, 7) = oRow("MENGE") 'Devolucion (Entrada) (653)
                        'wsxl.Cells(10, 6) = oRow("MENGE") 'Venta Cancelada      (653)
                    Case "601"
                        wsxl.Cells(ISAP, 11) = oRow("MENGE") 'Venta                (601)
                    Case "641"
                        wsxl.Cells(ISAP, 12) = oRow("MENGE") 'Traspaso de Salida   (351)
                    Case "953"
                        wsxl.Cells(ISAP, 13) = oRow("MENGE") 'Ajuste CM (Salida)  (551)
                    Case "602"
                        wsxl.Cells(ISAP, 9) = oRow("MENGE") 'Otros (Entrada)  (602)
                    Case "652", "957"
                        wsxl.Cells(ISAP, 15) = oRow("MENGE") 'Otros (Salida)  (652,957)
                    Case Else
                        wsxl.Cells(ISAP, 15) = oRow("MENGE")
                End Select

            Next

            '-------------------------------------------------------------------------------------
            ' JNAVA (17.07.2016): Adecuacion para retail. NO se realizaba la suma en el excel
            '-------------------------------------------------------------------------------------
            wsxl.Cells(IPRO, 10).Value = "=SUM(D" & IPRO & ":I" & IPRO & ")"
            wsxl.Cells(ISAP, 10).Value = "=SUM(D" & ISAP & ":I" & ISAP & ")"

            wsxl.Cells(IPRO, 16).Value = "=SUM(K" & IPRO & ":O" & IPRO & ")"
            wsxl.Cells(ISAP, 16).Value = "=SUM(K" & ISAP & ":O" & ISAP & ")"
            '-------------------------------------------------------------------------------------

            wsxl.Cells(IPRO, 17).Value = "=C" & IPRO & "+J" & IPRO & "-P" & IPRO
            wsxl.Cells(ISAP, 17).Value = "=C" & ISAP & "+J" & ISAP & "-P" & ISAP

            If intRow = 1 Then
                wsxl.Range("A" & IPRO & ":Q" & ISAP).Interior.Color = System.Drawing.Color.Beige.ToArgb   'RGB(255, 255, 192)
                intRow = 2
            Else
                wsxl.Range("A" & IPRO & ":Q" & ISAP).Interior.Color = System.Drawing.Color.White.ToArgb   'RGB(255, 255, 192)
                intRow = 1
            End If

            If cDias < tDias Then
                IPRO += 2
                ISAP += 2
                wsxl.Rows(IPRO).EntireRow.Insert()
                wsxl.Rows(IPRO).EntireRow.Insert()
            End If
            Fecha = Fecha.AddDays(1)

        Next


        'wsxl.Cells(1, 1).Interior.Color = &HDFFFCC
        'wsxl.Range("A6:G6").Interior.Color = RGB(255, 255, 192)
        'wsxl.Rows(ISAP + 1).EntireRow.Delete()
        'wsxl.Rows(IPRO).EntireRow.Delete()
        'wsxl.Rows(IPRO).EntireRow.Delete()
        'wsxl.Cells(ISAP + 1, 3).Value = "=SUMA(C" & 9 & ":C" & ISAP & ")"


        'System.Threading.Thread.Sleep(50)

        '---------------------------------------------------------------------------------
        ' JNAVA (17.02.2016): Validamos que exista la ruta, si no existe la creamos
        '---------------------------------------------------------------------------------
        Dim RutaSave As String = "C:\BITACORA"
        If Not Directory.Exists(RutaSave) Then
            Directory.CreateDirectory(RutaSave)
        End If


        'Se exporta la hoja Excel cargada en el objeto oExcel()
        oBook.SaveAs(RutaSave & "\BITACORA" & Format(Now, "ddMMyyyy") & ".XLSX")  'Excel.XlFileFormat.xlTextPrinter)
        '---------------------------------------------------------------------------------

        ' Cierra todo
        oBooks.Close(True)
        System.Runtime.InteropServices.Marshal. _
            ReleaseComObject(oBooks)
        oBooks = Nothing



        System.Runtime.InteropServices.Marshal. _
            ReleaseComObject(oBook)
        oBook = Nothing



        oExcel.Quit()
        System.Runtime.InteropServices.Marshal. _
            ReleaseComObject(oExcel)
        oExcel = Nothing

        'oBook.Show()

        KillExcel()
        System.Threading.Thread.Sleep(50)
        MessageBox.Show("Bitacora Guardada en .- " & Microsoft.VisualBasic.vbCrLf & RutaSave & "\BITACORA" & Format(Now, "ddMMyyyy") & ".XLS")

        'Process.Start("excel.exe " & "C:\BITACORA" & Format(Now, "ddMMyyyy") & ".XLS")
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        GenerarBitacoraXLS()
    End Sub
End Class
