Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.Core

Public Class GenerarArch

#Region "Constructors / Destructors"

    Private oApplicationContext As ApplicationContext


    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

#End Region

    

    Public Sub CrearDBF(ByVal Base As String, ByVal Nombre As String, ByVal Campos As String)
        Dim pconBase As Odbc.OdbcConnection
        Dim pcmdTB As Odbc.OdbcCommand

        pconBase = New Odbc.OdbcConnection
        pcmdTB = New Odbc.OdbcCommand
        pconBase.ConnectionString = "DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & Base
        pconBase.Open()
        pcmdTB.CommandText = "CREATE TABLE [" & Nombre & "] (" & Campos & ");"
        pcmdTB.Connection = pconBase
        pcmdTB.ExecuteNonQuery()
        pconBase.Close()
    End Sub

    Public Function DatosATrans(ByVal strComandSQL As String, ByVal strTabla As String) As DataSet

        Dim sccnnConnection As New SqlConnection(oApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                  GetConnectionString)

        Dim sccmdSelectAll As SqlCommand
        Dim scdaMovCont As SqlDataAdapter
        Dim dsMovCont As DataSet

        sccmdSelectAll = New SqlCommand
        scdaMovCont = New SqlDataAdapter
        dsMovCont = New DataSet

        With sccmdSelectAll

            .Connection = sccnnConnection

            .CommandText = "[DatosATrans]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ComandSQL", System.Data.SqlDbType.Text))

        End With

        scdaMovCont.SelectCommand = sccmdSelectAll

        Try

            sccnnConnection.Open()

            scdaMovCont.SelectCommand.Parameters("@ComandSQL").Value = strComandSQL

            'Fill DataSet
            scdaMovCont.Fill(dsMovCont, strTabla)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("Los registros no pudieron ser leidos debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dsMovCont

    End Function

#Region "Codigo comentado"
    'Public Sub GenArchMOVD(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlOrigen As String, Cadena As String
    '    Dim dsMultUD As DataSet, drMultUD As DataRow
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\MD00" & Format(daFecha, "ddMM") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\MD00" & Format(daFecha, "ddMM") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "MD00" & Format(daFecha, "ddMM"), "[FOLIOCTRL] TEXT (7), [MOVES] TEXT (1), [FECHA] DATETIME, [DESCMOV] TEXT (50), [FOLIO] INTEGER, [STATUS] TEXT (1), [CODIGO] TEXT (17), [NUMERO] INTEGER, [DESCRIPCIO] TEXT (30), [CANTIDAD] INTEGER, [UNIDAD] TEXT (3), [COSTUNIT] INTEGER, [PRECUNIT] INTEGER, [COSTO] INTEGER, [IMPORTE] INTEGER, [ORIGDST] TEXT (6), [SUCURSAL] TEXT (2), [TOTFGRAL] INTEGER, [TOTNC] INTEGER, [COST_NC] INTEGER, [TOTDESC] INTEGER, [USUARIO] TEXT (5), [VTA_DIP] TEXT (1)")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [MD00" & Format(daFecha, "ddMM") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Movimientos.*, CatalogoTipoMovimientos.Descripcion AS DescTM, CatalogoTipoMovimientos.Tipo FROM Movimientos INNER JOIN CatalogoTipoMovimientos ON Movimientos.CodTipoMov=CatalogoTipoMovimientos.CodTipoMov WHERE Convert(Datetime,Convert(Varchar,Movimientos.FechaMov,101),101)='" & Format(daFecha, "dd/MM/yyyy") & "'"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIOCTRL").Value = drMultU!FolioControl
    '        oRstDBF.Fields("MOVES").Value = drMultU!Tipo
    '        oRstDBF.Fields("FECHA").Value = Format(drMultU!FechaMov, "dd/MM/yyyy")
    '        oRstDBF.Fields("DESCMOV").Value = drMultU!DescTM
    '        oRstDBF.Fields("FOLIO").Value = drMultU!Folio
    '        oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
    '        oRstDBF.Fields("NUMERO").Value = drMultU!Numero
    '        Cadena = drMultU!Descripcion
    '        If Cadena.Length > 30 Then
    '            oRstDBF.Fields("DESCRIPCIO").Value = Cadena.Substring(0, 30)
    '        Else
    '            oRstDBF.Fields("DESCRIPCIO").Value = drMultU!Descripcion
    '        End If
    '        oRstDBF.Fields("CANTIDAD").Value = drMultU!Cantidad
    '        oRstDBF.Fields("UNIDAD").Value = drMultU!CodUnidad
    '        oRstDBF.Fields("COSTUNIT").Value = drMultU!CostoUnit
    '        oRstDBF.Fields("PRECUNIT").Value = drMultU!PrecioUnit
    '        oRstDBF.Fields("COSTO").Value = drMultU!CostoTotal
    '        oRstDBF.Fields("IMPORTE").Value = drMultU!Importe - drMultU!Descuento
    '        oRstDBF.Fields("ORIGDST").Value = drMultU!Destino
    '        vlOrigen = drMultU!Origen
    '        oRstDBF.Fields("SUCURSAL").Value = vlOrigen.Substring(1, 2)
    '        oRstDBF.Fields("TOTFGRAL").Value = drMultU!TotFGral
    '        oRstDBF.Fields("TOTNC").Value = drMultU!TotNC
    '        oRstDBF.Fields("COST_NC").Value = drMultU!CostoNC
    '        oRstDBF.Fields("TOTDESC").Value = drMultU!Descuento

    '        oRstDBF.Fields("STATUS").Value = drMultU!StatusMov
    '        Cadena = drMultU!Usuario
    '        If drMultU!CodTipoMov = "201" Then
    '            vlComando = "SELECT Status, CodVendedor FROM Factura WHERE FolioFactura=" & drMultU!Folio
    '            dsMultUD = oGenArch.DatosATrans(vlComando, "Factura")
    '            For Each drMultUD In dsMultUD.Tables(0).Rows
    '                Cadena = drMultUD!CodVendedor
    '                If drMultUD!Status = "CAN" Then
    '                    oRstDBF.Fields("STATUS").Value = "C"
    '                Else
    '                    oRstDBF.Fields("STATUS").Value = "A"
    '                End If
    '            Next
    '        End If
    '        If Cadena.Length > 5 Then
    '            oRstDBF.Fields("USUARIO").Value = Cadena.Substring(0, 5)
    '        Else
    '            oRstDBF.Fields("USUARIO").Value = Cadena
    '        End If

    '        oRstDBF.Fields("VTA_DIP").Value = drMultU!Vta_DIP
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub
    'Public Sub GenArchFTOT(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String, vlFormaPago As Integer
    '    Dim dsMultUD As DataSet, drMultUD As DataRow, vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\FT00" & Format(daFecha, "ddMM") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\FT00" & Format(daFecha, "ddMM") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "FT00" & Format(daFecha, "ddMM"), "[FOLIO] INTEGER, [SUCURSAL] TEXT (2), [FECHA] DATETIME, [HORA] TEXT (8), [VENDEDOR] TEXT (5), [CODCLI] TEXT (6), [IMPORTE] INTEGER, [DESCUENTO] INTEGER, [IVA] INTEGER, [FOL_NCRED] INTEGER, [TOTAL_PZAS] INTEGER, [F_PAGO1] TEXT (1), [PAGO1] INTEGER, [F_PAGO2] TEXT (1), [PAGO2] INTEGER, [TIP_VTA] TEXT (1), [IMPRESA] TEXT (1), [STATUS] TEXT (1), [STATUS2] TEXT (1), [DEVOL_DIN] TEXT (1), [FOL_APART] INTEGER, [DESCUENSIS] INTEGER, [CLADESCTO] TEXT (3), [COMENDESC] TEXT (25), [PRECUNIT] INTEGER, [COSTUNIT] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [FT00" & Format(daFecha, "ddMM") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Factura.FacturaID, Factura.FolioFactura, Factura.CodAlmacen, Factura.Fecha, Min(Movimientos.FechaMov) As Hora, Factura.CodVendedor, Factura.ClienteID, Factura.Total, Factura.DescTotal, Factura.IVA, Sum(Movimientos.Cantidad) As TotalPzas, " & _
    '                "Factura.CodTipoVenta, Factura.Impresa, Factura.StatusRegistro, Factura.ApartadoID, Sum(Movimientos.PrecioUnit) As PrecUnit, Sum(Movimientos.CostoUnit) As CostUnit " & _
    '                "FROM Factura INNER JOIN Movimientos On Factura.FolioFactura=Movimientos.Folio WHERE (Movimientos.CodTipoMov IN(201)) And Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101)='" & daFecha & "' " & _
    '                "GROUP BY Factura.FacturaID, Factura.FolioFactura, Factura.CodAlmacen, Factura.Fecha, Factura.CodVendedor, Factura.ClienteID, Factura.Total, Factura.DescTotal, Factura.IVA, Factura.CodTipoVenta, Factura.Impresa, Factura.StatusRegistro, Factura.ApartadoID " & _
    '                "ORDER BY Factura.FolioFactura"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIO").Value = drMultU!FolioFactura
    '        Cadena = drMultU!CodAlmacen
    '        oRstDBF.Fields("SUCURSAL").Value = Cadena.Substring(1, 2)
    '        oRstDBF.Fields("FECHA").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
    '        oRstDBF.Fields("HORA").Value = Format(drMultU!Hora, "HH:mm:ss")
    '        Cadena = drMultU!CodVendedor
    '        oRstDBF.Fields("VENDEDOR").Value = Cadena.Substring(0, 5)
    '        oRstDBF.Fields("CODCLI").Value = drMultU!ClienteID
    '        oRstDBF.Fields("IMPORTE").Value = drMultU!Total
    '        oRstDBF.Fields("DESCUENTO").Value = drMultU!DescTotal
    '        oRstDBF.Fields("IVA").Value = drMultU!IVA
    '        oRstDBF.Fields("TOTAL_PZAS").Value = drMultU!TotalPzas
    '        oRstDBF.Fields("TIP_VTA").Value = drMultU!CodTipoVenta
    '        If drMultU!Impresa = 0 Then
    '            oRstDBF.Fields("IMPRESA").Value = "N"
    '        Else
    '            oRstDBF.Fields("IMPRESA").Value = "S"
    '        End If
    '        If drMultU!StatusRegistro = 0 Then
    '            oRstDBF.Fields("STATUS").Value = "C"
    '        Else
    '            oRstDBF.Fields("STATUS").Value = "A"
    '        End If
    '        oRstDBF.Fields("STATUS2").Value = "P"
    '        oRstDBF.Fields("DEVOL_DIN").Value = ""
    '        oRstDBF.Fields("PRECUNIT").Value = drMultU!PrecUnit
    '        oRstDBF.Fields("COSTUNIT").Value = drMultU!CostUnit

    '        vlFormaPago = 1
    '        vlComando = "SELECT DPValeID, CodFormasPago, MontoPago FROM FacturasFormasPago WHERE FacturaID=" & drMultU!FacturaID
    '        dsMultUD = oGenArch.DatosATrans(vlComando, "FacturasFormasPago")
    '        For Each drMultUD In dsMultUD.Tables(0).Rows
    '            oRstDBF.Fields("FOL_NCRED").Value = drMultUD!DPValeID
    '            Select Case vlFormaPago
    '                Case 1
    '                    oRstDBF.Fields("F_PAGO1").Value = drMultUD!CodFormasPago
    '                    oRstDBF.Fields("PAGO1").Value = drMultUD!MontoPago
    '                    oRstDBF.Fields("F_PAGO2").Value = ""
    '                    oRstDBF.Fields("PAGO2").Value = 0
    '                Case 2
    '                    oRstDBF.Fields("F_PAGO2").Value = drMultUD!CodFormasPago
    '                    oRstDBF.Fields("PAGO2").Value = drMultUD!MontoPago
    '                Case Else
    '                    Exit For
    '            End Select
    '            vlFormaPago += 1
    '        Next

    '        vlComando = "SELECT CantDescuentoSistema, CodTipoDescuento FROM FacturaCorrida WHERE FacturaID=" & drMultU!FacturaID
    '        dsMultUD = oGenArch.DatosATrans(vlComando, "FacturaCorrida")
    '        For Each drMultUD In dsMultUD.Tables(0).Rows
    '            oRstDBF.Fields("DESCUENSIS").Value = drMultUD!CantDescuentoSistema
    '            oRstDBF.Fields("CLADESCTO").Value = drMultUD!CodTipoDescuento
    '            oRstDBF.Fields("COMENDESC").Value = ""
    '        Next

    '        oRstDBF.Fields("FOL_APART").Value = 0
    '        If drMultU!ApartadoID <> 0 Then
    '            vlComando = "SELECT FolioApartado FROM Apartados WHERE ApartadoID=" & drMultU!ApartadoID
    '            dsMultUD = oGenArch.DatosATrans(vlComando, "Apartados")
    '            For Each drMultUD In dsMultUD.Tables(0).Rows
    '                oRstDBF.Fields("FOL_APART").Value = drMultUD!FolioApartado
    '            Next
    '        End If

    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchTRSG(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\TRSG" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\TRSG" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "TRSG" & Format(daFecha, "MMyy"), "[FOLIO] INTEGER, [FECHA] DATETIME, [HORA] TEXT (8), [SUC_ORIG] TEXT (2), [SUC_DST] TEXT (2), [USUARIO] TEXT (5), [CANTIDAD] INTEGER, [IMPORTE] INTEGER, [GUIA] TEXT (15), [NOTA1] TEXT (60), [NOTA2] TEXT (60), [NOTA3] TEXT (60), [NOTA4] TEXT (60)")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [TRSG" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Traspaso.Folio, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Sum(TraspasoCorrida.Cantidad) As Cantidad, Sum(TraspasoCorrida.Importe) As Importe, Traspaso.Guia, Traspaso.Observaciones FROM Traspaso INNER JOIN TraspasoCorrida On Traspaso.TraspasoID=TraspasoCorrida.TraspasoID " & _
    '                "WHERE Traspaso.Origen='" & oApplicationContext.ApplicationConfiguration.Almacen & "' And Traspaso.Status='TRA' And Convert(Datetime,Convert(Varchar,Traspaso.Fecha,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,Traspaso.Fecha,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' " & _
    '                "GROUP BY Traspaso.Folio, Traspaso.Fecha, Traspaso.Almacen, Traspaso.Origen, Traspaso.Usuario, Traspaso.Guia, Traspaso.Observaciones"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIO").Value = drMultU!Folio
    '        oRstDBF.Fields("FECHA").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
    '        oRstDBF.Fields("HORA").Value = Format(drMultU!Fecha, "HH:mm:ss")
    '        Cadena = drMultU!Almacen
    '        oRstDBF.Fields("SUC_ORIG").Value = Cadena.Substring(1, 2)
    '        Cadena = drMultU!Origen
    '        oRstDBF.Fields("SUC_DST").Value = Cadena.Substring(1, 2)
    '        Cadena = drMultU!Usuario
    '        If Cadena.Length > 5 Then
    '            oRstDBF.Fields("USUARIO").Value = Cadena.Substring(0, 5)
    '        Else
    '            oRstDBF.Fields("USUARIO").Value = Cadena
    '        End If
    '        oRstDBF.Fields("CANTIDAD").Value = drMultU!Cantidad
    '        oRstDBF.Fields("IMPORTE").Value = drMultU!Importe
    '        oRstDBF.Fields("GUIA").Value = drMultU!Guia
    '        oRstDBF.Fields("NOTA1").Value = ""
    '        oRstDBF.Fields("NOTA2").Value = ""
    '        oRstDBF.Fields("NOTA3").Value = ""
    '        oRstDBF.Fields("NOTA4").Value = ""
    '        Cadena = drMultU!Observaciones
    '        Select Case Cadena.Length
    '            Case Is <= 60
    '                oRstDBF.Fields("NOTA1").Value = Cadena
    '            Case Is > 60
    '                oRstDBF.Fields("NOTA1").Value = Cadena.Substring(0, 60)
    '                oRstDBF.Fields("NOTA2").Value = Cadena.Substring(61, 60)
    '            Case Is > 120
    '                oRstDBF.Fields("NOTA3").Value = Cadena.Substring(122, 60)
    '            Case Is > 180
    '                oRstDBF.Fields("NOTA4").Value = Cadena.Substring(183, 60)
    '        End Select
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchAJGR(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim dsMultUD As DataSet, drMultUD As DataRow, vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\AJGR" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\AJGR" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "AJGR" & Format(daFecha, "MMyy"), "[FOLIO] INTEGER, [FECHA] DATETIME, [CODIGO1] TEXT (17), [TALLA1] INTEGER, [CANTIDAD1] INTEGER, [COSTO1] INTEGER, [PRECIO1] INTEGER, [COSTUNIT1] INTEGER, [PRECUNIT1] INTEGER, [CODIGO2] TEXT (17), [TALLA2] INTEGER, [CANTIDAD2] INTEGER, [COSTO2] INTEGER, [PRECIO2] INTEGER, [COSTUNIT2] INTEGER, [PRECUNIT2] INTEGER, [TCANT1] INTEGER, [TCOST1] INTEGER, [TCANT2] INTEGER, [TCOST2] INTEGER, [NOTA1] TEXT (60), [NOTA2] TEXT (60), [NOTA3] TEXT (60), [NOTA4] TEXT (60)")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [AJGR" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT FolioAjuste, FechaAjuste, CodAlmacen, TotalCodigos, Observaciones, AE_CostoTotal, AS_CostoTotal FROM AjusteGeneral " & _
    '                "WHERE Convert(Datetime,Convert(Varchar,FechaAjuste,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,FechaAjuste,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' And StatusRegistro=1"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows

    '        vlComando = "SELECT AE_Codigo, AE_Talla, AE_Cantidad, AE_Costo, AS_Codigo, AS_Talla, AS_Cantidad, AS_Costo FROM AjusteGeneralDetalle " & _
    '                    "WHERE FolioAjuste=" & drMultU!FolioAjuste & " And CodAlmacen='" & drMultU!CodAlmacen & "'"
    '        dsMultUD = oGenArch.DatosATrans(vlComando, "Movimientos")
    '        For Each drMultUD In dsMultUD.Tables(0).Rows
    '            oRstDBF.AddNew()
    '            oRstDBF.Fields("FOLIO").Value = drMultU!FolioAjuste
    '            oRstDBF.Fields("FECHA").Value = Format(drMultU!FechaAjuste, "dd/MM/yyyy")
    '            oRstDBF.Fields("CODIGO1").Value = drMultUD!AE_Codigo
    '            oRstDBF.Fields("TALLA1").Value = drMultUD!AE_Talla
    '            oRstDBF.Fields("CANTIDAD1").Value = drMultUD!AE_Cantidad
    '            oRstDBF.Fields("COSTO1").Value = drMultUD!AE_Costo * drMultUD!AE_Cantidad
    '            oRstDBF.Fields("PRECIO1").Value = 0
    '            oRstDBF.Fields("COSTUNIT1").Value = drMultUD!AE_Costo
    '            oRstDBF.Fields("PRECUNIT1").Value = 0
    '            oRstDBF.Fields("CODIGO2").Value = drMultUD!AS_Codigo
    '            oRstDBF.Fields("TALLA2").Value = drMultUD!AS_Talla
    '            oRstDBF.Fields("CANTIDAD2").Value = drMultUD!AS_Cantidad
    '            oRstDBF.Fields("COSTO2").Value = drMultUD!AS_Costo * drMultUD!AS_Cantidad
    '            oRstDBF.Fields("PRECIO2").Value = 0
    '            oRstDBF.Fields("COSTUNIT2").Value = drMultUD!AS_Costo
    '            oRstDBF.Fields("PRECUNIT2").Value = 0
    '            oRstDBF.Fields("TCANT1").Value = 0
    '            oRstDBF.Fields("TCOST1").Value = 0
    '            oRstDBF.Fields("TCANT2").Value = 0
    '            oRstDBF.Fields("TCOST2").Value = 0
    '            oRstDBF.Fields("NOTA1").Value = ""
    '            oRstDBF.Fields("NOTA2").Value = ""
    '            oRstDBF.Fields("NOTA3").Value = ""
    '            oRstDBF.Fields("NOTA4").Value = ""
    '            oRstDBF.Update()
    '        Next
    '        dsMultUD = Nothing

    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("TCANT1").Value = drMultU!TotalCodigos
    '        oRstDBF.Fields("TCOST1").Value = drMultU!AE_CostoTotal
    '        oRstDBF.Fields("TCANT2").Value = drMultU!TotalCodigos
    '        oRstDBF.Fields("TCOST2").Value = drMultU!AS_CostoTotal
    '        Cadena = drMultU!Observaciones
    '        Select Case Cadena.Length
    '            Case Is <= 60
    '                oRstDBF.Fields("NOTA1").Value = Cadena
    '                oRstDBF.Fields("NOTA2").Value = ""
    '                oRstDBF.Fields("NOTA3").Value = ""
    '                oRstDBF.Fields("NOTA4").Value = ""
    '            Case Is > 60
    '                oRstDBF.Fields("NOTA1").Value = Cadena.Substring(0, 60)
    '                If Cadena.Length > 120 Then
    '                    oRstDBF.Fields("NOTA2").Value = Cadena.Substring(60, 60)
    '                Else
    '                    oRstDBF.Fields("NOTA2").Value = Cadena.Substring(60, Cadena.Length - 60)
    '                End If
    '                oRstDBF.Fields("NOTA3").Value = ""
    '                oRstDBF.Fields("NOTA4").Value = ""
    '            Case Is > 120
    '                If Cadena.Length > 180 Then
    '                    oRstDBF.Fields("NOTA3").Value = Cadena.Substring(120, 60)
    '                Else
    '                    oRstDBF.Fields("NOTA3").Value = Cadena.Substring(120, Cadena.Length - 120)
    '                End If
    '            Case Is > 180
    '                If Cadena.Length > 180 Then
    '                    oRstDBF.Fields("NOTA4").Value = Cadena.Substring(180, 60)
    '                Else
    '                    oRstDBF.Fields("NOTA4").Value = Cadena.Substring(180, Cadena.Length - 180)
    '                End If
    '        End Select
    '        oRstDBF.Update()

    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchDSOT(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String, vlPrecReal As Double, vlPrecPub As Double, vlPrecFinal As Double, vlImpOtor As Double

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\DSOT" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\DSOT" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "DSOT" & Format(daFecha, "MMyy"), "[FOLIO] INTEGER, [FECHA] DATETIME, [CODIGO] TEXT (17), [PREC_REAL] INTEGER, [DESC_SIST] INTEGER, [IMP_SIST] INTEGER, [PREC_PUB] INTEGER, [DESC_OTOR] INTEGER, [IMP_OTOR] INTEGER, [PREC_FINAL] INTEGER, [COSTO] INTEGER, [UTILIDAD] INTEGER, [PLAYER] TEXT (15)")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [DSOT" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Factura.FolioFactura, Factura.Fecha, Factura.Usuario, FacturaCorrida.CodArticulo, FacturaCorrida.Cantidad, FacturaCorrida.CostoUnit, FacturaCorrida.Total, FacturaCorrida.PrecioOferta, FacturaCorrida.Descuento, FacturaCorrida.DescuentoSistema, FacturaCorrida.CantDescuentoSistema FROM Factura INNER JOIN FacturaCorrida ON Factura.FacturaID=FacturaCorrida.FacturaID " & _
    '                "WHERE Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' And Factura.StatusRegistro=1 And (FacturaCorrida.Descuento<>0 Or FacturaCorrida.DescuentoSistema<>0)"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIO").Value = drMultU!FolioFactura
    '        oRstDBF.Fields("FECHA").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
    '        oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo

    '        vlPrecReal = drMultU!Total + drMultU!CantDescuentoSistema
    '        oRstDBF.Fields("PREC_REAL").Value = vlPrecReal
    '        oRstDBF.Fields("DESC_SIST").Value = drMultU!DescuentoSistema
    '        oRstDBF.Fields("IMP_SIST").Value = drMultU!CantDescuentoSistema

    '        vlPrecPub = drMultU!Total
    '        oRstDBF.Fields("PREC_PUB").Value = vlPrecPub

    '        oRstDBF.Fields("DESC_OTOR").Value = drMultU!Descuento
    '        vlImpOtor = vlPrecPub * (drMultU!Descuento / 100)
    '        oRstDBF.Fields("IMP_OTOR").Value = vlImpOtor

    '        vlPrecFinal = vlPrecPub - vlImpOtor
    '        oRstDBF.Fields("PREC_FINAL").Value = vlPrecFinal
    '        oRstDBF.Fields("COSTO").Value = drMultU!CostoUnit * drMultU!Cantidad

    '        oRstDBF.Fields("UTILIDAD").Value = vlPrecFinal - (drMultU!CostoUnit * drMultU!Cantidad)
    '        oRstDBF.Fields("PLAYER").Value = drMultU!Usuario
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchAUIN(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\AUIN" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\AUIN" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "AUIN" & Format(daFecha, "MMyy"), "[SUCURSAL] TEXT (2), [VENTAS] INTEGER, [PROMO] INTEGER, [DESC_AD] INTEGER, [VTA_BRUTA] INTEGER, [COSTO] INTEGER, [UTILIDAD] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [AUIN" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Factura.CodAlmacen, Sum(FacturaCorrida.Total+FacturaCorrida.CantDescuentoSistema) As Ventas, Sum(FacturaCorrida.CantDescuentoSistema) As Promo, Sum(FacturaCorrida.Total*(FacturaCorrida.Descuento/100)) As Desc_Ad, Sum(FacturaCorrida.Cantidad*FacturaCorrida.CostoUnit) As Costo FROM Factura INNER JOIN FacturaCorrida ON Factura.FacturaID=FacturaCorrida.FacturaID " & _
    '                "WHERE Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,Factura.Fecha,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' And Factura.StatusRegistro=1 " & _
    '                "GROUP BY Factura.CodAlmacen"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        Cadena = drMultU!CodAlmacen
    '        oRstDBF.Fields("SUCURSAL").Value = Cadena.Substring(1, 2)
    '        oRstDBF.Fields("VENTAS").Value = drMultU!Ventas
    '        oRstDBF.Fields("PROMO").Value = drMultU!Promo
    '        oRstDBF.Fields("DESC_AD").Value = drMultU!Desc_Ad
    '        oRstDBF.Fields("VTA_BRUTA").Value = drMultU!Ventas - (drMultU!Promo + drMultU!Desc_Ad)
    '        oRstDBF.Fields("COSTO").Value = drMultU!Costo
    '        oRstDBF.Fields("UTILIDAD").Value = (drMultU!Ventas - (drMultU!Promo + drMultU!Desc_Ad)) - drMultU!Costo
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchTRAN(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlPzas As Double, vlCost As Double
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\TRAN" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\TRAN" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "TRAN" & Format(daFecha, "MMyy"), "[FOLIO] INTEGER, [FECHA] DATETIME, [PZAS] INTEGER, [SALDO_PZAS] INTEGER, [COSTO] INTEGER, [SALDO_COST] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [TRAN" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlPzas = 0
    '    vlCost = 0
    '    vlComando = "SELECT Traspaso.Folio, Traspaso.Fecha, Sum(TraspasoCorrida.Cantidad) As Piezas, Sum(TraspasoCorrida.CostoUnit*TraspasoCorrida.Cantidad) As Costo FROM Traspaso INNER JOIN TraspasoCorrida ON Traspaso.TraspasoID=TraspasoCorrida.TraspasoID " & _
    '                "WHERE Convert(Datetime,Convert(Varchar,Traspaso.Fecha,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,Traspaso.Fecha,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' And Referencia Is Null " & _
    '                "GROUP BY Traspaso.Folio, Traspaso.Fecha"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows

    '        vlPzas = vlPzas + drMultU!Piezas
    '        vlCost = vlCost + drMultU!Costo

    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIO").Value = drMultU!Folio
    '        oRstDBF.Fields("FECHA").Value = Format(drMultU!Fecha, "dd/MM/yyyy")
    '        oRstDBF.Fields("PZAS").Value = drMultU!Piezas
    '        oRstDBF.Fields("SALDO_PZAS").Value = vlPzas
    '        oRstDBF.Fields("COSTO").Value = drMultU!Costo
    '        oRstDBF.Fields("SALDO_COST").Value = vlCost
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchINCO(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, vlFecha As Date, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\INCO" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\INCO" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "INCO" & Format(daFecha, "MMyy"), "[SUCURSAL] TEXT (2), [CODIGO] TEXT (17), [TALLA] INTEGER, [EXISTENCIA] INTEGER, [RESULTADO] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [INCO" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlFecha = daFecha
    '    vlComando = "SELECT CodAlmacen, CodArticulo, Numero, Total, (Saldo_" & vlFecha.Month & "+Entro_" & vlFecha.Month & "-Salio_" & vlFecha.Month & ") As Resultado FROM Existencias " & _
    '                "WHERE Total<>(Saldo_" & vlFecha.Month & "+Entro_" & vlFecha.Month & "-Salio_" & vlFecha.Month & ")"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        Cadena = drMultU!CodAlmacen
    '        oRstDBF.Fields("SUCURSAL").Value = Cadena.Substring(1, 2)
    '        oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
    '        oRstDBF.Fields("TALLA").Value = drMultU!Numero
    '        oRstDBF.Fields("EXISTENCIA").Value = drMultU!Total
    '        oRstDBF.Fields("RESULTADO").Value = drMultU!Resultado
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchHIST(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\HIST" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\HIST" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "HIST" & Format(daFecha, "MMyy"), "[SUCURSAL] TEXT (2), [CODIGO] TEXT (17), [HISTORICO] INTEGER, [INVENTARIO] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [HIST" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Existencias.CodAlmacen, Existencias.CodArticulo, Sum(Existencias.Saldo_1) As Inicial, Sum(Existencias.Total) As Total, Sum(Entradas-Salidas) As Historico FROM Existencias INNER JOIN EntradasSalidas On Existencias.CodArticulo=EntradasSalidas.CodArticulo And Existencias.CodAlmacen=EntradasSalidas.CodAlmacen " & _
    '                "GROUP BY Existencias.CodAlmacen, Existencias.CodArticulo"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Movimientos")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        If drMultU!Total <> drMultU!Inicial + drMultU!Historico Then
    '            oRstDBF.AddNew()
    '            Cadena = drMultU!CodAlmacen
    '            oRstDBF.Fields("SUCURSAL").Value = Cadena.Substring(1, 2)
    '            oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
    '            oRstDBF.Fields("HISTORICO").Value = drMultU!Inicial + drMultU!Historico
    '            oRstDBF.Fields("INVENTARIO").Value = drMultU!Total
    '            oRstDBF.Update()
    '        End If
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchREAP(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String
    '    Dim vlNomArchG As String, vlNomArchT As String

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\REAP" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\REAP" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "REAP" & Format(daFecha, "MMyy"), "[FOLIO] INTEGER, [DESCRIPCIO] TEXT (30), [SUCURSAL] TEXT (2), [CANTIDAD] INTEGER, [CODIGO] TEXT (17), [TALLA] INTEGER, [PRECUNIT] INTEGER, [IMPORTE] INTEGER, [FUM] DATETIME, [DESCU] INTEGER, [CANTDESC] INTEGER, [VENDEDOR] TEXT (5), [COD_CLIEN] TEXT (10), [ABONOS] INTEGER, [SALDO] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [REAP" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlComando = "SELECT Apartados.FolioApartado, CatalogoArticulos.Descripcion, Apartados.CodVendedor, Apartados.ClienteID, Apartados.Importe, Apartados.Saldo, ApartadosDetalle.CodArticulo, ApartadosDetalle.Numero, ApartadosDetalle.Cantidad, ApartadosDetalle.Precio, ApartadosDetalle.Importe, ApartadosDetalle.Fecha, ApartadosDetalle.Descuento FROM Apartados INNER JOIN ApartadosDetalle ON Apartados.ApartadoID=ApartadosDetalle.ApartadoID INNER JOIN CatalogoArticulos ON ApartadosDetalle.CodArticulo=CatalogoArticulos.CodArticulo " & _
    '                "WHERE Convert(Datetime,Convert(Varchar,Apartados.Fecha,101),101)>='01/" & Format(daFecha, "MM") & "/" & Format(daFecha, "yyyy") & "' And Convert(Datetime,Convert(Varchar,Apartados.Fecha,101),101)<='" & Format(daFecha, "dd/MM/yyyy") & "' And Apartados.Entregada='N'"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Apartados")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("FOLIO").Value = drMultU!FolioApartado
    '        Cadena = drMultU!Descripcion
    '        If Cadena.Length > 30 Then
    '            oRstDBF.Fields("DESCRIPCIO").Value = Cadena.Substring(0, 30)
    '        Else
    '            oRstDBF.Fields("DESCRIPCIO").Value = Cadena
    '        End If
    '        oRstDBF.Fields("SUCURSAL").Value = oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2)
    '        oRstDBF.Fields("CANTIDAD").Value = drMultU!Cantidad
    '        oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
    '        oRstDBF.Fields("TALLA").Value = drMultU!Numero
    '        oRstDBF.Fields("PRECUNIT").Value = drMultU!Precio
    '        oRstDBF.Fields("IMPORTE").Value = drMultU!Importe
    '        oRstDBF.Fields("FUM").Value = drMultU!Fecha
    '        oRstDBF.Fields("DESCU").Value = drMultU!Descuento
    '        oRstDBF.Fields("CANTDESC").Value = (drMultU!Precio * drMultU!Cantidad) * (drMultU!Descuento / 100)
    '        oRstDBF.Fields("VENDEDOR").Value = drMultU!CodVendedor
    '        oRstDBF.Fields("COD_CLIEN").Value = drMultU!ClienteID
    '        oRstDBF.Fields("ABONOS").Value = drMultU!Importe - drMultU!Saldo
    '        oRstDBF.Fields("SALDO").Value = drMultU!Saldo
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Private Sub GenArchCSIN(ByVal daFecha As Date)
    '    Dim oGenArch As New GenerarArch(oApplicationContext)
    '    Dim dsMultU As DataSet, drMultU As DataRow, vlComando As String, Cadena As String, vlTotPzas As Double, vlPorc As Double, vlAcumPorc As Double
    '    Dim vlNomArchG As String, vlNomArchT As String, vlFecha As Date

    '    vlNomArchG = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\CSIN" & Format(daFecha, "MMyy") & ".DBF"
    '    vlNomArchT = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida & "\CSIN" & Format(daFecha, "MMyy") & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0"

    '    If Dir(vlNomArchG) <> "" Then
    '        Kill(vlNomArchG)
    '    End If
    '    If Dir(vlNomArchT) <> "" Then
    '        Kill(vlNomArchT)
    '    End If

    '    oGenArch.CrearDBF(oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida, "CSIN" & Format(daFecha, "MMyy"), "[CODIGO] TEXT (17), [DESCRIPCIO] TEXT (25), [IMP_TOT] INTEGER, [DESCU] INTEGER, [CANTIDAD] INTEGER, [IMPORTE] INTEGER, [CANT_NC] INTEGER, [IMPORTE_NC] INTEGER, [COSTO] INTEGER, [PORCEN] INTEGER, [ACUMULA] INTEGER, [PORCEN2] INTEGER")

    '    Dim oConDBF As New ADODB.ConnectionClass
    '    Dim oRstDBF As New ADODB.RecordsetClass

    '    oConDBF.Open("DRIVER={Microsoft dBASE Driver (*.dbf)};DBQ=" & oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida)
    '    oRstDBF.Open("SELECT * FROM [CSIN" & Format(daFecha, "MMyy") & "];", oConDBF, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '    vlFecha = daFecha
    '    vlComando = "SELECT Sum(Existencias.Saldo_" & vlFecha.Month & "+Existencias.Entro_" & vlFecha.Month & "-Existencias.Salio_" & vlFecha.Month & ") As Cantidad FROM Existencias"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Existencias")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        vlTotPzas = drMultU!Cantidad
    '    Next
    '    dsMultU = Nothing

    '    vlAcumPorc = 0

    '    vlComando = "SELECT Existencias.CodArticulo, CatalogoArticulos.Descripcion, Sum(Existencias.Saldo_" & vlFecha.Month & "+Existencias.Entro_" & vlFecha.Month & "-Existencias.Salio_" & vlFecha.Month & ") As Cantidad, Existencias.Costo FROM Existencias INNER JOIN CatalogoArticulos ON Existencias.CodArticulo=CatalogoArticulos.CodArticulo " & _
    '                "WHERE (Existencias.Saldo_" & vlFecha.Month & "+Existencias.Entro_" & vlFecha.Month & "-Existencias.Salio_" & vlFecha.Month & ")<>0 GROUP BY Existencias.CodArticulo, CatalogoArticulos.Descripcion, Existencias.Costo"
    '    dsMultU = oGenArch.DatosATrans(vlComando, "Existencias")
    '    For Each drMultU In dsMultU.Tables(0).Rows
    '        oRstDBF.AddNew()
    '        oRstDBF.Fields("CODIGO").Value = drMultU!CodArticulo
    '        Cadena = drMultU!Descripcion
    '        If Cadena.Length > 25 Then
    '            oRstDBF.Fields("DESCRIPCIO").Value = Cadena.Substring(0, 25)
    '        Else
    '            oRstDBF.Fields("DESCRIPCIO").Value = Cadena
    '        End If
    '        oRstDBF.Fields("CANTIDAD").Value = drMultU!Cantidad
    '        oRstDBF.Fields("IMPORTE").Value = drMultU!Cantidad * drMultU!Costo
    '        vlPorc = (drMultU!Cantidad * 100) / vlTotPzas
    '        oRstDBF.Fields("PORCEN").Value = vlPorc
    '        vlAcumPorc = vlAcumPorc + vlPorc
    '        oRstDBF.Fields("ACUMULA").Value = vlAcumPorc
    '        oRstDBF.Update()
    '    Next
    '    dsMultU = Nothing
    '    oRstDBF.Close()
    '    oConDBF.Close()

    '    Rename(vlNomArchG, vlNomArchT)

    'End Sub

    'Public Sub fGenerarDBF(ByVal daFecha As Date)
    '    Dim icDBF As RepAjustesESEng.cTransDBF
    '    Dim psTabla As String
    '    Dim psBase As String
    '    Dim psOrig As String
    '    Dim psAJEN As String
    '    Dim psAJSA As String
    '    Dim psANCO As String
    '    Dim psANIN As String
    '    Dim psANSU As String
    '    Dim psAPAR As String
    '    Dim psEXNE As String
    '    Dim psREDE As String
    '    Dim psRETI As String
    '    Dim psTRSA As String
    '    Dim psAlmacen As String
    '    Dim psFecha As Date

    '    psOrig = "Driver={SQL Server};Server=" & oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.Server & ";DataBase=" & oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.Database & ";User ID=" & oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.User & ";Password=" & oApplicationContext.ApplicationConfiguration.DataStorageConfiguration.Password & ";"
    '    psBase = oApplicationContext.ApplicationConfiguration.RutaTraspasoSalida
    '    psAlmacen = oApplicationContext.ApplicationConfiguration.Almacen
    '    psFecha = daFecha
    '    If Dir(psBase & "\????" & Format(daFecha, "MMyy") & ".*") <> "" Then
    '        Kill(psBase & "\????" & Format(daFecha, "MMyy") & ".*")
    '    End If
    '    icDBF = New RepAjustesESEng.cTransDBF
    '    With icDBF
    '        psAJEN = .CrearAJEN(psBase, psFecha.Year, psFecha.Month)
    '        psAJSA = .CrearAJSA(psBase, psFecha.Year, psFecha.Month)
    '        psANCO = .CrearANCO(psBase, psFecha.Year, psFecha.Month)
    '        psANIN = .CrearANIN(psBase, psFecha.Year, psFecha.Month)
    '        psANSU = .CrearANSU(psBase, psFecha.Year, psFecha.Month)
    '        psAPAR = .CrearAPAR(psBase, psFecha.Year, psFecha.Month)
    '        psEXNE = .CrearEXNE(psBase, psFecha.Year, psFecha.Month)
    '        psREDE = .CrearREDE(psBase, psFecha.Year, psFecha.Month)
    '        psRETI = .CrearRETI(psBase, psFecha.Year, psFecha.Month)
    '        psTRSA = .CrearTRSA(psBase, psFecha.Year, psFecha.Month)
    '        .TransAJEN(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psAJEN)
    '        .TransAJSA(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psAJSA)
    '        .TransANCO(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psANCO)
    '        .TransANIN(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psANIN, oApplicationContext.ApplicationConfiguration.IVA)
    '        .TransANSU(psOrig, psAlmacen, psBase, psANSU)
    '        .TransAPAR(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psAPAR)
    '        .TransEXNE(psOrig, psAlmacen, psBase, psEXNE)
    '        .TransREDE(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psREDE)
    '        .TransRETI(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psRETI)
    '        .TransTRSA(psOrig, psAlmacen, psFecha.Year, psFecha.Month, psBase, psTRSA)
    '    End With
    '    Rename(psBase & "\" & psAJEN & ".DBF", psBase & "\" & psAJEN & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psAJSA & ".DBF", psBase & "\" & psAJSA & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psANCO & ".DBF", psBase & "\" & psANCO & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psANIN & ".DBF", psBase & "\" & psANIN & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psANSU & ".DBF", psBase & "\" & psANSU & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psAPAR & ".DBF", psBase & "\" & psAPAR & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psEXNE & ".DBF", psBase & "\" & psEXNE & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psREDE & ".DBF", psBase & "\" & psREDE & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psRETI & ".DBF", psBase & "\" & psRETI & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")
    '    Rename(psBase & "\" & psTRSA & ".DBF", psBase & "\" & psTRSA & "." & oApplicationContext.ApplicationConfiguration.Almacen.Substring(1, 2) & "0")

    '    GenArchTRSG(daFecha)
    '    GenArchAJGR(daFecha)
    '    GenArchDSOT(daFecha)
    '    GenArchAUIN(daFecha)
    '    GenArchTRAN(daFecha)
    '    GenArchINCO(daFecha)
    '    GenArchHIST(daFecha)
    '    GenArchREAP(daFecha)
    '    GenArchCSIN(daFecha)

    'End Sub
#End Region

End Class
