Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core
Imports Microsoft.VisualBasic

Public Class Auditoria

#Region "Constructors / Destructors"

    Private oApplicationContext As ApplicationContext


    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

#Region "Archivos de Exportación de Información"

    Public Sub ArchivoBat()
        If Dir("C:\DPT\AUD\*.*", FileAttribute.Archive) <> "" Then
            Kill("C:\DPT\AUD\*.*")
        Else
            Directory.CreateDirectory("C:\DPT\AUD")
        End If
        FileOpen(1, "C:\DPT\AUD\ExportInfo.bat", OpenMode.Output)
        PrintLine(1, "C:")
        PrintLine(1, "Cd C:\DPT\AUD")
        PrintLine(1, "arj a AudBas *.dbf")
        PrintLine(1, "Exit")
        PrintLine(1, "Fecha - Hora: " & Date.Now)
        PrintLine(1, "Usuario: " & oApplicationContext.Security.CurrentUser.Name)
        FileClose(1)
    End Sub


    Public Sub AjustesEntrada()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow

        oGenArch.CrearDBF("C:\DPT\AUD\", "AJUSE" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Sucursal] TEXT (2), [Fecha] DATE, [Hora] TEXT (8), [Usuario] TEXT (5), [TipoMov] TEXT (3), [DescripMov] TEXT (25), [Total_Pzas] NUMBER, [Importe] NUMBER, [CostTot] NUMBER, [Status] TEXT (1), [Nota1] TEXT (60), [Nota2] TEXT (60), [Nota3] TEXT (60), [Nota4] TEXT (60)")
        oGenArch.CrearDBF("C:\DPT\AUD\", "AJCORR" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Sucursal] TEXT (2), [Codigo] TEXT (20), [Talla] NUMBER, [Cantidad] NUMBER, [Fecha] DATE, [CostUnit] NUMBER, [PrecUnit] NUMBER")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass
        Dim oRstDetDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [AJUSE" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        oRstDetDBF.Open("SELECT * FROM [AJCORR" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT AjustesEntrada.Folio, AjustesEntrada.Almacen, AjustesEntrada.Fecha, AjustesEntrada.Usuario, Cantidad = AjustesEntrada.TotalCodigos, AjustesEntrada.Observaciones, CatalogoTipoMovimientos.Descripcion, AjustesEntrada.CostoTotal As Importe " & _
                    " FROM AjustesEntrada, CatalogoTipoMovimientos " & _
                    " WHERE 105=CatalogoTipoMovimientos.CodTipoMov And Year(AjustesEntrada.Fecha)=" & Date.Now.Year & "  And AjustesEntrada.Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' "


        'vlComando = "SELECT AjustesEntrada.Folio, AjustesEntrada.Almacen, AjustesEntrada.Fecha, AjustesEntrada.Usuario, AjustesEntrada.TipoMov, AjustesEntrada.Cantidad, AjustesEntrada.Observaciones, CatalogoTipoMovimientos.Descripcion, Sum(AjustesEntradaDetalles.Importe*AjustesEntradaDetalles.Cantidad) As Importe " & _
        '            "FROM AjustesEntrada, AjustesEntradaDetalles, CatalogoTipoMovimientos " & _
        '            "WHERE AjustesEntrada.Folio=AjustesEntradaDetalles.Folio And AjustesEntrada.TipoMov=CatalogoTipoMovimientos.CodTipoMov And Year(AjustesEntrada.Fecha)=" & Date.Now.Year & " And AjustesEntrada.Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' " & _
        '            "GROUP BY AjustesEntrada.Folio, AjustesEntrada.Almacen, AjustesEntrada.Fecha, AjustesEntrada.Usuario, AjustesEntrada.TipoMov, AjustesEntrada.Cantidad, AjustesEntrada.Observaciones, CatalogoTipoMovimientos.Descripcion"

        dsMultU = oGenArch.DatosATrans(vlComando, "AjustesEntrada")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio)
            vlCadena = drMultU!Almacen
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
            oRstDBF.Fields("Hora").Value = Format(drMultU!Fecha, "hh:mm")
            vlCadena = drMultU!Usuario
            oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
            oRstDBF.Fields("TipoMov").Value = "105" 'drMultU!TipoMov
            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 25 Then
                oRstDBF.Fields("DescripMov").Value = vlCadena.Substring(0, 25)
            Else
                oRstDBF.Fields("DescripMov").Value = vlCadena
            End If
            oRstDBF.Fields("Total_Pzas").Value = drMultU!Cantidad
            oRstDBF.Fields("Importe").Value = drMultU!Importe
            oRstDBF.Fields("CostTot").Value = drMultU!Importe
            oRstDBF.Fields("Status").Value = "A"
            vlCadena = drMultU!Observaciones
            Select Case vlCadena.Length
                Case Is <= 60
                    oRstDBF.Fields("NOTA1").Value = vlCadena
                    oRstDBF.Fields("NOTA2").Value = ""
                    oRstDBF.Fields("NOTA3").Value = ""
                    oRstDBF.Fields("NOTA4").Value = ""
                Case Is > 60
                    oRstDBF.Fields("NOTA1").Value = vlCadena.Substring(0, 60)
                    If vlCadena.Length > 120 Then
                        oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, 60)
                    Else
                        oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, vlCadena.Length - 60)
                    End If
                    oRstDBF.Fields("NOTA3").Value = ""
                    oRstDBF.Fields("NOTA4").Value = ""
                Case Is > 120
                    If vlCadena.Length > 180 Then
                        oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, 60)
                    Else
                        oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, vlCadena.Length - 120)
                    End If
                Case Is > 180
                    If vlCadena.Length > 180 Then
                        oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, 60)
                    Else
                        oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, vlCadena.Length - 180)
                    End If
            End Select
            oRstDBF.Update()

            vlComando = "SELECT * FROM AjustesEntradaDetalles WHERE AjustesEntradaDetalles.FolioAjuste=" & drMultU!Folio
            dsMultUD = oGenArch.DatosATrans(vlComando, "AjustesEntradaDetalles")
            For Each drMultUD In dsMultUD.Tables(0).Rows
                oRstDetDBF.AddNew()
                oRstDetDBF.Fields("Folio").Value = CDbl(drMultUD!Folio)
                vlCadena = drMultU!Almacen 'drMultUD!Almacen
                oRstDetDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
                oRstDetDBF.Fields("Codigo").Value = drMultUD!Codigo

                If IsNumeric(drMultUD!Talla) Then
                    oRstDetDBF.Fields("Talla").Value = drMultUD!Talla
                Else
                    oRstDetDBF.Fields("Talla").Value = 0
                End If

                oRstDetDBF.Fields("Cantidad").Value = drMultUD!Cantidad
                oRstDetDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
                oRstDetDBF.Fields("CostUnit").Value = drMultUD!Importe
                oRstDetDBF.Fields("PrecUnit").Value = drMultUD!Importe
                oRstDetDBF.Update()
            Next
            dsMultUD = Nothing

        Next

        dsMultU = Nothing

        oRstDBF.Close()
        oRstDetDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub AjustesSalida()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow

        oGenArch.CrearDBF("C:\DPT\AUD\", "AJUSS" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Sucursal] TEXT (2), [Fecha] DATE, [Hora] TEXT (8), [Usuario] TEXT (5), [TipoMov] TEXT (3), [DescripMov] TEXT (25), [Total_Pzas] NUMBER, [Importe] NUMBER, [CostTot] NUMBER, [Status] TEXT (1), [Nota1] TEXT (60), [Nota2] TEXT (60), [Nota3] TEXT (60), [Nota4] TEXT (60)")
        oGenArch.CrearDBF("C:\DPT\AUD\", "AJCORS" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Sucursal] TEXT (2), [Codigo] TEXT (20), [Talla] NUMBER, [Cantidad] NUMBER, [Fecha] DATE, [CostUnit] NUMBER, [PrecUnit] NUMBER")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass
        Dim oRstDetDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [AJUSS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        oRstDetDBF.Open("SELECT * FROM [AJCORS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT AjustesSalida.Folio, AjustesSalida.Almacen, AjustesSalida.Fecha, AjustesSalida.Usuario,  Cantidad = AjustesSalida.TotalCodigos , AjustesSalida.Observaciones, CatalogoTipoMovimientos.Descripcion, AjustesSalida.CostoTotal As Importe " & _
                    " FROM AjustesSalida, CatalogoTipoMovimientos " & _
                    " WHERE 205=CatalogoTipoMovimientos.CodTipoMov And Year(AjustesSalida.Fecha)=" & Date.Now.Year & " And AjustesSalida.Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' "

        'vlComando = "SELECT AjustesSalida.Folio, AjustesSalida.Almacen, AjustesSalida.Fecha, AjustesSalida.Usuario, AjustesSalida.TipoMov, AjustesSalida.Cantidad, AjustesSalida.Observaciones, CatalogoTipoMovimientos.Descripcion, Sum(AjustesSalidaDetalles.Importe*AjustesSalidaDetalles.Cantidad) As Importe " & _
        '            "FROM AjustesSalida, AjustesSalidaDetalles, CatalogoTipoMovimientos " & _
        '            "WHERE AjustesSalida.Folio=AjustesSalidaDetalles.Folio And AjustesSalida.TipoMov=CatalogoTipoMovimientos.CodTipoMov And Year(AjustesSalida.Fecha)=" & Date.Now.Year & " And AjustesSalida.Almacen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' " & _
        '            "GROUP BY AjustesSalida.Folio, AjustesSalida.Almacen, AjustesSalida.Fecha, AjustesSalida.Usuario, AjustesSalida.TipoMov, AjustesSalida.Cantidad, AjustesSalida.Observaciones, CatalogoTipoMovimientos.Descripcion"

        dsMultU = oGenArch.DatosATrans(vlComando, "AjustesSalida")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio)
            vlCadena = drMultU!Almacen
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
            oRstDBF.Fields("Hora").Value = Format(drMultU!Fecha, "hh:mm")
            vlCadena = drMultU!Usuario
            oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
            oRstDBF.Fields("TipoMov").Value = "205" 'drMultU!TipoMov
            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 25 Then
                oRstDBF.Fields("DescripMov").Value = vlCadena.Substring(0, 25)
            Else
                oRstDBF.Fields("DescripMov").Value = vlCadena
            End If
            oRstDBF.Fields("Total_Pzas").Value = drMultU!Cantidad
            oRstDBF.Fields("Importe").Value = drMultU!Importe
            oRstDBF.Fields("CostTot").Value = drMultU!Importe
            oRstDBF.Fields("Status").Value = "A"
            vlCadena = drMultU!Observaciones
            Select Case vlCadena.Length
                Case Is <= 60
                    oRstDBF.Fields("NOTA1").Value = vlCadena
                    oRstDBF.Fields("NOTA2").Value = ""
                    oRstDBF.Fields("NOTA3").Value = ""
                    oRstDBF.Fields("NOTA4").Value = ""
                Case Is > 60
                    oRstDBF.Fields("NOTA1").Value = vlCadena.Substring(0, 60)
                    If vlCadena.Length > 120 Then
                        oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, 60)
                    Else
                        oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, vlCadena.Length - 60)
                    End If
                    oRstDBF.Fields("NOTA3").Value = ""
                    oRstDBF.Fields("NOTA4").Value = ""
                Case Is > 120
                    If vlCadena.Length > 180 Then
                        oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, 60)
                    Else
                        oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, vlCadena.Length - 120)
                    End If
                Case Is > 180
                    If vlCadena.Length > 180 Then
                        oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, 60)
                    Else
                        oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, vlCadena.Length - 180)
                    End If
            End Select
            oRstDBF.Update()

            vlComando = "SELECT * FROM AjustesSalidaDetalles WHERE AjustesSalidaDetalles.FolioAjuste=" & drMultU!Folio
            dsMultUD = oGenArch.DatosATrans(vlComando, "AjustesEntradaDetalles")
            For Each drMultUD In dsMultUD.Tables(0).Rows
                oRstDetDBF.AddNew()
                oRstDetDBF.Fields("Folio").Value = CDbl(drMultUD!Folio)
                vlCadena = drMultU!Almacen
                oRstDetDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
                oRstDetDBF.Fields("Codigo").Value = drMultUD!Codigo

                If IsNumeric(drMultUD!Talla) Then
                    oRstDetDBF.Fields("Talla").Value = drMultUD!Talla
                Else
                    oRstDetDBF.Fields("Talla").Value = 0
                End If

                oRstDetDBF.Fields("Cantidad").Value = drMultUD!Cantidad
                oRstDetDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
                oRstDetDBF.Fields("CostUnit").Value = drMultUD!Importe
                oRstDetDBF.Fields("PrecUnit").Value = drMultUD!Importe
                oRstDetDBF.Update()
            Next
            dsMultUD = Nothing

        Next

        dsMultU = Nothing

        oRstDBF.Close()
        oRstDetDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Archivos()
        Dim oGenArch As New GenerarArch(oApplicationContext)

        oGenArch.CrearDBF("C:\DPT\AUD\", "ARCHIVOS", "[Fecha] DATE, [Numero] NUMBER")

    End Sub


    Public Sub Articulos()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        ''Con los campos nuevos.
        'oGenArch.CrearDBF("C:\DPT\AUD\", "ARTIC", "[Codigo] TEXT (17), [Descripcio] TEXT (30), [Color] TEXT (15), [Corr_Ini] NUMBER, [Corr_Fin] NUMBER, [Linea] TEXT (3), [Uso] TEXT (8), [Und_Vta] TEXT (3), [Und_Cra] TEXT (3), [Equivc_v] NUMBER, [Prov1] TEXT (10), [Prov2] TEXT (10), [Costo] NUMBER, [Precio] NUMBER, [Util] NUMBER, " & _
        '                 "[Minimo] NUMBER, [Reorden] NUMBER, [Maximo] NUMBER, [Promedio] NUMBER, [Reposicion] NUMBER, [Fec_Ultima] DATE, [Unico] TEXT (1), [Inventario] TEXT (1), [Existencia] NUMBER, [Ult_Compra] DATE, [FUM] DATE, [Ofertado] TEXT (1), [Ofer_Cant] NUMBER, [Ofer_100] NUMBER, [Familia] TEXT (2), [Circula] TEXT (1), " & _
        '                 "[Razon] TEXT (1), [Apartado] NUMBER, [Ofer_Fecha] DATE, [Brinco] NUMBER, [StatusCome] TEXT (6), [Ordenable] TEXT (1), [Descuent] NUMBER, [UPC] TEXT (20), [KIT] BIT, [Serie] BIT, [ImprimeP] BIT, [Importad] BIT, [Pediment] BIT, [Marca] TEXT (2), [Corrida] TEXT (3), " & _
        '                 "[Precio1] NUMBER, [Precio2] NUMBER, [Precio3] NUMBER, [Precio4] NUMBER, [Precio5] NUMBER, [DIP] TEXT (1)")

        '''Con los campos viejos.
        oGenArch.CrearDBF("C:\DPT\AUD\", "ARTIC", "[Codigo] TEXT (17), [Descripcio] TEXT (30), [Color] TEXT (15), [Corr_Ini] NUMBER, [Corr_Fin] NUMBER, [Linea] TEXT (2), [Uso] TEXT (2), [Und_Vta] TEXT (3), [Und_Cra] TEXT (3), [Equivc_v] NUMBER, [Prov1] TEXT (10), [Prov2] TEXT (10), [Costo] NUMBER, [Precio] NUMBER, [Util] NUMBER, " & _
                         "[Minimo] NUMBER, [Reorden] NUMBER, [Maximo] NUMBER, [Promedio] NUMBER, [Reposicion] NUMBER, [Fec_Ultima] DATE, [Unico] TEXT (1), [Inventario] TEXT (1), [Existencia] NUMBER, [Ult_Compra] DATE, [FUM] DATE, [Ofertado] TEXT (1), [Ofer_Cant] NUMBER, [Ofer_100] NUMBER, [Familia] TEXT (2), [Circula] TEXT (1), " & _
                         "[Razon] TEXT (1), [Apartado] NUMBER, [Ofer_Fecha] DATE, [Brinco] NUMBER, [StatusCome] TEXT (6), [Ordenable] TEXT (1), [Descuent] NUMBER, [UPC] TEXT (20), [KIT] BIT, [Serie] BIT, [ImprimeP] BIT, [Importad] BIT, [Pediment] BIT, [Marca] TEXT (2), [Corrida] TEXT (3), " & _
                         "[Precio1] NUMBER, [Precio2] NUMBER, [Precio3] NUMBER, [Precio4] NUMBER, [Precio5] NUMBER, [DIP] TEXT (1)")


        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [ARTIC];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT CatalogoArticulos.*, CatalogoCorridas.NumInicio, CatalogoCorridas.NumFin, CatalogoCorridas.Salto FROM CatalogoArticulos, CatalogoCorridas " & _
                    "WHERE CatalogoArticulos.CodCorrida=CatalogoCorridas.CodCorrida "
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoArticulos")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()

            vlCadena = drMultU!CodArticulo
            If vlCadena.Length > 17 Then
                oRstDBF.Fields("Codigo").Value = vlCadena.Substring(0, 17)
            Else
                oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo
            End If

            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 30 Then
                oRstDBF.Fields("Descripcio").Value = vlCadena.Substring(0, 30)
            Else
                oRstDBF.Fields("Descripcio").Value = drMultU!Descripcion
            End If

            'vlCadena = drMultU!Color1
            'If vlCadena.Length > 15 Then
            '    oRstDBF.Fields("Color").Value = vlCadena.Substring(0, 15)
            'Else
            oRstDBF.Fields("Color").Value = " " 'drMultU!Color1
            'End If

            oRstDBF.Fields("Corr_Ini").Value = drMultU!NumInicio
            oRstDBF.Fields("Corr_Fin").Value = drMultU!NumFin

            oRstDBF.Fields("Linea").Value = Right(CStr(drMultU!CodLinea), 2)
            oRstDBF.Fields("Uso").Value = Right(CStr(drMultU!CodUso), 2)

            oRstDBF.Fields("Und_Vta").Value = drMultU!CodUnidadVta
            oRstDBF.Fields("Und_Cra").Value = drMultU!CodUnidadCom

            oRstDBF.Fields("Equivc_v").Value = 1

            oRstDBF.Fields("Prov1").Value = " " 'drMultU!CodProveedor1
            oRstDBF.Fields("Prov2").Value = " " 'drMultU!CodProveedor2
            oRstDBF.Fields("Costo").Value = drMultU!CostoProm

            oRstDBF.Fields("Precio").Value = drMultU!PrecioVenta

            oRstDBF.Fields("Util").Value = drMultU!MargenUtilidad

            oRstDBF.Fields("Minimo").Value = 0

            oRstDBF.Fields("Reorden").Value = 0 'drMultU!Ordenable

            oRstDBF.Fields("Maximo").Value = 0

            oRstDBF.Fields("Promedio").Value = drMultU!CostoProm

            oRstDBF.Fields("Reposicion").Value = drMultU!CostoProm

            oRstDBF.Fields("Fec_Ultima").Value = Format(Now.Date, "dd/MM/yyyy") 'Format(drMultU!FUO, "dd/MM/yyyy")

            oRstDBF.Fields("Unico").Value = "N"

            oRstDBF.Fields("Inventario").Value = "S"
            oRstDBF.Fields("Existencia").Value = 999
            oRstDBF.Fields("Ult_Compra").Value = Format(Now.Date, "dd/MM/yyyy") 'Format(drMultU!FUC, "dd/MM/yyyy")
            oRstDBF.Fields("FUM").Value = Format(Now.Date, "dd/MM/yyyy") 'Format(drMultU!FUO, "dd/MM/yyyy")

            'If drMultU!PrecioVenta <> drMultU!PrecioOferta Then
            oRstDBF.Fields("Ofertado").Value = "S"
            'Else
            '    oRstDBF.Fields("Ofertado").Value = "N"
            'End If

            oRstDBF.Fields("Ofer_Cant").Value = drMultU!PrecioVenta 'drMultU!PrecioOferta
            oRstDBF.Fields("Ofer_100").Value = drMultU!Descuento
            oRstDBF.Fields("Familia").Value = drMultU!CodFamilia
            oRstDBF.Fields("Circula").Value = ""
            oRstDBF.Fields("Razon").Value = ""
            oRstDBF.Fields("Apartado").Value = 0
            oRstDBF.Fields("Ofer_Fecha").Value = Format(Now.Date, "dd/MM/yyyy")  'Format(drMultU!FechaOferta, "dd/MM/yyyy")
            oRstDBF.Fields("Brinco").Value = drMultU!Salto
            oRstDBF.Fields("StatusCome").Value = "Linea" 'drMultU!CodStatusArticulo

            'If drMultU!Ordenable = 0 Then
            'oRstDBF.Fields("Ordenable").Value = "N"
            'Else
                oRstDBF.Fields("Ordenable").Value = "S"
            'End If

            oRstDBF.Fields("Descuent").Value = drMultU!Descuento
            oRstDBF.Fields("UPC").Value = ""
            oRstDBF.Fields("Unico").Value = False
            oRstDBF.Fields("KIT").Value = False
            oRstDBF.Fields("Serie").Value = False
            oRstDBF.Fields("ImprimeP").Value = False
            oRstDBF.Fields("Importad").Value = False
            oRstDBF.Fields("Pediment").Value = False

            oRstDBF.Fields("Marca").Value = drMultU!CodMarca
            oRstDBF.Fields("Corrida").Value = drMultU!CodCorrida

            oRstDBF.Fields("Precio1").Value = 0
            oRstDBF.Fields("Precio2").Value = 0
            oRstDBF.Fields("Precio3").Value = 0
            oRstDBF.Fields("Precio4").Value = 0
            oRstDBF.Fields("Precio5").Value = 0

            If drMultU!DIP = 0 Then
                oRstDBF.Fields("DIP").Value = "N"
            Else
                oRstDBF.Fields("DIP").Value = "S"
            End If
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Movimientos()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow

        oGenArch.CrearDBF("C:\DPT\AUD\", "BASMD" & Format(Date.Now, "yy"), "[TipoMov] TEXT (4), [FolioCtrl] TEXT (7), [MovES] TEXT (1), [Fecha] DATE, [DescMov] TEXT (50), [Folio] NUMBER, [Status] TEXT (1), [Codigo] TEXT (17), [Numero] NUMBER, [Descripcio] TEXT (30), [Cantidad] NUMBER, [Unidad] TEXT (3), [Costo] NUMBER, [Importe] NUMBER, [OrigDst] TEXT (10), " & _
                         "[Sucursal] TEXT (2), [TotNC] NUMBER, [TotDesc] NUMBER, [TotFGral] NUMBER, [PrecUnit] NUMBER, [CostUnit] NUMBER, [Usuario] TEXT (5), [Vta_DIP] TEXT (1), [Cost_NC] NUMBER, [CCtaCont] TEXT (12)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [BASMD" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT Movimientos.*, CatalogoTipoMovimientos.Descripcion AS DescTM, CatalogoTipoMovimientos.Tipo, TipoMov= ' ' FROM Movimientos INNER JOIN CatalogoTipoMovimientos ON Movimientos.CodTipoMov=CatalogoTipoMovimientos.CodTipoMov " & _
                    "WHERE Year(Movimientos.FechaMov)=" & Date.Now.Year
        dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("TipoMov").Value = drMultU!TipoMov '
            oRstDBF.Fields("FolioCtrl").Value = drMultU!FolioControl '
            oRstDBF.Fields("MovES").Value = drMultU!Tipo '
            oRstDBF.Fields("Fecha").Value = Format(drMultU!FechaMov, "dd/MM/yyyy") '
            oRstDBF.Fields("DescMov").Value = drMultU!DescTM '
            oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio) '

            oRstDBF.Fields("Status").Value = drMultU!StatusMov '
            vlCadena = drMultU!Usuario '
            If drMultU!CodTipoMov = "201" Then
                vlComando = "SELECT Status, CodVendedor FROM Factura WHERE FolioFactura=" & drMultU!Folio
                dsMultUD = oGenArch.DatosATrans(vlComando, "Factura")
                For Each drMultUD In dsMultUD.Tables(0).Rows
                    vlCadena = drMultUD!CodVendedor
                    If drMultUD!Status = "CAN" Then
                        oRstDBF.Fields("Status").Value = "C"
                    Else
                        oRstDBF.Fields("Status").Value = "A"
                    End If
                Next
            End If
            If vlCadena.Length > 5 Then
                oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
            Else
                oRstDBF.Fields("Usuario").Value = vlCadena
            End If

            oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo '

            If IsNumeric(drMultU!Numero) Then
                oRstDBF.Fields("Numero").Value = drMultU!Numero '
            Else
                oRstDBF.Fields("Numero").Value = 0 '
            End If

            vlCadena = drMultU!Descripcion '
            If vlCadena.Length > 30 Then
                oRstDBF.Fields("Descripcio").Value = vlCadena.Substring(0, 30)
            Else
                oRstDBF.Fields("Descripcio").Value = drMultU!Descripcion
            End If

            oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad '
            oRstDBF.Fields("Unidad").Value = drMultU!CodUnidad '
            oRstDBF.Fields("Costo").Value = drMultU!CostoTotal '
            oRstDBF.Fields("Importe").Value = drMultU!Importe '
            oRstDBF.Fields("OrigDst").Value = drMultU!Destino '
            vlCadena = drMultU!Origen '
            oRstDBF.Fields("Sucursal").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("TotNC").Value = drMultU!TotNC '
            oRstDBF.Fields("TotDesc").Value = drMultU!Descuento '
            oRstDBF.Fields("TotFGral").Value = drMultU!TotFGral '
            oRstDBF.Fields("PrecUnit").Value = drMultU!PrecioUnit '
            oRstDBF.Fields("CostUnit").Value = drMultU!CostoUnit '
            oRstDBF.Fields("Vta_DIP").Value = drMultU!VTA_DIP '
            oRstDBF.Fields("Cost_NC").Value = drMultU!CostoNC '
            oRstDBF.Fields("CCtaCont").Value = ""
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Existencias()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        ''Campos Nuevos
        'oGenArch.CrearDBF("C:\DPT\AUD\", "EXIS" & Format(Date.Now, "yy"), "[Suc] TEXT (2), [Codigo] TEXT (20), [Numero] NUMBER, [Existencia] NUMBER, [Pedidos] NUMBER, [Ordenados] NUMBER, [Saldo_1] NUMBER, [Entro_1] NUMBER, [Salio_1] NUMBER, " & _
        '                  "[Saldo_2] NUMBER, [Entro_2] NUMBER, [Salio_2] NUMBER, [Saldo_3] NUMBER, [Entro_3] NUMBER, [Salio_3] NUMBER, [Saldo_4] NUMBER, [Entro_4] NUMBER, [Salio_4] NUMBER, [Saldo_5] NUMBER, [Entro_5] NUMBER, [Salio_5] NUMBER, " & _
        '                  "[Saldo_6] NUMBER, [Entro_6] NUMBER, [Salio_6] NUMBER, [Saldo_7] NUMBER, [Entro_7] NUMBER, [Salio_7] NUMBER, [Saldo_8] NUMBER, [Entro_8] NUMBER, [Salio_8] NUMBER, [Saldo_9] NUMBER, [Entro_9] NUMBER, [Salio_9] NUMBER, " & _
        '                  "[Saldo_10] NUMBER, [Entro_10] NUMBER, [Salio_10] NUMBER, [Saldo_11] NUMBER, [Entro_11] NUMBER, [Salio_11] NUMBER, [Saldo_12] NUMBER, [Entro_12] NUMBER, [Salio_12] NUMBER, [FUM] DATE, [Familia] TEXT (2), [Apartado] NUMBER, [Defectuoso] NUMBER")

        ''Campos Viejos.
        oGenArch.CrearDBF("C:\DPT\AUD\", "EXIS" & Format(Date.Now, "yy"), "[Suc] TEXT (2), [Codigo] TEXT (17), [Numero] NUMBER, [Existencia] NUMBER, [Pedidos] NUMBER, [Ordenados] NUMBER, [Saldo_1] NUMBER, [Entro_1] NUMBER, [Salio_1] NUMBER, " & _
                          "[Saldo_2] NUMBER, [Entro_2] NUMBER, [Salio_2] NUMBER, [Saldo_3] NUMBER, [Entro_3] NUMBER, [Salio_3] NUMBER, [Saldo_4] NUMBER, [Entro_4] NUMBER, [Salio_4] NUMBER, [Saldo_5] NUMBER, [Entro_5] NUMBER, [Salio_5] NUMBER, " & _
                          "[Saldo_6] NUMBER, [Entro_6] NUMBER, [Salio_6] NUMBER, [Saldo_7] NUMBER, [Entro_7] NUMBER, [Salio_7] NUMBER, [Saldo_8] NUMBER, [Entro_8] NUMBER, [Salio_8] NUMBER, [Saldo_9] NUMBER, [Entro_9] NUMBER, [Salio_9] NUMBER, " & _
                          "[Saldo_10] NUMBER, [Entro_10] NUMBER, [Salio_10] NUMBER, [Saldo_11] NUMBER, [Entro_11] NUMBER, [Salio_11] NUMBER, [Saldo_12] NUMBER, [Entro_12] NUMBER, [Salio_12] NUMBER, [FUM] DATE, [Familia] TEXT (2), [Apartado] NUMBER, [Defectuoso] NUMBER")
        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [EXIS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM Existencias WHERE CodAlmacen=" & oApplicationContext.ApplicationConfiguration.Almacen
        dsMultU = oGenArch.DatosATrans(vlComando, "Existencias")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            vlCadena = drMultU!CodAlmacen
            oRstDBF.Fields("Suc").Value = vlCadena.Substring(1, 2)
            oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo
            If IsNumeric(drMultU!Numero) Then
                oRstDBF.Fields("Numero").Value = drMultU!Numero
            Else
                oRstDBF.Fields("Numero").Value = 0 '
            End If

            oRstDBF.Fields("Existencia").Value = drMultU!Total
            oRstDBF.Fields("Pedidos").Value = 0
            oRstDBF.Fields("Ordenados").Value = 0
            oRstDBF.Fields("Saldo_1").Value = drMultU!Saldo_1
            oRstDBF.Fields("Entro_1").Value = drMultU!Entro_1
            oRstDBF.Fields("Salio_1").Value = drMultU!Salio_1
            oRstDBF.Fields("Saldo_2").Value = drMultU!Saldo_2
            oRstDBF.Fields("Entro_2").Value = drMultU!Entro_2
            oRstDBF.Fields("Salio_2").Value = drMultU!Salio_2
            oRstDBF.Fields("Saldo_3").Value = drMultU!Saldo_3
            oRstDBF.Fields("Entro_3").Value = drMultU!Entro_3
            oRstDBF.Fields("Salio_3").Value = drMultU!Salio_3
            oRstDBF.Fields("Saldo_4").Value = drMultU!Saldo_4
            oRstDBF.Fields("Entro_4").Value = drMultU!Entro_4
            oRstDBF.Fields("Salio_4").Value = drMultU!Salio_4
            oRstDBF.Fields("Saldo_5").Value = drMultU!Saldo_5
            oRstDBF.Fields("Entro_5").Value = drMultU!Entro_5
            oRstDBF.Fields("Salio_5").Value = drMultU!Salio_5
            oRstDBF.Fields("Saldo_6").Value = drMultU!Saldo_6
            oRstDBF.Fields("Entro_6").Value = drMultU!Entro_6
            oRstDBF.Fields("Salio_6").Value = drMultU!Salio_6
            oRstDBF.Fields("Saldo_7").Value = drMultU!Saldo_7
            oRstDBF.Fields("Entro_7").Value = drMultU!Entro_7
            oRstDBF.Fields("Salio_7").Value = drMultU!Salio_7
            oRstDBF.Fields("Saldo_8").Value = drMultU!Saldo_8
            oRstDBF.Fields("Entro_8").Value = drMultU!Entro_8
            oRstDBF.Fields("Salio_8").Value = drMultU!Salio_8
            oRstDBF.Fields("Saldo_9").Value = drMultU!Saldo_9
            oRstDBF.Fields("Entro_9").Value = drMultU!Entro_9
            oRstDBF.Fields("Salio_9").Value = drMultU!Salio_9
            oRstDBF.Fields("Saldo_10").Value = drMultU!Saldo_10
            oRstDBF.Fields("Entro_10").Value = drMultU!Entro_10
            oRstDBF.Fields("Salio_10").Value = drMultU!Salio_10
            oRstDBF.Fields("Saldo_11").Value = drMultU!Saldo_11
            oRstDBF.Fields("Entro_11").Value = drMultU!Entro_11
            oRstDBF.Fields("Salio_11").Value = drMultU!Salio_11
            oRstDBF.Fields("Saldo_12").Value = drMultU!Saldo_12
            oRstDBF.Fields("Entro_12").Value = drMultU!Entro_12
            oRstDBF.Fields("Salio_12").Value = drMultU!Salio_12

            If IsDBNull(drMultU!FUM) Then
                oRstDBF.Fields("FUM").Value = Format(Now.Date, "dd/MM/yyyy")
            Else
                oRstDBF.Fields("FUM").Value = Format(drMultU!FUM, "dd/MM/yyyy")
            End If


            oRstDBF.Fields("Familia").Value = drMultU!CodFamilia
            oRstDBF.Fields("Apartado").Value = drMultU!Apartados
            oRstDBF.Fields("Defectuoso").Value = drMultU!Defectuosos
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub ExpoInfo()
        Dim oGenArch As New GenerarArch(oApplicationContext)

        oGenArch.CrearDBF("C:\DPT\AUD\", "EXPOINFO", "[Fecha] DATE, [Numero] NUMBER")

    End Sub


    Public Sub Familias()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        oGenArch.CrearDBF("C:\DPT\AUD\", "FAMILIA", "[Codigo] TEXT (2), [Nombre] TEXT (25)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [FAMILIA];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoFamilias"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoFamilias")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Codigo").Value = drMultU!CodFamilia
            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 25 Then
                oRstDBF.Fields("Nombre").Value = vlCadena.Substring(0, 25)
            Else
                oRstDBF.Fields("Nombre").Value = drMultU!Descripcion
            End If
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Lineas()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        ''campos nuevos
        'oGenArch.CrearDBF("C:\DPT\AUD\", "LINEAS", "[Codigo] TEXT (3), [Nombre] TEXT (25)")

        ''Campos viejos.
        oGenArch.CrearDBF("C:\DPT\AUD\", "LINEAS", "[Codigo] TEXT (2), [Nombre] TEXT (25)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [LINEAS];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoLineas"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoLineas")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()

            oRstDBF.Fields("Codigo").Value = Right(CStr(drMultU!CodLinea), 2)

            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 25 Then
                oRstDBF.Fields("Nombre").Value = vlCadena.Substring(0, 25)
            Else
                oRstDBF.Fields("Nombre").Value = drMultU!Descripcion
            End If
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Marcas()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        oGenArch.CrearDBF("C:\DPT\AUD\", "MARCAS", "[Codigo] TEXT (2), [Nombre] TEXT (25), [Origen] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [MARCAS];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoMarcas"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoMarcas")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Codigo").Value = drMultU!CodMarca
            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 25 Then
                oRstDBF.Fields("Nombre").Value = vlCadena.Substring(0, 25)
            Else
                oRstDBF.Fields("Nombre").Value = drMultU!Descripcion
            End If
            oRstDBF.Fields("Origen").Value = drMultU!CodOrigen
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub TCanOD()
        Dim oGenArch As New GenerarArch(oApplicationContext)

        oGenArch.CrearDBF("C:\DPT\AUD\", "TCANOD" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Sucursal] TEXT (2), [EntSal] TEXT (2), [Referencia] NUMBER, [Usuario] TEXT (5), [Fecha] DATE, [Hora] TEXT (8)")

    End Sub


    Public Sub TipoAjustes()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        oGenArch.CrearDBF("C:\DPT\AUD\", "TIPAJUS", "[Codigo] TEXT (3), [Descripcio] TEXT (30)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [TIPAJUS];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoTipoMovimientos WHERE CodTipoMov IN(101,103,105,106,107,108,109,110,111,113,118,205,207,208,209," & _
                    " 210,211,212,213,214,216)"

        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoTipoMovimientos")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            oRstDBF.Fields("Codigo").Value = drMultU!CodTipoMov
            vlCadena = drMultU!Descripcion
            If vlCadena.Length > 30 Then
                oRstDBF.Fields("Descripcio").Value = vlCadena.Substring(0, 30)
            Else
                oRstDBF.Fields("Descripcio").Value = drMultU!Descripcion
            End If
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub TraspasosEntrada()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow, i As Integer, vlNumero As Double

        oGenArch.CrearDBF("C:\DPT\AUD\", "TRAS" & Format(Date.Now, "yy"), "[Folio] NUMBER, [FolioEnv] NUMBER, [Fecha] DATE, [Suc_Orig] TEXT (2), [Suc_Dst] TEXT (2), [Usuario] TEXT (5), [Cantidad] NUMBER, [Importe] NUMBER, [Hora] TEXT (8), [FechaEnv] DATE, [HoraEnv] TEXT (8), [UsuarioEnv] TEXT (5), [Status] TEXT (1), [FolioCtrl] NUMBER, [GUIA] TEXT (15), [Nota1] TEXT (60), [Nota2] TEXT (60), [Nota3] TEXT (60), [Nota4] TEXT (60)")
        oGenArch.CrearDBF("C:\DPT\AUD\", "TRCORR" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Codigo] TEXT (17), [Talla] NUMBER, [Cantidad] NUMBER, [CostUnit] NUMBER, [Importe] NUMBER, [Fecha] DATE")

        'Dim oConDBF As New ADODB.ConnectionClass
        'Dim oRstDBF As New ADODB.RecordsetClass
        'Dim oRstDetDBF As New ADODB.RecordsetClass

        'oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        'oRstDBF.Open("SELECT * FROM [TRAS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'oRstDetDBF.Open("SELECT * FROM [TRCORR" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        'vlComando = "SELECT Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Referencia, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.FechaRecibe, Traspaso.UsuarioRecibe, Traspaso.NumConsecutivo, Traspaso.Guia, Traspaso.Observaciones, Sum(TraspasoCorrida.Cantidad) As Cantidad, Sum(TraspasoCorrida.Importe) As Importe " & _
        '            "FROM Traspaso INNER JOIN TraspasoCorrida ON Traspaso.TraspasoID=TraspasoCorrida.TraspasoID " & _
        '            "WHERE Traspaso.Origen=" & oApplicationContext.ApplicationConfiguration.Almacen & " And Year(Traspaso.Fecha)=" & Date.Now.Year & " And Traspaso.Status='REC' " & _
        '            "GROUP BY Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Referencia, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.FechaRecibe, Traspaso.UsuarioRecibe, Traspaso.NumConsecutivo, Traspaso.Guia, Traspaso.Observaciones"
        'dsMultU = oGenArch.DatosATrans(vlComando, "Traspaso")
        'For Each drMultU In dsMultU.Tables(0).Rows
        '    oRstDBF.AddNew()
        '    oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio)
        '    oRstDBF.Fields("FolioEnv").Value = drMultU!Referencia
        '    oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
        '    vlCadena = drMultU!Almacen
        '    oRstDBF.Fields("Suc_Orig").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Origen
        '    oRstDBF.Fields("Suc_Dst").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Usuario
        '    If vlCadena.Length > 5 Then
        '        oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
        '    Else
        '        oRstDBF.Fields("Usuario").Value = drMultU!Usuario
        '    End If
        '    oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad
        '    oRstDBF.Fields("Importe").Value = drMultU!Importe
        '    oRstDBF.Fields("Hora").Value = Format(drMultU!Fecha, "hh:mm")
        '    oRstDBF.Fields("FechaEnv").Value = Format(drMultU!FechaRecibe, "dd/MM/yyyy")
        '    oRstDBF.Fields("HoraEnv").Value = Format(drMultU!FechaRecibe, "hh:mm")
        '    vlCadena = drMultU!UsuarioRecibe
        '    If vlCadena.Length > 5 Then
        '        oRstDBF.Fields("UsuarioEnv").Value = vlCadena.Substring(0, 5)
        '    Else
        '        oRstDBF.Fields("UsuarioEnv").Value = drMultU!UsuarioRecibe
        '    End If
        '    oRstDBF.Fields("Status").Value = "A"
        '    oRstDBF.Fields("FolioCtrl").Value = drMultU!NumConsecutivo
        '    oRstDBF.Fields("GUIA").Value = drMultU!Guia

        '    vlCadena = drMultU!Observaciones
        '    Select Case vlCadena.Length
        '        Case Is <= 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena
        '            oRstDBF.Fields("NOTA2").Value = ""
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena.Substring(0, 60)
        '            If vlCadena.Length > 120 Then
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, 60)
        '            Else
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, vlCadena.Length - 60)
        '            End If
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 120
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, 60)
        '            Else
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, vlCadena.Length - 120)
        '            End If
        '        Case Is > 180
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, 60)
        '            Else
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, vlCadena.Length - 180)
        '            End If
        '    End Select
        '    oRstDBF.Update()

        '    vlComando = "SELECT TraspasoCorrida.*, CatalogoCorridas.NumInicio, CatalogoCorridas.NumFin, CatalogoCorridas.Salto FROM TraspasoCorrida INNER JOIN CatalogoCorridas ON TraspasoCorrida.Corrida=CatalogoCorridas.CodCorrida " & _
        '                "WHERE TraspasoID=" & drMultU!TraspasoID
        '    dsMultUD = oGenArch.DatosATrans(vlComando, "TraspasoCorrida")
        '    For Each drMultUD In dsMultUD.Tables(0).Rows

        '        i = 1
        '        vlNumero = drMultUD!NumInicio
        '        Do While vlNumero <= drMultUD!NumFin
        '            If drMultUD.Item("C" & Format(i, "00")) <> 0 Then
        '                oRstDetDBF.AddNew()
        '                oRstDetDBF.Fields("Folio").Value = CDbl(drMultUD!Folio)
        '                oRstDetDBF.Fields("Codigo").Value = drMultUD!Codigo
        '                oRstDetDBF.Fields("Talla").Value = vlNumero
        '                oRstDetDBF.Fields("Cantidad").Value = drMultUD.Item("C" & Format(i, "00")) * drMultUD!Multiplica
        '                oRstDetDBF.Fields("CostUnit").Value = drMultUD!CostoUnit
        '                oRstDetDBF.Fields("Importe").Value = drMultUD!Importe
        '                oRstDetDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
        '                oRstDetDBF.Update()
        '            End If
        '            If drMultUD!Salto = 0 Then
        '                vlNumero += 1
        '            Else
        '                vlNumero += drMultUD!Salto
        '            End If
        '            i += 1
        '        Loop
        '    Next
        '    dsMultUD = Nothing

        'Next

        'dsMultU = Nothing

        'oRstDBF.Close()
        'oRstDetDBF.Close()
        'oConDBF.Close()

    End Sub


    Public Sub TraspasosSalida()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow, i As Integer, vlNumero As Double

        oGenArch.CrearDBF("C:\DPT\AUD\", "TRASS" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Fecha] DATE, [Suc_Orig] TEXT (2), [Suc_Dst] TEXT (2), [Usuario] TEXT (5), [Cantidad] NUMBER, [Importe] NUMBER, [Hora] TEXT (8), [FolioRec] NUMBER, [FechaRec] DATE, [HoraRec] TEXT (8), [UsuarioRec] TEXT (5), [Status] TEXT (1), [FolioCtrl] NUMBER, [Nota1] TEXT (60), [Nota2] TEXT (60), [Nota3] TEXT (60), [Nota4] TEXT (60), [GUIA] TEXT (15)")
        oGenArch.CrearDBF("C:\DPT\AUD\", "TRCORS" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Codigo] TEXT (17), [Talla] NUMBER, [Cantidad] NUMBER, [CostUnit] NUMBER, [Importe] NUMBER, [Fecha] DATE")

        'Dim oConDBF As New ADODB.ConnectionClass
        'Dim oRstDBF As New ADODB.RecordsetClass
        'Dim oRstDetDBF As New ADODB.RecordsetClass

        'oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        'oRstDBF.Open("SELECT * FROM [TRASS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'oRstDetDBF.Open("SELECT * FROM [TRCORS" & Format(Date.Now, "yy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        'vlComando = "SELECT Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Referencia, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.FechaRecibe, Traspaso.UsuarioRecibe, Traspaso.NumConsecutivo, Traspaso.Guia, Traspaso.Observaciones, Sum(TraspasoCorrida.Cantidad) As Cantidad, Sum(TraspasoCorrida.Importe) As Importe " & _
        '            "FROM Traspaso INNER JOIN TraspasoCorrida ON Traspaso.TraspasoID=TraspasoCorrida.TraspasoID " & _
        '            "WHERE Traspaso.Almacen=" & oApplicationContext.ApplicationConfiguration.Almacen & " And Year(Traspaso.Fecha)=" & Date.Now.Year & " " & _
        '            "GROUP BY Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Referencia, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.FechaRecibe, Traspaso.UsuarioRecibe, Traspaso.NumConsecutivo, Traspaso.Guia, Traspaso.Observaciones"
        'dsMultU = oGenArch.DatosATrans(vlComando, "Traspaso")
        'For Each drMultU In dsMultU.Tables(0).Rows
        '    oRstDBF.AddNew()
        '    oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio)
        '    oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
        '    vlCadena = drMultU!Almacen
        '    oRstDBF.Fields("Suc_Orig").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Origen
        '    oRstDBF.Fields("Suc_Dst").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Usuario
        '    If vlCadena.Length > 5 Then
        '        oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
        '    Else
        '        oRstDBF.Fields("Usuario").Value = drMultU!Usuario
        '    End If
        '    oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad
        '    oRstDBF.Fields("Importe").Value = drMultU!Importe
        '    oRstDBF.Fields("Hora").Value = Format(drMultU!Fecha, "hh:mm")
        '    If drMultU!Referencia <> "" Then
        '        oRstDBF.Fields("FolioRec").Value = CDbl(drMultU!Referencia)
        '        oRstDBF.Fields("FechaRec").Value = Format(drMultU!FechaRecibe, "dd/MM/yyyy")
        '        oRstDBF.Fields("HoraRec").Value = Format(drMultU!FechaRecibe, "hh:mm")
        '        vlCadena = drMultU!UsuarioRecibe
        '        If vlCadena.Length > 5 Then
        '            oRstDBF.Fields("UsuarioRec").Value = vlCadena.Substring(0, 5)
        '        Else
        '            oRstDBF.Fields("UsuarioRec").Value = drMultU!UsuarioRecibe
        '        End If
        '    End If
        '    oRstDBF.Fields("Status").Value = "A"
        '    oRstDBF.Fields("FolioCtrl").Value = drMultU!NumConsecutivo
        '    oRstDBF.Fields("GUIA").Value = drMultU!Guia

        '    vlCadena = drMultU!Observaciones
        '    Select Case vlCadena.Length
        '        Case Is <= 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena
        '            oRstDBF.Fields("NOTA2").Value = ""
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena.Substring(0, 60)
        '            If vlCadena.Length > 120 Then
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, 60)
        '            Else
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, vlCadena.Length - 60)
        '            End If
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 120
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, 60)
        '            Else
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, vlCadena.Length - 120)
        '            End If
        '        Case Is > 180
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, 60)
        '            Else
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, vlCadena.Length - 180)
        '            End If
        '    End Select
        '    oRstDBF.Update()

        '    vlComando = "SELECT TraspasoCorrida.*, CatalogoCorridas.NumInicio, CatalogoCorridas.NumFin, CatalogoCorridas.Salto FROM TraspasoCorrida INNER JOIN CatalogoCorridas ON TraspasoCorrida.Corrida=CatalogoCorridas.CodCorrida " & _
        '                "WHERE TraspasoID=" & drMultU!TraspasoID
        '    dsMultUD = oGenArch.DatosATrans(vlComando, "TraspasoCorrida")
        '    For Each drMultUD In dsMultUD.Tables(0).Rows

        '        i = 1
        '        vlNumero = drMultUD!NumInicio
        '        Do While vlNumero <= drMultUD!NumFin
        '            If drMultUD.Item("C" & Format(i, "00")) <> 0 Then
        '                oRstDetDBF.AddNew()
        '                oRstDetDBF.Fields("Folio").Value = CDbl(drMultUD!Folio)
        '                oRstDetDBF.Fields("Codigo").Value = drMultUD!Codigo
        '                oRstDetDBF.Fields("Talla").Value = vlNumero
        '                oRstDetDBF.Fields("Cantidad").Value = drMultUD.Item("C" & Format(i, "00")) * drMultUD!Multiplica
        '                oRstDetDBF.Fields("CostUnit").Value = drMultUD!CostoUnit
        '                oRstDetDBF.Fields("Importe").Value = drMultUD!Importe
        '                oRstDetDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
        '                oRstDetDBF.Update()
        '            End If
        '            If drMultUD!Salto = 0 Then
        '                vlNumero += 1
        '            Else
        '                vlNumero += drMultUD!Salto
        '            End If
        '            i += 1
        '        Loop
        '    Next
        '    dsMultUD = Nothing

        'Next

        'dsMultU = Nothing

        'oRstDBF.Close()
        'oRstDetDBF.Close()
        'oConDBF.Close()

    End Sub


    Public Sub TraspasosPendientes()

        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String
        Dim dsMultUD As DataSet, drMultUD As DataRow, i As Integer, vlNumero As Double

        oGenArch.CrearDBF("C:\DPT\AUD\", "TRASPENG", "[Folio] NUMBER, [Fecha] DATE, [Hora] TEXT (8), [Suc_Orig] TEXT (2), [Suc_Dst] TEXT (2), [Usuario] TEXT (5), [Cantidad] NUMBER, [Importe] NUMBER, [GUIA] TEXT (15), [Nota1] TEXT (60), [Nota2] TEXT (60), [Nota3] TEXT (60), [Nota4] TEXT (60)")
        oGenArch.CrearDBF("C:\DPT\AUD\", "TRASPEND", "[Folio] NUMBER, [Suc_Orig] TEXT (2), [Codigo] TEXT (17), [Talla] NUMBER, [Cantidad] NUMBER, [CostUnit] NUMBER, [Importe] NUMBER")

        'Dim oConDBF As New ADODB.ConnectionClass
        'Dim oRstDBF As New ADODB.RecordsetClass
        'Dim oRstDetDBF As New ADODB.RecordsetClass

        'oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        'oRstDBF.Open("SELECT * FROM [TRASPENG];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'oRstDetDBF.Open("SELECT * FROM [TRASPEND];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        'vlComando = "SELECT Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.Guia, Traspaso.Observaciones, Sum(TraspasoCorrida.Cantidad) As Cantidad, Sum(TraspasoCorrida.Importe) As Importe " & _
        '            "FROM Traspaso INNER JOIN TraspasoCorrida ON Traspaso.TraspasoID=TraspasoCorrida.TraspasoID " & _
        '            "WHERE Traspaso.Origen=" & oApplicationContext.ApplicationConfiguration.Almacen & " And Year(Traspaso.Fecha)=" & Date.Now.Year & " And Traspaso.Status<>'REC' " & _
        '            "GROUP BY Traspaso.TraspasoID, Traspaso.Folio, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.Guia, Traspaso.Observaciones"
        'dsMultU = oGenArch.DatosATrans(vlComando, "Traspaso")
        'For Each drMultU In dsMultU.Tables(0).Rows
        '    oRstDBF.AddNew()
        '    oRstDBF.Fields("Folio").Value = CDbl(drMultU!Folio)
        '    oRstDBF.Fields("Fecha").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
        '    oRstDBF.Fields("Hora").Value = Format(drMultU!Fecha, "hh:mm")
        '    vlCadena = drMultU!Almacen
        '    oRstDBF.Fields("Suc_Orig").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Origen
        '    oRstDBF.Fields("Suc_Dst").Value = vlCadena.Substring(1, 2)
        '    vlCadena = drMultU!Usuario
        '    If vlCadena.Length > 5 Then
        '        oRstDBF.Fields("Usuario").Value = vlCadena.Substring(0, 5)
        '    Else
        '        oRstDBF.Fields("Usuario").Value = drMultU!Usuario
        '    End If
        '    oRstDBF.Fields("Cantidad").Value = drMultU!Cantidad
        '    oRstDBF.Fields("Importe").Value = drMultU!Importe
        '    oRstDBF.Fields("GUIA").Value = drMultU!Guia

        '    vlCadena = drMultU!Observaciones
        '    Select Case vlCadena.Length
        '        Case Is <= 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena
        '            oRstDBF.Fields("NOTA2").Value = ""
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 60
        '            oRstDBF.Fields("NOTA1").Value = vlCadena.Substring(0, 60)
        '            If vlCadena.Length > 120 Then
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, 60)
        '            Else
        '                oRstDBF.Fields("NOTA2").Value = vlCadena.Substring(60, vlCadena.Length - 60)
        '            End If
        '            oRstDBF.Fields("NOTA3").Value = ""
        '            oRstDBF.Fields("NOTA4").Value = ""
        '        Case Is > 120
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, 60)
        '            Else
        '                oRstDBF.Fields("NOTA3").Value = vlCadena.Substring(120, vlCadena.Length - 120)
        '            End If
        '        Case Is > 180
        '            If vlCadena.Length > 180 Then
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, 60)
        '            Else
        '                oRstDBF.Fields("NOTA4").Value = vlCadena.Substring(180, vlCadena.Length - 180)
        '            End If
        '    End Select
        '    oRstDBF.Update()

        '    vlComando = "SELECT TraspasoCorrida.*, CatalogoCorridas.NumInicio, CatalogoCorridas.NumFin, CatalogoCorridas.Salto FROM TraspasoCorrida INNER JOIN CatalogoCorridas ON TraspasoCorrida.Corrida=CatalogoCorridas.CodCorrida " & _
        '                "WHERE TraspasoID=" & drMultU!TraspasoID
        '    dsMultUD = oGenArch.DatosATrans(vlComando, "TraspasoCorrida")
        '    For Each drMultUD In dsMultUD.Tables(0).Rows

        '        i = 1
        '        vlNumero = drMultUD!NumInicio
        '        Do While vlNumero <= drMultUD!NumFin
        '            If drMultUD.Item("C" & Format(i, "00")) <> 0 Then
        '                oRstDetDBF.AddNew()
        '                oRstDetDBF.Fields("Folio").Value = CDbl(drMultUD!Folio)
        '                vlCadena = drMultU!Almacen
        '                oRstDetDBF.Fields("Suc_Orig").Value = vlCadena.Substring(1, 2)
        '                oRstDetDBF.Fields("Codigo").Value = drMultUD!Codigo
        '                oRstDetDBF.Fields("Talla").Value = vlNumero
        '                oRstDetDBF.Fields("Cantidad").Value = drMultUD.Item("C" & Format(i, "00")) * drMultUD!Multiplica
        '                oRstDetDBF.Fields("CostUnit").Value = drMultUD!CostoUnit
        '                oRstDetDBF.Fields("Importe").Value = drMultUD!Importe
        '                oRstDetDBF.Update()
        '            End If
        '            If drMultUD!Salto = 0 Then
        '                vlNumero += 1
        '            Else
        '                vlNumero += drMultUD!Salto
        '            End If
        '            i += 1
        '        Loop
        '    Next
        '    dsMultUD = Nothing

        'Next

        'dsMultU = Nothing

        'oRstDBF.Close()
        'oRstDetDBF.Close()
        'oConDBF.Close()

    End Sub


    Public Sub TSGC()
        Dim oGenArch As New GenerarArch(oApplicationContext)

        oGenArch.CrearDBF("C:\DPT\AUD\", "TSGCG" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Fecha] DATE, [Hora] TEXT (8), [Suc_Orig] TEXT (2), [Suc_Dst] TEXT (2), [Usuario] TEXT (5), [Cantidad] NUMBER, [Importe] NUMBER")
        oGenArch.CrearDBF("C:\DPT\AUD\", "TSGCD" & Format(Date.Now, "yy"), "[Folio] NUMBER, [Suc_Orig] TEXT (2), [Codigo] TEXT (17), [Talla] NUMBER, [Cantidad] NUMBER, [CostUnit] NUMBER, [Importe] NUMBER")

    End Sub


    Public Sub UPC()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        oGenArch.CrearDBF("C:\DPT\AUD\", "UPC", "[UPC] TEXT (19), [Codigo] TEXT (20), [Talla] NUMBER, [Status] TEXT (1), [Fecha] DATE")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [UPC];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoUPC"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoUPC")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()

            vlCadena = drMultU!CodUPC
            Dim i, count As Integer
            count = vlCadena.Length

            For i = 0 To count
                vlCadena = vlCadena.TrimStart("0")
            Next

            vlCadena.PadLeft(19, " ")

            If vlCadena.Length > 19 Then
                oRstDBF.Fields("UPC").Value = vlCadena.Substring(0, 19)
            Else
                oRstDBF.Fields("UPC").Value = vlCadena 'drMultU!CodUPC
            End If
            vlCadena = drMultU!CodArticulo
            If vlCadena.Length > 17 Then
                oRstDBF.Fields("Codigo").Value = vlCadena.Substring(0, 17)
            Else
                oRstDBF.Fields("Codigo").Value = drMultU!CodArticulo
            End If

            If IsNumeric(drMultU!Numero) Then
                oRstDBF.Fields("Talla").Value = drMultU!Numero
            Else
                oRstDBF.Fields("Talla").Value = 0
            End If

            oRstDBF.Fields("Status").Value = "A"
            oRstDBF.Fields("Fecha").Value = Format(Now.Date, "dd/MM/yyyy")
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


    Public Sub Usuarios()
        Dim oGenArch As New GenerarArch(oApplicationContext)
        Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlCadena As String

        oGenArch.CrearDBF("C:\DPT\AUD\", "USUARIO", "[Codigo] TEXT (5), [Nombre] TEXT (30), [Direc] TEXT (30), [Direc2] TEXT (30), [Tel1] TEXT (15), [Tel2] TEXT (15), [Nota1] TEXT (30), [Nota2] TEXT (30), [Nota3] TEXT (30), [PW] TEXT (10), [Status] TEXT (1)")

        Dim oConDBF As New ADODB.ConnectionClass
        Dim oRstDBF As New ADODB.RecordsetClass

        oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=C:\DPT\AUD\")
        oRstDBF.Open("SELECT * FROM [USUARIO];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        vlComando = "SELECT * FROM CatalogoVendedores"
        dsMultU = oGenArch.DatosATrans(vlComando, "CatalogoVendedores")
        For Each drMultU In dsMultU.Tables(0).Rows
            oRstDBF.AddNew()
            vlCadena = drMultU!CodVendedor
            If vlCadena.Length > 5 Then
                oRstDBF.Fields("Codigo").Value = vlCadena.Substring(0, 5)
            Else
                oRstDBF.Fields("Codigo").Value = drMultU!CodVendedor
            End If
            vlCadena = drMultU!Nombre
            If vlCadena.Length > 30 Then
                oRstDBF.Fields("Nombre").Value = vlCadena.Substring(0, 30)
            Else
                oRstDBF.Fields("Nombre").Value = drMultU!Nombre
            End If
            oRstDBF.Fields("Direc").Value = ""
            oRstDBF.Fields("Direc2").Value = ""
            oRstDBF.Fields("Tel1").Value = ""
            oRstDBF.Fields("Tel2").Value = ""
            oRstDBF.Fields("Nota1").Value = ""
            oRstDBF.Fields("Nota2").Value = ""
            oRstDBF.Fields("Nota3").Value = ""
            oRstDBF.Fields("PW").Value = ""
            oRstDBF.Fields("Status").Value = "A"
            oRstDBF.Update()
        Next
        dsMultU = Nothing

        oRstDBF.Close()
        oConDBF.Close()

    End Sub


#End Region

End Class
