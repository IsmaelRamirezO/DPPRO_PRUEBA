Imports System
Imports System.IO
Imports DportenisPro.DPTienda.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Checksums
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes


Public Class GananciaAdicional

#Region "Constructors / Destructors"

    Private oApplicationContext As ApplicationContext


    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

#Region "Ganancias Adicionales"

    Private Sub Comprimir(ByVal fileNames() As String, ByVal zipFic As String)

        Dim objCrc32 As New Crc32
        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(File.Create(zipFic))
        strmZipOutputStream.SetLevel(6)

        Dim strFile As String

        For Each strFile In fileNames
            Dim strmFile As FileStream = File.OpenRead(strFile)
            Dim abyBuffer(Convert.ToInt32(strmFile.Length - 1)) As Byte

            strmFile.Read(abyBuffer, 0, abyBuffer.Length)

            Dim sFile As String = Path.GetFileName(strFile)
            Dim theEntry As ZipEntry = New ZipEntry(sFile)

            Dim fi As New FileInfo(strFile)
            theEntry.DateTime = fi.LastWriteTime
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


    Public Sub GeneraGananciaAdicional(ByVal Ruta As String)

        Dim FileNames(0) As String, vlRuta As String

        vlRuta = Ruta
        vlRuta = vlRuta.Replace(".zip", "") & "\"

        If Directory.Exists(vlRuta) = True Then
            Directory.Delete(vlRuta, True)
        End If

        Directory.CreateDirectory(vlRuta)
        'Archivos de Ganancias Adicionales
        Artic(vlRuta)
        FTOT(vlRuta)
        FDET(vlRuta)
        NCDET(vlRuta)
        Cliente(vlRuta)
        CxCEdo(vlRuta)

        FileNames = Directory.GetFiles(vlRuta, "*.dbf")

        Comprimir(FileNames, Ruta)

        'Kill(vlRuta & "*.dbf")
        Directory.Delete(vlRuta, True)

    End Sub

    Private Sub Artic(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String

        oGenArch.CrearDBF(Ruta, "Artic", "[CODIGO] TEXT (20), [DIP] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [Artic];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT CodArticulo FROM CatalogoArticulos WHERE DIP=1"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoArticulos")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
            oRstDBF.Fields("DIP").Value = "S"
            oRstDBF.Update()
        Next

        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

    Private Sub FTOT(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String
        Dim vlFecha As Date, vlCadena As String

        vlFecha = Date.Now
        oGenArch.CrearDBF(Ruta, "FTOT", "[Folio] NUMERIC, [Sucursal] TEXT (2), [CodCli] TEXT (10), [Fecha] DATE, [Tip_Vta] TEXT (1), [Status] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [FTOT];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM Factura WHERE Year(Fecha)=" & vlFecha.Year & " And CodAlmacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' And (CodTipoVenta='D') And Status='GRA'"
        dsMultU = oGenArch.DatosATrans(vlComando, "Factura")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Folio").Value = drMultU!FolioFactura
            vlCadena = drMultU!CodAlmacen
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("CodCli").Value = CStr(drMultU!ClienteID).PadLeft(10, "0")
            oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
            oRstDBF.Fields("Tip_Vta").Value = "D"
            oRstDBF.Fields("Status").Value = "A"
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

    Private Sub FDET(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String
        Dim vlFecha As Date, vlCadena As String

        vlFecha = Date.Now
        oGenArch.CrearDBF(Ruta, "FDET", "[Folio] NUMERIC, [Sucursal] TEXT (2), [Codigo] TEXT (20), [Talla] NUMERIC, [Cantidad] NUMERIC, [CostUnit] NUMERIC, [PrecUnit] NUMERIC, [Descu] NUMERIC")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [FDET];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        'vlComando = "SELECT Factura.FolioFactura, Factura.CodAlmacen, FacturaCorrida.CodArticulo, FacturaCorrida.Numero, FacturaCorrida.Cantidad, FacturaCorrida.CostoUnit, FacturaCorrida.PrecioUnit, FacturaCorrida.PrecioUnit + FacturaCorrida.Descuento / 100 + FacturaCorrida.CantDescuentoSistema / FacturaCorrida.Cantidad AS Descuento " & _
        vlComando = "SELECT Factura.FolioFactura, Factura.CodAlmacen, FacturaCorrida.CodArticulo, FacturaCorrida.Numero, FacturaCorrida.Cantidad, FacturaCorrida.CostoUnit, FacturaCorrida.PrecioUnit, FacturaCorrida.Descuento + FacturaCorrida.DescuentoSistema AS Descuento " & _
                    "FROM Factura INNER JOIN FacturaCorrida ON Factura.FacturaID=FacturaCorrida.FacturaID " & _
                    "WHERE Year(Factura.Fecha)=" & vlFecha.Year & " And Factura.CodAlmacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' And (Factura.CodTipoVenta='D') And Factura.Status='GRA'"
        dsMultU = oGenArch.DatosATrans(vlComando, "Factura")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Folio").Value = drMultU!FolioFactura
            vlCadena = drMultU!CodAlmacen
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo

            If IsNumeric(drMultU!Numero) Then
                oRstDBF.Fields("Talla").Value = drMultU!Numero
            Else
                oRstDBF.Fields("Talla").Value = 0
            End If

            oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad
            oRstDBF.Fields("CostUnit").Value = drMultU!CostoUnit
            oRstDBF.Fields("PrecUnit").Value = drMultU!PrecioUnit
            oRstDBF.Fields("Descu").Value = drMultU!Descuento
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

    Private Sub NCDET(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String
        Dim vlFecha As Date, vlCadena As String

        vlFecha = Date.Now
        oGenArch.CrearDBF(Ruta, "NCDET", "[Fecha] DATE, [Sucursal] TEXT (2), [Fecha_Fact] DATE, [Folio_Fact] NUMERIC, [Cantidad] NUMERIC, [Codigo] TEXT (20), [Talla] NUMERIC, [CodCli] TEXT (10)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [NCDET];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT NotasCreditoDetalle.*, Factura.Fecha As Fecha_Fact " & _
                    "FROM NotasCreditoDetalle INNER JOIN Factura ON NotasCreditoDetalle.FolioReferencia=Factura.FolioFactura " & _
                    "WHERE Year(NotasCreditoDetalle.Fecha)=" & vlFecha.Year & " And NotasCreditoDetalle.CodAlmacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' And NotasCreditoDetalle.ClienteID<>1 And NotasCreditoDetalle.StatusRegistro=1"
        dsMultU = oGenArch.DatosATrans(vlComando, "Factura")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
            vlCadena = drMultU!CodAlmacen
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("Fecha_Fact").Value = Format(drMultU!Fecha_Fact, "dd/MM/yyyy")
            oRstDBF.Fields("Folio_Fact").Value = drMultU!FolioReferencia
            oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad
            oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo

            If IsNumeric(drMultU!Numero) Then
                oRstDBF.Fields("Talla").Value = drMultU!Numero
            Else
                oRstDBF.Fields("Talla").Value = 0
            End If

            oRstDBF.Fields("CodCli").Value = CStr(drMultU!ClienteID).PadLeft(10, "0")
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

    Private Sub Cliente(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim oClientMng As New ClientesManager(oApplicationContext)
        Dim oCliente As ClienteAlterno = oClientMng.CreateAlterno
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String
        Dim vlFecha As Date, vlCadena As String

        vlFecha = Date.Now
        oGenArch.CrearDBF(Ruta, "Cliente", "[Codigo] TEXT (10), [Nombre] TEXT (40), [Sexo] TEXT (1), [Direc] TEXT (30), [Edo] TEXT (6), [Ciudad] TEXT (15), [CP] TEXT (10), [Tel1] TEXT (15), [TipoCte] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [Cliente];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT DISTINCT ClienteID FROM Factura WHERE Year(Fecha)=" & vlFecha.Year & " And CodAlmacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' And (CodTipoVenta='D') And Status='GRA'"
        dsMultU = oGenArch.DatosATrans(vlComando, "Factura")
        For Each drMultU In dsMultU.Tables(0).Rows
            oCliente.GenerateRFC = False
            oClientMng.Load(drMultU!ClienteID, oCliente, "D")

            If oCliente.CodigoAlterno <> 0 Then
                oRstDBF.AddNew()

                oRstDBF.Fields("Codigo").Value = oCliente.CodigoAlterno.PadLeft(10, "0")

                vlCadena = oCliente.NombreCompleto
                If vlCadena.Length > 40 Then
                    oRstDBF.Fields("Nombre").Value = vlCadena.Substring(0, 40)
                Else
                    oRstDBF.Fields("Nombre").Value = vlCadena
                End If

                oRstDBF.Fields("Sexo").Value = oCliente.Sexo

                vlCadena = oCliente.Direccion
                If vlCadena.Length > 30 Then
                    oRstDBF.Fields("Direc").Value = vlCadena.Substring(0, 30)
                Else
                    oRstDBF.Fields("Direc").Value = oCliente.Direccion
                End If

                vlCadena = oCliente.Estado
                If vlCadena.Length > 6 Then
                    oRstDBF.Fields("Edo").Value = vlCadena.Substring(0, 6)
                Else
                    oRstDBF.Fields("Edo").Value = oCliente.Estado
                End If

                vlCadena = oCliente.Ciudad
                If vlCadena.Length > 15 Then
                    oRstDBF.Fields("Ciudad").Value = vlCadena.Substring(0, 15)
                Else
                    oRstDBF.Fields("Ciudad").Value = oCliente.Ciudad
                End If

                oRstDBF.Fields("CP").Value = oCliente.CP

                vlCadena = oCliente.Telefono
                If vlCadena.Length > 15 Then
                    oRstDBF.Fields("Tel1").Value = vlCadena.Substring(0, 15)
                Else
                    oRstDBF.Fields("Tel1").Value = oCliente.Telefono
                End If

                oRstDBF.Fields("TipoCte").Value = "D"

                oRstDBF.Update()
            End If

        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

    Private Sub CxCEdo(ByVal Ruta As String)

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsCxCEdo As DataSet, drCxCEdo As DataRow, vlComando As String
        Dim vlFecha As Date

        vlFecha = Date.Now
        oGenArch.CrearDBF(Ruta, "CxCEdo", "[Fecha] DATE, [Fec_Fact] DATE, [Factura] NUMBER, [Saldo_Af] NUMBER, [Status] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Ruta)
        oRstDBF.Open("SELECT * FROM [CxCEdo];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "Select Fecha = Factura.FechaLiquidacion, FechaFactura=Factura.Fecha, Factura.FolioFactura, Factura.Saldo " & _
        " From Factura WHERE Year(Factura.Fecha)=" & vlFecha.Year & " And Factura.CodAlmacen='" & oApplicationContext.ApplicationConfiguration.Almacen & _
        "' And (Factura.CodTipoVenta='D') And Factura.Status='GRA' and Factura.Saldo <= 0"

        dsCxCEdo = oGenArch.DatosATrans(vlComando, "Factura")

        For Each drCxCEdo In dsCxCEdo.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Fecha").Value = Format(drCxCEdo!Fecha, "dd/MM/yyyy")
            oRstDBF.Fields("Fec_Fact").Value = Format(drCxCEdo!FechaFactura, "dd/MM/yyyy")
            oRstDBF.Fields("Factura").Value = drCxCEdo!FolioFactura
            oRstDBF.Fields("Saldo_Af").Value = 0 'drCxCEdo!Saldo
            oRstDBF.Fields("Status").Value = "A"
            oRstDBF.Update()
        Next
        dsCxCEdo = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub

#End Region

End Class
