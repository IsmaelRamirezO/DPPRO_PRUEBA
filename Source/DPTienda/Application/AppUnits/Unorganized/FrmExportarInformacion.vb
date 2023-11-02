Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Checksums
Imports System.IO

Public Class FrmExportarInformacion
    Inherits System.Windows.Forms.Form


#Region "Variables Miembros"

    Private zUtil As New ZipUtil

#End Region


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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblFileName As System.Windows.Forms.Label
    Friend WithEvents Barra As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmExportarInformacion))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblFileName = New System.Windows.Forms.Label
        Me.Barra = New Janus.Windows.EditControls.UIProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.btnGenerar)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Location = New System.Drawing.Point(-8, -8)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(440, 168)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Window
        Me.btnGenerar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.Location = New System.Drawing.Point(328, 96)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(96, 23)
        Me.btnGenerar.TabIndex = 32
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LblFileName)
        Me.GroupBox1.Controls.Add(Me.Barra)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'LblFileName
        '
        Me.LblFileName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFileName.Location = New System.Drawing.Point(64, 16)
        Me.LblFileName.Name = "LblFileName"
        Me.LblFileName.Size = New System.Drawing.Size(328, 16)
        Me.LblFileName.TabIndex = 2
        '
        'Barra
        '
        Me.Barra.Location = New System.Drawing.Point(8, 32)
        Me.Barra.Maximum = 13
        Me.Barra.Name = "Barra"
        Me.Barra.ProgressFormatStyle.BackColor = System.Drawing.Color.Navy
        Me.Barra.ProgressFormatStyle.BackColorGradient = System.Drawing.Color.White
        Me.Barra.ProgressFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical
        Me.Barra.ShowPercentage = True
        Me.Barra.Size = New System.Drawing.Size(392, 24)
        Me.Barra.TabIndex = 1
        Me.Barra.Text = "UiProgressBar1"
        Me.Barra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Archivo:"
        '
        'FrmExportarInformacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 116)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(432, 150)
        Me.MinimumSize = New System.Drawing.Size(432, 150)
        Me.Name = "FrmExportarInformacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Información"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        CreateFolder()

        Dim dtCatalogo As DataTable
        'dtCatalogo = GetCatalogoUPC().Tables(0).Copy
        ''CreateUPCDBF(dtCatalogo)
        'ExporTODBF(dtCatalogo)

        dtCatalogo = GetCatalogoBASMD().Tables(0).Copy
        ExporTODBF(dtCatalogo)

        'dtCatalogo = GetCatalogoEXIS().Tables(0).Copy
        'ExporTODBF(dtCatalogo)

        'dtCatalogo = GetCatalogoMARCAS().Tables(0).Copy
        'ExporTODBF(dtCatalogo)

        'dtCatalogo = GetCatalogoUSUARIO().Tables(0).Copy
        'ExporTODBF(dtCatalogo)

        zUtil.Comprimir("C:\DPT\AUDBAS\", "*.dbf", "C:\DPT\AUDBAS.arj", False)

        MsgBox("Archivo generado con exitó en la ruta " & "C:\DPT\AUDBAS.arj", MsgBoxStyle.Information, Me.Text)
    End Sub

#End Region

#Region "Sub TO AppUni AUDBAS"

    Function GetCatalogoUPC() As DataSet

        Dim strQuery As String = _
        " SELECT     CodUPC AS UPC, CodArticulo AS Codigo, Numero AS Talla, 'A' AS Status, Convert(Datetime,Convert(Varchar,GETDATE(),101),101)  AS Fecha FROM CatalogoUPC "

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "UPC")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Function GetCatalogoBASMD() As DataSet

        Dim strQuery As String = _
                        " SELECT     '' AS TIPOMOV, Movimientos.FolioControl AS FOLIOCTRL, CatalogoTipoMovimientos.Tipo AS Moves, Convert(Datetime,Convert(Varchar,Movimientos.FechaMov,101),101) AS Fecha, " & _
                        " CatalogoTipoMovimientos.Descripcion AS DESCMOV, Movimientos.Folio, Movimientos.StatusMov AS Status, Movimientos.CodArticulo AS Codigo, " & _
                        " Movimientos.Numero, Movimientos.Descripcion AS Descripcion, Movimientos.Cantidad, Movimientos.CodUnidad AS Unidad, " & _
                        " Movimientos.CostoUnit AS Costo, Movimientos.Importe, Movimientos.Origen AS ORIGDST, Movimientos.Destino AS Sucursal, Movimientos.TOTNC, " & _
                        " Movimientos.Descuento AS TOTDESC, Movimientos.TOTFGRAL, Movimientos.PrecioUnit, Movimientos.CostoUnit AS COSTUNIT, Movimientos.Usuario, " & _
                        " Movimientos.VTA_DIP, Movimientos.CostoNC AS CostNC, '' AS CCTACONT " & _
                        " FROM         Movimientos INNER JOIN " & _
                        " CatalogoTipoMovimientos ON Movimientos.CodTipoMov = CatalogoTipoMovimientos.CodTipoMov "

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "BASMD" & Microsoft.VisualBasic.Right(oAppContext.ApplicationConfiguration.Almacen, 2))

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Function GetCatalogoEXIS() As DataSet

        Dim strQuery As String = _
                        " SELECT     CodAlmacen AS SUC, CodArticulo AS CODIGO, Numero, Libre AS Existencia, 0 AS Pedidos, 0 AS Ordenados, Saldo_1, Entro_1, Salio_1, Saldo_2, " & _
                        " Entro_2, Salio_2, Saldo_3, Entro_3, Salio_3, Saldo_4, Entro_4, Salio_4, Saldo_5, Entro_5, Salio_5, Saldo_6, Entro_6, Salio_6, Saldo_7, Entro_7, " & _
                        " Salio_7, Saldo_8, Entro_8, Salio_8, Saldo_9, Entro_9, Salio_9, Saldo_10, Entro_10, Salio_10, Saldo_11, Entro_11, Salio_11, Saldo_12, Entro_12, " & _
                        " Salio_12, FUM, CodFamilia AS Familia, Apartados, Defectuosos " & _
                        " FROM Existencias "

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "EXIS" & Microsoft.VisualBasic.Right(oAppContext.ApplicationConfiguration.Almacen, 2))

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Function GetCatalogoMARCAS() As DataSet

        Dim strQuery As String = _
                        " SELECT     CodMarca AS Codigo, Descripcion AS Nombre, CodOrigen AS Origen FROM CatalogoMarcas"

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "MARCAS")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Function GetCatalogoUSUARIO() As DataSet

        Dim strQuery As String = _
                       " SELECT CodVendedor AS Codigo, Nombre, '' AS DIREC, '' AS DIREC2, '' AS TEL1, '' AS TEL2, '' AS NOTA1, '' AS NOTA2, '' AS NOTA3, '' AS PW,  'S' AS STATUS FROM CatalogoVendedores"

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "USUARIO")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

    Public Sub CreateFolder()
        On Error Resume Next
        Microsoft.VisualBasic.MkDir("C:\DPT\AUDBAS")
    End Sub

    Function ExporTODBF(ByVal dtCatalogo As DataTable) As Boolean


        Dim xlapp 'As Excel.Application
        Dim wbxl 'As Excel.Workbook
        Dim wsxl 'As Excel.Worksheet

        Dim intRow As Integer 'counter
        Dim intCell As Integer 'counter

        Dim oRow As DataRow

        'On Error Resume Next

        'xlapp = GetObject(, "Excel.Application")

        If xlapp Is Nothing Then
            xlapp = CreateObject("Excel.Application")
            If xlapp Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical, " Auditoría de Retiros")
                Exit Function
            End If
        Else
            xlapp = CreateObject("Excel.Application")
        End If

        wbxl = xlapp.Workbooks.Add
        wsxl = xlapp.Sheets(1)
        wsxl.Name = dtCatalogo.TableName

        intRow = 1
        intCell = 0
        Me.Label1.Text = " " & dtCatalogo.TableName & ".dbf"
        Me.Label1.Refresh()

        Me.Barra.Value = 0
        Me.Barra.Maximum = dtCatalogo.Columns.Count + dtCatalogo.Rows.Count

        For Each oCol As DataColumn In dtCatalogo.Columns
            intCell += 1
            wsxl.Cells(intRow, intCell).Value = oCol.ColumnName
            Barra.Value += 1
            Barra.Refresh()
        Next

        For Each oRow In dtCatalogo.Rows
            intRow = intRow + 1
            intCell = 0
            For Each oCol As DataColumn In dtCatalogo.Columns
                intCell += 1
                wsxl.Cells(intRow, intCell).Value = "'" & oRow(ocol.ColumnName)
            Next
            Barra.Value += 1
            Barra.Refresh()
        Next

        Me.Cursor = Cursors.Default

        'Se exporta la hoja Excel cargada en el objeto oExcel()
        'wsxl.Range("B1:B1").AutoFit()
        'wsxl.Columns.EntireColumn.AutoFit()
        wsxl.Columns.AutoFit()

        wbxl.SaveAs("C:\DPT\AUDBAS\" & dtCatalogo.TableName & ".dbf", 11) 'Excel.XlFileFormat.xlDBF4)

        System.Runtime.InteropServices.Marshal.ReleaseComObject(wbxl)
        wbxl = Nothing
        xlapp.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp)
        xlapp = Nothing

        KillExcel()

    End Function

    '''No JALA por que no graba en formato DBF.
    Function ExporTODBFTwo(ByVal dtCatalogo As DataTable) As Boolean

        Dim oStream As New System.IO.StreamWriter("C:\DPT\AUDBAS\" & dtCatalogo.TableName & ".dbf")
        Dim oRow As DataRow

        Me.Label1.Text = " " & dtCatalogo.TableName & ".dbf"
        Me.Label1.Refresh()

        Me.Barra.Value = 0
        Me.Barra.Maximum = dtCatalogo.Columns.Count + dtCatalogo.Rows.Count

        Dim intCol As Integer = dtCatalogo.Columns.Count
        Dim intColCount As Integer

        For Each oCol As DataColumn In dtCatalogo.Columns
            intColCount += 1
            If intCol = intColCount Then
                oStream.WriteLine(oCol.ColumnName)
            Else
                oStream.Write(oCol.ColumnName & Microsoft.VisualBasic.vbTab)
            End If

            Barra.Value += 1
            Barra.Refresh()
        Next

        For Each oRow In dtCatalogo.Rows
            intColCount = 0
            For Each oCol As DataColumn In dtCatalogo.Columns
                intColCount += 1
                If IsDBNull(oRow(ocol.ColumnName)) Then
                    If intCol = intColCount Then
                        oStream.WriteLine("")
                    Else
                        oStream.Write("" & Microsoft.VisualBasic.vbTab)
                    End If
                Else
                    If intCol = intColCount Then
                        oStream.WriteLine(CStr(oRow(ocol.ColumnName)))
                    Else
                        oStream.Write(CStr(oRow(ocol.ColumnName)) & Microsoft.VisualBasic.vbTab)
                    End If
                End If
            Next
            Barra.Value += 1
            Barra.Refresh()
        Next

        Me.Cursor = Cursors.Default
        oStream.Close()


    End Function

#End Region

#Region " Sub TO AppUni Ganancias Adicional"

    Function GetCatalogoARTIC() As DataSet

        Dim strQuery As String = _
                        " SELECT  CodArticulo, 'S' AS Dip FROM CatalogoArticulos WHERE(Dip = 1)"

        Dim oResult As DataSet
        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection

            .CommandText = strQuery
            .CommandType = System.Data.CommandType.Text

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))

        End With

        Dim oCatalogoCorridasAdapter As SqlDataAdapter
        oCatalogoCorridasAdapter = New SqlDataAdapter
        oCatalogoCorridasAdapter.SelectCommand = sccmdSelect

        Try

            sccnnConnection.Open()

            oResult = New DataSet

            oCatalogoCorridasAdapter.Fill(oResult, "ARTIC")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

        End Try

        sccmdSelect.Dispose()
        sccmdSelect = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return oResult

    End Function

#End Region
    'Private Sub CreateUPCDBF(ByVal dtCatalogo As DataTable)
    '    Try

    '        Me.Label1.Text = " " & dtCatalogo.TableName & ".dbf"
    '        Me.Label1.Refresh()

    '        Me.Barra.Value = 0
    '        Me.Barra.Maximum = dtCatalogo.Rows.Count

    '        Dim oDBFEngine As New DBFEngine.xdbf
    '        oDBFEngine.creaTable("C:\DPT\AUDBAS\UPC.dbf", "UPC C(18), Codigo C(18), Talla C(4),Status C(1),Fecha D")

    '        For Each orow As DataRow In dtCatalogo.Rows
    '            oDBFEngine.AppendBlank()
    '            For Each oCol As DataColumn In dtCatalogo.Columns
    '                If oCol.DataType.ToString = "System.DateTime" Then
    '                    oDBFEngine.Replace(oCol.ColumnName, Format(orow(oCol.ColumnName), "yyyyMMdd"))
    '                Else
    '                    oDBFEngine.Replace(oCol.ColumnName, orow(oCol.ColumnName))
    '                End If

    '            Next
    '            Me.Barra.Value += 1
    '            Me.Barra.Refresh()
    '        Next

    '        oDBFEngine.Close()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

End Class

'''Clase con Metodos para Zip y UnZip
Public Class ZipUtil
    Public Sub Comprimir(ByVal directorio As String, _
                         ByVal filtro As String, _
                         ByVal zipFic As String, _
                         Optional ByVal crearAuto As Boolean = True)
        ' Comprime los ficheros del directorio indicado y guardarlo en el zip.
        ' En filtro se indicará el filtro a usar para seleccionar los ficheros del directorio.
        ' Si directorio es una cadena vacía, filtro será el fichero a comprimir (sólo ese)
        ' Si crearAuto = True, zipfile será el directorio en el que se guardará
        ' y se generará automáticamente el nombre con la fecha y hora actual

        Dim fileNames(0) As String
        If directorio = "" Then
            fileNames(0) = filtro
        Else
            fileNames = Directory.GetFiles(directorio, filtro)
        End If
        '
        ' Llamar a la versión sobrecargada que recibe un array
        Comprimir(fileNames, zipFic, crearAuto)
    End Sub
    '
    Public Sub Comprimir(ByVal fileNames() As String, _
                         ByVal zipFic As String, _
                         Optional ByVal crearAuto As Boolean = False)
        ' Comprimir los ficheros del array en el zip indicado.
        ' Si crearAuto = True, zipfile será el directorio en el que se guardará
        ' y se generará automáticamente el nombre con la fecha y hora actual
        Dim objCrc32 As New Crc32
        Dim strmZipOutputStream As ZipOutputStream
        '
        If zipFic = "" Then
            zipFic = "."
            crearAuto = True
        End If
        If crearAuto Then
            ' si hay que crear el nombre del fichero
            ' éste será el path indicado y la fecha actual
            zipFic &= "\ZIP" & DateTime.Now.ToString("yyMMddHHmmss") & ".zip"
        End If
        strmZipOutputStream = New ZipOutputStream(File.Create(zipFic))
        ' Compression Level: 0-9
        ' 0: no(Compression)
        ' 9: maximum compression
        strmZipOutputStream.SetLevel(6)
        '
        Dim strFile As String
        For Each strFile In fileNames
            Dim strmFile As FileStream = File.OpenRead(strFile)
            Dim abyBuffer(Convert.ToInt32(strmFile.Length - 1)) As Byte
            '
            strmFile.Read(abyBuffer, 0, abyBuffer.Length)
            '
            '------------------------------------------------------------------
            ' para guardar sin el primer path
            'Dim sFile As String = strFile
            'Dim i As Integer = sFile.IndexOf("\")
            'If i > -1 Then
            '    sFile = sFile.Substring(i + 1).TrimStart
            'End If
            '------------------------------------------------------------------
            '
            '------------------------------------------------------------------
            ' para guardar sólo el nombre del fichero
            ' esto sólo se debe hacer si no se procesan directorios
            ' que puedan contener nombres repetidos
            Dim sFile As String = Path.GetFileName(strFile)
            Dim theEntry As ZipEntry = New ZipEntry(sFile)
            '------------------------------------------------------------------
            '
            '------------------------------------------------------------------
            ' se guarda con el path completo
            'Dim theEntry As ZipEntry = New ZipEntry(strFile)
            '------------------------------------------------------------------
            '
            ' Guardar la fecha y hora de la última modificación
            Dim fi As New FileInfo(strFile)
            theEntry.DateTime = fi.LastWriteTime
            'theEntry.DateTime = DateTime.Now
            '
            theEntry.Size = strmFile.Length
            strmFile.Close()
            objCrc32.Reset()
            objCrc32.Update(abyBuffer)
            theEntry.Crc = objCrc32.Value
            strmZipOutputStream.PutNextEntry(theEntry)
            strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)
        Next
        strmZipOutputStream.Finish()
        strmZipOutputStream.Close()
    End Sub
    '
    Public Sub Descomprimir(ByVal directorio As String, _
                            Optional ByVal zipFic As String = "", _
                            Optional ByVal eliminar As Boolean = False, _
                            Optional ByVal renombrar As Boolean = False)
        ' descomprimir el contenido de zipFic en el directorio indicado.
        ' si zipFic no tiene la extensión .zip, se entenderá que es un directorio y
        ' se procesará el primer fichero .zip de ese directorio.
        ' si eliminar es True se eliminará ese fichero zip después de descomprimirlo.
        ' si renombrar es True se añadirá al final .descomprimido
        If Not zipFic.ToLower.EndsWith(".zip") Then
            zipFic = Directory.GetFiles(zipFic, "*.zip")(0)
        End If
        ' si no se ha indicado el directorio, usar el actual
        If directorio = "" Then directorio = "."
        '
        Dim z As New ZipInputStream(File.OpenRead(zipFic))
        Dim theEntry As ZipEntry
        '
        Do
            theEntry = z.GetNextEntry()
            If Not theEntry Is Nothing Then
                Dim fileName As String = directorio & "\" & Path.GetFileName(theEntry.Name)
                '
                ' dará error si no existe el path
                Dim streamWriter As FileStream
                Try
                    streamWriter = File.Create(fileName)
                Catch ex As DirectoryNotFoundException
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName))
                    streamWriter = File.Create(fileName)
                End Try
                '
                Dim size As Integer
                Dim data(2048) As Byte
                Do
                    size = z.Read(data, 0, data.Length)
                    If (size > 0) Then
                        streamWriter.Write(data, 0, size)
                    Else
                        Exit Do
                    End If
                Loop
                streamWriter.Close()
            Else
                Exit Do
            End If
        Loop
        z.Close()
        '
        ' cuando se hayan extraído los ficheros, renombrarlo
        If renombrar Then
            File.Copy(zipFic, zipFic & ".descomprimido")
        End If
        If eliminar Then
            File.Delete(zipFic)
        End If
    End Sub
    '
    Public Function Contenido(ByVal zipFic As String) As ZipEntry()
        ' devuelve el contenido del zip indicado
        Dim strmZipInputStream As ZipInputStream = New ZipInputStream(File.OpenRead(zipFic))
        Dim objEntry As ZipEntry
        'Dim strOutput As String
        Dim files() As ZipEntry
        Dim n As Integer = -1
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(strOutput)
        '
        objEntry = strmZipInputStream.GetNextEntry()
        While IsNothing(objEntry) = False
            n = n + 1
            ReDim Preserve files(n)
            files(n) = objEntry
            objEntry = strmZipInputStream.GetNextEntry()
        End While
        strmZipInputStream.Close()
        '
        Return files
    End Function
End Class