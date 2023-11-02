Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralNuevo
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports System.Globalization


Friend Class ProcesoSAPProxy

    Private oParent As ProcesoSAPManager
    Public ConfigCierreFI As ConfigSaveArchivos.SaveConfigArchivos

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As ProcesoSAPManager)

        oParent = Parent

    End Sub

#End Region

#Region "Vendedores"

    Friend Function Read_Vendedores() As DataTable


        Dim dtVendedores As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            '--------------------------------------------------------------------------------
            ' JNAVA (12.05.2016): Se aumenta el tiempo de Espera de SAP (TimeOut)
            '--------------------------------------------------------------------------------
            R3.HttpTimeout = oParent.SAPApplicationConfig.Timeout
            '--------------------------------------------------------------------------------

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD03_EXTRACCIONVENDEDOR ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD03_EXTRACCIONVENDEDOR")

                '-------------------------------------------------------------------------------------------
                ' JNAVA (07.01.2015): Se quito para Retail
                '-------------------------------------------------------------------------------------------
                '                If Not oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                'Cambio_053:
                '                    func.Exports("PVKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                '                Else
                '                    GoTo Cambio_053
                '                    'func.Exports("PVKBUR").ParamValue = "C053"
                '                End If

                func.Execute()
                R3.Close()

                dtVendedores = func.Tables("VENDEDORES").ToADOTable

                Return dtVendedores

            End If



        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        'Try

        '    Dim objR3 As New SAPFunctionsOCX.SAPFunctions
        '    Dim objFunc As SAPFunctionsOCX.Function
        '    Dim objPar1 As SAPFunctionsOCX.Parameter 'Parametro Oficina de Ventas
        '    Dim objErr As Object
        '    Dim objRes As Object
        '    Dim bResultado As Boolean

        '    With objR3.Connection
        '        .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
        '        .GroupName = oParent.SAPApplicationConfig.GroupName
        '        .System = oParent.SAPApplicationConfig.System
        '        .Client = oParent.SAPApplicationConfig.Client
        '        .User = oParent.SAPApplicationConfig.User
        '        .Password = oParent.SAPApplicationConfig.Password
        '        .Language = oParent.SAPApplicationConfig.Language
        '    End With

        '    If objR3.Connection.logon(0, True) <> True Then
        '        MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
        '        Exit Function
        '    End If

        '    objFunc = objR3.Add("ZBAPISD03_EXTRACCIONVENDEDOR")
        '    objPar1 = objFunc.Exports("PVKBUR")
        '    objErr = objFunc.Imports("RETURN")
        '    objRes = objFunc.Tables("VENDEDORES")

        '    If Not oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
        '        objPar1.Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
        '    Else
        '        objPar1.Value = "C053"
        '    End If


        '    bResultado = objFunc.Call

        '    If Not bResultado Then
        '        MsgBox(objFunc.Exception)
        '    End If

        '    objR3.Connection.LogOff()

        '    Dim irow As Integer = 0
        '    Dim iField As Integer
        '    Dim vField As String


        '    Dim dtVendedores As New DataTable("Vendedores")

        '    For iField = 1 To objRes.ColumnCount
        '        dtVendedores.Columns.Add(objRes.ColumnName(iField), objRes.ColumnName(1).GetType)
        '    Next

        '    For irow = 1 To objRes.ROWCOUNT

        '        Dim orow As DataRow = dtVendedores.NewRow

        '        For iField = 1 To objRes.ColumnCount

        '            vField = oRows(iField) 'Mid(oRows(iField), iStart, iLength)
        '            orow(objRes.ColumnName(iField)) = vField

        '        Next

        '        dtVendedores.Rows.Add(orow)

        '        dtVendedores.AcceptChanges()

        '    Next

        '    Return dtVendedores

        'Catch ex As Exception

        '    Throw New ApplicationException(ex.Message, ex)

        'End Try

    End Function

    Friend Function ZBAPI_VALIDAVENDEDOR(ByVal CodVendedor As String) As String


        Dim strRes As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)



            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDAVENDEDOR         ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDAVENDEDOR")

                func.Exports("I_VKGRP").ParamValue = CodVendedor.Trim
                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen

                func.Execute()
                R3.Close()

                strRes = func.Imports("E_RESULT").ParamValue

                Return strRes

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Articulos"

    Friend Function Read_ArticulosSAPSD01(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable

        Dim dtArticulos As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            '--------------------------------------------------------------------------------
            ' JNAVA (12.05.2016): Se aumenta el tiempo de Espera de SAP (TimeOut)
            '--------------------------------------------------------------------------------
            R3.HttpTimeout = oParent.SAPApplicationConfig.Timeout
            '--------------------------------------------------------------------------------

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD01_EXTDATMAT ******
                '*****************************************************
                ' Create a function object
                'Dim strnombrebapi As String = String.Empty
                'If oParent.SAPApplicationConfig.TdaNueva Then
                '    strnombrebapi = "ZBAPISD01_TDANUEVA"
                'Else
                '    strnombrebapi = "ZBAPISD01_EXTDATMAT"
                'End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX002_ARTICULOS")

                func.Exports("CENTRO").ParamValue = oParent.Read_Centros()
                'func.Exports("ERSDA_1").ParamValue = fechaini.ToShortDateString
                'func.Exports("ERSDA_2").ParamValue = fechafin.ToShortDateString

                '----------------------------------------------------
                'JNAVA (16.12.2014): Correccion descargas normales
                '----------------------------------------------------
                If oParent.SAPApplicationConfig.DercargaManual Or oParent.SAPApplicationConfig.TdaNueva Then
                    oParent.SAPApplicationConfig.TdaNueva = True
                Else
                    oParent.SAPApplicationConfig.TdaNueva = False
                End If


                If oParent.SAPApplicationConfig.TdaNueva = False Then
                    func.Exports("DIAS").ParamValue = "10"
                    func.Exports("ACTUALIZA").ParamValue = "X"
                Else
                    func.Exports("CARGA").ParamValue = "X"
                End If
                'If strnombrebapi = "ZBAPISD01_EXTDATMAT" Then
                '    func.Exports("I_DIAS").ParamValue = "10"
                'End If

                func.Execute()
                R3.Close()

                dtArticulos = func.Tables("TT_MARA").ToADOTable

                Return dtArticulos

            End If



        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAEXISTENCIAS() As DataTable

        Dim dtExistencias As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            '--------------------------------------------------------------------------------
            ' JNAVA (12.05.2016): Se aumenta el tiempo de Espera de SAP (TimeOut)
            '--------------------------------------------------------------------------------
            R3.HttpTimeout = oParent.SAPApplicationConfig.Timeout
            '--------------------------------------------------------------------------------

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CARGAEXISTENCIAS ******
                '*****************************************************
                ' Create a function object

                'Dim strnombrebapi As String = String.Empty
                'If oParent.SAPApplicationConfig.TdaNueva Then
                '    strnombrebapi = "ZBAPI_CARGAEXISTENCIASTDANUEVA"
                'Else
                '    strnombrebapi = "ZBAPI_CARGAEXISTENCIAS"
                'End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX001_EXISTENCIAS")


                func.Exports("CENTRO").ParamValue = oParent.Read_Centros()
                'If oParent.SAPApplicationConfig.TdaNueva Then
                func.Exports("CARGA").ParamValue = "X"
                'Else
                '    func.Exports("ACTUALIZA").ParamValue = "X"
                'End If


                func.Execute()
                R3.Close()

                dtExistencias = func.Tables("ZEXISTENCIA").ToADOTable

                Return dtExistencias

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAEXISTENCIASXCODIGO(ByVal strMaterial As String) As DataTable

        Dim dtExistencias As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CARGAEXISTENCIAS_XCODIGO ****
                '*****************************************************
                ' Create a function object

                'Dim strnombrebapi As String = String.Empty
                'If oParent.SAPApplicationConfig.TdaNueva Then
                'strnombrebapi = "ZBAPI_CARGAEXISTENCIAS_XCODIGO"
                'Else
                '    strnombrebapi = "ZBAPI_CARGAEXISTENCIAS"
                'End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX001_EXISTENCIAS")


                func.Exports("CENTRO").ParamValue = oParent.Read_Centros()
                func.Exports("MATERIAL").ParamValue = strMaterial.Trim.ToUpper.PadLeft(18, "0")
                func.Exports("CODIGO").ParamValue = "X"

                'Dim dtZMateriales As New ERPConnect.RFCTable("ZTMATERIALES")
                'Dim oNewCol As New ERPConnect.RFCTableColumn("MATNR")

                'With oNewCol
                '    oNewCol.Type = ERPConnect.RFCTYPE.CHAR
                '    oNewCol.Length = 18
                'End With
                'dtZMateriales.Columns.Add(oNewCol)

                'Dim oZRow As ERPConnect.RFCStructure

                'For Each oRow As DataRow In dtMateriales.Rows
                '    oZRow = dtZMateriales.AddRow
                '    oZRow.Item("MATNR") = oRow!Codigo
                '    dtZMateriales.Rows.Add(oZRow)
                'Next

                'func.Tables.Add(dtZMateriales)

                func.Execute()

                R3.Close()

                dtExistencias = func.Tables("ZEXISTENCIA").ToADOTable


                Return dtExistencias

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZRFC_CARGAARTICULO_XCODIGO(ByVal strMaterial As String) As DataTable

        Dim dtCodigo As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_CARGAARTICULO_XCODIGO     ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX002_ARTICULOS")


                func.Exports("CENTRO").ParamValue = oParent.Read_Centros()
                func.Exports("MATERIAL").ParamValue = strMaterial.PadLeft(18, "0")
                func.Exports("CODIGO").ParamValue = "X"

                func.Execute()

                R3.Close()

                dtCodigo = func.Tables("TT_MARA").ToADOTable

                Return dtCodigo

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAMARCAS() As DataTable

        Dim dtMarcas As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_MM_MARCAS             ********
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_MM_MARCAS")

                func.Execute()
                R3.Close()

                dtMarcas = func.Tables("E_MARCAS").ToADOTable

                Return dtMarcas

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZMF_JERARQUIASYATRIBUTOS(Tipo As String, ByRef dtValores As DataTable) As DataTable

        Dim dtCatalogos As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMF_JERARQUIASYATRIBUTOS   ********
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMF_JERARQUIASYATRIBUTOS")

                func.Exports("I_TIPO").ParamValue = Tipo.Trim

                func.Execute()

                R3.Close()

                dtCatalogos = func.Tables("T_CATALOGO").ToADOTable
                dtValores = func.Tables("T_RESULTADO").ToADOTable

                Return dtCatalogos

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGADESCUENTOSADICIONALES(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES7   ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES7"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZRFC_DESCARGA_DATOS_TIENDAS() As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_DESCARGA_DATOS_TIENDAS  ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_DESCARGA_DATOS_TIENDAS")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("E_DATOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGADESCUENTOSADICIONALESGENERAL(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES6   ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES6"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGADESCUENTOSADICIONALESPORMARCA(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES5    ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES5"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAPROMOCION20Y30(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES4    *****
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES4"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIO(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES    ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIOPORMARCA(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES2    *****
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES2"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAPROMOCIONDOSPORUNOYMEDIOPORCODIGO(ByVal Fecha As Date) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES3    *****
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES3"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGAPROMOCIONDPAKETESSTREETPACKS(ByVal Fecha As Date, ByRef dtDetalle As DataTable) As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOS_ACTUALES8    *****
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOS_ACTUALES8"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("PAQUETES").ToADOTable
                dtDetalle = func.Tables("PAQUETES_DET").ToADOTable


                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CARGADESCUENTOSFIJOSCLIENTESDIPS() As DataTable

        Dim dtDA As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_DESCUENTOSFIJOS         *****
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty

                strnombrebapi = "ZBAPI_DESCUENTOSFIJOS"

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                'func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                dtDA = func.Tables("DESCUENTOS").ToADOTable

                Return dtDA

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_GETDATA_UPC(ByVal CodUPC As String) As ArticulosSAP

        Dim oResult As ArticulosSAP
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CARGAEXISTENCIAS ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_GETDATA_UPC")
                func.Exports("I_CodUpc").ParamValue = CodUPC
                func.Execute()
                R3.Close()
                If func.Imports("E_EXISTE").ToString = "S" Then
                    oResult = New ArticulosSAP
                    With oResult
                        .Codarticulo = func.Imports("E_CodArticulo").ToString
                        .Codcorrida = func.Imports("E_Talla").ToString 'Meteremos la Talla.
                        .Codlinea = func.Imports("E_CodLinea").ToString
                        .Descripcion = func.Imports("E_Descripcion").ToString
                        .Costopromedio = func.Imports("e_costo").ToDouble
                        .Codfamilia = func.Imports("E_CodFamilia").ToString
                    End With
                End If
                Return oResult
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function
#End Region

#Region "Clientes"

    Friend Function Read_ClientesSAPSD02(ByVal OrganizacionCompra As String, ByVal canal As String, ByVal sector As String) As DataTable

        Dim dtClientes As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD02_DGCLIENTES ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty
                If oParent.SAPApplicationConfig.TdaNueva Then
                    strnombrebapi = "ZBAPISD02_TDANUEVA"
                Else
                    strnombrebapi = "ZBAPISD02_DGCLIENTES"
                End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("P_VKORG").ParamValue = OrganizacionCompra
                If Not oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                    func.Exports("P_VTWEG").ParamValue = canal
                Else
                    GoTo Cambio_053
                    'func.Exports("P_VTWEG").ParamValue = "C1"
                End If
                func.Exports("P_SPART").ParamValue = sector


                func.Execute()
                R3.Close()

                dtClientes = func.Tables("CLIENTES").ToADOTable

                Return dtClientes

            End If


        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_ELIMINAEMAILS(ByVal ClienteID As String) As String

        Dim strResult As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_ELIMINAEMAILS          ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_ELIMINAEMAILS")

                func.Exports("CLIENTEID").ParamValue = ClienteID.PadLeft(10, "0")

                func.Execute()

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strResult

    End Function

    'Friend Function Valida_Clientes(ByVal strCliente As String, ByVal Todos As Boolean, ByRef Adeuda As Boolean) As String

    '    Dim dtClientes As DataTable
    '    Dim strMensaje, strResult As String
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPISD02_DGCLIENTES ******
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZVALIDA_COMPRADOR")

    '            func.Exports("I_KUNNR").ParamValue = strCliente
    '            func.Exports("I_TODOS").ParamValue = IIf(Todos, "X", "")

    '            func.Execute()

    '            dtClientes = func.Tables("T_TLINE").ToADOTable
    '            strResult = func.Imports("E_STATU").ToString
    '            R3.Close()

    '            Adeuda = IIf(func.Imports("E_ADEUDA").ToString.Trim = "X", True, False)

    '            If strResult = "X" Then
    '                For Each oRow As DataRow In dtClientes.Rows
    '                    strMensaje = strMensaje & CStr(oRow("TDLINE")).ToString & Microsoft.VisualBasic.vbCrLf
    '                Next

    '                If strMensaje = String.Empty Then
    '                    strMensaje = "Cliente congelado"
    '                End If
    '            Else
    '                If strResult = "Z" Then
    '                    strMensaje = "DPVF "
    '                Else
    '                    strMensaje = "TARJ "
    '                End If
    '                For Each oRow As DataRow In dtClientes.Rows
    '                    strMensaje = strMensaje & CStr(oRow("TDLINE")).ToString & Microsoft.VisualBasic.vbCrLf
    '                Next
    '            End If

    '            Return strMensaje

    '        End If


    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    'End Function

    Friend Function ZCUP_INFO_CUPON(ByVal strFolio As String, ByVal strTipoVenta As String, ByRef strErrorMsg As String) As CuponDescuento

        Dim strResult As String = ""
        Dim oCuponDesc As CuponDescuento
        Dim FechaVig As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCUP_INFO_CUPON              ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCUP_INFO_CUPON")

                func.Exports("I_FOLIO").ParamValue = strFolio.Trim
                func.Exports("I_TIPO_VENTA").ParamValue = strTipoVenta.Trim
                func.Exports("I_TIENDA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen

                func.Execute()

                R3.Close()

                strResult = func.Imports("E_RESULTADO").ParamValue

                If CInt(strResult) = 1 Then
                    oCuponDesc = New CuponDescuento

                    With oCuponDesc
                        .Folio = IIf(IsNumeric(strFolio.Trim), strFolio.Trim.PadLeft(10, "0"), strFolio.Trim.ToUpper)
                        .Descripcion = func.Imports("E_DESCRIPCION").ToString
                        .TipoDescuento = func.Imports("E_TIPO_DESCTO").ToString
                        .Descuento = func.Imports("E_DESCUENTO").ParamValue
                        .Minimo = func.Imports("E_MINIMO").ParamValue
                        .Maximo = func.Imports("E_MAXIMO").ParamValue
                        .LimiteDescuento = func.Imports("E_LIMITE_DESCTO").ParamValue
                        FechaVig = func.Imports("E_FECHA_FIN").ToString
                        .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
                        .FormasPago = func.Tables("T_FORMASPAGO").ToADOTable()
                    End With
                    Dim zcupones As ERPConnect.RFCStructure = func.Imports("E_ZCUPONES").ToStructure()
                    For Each col As ERPConnect.RFCTableColumn In zcupones.Columns
                        oCuponDesc.InfoCupon.Add(col.Name, zcupones(col.Name))
                    Next
                Else
                    strErrorMsg = func.Imports("E_DESCRIPCION").ToString
                    oCuponDesc = Nothing
                End If

                Return oCuponDesc

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function
#End Region

#Region "Bitacora"
    Friend Function Read_BitacoraSAP(ByVal Fecha As Date) As DataTable

        Dim dtBitacoraSAP As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD02_DGCLIENTES ******
                '*****************************************************
                ' Create a function object

                Dim strnombrebapi As String = String.Empty
                If oParent.SAPApplicationConfig.TdaNueva Then
                    strnombrebapi = "ZBITACORA_MOVIMIENTOS"
                Else
                    strnombrebapi = "ZBITACORA_MOVIMIENTOS"
                End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                func.Exports("I_FECHA").ParamValue = Format(Fecha, "dd.MM.yyyy")
                func.Exports("I_WERKS").ParamValue = oParent.Read_Centros()
                func.Exports("I_LGORT").ParamValue = "M001" '"A001"

                func.Execute()
                R3.Close()

                dtBitacoraSAP = func.Tables("T_MOVIMIENTOS").ToADOTable

                Return dtBitacoraSAP

            End If


        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "CondicionesVenta Importes"

    Friend Function ZBAPI_Extraer_PreciosCondiciones(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal bCompleta As Boolean, Material As String) As DataTable

        Dim dtCondPrecio As New DataTable("CondicionesPago")
        Dim dtTemp As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '**************************************************************
                'Call RFC function ZBAPISD04_TDANUEVA - ZBAPISD04_EXTRPRECIOS
                '**************************************************************
                ' Create a function object

                Dim strnombrebapi As String = ""

                'If oParent.SAPApplicationConfig.TdaNueva OrElse bCompleta Then
                '    strnombrebapi = "ZBAPISD04_TDANUEVA"
                'Else
                '    strnombrebapi = "ZBAPISD04_EXTRPRECIOS"
                'End If

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_ABAMX_D04S")

                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    ''cuando es la tienda 53
                    'VKBUR.Value = "C053"
                    'If strLstPrecio = "Z0" Then
                    '    'Para que se baje el precio con iva
                    '    CANAL.Value = "T1"
                    'Else
                    '    CANAL.Value = "C1"
                    'End If
                    GoTo Cambio_053
                Else
                    'Otra Tienda
Cambio_053:
                    func.Exports("PI_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    func.Exports("PI_CANAL").ParamValue = "10"
                End If

                func.Exports("PI_COND").ParamValue = strCondicion
                func.Exports("PI_MATNR").ParamValue = Material.PadLeft(18, "0")
                'func.Exports("PI_LTAPRE").ParamValue = strLstPrecio
                If Material.Trim = "" Then
                    If oParent.SAPApplicationConfig.TdaNueva OrElse bCompleta Then
                        func.Exports("PI_TYPE").ParamValue = "T"
                    Else
                        func.Exports("PI_TYPE").ParamValue = "A"
                    End If
                Else
                    func.Exports("PI_TYPE").ParamValue = "D"
                End If
               
                func.Execute()

                R3.Close()
                'Creamos la estructura de la tabla
                dtCondPrecio.Columns.Add("OficinaVentas", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Jerarquia", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoMater", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("ListaPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Material", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
                dtCondPrecio.Columns.Add("FechaIni", GetType(DateTime)) 'func.Tables("PT_A903").Columns(1).GetType)
                dtCondPrecio.Columns.Add("FechaFin", GetType(DateTime)) 'func.Tables("PT_A903").Columns(1).GetType)
                dtCondPrecio.Columns.Add("CondVta", System.Type.GetType("System.String"))

                Dim oRow As DataRow, oRowTemp As DataRow
                Dim strFechaTemp As String = ""

                '------------------Tabla A004----------------
                If strLstPrecio <> "C2" Then
                    dtTemp = func.Tables("PT_A004").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("Material") = CStr(!MATNR)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("OficinaVentas") = ""
                            oRow("Jerarquia") = ""
                            oRow("GpoMater") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                End If
                '------------------Tabla A501----------------
                dtTemp = func.Tables("PT_A903").ToADOTable
                For Each oRowTemp In dtTemp.Rows
                    oRow = dtCondPrecio.NewRow
                    With oRowTemp
                        oRow("Material") = CStr(!MATNR)
                        oRow("ListaPrecios") = CStr(!PLTYP)
                        oRow("Importe") = CDec(!KBETR)
                        strFechaTemp = CStr(!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = CDate(strFechaTemp)
                        strFechaTemp = CStr(!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp
                        oRow("OficinaVentas") = ""
                        oRow("Jerarquia") = ""
                        oRow("GpoMater") = ""
                        oRow("GpoPrecios") = ""
                        oRow("CondVta") = strCondicion
                    End With
                    dtCondPrecio.Rows.Add(oRow)
                Next
                dtCondPrecio.AcceptChanges()

                If strCondicion <> "J3AP" Then
                    '------------------Tabla A502----------------
                    dtTemp = func.Tables("PT_A502").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("Jerarquia") = CStr(!PRODH)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("OficinaVentas") = ""
                            oRow("GpoMater") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A503----------------
                    dtTemp = func.Tables("PT_A503").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("Jerarquia") = CStr(!PRODH)
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("OficinaVentas") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A504----------------
                    dtTemp = func.Tables("PT_A504").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("Jerarquia") = CStr(!PRODH)
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("GpoPrecios") = CStr(!KONDA)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("OficinaVentas") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A505----------------
                    dtTemp = func.Tables("PT_A505").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("OficinaVentas") = CStr(!VKBUR)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("GpoMater") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                            oRow("Jerarquia") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A506----------------
                    dtTemp = func.Tables("PT_A506").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("Material") = CStr(!MATNR)
                            oRow("OficinaVentas") = CStr(!VKBUR)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("GpoMater") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                            oRow("Jerarquia") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A507----------------
                    dtTemp = func.Tables("PT_A507").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("OficinaVentas") = CStr(!VKBUR)
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                            oRow("Jerarquia") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A508----------------
                    dtTemp = func.Tables("PT_A508").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("OficinaVentas") = CStr(!VKBUR)
                            oRow("Jerarquia") = CStr(!PRODH)
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A509----------------
                    dtTemp = func.Tables("PT_A509").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("OficinaVentas") = CStr(!VKBUR)
                            oRow("Jerarquia") = CStr(!PRODH)
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("GpoPrecios") = CStr(!KONDA)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("Material") = ""
                            oRow("ListaPrecios") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '------------------Tabla A029----------------
                    dtTemp = func.Tables("PT_A029").ToADOTable
                    For Each oRowTemp In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        With oRowTemp
                            oRow("GpoMater") = CStr(!KONDM)
                            oRow("Importe") = CDec(!KBETR)
                            strFechaTemp = CStr(!DATAB)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaIni") = strFechaTemp
                            strFechaTemp = CStr(!DATBI)
                            strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                            oRow("FechaFin") = strFechaTemp
                            oRow("OficinaVentas") = ""
                            oRow("Material") = ""
                            oRow("GpoPrecios") = ""
                            oRow("ListaPrecios") = ""
                            oRow("Jerarquia") = ""
                        End With
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtCondPrecio

    End Function

    '    Friend Function Read_ExtraPreciosCondicSAPSD04(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal bCompleta As Boolean) As DataTable
    '        Try
    '            Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '            Dim myFunc As SAPFunctionsOCX.Function
    '            Dim Result As Boolean
    '            ' Se definen los parámetros TABLE
    '            Dim objtabretA501 As Object
    '            Dim objtabretA004 As Object
    '            Dim objtabretA509 As Object
    '            Dim objtabretA508 As Object
    '            Dim objtabretA507 As Object
    '            Dim objtabretA506 As Object
    '            Dim objtabretA505 As Object
    '            Dim objtabretA504 As Object
    '            Dim objtabretA503 As Object
    '            Dim objtabretA502 As Object
    '            Dim objtabretA029 As Object

    '            With R3.Connection
    '                .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '                .GroupName = oParent.SAPApplicationConfig.GroupName
    '                .System = oParent.SAPApplicationConfig.System
    '                .Client = oParent.SAPApplicationConfig.Client
    '                .User = oParent.SAPApplicationConfig.User
    '                .Password = oParent.SAPApplicationConfig.Password
    '                .Language = oParent.SAPApplicationConfig.Language
    '                .SystemNumber = oParent.SAPApplicationConfig.System
    '            End With

    '            ' Si no se logro conectar con éxito, entonces sale de la rutina
    '            If R3.Connection.logon(0, True) <> True Then
    '                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
    '                Exit Function
    '            Else
    '                ' Definición de los parámetros para el IMPORT de la función SAP
    '                Dim VKBUR As SAPFunctionsOCX.Parameter
    '                Dim V_COND As SAPFunctionsOCX.Parameter
    '                Dim LTAPRE As SAPFunctionsOCX.Parameter
    '                Dim CANAL As SAPFunctionsOCX.Parameter


    '                '*****************************************************
    '                'Call RFC function ZBAPISD04_EXTRPRECIOS     ***Ramiro
    '                '*****************************************************
    '                Dim strnombrebapi As String = String.Empty

    '                If oParent.SAPApplicationConfig.TdaNueva OrElse bCompleta Then
    '                    strnombrebapi = "ZBAPISD04_TDANUEVA"
    '                Else
    '                    strnombrebapi = "ZBAPISD04_EXTRPRECIOS"
    '                End If

    '                myFunc = R3.Add(strnombrebapi)
    '                ' Ajusta los parámetros de delimitación de entrada
    '                VKBUR = myFunc.Exports("VKBUR")
    '                V_COND = myFunc.Exports("V_COND")
    '                LTAPRE = myFunc.Exports("LTAPRE")
    '                CANAL = myFunc.Exports("CANAL")

    '                objtabretA501 = myFunc.Tables("ZT_A501")
    '                objtabretA004 = myFunc.Tables("ZT_A004")
    '                ' If strCondicion <> "J3AP" Then
    '                objtabretA502 = myFunc.Tables("ZT_A502")
    '                objtabretA503 = myFunc.Tables("ZT_A503")
    '                objtabretA504 = myFunc.Tables("ZT_A504")
    '                objtabretA505 = myFunc.Tables("ZT_A505")
    '                objtabretA506 = myFunc.Tables("ZT_A506")
    '                objtabretA507 = myFunc.Tables("ZT_A507")
    '                objtabretA508 = myFunc.Tables("ZT_A508")
    '                objtabretA509 = myFunc.Tables("ZT_A509")
    '                objtabretA029 = myFunc.Tables("ZT_A029")
    '                'End If

    '                '****** Asigno valores a los objetos

    '                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
    '                    ''cuando es la tienda 53
    '                    'VKBUR.Value = "C053"
    '                    'If strLstPrecio = "Z0" Then
    '                    '    'Para que se baje el precio con iva
    '                    '    CANAL.Value = "T1"
    '                    'Else
    '                    '    CANAL.Value = "C1"
    '                    'End If
    '                    GoTo Cambio_053
    '                Else
    '                    'Otra Tienda
    'Cambio_053:
    '                    VKBUR.Value = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
    '                    CANAL.Value = "T1"
    '                End If

    '                V_COND.Value = strCondicion
    '                LTAPRE.Value = strLstPrecio

    '                ' Ejecuta función en R/3
    '                Result = myFunc.Call
    '                R3.Connection.LOGOFF()

    '                If Result Then 'me traigo los campos
    '                    Dim irow As Integer = 0
    '                    'Tabla para meter los resultados de la BAPI
    '                    Dim dtCondPrecio As New DataTable("CondicionesPago")
    '                    dtCondPrecio.Columns.Add("OficinaVentas", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("Jerarquia", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("GpoMater", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("GpoPrecios", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("ListaPrecios", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("Material", System.Type.GetType("System.String"))
    '                    dtCondPrecio.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
    '                    dtCondPrecio.Columns.Add("FechaIni", objtabretA501.ColumnName(1).GetType)
    '                    dtCondPrecio.Columns.Add("FechaFin", objtabretA501.ColumnName(1).GetType)

    '                    '------------------objtabretA004----------------
    '                    'strCondicion
    '                    'strLstPrecio
    '                    If strLstPrecio <> "C2" Then
    '                        For irow = 1 To objtabretA004.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("Material") = CStr(objtabretA004(irow, "MATNR"))
    '                            orow("Importe") = CDec(objtabretA004(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA004(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA004(irow, "DATBI"))
    '                            orow("OficinaVentas") = String.Empty
    '                            orow("Jerarquia") = String.Empty
    '                            orow("GpoMater") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty

    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                    End If


    '                    '------------------objtabretA501----------------
    '                    For irow = 1 To objtabretA501.ROWCOUNT
    '                        Dim orow As DataRow = dtCondPrecio.NewRow
    '                        orow("Material") = CStr(objtabretA501(irow, "MATNR"))
    '                        orow("ListaPrecios") = CStr(objtabretA501(irow, "PLTYP"))
    '                        orow("Importe") = CDec(objtabretA501(irow, "KBETR"))
    '                        orow("FechaIni") = CStr(objtabretA501(irow, "DATAB"))
    '                        orow("FechaFin") = CStr(objtabretA501(irow, "DATBI"))
    '                        orow("OficinaVentas") = String.Empty
    '                        orow("Jerarquia") = String.Empty
    '                        orow("GpoMater") = String.Empty
    '                        orow("GpoPrecios") = String.Empty
    '                        dtCondPrecio.Rows.Add(orow)
    '                        dtCondPrecio.AcceptChanges()
    '                    Next

    '                    If strCondicion <> "J3AP" Then
    '                        '------------------objtabretA502----------------
    '                        For irow = 1 To objtabretA502.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("Jerarquia") = CStr(objtabretA502(irow, "PRODH"))
    '                            orow("Importe") = CDec(objtabretA502(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA502(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA502(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("OficinaVentas") = String.Empty
    '                            orow("GpoMater") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA503----------------
    '                        For irow = 1 To objtabretA503.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("Jerarquia") = CStr(objtabretA503(irow, "PRODH"))
    '                            orow("GpoMater") = CStr(objtabretA503(irow, "KONDM"))
    '                            orow("Importe") = CDec(objtabretA503(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA503(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA503(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("OficinaVentas") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA504----------------
    '                        For irow = 1 To objtabretA504.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("Jerarquia") = CStr(objtabretA504(irow, "PRODH"))
    '                            orow("GpoMater") = CStr(objtabretA504(irow, "KONDM"))
    '                            orow("GpoPrecios") = CStr(objtabretA504(irow, "KONDA"))
    '                            orow("Importe") = CDec(objtabretA504(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA504(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA504(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("OficinaVentas") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA505----------------
    '                        For irow = 1 To objtabretA505.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("OficinaVentas") = CStr(objtabretA505(irow, "VKBUR"))
    '                            orow("Importe") = CDec(objtabretA505(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA505(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA505(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("GpoMater") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            orow("Jerarquia") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA506----------------
    '                        For irow = 1 To objtabretA506.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("Material") = CStr(objtabretA506(irow, "MATNR"))
    '                            orow("OficinaVentas") = CStr(objtabretA506(irow, "VKBUR"))
    '                            orow("Importe") = CDec(objtabretA506(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA506(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA506(irow, "DATBI"))
    '                            orow("GpoMater") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            orow("Jerarquia") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA507----------------
    '                        For irow = 1 To objtabretA507.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("OficinaVentas") = CStr(objtabretA507(irow, "VKBUR"))
    '                            orow("GpoMater") = CStr(objtabretA507(irow, "KONDM"))
    '                            orow("Importe") = CDec(objtabretA507(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA507(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA507(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            orow("Jerarquia") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA508----------------
    '                        For irow = 1 To objtabretA508.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("OficinaVentas") = CStr(objtabretA508(irow, "VKBUR"))
    '                            orow("Jerarquia") = CStr(objtabretA508(irow, "PRODH"))
    '                            orow("GpoMater") = CStr(objtabretA508(irow, "KONDM"))
    '                            orow("Importe") = CDec(objtabretA508(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA508(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA508(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA509----------------
    '                        For irow = 1 To objtabretA509.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("OficinaVentas") = CStr(objtabretA509(irow, "VKBUR"))
    '                            orow("Jerarquia") = CStr(objtabretA509(irow, "PRODH"))
    '                            orow("GpoMater") = CStr(objtabretA509(irow, "KONDM"))
    '                            orow("GpoPrecios") = CStr(objtabretA509(irow, "KONDA"))
    '                            orow("Importe") = CDec(objtabretA509(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA509(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA509(irow, "DATBI"))
    '                            orow("Material") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                        '------------------objtabretA029----------------
    '                        For irow = 1 To objtabretA029.ROWCOUNT
    '                            Dim orow As DataRow = dtCondPrecio.NewRow
    '                            orow("GpoMater") = CStr(objtabretA029(irow, "KONDM"))
    '                            orow("Importe") = CDec(objtabretA029(irow, "KBETR"))
    '                            orow("FechaIni") = CStr(objtabretA029(irow, "DATAB"))
    '                            orow("FechaFin") = CStr(objtabretA029(irow, "DATBI"))
    '                            orow("OficinaVentas") = String.Empty
    '                            orow("Material") = String.Empty
    '                            orow("GpoPrecios") = String.Empty
    '                            orow("ListaPrecios") = String.Empty
    '                            orow("Jerarquia") = String.Empty
    '                            dtCondPrecio.Rows.Add(orow)
    '                            dtCondPrecio.AcceptChanges()
    '                        Next
    '                    End If
    '                    Return dtCondPrecio
    '                End If
    '            End If
    '        Catch ex As Exception
    '            Throw New ApplicationException(ex.Message, ex)
    '        End Try
    '    End Function

    Friend Function Read_ExtraPreciosCondicSAPSD04(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal bCompleta As Boolean) As DataTable

        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim objtabretA501 As DataTable
        Dim objtabretA004 As DataTable
        Dim objtabretA509 As DataTable
        Dim objtabretA508 As DataTable
        Dim objtabretA507 As DataTable
        Dim objtabretA506 As DataTable
        Dim objtabretA505 As DataTable
        Dim objtabretA504 As DataTable
        Dim objtabretA503 As DataTable
        Dim objtabretA502 As DataTable
        Dim objtabretA029 As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  MSS_GET_SY_DATE_TIME
                '*****************************************************
                ' Create a function object
                Dim strnombrebapi As String = String.Empty

                If oParent.SAPApplicationConfig.TdaNueva OrElse bCompleta Then
                    strnombrebapi = "ZBAPISD04_TDANUEVA"
                Else
                    strnombrebapi = "ZBAPISD04_EXTRPRECIOS"
                End If
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(strnombrebapi)

                'Asigno valores
                func.Exports("VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("CANAL").ParamValue = "T1"

                func.Exports("V_COND").ParamValue = strCondicion
                func.Exports("LTAPRE").ParamValue = strLstPrecio

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos informacion
                objtabretA501 = func.Tables("ZT_A501").ToADOTable
                objtabretA004 = func.Tables("ZT_A004").ToADOTable
                objtabretA509 = func.Tables("ZT_A509").ToADOTable
                objtabretA508 = func.Tables("ZT_A508").ToADOTable
                objtabretA507 = func.Tables("ZT_A507").ToADOTable
                objtabretA506 = func.Tables("ZT_A506").ToADOTable
                objtabretA505 = func.Tables("ZT_A505").ToADOTable
                objtabretA504 = func.Tables("ZT_A504").ToADOTable
                objtabretA503 = func.Tables("ZT_A503").ToADOTable
                objtabretA502 = func.Tables("ZT_A502").ToADOTable
                objtabretA029 = func.Tables("ZT_A029").ToADOTable

                Dim irow As Integer = 0
                'Tabla para meter los resultados de la BAPI
                Dim dtCondPrecio As New DataTable("CondicionesPago")
                dtCondPrecio.Columns.Add("OficinaVentas", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Jerarquia", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoMater", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("ListaPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Material", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
                dtCondPrecio.Columns.Add("FechaIni", System.Type.GetType("System.Date"))
                dtCondPrecio.Columns.Add("FechaFin", System.Type.GetType("System.Date"))

                '------------------objtabretA004----------------
                'strCondicion
                'strLstPrecio
                If strLstPrecio <> "C2" Then
                    For Each oRows As DataRow In objtabretA004.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = CStr(oRows!MATNR)
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                End If

                '------------------objtabretA501----------------
                For Each oRows As DataRow In objtabretA501.Rows
                    Dim oRow As DataRow = dtCondPrecio.NewRow
                    oRow("Material") = CStr(oRows!MATNR)
                    oRow("Importe") = CDec(oRows!KBETR)
                    oRow("FechaIni") = CStr(oRows!DATAB)
                    oRow("FechaFin") = CStr(oRows!DATBI)
                    oRow("OficinaVentas") = String.Empty
                    oRow("Jerarquia") = String.Empty
                    oRow("GpoMater") = String.Empty
                    oRow("GpoPrecios") = String.Empty
                    oRow("ListaPrecios") = CStr(oRows!PLTYP)
                    dtCondPrecio.Rows.Add(oRow)
                    dtCondPrecio.AcceptChanges()
                Next

                If strCondicion <> "J3AP" Then
                    '------------------objtabretA502----------------
                    For Each oRows As DataRow In objtabretA502.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = CStr(oRows!PRODH)
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA503----------------
                    For Each oRows As DataRow In objtabretA503.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = CStr(oRows!PRODH)
                        oRow("GpoMater") = CStr(oRows!KONDM)
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA504----------------
                    For Each oRows As DataRow In objtabretA504.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = CStr(oRows!PRODH)
                        oRow("GpoMater") = CStr(oRows!KONDM)
                        oRow("GpoPrecios") = CStr(oRows!KONDA)
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA505----------------
                    For Each oRows As DataRow In objtabretA505.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = CStr(oRows!VKBUR)
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA506----------------
                    For Each oRows As DataRow In objtabretA506.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = CStr(oRows!MATNR)
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = CStr(oRows!VKBUR)
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA507----------------
                    For Each oRows As DataRow In objtabretA507.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = CStr(oRows!VKBUR)
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = CDec(oRows!KONDM)
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA508----------------
                    For Each oRows As DataRow In objtabretA508.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = CStr(oRows!VKBUR)
                        oRow("Jerarquia") = CStr(oRows!PRODH)
                        oRow("GpoMater") = CDec(oRows!KONDM)
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA509----------------
                    For Each oRows As DataRow In objtabretA509.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = CStr(oRows!VKBUR)
                        oRow("Jerarquia") = CStr(oRows!PRODH)
                        oRow("GpoMater") = CDec(oRows!KONDM)
                        oRow("GpoPrecios") = CDec(oRows!KONDA)
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next
                    '------------------objtabretA029----------------
                    For Each oRows As DataRow In objtabretA509.Rows
                        Dim oRow As DataRow = dtCondPrecio.NewRow
                        oRow("Material") = String.Empty
                        oRow("Importe") = CDec(oRows!KBETR)
                        oRow("FechaIni") = CStr(oRows!DATAB)
                        oRow("FechaFin") = CStr(oRows!DATBI)
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = CDec(oRows!KONDM)
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                        dtCondPrecio.AcceptChanges()
                    Next

                    Return dtCondPrecio

                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function Read_ExtraPreciosCondicSAPSD04XCODIGO(ByVal strCondicion As String, ByVal strLstPrecio As String, ByVal strMaterial As String) As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD04_XCODIGOS             ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_ABAMX_D04S")

                '****** Asigno valores a los objetos
                If oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
                    ''cuando es la tienda 53
                    'VKBUR.Value = "C053"
                    'If strLstPrecio = "Z0" Then
                    '    'Para que se baje el precio con iva
                    '    CANAL.Value = "T1"
                    'Else
                    '    CANAL.Value = "C1"
                    'End If
                    GoTo Cambio_053
                Else
                    'Otra Tienda
Cambio_053:
                    func.Exports("PI_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                    func.Exports("PI_CANAL").ParamValue = "T1"
                End If

                func.Exports("PI_COND").ParamValue = strCondicion
                func.Exports("PI_LTAPRE").ParamValue = strLstPrecio
                func.Exports("PI_MATNR").ParamValue = strMaterial.Trim.ToUpper
                func.Exports("PI_TYPE").ParamValue = "D"

                'Dim dtZMateriales As New ERPConnect.RFCTable("ZTMATERIALES")
                'Dim oNewCol As New ERPConnect.RFCTableColumn("MATNR")

                'With oNewCol
                '    oNewCol.Type = ERPConnect.RFCTYPE.CHAR
                '    oNewCol.Length = 18
                'End With
                'dtZMateriales.Columns.Add(oNewCol)

                'Dim oSRow As ERPConnect.RFCStructure

                'For Each oRowM As DataRow In dtMateriales.Rows
                '    oSRow = dtZMateriales.AddRow
                '    oSRow.Item("MATNR") = oRowM!Material
                '    dtZMateriales.Rows.Add(oSRow)
                'Next

                'func.Tables.Add(dtZMateriales)


                ' Ejecuta función en R/3
                func.Execute()
                R3.Close()

                'If Result Then 'me traigo los campos
                'Dim irow As Integer = 0
                'Tabla para meter los resultados de la BAPI

                Dim dtTemp As DataTable
                Dim dtCondPrecio As New DataTable("CondicionesPago")
                Dim strFechaTemp As String = ""

                dtTemp = func.Tables("ZT_A501").ToADOTable

                dtCondPrecio.Columns.Add("OficinaVentas", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Jerarquia", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoMater", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("GpoPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("ListaPrecios", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Material", System.Type.GetType("System.String"))
                dtCondPrecio.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
                dtCondPrecio.Columns.Add("FechaIni", func.Tables("ZT_A501").Columns(1).GetType) ')objtabretA501.ColumnName(1).GetType)
                dtCondPrecio.Columns.Add("FechaFin", func.Tables("ZT_A501").Columns(1).GetType) 'objtabretA501.ColumnName(1).GetType)
                dtCondPrecio.Columns.Add("CondVta", System.Type.GetType("System.String"))
                '-------------------------------------------------------------------------------------------------------------------------
                'Tabla ZT_A004
                '-------------------------------------------------------------------------------------------------------------------------
                'strCondicion
                'strLstPrecio
                Dim oRow As DataRow
                Dim oZRow As DataRow

                If strLstPrecio.Trim.ToUpper <> "C2" Then
                    dtTemp = func.Tables("ZT_A004").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("Material") = CStr(oZRow!MATNR) 'CStr(objtabretA004(irow, "MATNR"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA004(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA004(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA004(irow, "DATBI"))
                        oRow("OficinaVentas") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty

                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                End If
                '-------------------------------------------------------------------------------------------------------------------------
                'Tabla ZT_A501
                '-------------------------------------------------------------------------------------------------------------------------
                dtTemp = func.Tables("ZT_A501").ToADOTable
                For Each oZRow In dtTemp.Rows
                    oRow = dtCondPrecio.NewRow
                    oRow("Material") = CStr(oZRow!MATNR) 'CStr(objtabretA501(irow, "MATNR"))
                    oRow("ListaPrecios") = CStr(oZRow!PLTYP) 'CStr(objtabretA501(irow, "PLTYP"))
                    oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA501(irow, "KBETR"))
                    strFechaTemp = CStr(oZRow!DATAB)
                    strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                    oRow("FechaIni") = strFechaTemp 'CStr(objtabretA501(irow, "DATAB"))
                    strFechaTemp = CStr(oZRow!DATBI)
                    strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                    oRow("FechaFin") = strFechaTemp 'CStr(objtabretA501(irow, "DATBI"))
                    oRow("OficinaVentas") = String.Empty
                    oRow("Jerarquia") = String.Empty
                    oRow("GpoMater") = String.Empty
                    oRow("GpoPrecios") = String.Empty
                    oRow("CondVta") = strCondicion
                    dtCondPrecio.Rows.Add(oRow)
                Next
                dtCondPrecio.AcceptChanges()

                '-------------------------------------------------------------------------------------------------------------------------
                'Tabla ZT_A502
                '-------------------------------------------------------------------------------------------------------------------------
                If strCondicion <> "J3AP" Then
                    dtTemp = func.Tables("ZT_A502").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("Jerarquia") = CStr(oZRow!PRODH) 'CStr(objtabretA502(irow, "PRODH"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA502(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA502(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA502(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("OficinaVentas") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A503
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A503").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("Jerarquia") = CStr(oZRow!PRODH) 'CStr(objtabretA503(irow, "PRODH"))
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA503(irow, "KONDM"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA503(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA503(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA503(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("OficinaVentas") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A504
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A504").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("Jerarquia") = CStr(oZRow!PRODH) 'CStr(objtabretA504(irow, "PRODH"))
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA504(irow, "KONDM"))
                        oRow("GpoPrecios") = CStr(oZRow!KONDA) 'CStr(objtabretA504(irow, "KONDA"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA504(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA504(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA504(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("OficinaVentas") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A505
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A505").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("OficinaVentas") = CStr(oZRow!VKBUR) 'CStr(objtabretA505(irow, "VKBUR"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA505(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA505(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA505(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A506
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A506").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("Material") = CStr(oZRow!MATNR) 'CStr(objtabretA506(irow, "MATNR"))
                        oRow("OficinaVentas") = CStr(oZRow!VKBUR) 'CStr(objtabretA506(irow, "VKBUR"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA506(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA506(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA506(irow, "DATBI"))
                        oRow("GpoMater") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A507
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A507").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("OficinaVentas") = CStr(oZRow!VKBUR) 'CStr(objtabretA507(irow, "VKBUR"))
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA507(irow, "KONDM"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA507(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA507(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA507(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A508
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A508").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("OficinaVentas") = CStr(oZRow!VKBUR) 'CStr(objtabretA508(irow, "VKBUR"))
                        oRow("Jerarquia") = CStr(oZRow!PRODH) 'CStr(objtabretA508(irow, "PRODH"))
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA508(irow, "KONDM"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA508(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA508(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA508(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A509
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A509").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("OficinaVentas") = CStr(oZRow!VKBUR) 'CStr(objtabretA509(irow, "VKBUR"))
                        oRow("Jerarquia") = CStr(oZRow!PRODH) 'CStr(objtabretA509(irow, "PRODH"))
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA509(irow, "KONDM"))
                        oRow("GpoPrecios") = CStr(oZRow!KONDA) 'CStr(objtabretA509(irow, "KONDA"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA509(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA509(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA509(irow, "DATBI"))
                        oRow("Material") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                    '-------------------------------------------------------------------------------------------------------------------------
                    'Tabla ZT_A029
                    '-------------------------------------------------------------------------------------------------------------------------
                    dtTemp = func.Tables("ZT_A029").ToADOTable
                    For Each oZRow In dtTemp.Rows
                        oRow = dtCondPrecio.NewRow
                        oRow("GpoMater") = CStr(oZRow!KONDM) 'CStr(objtabretA029(irow, "KONDM"))
                        oRow("Importe") = CDec(oZRow!KBETR) 'CDec(objtabretA029(irow, "KBETR"))
                        strFechaTemp = CStr(oZRow!DATAB)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaIni") = strFechaTemp 'CStr(objtabretA029(irow, "DATAB"))
                        strFechaTemp = CStr(oZRow!DATBI)
                        strFechaTemp = strFechaTemp.Substring(6, 2) & "/" & strFechaTemp.Substring(4, 2) & "/" & strFechaTemp.Substring(0, 4)
                        oRow("FechaFin") = strFechaTemp 'CStr(objtabretA029(irow, "DATBI"))
                        oRow("OficinaVentas") = String.Empty
                        oRow("Material") = String.Empty
                        oRow("GpoPrecios") = String.Empty
                        oRow("ListaPrecios") = String.Empty
                        oRow("Jerarquia") = String.Empty
                        dtCondPrecio.Rows.Add(oRow)
                    Next
                    dtCondPrecio.AcceptChanges()
                End If

                Return dtCondPrecio

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Apartado"

    'Friend Function Write_RegistroApartadoSAPMM13(ByVal strContrato As String, ByVal oArticulos() As ZDP_PRODAPARTADO) As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strCentro As String

    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_APARTADO As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CENTRO As SAPFunctionsOCX.Parameter    'MSEG-WERKS  CENTRO
    '        Dim ALMACEN As SAPFunctionsOCX.Parameter   'MSEG-LGORT  Almacén
    '        Dim CONTRATO As SAPFunctionsOCX.Parameter
    '        Dim DOCFI As SAPFunctionsOCX.Parameter
    '        Dim I_FECHA As SAPFunctionsOCX.Parameter    'Fecha Movimiento

    '        strCentro = oParent.Read_Centros()

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIMM13_REGISTROAPARTADO  ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM13_REGISTROAPARTADO")

    '            ' Ajusta los parámetros de delimitación de entrada
    '            CENTRO = myFunc.Exports("CENTRO")
    '            ALMACEN = myFunc.Exports("ALMACEN")
    '            CONTRATO = myFunc.Exports("CONTRATO")
    '            I_FECHA = myFunc.Exports("I_FECHA")

    '            DOCFI = myFunc.Imports("DOCFI")
    '            ' Cargar la tabla con los datos que vamos a enviar - TABLES.
    '            objtabretTABLA_APARTADO = myFunc.Tables("ZTABLA_APARTADO")
    '            objtabretReturn = myFunc.Tables("RETURN")

    '            ' Asigno valores a los objetos
    '            CENTRO.Value = strCentro
    '            ALMACEN.Value = strCentro
    '            CONTRATO.Value = strContrato
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            For i As Integer = 1 To oArticulos.Length
    '                oStructureSAP = objtabretTABLA_APARTADO.AppendRow()
    '                oStructureSAP.Value("CENTRO") = strCentro
    '                oStructureSAP.Value("CONTRATO") = oArticulos(i - 1).Contrato
    '                oStructureSAP.Value("MATNR") = oArticulos(i - 1).Matnr
    '                oStructureSAP.Value("CANTIDAD") = oArticulos(i - 1).Cantidad
    '                oStructureSAP.Value("TALLA") = oArticulos(i - 1).Talla
    '            Next i

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            If Result Then 'me traigo los campos
    '                Return CStr(DOCFI.Value)
    '            Else
    '                Return String.Empty
    '            End If

    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Function

    '"Registro de Apartado"
    Friend Function Write_RegistroApartadoSAPMM13(ByVal strContrato As String, ByVal oArticulos() As ZDP_PRODAPARTADO) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try

            Dim Result As Boolean
            Dim strCentro As String
            Dim DOCFI As String

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM13_REGISTROAPARTADO     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM13_REGISTROAPARTADO")

                ' Asigno valores a los objetos
                strCentro = oParent.Read_Centros()
                func.Exports("CENTRO").ParamValue = strCentro
                func.Exports("ALMACEN").ParamValue = strCentro
                func.Exports("CONTRATO").ParamValue = strContrato
                func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

                ' Cargar la tabla con los datos que vamos a enviar - TABLES.
                Dim T_CLines As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
                For Each oArticulo As ZDP_PRODAPARTADO In oArticulos
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("CENTRO") = strCentro
                    R_CLines("CONTRATO") = oArticulo.Contrato
                    R_CLines("MATNR") = oArticulo.Matnr
                    R_CLines("CANTIDAD") = oArticulo.Cantidad
                    R_CLines("TALLA") = oArticulo.Talla
                Next

                'Ejecutamos la RFC
                func.Execute()

                R3.Close()

                'Obtenemos Ionfo
                DOCFI = CStr(func.Imports("DOCFI").ParamValue)



                If DOCFI <> String.Empty Then 'me traigo los campos
                    Return DOCFI
                Else
                    Return String.Empty
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    'Friend Function Write_DesbloqueoApartadoSAPMM14(ByVal strContrato As String, ByVal articulos() As ZDP_PRODAPARTADO) As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_APARTADO As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            ' Definición de los parámetros para el IMPORT de la función SAP
    '            Dim CENTRO As SAPFunctionsOCX.Parameter    'MSEG-WERKS  CENTRO
    '            Dim ALMACEN As SAPFunctionsOCX.Parameter   'MSEG-LGORT  Almacén
    '            Dim CONTRATO As SAPFunctionsOCX.Parameter
    '            Dim DOCFI As SAPFunctionsOCX.Parameter
    '            Dim I_FECHA As SAPFunctionsOCX.Parameter    'Fecha Movimiento

    '            '********************************************************
    '            'Call RFC function ZBAPIMM14_DESBLOQUEOART  ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM14_DESBLOQUEOART")
    '            ' Ajusta los parámetros de delimitación de entrada

    '            CENTRO = myFunc.Exports("CENTRO")
    '            ALMACEN = myFunc.Exports("ALMACEN")
    '            CONTRATO = myFunc.Exports("CONTRATO")
    '            I_FECHA = myFunc.Exports("I_FECHA")
    '            DOCFI = myFunc.Imports("DOCFI")

    '            ' Cargar la tabla con los datos que vamos a enviar - TABLES.
    '            objtabretTABLA_APARTADO = myFunc.Tables("ZTABLA_APARTADO")
    '            objtabretReturn = myFunc.Imports("RETURN")


    '            For i As Integer = 1 To articulos.Length
    '                oStructureSAP = objtabretTABLA_APARTADO.AppendRow()
    '                oStructureSAP.Value("CENTRO") = oParent.Read_Centros()
    '                oStructureSAP.Value("CONTRATO") = articulos(i - 1).Contrato
    '                oStructureSAP.Value("MATNR") = articulos(i - 1).Matnr
    '                oStructureSAP.Value("CANTIDAD") = articulos(i - 1).Cantidad
    '                oStructureSAP.Value("TALLA") = articulos(i - 1).Talla
    '            Next i

    '            '****** Asigno valores a los objetos
    '            CENTRO.Value = oParent.Read_Centros()
    '            ALMACEN.Value = oParent.Read_Centros()
    '            CONTRATO.Value = strContrato
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()
    '            Dim iren As Integer
    '            If Result Then 'me traigo los campos
    '                Return CStr(DOCFI.Value)
    '            Else
    '                Return String.Empty
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try

    'End Function

    '"Desbloqueo de Apartado"
    Friend Function Write_DesbloqueoApartadoSAPMM14(ByVal strContrato As String, ByVal articulos() As ZDP_PRODAPARTADO) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim strCentro As String
            Dim DOCFI As String = String.Empty

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM14_DESBLOQUEOART     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM14_DESBLOQUEOART")

                ' Asigno valores a los objetos
                strCentro = oParent.Read_Centros()
                func.Exports("CENTRO").ParamValue = strCentro
                func.Exports("ALMACEN").ParamValue = strCentro
                func.Exports("CONTRATO").ParamValue = strContrato
                func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

                ' Cargar la tabla con los datos que vamos a enviar - TABLES.
                Dim T_CLines As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
                For Each oArticulo As ZDP_PRODAPARTADO In articulos
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("CENTRO") = strCentro
                    R_CLines("CONTRATO") = oArticulo.Contrato
                    R_CLines("MATNR") = oArticulo.Matnr
                    R_CLines("CANTIDAD") = oArticulo.Cantidad
                    R_CLines("TALLA") = oArticulo.Talla
                Next

                'Ejecutamos la RFC
                func.Execute()

                R3.Close()

                'Obtenemos Ionfo
                DOCFI = CStr(func.Imports("DOCFI").ParamValue)

                If DOCFI <> String.Empty Then 'me traigo los campos
                    Return DOCFI
                Else
                    Return String.Empty
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '-------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 05/07/2013: Se agrego un parametro esta para registrar los pedidos del SiHay
    '-------------------------------------------------------------------------------------------------------------------------------
    'Friend Function Write_AnticipoApartadoSAPFI02(ByVal strNumDocRef As String, ByVal dblImporte As Double, ByVal strCodcliente As String, _
    '                                                ByVal strContrato As String, ByVal strTipoMovieminto As String, ByVal strNombreTienda As String, _
    '                                                ByVal strCuenta As String, ByVal strDivision As String, ByVal strNumtienda As String, _
    '                                                ByVal strNoAfil As String, Optional ByVal ZSH_FPAGO As String = "", Optional ByRef strErrorLog As String = "") As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            Dim XBLNR As SAPFunctionsOCX.Parameter
    '            Dim WRBTR As SAPFunctionsOCX.Parameter
    '            Dim TIENDA As SAPFunctionsOCX.Parameter
    '            Dim ZFBDT As SAPFunctionsOCX.Parameter
    '            Dim WAERS As SAPFunctionsOCX.Parameter
    '            Dim NEWKO As SAPFunctionsOCX.Parameter
    '            Dim F_29 As SAPFunctionsOCX.Parameter
    '            Dim DOCFI As SAPFunctionsOCX.Parameter
    '            Dim ZUONR As SAPFunctionsOCX.Parameter
    '            Dim SGTXT As SAPFunctionsOCX.Parameter
    '            Dim TIPOMOV As SAPFunctionsOCX.Parameter
    '            Dim CUENTA As SAPFunctionsOCX.Parameter
    '            Dim GSBER As SAPFunctionsOCX.Parameter
    '            Dim BKTXT As SAPFunctionsOCX.Parameter
    '            Dim ZSH_FPAGOP As SAPFunctionsOCX.Parameter
    '            Dim TextoCab As String = ""

    '            Dim oReturn As Object           '--Tabla de Retorno
    '            'Dim I_FECHA As SAPFunctionsOCX.Parameter

    '            '********************************************************
    '            'Call RFC function ZBAPIFI02_ANT_APART  ***Rogelio
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIFI02_ANT_APART")

    '            ' Ajusta los parámetros de delimitación de entrada

    '            ' Definición de los parámetros para el IMPORT de la función SAP
    '            XBLNR = myFunc.Exports("XBLNR")      'Número de documento de referencia
    '            WRBTR = myFunc.Exports("WRBTR")      'Importe en la moneda del documento
    '            TIENDA = myFunc.Exports("TIENDA")
    '            ZFBDT = myFunc.Exports("ZFBDT")     'Fecha base para cálculo del vencimiento
    '            NEWKO = myFunc.Exports("NEWKO")     'Cuenta o matchcode para la siguiente posición
    '            ZUONR = myFunc.Exports("ZUONR")     'Informacion Opcionales
    '            SGTXT = myFunc.Exports("SGTXT")     'Informacion Opcionales
    '            TIPOMOV = myFunc.Exports("TIPOMOV") 'Si es AB o AN
    '            CUENTA = myFunc.Exports("CUENTA")
    '            GSBER = myFunc.Exports("GSBER")     'Division
    '            BKTXT = myFunc.Exports("BKTXT")     'Texto de Cabezera
    '            If ZSH_FPAGO.Trim() <> "" Then
    '                ZSH_FPAGOP = myFunc.Exports("FPAGO")
    '                ZSH_FPAGOP.Value = ZSH_FPAGO
    '            End If

    '            'I_FECHA = myFunc.Exports("I_FECHA") 'Fecha Movimiento

    '            ' Definición de los parámetros para el EXPORT de la función SAP
    '            F_29 = myFunc.Imports("F_29") 'Regresa Y = Creado y N = no creado
    '            DOCFI = myFunc.Imports("DOCFI")

    '            If InStr(strNumDocRef, "Pedido SH:") > 0 Then
    '                TextoCab = strNumDocRef.Trim
    '                strNumDocRef = strNumDocRef.Trim.Replace("Pedido SH: ", "")
    '            Else
    '                TextoCab = strNumDocRef.Trim.PadLeft(10, "0")
    '            End If

    '            XBLNR.Value = strNumDocRef 'Folio Abono.
    '            WRBTR.Value = dblImporte
    '            TIENDA.Value = strNombreTienda
    '            ZFBDT.Value = Date.Now.Date
    '            NEWKO.Value = strCodcliente
    '            '---Numero de Referencia Bancario
    '            If strCuenta = "EFECTIVO" Then
    '                Dim numref As New NumeroReferencia.cNumReferencia
    '                ZUONR.Value = numref.getNumReferencia(strNumtienda.PadLeft(4, "0"), CStr(Format(Date.Now.Date, "ddMMyyyy")))
    '            ElseIf strCuenta = "TARJETA 1" Then
    '                Dim strNumRefBBV As String
    '                If strNoAfil.Length > 6 Then
    '                    strNumRefBBV = Mid(strNoAfil, 2)
    '                Else
    '                    strNumRefBBV = strNoAfil.PadLeft(6, "0")
    '                End If
    '                ZUONR.Value = strNumRefBBV & Format(Date.Today, "ddMM") & Format(Date.Today, "yyyy").Substring(1)
    '            Else
    '                ZUONR.Value = strNoAfil & Format(Date.Today, "ddMMyy")
    '            End If
    '            '---Numero de Referencia Bancario
    '            'SGTXT.Value = strNumDocRef.PadLeft(10, "0")
    '            SGTXT.Value = TextoCab
    '            TIPOMOV.Value = strTipoMovieminto
    '            CUENTA.Value = strCuenta
    '            GSBER.Value = strDivision
    '            BKTXT.Value = strContrato.PadLeft(10, "0")

    '            ' Ejecuta función en R/3
    '            oReturn = myFunc.Tables("RETURN")
    '            Result = myFunc.Call

    '            'Cierra la conexion
    '            R3.Connection.LOGOFF()

    '            If Result Then 'me traigo los campos
    '                If F_29.Value = "Y" Then
    '                    Return DOCFI.Value
    '                Else
    '                    'Mostramos errores de SAP.
    '                    Dim iRen As Integer
    '                    Dim strError As String
    '                    strError = String.Empty
    '                    For iRen = 1 To oReturn.ROWCOUNT
    '                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '                    Next iRen

    '                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

    '                    strErrorLog = strError.Trim
    '                    Return String.Empty
    '                End If

    '            End If

    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Function


    '"Anticipo de Apartado"

    '"Anticipo de Apartado"
    Friend Function Write_AnticipoApartadoSAPFI02(ByVal strNumDocRef As String, ByVal dblImporte As Double, ByVal strCodcliente As String, _
                                                   ByVal strContrato As String, ByVal strTipoMovieminto As String, ByVal strNombreTienda As String, _
                                                   ByVal strCuenta As String, ByVal strDivision As String, ByVal strNumtienda As String, _
                                                   ByVal strNoAfil As String, Optional ByVal ZSH_FPAGO As String = "", Optional ByRef strErrorLog As String = "", Optional ByVal Mod_Ped As String = "") As String
        '----------------------------------------------------------------------------------
        ' JNAVA (04.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim Result As Boolean
            Dim TextoCab As String = ""
            Dim dtReturn As New DataTable

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI02_ANT_APART     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI02_ANT_APART")

                'Asiganamos(datos)
                If InStr(strNumDocRef, "Pedido SH:") > 0 Then
                    TextoCab = strNumDocRef.Trim
                    strNumDocRef = strNumDocRef.Trim.Replace("Pedido SH: ", "")
                Else
                    TextoCab = strNumDocRef.Trim.PadLeft(10, "0")
                End If
                If ZSH_FPAGO.Trim() <> "" Then
                    func.Exports("FPAGO").ParamValue = ZSH_FPAGO
                End If
                func.Exports("XBLNR").ParamValue = strNumDocRef 'Folio Abono.
                func.Exports("WRBTR").ParamValue = dblImporte
                func.Exports("TIENDA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("ZFBDT").ParamValue = Date.Now.Date.ToString("ddMMyyyy")
                'func.Exports("NEWKO").ParamValue = strCodcliente
                '---Numero de Referencia Bancario
                If strCuenta = "EFECTIVO" Then
                    Dim numref As New NumeroReferencia.cNumReferencia
                    func.Exports("ZUONR").ParamValue = numref.getNumReferencia(strNumtienda.PadLeft(4, "0"), CStr(Format(Date.Now.Date, "ddMMyyyy")))
                ElseIf strCuenta = "TARJETA 1" Then
                    Dim strNumRefBBV As String
                    If strNoAfil.Length > 6 Then
                        strNumRefBBV = Mid(strNoAfil, 2)
                    Else
                        strNumRefBBV = strNoAfil.PadLeft(6, "0")
                    End If
                    func.Exports("ZUONR").ParamValue = strNumRefBBV & Format(Date.Today, "ddMM") & Format(Date.Today, "yyyy").Substring(1)
                Else
                    func.Exports("ZUONR").ParamValue = strNoAfil & Format(Date.Today, "ddMMyy")
                End If
                '---Numero de Referencia Bancario
                'SGTXT.Value = strNumDocRef.PadLeft(10, "0")
                func.Exports("SGTXT").ParamValue = TextoCab
                func.Exports("TIPOMOV").ParamValue = strTipoMovieminto
                func.Exports("CUENTA").ParamValue = strCuenta
                'func.Exports("GSBER").ParamValue = strDivision
                func.Exports("BKTXT").ParamValue = strContrato.PadLeft(10, "0")

                If Mod_Ped <> "" Then
                    func.Exports("I_MOT_PED").ParamValue = Mod_Ped
                End If

                'Ejecutamos la RFC
                func.Execute()

                R3.Close()

                'Obtenemos Info
                dtReturn = func.Tables("RETURN").ToADOTable()

                If func.Imports("F_29").ParamValue = "Y" Then
                    Return func.Imports("DOCFI").ParamValue
                Else
                    'Mostramos errores de SAP.
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr((row("MESSAGE")))
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                    strErrorLog = strError.Trim
                    Return String.Empty
                End If


            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    'Cancelacion de Apartado
    'Friend Function Write_CancelacionApartadoSAPFI04(ByVal strCliente As String, ByVal dblIImporte As Double, ByVal dblIImportePenalidad As Double, _
    '                                                ByVal strTienda As String, ByVal strDevdinero As String, ByVal dblIImporteDevolucion As Double, _
    '                                                ByVal strDocFi As String, ByVal strBanco As String, ByVal strTipoPago As String) As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strCentro As String

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CLIENTE As SAPFunctionsOCX.Parameter
    '        Dim IMPORTE As SAPFunctionsOCX.Parameter
    '        Dim IMPORTE_PENALIDAD As SAPFunctionsOCX.Parameter
    '        Dim TIENDA As SAPFunctionsOCX.Parameter
    '        Dim IMPORTE_DEVOLUCION As SAPFunctionsOCX.Parameter
    '        Dim DOCNUMFI As SAPFunctionsOCX.Parameter
    '        'Dim I_FECHA As SAPFunctionsOCX.Parameter

    '        Dim DEVOLUCION_DINERO As SAPFunctionsOCX.Parameter
    '        Dim BANCO As SAPFunctionsOCX.Parameter
    '        Dim CLAVE_COBRANZA As SAPFunctionsOCX.Parameter

    '        ' Definición de los parámetros para el EXPORT de la función SAP
    '        Dim DOCNUMFB01 As SAPFunctionsOCX.Parameter

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIFI04_CANCAPART  ***Pedro Tosh
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIFI04_CANCAPART")

    '            ' Ajusta los parámetros de delimitación de entrada
    '            CLIENTE = myFunc.Exports("CLIENTE")
    '            IMPORTE = myFunc.Exports("IMPORTE")
    '            IMPORTE_PENALIDAD = myFunc.Exports("IMPORTE_PENALIDAD")
    '            TIENDA = myFunc.Exports("TIENDA")
    '            DOCNUMFI = myFunc.Exports("DOCNUMFI")
    '            IMPORTE_DEVOLUCION = myFunc.Exports("IMPORTE_DEVOLUCION")
    '            'I_FECHA = myFunc.Exports("I_FECHA")
    '            DEVOLUCION_DINERO = myFunc.Exports("DEVOLUCION_DINERO")
    '            BANCO = myFunc.Exports("BANCO")
    '            CLAVE_COBRANZA = myFunc.Exports("CLAVE_COBRANZA")

    '            ' Ajusta los parámetros de delimitación de Salida
    '            DOCNUMFB01 = myFunc.Imports("DOCNUMFB01")

    '            '' Asigno valores a los objetos
    '            CLIENTE.Value = strCliente
    '            IMPORTE.Value = dblIImporte
    '            IMPORTE_PENALIDAD.Value = dblIImportePenalidad
    '            TIENDA.Value = strTienda
    '            DOCNUMFI.Value = strDocFi
    '            IMPORTE_DEVOLUCION.Value = dblIImporteDevolucion
    '            If strDevdinero Is Nothing Or strDevdinero = String.Empty Then
    '                DEVOLUCION_DINERO.Value = ""
    '            Else
    '                DEVOLUCION_DINERO.Value = strDevdinero
    '            End If
    '            BANCO.Value = strBanco
    '            CLAVE_COBRANZA.Value = strTipoPago
    '            'I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            If Result Then 'me traigo los campos
    '                Return CStr(DOCNUMFB01.Value)
    '            Else
    '                Return String.Empty
    '            End If

    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try

    'End Function

    Friend Function Write_CancelacionApartadoSAPFI04(ByVal strCliente As String, ByVal dblIImporte As Double, ByVal dblIImportePenalidad As Double, _
                                                    ByVal strTienda As String, ByVal strDevdinero As String, ByVal dblIImporteDevolucion As Double, _
                                                    ByVal strDocFi As String, ByVal strBanco As String, ByVal strTipoPago As String) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim Result As Boolean
            Dim strCentro As String
            Dim strDOCNUMFB01 As String

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI04_CANCAPART     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI04_CANCAPART")

                '' Asigno valores a los objetos
                func.Exports("CLIENTE").ParamValue = strCliente
                func.Exports("IMPORTE").ParamValue = dblIImporte
                func.Exports("IMPORTE_PENALIDAD").ParamValue = dblIImportePenalidad
                func.Exports("TIENDA").ParamValue = strTienda
                func.Exports("DOCNUMFI").ParamValue = strDocFi
                func.Exports("IMPORTE_DEVOLUCION").ParamValue = dblIImporteDevolucion
                If strDevdinero Is Nothing Or strDevdinero = String.Empty Then
                    func.Exports("DEVOLUCION_DINERO").ParamValue = ""
                Else
                    func.Exports("DEVOLUCION_DINERO").ParamValue = strDevdinero
                End If
                func.Exports("BANCO").ParamValue = strBanco
                func.Exports("CLAVE_COBRANZA").ParamValue = strTipoPago
                'I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                strDOCNUMFB01 = func.Imports("DOCNUMFB01").ParamValue

                Return strDOCNUMFB01


            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    'Friend Function Write_CancelacionAbonoApartadoSAPFI04(ByVal strCliente As String, ByVal dtFecha As String, ByVal dblIImporte As Double, _
    '                                                        ByVal strCuentaMayor As String, ByVal strDocFi As String, ByVal strGSBER As String, ByVal strWerks As String, ByRef strError As String) As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strCentro As String
    '        Dim oReturn As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CLIENTE As SAPFunctionsOCX.Parameter
    '        Dim FECHA As SAPFunctionsOCX.Parameter
    '        Dim IMPORTE As SAPFunctionsOCX.Parameter
    '        Dim CUENTAMAYOR As SAPFunctionsOCX.Parameter
    '        Dim DOCNUMFI As SAPFunctionsOCX.Parameter
    '        Dim GSBER As SAPFunctionsOCX.Parameter
    '        Dim WERKS As SAPFunctionsOCX.Parameter
    '        'Dim I_FECHA As SAPFunctionsOCX.Parameter


    '        ' Definición de los parámetros para el EXPORT de la función SAP
    '        Dim DOCNUMFB01 As SAPFunctionsOCX.Parameter

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIFI_CANC_AB_APARTADO  ***Beny S
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIFI_CANC_AB_APARTADO")

    '            ' Ajusta los parámetros de delimitación de entrada
    '            CLIENTE = myFunc.Exports("CLIENTE")
    '            FECHA = myFunc.Exports("FECHA")
    '            IMPORTE = myFunc.Exports("IMPORTE")
    '            CUENTAMAYOR = myFunc.Exports("CUENTAMAYOR")
    '            DOCNUMFI = myFunc.Exports("DOCFI")
    '            GSBER = myFunc.Exports("DIVISION")
    '            WERKS = myFunc.Exports("CECO")

    '            ' Ajusta los parámetros de delimitación de Salida
    '            DOCNUMFB01 = myFunc.Imports("DOCNUMFB01")

    '            '' Asigno valores a los objetos
    '            CLIENTE.Value = strCliente
    '            IMPORTE.Value = dblIImporte
    '            FECHA.Value = dtFecha
    '            CUENTAMAYOR.Value = strCuentaMayor
    '            DOCNUMFI.Value = strDocFi
    '            GSBER.Value = strGSBER
    '            WERKS.Value = strWerks

    '            ' Ejecuta función en R/3
    '            oReturn = myFunc.Tables("RETURN")
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            If Result Then 'me traigo los campos
    '                Return CStr(DOCNUMFB01.Value)
    '            Else
    '                Dim iRen As Integer
    '                strError = String.Empty
    '                For iRen = 1 To oReturn.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '                Next iRen

    '                Return String.Empty
    '            End If

    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try

    'End Function


    Friend Function Write_CancelacionAbonoApartadoSAPFI04(ByVal strCliente As String, ByVal dtFecha As String, ByVal dblIImporte As Double, _
                                                           ByVal strCuentaMayor As String, ByVal strDocFi As String, ByVal strGSBER As String, ByVal strWerks As String, ByRef strError As String, ByVal strReferencia As String) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '---------------------------------------------------------------------------------- 
        ' JNAVA (12.03.2016): Modificacion para adaptacion a retail, se envia referencia 
        '                     en ves del cliente
        '----------------------------------------------------------------------------------

        Try
            Dim strCentro As String
            Dim strDOCNUMFB01 As String
            Dim dtReturn As New DataTable

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI_CANC_AB_APARTADO     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI_CANC_AB_APARTADO")

                '' Asigno valores a los objetos
                'func.Exports("CLIENTE").ParamValue = strCliente
                func.Exports("REF_PAGO").ParamValue = strReferencia
                func.Exports("IMPORTE").ParamValue = CDec(dblIImporte).ToString("##,##0.00").Replace(",", "")
                Dim fecha As String = dtFecha.Substring(6, 4) & dtFecha.Substring(3, 2) & dtFecha.Substring(0, 2)
                func.Exports("FECHA").ParamValue = dtFecha
                func.Exports("CUENTAMAYOR").ParamValue = strCuentaMayor
                func.Exports("DOCFI").ParamValue = strDocFi
                'func.Exports("GSBER").ParamValue = strGSBER
                func.Exports("OF_VENTAS").ParamValue = strWerks

                ' Ejecuta función en R/3
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtenemos info
                dtReturn = func.Tables("RETURN").ToADOTable
                strDOCNUMFB01 = CStr(func.Imports("DOCNUMFB01").ParamValue)

                If strDOCNUMFB01 <> String.Empty Then 'me traigo los campos
                    Return strDOCNUMFB01
                Else
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr((row("MESSAGE")))
                    Next
                    Return String.Empty
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

#End Region

#Region "ZPP_COBRANZAS"


    Friend Function Read_ZPP_COBRANZAS() As DataTable

        Dim dtClientes As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI02_RECCUENTAS         ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI02_RECCUENTAS")
                func.Execute()
                R3.Close()

                dtClientes = func.Tables("T_CUENTAS").ToADOTable

                Return dtClientes
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function


#End Region

#Region "Factura SAP"
    '-------------------------------------------------------------------------
    ' JNAVA 17.02.2016): Se comento por que ya no se usa en Retail
    '-------------------------------------------------------------------------
    'Friend Function Read_Plaza() As String

    '    Dim Plaza As String = ""
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZRFC_GETPLAZA_TIENDA         ******
    '            '*****************************************************
    '            ' Create a function object
    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_GETPLAZA_TIENDA")

    '            func.Exports("I_TIENDA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen

    '            func.Execute()

    '            R3.Close()

    '            Plaza = func.Imports("E_PLAZA").ParamValue

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    '    Return Plaza.Trim

    'End Function

    'Friend Sub Write_FacturaSAP_PG_EFEC(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis

    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        Dim oReturn As Object           '--Tabla de Retorno
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        'oReturn = objFunc.Imports("RETURN")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            oI_ZonaVta.Value = .ZonaVenta

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV", "Z522", "ZDIP"  '-- % Descuento Manager/Asistente ¦ Vales de Descuento/Socios"
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))

    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()


    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            'TODO oReturn
    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Information, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()

    '    Catch ex As Exception


    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty

    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_FIS_EFEC(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oReturn As Object
    '        Dim oMesstab As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            oI_ZonaVta.Value = .ZonaVenta

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV"     '-- % Descuento Manager/Asistente ¦ Vales de Descuento
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()

    '    Catch ex As Exception

    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty

    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_PG_TARJ(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        Dim oReturn As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            '------------------------------------------------------------------------------------------------------
    '            'JNAVA (03.03.2015): Si la Zona de Venta es DPCA se maneja como tarjeta de Credito normal en SAP
    '            '------------------------------------------------------------------------------------------------------
    '            oI_ZonaVta.Value = IIf(.ZonaVenta = "DPCA", "TACR", .ZonaVenta)
    '            '------------------------------------------------------------------------------------------------------

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV", "ZDIP"    '-- % Descuento Manager/Asistente ¦ Vales de Descuento/Socios
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Information, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()

    '    Catch ex As Exception

    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty

    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_PG_VCJA(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oI_NumVa As Object          '--No. Vale de Caja
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        Dim oReturn As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oI_NumVa = objFunc.Exports("I_NUMVA")
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oI_NumVa.Value = .NumeroVale
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            oI_ZonaVta.Value = .ZonaVenta

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV", "ZDIP"    '-- % Descuento Manager/Asistente ¦ Vales de Descuento/Socios
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then

    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Information, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty


    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_FONACOT_FACILITO_DIPS(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis
    '        Dim I_CONTRATO As Object        '--Fecha de Contrato (Apartado)
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        Dim oReturn As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        'Validamos que sea Facturacion apartado para mandar la fecha.
    '        If UCase(oVentaFacturaSAP.NombreBAPI) = "ZBAPISD11_VENTAAPARTADO" Then
    '            I_CONTRATO = objFunc.Exports("I_CONTRATO")
    '            With oVentaFacturaSAP
    '                I_CONTRATO.value = .FechaApartado
    '            End With
    '        End If

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            oI_ZonaVta.Value = .ZonaVenta

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV", "ZDIP"    '-- % Descuento Manager/Asistente ¦ Vales de Descuento
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Information, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty

    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_DPVale(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_NumVa As Object          '--Numero de DPVale
    '        Dim oI_MontoInicial As Object   '--Monto DPVale
    '        Dim oI_CteDist As Object        '--Cliente Distribuidor
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        Dim oVale As Object             '--Indicador de posición
    '        Dim oCliente As Object          '--Indicados de posición
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        Dim oReturn As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_NumVa = objFunc.Exports("I_NUMVA")
    '        oI_MontoInicial = objFunc.Exports("I_MONTOINICIAL")
    '        oI_CteDist = objFunc.Exports("I_CTEDIST")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")
    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        oVale = objFunc.Imports("VALE")
    '        oCliente = objFunc.Imports("CLIENTE")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .CodigoCliente
    '            oI_ZonaVta.Value = .ZonaVenta
    '            oI_NumVa.Value = .NumeroVale
    '            oI_MontoInicial.Value = CStr(.MontoDPVale).Trim
    '            oI_CteDist.Value = .ClienteDistribuidor

    '            For Each oRow In .Detalle.Rows

    '                iCount += 1
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV"     '-- % Descuento Manager/Asistente ¦ Vales de Descuento
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Information, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception


    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty

    '    End Try

    'End Sub

    'Friend Sub Write_FacturaSAP_DPVale_SAP(ByVal oVentaFacturaSAP As VentasFacturaSAP)

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oClasePedido As Object      '--Clase Pedido
    '        Dim oOficinaVta As Object       '--Oficina de Ventas
    '        Dim oI_Agente As Object         '--Grupo de Vendedores
    '        Dim oI_Werks As Object          '--Centro
    '        Dim oI_Credito As Object        '--Indicador de una posicion
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        Dim oI_ZonaVta As Object        '--Zona de Ventas
    '        Dim oI_NumVa As Object          '--Numero de DPVale
    '        Dim oI_CteDist As Object        '--Cliente Distribuidor
    '        Dim oI_FACDPPRO As Object       '--Folio Factura Dportenis

    '        Dim oI_NUMDE As Object          '--Numero de Quincenas
    '        Dim oI_PARES_PZAS As Object     '--Numero de Pares Piezas
    '        Dim oI_MONTODPVALE As Object    '--Monto de DPvale
    '        Dim oI_MONTOUTILIZADO As Object '--Monto Utilizado
    '        Dim oI_REVALE As Object         '--X si se ocupa Revale
    '        Dim oI_RPARES_PZAS As Object    '--Pares Piezas de Revale
    '        Dim oI_RMONTODPVALE As Object   '--Monto de Revale
    '        Dim oI_Fecha As Object          '--Fecha Movimiento
    '        Dim oI_FechaCobro As Object     '--Fecha en la que se empezará a cobrar el primer abono
    '        Dim oI_ID As Object             '--ID de la Venta

    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oSalesDocument As Object    '--Documento de Ventas
    '        Dim oFIDocument As Object       '--Número de un Documento Contable
    '        Dim oVale As Object             '--Indicador de posición
    '        Dim oCliente As Object          '--Indicados de posición

    '        Dim oE_REVALE As Object         '--Numero de REVALE GENERADO
    '        '--Fin parametros Imports/

    '        '/--Tablas
    '        '--DatosDet
    '        Dim oStructureSAPDatos As Object
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Condiciones
    '        Dim oStructureSAPCondi As Object
    '        Dim oTbCondiciones As SAPTableFactoryCtrl.Table

    '        Dim oMesstab As Object
    '        Dim oReturn As Object
    '        '--Fin Tablas/

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            objR3 = Nothing
    '            Exit Sub
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add(oVentaFacturaSAP.NombreBAPI)

    '        '/--Exports
    '        oClasePedido = objFunc.Exports("CLASEPEDIDO")
    '        oOficinaVta = objFunc.Exports("OFICINAVTA")
    '        oI_Agente = objFunc.Exports("I_AGENTE")
    '        oI_Werks = objFunc.Exports("I_WERKS")
    '        oI_Credito = objFunc.Exports("I_CREDITO")
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        oI_ZonaVta = objFunc.Exports("I_ZONAVTA")
    '        oI_NumVa = objFunc.Exports("I_NUMVA")
    '        oI_CteDist = objFunc.Exports("I_CTEDIST")
    '        oI_FACDPPRO = objFunc.Exports("I_FACDPPRO")

    '        oI_NUMDE = objFunc.Exports("I_NUMDE")
    '        oI_PARES_PZAS = objFunc.Exports("I_PARES_PZAS")
    '        oI_MONTODPVALE = objFunc.Exports("I_MONTODPVALE")
    '        oI_MONTOUTILIZADO = objFunc.Exports("I_MONTOUTILIZADO")
    '        oI_REVALE = objFunc.Exports("I_REVALE")
    '        oI_RPARES_PZAS = objFunc.Exports("I_RPARES_PZAS")
    '        oI_RMONTODPVALE = objFunc.Exports("I_RMONTODPVALE")
    '        oI_Fecha = objFunc.Exports("I_Fecha")
    '        oI_FechaCobro = objFunc.Exports("I_FECCO")
    '        oI_ID = objFunc.Exports("I_ID")

    '        '--Fin Exports/

    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("DATOSDET")
    '        oTbCondiciones = objFunc.Tables("CONDICIONES")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oReturn = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        '/--Imports
    '        oSalesDocument = objFunc.Imports("SALESDOCUMENT")
    '        oFIDocument = objFunc.Imports("FIDOCUMENT")
    '        oVale = objFunc.Imports("VALE")
    '        oCliente = objFunc.Imports("CLIENTE")

    '        oE_REVALE = objFunc.Imports("E_REVALE")
    '        '--Fin Imports/

    '        '/--Captura de Info
    '        Dim iCount As Integer = 0
    '        Dim oRow As DataRow

    '        With oVentaFacturaSAP
    '            oI_FACDPPRO.value = .FacturaDP
    '            oClasePedido.Value = .ClasePedido
    '            oOficinaVta.Value = .OficinaVentas
    '            oI_Agente.Value = .Vendedor
    '            oI_Werks.Value = .Centro
    '            oI_Credito.Value = .Credito
    '            oI_Kunnr.Value = .ClienteDistribuidor
    '            oI_ZonaVta.Value = .ZonaVenta
    '            oI_NumVa.Value = .NumeroVale
    '            oI_CteDist.Value = .CodigoCliente

    '            oI_NUMDE.Value = .NUMDE

    '            oI_PARES_PZAS.Value = .PARES_PZAS
    '            oI_MONTODPVALE.Value = .MontoDPVale
    '            oI_MONTOUTILIZADO.Value = .MONTOUTILIZADO
    '            If .REVALE Then
    '                oI_REVALE.Value = "X"
    '            Else
    '                oI_REVALE.Value = String.Empty
    '            End If
    '            oI_RPARES_PZAS.Value = .RPARES_PZAS
    '            oI_RMONTODPVALE.Value = .RMONTODPVALE
    '            oI_Fecha.Value = Format(.FechaMovimiento, "dd/MM/yyyy")
    '            oI_FechaCobro.Value = Format(.FechaCobroDPVL, "dd/MM/yyyy")
    '            oI_ID.Value = .DPValeVentaID

    '            For Each oRow In .Detalle.Rows

    '                iCount += 10
    '                '--DatosDet
    '                oStructureSAPDatos = oTbDatosDet.AppendRow()
    '                oStructureSAPDatos.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                oStructureSAPDatos.Value("MATNR") = oRow!Codigo
    '                oStructureSAPDatos.Value("CANTIDAD") = CStr(oRow!Cantidad)
    '                oStructureSAPDatos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)

    '                '--Condiciones
    '                If oRow!Condicion <> String.Empty Then
    '                    oStructureSAPCondi = oTbCondiciones.AppendRow()
    '                    oStructureSAPCondi.Value("FOLIO") = CStr(iCount).PadLeft(4, "0")
    '                    oStructureSAPCondi.Value("MATNR") = oRow!Codigo
    '                    oStructureSAPCondi.Value("CONDICION") = oRow!Condicion
    '                    Select Case oRow!Condicion
    '                        Case "Z3AN", "ZRDV"     '-- % Descuento Manager/Asistente ¦ Vales de Descuento
    '                            'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
    '                        Case "Z501"             '-- Monto DPesos
    '                            oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Descuento)
    '                    End Select
    '                End If

    '            Next

    '        End With

    '        Dim b As Boolean

    '        b = objFunc.Call()

    '        If oSalesDocument.Value = String.Empty Or oFIDocument.Value = String.Empty Then
    '            Dim iRen As Integer
    '            Dim strError As String
    '            strError = String.Empty
    '            For iRen = 1 To oReturn.ROWCOUNT
    '                strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(oReturn(iRen, "message"))
    '            Next iRen

    '            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

    '            oVentaFacturaSAP.FolioSAP = String.Empty
    '            oVentaFacturaSAP.FolioFISAP = String.Empty
    '            oVentaFacturaSAP.FOLIOREVALE = String.Empty
    '        Else
    '            oVentaFacturaSAP.FolioSAP = oSalesDocument.Value
    '            oVentaFacturaSAP.FolioFISAP = oFIDocument.Value
    '            oVentaFacturaSAP.FOLIOREVALE = oE_REVALE.Value
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oVentaFacturaSAP.FolioSAP = String.Empty
    '        oVentaFacturaSAP.FolioFISAP = String.Empty
    '        oVentaFacturaSAP.FOLIOREVALE = String.Empty

    '    End Try

    'End Sub

    Friend Function ZBAPISD10_VENTA_DPVALE(ByRef oVentaFacturaSAP As VentasFacturaSAP) As Boolean

        Dim bDesconexion As Boolean = False

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                oVentaFacturaSAP.FolioSAP = String.Empty
                oVentaFacturaSAP.FolioFISAP = String.Empty
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD10_VENTA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD10_VENTA_DPVALE")
                Dim oRow As DataRow

                With oVentaFacturaSAP
                    func.Exports("I_FACDPPRO").ParamValue = .FacturaDP
                    func.Exports("CLASEPEDIDO").ParamValue = .ClasePedido
                    func.Exports("OFICINAVTA").ParamValue = .OficinaVentas
                    func.Exports("I_AGENTE").ParamValue = .Vendedor
                    func.Exports("CLASEPEDIDO").ParamValue = .ClasePedido
                    func.Exports("I_WERKS").ParamValue = .Centro
                    func.Exports("I_CREDITO").ParamValue = .Credito
                    func.Exports("I_KUNNR").ParamValue = .ClienteDistribuidor
                    func.Exports("I_ZONAVTA").ParamValue = .ZonaVenta
                    func.Exports("I_NUMVA").ParamValue = .NumeroVale
                    func.Exports("I_CTEDIST").ParamValue = .CodigoCliente
                    func.Exports("I_NUMDE").ParamValue = CStr(.NUMDE)
                    func.Exports("I_PARES_PZAS").ParamValue = CStr(.PARES_PZAS)
                    func.Exports("I_MONTODPVALE").ParamValue = .MontoDPVale
                    func.Exports("I_MONTOUTILIZADO").ParamValue = CStr(.MONTOUTILIZADO)
                    If .REVALE Then
                        func.Exports("I_REVALE").ParamValue = "X"
                    Else
                        func.Exports("I_REVALE").ParamValue = ""
                    End If
                    func.Exports("I_RPARES_PZAS").ParamValue = CStr(.RPARES_PZAS)
                    func.Exports("I_RMONTODPVALE").ParamValue = .RMONTODPVALE
                    func.Exports("I_FECHA").ParamValue = Format(.FechaMovimiento, "dd/MM/yyyy")
                    func.Exports("I_FECCO").ParamValue = Format(.FechaCobroDPVL, "dd/MM/yyyy")
                    func.Exports("I_ID").ParamValue = .DPValeVentaID

                    ''-----------------------------------------------------------------------
                    ''JNAVA (06.01.2015): DPV-077-Seguro de Vida en Calzado
                    ''-----------------------------------------------------------------------
                    'If oVentaFacturaSAP.SeguroDPVL Then
                    '    func.Exports("I_ZSEG").ParamValue = "1"
                    'Else
                    '    func.Exports("I_ZSEG").ParamValue = "0"
                    'End If

                    '---------------------------------------------------------------------------------------------------------------------------
                    'FLIZARRAGA 11/10/2015: Valida si desea el cargo del seguro de vida del DPVale
                    '---------------------------------------------------------------------------------------------------------------------------
                    func.Exports("I_ZSEG").ParamValue = .ZSEG

                    '---------------------------------------------------------------------------------------------------------------------------
                    'RGERMAIN 29.05.2015: Se envian el importe del seguro de vida y el folio del acreedor obtenidos de SQL a la RFC de SAP
                    '---------------------------------------------------------------------------------------------------------------------------
                    func.Exports("I_IMPSEG").ParamValue = .ImpSegDPVL
                    func.Exports("I_FOLSEG").ParamValue = .FolSegDPVL

                    '---------------------------------------------------------------------------------------------------------------------------
                    'JNAVA 09.06.2015: Se envian la divicion obtenida de SQL a la RFC de SAP
                    '---------------------------------------------------------------------------------------------------------------------------
                    func.Exports("I_DIVP").ParamValue = .DivPDPVL

                    Dim T_Datos As ERPConnect.RFCTable = func.Tables("DATOSDET")
                    Dim T_Cond As ERPConnect.RFCTable = func.Tables("CONDICIONES")
                    Dim R_Lines As ERPConnect.RFCStructure, R_LinesCond As ERPConnect.RFCStructure
                    Dim i As Integer = 0

                    For Each oRow In .Detalle.Rows
                        i += 10
                        R_Lines = T_Datos.AddRow
                        R_Lines("FOLIO") = CStr(i).Trim.PadLeft(4, "0")
                        R_Lines("MATNR") = oRow!Codigo
                        R_Lines("CANTIDAD") = CStr(oRow!Cantidad)
                        R_Lines("TALLA") = oParent.FormatTalla(oRow!Talla)
                        '--Condiciones
                        If oRow!Condicion <> "" Then
                            R_LinesCond = T_Cond.AddRow()
                            R_LinesCond("FOLIO") = CStr(i).PadLeft(4, "0")
                            R_LinesCond("MATNR") = oRow!Codigo
                            R_LinesCond("CONDICION") = oRow!Condicion
                            Select Case oRow!Condicion
                                Case "ZDP4", "ZRDV"     '-- % Descuento Manager/Asistente ¦ Vales de Descuento
                                    'oStructureSAPCondi.Value("IMPORTE") = CStr(oRow!Adicional)
                                    R_LinesCond("IMPORTE") = CStr(Math.Round(CDec(oRow!Adicional), 2))
                                Case "Z501"             '-- Monto DPesos
                                    R_LinesCond("IMPORTE") = CStr(oRow!Descuento)
                            End Select
                        End If
                    Next
                End With

                func.Execute()

                R3.Close()

                oVentaFacturaSAP.FolioSAP = CStr(func.Imports("SALESDOCUMENT").ParamValue).Trim
                oVentaFacturaSAP.FolioFISAP = CStr(func.Imports("FIDOCUMENT").ParamValue).Trim
                oVentaFacturaSAP.FOLIOREVALE = CStr(func.Imports("E_REVALE").ParamValue).Trim
                'RGERMAIN 28.04.2015: Obtenemos el resultado de la generacion del seguro de vida en DPVale
                If CStr(func.Imports("E_SEGGEN").ParamValue).Trim = "X" Then
                    oVentaFacturaSAP.SeguroDPVL = True
                Else
                    oVentaFacturaSAP.SeguroDPVL = False
                End If

                '-----------------------------------------------------------------------------------------------
                ' JNAVA (02.06.2015): Agregamos el campo con el Motivo De No Generarse Seguro
                '-----------------------------------------------------------------------------------------------
                oVentaFacturaSAP.RechazoSeguro = CStr(func.Imports("E_ZRECH").ParamValue)

                If oVentaFacturaSAP.FolioSAP.Trim = "" OrElse oVentaFacturaSAP.FolioFISAP = "" Then
                    Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable
                    Dim strError = ""
                    For Each oRow In dtReturn.Rows
                        strError = strError & vbCrLf & CStr(oRow!Message).Trim
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")

                    oVentaFacturaSAP.FolioSAP = ""
                    oVentaFacturaSAP.FolioFISAP = ""
                    oVentaFacturaSAP.FOLIOREVALE = ""
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            bDesconexion = True
            'Throw e1
            MsgBox(e1.ToString, MsgBoxStyle.Exclamation, "Dportenis PRO")
        Catch e1 As ERPConnect.ERPException
            bDesconexion = True
            'Throw e1
            MsgBox(e1.ToString, MsgBoxStyle.Exclamation, "Dportenis PRO")
        Catch e1 As Exception
            Throw e1
        End Try

        Return bDesconexion

    End Function

    Friend Sub ZDPVL_REINTENTOVENTA(ByRef oVentaFacturaSAP As VentasFacturaSAP)

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZDPVL_REINTENTOVENTA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_REINTENTOVENTA")
                Dim strResult As String = "", strError As String = "", zactivas As ERPConnect.RFCStructure

                func.Exports("I_ID").ParamValue = oVentaFacturaSAP.DPValeVentaID

                func.Execute()
                R3.Close()

                strResult = func.Imports("E_RETURN").ParamValue
                strError = func.Imports("E_ERROR").ParamValue
                zactivas = func.Imports("E_RESULTADO").ToStructure()
                If CInt(strResult) <> 0 Then
                    MsgBox(strError, MsgBoxStyle.Exclamation, "Error")
                Else
                    oVentaFacturaSAP.FolioSAP = CStr(zactivas("SALESDOCUMENT")).Trim
                    oVentaFacturaSAP.FolioFISAP = CStr(zactivas("FIDOCUMENT")).Trim
                    oVentaFacturaSAP.FOLIOREVALE = CStr(zactivas("E_REVALE")).Trim
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Catch e1 As Exception
            Throw e1
        End Try

    End Sub

    Friend Sub ZDPVL_LOGACTIVAS_FINALIZAR(ByVal DPValeVentaID As String)

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZDPVL_LOGACTIVAS_FINALIZAR
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_LOGACTIVAS_FINALIZAR")

                func.Exports("I_ID").ParamValue = DPValeVentaID

                func.Execute()

                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Catch e1 As Exception
            Throw e1
        End Try

    End Sub

    'Friend Function Read_CreditoAsociadoSAP(ByVal IDAsociadoSAP As String) As CreditoAsociadoSAP

    '    Dim oResult As New CreditoAsociadoSAP

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oI_Kunnr As Object          '--Número de Cliente
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oLimite As Object           '--Documento de Ventas
    '        Dim oCredito As Object          '--Número de un Documento Contable
    '        Dim oBloqueado As Object        '--Indicador de posición
    '        '--Fin parametros Imports/


    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            objR3 = Nothing
    '            Exit Function
    '        End If

    '        '--Implementamos Nombre BAPI
    '        objFunc = objR3.Add("ZBAPI_LIMITECREDITO")

    '        '/--Exports
    '        oI_Kunnr = objFunc.Exports("I_KUNNR")
    '        '--Fin Exports/

    '        '/--Imports
    '        oLimite = objFunc.Imports("LIMITE")
    '        oCredito = objFunc.Imports("CREDITO")
    '        oBloqueado = objFunc.Imports("BLOQUEADO")
    '        '--Fin Imports/

    '        '/--Captura de Info --Cargamos parametros BAPI
    '        oI_Kunnr.Value = IDAsociadoSAP

    '        Dim b As Boolean
    '        b = objFunc.Call()

    '        If b Then
    '            oResult.CodigoAsociadoSAP = IDAsociadoSAP
    '            oResult.LimiteCredito = oLimite.Value
    '            oResult.Credito = oCredito.Value
    '            oResult.Bloqueado = oBloqueado.Value
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oResult.CodigoAsociadoSAP = String.Empty
    '        oResult.LimiteCredito = 0
    '        oResult.Credito = 0
    '        oResult.Bloqueado = "S"


    '    End Try

    '    Return oResult

    'End Function

    'Friend Function Read_CreditoAsociadoSAP(ByVal IDAsociadoSAP As String) As CreditoAsociadoSAP
    '    '----------------------------------------------------------------------------------
    '    ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
    '    '----------------------------------------------------------------------------------
    '    Dim oResult As New CreditoAsociadoSAP
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPI_LIMITECREDITO     ****
    '            '*****************************************************
    '            ' Create a function object
    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_LIMITECREDITO")

    '            'Captura de Info
    '            func.Exports("I_Kunnr").ParamValue = IDAsociadoSAP

    '            'Ejecutamos RFC
    '            func.Execute()

    '            'Obtenemos datos
    '            oResult.CodigoAsociadoSAP = IDAsociadoSAP
    '            oResult.LimiteCredito = func.Imports("LIMITE").ParamValue
    '            oResult.Credito = func.Imports("CREDITO").ParamValue
    '            oResult.Bloqueado = func.Imports("BLOQUEADO").ParamValue

    '            R3.Close()

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        oResult.CodigoAsociadoSAP = String.Empty
    '        oResult.LimiteCredito = 0
    '        oResult.Credito = 0
    '        oResult.Bloqueado = "S"
    '    Catch e1 As ERPConnect.ERPException
    '        oResult.CodigoAsociadoSAP = String.Empty
    '        oResult.LimiteCredito = 0
    '        oResult.Credito = 0
    '        oResult.Bloqueado = "S"
    '    End Try

    '    Return oResult

    'End Function


#End Region

#Region "Traspaso SAP salida-Pedido"

    '---------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 25/03/2014: Se realiza el traslado de defectuoso
    '---------------------------------------------------------------------------------------------------------------------

    Public Function ZMM_PROCESO_ENVIO_DEFECTUOSOS(ByVal ImportParameter As Hashtable, ByRef ExportParameter As Hashtable, ByVal dtMateriales As DataTable) As DataTable
        Dim dsResultado As New DataTable
        Dim strCentroOrigen As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIMM14_DESBLOQUEOART         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_PROCESO_ENVIO_DEFECTUOSOS")
                strCentroOrigen = oParent.Read_Centros()
                func.Exports("I_Centro").ParamValue = strCentroOrigen
                '---------------------------------------------------------------------------------------------------------------------
                'FLIZARRAGA 18/07/2016: Se cambio al almacen M009 porque es el almacen de Defectuosos por Dora Leonor
                '---------------------------------------------------------------------------------------------------------------------
                func.Exports("I_ALMACENTIENDA").ParamValue = "M009"
                func.Exports("I_ALMACENDEF").ParamValue = "M007"
                func.Exports("I_GUIA").ParamValue = CStr(ImportParameter("guia"))
                func.Exports("I_BULTO").ParamValue = CStr(ImportParameter("bulto"))
                If CStr(ImportParameter("transportista")) = "MISMOS" Then
                    func.Exports("I_TRANSPORTISTA").ParamValue = "CLIENTE"
                Else
                    func.Exports("I_TRANSPORTISTA").ParamValue = CStr(ImportParameter("transportista"))
                End If
                func.Exports("I_TRANSPORTISTA").ParamValue = CStr(ImportParameter("transportista"))
                func.Exports("I_CONTRATO").ParamValue = CStr(ImportParameter("FolioDesbloqueo"))
                func.Exports("I_FECHA").ParamValue = CStr(Format(MSS_GET_SY_DATE_TIME(), "dd/MM/yyyy"))
                func.Exports("I_TEXTO_CABECERA").ParamValue = CStr(ImportParameter("observaciones"))
                func.Exports("I_MOTIVO").ParamValue = CStr(ImportParameter("MotivoDevolucion"))
                Dim t_materiales As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim ZTABLA_APARTADO As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim R_Row As ERPConnect.RFCStructure
                Dim oRow As DataRow
                For Each oRow In dtMateriales.Rows

                    R_Lines = t_materiales.AddRow

                    R_Lines("CENTRO_DESTINO") = "1000"
                    R_Lines("MATNR") = CStr(oRow("CodArticulo"))
                    R_Lines("MENGE") = oRow("Cantidad")
                    If IsNumeric(CStr(oRow!Talla)) Then
                        R_Lines("TALLA") = Format(CDec(oRow("Talla")), "##.0")
                    Else
                        R_Lines("TALLA") = CStr(oRow("Talla"))
                    End If
                    R_Lines("MOTIVO_PEDIDO") = CStr(oRow("MotivoDefectuoso").ToString)
                    R_Lines("CLAVE_CONFIRM") = "0004"
                    R_Lines("ALMACEN") = "M009"
                    R_Row = ZTABLA_APARTADO.AddRow
                    R_Row("CENTRO") = strCentroOrigen
                    R_Row("CONTRATO") = CStr(ImportParameter("FolioDesbloqueo"))
                    R_Row("MATNR") = CStr(oRow("CodArticulo"))
                    R_Row("CANTIDAD") = oRow("Cantidad")

                    If IsNumeric(CStr(oRow!Talla)) Then
                        R_Row("TALLA") = Format(CDec(oRow("Talla")), "##.0")
                    Else
                        R_Row("TALLA") = CStr(oRow("Talla"))
                    End If
                Next

                func.Execute()
                R3.Close()

                Dim strError As String = CStr(func.Imports("E_ERROR").ParamValue)
                ExportParameter("E_ERROR") = strError
                dsResultado = func.Tables("T_RETURN").ToADOTable()
                If strError.Trim() = "X" Then
                    Dim mensaje As String = ""
                    For Each row As DataRow In dsResultado.Rows
                        mensaje &= CStr(row("MESSAGE")) & vbCrLf
                    Next
                    ExportParameter("MensajeError") = mensaje
                Else
                    ExportParameter("E_DOCFI_DESBLOQUEO") = func.Imports("E_DOCFI_DESBLOQUEO").ParamValue
                    ExportParameter("E_NUMTRASLADO") = func.Imports("E_NUMTRASLADO").ParamValue
                    ExportParameter("E_MATERIALDOCUMENT") = func.Imports("E_MATERIALDOCUMENT").ParamValue
                    ExportParameter("E_DOCFI_BLOQUEO") = func.Imports("E_DOCFI_BLOQUEO").ParamValue
                End If

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return dsResultado
    End Function

    '"Traspaso salida-Pedido"

    'Friend Function Write_pedidotrasSAPMM02(ByVal oArticulos() As ZDP_PRODAPARTADO, ByVal strAlmacen As String) As String
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strCentroOrigen As String
    '        Dim strCentroDestino As String

    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_ARTICULOS As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CENTRO_ORIGEN As SAPFunctionsOCX.Parameter      'MSEG-WERKS  CENTRO
    '        Dim CENTRO_DESTINO As SAPFunctionsOCX.Parameter     'MSEG-WERKS  CENTRO
    '        Dim I_FECHA As SAPFunctionsOCX.Parameter            'FECHA MOVIEMIENTO
    '        ' Definición de los parámetros para el EXPORT de la función SAP
    '        Dim NUMPEDMM02 As SAPFunctionsOCX.Parameter
    '        Dim ME21N As SAPFunctionsOCX.Parameter
    '        Dim ALMACEN_DESTINO As SAPFunctionsOCX.Parameter     'ALMACEN

    '        strCentroOrigen = oParent.Read_Centros()

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIMM02_PEDIDOTRAS ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM02_PEDIDOTRAS")

    '            ' Ajusta los parámetros de delimitación de entrada
    '            CENTRO_ORIGEN = myFunc.Exports("CENTRO_ORIGEN")
    '            CENTRO_DESTINO = myFunc.Exports("CENTRO_DESTINO")
    '            I_FECHA = myFunc.Exports("I_FECHA")

    '            ' Ajusta los parámetros de delimitación de Salida
    '            NUMPEDMM02 = myFunc.Imports("NUMPEDMM02")
    '            ME21N = myFunc.Imports("ME21N")
    '            ALMACEN_DESTINO = myFunc.Exports("ALMACEN_DESTINO")


    '            ' Cargar la tabla con los datos que vamos a enviar - TABLES.
    '            objtabretTABLA_ARTICULOS = myFunc.Tables("PEDIDO")
    '            objtabretReturn = myFunc.Tables("RETURN")


    '            For i As Integer = 0 To oArticulos.Length - 1
    '                oStructureSAP = objtabretTABLA_ARTICULOS.AppendRow()
    '                oStructureSAP.Value("CENTRO_DESTINO") = oArticulos(i).Contrato
    '                oStructureSAP.Value("MATNR") = oArticulos(i).Matnr
    '                oStructureSAP.Value("MENGE") = oArticulos(i).Cantidad
    '                oStructureSAP.Value("TALLA") = oArticulos(i).Talla
    '                strCentroDestino = oArticulos(i).Contrato
    '            Next i

    '            ' Asigno valores a los objetos
    '            CENTRO_ORIGEN.Value = strCentroOrigen
    '            CENTRO_DESTINO.Value = strCentroDestino
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))
    '            ALMACEN_DESTINO.Value = strAlmacen

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()


    '            If ME21N.Value = "Y" Then 'me traigo los campos
    '                Return CStr(NUMPEDMM02.Value)
    '            Else
    '                Dim iRen As Integer
    '                Dim strError As String
    '                strError = String.Empty
    '                For iRen = 1 To objtabretReturn.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(objtabretReturn(iRen, "message"))
    '                Next iRen

    '                MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                Return String.Empty
    '            End If

    '        End If

    '    Catch ex As Exception

    '        Throw New ApplicationException(ex.Message, ex)

    '    End Try
    'End Function

    Friend Function Write_pedidotrasSAPMM02(ByVal oArticulos() As ZDP_PRODAPARTADO, ByVal strAlmacen As String, Optional ByVal guias As Hashtable = Nothing) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim strCentroOrigen As String = oParent.Read_Centros()
        Dim strCentroDestino As String

        ' Se definen los parámetros TABLE            
        Dim dtReturn As New DataTable
        Dim strReturn As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM02_PEDIDOTRAS     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM02_PEDIDOTRAS")

                ' Asigno valores a los objetos
                func.Exports("CENTRO_ORIGEN").ParamValue = strCentroOrigen
                func.Exports("CENTRO_DESTINO").ParamValue = oArticulos(0).Contrato
                'func.Exports("CENTRO_DESTINO").ParamValue = strCentroDestino
                func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))
                func.Exports("ALMACEN_DESTINO").ParamValue = strAlmacen
                If guias.ContainsKey("doc_type") Then
                    func.Exports("I_DOC_TYPE").ParamValue = guias("doc_type")
                Else
                    func.Exports("I_DOC_TYPE").ParamValue = "ZTRA"
                End If
                If guias.ContainsKey("AlmacenOrigen") Then
                    func.Exports("ALMACEN_ORIGEN").ParamValue = CStr(guias("AlmacenOrigen"))
                End If
                func.Exports("I_GUIA").ParamValue = CStr(guias("Guia"))
                func.Exports("I_BULTO").ParamValue = CStr(guias("Bultos"))
                func.Exports("I_TRANSPORTISTA").ParamValue = CStr(guias("Transportista"))
                func.Exports("I_MOTIVO").ParamValue = CStr(guias("MotivoDevolucion"))
                ' Cargar la tabla con los datos que vamos a enviar - TABLES.
                Dim T_CLines As ERPConnect.RFCTable = func.Tables("PEDIDO")
                For Each oArticulo As ZDP_PRODAPARTADO In oArticulos
                    Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                    R_CLines("CENTRO_DESTINO") = strCentroOrigen
                    R_CLines("MOTIVO_PEDIDO") = oArticulo.MotivoDefectuoso
                    R_CLines("CLAVE_CONFIRM") = oArticulo.ClaveConfirm
                    R_CLines("MATNR") = oArticulo.Matnr
                    If oArticulo.Serie.Trim() <> "" Then
                        R_CLines("SERIE") = oArticulo.Serie
                    Else
                        R_CLines("SERIE") = ""
                    End If
                    R_CLines("MENGE") = oArticulo.Cantidad
                    R_CLines("TALLA") = oArticulo.Talla
                    If guias.ContainsKey("AlmacenOrigen") Then
                        R_CLines("ALMACEN") = CStr(guias("AlmacenOrigen"))
                    End If
                Next

                'Ejecutamos RFC
                func.Execute()

                R3.Close()


                'Obtenemos datos
                dtReturn = func.Tables("RETURN").ToADOTable


                If func.Imports("ME21N").ParamValue = "Y" Then
                    strReturn = CStr(func.Imports("NUMPEDMM02").ParamValue)
                    guias("NUMDOCMAT") = CStr(func.Imports("NUMDOCMAT").ParamValue)
                Else
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr((row("MESSAGE")))
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    strReturn = String.Empty
                End If

            End If

            Return strReturn

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Traspaso SAP salida-traspaso"

    '"Traspaso salida-traspaso"

    'Friend Function Write_TrasladoSAPMM02(ByVal strpedido As String, ByVal strTXTCAB As String, ByVal strAlmacenDestino As String) As String

    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strcentro_origen As String


    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_PEDIDOS As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CLASE_MOVIMIENTO As SAPFunctionsOCX.Parameter   '
    '        Dim CENTRO_ORIGEN As SAPFunctionsOCX.Parameter      '
    '        Dim VALE_MATERIAL As SAPFunctionsOCX.Parameter      '
    '        Dim TEXTO_CABECERA As SAPFunctionsOCX.Parameter     '
    '        Dim NUMPEDIDO As SAPFunctionsOCX.Parameter          '
    '        Dim NUMDOC As SAPFunctionsOCX.Parameter
    '        Dim AlmacenPro As SAPFunctionsOCX.Parameter
    '        Dim I_FECHA As SAPFunctionsOCX.Parameter            'Fecha Movimiento
    '        Dim MB1B As SAPFunctionsOCX.Parameter

    '        strcentro_origen = oParent.Read_Centros()

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIMM02_TRASLADO ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM02_TRASLADO")

    '            ' Ajusta los parámetros de delimitación de entrada

    '            CENTRO_ORIGEN = myFunc.Exports("CENTRO_ORIGEN")
    '            NUMPEDIDO = myFunc.Exports("NUMPEDIDO")
    '            I_FECHA = myFunc.Exports("I_FECHA")
    '            TEXTO_CABECERA = myFunc.Exports("TEXTO_CABECERA")
    '            AlmacenPro = myFunc.Exports("I_ALMACENPRO")

    '            'Parametros de Salida
    '            NUMDOC = myFunc.Imports("NUMDOC")
    '            MB1B = myFunc.Imports("MB1B")

    '            ' Cargar la tabla con los datos que vamos a enviar - TABLES.
    '            objtabretReturn = myFunc.Tables("RETURN")

    '            ' Asigno valores a los objetos
    '            CENTRO_ORIGEN.Value = strcentro_origen
    '            NUMPEDIDO.Value = strpedido
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))
    '            TEXTO_CABECERA.Value = strTXTCAB
    '            AlmacenPro.Value = strAlmacenDestino


    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            'If Result Then 'me traigo los campos
    '            '    Return CStr(NUMDOC.Value)
    '            'Else
    '            '    Return String.Empty
    '            'End If

    '            If MB1B.Value = "Y" Then
    '                Return CStr(NUMDOC.Value)
    '            Else
    '                Dim iRen As Integer
    '                Dim strError As String
    '                strError = String.Empty
    '                For iRen = 1 To objtabretReturn.ROWCOUNT
    '                    strError = strError & Microsoft.VisualBasic.vbCrLf & CStr(objtabretReturn(iRen, "message"))
    '                Next iRen

    '                MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

    '                Return String.Empty
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Function

    Friend Function Write_TrasladoSAPMM02(ByVal strpedido As String, ByVal strTXTCAB As String, ByVal strAlmacenDestino As String) As String

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim strCentroOrigen As String = oParent.Read_Centros()

        ' Se definen los parámetros TABLE            
        Dim dtReturn As New DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM02_TRASLADO     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM02_TRASLADO")

                ' Asigno valores a los objetos
                func.Exports("CENTRO_ORIGEN").ParamValue = strCentroOrigen
                func.Exports("NUMPEDIDO").ParamValue = strpedido
                func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))
                func.Exports("TEXTO_CABECERA").ParamValue = strTXTCAB
                func.Exports("I_ALMACENPRO").ParamValue = strAlmacenDestino

                'Ejecutamos RFC
                func.Execute()
                R3.Close()

                'Obtenemos datos
                dtReturn = func.Tables("RETURN").ToADOTable

                If func.Imports("MB1B").ParamValue = "Y" Then
                    Return CStr(func.Imports("NUMDOC").ParamValue)
                Else
                    Dim strError As String
                    strError = String.Empty
                    For Each row As DataRow In dtReturn.Rows
                        strError = strError & Microsoft.VisualBasic.vbCrLf & CStr((row("MESSAGE")))
                    Next

                    MsgBox(strError, MsgBoxStyle.Exclamation, "Dportenis PRO")

                    Return String.Empty
                End If



            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Friend Function ZMM_TRASLADO_ME22N(ByVal Traslado As String, ByVal dtMateriales As DataTable) As String

        Dim strRes As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMM_TRASLADO_ME22N             ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_TRASLADO_ME22N")

                func.Exports("I_TRASLADO").ParamValue = Traslado.Trim.PadLeft(10, "0")

                Dim oRow As DataRow
                Dim T_Materiales As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim R_Lines As ERPConnect.RFCStructure

                For Each oRow In dtMateriales.Rows
                    R_Lines = T_Materiales.AddRow
                    R_Lines("MATERIAL") = CStr(oRow!CodArticulo).Trim
                    If IsNumeric(CStr(oRow!Talla)) Then
                        R_Lines("Talla") = Format(CDec(oRow!Talla), "#.0")
                    Else
                        R_Lines("Talla") = CStr(oRow!Talla).Trim
                    End If
                    R_Lines("Cantidad") = CInt(oRow!Cantidad)
                Next

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""
                Dim dtMsg As DataTable

                strRes = func.Imports("E_ERROR").ToString
                dtMsg = func.Tables("TRETURN").ToADOTable

                If strRes.Trim.ToUpper = "X" Then
                    For Each oRow In dtMsg.Rows
                        strMsg &= CStr(oRow!Message).Trim
                    Next
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al agregar posiciones al traslado en SAP")
                End If

                strRes = strMsg.Trim

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZMM_351_PIEZAS_RESTANTES(ByVal Traslado As String) As String

        Dim strRes As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMM_351_PIEZAS_RESTANTES       ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_351_PIEZAS_RESTANTES")

                func.Exports("I_TRASLADO").ParamValue = Traslado.Trim.PadLeft(10, "0")

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""
                Dim dsMsg As New DataSet("Messages")

                strRes = func.Imports("E_ERROR").ToString
                dsMsg.Tables.Add(func.Tables("IT_RETURN").ToADOTable)
                dsMsg.Tables.Add(func.Tables("T_NO_APLICADOS").ToADOTable)

                If strRes.Trim.ToUpper = "X" Then
                    Dim oRow As DataRow
                    For Each oRow In dsMsg.Tables(0).Rows
                        strMsg &= CStr(oRow!Message).Trim
                    Next
                    If strMsg.Trim <> "" Then strMsg &= vbCrLf & vbCrLf
                    For Each oRow In dsMsg.Tables(1).Rows
                        strMsg &= CStr(oRow!Material).Trim & "".PadLeft(3, " ") & CStr(oRow!Talla).Trim & "".PadLeft(3, " ") & CStr(oRow!Cantidad).Trim
                    Next
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al agregar posiciones al traslado en SAP")
                End If

                strRes = strMsg.Trim

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

#End Region

#Region "Traspaso SAP Entrada-traspaso"

    '"Traspaso salida-traspaso"

    'Friend Function Write_TrasladoEntradaSAPMM02(ByVal strpedido As String) As String

    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim strcentro_destino As String

    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_PEDIDOS As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim NUMPEDIDO As SAPFunctionsOCX.Parameter          '
    '        Dim CENTRO_DESTINO As SAPFunctionsOCX.Parameter     '
    '        Dim I_FECHA As SAPFunctionsOCX.Parameter            'Fecha Movimiento

    '        Dim NUMPEDMB01 As SAPFunctionsOCX.Parameter
    '        Dim APLICADO As SAPFunctionsOCX.Parameter

    '        strcentro_destino = oParent.Read_Centros()

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            Throw New ApplicationException("No se pudo establecer la conexión con SAP.")
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPIMM02_MB01 ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPIMM02_MB01")

    '            ' Ajusta los parámetros de delimitación de entrada

    '            CENTRO_DESTINO = myFunc.Exports("CENTRO_DESTINO")
    '            NUMPEDIDO = myFunc.Exports("NUMPEDIDO")
    '            I_FECHA = myFunc.Exports("I_FECHA")

    '            NUMPEDMB01 = myFunc.Imports("NUMPEDMB01")
    '            APLICADO = myFunc.Imports("APLICADO")

    '            ' Asigno valores a los objetos
    '            CENTRO_DESTINO.Value = strcentro_destino
    '            NUMPEDIDO.Value = strpedido
    '            I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()

    '            If Result Then 'me traigo los campos
    '                If CStr(APLICADO.Value) = "E" Then
    '                    MsgBox("Error al Tratar de Aplicar el Traslado en SAP", MsgBoxStyle.Critical, "Error al Aplicar Traslado")
    '                ElseIf CStr(APLICADO.Value) = "I" Then
    '                    MsgBox("El traslado se aplico incompleto favor de comunicar a soporte" & _
    '                    Microsoft.VisualBasic.vbCrLf & " para evitar diferencias en inventario.", MsgBoxStyle.Critical, "Error al Aplicar Traslado")
    '                End If

    '                Return CStr(NUMPEDMB01.Value)
    '            Else
    '                Return String.Empty
    '            End If

    '        End If

    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Function

    Friend Function Write_TrasladoEntradaSAPMM02(ByVal strpedido As String) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim strCentroDestino As String = oParent.Read_Centros()

        ' Se definen los parámetros TABLE            
        Dim dtReturn As New DataTable
        Dim StrNUMPEDMB01 As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM02_TRASLADO     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM02_TRASLADO")

                ' Asigno valores a los objetos
                func.Exports("CENTRO_DESTINO").ParamValue = strCentroDestino
                func.Exports("NUMPEDIDO").ParamValue = strpedido
                func.Exports("I_FECHA").ParamValue = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                dtReturn = func.Tables("RETURN").ToADOTable
                StrNUMPEDMB01 = func.Imports("NUMPEDMB01").ParamValue


                If StrNUMPEDMB01 <> String.Empty Then 'me traigo los campos
                    If CStr(func.Imports("APLICADO").ParamValue) = "E" Then
                        MsgBox("Error al Tratar de Aplicar el Traslado en SAP", MsgBoxStyle.Critical, "Error al Aplicar Traslado")
                    ElseIf CStr(func.Imports("APLICADO").ParamValue) = "I" Then
                        MsgBox("El traslado se aplico incompleto favor de comunicar a soporte" & _
                        Microsoft.VisualBasic.vbCrLf & " para evitar diferencias en inventario.", MsgBoxStyle.Critical, "Error al Aplicar Traslado")
                    End If

                    Return CStr(func.Imports("NUMPEDMB01").ParamValue)
                Else
                    Return String.Empty
                End If



            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

#End Region

#Region "Lista Traspasos en Espera"

    Public Function Read_TraspasosPendientesXgrabar(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal strI_EBELN As String, ByVal strGeneral As String, ByVal Centro As String, ByVal Material As String) As DataTable
        Dim resultado As DataTable = Nothing
        Try
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM02_REVISARTRASPASOTEMP
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM02_REVISARTRASPASOTEMP")
                If Centro.Trim = "" Then Centro = oParent.Read_Centros()
                func.Exports("I_WERKS").ParamValue = Centro
                func.Exports("I_FECHAINI").ParamValue = FechaInicio.ToString("yyyyMMdd")
                func.Exports("I_FECHAFIN").ParamValue = FechaFin.ToString("yyyyMMdd")
                func.Exports("I_EBELN").ParamValue = strI_EBELN
                'func.Exports("GENERAL").ParamValue = strGeneral

                'func.Exports("I_TODOS").ParamValue = ""
                'func.Exports("I_DETALLADO").ParamValue = "X"
                If Material.Trim() <> "" Then
                    func.Exports("I_MATERIAL").ParamValue = Material.Trim().ToUpper()
                End If
                'func.Exports("I_MATERIAL").ParamValue = Material.Trim.ToUpper
                func.Execute()

                R3.Close()

                resultado = func.Tables("ZTRASLADOS").ToADOTable()

                '------------------------------------------------------------------------------------
                ' JNAVA (07.03.2016): Se formatea la fecha
                '------------------------------------------------------------------------------------
                Dim strFecha As String = ""
                For Each oRow As DataRow In resultado.Rows
                    strFecha = oRow!AEDAT
                    oRow!AEDAT = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                Next
                '------------------------------------------------------------------------------------

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return resultado
    End Function

    'Friend Function Read_TraspasosEspera(ByVal dateFechaini As Date, ByVal dateFechaFin As Date, ByVal strI_EBELN As String, ByVal strGENERAL As String, _
    '                                     ByVal RecibirParcial As Boolean, Optional ByRef bRes As Boolean = True, Optional ByVal Centro As String = "") As DataTable

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim objRes As Object
    '        Dim bResultado As Boolean

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim I_WERKS As SAPFunctionsOCX.Parameter     'MSEG-WERKS  CENTRO
    '        Dim I_FECHAINI As SAPFunctionsOCX.Parameter
    '        Dim I_FECHAFIN As SAPFunctionsOCX.Parameter
    '        Dim I_EBELN As SAPFunctionsOCX.Parameter
    '        Dim GENERAL As SAPFunctionsOCX.Parameter

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            bRes = False
    '            Exit Function
    '        End If


    '        If RecibirParcial = False Then
    '            objFunc = objR3.Add("ZBAPIMM02_REVISARTRASPASO")
    '        Else
    '            objFunc = objR3.Add("ZBAPIMM02_REVISARTRASPASOTEMP")
    '        End If
    '        'objFunc = objR3.Add("ZBAPIMM02_REVISARTRASPASO")
    '        objRes = objFunc.Tables("ZTRASLADOS")

    '        ' Ajusta los parámetros de delimitación de entrada

    '        I_WERKS = objFunc.Exports("I_WERKS")
    '        I_FECHAINI = objFunc.Exports("I_FECHAINI")
    '        I_FECHAFIN = objFunc.Exports("I_FECHAFIN")
    '        I_EBELN = objFunc.Exports("I_EBELN")
    '        GENERAL = objFunc.Exports("GENERAL")

    '        ' Asigno valores a los objetos
    '        If Centro.Trim = "" Then Centro = oParent.Read_Centros()
    '        I_WERKS.Value = Centro.Trim
    '        I_FECHAINI.Value = dateFechaini
    '        I_FECHAFIN.Value = dateFechaFin
    '        I_EBELN.Value = strI_EBELN
    '        GENERAL.Value = strGENERAL

    '        bResultado = objFunc.Call
    '        objR3.Connection.LogOff()

    '        If bResultado Then
    '            Dim irow As Integer = 0
    '            'Tabla para meter los resultados de la BAPI
    '            Dim dtZTRASLADOS As New DataTable("ZTRASLADOS")
    '            If strGENERAL = "S" Then
    '                dtZTRASLADOS.Columns.Add("Referencia", objRes.ColumnName(1).GetType)
    '                dtZTRASLADOS.Columns.Add("Status", objRes.ColumnName(1).GetType)
    '                dtZTRASLADOS.Columns.Add("S. Almacen", objRes.ColumnName(1).GetType)
    '                dtZTRASLADOS.Columns.Add("S. Destino", objRes.ColumnName(1).GetType)
    '                dtZTRASLADOS.Columns.Add("Fecha", objRes.ColumnName(1).GetType)
    '                dtZTRASLADOS.Columns.Add("Guia", objRes.ColumnName(1).GetType)
    '                For irow = 1 To objRes.ROWCOUNT
    '                    Dim orow As DataRow = dtZTRASLADOS.NewRow
    '                    orow("Referencia") = CStr(oRows("EBELN"))
    '                    orow("Status") = "TRA"
    '                    orow("S. Almacen") = CStr(oRows("RESWK"))
    '                    orow("S. Destino") = CStr(oRows("WERKS"))
    '                    orow("Fecha") = Format(oRows("AEDAT"), "SHORT DATE")
    '                    orow("Guia") = ReadInfoPaqueteria(CStr(oRows("EBELN")), "F01")
    '                    dtZTRASLADOS.Rows.Add(orow)
    '                    dtZTRASLADOS.AcceptChanges()
    '                Next
    '            Else
    '                dtZTRASLADOS.Columns.Add("Referencia", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Codigo", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Descripcion", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Talla", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Origen", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Destino", System.Type.GetType("System.String"))
    '                dtZTRASLADOS.Columns.Add("Cantidad", System.Type.GetType("System.Int32"))
    '                dtZTRASLADOS.Columns.Add("Fecha", objRes.ColumnName(1).GetType)
    '                If RecibirParcial Then
    '                    dtZTRASLADOS.Columns.Add("EBELP", System.Type.GetType("System.String"))
    '                    dtZTRASLADOS.Columns.Add("ETENR", System.Type.GetType("System.String"))
    '                End If
    '                For irow = 1 To objRes.ROWCOUNT
    '                    Dim orow As DataRow = dtZTRASLADOS.NewRow
    '                    orow("Referencia") = CStr(oRows("EBELN"))
    '                    orow("Codigo") = CStr(oRows("MATNR"))
    '                    orow("Descripcion") = CStr(oRows("TXZ01"))
    '                    orow("Origen") = CStr(oRows("RESWK"))
    '                    orow("Destino") = CStr(oRows("WERKS"))
    '                    orow("Fecha") = Format(oRows("AEDAT"), "SHORT DATE")
    '                    If RecibirParcial Then
    '                        orow("EBELP") = CStr(oRows("EBELP"))
    '                        orow("ETENR") = CStr(oRows("ETENR"))
    '                    End If
    '                    If InStr(CStr(oRows("J_3ASiZE")), ".5", CompareMethod.Text) = 0 And InStr(CStr(oRows("J_3ASiZE")), ".0", CompareMethod.Text) <> 0 And IsNumeric(CStr(oRows("J_3ASiZE"))) Then
    '                        orow("Talla") = CStr(CInt(oRows("J_3ASiZE")))
    '                    Else
    '                        orow("Talla") = CStr(oRows("J_3ASiZE"))
    '                    End If
    '                    orow("Cantidad") = CInt(oRows("MENGE"))
    '                    dtZTRASLADOS.Rows.Add(orow)
    '                    dtZTRASLADOS.AcceptChanges()
    '                Next
    '            End If
    '            Return dtZTRASLADOS
    '        End If

    '        bRes = False
    '        Return Nothing

    '    Catch ex As Exception

    '        Throw New ApplicationException("[Read_TraspasosEspera] " & ex.Message, ex)

    '    End Try

    'End Function

    Friend Function Read_TraspasosEspera(ByVal dateFechaini As Date, ByVal dateFechaFin As Date, ByVal strI_EBELN As String, ByVal strGENERAL As String, _
                                         ByVal RecibirParcial As Boolean, Optional ByRef bRes As Boolean = True, Optional ByVal Centro As String = "") As DataTable

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim dtRETURN As New DataTable

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC ZBAPIMM02_REVISARTRASPASO     ****
                '*****************************************************
                ' Create a function object
                Dim RFC As String

                '----------------------------------------------------------------------------------
                ' JNAVA (15.02.2016): Se ejecuta solo una bapi por retail
                '----------------------------------------------------------------------------------
                'If RecibirParcial = False Then
                '    RFC = "ZBAPIMM02_REVISARTRASPASO"
                'Else
                RFC = "ZBAPIMM02_REVISARTRASPASOTEMP"
                'End If
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction(RFC)

                ' Asigno valores a los objetos
                If Centro.Trim = "" Then Centro = oParent.Read_Centros()
                func.Exports("I_WERKS").ParamValue = Centro.Trim
                func.Exports("I_FECHAINI").ParamValue = dateFechaini.ToString("yyyyMMdd")
                func.Exports("I_FECHAFIN").ParamValue = dateFechaFin.ToString("yyyyMMdd")
                func.Exports("I_EBELN").ParamValue = strI_EBELN
                'func.Exports("GENERAL").ParamValue = strGENERAL
                If strI_EBELN.Trim = String.Empty Then
                    func.Exports("I_TODOS").ParamValue = "X"
                Else
                    func.Exports("I_TODOS").ParamValue = ""
                End If

                'Ejecuta función
                func.Execute()


                'Cerramos conexion
                R3.Close()

                'Obtener datos
                dtRETURN = func.Tables("ZTRASLADOS").ToADOTable

                '------------------------------------------------------------------------------------
                ' JNAVA (07.03.2016): Se formatea la fecha
                '------------------------------------------------------------------------------------
                Dim strFecha As String = ""
                For Each oRow As DataRow In dtRETURN.Rows
                    strFecha = oRow!AEDAT
                    oRow!AEDAT = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                Next
                '-----------------------------------------------------------------------------------

                If Not dtRETURN Is Nothing OrElse dtRETURN.Rows.Count > 0 Then
                    Dim irow As Integer = 0
                    'Tabla para meter los resultados de la BAPI
                    Dim dtZTRASLADOS As New DataTable("ZTRASLADOS")
                    If strGENERAL = "S" Then
                        dtZTRASLADOS.Columns.Add("Referencia")
                        dtZTRASLADOS.Columns.Add("Status")
                        dtZTRASLADOS.Columns.Add("S. Almacen")
                        dtZTRASLADOS.Columns.Add("S. Destino")
                        dtZTRASLADOS.Columns.Add("Fecha")
                        dtZTRASLADOS.Columns.Add("Guia")

                        Dim oRow As DataRow
                        '------------------------------------------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (16.02.2016): Adecuaciones por retail
                        '------------------------------------------------------------------------------------------------------------------------------------------------------------
                        Dim strGuia As String
                        '------------------------------------------------------------------------------------------------------------------------------------------------------------
                        For Each oRows As DataRow In dtRETURN.Rows
                            oRow = Nothing
                            oRow = dtZTRASLADOS.NewRow
                            oRow("Referencia") = CStr(oRows("EBELN"))
                            oRow("Status") = "TRA"
                            oRow("S. Almacen") = CStr(oRows("RESWK"))
                            oRow("S. Destino") = CStr(oRows("WERKS"))
                            oRow("Fecha") = Format(oRows("AEDAT"), "SHORT DATE")
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------
                            ' JNAVA (16.02.2016): Adecuaciones por retail
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------
                            'ReadInfoPaqueteria(CStr(oRows("EBELN")), strGuia, "", 0)
                            oRow("Guia") = "" 'strGuia 'ReadInfoPaqueteria(CStr(oRows("EBELN")), "F01
                            '------------------------------------------------------------------------------------------------------------------------------------------------------------
                            dtZTRASLADOS.Rows.Add(oRow)
                            dtZTRASLADOS.AcceptChanges()
                        Next
                    Else
                        dtZTRASLADOS.Columns.Add("Referencia")
                        dtZTRASLADOS.Columns.Add("Codigo")
                        dtZTRASLADOS.Columns.Add("Descripcion")
                        dtZTRASLADOS.Columns.Add("Talla")
                        dtZTRASLADOS.Columns.Add("Origen")
                        dtZTRASLADOS.Columns.Add("Destino")
                        dtZTRASLADOS.Columns.Add("Cantidad", System.Type.GetType("System.Int32"))
                        dtZTRASLADOS.Columns.Add("Fecha")
                        dtZTRASLADOS.Columns.Add("Consignacion", GetType(Boolean))

                        dtZTRASLADOS.Columns.Add("EBELP", System.Type.GetType("System.String"))
                        If RecibirParcial Then
                            dtZTRASLADOS.Columns.Add("ETENR", System.Type.GetType("System.String"))
                        End If

                        Dim oRow As DataRow
                        For Each oRows As DataRow In dtRETURN.Rows
                            oRow = Nothing
                            oRow = dtZTRASLADOS.NewRow
                            oRow("Referencia") = CStr(oRows("EBELN"))
                            oRow("Codigo") = CStr(oRows("MATNR"))
                            oRow("Descripcion") = CStr(oRows("TXZ01"))
                            oRow("Origen") = CStr(oRows("RESWK"))
                            oRow("Destino") = CStr(oRows("WERKS"))
                            oRow("Fecha") = Format(oRows("AEDAT"), "SHORT DATE")
                            If RecibirParcial Then
                                oRow("EBELP") = CStr(oRows("EBELP"))
                                oRow("ETENR") = CStr(oRows("ETENR"))
                            End If
                            If InStr(CStr(oRows("J_3ASiZE")), ".5", CompareMethod.Text) = 0 And InStr(CStr(oRows("J_3ASiZE")), ".0", CompareMethod.Text) <> 0 And IsNumeric(CStr(oRows("J_3ASiZE"))) Then
                                oRow("Talla") = CStr(CInt(oRows("J_3ASiZE")))
                            Else
                                oRow("Talla") = CStr(oRows("J_3ASiZE"))
                            End If
                            oRow("Cantidad") = CInt(oRows("MENGE"))
                            If CStr(oRows("LGORT")).Trim = "C001" Then
                                oRow("Consignacion") = True
                            Else
                                oRow("Consignacion") = False
                            End If
                            dtZTRASLADOS.Rows.Add(oRow)
                            dtZTRASLADOS.AcceptChanges()
                        Next

                    End If
                    Return dtZTRASLADOS
                End If

                bRes = False
                Return Nothing

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

#End Region

#Region "Abonos Facturas Credito Asociados DIPS"


    'Friend Function ZBAPI_EXTFACTABONOS(ByVal strCliente As String) As DataTable

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim objRes As Object
    '        Dim bResultado As Boolean

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim I_KUNNR As SAPFunctionsOCX.Parameter     'Nº de cliente 1

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        End If


    '        objFunc = objR3.Add("ZBAPI_EXTFACTABONOS")
    '        objRes = objFunc.Tables("ZT_CXC")

    '        ' Ajusta los parámetros de delimitación de entrada

    '        I_KUNNR = objFunc.Exports("I_KUNNR")

    '        ' Asigno valores a los objetos
    '        I_KUNNR.Value = strCliente

    '        bResultado = objFunc.Call
    '        objR3.Connection.LogOff()

    '        If bResultado Then

    '            Dim irow As Integer = 0
    '            'Tabla para meter los resultados de la BAPI
    '            Dim dtZT_CXC As New DataTable("dtZT_CXC")
    '            If strCliente = String.Empty Then
    '                dtZT_CXC.Columns.Add("ClienteID", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("Nombre", objRes.ColumnName(1).GetType)

    '                For irow = 1 To objRes.ROWCOUNT
    '                    Dim orow As DataRow = dtZT_CXC.NewRow
    '                    orow("ClienteID") = CStr(oRows("KUNNR"))
    '                    orow("Nombre") = CStr(oRows("NAME1"))

    '                    dtZT_CXC.Rows.Add(orow)
    '                    dtZT_CXC.AcceptChanges()
    '                Next
    '            Else
    '                dtZT_CXC.Columns.Add("Nombre", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("FechaFactura", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("FolioFactura", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("FechaLimitePago", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("PagoEstablecido", System.Type.GetType("System.Decimal"))
    '                dtZT_CXC.Columns.Add("Abonos", System.Type.GetType("System.Decimal"))
    '                dtZT_CXC.Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
    '                dtZT_CXC.Columns.Add("Abono", System.Type.GetType("System.Decimal"))
    '                dtZT_CXC.Columns.Add("LimiteCredito", System.Type.GetType("System.Decimal"))
    '                dtZT_CXC.Columns.Add("DocFi", objRes.ColumnName(1).GetType)
    '                dtZT_CXC.Columns.Add("DpFactura", System.Type.GetType("System.String"))

    '                For irow = 1 To objRes.ROWCOUNT
    '                    Dim orow As DataRow = dtZT_CXC.NewRow
    '                    orow("Nombre") = CStr(oRows("NAME1"))
    '                    orow("FechaFactura") = Format(oRows("ZFBDT"), "SHORT DATE")
    '                    'orow("FolioFactura") = CStr(oRows("VBELN"))
    '                    orow("FolioFactura") = CDec(oRows("BELNR"))
    '                    orow("FechaLimitePago") = Format(oRows("FDTAG"), "SHORT DATE")
    '                    orow("PagoEstablecido") = CDec(oRows("DMBTR"))
    '                    orow("Abonos") = CDec(oRows("ABONO"))
    '                    orow("Saldo") = CDec(oRows("SALDO"))
    '                    orow("Abono") = CDec("0.00")
    '                    orow("LimiteCredito") = CDec(oRows("KLIMK"))
    '                    'orow("DocFi") = CDec(oRows("BELNR"))
    '                    orow("DocFi") = CStr(oRows("VBELN"))
    '                    orow("DpFactura") = CStr(oRows("FacturaDP"))
    '                    dtZT_CXC.Rows.Add(orow)
    '                    dtZT_CXC.AcceptChanges()
    '                Next
    '            End If

    '            Return dtZT_CXC

    '        End If

    '        Return Nothing

    '    Catch ex As Exception

    '        Throw New ApplicationException(ex.Message, ex)

    '    End Try

    'End Function

    Friend Function ZBAPI_EXTFACTABONOS(ByVal strCliente As String) As DataTable
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim dtRespuesta As New DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_EXTFACTABONOS     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_EXTFACTABONOS")

                '' Asigno valores a los objetos
                func.Exports("I_KUNNR").ParamValue = strCliente

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtenemos Datos
                dtRespuesta = func.Tables("ZT_CXC").ToADOTable


                'Validamos datos
                If Not dtRespuesta Is Nothing OrElse dtRespuesta.Rows.Count > 0 Then

                    Dim irow As Integer = 0
                    'Tabla para meter los resultados de la BAPI
                    Dim dtZT_CXC As New DataTable("dtZT_CXC")
                    If strCliente = String.Empty Then
                        dtZT_CXC.Columns.Add("ClienteID")
                        dtZT_CXC.Columns.Add("Nombre")

                        Dim oRow As DataRow
                        For Each oRows As DataRow In dtRespuesta.Rows
                            oRow = Nothing
                            oRow = dtZT_CXC.NewRow
                            oRow("ClienteID") = CStr(oRows("KUNNR"))
                            oRow("Nombre") = CStr(oRows("NAME1"))
                            dtZT_CXC.Rows.Add(oRow)
                            dtZT_CXC.AcceptChanges()
                        Next
                    Else
                        dtZT_CXC.Columns.Add("Nombre")
                        dtZT_CXC.Columns.Add("FechaFactura")
                        dtZT_CXC.Columns.Add("FolioFactura")
                        dtZT_CXC.Columns.Add("FechaLimitePago")
                        dtZT_CXC.Columns.Add("PagoEstablecido")
                        dtZT_CXC.Columns.Add("Abonos")
                        dtZT_CXC.Columns.Add("Saldo")
                        dtZT_CXC.Columns.Add("Abono")
                        dtZT_CXC.Columns.Add("LimiteCredito")
                        dtZT_CXC.Columns.Add("DocFi")
                        dtZT_CXC.Columns.Add("DpFactura")

                        Dim oRow As DataRow
                        For Each oRows As DataRow In dtRespuesta.Rows
                            oRow = Nothing
                            oRow("Nombre") = CStr(oRows("NAME1"))
                            oRow("FechaFactura") = Format(oRows("ZFBDT"), "SHORT DATE")
                            'orow("FolioFactura") = CStr(oRows("VBELN"))
                            oRow("FolioFactura") = CDec(oRows("BELNR"))
                            oRow("FechaLimitePago") = Format(oRows("FDTAG"), "SHORT DATE")
                            oRow("PagoEstablecido") = CDec(oRows("DMBTR"))
                            oRow("Abonos") = CDec(oRows("ABONO"))
                            oRow("Saldo") = CDec(oRows("SALDO"))
                            oRow("Abono") = CDec("0.00")
                            oRow("LimiteCredito") = CDec(oRows("KLIMK"))
                            'orow("DocFi") = CDec(oRows("BELNR"))
                            oRow("DocFi") = CStr(oRows("VBELN"))
                            oRow("DpFactura") = CStr(oRows("FacturaDP"))
                            dtZT_CXC.Rows.Add(oRow)
                            dtZT_CXC.AcceptChanges()
                        Next
                    End If

                    Return dtZT_CXC

                End If

                Return Nothing

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    'Friend Function ZBAPIFI06_REG_ABONO_PAGO_VENTA(ByVal strTIENDA As String, ByVal strCliente As String, ByVal dblIMPORTE As Double, _
    '                                                ByVal strVBELN As String, ByVal strCLACOBR As String, ByVal strBANCO As String, _
    '                                                ByVal strFactDpPro As String, ByVal strDetalle As String, ByVal strRefBanco As String) As String()

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim bResultado As Boolean
    '        Dim astrDocNum(2) As String

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim TIENDA As SAPFunctionsOCX.Parameter         'Clave de Tienda
    '        Dim CLIENTE As SAPFunctionsOCX.Parameter        'Nº de cliente
    '        Dim IMPORTE As SAPFunctionsOCX.Parameter        'Importe
    '        Dim VBELN As SAPFunctionsOCX.Parameter          'Número de documento comercial
    '        Dim DETALLE As SAPFunctionsOCX.Parameter        '
    '        Dim REF_BANCO As SAPFunctionsOCX.Parameter      'Referencia Bancaria
    '        Dim CLACOBR As SAPFunctionsOCX.Parameter        'Clave de Cobranza
    '        Dim BANCO As SAPFunctionsOCX.Parameter          'Banco
    '        Dim I_FACTDPPRO As SAPFunctionsOCX.Parameter    'Factura Dportenis PRO
    '        'Dim I_FECHA As SAPFunctionsOCX.Parameter        'Fecha Movimiento


    '        Dim DOCNUMFB01 As SAPFunctionsOCX.Parameter      'Respuesta
    '        Dim DOCNUMFB05 As SAPFunctionsOCX.Parameter      'Respuesta

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        End If

    '        'Para Decirle a que BAPI voy a llamar
    '        objFunc = objR3.Add("ZBAPIFI06_REG_ABONO_PAGO_VENTA")

    '        ' Ajusta los parámetros de delimitación de entrada

    '        TIENDA = objFunc.Exports("TIENDA")
    '        CLIENTE = objFunc.Exports("CLIENTE")
    '        IMPORTE = objFunc.Exports("IMPORTE")
    '        VBELN = objFunc.Exports("VBELN")
    '        DETALLE = objFunc.Exports("DETALLE")
    '        REF_BANCO = objFunc.Exports("REF_BANCO")
    '        CLACOBR = objFunc.Exports("CLACOBR")
    '        BANCO = objFunc.Exports("BANCO")
    '        I_FACTDPPRO = objFunc.Exports("I_FACTDPPRO")
    '        'I_FECHA = objFunc.Exports("I_FECHA")

    '        DOCNUMFB01 = objFunc.Imports("DOCNUMFB01")
    '        DOCNUMFB05 = objFunc.Imports("DOCNUMFB05")

    '        ' Asigno valores a los objetos


    '        TIENDA.Value = strTIENDA
    '        CLIENTE.Value = strCliente
    '        IMPORTE.Value = dblIMPORTE
    '        VBELN.Value = strVBELN
    '        REF_BANCO.Value = strRefBanco
    '        CLACOBR.Value = strCLACOBR
    '        BANCO.Value = strBANCO
    '        I_FACTDPPRO.Value = strFactDpPro
    '        DETALLE.Value = strDetalle
    '        'I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))


    '        bResultado = objFunc.Call
    '        objR3.Connection.LogOff()

    '        If bResultado Then
    '            astrDocNum(0) = DOCNUMFB01.Value
    '            astrDocNum(1) = DOCNUMFB05.Value
    '            Return astrDocNum

    '        Else
    '            astrDocNum(0) = String.Empty
    '            astrDocNum(1) = String.Empty
    '            Return astrDocNum
    '        End If
    '        astrDocNum(0) = String.Empty
    '        astrDocNum(1) = String.Empty

    '        Return astrDocNum

    '    Catch ex As Exception

    '        Throw New ApplicationException(ex.Message, ex)

    '    End Try

    'End Function

    Friend Function ZBAPIFI06_REG_ABONO_PAGO_VENTA(ByVal strTIENDA As String, ByVal strCliente As String, ByVal dblIMPORTE As Double, _
                                                  ByVal strVBELN As String, ByVal strCLACOBR As String, ByVal strBANCO As String, _
                                                  ByVal strFactDpPro As String, ByVal strDetalle As String, ByVal strRefBanco As String) As String()

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim astrDocNum(2) As String

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI06_REG_ABONO_PAGO_VENTA     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI06_REG_ABONO_PAGO_VENTA")

                '' Asigno valores a los objetos
                func.Exports("TIENDA").ParamValue = strTIENDA
                func.Exports("CLIENTE").ParamValue = strCliente
                func.Exports("IMPORTE").ParamValue = dblIMPORTE
                func.Exports("VBELN").ParamValue = strVBELN
                func.Exports("REF_BANCO").ParamValue = strRefBanco
                func.Exports("CLACOBR").ParamValue = strCLACOBR
                func.Exports("BANCO").ParamValue = strBANCO
                func.Exports("I_FACTDPPRO").ParamValue = strFactDpPro
                func.Exports("DETALLE").ParamValue = strDetalle
                'I_FECHA.Value = CStr(Format(Date.Now.Date, "dd/MM/yyyy"))

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtenemos datos
                If Not String.IsNullOrEmpty(func.Imports("DOCNUMFB01").ParamValue) OrElse Not String.IsNullOrEmpty(func.Imports("DOCNUMFB05").ParamValue) Then
                    astrDocNum(0) = func.Imports("DOCNUMFB01").ParamValue
                    astrDocNum(1) = func.Imports("DOCNUMFB05").ParamValue
                Else
                    astrDocNum(0) = String.Empty
                    astrDocNum(1) = String.Empty
                End If

                Return astrDocNum

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

#End Region

#Region "Consulta Existencias"

    'Friend Function Read_ExistenciasSAP(ByVal strarticulo As String, ByVal strcentro As String, ByVal strtodos As String) As DataTable
    '    Try
    '        Dim R3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim myFunc As SAPFunctionsOCX.Function
    '        Dim Result As Boolean
    '        Dim objRes As Object
    '        'Dim strCentro As String

    '        ' Se definen los parámetros TABLE            
    '        Dim objtabretTABLA_ARTICULOS As SAPTableFactoryCtrl.Table
    '        Dim objtabretReturn As Object
    '        Dim oStructureSAP As Object

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim CENTRO As SAPFunctionsOCX.Parameter
    '        Dim TODOS As SAPFunctionsOCX.Parameter
    '        Dim MATERIAL As SAPFunctionsOCX.Parameter

    '        With R3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        If R3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '********************************************************
    '            'Call RFC function ZBAPI_EXTEXISTENCIAS ***Emanuel
    '            '********************************************************
    '            myFunc = R3.Add("ZBAPI_EXTEXISTENCIAS")

    '            ' Ajusta los parámetros de delimitación de entrada
    '            CENTRO = myFunc.Exports("CENTRO")
    '            TODOS = myFunc.Exports("TODOS")
    '            MATERIAL = myFunc.Exports("MATERIAL")

    '            ' Asigno valores a los objetos
    '            CENTRO.Value = strcentro
    '            TODOS.Value = strtodos
    '            MATERIAL.Value = strarticulo

    '            objRes = myFunc.Tables("ZEXISTENCIA")

    '            ' Ejecuta función en R/3
    '            Result = myFunc.Call
    '            'Cierra la Conexion
    '            R3.Connection.LOGOFF()


    '            If Result Then 'me traigo los campos
    '                Dim irow As Integer = 0
    '                'Tabla para meter los resultados de la BAPI
    '                Dim dtexistencias As New DataTable("ZEXISTENCIA")
    '                dtexistencias.Columns.Add("Almacén", System.Type.GetType("System.String"))
    '                dtexistencias.Columns.Add("Número", System.Type.GetType("System.String"))
    '                dtexistencias.Columns.Add("Libre", System.Type.GetType("System.Decimal"))
    '                dtexistencias.Columns.Add("Apartados", System.Type.GetType("System.String"))
    '                dtexistencias.Columns.Add("Defectuosos", System.Type.GetType("System.String"))
    '                dtexistencias.Columns.Add("Transito", System.Type.GetType("System.Decimal"))

    '                '------------------objres----------------
    '                Dim strTalla As String
    '                For irow = 1 To objRes.ROWCOUNT
    '                    Dim orow As DataRow = dtexistencias.NewRow
    '                    orow("Almacén") = CStr(oRows("WERKS"))
    '                    strTalla = CStr(oRows("J_3ASIZE"))
    '                    If InStr(strTalla, ".5", CompareMethod.Text) = 0 And InStr(strTalla, ".0", CompareMethod.Text) <> 0 And IsNumeric(strTalla) Then
    '                        strTalla = CInt(strTalla)
    '                    End If
    '                    orow("Número") = strTalla
    '                    orow("Libre") = CInt(oRows("CLABS"))
    '                    orow("Apartados") = CInt(oRows("CSPEM"))
    '                    orow("Defectuosos") = "0"
    '                    orow("Transito") = CInt(oRows("CUMLM"))
    '                    dtexistencias.Rows.Add(orow)
    '                    dtexistencias.AcceptChanges()
    '                Next

    '                Return dtexistencias
    '            Else
    '                Return Nothing
    '            End If

    '        End If
    '    Catch ex As Exception
    '        Throw New ApplicationException(ex.Message, ex)
    '    End Try
    'End Function

    Friend Function Read_ExistenciasSAP(ByVal strarticulo As String, ByVal strcentro As String, ByVal strtodos As String) As DataTable

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try

            Dim dtResultado As New DataTable

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_EXTEXISTENCIAS     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_EXTEXISTENCIAS")

                ' Asigno valores a los objetos
                func.Exports("CENTRO").ParamValue = strcentro
                func.Exports("TODOS").ParamValue = strtodos
                func.Exports("MATERIAL").ParamValue = strarticulo
                ' Ejecuta función
                func.Execute()
                R3.Close()

                'obtenemos info
                dtResultado = func.Tables("ZEXISTENCIA").ToADOTable
                'Cierra la Conexion

                If Not dtResultado Is Nothing OrElse dtResultado.Rows.Count > 0 Then 'me traigo los campos
                    Dim irow As Integer = 0
                    'Tabla para meter los resultados de la BAPI
                    Dim dtexistencias As New DataTable("ZEXISTENCIA")
                    dtexistencias.Columns.Add("CodArticulo", GetType(String))
                    dtexistencias.Columns.Add("Almacén", System.Type.GetType("System.String"))
                    dtexistencias.Columns.Add("Número", System.Type.GetType("System.String"))
                    dtexistencias.Columns.Add("Libre", System.Type.GetType("System.Decimal"))
                    dtexistencias.Columns.Add("Apartados", System.Type.GetType("System.String"))
                    dtexistencias.Columns.Add("Defectuosos", System.Type.GetType("System.String"))
                    dtexistencias.Columns.Add("Transito", System.Type.GetType("System.Decimal"))

                    '------------------objres----------------
                    Dim strTalla As String
                    Dim oRow As DataRow
                    For Each oRows As DataRow In dtResultado.Rows
                        oRow = Nothing
                        oRow = dtexistencias.NewRow
                        oRow("CodArticulo") = strarticulo
                        oRow("Almacén") = CStr(oRows("WERKS"))
                        strTalla = CStr(oRows("J_3ASIZE"))
                        If InStr(strTalla, ".5", CompareMethod.Text) = 0 And InStr(strTalla, ".0", CompareMethod.Text) <> 0 And IsNumeric(strTalla) Then
                            strTalla = CInt(strTalla)
                        End If
                        oRow("Número") = strTalla
                        oRow("Libre") = CInt(oRows("LABST"))
                        oRow("Apartados") = CInt(oRows("APARTADO"))
                        oRow("Defectuosos") = CInt(oRows("DEFECTUOSO"))
                        oRow("Transito") = CInt(oRows("UMLME"))
                        dtexistencias.Rows.Add(oRow)
                        dtexistencias.AcceptChanges()
                    Next

                    Return dtexistencias
                Else
                    Return Nothing
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Consulta Estado Cuenta Cliente"

    'Friend Function ZBAPI_EDOCUENTAXCLIENTE(ByVal strCliente As String) As DataTable

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim objRes As Object
    '        Dim bResultado As Boolean

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim I_KUNNR As SAPFunctionsOCX.Parameter     'Nº de cliente 1

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        End If


    '        objFunc = objR3.Add("ZBAPI_EDOCUENTAXCLIENTE")
    '        objRes = objFunc.Tables("ZT_CXC")

    '        ' Ajusta los parámetros de delimitación de entrada

    '        I_KUNNR = objFunc.Exports("I_KUNNR")

    '        ' Asigno valores a los objetos
    '        I_KUNNR.Value = strCliente

    '        bResultado = objFunc.Call
    '        objR3.Connection.LogOff()
    '        If bResultado Then
    '            Dim irow As Integer = 0
    '            'Tabla para meter los resultados de la BAPI
    '            Dim dtZT_CXC As New DataTable("dtZT_CXC")
    '            dtZT_CXC.Columns.Add("Detalle", System.Type.GetType("System.String")) 'DETALLE
    '            dtZT_CXC.Columns.Add("Fecha", objRes.ColumnName(1).GetType)
    '            dtZT_CXC.Columns.Add("Folio", System.Type.GetType("System.String"))
    '            dtZT_CXC.Columns.Add("Sucursal", System.Type.GetType("System.String"))
    '            dtZT_CXC.Columns.Add("ComprasCargos", System.Type.GetType("System.Decimal"))
    '            dtZT_CXC.Columns.Add("PagosAbonos", System.Type.GetType("System.Decimal"))
    '            dtZT_CXC.Columns.Add("FolioDP", System.Type.GetType("System.String"))

    '            For irow = 1 To objRes.ROWCOUNT
    '                Dim orow As DataRow = dtZT_CXC.NewRow

    '                orow("Detalle") = CStr(oRows("BELNR")) 'DOCFI
    '                orow("Fecha") = Format(oRows("ZFBDT"), "SHORT DATE")
    '                orow("Folio") = CStr(oRows("VBELN"))
    '                orow("Sucursal") = CStr(oRows("VWERK"))
    '                orow("ComprasCargos") = CDec(oRows("CARGO"))
    '                orow("PagosAbonos") = CDec(oRows("ABONO"))
    '                orow("FolioDP") = CStr(oRows("FACTURADP"))
    '                dtZT_CXC.Rows.Add(orow)
    '                dtZT_CXC.AcceptChanges()
    '            Next

    '            Return dtZT_CXC
    '        End If

    '        Return Nothing

    '    Catch ex As Exception

    '        Throw New ApplicationException(ex.Message, ex)

    '    End Try

    'End Function

    Friend Function ZBAPI_EDOCUENTAXCLIENTE(ByVal strCliente As String) As DataTable

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim dtRespuesta As New DataTable

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_EDOCUENTAXCLIENTE     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_EDOCUENTAXCLIENTE")

                '' Asigno valores a los objetos
                func.Exports("I_KUNNR").ParamValue = strCliente

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtener datos
                dtRespuesta = func.Tables("ZT_CXC").ToADOTable

                'Validamos datos
                If Not dtRespuesta Is Nothing OrElse dtRespuesta.Rows.Count > 0 Then 'me traigo los campos
                    'Tabla para meter los resultados de la BAPI
                    Dim dtZT_CXC As New DataTable("dtZT_CXC")
                    dtZT_CXC.Columns.Add("Detalle") 'DETALLE
                    dtZT_CXC.Columns.Add("Fecha")
                    dtZT_CXC.Columns.Add("Folio")
                    dtZT_CXC.Columns.Add("Sucursal")
                    dtZT_CXC.Columns.Add("ComprasCargos")
                    dtZT_CXC.Columns.Add("PagosAbonos")
                    dtZT_CXC.Columns.Add("FolioDP")

                    Dim oRow As DataRow
                    For Each oRows As DataRow In dtRespuesta.Rows
                        oRow = Nothing
                        oRow = dtZT_CXC.NewRow
                        oRow("Detalle") = CStr(oRows("BELNR")) 'DOCFI
                        oRow("Fecha") = Format(oRows("ZFBDT"), "SHORT DATE")
                        oRow("Folio") = CStr(oRows("VBELN"))
                        oRow("Sucursal") = CStr(oRows("VWERK"))
                        oRow("ComprasCargos") = CDec(oRows("CARGO"))
                        oRow("PagosAbonos") = CDec(oRows("ABONO"))
                        oRow("FolioDP") = CStr(oRows("FACTURADP"))
                        dtZT_CXC.Rows.Add(oRow)
                        dtZT_CXC.AcceptChanges()
                    Next

                    Return dtZT_CXC

                End If

                Return Nothing

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    'Friend Function ZBAPI_CONSULTAFACTURAS(ByVal strFactura As String) As DataTable

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function
    '        Dim objRes As Object
    '        Dim bResultado As Boolean

    '        ' Definición de los parámetros para el IMPORT de la función SAP
    '        Dim I_KUNNR As SAPFunctionsOCX.Parameter     'Nº de cliente 1
    '        Dim IMPORTEFACTURA As SAPFunctionsOCX.Parameter

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        End If


    '        objFunc = objR3.Add("ZBAPI_CONSULTAFACTURAS")
    '        objRes = objFunc.Tables("ZT_CXC")

    '        ' Ajusta los parámetros de delimitación de entrada

    '        I_KUNNR = objFunc.Exports("I_FACTURA")

    '        ' Ajusta los parámetros de delimitación de Salida

    '        IMPORTEFACTURA = objFunc.Imports("IMPORTEFACTURA")


    '        ' Asigno valores a los objetos
    '        I_KUNNR.Value = strFactura

    '        bResultado = objFunc.Call
    '        objR3.Connection.LogOff()

    '        If bResultado Then
    '            Dim irow As Integer = 0
    '            'Tabla para meter los resultados de la BAPI
    '            Dim dtZT_CXC As New DataTable("dtZT_CXC")
    '            dtZT_CXC.Columns.Add("Cliente", objRes.ColumnName(1).GetType) 'Cliente
    '            dtZT_CXC.Columns.Add("Folio", objRes.ColumnName(1).GetType) 'FOLIO
    '            dtZT_CXC.Columns.Add("Fecha", objRes.ColumnName(1).GetType) 'Fecha
    '            dtZT_CXC.Columns.Add("FechaVenci", objRes.ColumnName(1).GetType) 'Fecha de Vencimiento
    '            dtZT_CXC.Columns.Add("Sucursal", objRes.ColumnName(1).GetType)
    '            dtZT_CXC.Columns.Add("ComprasCargos", System.Type.GetType("System.Decimal"))
    '            dtZT_CXC.Columns.Add("PagosAbonos", System.Type.GetType("System.Decimal"))
    '            dtZT_CXC.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
    '            For irow = 1 To objRes.ROWCOUNT
    '                Dim orow As DataRow = dtZT_CXC.NewRow
    '                orow("Cliente") = CStr(oRows("KUNNR")) 'Cliente
    '                orow("Folio") = CStr(oRows("BELNR")) 'DOCFI
    '                orow("Fecha") = Format(oRows("VALUT"), "SHORT DATE")
    '                orow("FechaVenci") = Format(oRows("ZFBDT"), "SHORT DATE")
    '                orow("Sucursal") = CStr(oRows("VWERK"))
    '                orow("ComprasCargos") = CDec(oRows("CARGO"))
    '                orow("PagosAbonos") = CDec(oRows("ABONO"))
    '                orow("Importe") = CDec(IMPORTEFACTURA.Value)
    '                dtZT_CXC.Rows.Add(orow)
    '                dtZT_CXC.AcceptChanges()
    '            Next
    '            If objRes.ROWCOUNT = 0 Then
    '                Return Nothing
    '            Else
    '                Return dtZT_CXC
    '            End If
    '        End If

    '        Return Nothing

    '    Catch ex As Exception

    '        Throw New ApplicationException(ex.Message, ex)

    '    End Try

    'End Function

    Friend Function ZBAPI_CONSULTAFACTURAS(ByVal strFactura As String) As DataTable

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Try
            Dim dtRespuesta As New DataTable
            Dim strIMPORTEFACTURA As String

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CONSULTAFACTURAS     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_CONSULTAFACTURAS")

                '' Asigno valores a los objetos
                func.Exports("I_FACTURA").ParamValue = strFactura

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Cierra la Conexion
                R3.Close()

                'Obtener datos
                dtRespuesta = func.Tables("ZT_CXC").ToADOTable
                StrIMPORTEFACTURA = func.Imports("IMPORTEFACTURA").ParamValue


                'Validamos datos
                Dim dtZT_CXC As DataTable
                If Not dtRespuesta Is Nothing OrElse dtRespuesta.Rows.Count > 0 Then
                    'Tabla para meter los resultados de la BAPI
                    dtZT_CXC = New DataTable("dtZT_CXC")
                    dtZT_CXC.Columns.Add("Cliente") 'Cliente
                    dtZT_CXC.Columns.Add("Folio") 'FOLIO
                    dtZT_CXC.Columns.Add("Fecha") 'Fecha
                    dtZT_CXC.Columns.Add("FechaVenci") 'Fecha de Vencimiento
                    dtZT_CXC.Columns.Add("Sucursal")
                    dtZT_CXC.Columns.Add("ComprasCargos")
                    dtZT_CXC.Columns.Add("PagosAbonos")
                    dtZT_CXC.Columns.Add("Importe")

                    Dim oRow As DataRow
                    For Each oRows As DataRow In dtRespuesta.Rows
                        oRow = Nothing
                        oRow = dtZT_CXC.NewRow
                        oRow("Cliente") = CStr(oRows("KUNNR")) 'Cliente
                        oRow("Folio") = CStr(oRows("BELNR")) 'DOCFI
                        oRow("Fecha") = Format(oRows("VALUT"), "SHORT DATE")
                        oRow("FechaVenci") = Format(oRows("ZFBDT"), "SHORT DATE")
                        oRow("Sucursal") = CStr(oRows("VWERK"))
                        oRow("ComprasCargos") = CDec(oRows("CARGO"))
                        oRow("PagosAbonos") = CDec(oRows("ABONO"))
                        oRow("Importe") = CDec(strIMPORTEFACTURA)
                        dtZT_CXC.Rows.Add(oRow)
                        dtZT_CXC.AcceptChanges()
                    Next

                    Return dtZT_CXC

                End If

                Return Nothing

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

    '#Region "CompensacionVC"

    '    'Friend Function Write_ZBAPI_CompensacionVC(ByVal decMontoUtilizado As Decimal, ByVal strFIDocument As String, ByVal strFIFactura As String) As String

    '    '    Dim oResult As String = String.Empty

    '    '    Try

    '    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '    '        Dim objFunc As SAPFunctionsOCX.Function

    '    '        '/--Parametros Exports
    '    '        Dim oMontoUtilizado As Object           '--Monto Utilizado del Vale
    '    '        Dim oFIDocument As Object               '--Documento FI de Compensacion que genero el Vale.
    '    '        Dim oFIFactura As Object                '--Documento FI de la Factura que tiene el Saldo a Favor.
    '    '        '--Fin Parametros Exports/

    '    '        '/--Parametros Imports
    '    '        Dim oFICompensacion As Object           '--Nuevo Documento FI de Compensacion
    '    '        '--Fin parametros Imports/


    '    '        With objR3.Connection
    '    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '    '            .System = oParent.SAPApplicationConfig.System
    '    '            .Client = oParent.SAPApplicationConfig.Client
    '    '            .User = oParent.SAPApplicationConfig.User
    '    '            .Password = oParent.SAPApplicationConfig.Password
    '    '            .Language = oParent.SAPApplicationConfig.Language
    '    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '    '        End With

    '    '        If objR3.Connection.logon(0, True) <> True Then
    '    '            objR3 = Nothing
    '    '            Exit Function
    '    '        End If

    '    '        '--Implementamos Nombre BAPI
    '    '        objFunc = objR3.Add("ZBAPI_CompensacionVC")

    '    '        '/--Exports
    '    '        oMontoUtilizado = objFunc.Exports("MontoUtilizado") '--Monto Utilizado del Vale
    '    '        oFIDocument = objFunc.Exports("FIDocument") '--Documento FI de Compensacion que genero el Vale.
    '    '        oFIFactura = objFunc.Exports("FIFactura") '--Documento FI de la Factura que tiene el Saldo a Favor.
    '    '        '--Fin Exports/

    '    '        '/--Imports
    '    '        oFICompensacion = objFunc.Imports("FICompensacion")
    '    '        '--Fin Imports/


    '    '        Dim b As Boolean
    '    '        b = objFunc.Call()

    '    '        If b Then
    '    '            oResult = oFIFactura.Value
    '    '        End If

    '    '        objR3.Connection.LogOff()


    '    '    Catch ex As Exception

    '    '        oResult = String.Empty


    '    '    End Try

    '    '    Return oResult

    '    'End Function

    '#End Region

#Region "Ajustes de Entrada-Salida"

    Friend Function WRITE_ZBAPI_ANULAR_AJUSTE_TE(ByVal strFolio As String) As String

        Dim strResultado As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_ACTUALIZA_DIPS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_ANULAR_AJUSTE_TE")

                func.Exports("I_DOC").ParamValue = strFolio

                func.Execute()

                R3.Close()

                Return func.Imports("E_DOCR").ToString & "/" & func.Imports("E_RESULT").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    'Friend Function Write_ZBAPI_AJUSTE(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, Optional ByVal dtTemp As DataTable = Nothing) As String

    '    Dim oResult As String = String.Empty
    '    Dim strCentroFI As String
    '    Dim strCentroSAP As String

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oTEXTO_CABECERA As Object       '--Campo de usuario para cluster PC nacional
    '        Dim oVALE_ALMACEN As Object         '--Campo de usuario para cluster PC nacional
    '        Dim oWERKS As Object                '--Ámbito no definido , posiblemente para niveles patch
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oNUMMB1C As Object           '--Campo de texto, longitud 10
    '        Dim oMB1A As Object                 '--Indicador de una posición (Ajustes de Salida)
    '        '--Fin parametros Imports/

    '        '/--Detalle
    '        Dim oTTArticulos As Object 'Tabla de pedidos de MM para Bapi
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Detalee

    '        Dim oMesstab As Object 'Acumular mensajes en sistema SAP
    '        Dim oRETURN As Object 'Parámetro de retorno

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            objR3 = Nothing
    '            Exit Function
    '        End If

    '        '--Implementamos Nombre BAPI
    '        If oAjusteInfo.TipoAjuste = "E" Then
    '            objFunc = objR3.Add("ZBAPI_AJUSTEENTRADA")
    '            '/--Imports
    '            oNUMMB1C = objFunc.Imports("NUMMB1C") ''--Campo de texto, longitud 10
    '            '--Fin Imports/
    '        Else
    '            objFunc = objR3.Add("ZBAPI_AJUSTESALIDA")
    '            '/--Imports
    '            oNUMMB1C = objFunc.Imports("NUMMB1A")         ''--Campo de texto, longitud 10
    '            oMB1A = objFunc.Imports("MB1A")               '--Indicador de una posición (Ajustes de Salida)
    '            '--
    '        End If

    '        '/--Parametros Exports
    '        oTEXTO_CABECERA = objFunc.Exports("TEXTO_CABECERA")      '--Campo de usuario para cluster PC nacional
    '        oVALE_ALMACEN = objFunc.Exports("VALE_ALMACEN")          '--Campo de usuario para cluster PC nacional
    '        oWERKS = objFunc.Exports("WERKS")                        '--Ámbito no definido , posiblemente para niveles patch
    '        '--Fin Parametros Exports/



    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("TT_ARTICULOS")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oRETURN = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        oTEXTO_CABECERA.Value = "AJUSTE DE " & oAjusteInfo.TipoAjuste & " " & oAjusteInfo.Almacen
    '        oVALE_ALMACEN.Value = "Folio DpPro " & oAjusteInfo.FolioAjuste

    '        strCentroSAP = oParent.Read_Centros(, strCentroFI)
    '        oWERKS.Value = strCentroFI

    '        If dtTemp Is Nothing Then
    '            For Each oRow As DataRow In oAjusteInfo.Detalle.Rows
    '                '--DatosDet
    '                oTTArticulos = oTbDatosDet.AppendRow()
    '                oTTArticulos.Value("MATNR") = oRow!Codigo
    '                oTTArticulos.Value("CENTRO_DESTINO") = strCentroSAP
    '                oTTArticulos.Value("MENGE") = oRow!Cantidad
    '                oTTArticulos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)
    '            Next
    '        Else
    '            For Each oRow As DataRow In dtTemp.Rows
    '                '--DatosDet
    '                oTTArticulos = oTbDatosDet.AppendRow()
    '                oTTArticulos.Value("MATNR") = oRow!Codigo
    '                oTTArticulos.Value("CENTRO_DESTINO") = strCentroSAP
    '                oTTArticulos.Value("MENGE") = oRow!Cantidad
    '                oTTArticulos.Value("TALLA") = oParent.FormatTalla(oRow!Talla)
    '            Next
    '        End If



    '        Dim b As Boolean
    '        b = objFunc.Call()

    '        If b Then
    '            If oAjusteInfo.TipoAjuste = "E" Then
    '                oResult = oNUMMB1C.Value
    '                oAjusteInfo.FolioSAP = oResult
    '            Else
    '                If oMB1A.Value = "Y" Then
    '                    oResult = oNUMMB1C.Value
    '                    oAjusteInfo.FolioSAP = oResult
    '                End If
    '            End If
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oResult = String.Empty
    '        oAjusteInfo.FolioSAP = oResult

    '    End Try

    '    oAjusteInfo.FolioSAP = oResult
    '    Return oResult

    'End Function

    Friend Function Write_ZBAPI_AJUSTE(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, Optional ByVal dtTemp As DataTable = Nothing) As String

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------
        ' JNAVA (12.02.2016): Modificado por adecuaciones de retail
        '----------------------------------------------------------------------------------
        Dim oResult As String = String.Empty
        Try
            Dim strCentroFI As String
            Dim strCentroSAP As String

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_AJUSTEXXXXX              ****
                '*****************************************************
                ' Create a function object
                Dim RFC As String
                Dim iNUMBBA As String
                Dim iMB1 As String
                Dim func As ERPConnect.RFCFunction
                If oAjusteInfo.TipoAjuste = "E" Then
                    RFC = "ZBAPI_AJUSTEENTRADA"
                    iNUMBBA = "NUMMB1C"
                    iMB1 = "MB1C"
                Else
                    RFC = "ZBAPI_AJUSTESALIDA"
                    iNUMBBA = "NUMMB1A"
                    iMB1 = "MB1A"
                End If
                func = R3.CreateFunction(RFC)

                '' Asigno valores a los objetos
                func.Exports("TEXTO_CABECERA").ParamValue = CStr("AJUSTE DE " & oAjusteInfo.TipoAjuste & " " & oAjusteInfo.Almacen).TrimEnd
                func.Exports("VALE_ALMACEN").ParamValue = CStr("Folio DpPro " & oAjusteInfo.FolioAjuste).TrimEnd

                strCentroSAP = oParent.Read_Centros()
                func.Exports("WERKS").ParamValue = strCentroSAP 'strCentroFI
                func.Exports("MOV_TYPE").ParamValue = oAjusteInfo.ClaseMov.Trim
                func.Exports("MOV_REAS").ParamValue = oAjusteInfo.Motivo.Trim

                'tablas
                Dim T_Lines As ERPConnect.RFCTable = func.Tables("TT_ARTICULOS")
                If dtTemp Is Nothing Then
                    For Each oRow As DataRow In oAjusteInfo.Detalle.Rows
                        '--DatosDet
                        Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                        R_Lines("MATNR") = oRow!Codigo
                        R_Lines("CENTRO_DESTINO") = strCentroSAP
                        R_Lines("MENGE") = CInt(oRow!Cantidad)
                        R_Lines("ALMACEN") = "M001"
                    Next
                Else
                    For Each oRow As DataRow In dtTemp.Rows
                        '--DatosDet
                        Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                        R_Lines("MATNR") = oRow!Codigo
                        R_Lines("CENTRO_DESTINO") = strCentroSAP
                        R_Lines("MENGE") = CInt(oRow!Cantidad)
                        R_Lines("ALMACEN") = "M001"
                    Next
                End If

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtenemos datos
                If oAjusteInfo.TipoAjuste = "E" Then
                    oResult = func.Imports(iNUMBBA).ParamValue
                    oAjusteInfo.FolioSAP = oResult.Trim
                Else
                    If func.Imports(iMB1).ParamValue = "Y" Then
                        oResult = func.Imports(iNUMBBA).ParamValue
                        oAjusteInfo.FolioSAP = oResult.Trim
                    End If
                End If

                'If func.Imports(iMB1).ParamValue = "Y" Then
                '    oResult = func.Imports(iNUMBBA).ParamValue
                '    oAjusteInfo.FolioSAP = oResult
                'Else
                '    Dim dtMessage As DataTable
                '    Dim strMensaje As String
                '    dtMessage = func.Tables("RETURN").ToADOTable
                '    For Each oRow As DataRow In dtMessage.Rows
                '        strMensaje &= CStr(oRow("message")).Trim & vbCrLf
                '    Next
                '    MsgBox("Error al realizar los  Ajustes en SAP: " & vbCrLf & strMensaje, MsgBoxStyle.Exclamation, "Auditoria")
                '    oResult = String.Empty
                'End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            oResult = String.Empty
        Catch e1 As ERPConnect.ERPException
            oResult = String.Empty
        End Try

        oAjusteInfo.FolioSAP = oResult
        Return oResult

    End Function

    'Friend Function Write_ZBAPI_AJUSTESOB(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, ByVal strFolio As String, ByVal strCodigo As String, ByVal intCantidad As Integer, ByVal strTalla As String, Optional ByVal dtTemp As DataTable = Nothing) As String

    '    Dim oResult As String = String.Empty

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oTEXTO_CABECERA As Object       '--Campo de usuario para cluster PC nacional
    '        Dim oVALE_ALMACEN As Object         '--Campo de usuario para cluster PC nacional
    '        Dim oWERKS As Object                '--Ámbito no definido , posiblemente para niveles patch
    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oNUMMB1C As Object           '--Campo de texto, longitud 10
    '        Dim oMB1A As Object                 '--Indicador de una posición (Ajustes de Salida)
    '        '--Fin parametros Imports/

    '        '/--Detalle
    '        Dim oTTArticulos As Object 'Tabla de pedidos de MM para Bapi
    '        Dim oTbDatosDet As SAPTableFactoryCtrl.Table
    '        '--Detalee

    '        Dim oMesstab As Object 'Acumular mensajes en sistema SAP
    '        Dim oRETURN As Object 'Parámetro de retorno

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            objR3 = Nothing
    '            Exit Function
    '        End If

    '        '--Implementamos Nombre BAPI
    '        If oAjusteInfo.TipoAjuste = "E" Then
    '            objFunc = objR3.Add("ZBAPI_AJUSTEENTRADA")
    '            '/--Imports
    '            oNUMMB1C = objFunc.Imports("NUMMB1C") ''--Campo de texto, longitud 10
    '            '--Fin Imports/
    '        Else
    '            objFunc = objR3.Add("ZBAPI_AJUSTESALIDA")
    '            '/--Imports
    '            oNUMMB1C = objFunc.Imports("NUMMB1A")         ''--Campo de texto, longitud 10
    '            oMB1A = objFunc.Imports("MB1A")               '--Indicador de una posición (Ajustes de Salida)
    '            '--
    '        End If

    '        '/--Parametros Exports
    '        oTEXTO_CABECERA = objFunc.Exports("TEXTO_CABECERA")      '--Campo de usuario para cluster PC nacional
    '        oVALE_ALMACEN = objFunc.Exports("VALE_ALMACEN")          '--Campo de usuario para cluster PC nacional
    '        oWERKS = objFunc.Exports("WERKS")                        '--Ámbito no definido , posiblemente para niveles patch
    '        '--Fin Parametros Exports/



    '        '/--Tablas
    '        oTbDatosDet = objFunc.Tables("TT_ARTICULOS")
    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oRETURN = objFunc.Tables("RETURN")
    '        '--Fin Tablas/

    '        oTEXTO_CABECERA.Value = "AJUSTE DE " & oAjusteInfo.TipoAjuste & " " & oAjusteInfo.Almacen & " POR SOBRANTE EN TRASPASO " & strFolio
    '        oVALE_ALMACEN.Value = "Folio DpPro " & oAjusteInfo.FolioAjuste
    '        oWERKS.Value = oParent.Read_Centros
    '        If dtTemp Is Nothing Then
    '            'For Each oRow As DataRow In oAjusteInfo.Detalle.Rows
    '            '--DatosDet
    '            oTTArticulos = oTbDatosDet.AppendRow()
    '            oTTArticulos.Value("MATNR") = strCodigo
    '            oTTArticulos.Value("CENTRO_DESTINO") = oWERKS.Value
    '            oTTArticulos.Value("MENGE") = intCantidad
    '            oTTArticulos.Value("TALLA") = oParent.FormatTalla(strTalla)
    '            'Next
    '        Else
    '            'For Each oRow As DataRow In dtTemp.Rows
    '            '--DatosDet
    '            oTTArticulos = oTbDatosDet.AppendRow()
    '            oTTArticulos.Value("MATNR") = strCodigo
    '            oTTArticulos.Value("CENTRO_DESTINO") = oWERKS.Value
    '            oTTArticulos.Value("MENGE") = intCantidad
    '            oTTArticulos.Value("TALLA") = oParent.FormatTalla(strTalla)
    '            'Next
    '        End If



    '        Dim b As Boolean
    '        b = objFunc.Call()

    '        If b Then
    '            If oAjusteInfo.TipoAjuste = "E" Then
    '                oResult = oNUMMB1C.Value
    '                oAjusteInfo.FolioSAP = oResult
    '            Else
    '                If oMB1A.Value = "Y" Then
    '                    oResult = oNUMMB1C.Value
    '                    oAjusteInfo.FolioSAP = oResult
    '                End If
    '            End If
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oResult = String.Empty
    '        oAjusteInfo.FolioSAP = oResult

    '    End Try

    '    oAjusteInfo.FolioSAP = oResult
    '    Return oResult

    'End Function

    Friend Function Write_ZBAPI_AJUSTESOB(ByVal oAjusteInfo As AjusteGeneralNuevo.AjusteGeneralInfo, ByVal strFolio As String, ByVal strCodigo As String, ByVal intCantidad As Integer, ByVal strTalla As String, Optional ByVal dtTemp As DataTable = Nothing) As String
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim oResult As String = String.Empty
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_AJUSTEXXXXX              ****
                '*****************************************************
                ' Create a function object
                Dim RFC As String
                Dim func As ERPConnect.RFCFunction
                If oAjusteInfo.TipoAjuste = "E" Then
                    RFC = "ZBAPI_AJUSTEENTRADA"
                Else
                    RFC = "ZBAPI_AJUSTESALIDA"
                End If
                func = R3.CreateFunction(RFC)

                '' Asigno valores a los objetos
                func.Exports("TEXTO_CABECERA").ParamValue = "AJUSTE DE " & oAjusteInfo.TipoAjuste & " " & oAjusteInfo.Almacen & " POR SOBRANTE EN TRASPASO " & strFolio
                func.Exports("VALE_ALMACEN").ParamValue = "Folio DpPro " & oAjusteInfo.FolioAjuste
                func.Exports("WERKS").ParamValue = oParent.Read_Centros

                'tablas
                Dim T_Lines As ERPConnect.RFCTable = func.Tables("TT_ARTICULOS")
                Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                R_Lines("MATNR") = strCodigo
                R_Lines("CENTRO_DESTINO") = func.Exports("WERKS").ParamValue
                R_Lines("MENGE") = intCantidad
                R_Lines("TALLA") = oParent.FormatTalla(strTalla)

                'If dtTemp Is Nothing Then
                '    'For Each oRow As DataRow In oAjusteInfo.Detalle.Rows
                '    '--DatosDet
                '    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                '    R_Lines("MATNR") = strCodigo
                '    R_Lines("CENTRO_DESTINO") = func.Exports("WERKS").ParamValue
                '    R_Lines("MENGE") = intCantidad
                '    R_Lines("TALLA") = oParent.FormatTalla(strTalla)
                '    'Next
                'Else
                '    'For Each oRow As DataRow In dtTemp.Rows
                '    '--DatosDet
                '    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                '    R_Lines("MATNR") = strCodigo
                '    R_Lines("CENTRO_DESTINO") = func.Exports("WERKS").ParamValue
                '    R_Lines("MENGE") = intCantidad
                '    R_Lines("TALLA") = oParent.FormatTalla(strTalla)
                '    'Next
                'End If


                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'Obtenemos datos
                If CStr(func.Imports("NUMMB1C").ParamValue) <> String.Empty Then
                    If oAjusteInfo.TipoAjuste = "E" Then
                        oResult = func.Imports("NUMMB1C").ParamValue
                        oAjusteInfo.FolioSAP = oResult
                    Else
                        If func.Imports("MB1A").ParamValue = "Y" Then
                            oResult = func.Imports("NUMMB1C").ParamValue
                            oAjusteInfo.FolioSAP = oResult
                        End If
                    End If
                End If



            End If

        Catch e1 As ERPConnect.RFCServerException
            oResult = String.Empty
        Catch e1 As ERPConnect.ERPException
            oResult = String.Empty
        End Try

        oAjusteInfo.FolioSAP = oResult
        Return oResult

    End Function

#End Region

#Region "Ajuste Talla"

    'Friend Function Write_ZBAPI_AJUSTETalla(ByVal oAjusteInfo As AjusteGeneralTallaInfo) As String

    '    Dim oResult As String = String.Empty

    '    Try

    '        Dim objR3 As New SAPFunctionsOCX.SAPFunctions
    '        Dim objFunc As SAPFunctionsOCX.Function

    '        '/--Parametros Exports
    '        Dim oTEXTO_CABECERA As Object       '--Campo de usuario para cluster PC nacional
    '        Dim oVALE_ALMACEN As Object         '--Campo de usuario para cluster PC nacional
    '        Dim oWERKS As Object                '--Ámbito no definido , posiblemente para niveles patch
    '        Dim oCodigo As Object               '--Codigo que se hara cambio talla
    '        Dim oTALLA_S As Object              '--Talla de Salida
    '        Dim oTALLA_E As Object              '--Talla de Entrada
    '        Dim oCANTIDAD As Object             '--Cantidad por la que se hara cambio
    '        Dim oModo As Object                 '--MODO


    '        '--Fin Parametros Exports/

    '        '/--Parametros Imports
    '        Dim oNUMMB1C As Object              '--Campo de texto, longitud 10
    '        Dim oMB1C As Object                 '--Indicador de una posición            
    '        '--Fin parametros Imports/

    '        Dim oMesstab As Object 'Acumular mensajes en sistema SAP
    '        Dim oRETURN As Object 'Parámetro de retorno

    '        With objR3.Connection
    '            .ApplicationServer = oParent.SAPApplicationConfig.ApplicationServer
    '            .GroupName = oParent.SAPApplicationConfig.GroupName
    '            .System = oParent.SAPApplicationConfig.System
    '            .Client = oParent.SAPApplicationConfig.Client
    '            .User = oParent.SAPApplicationConfig.User
    '            .Password = oParent.SAPApplicationConfig.Password
    '            .Language = oParent.SAPApplicationConfig.Language
    '            .SystemNumber = oParent.SAPApplicationConfig.System
    '        End With

    '        If objR3.Connection.logon(0, True) <> True Then
    '            objR3 = Nothing
    '            Exit Function
    '        End If

    '        objFunc = objR3.Add("ZBAPI_AJUSTEGENERAL")

    '        '/--Imports
    '        oNUMMB1C = objFunc.Imports("NUMMB1C")       '--Campo de texto, longitud 10
    '        oMB1C = objFunc.Imports("MB1C")             '--Indicador de una posición (Ajustes de Salida)
    '        '---Fin Imports/

    '        '/--Parametros Exports
    '        oTEXTO_CABECERA = objFunc.Exports("TEXTO_CABECERA")         '--Campo de usuario para cluster PC nacional
    '        oVALE_ALMACEN = objFunc.Exports("VALE_ALMACEN")             '--Campo de usuario para cluster PC nacional
    '        oWERKS = objFunc.Exports("WERKS")                           '--Ámbito no definido , posiblemente para niveles patch
    '        oCodigo = objFunc.Exports("Codigo")                        '--Codigo que se hara cambio talla
    '        oTALLA_S = objFunc.Exports("TALLA_S")                      '--Talla de Salida
    '        oTALLA_E = objFunc.Exports("TALLA_E")                      '--Talla de Entrada
    '        oCANTIDAD = objFunc.Exports("CANTIDAD")                    '--Cantidad por la que se hara cambio
    '        oModo = objFunc.Exports("MODE")
    '        '--Fin Parametros Exports/

    '        oMesstab = objFunc.Tables("MESSTAB")
    '        oRETURN = objFunc.Tables("RETURN")


    '        oTEXTO_CABECERA.Value = oAjusteInfo.Observaciones
    '        oVALE_ALMACEN.Value = "Folio Dp " & CStr(oAjusteInfo.FolioAjuste)
    '        oWERKS.Value = oParent.Read_Centros
    '        oCodigo.Value = oAjusteInfo.Codigo
    '        oTALLA_S.Value = oParent.FormatTalla(oAjusteInfo.Talla_S)
    '        oTALLA_E.Value = oParent.FormatTalla(oAjusteInfo.Talla_E)
    '        oCANTIDAD.Value = oAjusteInfo.Cantidad
    '        oModo.Value = "N"

    '        Dim b As Boolean
    '        b = objFunc.Call()

    '        If b Then
    '            If oMB1C.Value = "Y" Then
    '                oResult = oNUMMB1C.Value
    '                oAjusteInfo.FolioSAP = oResult
    '            End If
    '        End If

    '        objR3.Connection.LogOff()


    '    Catch ex As Exception

    '        oResult = String.Empty
    '        oAjusteInfo.FolioSAP = oResult

    '    End Try

    '    oAjusteInfo.FolioSAP = oResult
    '    Return oResult

    'End Function

    Friend Function Write_ZBAPI_AJUSTETalla(ByVal oAjusteInfo As AjusteGeneralTallaInfo) As String

        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim oResult As String = String.Empty
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_AJUSTEGENERAL     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_AJUSTEGENERAL")

                '' Asigno valores a los objetos
                func.Exports("TEXTO_CABECERA").ParamValue = oAjusteInfo.Observaciones
                func.Exports("VALE_ALMACEN").ParamValue = "Folio Dp " & CStr(oAjusteInfo.FolioAjuste)
                func.Exports("WERKS").ParamValue = oParent.Read_Centros
                func.Exports("Codigo").ParamValue = oAjusteInfo.Codigo
                func.Exports("TALLA_S").ParamValue = oParent.FormatTalla(oAjusteInfo.Talla_S)
                func.Exports("TALLA_E").ParamValue = oParent.FormatTalla(oAjusteInfo.Talla_E)
                func.Exports("CANTIDAD").ParamValue = oAjusteInfo.Cantidad
                func.Exports("MODE").ParamValue = "N"

                ' Ejecuta función
                func.Execute()

                'Cierra la Conexion
                R3.Close()

                'obtenemos datos
                If func.Imports("MB1C").ParamValue = "Y" Then
                    oResult = func.Imports("NUMMB1C").ParamValue
                    oAjusteInfo.FolioSAP = oResult
                End If


            End If

        Catch e1 As ERPConnect.RFCServerException

            oResult = String.Empty
            oAjusteInfo.FolioSAP = oResult

        Catch e1 As ERPConnect.ERPException

            oResult = String.Empty
            oAjusteInfo.FolioSAP = oResult

        End Try

        oAjusteInfo.FolioSAP = oResult
        Return oResult

    End Function

#End Region

#Region "Reporte Movimientos Historicos"

    ''''Reportes
    '''
    Friend Function Read_HistoricoMovimientos(ByVal strCodArticulo As String, ByVal FechaInicio As String, ByVal FechaFin As String, _
    ByRef intExports() As Integer) As DataTable

        Dim dtMovimientos As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIMM_HISTORIAL_MOVIMIENTOS *****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM_HISTORIAL_MOVIMIENTOS")

                func.Exports("MATNR").ParamValue = strCodArticulo
                func.Exports("WERKS").ParamValue = oParent.Read_Centros()
                func.Exports("LGORT").ParamValue = "M001"
                func.Exports("FechaInicio").ParamValue = FechaInicio
                func.Exports("FechaFin").ParamValue = FechaFin

                func.Execute()
                R3.Close()

                '/--Asigno al arreglo los valores de salida de la BAPI--\
                intExports(0) = func.Imports("ESTOCKINICIAL").ToInt32
                intExports(1) = func.Imports("ENTRADAS").ToInt32
                intExports(2) = func.Imports("SALIDAS").ToInt32
                intExports(3) = func.Imports("ESTOCKFINAL").ToInt32

                dtMovimientos = func.Tables("T_MOVIMIENTOS").ToADOTable

                'Declaro las variables que voy a utilizar para el stock inicial, final, entradas y salidas
                Dim vlEntradasAR, vlSalidasAR, vlEntradasBR, vlSalidasBR As Integer

                '/--Agrego la columna para el FolioDpPro--\
                'sE COMENTO POR QUE YA NO VA  A SALIR EN EL GRID
                'Dim dcFolioDpPro As New DataColumn
                'With dcFolioDpPro
                '    .ColumnName = "FolioDpPro"
                '    .Caption = "Folio DpPro"
                '    .DataType = GetType(System.String)
                '    .DefaultValue = String.Empty
                'End With
                'With dtMovimientos.Columns
                '    .Add(dcFolioDpPro)
                'End With
                'dtMovimientos.AcceptChanges()

                For Each orow As DataRow In dtMovimientos.Rows
                    orow!BUDAT = Mid(orow!BUDAT, 7, 2) & "/" & Mid(orow!BUDAT, 5, 2) & "/" & Mid(orow!BUDAT, 1, 4)
                    If orow!SHKZG = "H" Then
                        If CDate(orow!BUDAT) > CDate(FechaFin) Then
                            vlSalidasAR += orow!MENGE
                        Else
                            vlSalidasBR += orow!MENGE
                        End If
                        orow!MENGE *= -1
                    Else
                        If CDate(orow!BUDAT) > CDate(FechaFin) Then
                            vlEntradasAR += orow!MENGE
                        Else
                            vlEntradasBR += orow!MENGE
                        End If
                    End If

                    Select Case orow!BWART
                        Case "102"
                            orow!DESCRIPCION = "Anulación de traspaso de entrada"
                        Case "602"
                            orow!DESCRIPCION = "Anulación de venta"
                        Case "657"
                            orow!DESCRIPCION = "Devolución"
                        Case "101"
                            orow!DESCRIPCION = "Ingreso Traspaso"
                            orow!FolioSD = orow!FolioTras
                        Case "601"
                            '---------------------------------------------------------------------
                            ' JNAVA (17.03.2017): Validamos si es de Ecommerce
                            '---------------------------------------------------------------------
                            If CStr(orow!FOLIOPRO).Trim = "30" Then
                                orow!DESCRIPCION = "Ecommerce"
                            Else
                                orow!DESCRIPCION = "Venta"
                            End If
                            '---------------------------------------------------------------------
                            'orow!FOLIOSD = Me.oParent.SelFolioSAPByFolioFI(orow!FOLIOFI)
                        Case "501"
                            orow!DESCRIPCION = "Entrada sin pedido"
                        Case "502"
                            orow!DESCRIPCION = "DM. Entr. sin descripción"
                        Case "561"
                            orow!DESCRIPCION = "Carga inicial"
                        Case "309"
                            orow!DESCRIPCION = "Cambio Talla/Modelo"
                        Case "551"
                            orow!DESCRIPCION = "Ajuste Salida"
                        Case "562"
                            orow!DESCRIPCION = "Anulación ajuste carga"
                        Case "351"
                            orow!DESCRIPCION = "Traspaso de salida"
                        Case "653"
                            orow!DESCRIPCION = "Cancelación y/o devolución inventario"
                            'orow!FOLIOSD = Me.oParent.SelFolioSAPByFolioFI(orow!FOLIOFI)
                        Case "552"
                            orow!DESCRIPCION = "Ajuste de entrada"
                        Case "352"
                            orow!DESCRIPCION = "Devolución de transito"
                        Case "344"
                            orow!DESCRIPCION = "Bloqueo de producto"
                        Case "343"
                            orow!DESCRIPCION = "Desbloqueo de producto"
                        Case Else
                            orow!DESCRIPCION = "Sin descripción"
                    End Select
                    'orow!FolioDPpro = oParent.getFolioDpPro(orow("BWART"), orow("FolioSD"), orow("FolioTras"))
                Next

                Dim dcFechaPC As New DataColumn
                With dcFechaPC
                    .ColumnName = "FechaPC"
                    .Caption = "FechaPC"
                    .DataType = GetType(Date)
                    .Expression = "BUDAT"
                End With
                With dtMovimientos.Columns
                    .Add(dcFechaPC)
                End With

                dtMovimientos.AcceptChanges()

                intExports(3) += (vlSalidasAR - vlEntradasAR)
                intExports(0) = intExports(3) + (vlSalidasBR - vlEntradasBR)
                intExports(1) = vlEntradasBR
                intExports(2) = vlSalidasBR

                '/-- Agregar la columna --\
                Dim dcTipoMov As New DataColumn
                With dcTipoMov
                    .ColumnName = "TipoMov"
                    .Caption = "Tipo Mov"
                    .DataType = GetType(System.String)
                    .DefaultValue = String.Empty
                End With
                With dtMovimientos.Columns
                    .Add(dcTipoMov)
                End With
                dtMovimientos.AcceptChanges()

                '/--Asignarle el valor dependiendo de la cantidad [>=0 en Entrada; <0 es Salida]
                Dim dvTipoMovE As New DataView(dtMovimientos, "MENGE >=0", "MENGE", DataViewRowState.CurrentRows)
                For Each oRowE As DataRowView In dvTipoMovE
                    oRowE("TipoMov") = "Entrada"
                Next
                dtMovimientos.AcceptChanges()
                Dim dvTipoMovS As New DataView(dtMovimientos, "MENGE <0", "MENGE", DataViewRowState.CurrentRows)
                For Each oRowS As DataRowView In dvTipoMovS
                    oRowS("TipoMov") = "Salida"
                Next
                dtMovimientos.AcceptChanges()
                '/----\

                Return dtMovimientos

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

#End Region

#Region "Carga Dias Cierre SAP"

    Friend Function ZBAPIFI05_VENTASDIA(ByRef strResult As String, ByVal strFname As String) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)
            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPIFI05_VENTASDIA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIFI05_VENTASDIA")

                func.Exports("FNAME").ParamValue = strFname

                func.Execute()

                'A es un error en la carga del archivo, no se cargo nada
                'B es porque en una o varias no se registro el abono
                'Nada es OK
                strResult = func.Imports("E_RESULT").ToString()

                dtResultado = func.Tables("RESULTADO").ToADOTable
                R3.Close()

                Return dtResultado

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

#End Region

#Region "Guarda Referencia Bultos Paqueteria"

    'Friend Function ReadInfoPaqueteria(ByVal FolioTraslado As String, ByVal Elemento As String) As String

    '    Dim strResult As String

    '    Dim R3 As New ERPConnect.R3Connection( _
    '             oParent.SAPApplicationConfig.ApplicationServer, _
    '             oParent.SAPApplicationConfig.System, _
    '             oParent.SAPApplicationConfig.User, _
    '             oParent.SAPApplicationConfig.Password, _
    '             oParent.SAPApplicationConfig.Language, _
    '             oParent.SAPApplicationConfig.Client)
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZREAD_TEXT")

    '            func.Exports("I_CLIENT").ParamValue = oParent.SAPApplicationConfig.Client
    '            func.Exports("I_ID").ParamValue = Elemento  ' Elemento F01, F03, F03 (Guia, Bulto, Paqueteria)
    '            func.Exports("I_LANGUAGE").ParamValue = oParent.SAPApplicationConfig.Language  ' Idioma
    '            func.Exports("I_NAME").ParamValue = FolioTraslado
    '            func.Exports("I_OBJECT").ParamValue = "EKKO"  ' Tabla Cabecera
    '            func.Exports("I_ARCHIVE_HANDLE").ParamValue = "0"
    '            func.Exports("I_LOCAL_CAT").ParamValue = ""
    '            func.Execute()
    '            R3.Close()

    '            Dim T_Lines As ERPConnect.RFCTable = func.Tables("T_Lines")
    '            If T_Lines.RowCount > 0 Then
    '                strResult = CStr(T_Lines.Rows(0)("TDLine"))
    '            End If


    '            Return strResult
    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    Finally
    '        If R3.Ping = True Then
    '            R3.Close()
    '        End If
    '    End Try

    'End Function

    '---------------------------------------------------------
    ' JNAVA (16.02.2016): Adaptado para cambios en Retail
    '---------------------------------------------------------
    Friend Sub ReadInfoPaqueteria(ByVal FolioTraslado As String, ByRef Guia As String, ByRef Transportista As String, ByRef Bultos As Integer)

        Dim R3 As New ERPConnect.R3Connection( _
                 oParent.SAPApplicationConfig.ApplicationServer, _
                 oParent.SAPApplicationConfig.System, _
                 oParent.SAPApplicationConfig.User, _
                 oParent.SAPApplicationConfig.Password, _
                 oParent.SAPApplicationConfig.Language, _
                 oParent.SAPApplicationConfig.Client)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMF_OBTENCION_GUIA")
                func.Exports("I_VBELN").ParamValue = FolioTraslado

                func.Execute()
                R3.Close()

                ' Obtenemos valores
                Guia = func.Imports("E_BOLNR").ParamValue.ToString.TrimEnd
                Transportista = func.Imports("E_BEZEI").ParamValue.ToString.TrimEnd

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Finally
            If R3.Ping = True Then
                R3.Close()
            End If
        End Try

    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (17.02.2016): se comenta por que ya no se usara pues la BAPI de ZBAPIMM02_PEDIDOTRAS incluye la funcionalidad
    '-----------------------------------------------------------------------------------------------------------------------------------
    'Friend Function SaveInfoPaqueteria(ByVal FolioTraslado As String, ByVal Valor As String, ByVal Elemento As String) As String

    '    Dim strResult As String

    '    Dim R3 As New ERPConnect.R3Connection( _
    '             oParent.SAPApplicationConfig.ApplicationServer, _
    '             oParent.SAPApplicationConfig.System, _
    '             oParent.SAPApplicationConfig.User, _
    '             oParent.SAPApplicationConfig.Password, _
    '             oParent.SAPApplicationConfig.Language, _
    '             oParent.SAPApplicationConfig.Client)
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSAVE_TEXT")

    '            func.Exports("I_CLIENT").ParamValue = oParent.SAPApplicationConfig.Client

    '            Dim header As ERPConnect.RFCStructure = func.Exports("I_HEADER").ToStructure
    '            header("TDOBJECT") = "EKKO" ' Tabla Cabecera
    '            header("TDNAME") = FolioTraslado
    '            header("TDID") = Elemento ' Elemento F01, F03, F03 (Guia, Bulto, Paqueteria)
    '            header("TDSPRAS") = oParent.SAPApplicationConfig.Language ' Idioma

    '            func.Exports("I_INSERT").ParamValue = ""
    '            func.Exports("I_SAVEMODE_DIRECT").ParamValue = "X"
    '            func.Exports("I_OWNER_SPECIFIED").ParamValue = ""
    '            func.Exports("I_LOCAL_CAT").ParamValue = ""

    '            Dim T_Lines As ERPConnect.RFCTable = func.Tables("T_Lines")
    '            Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
    '            R_Lines("TDFormat") = "*"
    '            R_Lines("TDLine") = Valor

    '            func.Execute()
    '            R3.Close()

    '            strResult = func.Imports("E_FUNCTION").ParamValue()
    '            Return strResult
    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    Finally
    '        If R3.Ping = True Then
    '            R3.Close()
    '        End If
    '    End Try

    'End Function

    Friend Function ZBAPI_AplicaTrasladoEntradaParcial(ByVal FolioTraslado As String, ByVal dtMateriales As DataTable) As String

        Dim strResult As String = ""
        Dim dtMessage As DataTable
        Dim strMensaje As String = ""

        Dim R3 As New ERPConnect.R3Connection( _
                 oParent.SAPApplicationConfig.ApplicationServer, _
                 oParent.SAPApplicationConfig.System, _
                 oParent.SAPApplicationConfig.User, _
                 oParent.SAPApplicationConfig.Password, _
                 oParent.SAPApplicationConfig.Language, _
                 oParent.SAPApplicationConfig.Client)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_MOVTO_PARCIAL")

                func.Exports("I_TRASLADO").ParamValue = FolioTraslado.Trim.PadLeft(10, "0")
                func.Exports("I_MOVIMIENTO").ParamValue = "101"

                '-----------------------------------------------------------------------------
                'JNAVA (15.02.2016): Se cambio nombre de tabla para retail
                '-----------------------------------------------------------------------------
                Dim T_Traslado As ERPConnect.RFCTable = func.Tables("IT_GOODSMVT_ITEM") 'func.Tables("IT_AFS_GOODSMVT_ITEM")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each oRow In dtMateriales.Rows
                    R_Lines = T_Traslado.AddRow
                    R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim
                    R_Lines("PLANT") = oParent.Read_Centros.Trim.ToUpper
                    R_Lines("STGE_LOC") = "M001" '"A001"
                    '-----------------------------------------------------------------------------
                    'JNAVA (15.02.2016): Se comento por cambio a retail
                    '-----------------------------------------------------------------------------
                    'If IsNumeric(CStr(oRow!Talla)) Then
                    '    R_Lines("GRID_VALUE") = Format(CDec(oRow!Talla), "#.0")
                    'Else
                    '    R_Lines("GRID_VALUE") = CStr(oRow!Talla).Trim
                    'End If
                    'R_Lines("GRID_VALUE") = CStr(oRow!Talla).Trim
                    R_Lines("PO_ITEM") = CStr(oRow!EBELP)
                    R_Lines("ENTRY_QNT") = CInt(oRow!Cantidad)
                    R_Lines("SCHED_LINE_SKU") = CStr(oRow!ETENR)
                Next

                func.Execute()
                R3.Close()

                strResult = CStr(func.Imports("E_MATERIALDOCUMENT").ParamValue).Trim.ToUpper
                dtMessage = func.Tables("IT_RETURN").ToADOTable

                If strResult.Trim = "" Then
                    For Each oRow In dtMessage.Rows
                        strMensaje &= CStr(oRow("message")).Trim & vbCrLf
                    Next
                    MsgBox(strMensaje, MsgBoxStyle.Exclamation, "Error al aplicar el traspaso en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Finally
            If R3.Ping = True Then
                R3.Close()
            End If
        End Try

        Return strResult

    End Function



#End Region

#Region "Actualiza Direccion Telefono y Email clientes"

    Friend Function ActualizaClientes(ByVal strClienteID As String, ByVal strCalleNum As String, ByVal strCp As String, _
    ByVal strPoblacion As String, ByVal strEstado As String, ByVal strTelefono As String, ByVal stremail As String _
    , ByVal strColonia As String) As String

        Dim strE_Result As String

        Dim R3 As New ERPConnect.R3Connection( _
                 oParent.SAPApplicationConfig.ApplicationServer, _
                 oParent.SAPApplicationConfig.System, _
                 oParent.SAPApplicationConfig.User, _
                 oParent.SAPApplicationConfig.Password, _
                 oParent.SAPApplicationConfig.Language, _
                 oParent.SAPApplicationConfig.Client)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_MODIFCLIENT")

                func.Exports("KUNNR").ParamValue = strClienteID
                func.Exports("STRAS").ParamValue = strCalleNum
                func.Exports("PSTLZ").ParamValue = strCp
                func.Exports("ORT01").ParamValue = strPoblacion
                func.Exports("REGIO").ParamValue = strEstado
                func.Exports("TELF1").ParamValue = strTelefono
                func.Exports("KNURL").ParamValue = stremail
                func.Exports("ORT02").ParamValue = strColonia
                func.Exports("VKORG").ParamValue = "CDPT"
                If Not oParent.ApplicationContext.ApplicationConfiguration.Almacen = "053" Then
Cambio_053:
                    func.Exports("VTWEG").ParamValue = "T1"
                Else
                    GoTo Cambio_053
                    'func.Exports("VTWEG").ParamValue = "C1"
                End If
                func.Exports("SPART").ParamValue = "VG"

                func.Execute()
                R3.Close()

                strE_Result = func.Imports("E_RESULT").ToString()



                Return strE_Result
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Finally
            If R3.Ping = True Then
                R3.Close()
            End If
        End Try

    End Function




#End Region

#Region "Consulta Existencias dl Z001"

    Friend Function ZBAPI_CONSULTA_ALLSTOCK(ByRef strCodArticulo As String) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CONSULTA_ALLSTOCK
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_CONSULTA_ALLSTOCK")
                Dim T_MAT As ERPConnect.RFCTable = func.Tables("T_MATERIALES_IN")
                Dim R_Lines As ERPConnect.RFCStructure = T_MAT.AddRow()
                R_Lines("CODARTICULO") = strCodArticulo
                R_Lines("CENTRO") = "1000"
                'func.Exports("I_CODARTICULO").ParamValue = strCodArticulo
                'func.Exports("I_CENTRO").ParamValue = "Z001"

                func.Execute()
                R3.Close()

                dtResultado = func.Tables("T_ZEXISTENCIA").ToADOTable

                Return dtResultado

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

#End Region

#Region "DPVALE SAP"

    'Friend Function ZBAPI_VALIDA_REVALE(ByVal cdpvale As cDPVale) As cDPVale

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPI_VALIDA_REVALE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_REVALE")

    '            func.Exports("INUMVA").ParamValue = cdpvale.INUMVA

    '            func.Execute()

    '            cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable
    '            cdpvale.EEXIST = func.Imports("EEXIST").ToString

    '            R3.Close()

    '            Return cdpvale

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    'Friend Function ZBAPI_VALIDA_DPVALE(ByVal cdpvale As cDPVale) As cDPVale

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPI_VALIDA_DPVALE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_DPVALE")

    '            func.Exports("INUMVA").ParamValue = cdpvale.INUMVA
    '            If cdpvale.I_RUTA.Trim = String.Empty Then
    '                func.Exports("I_RUTA").ParamValue = "X"
    '            Else
    '                func.Exports("I_RUTA").ParamValue = cdpvale.I_RUTA
    '            End If

    '            func.Execute()

    '            cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable

    '            cdpvale.EEXIST = func.Imports("EEXIST").ToString
    '            cdpvale.ESTATU = func.Imports("ESTATU").ToString
    '            cdpvale.EPLAZA = func.Imports("EPLAZA").ToString
    '            cdpvale.LimiteCredito = CDec(func.Imports("ELCREDITO").ToString)
    '            cdpvale.Congelado = func.Imports("Congelado").ToString
    '            cdpvale.LimiteCreditoPrestamo = CDec(func.Imports("ECREDITOP").ToString)
    '            cdpvale.FlagPrestamo = func.Imports("EPRESTAMO").ToString
    '            R3.Close()

    '            Return cdpvale

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    Friend Function ZBAPI_VALIDA_VALE_EMPLEADO(ByVal VE As ValeEmpleado) As ValeEmpleado

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_CONSULTAVALEDESCTO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_CONSULTAVALEDESCTO")

                func.Exports("FOLIO").ParamValue = VE.Folio.ToString.PadLeft(5, "0")
                func.Exports("SERIE").ParamValue = VE.Serie.ToUpper

                func.Execute()

                R3.Close()

                'cdPVale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable

                VE.Status = func.Imports("STATU").ToString
                VE.Descuento = func.Imports("PORCENTAJE").ParamValue / 100
                VE.EsRevale = IIf(func.Imports("REVALE").ToString = "X", True, False)
                'VE.FechaFinVigencia = func.Imports("FECHA").ToString


                Return VE

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_QUEMA_VALE_EMPLEADO(ByVal Folio As String, ByVal Serie As String, ByVal FolioSAP As String) As String

        Dim Status As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_QUEMARVALEDESCTO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_QUEMARVALEDESCTO")

                func.Exports("FOLIO").ParamValue = Folio.PadLeft(5, "0")
                func.Exports("SERIE").ParamValue = Serie
                func.Exports("FOLIOSD").ParamValue = FolioSAP

                func.Execute()
                R3.Close()


                Status = func.Imports("STATU").ToString

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_QUEMA_CUPON_DESCUENTO(ByVal Folio As String, ByVal TipoVenta As String, ByVal FolioSAP As String, _
    ByRef FolioNuevo As String, ByVal formasPago As DataTable) As String

        Dim Status As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCUP_UTIL_CUPON
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCUP_UTIL_CUPON")

                If Not formasPago Is Nothing Then
                    Dim T_FormasPago As ERPConnect.RFCTable = func.Tables("T_FORMASPAGO")
                    Dim R_Lines As ERPConnect.RFCStructure
                    For Each row As DataRow In formasPago.Rows
                        R_Lines = T_FormasPago.AddRow()
                        R_Lines("FORMA_PAGO") = CStr(row!FORMA_PAGO)
                    Next
                End If

                func.Exports("I_FOLIO").ParamValue = Folio.Trim
                func.Exports("I_TIPO_VENTA").ParamValue = TipoVenta.Trim
                func.Exports("I_FECHA").ParamValue = Format(Today, "yyyyMMdd")
                func.Exports("I_DOCTO_VTA").ParamValue = FolioSAP
                func.Exports("I_OFNA_VTA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen

                func.Execute()
                R3.Close()

                Status = func.Imports("I_RESULTADO").ToString
                FolioNuevo = func.Imports("E_FOLIO").ToString

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_GENERA_REVALE_EMPLEADO(ByVal FolioSAP As String, ByRef ValeE As ValeEmpleado) As String

        Dim Status As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGENERAR_REVALE_EMPLEADO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGENERAR_REVALE_EMPLEADO")

                func.Exports("FOLIOSD").ParamValue = FolioSAP

                func.Execute()
                R3.Close()

                ValeE = New ValeEmpleado
                ValeE.Folio = func.Imports("FOLIO").ParamValue
                ValeE.Serie = func.Imports("SERIE").ParamValue

                Status = func.Imports("E_RESULT").ToString

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_GENERA_RECUPON(ByRef oReCupon As CuponDescuento, ByVal FolioSAP As String, ByRef FolioCupon As String, ByVal Desc As Decimal, ByVal Minimo As Decimal) As String

        Dim Status As String = ""
        Dim FechaVig As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCUP_DEV_Y_RECUPON
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCUP_DEV_Y_RECUPON")

                func.Exports("I_FOLIO_CUP").ParamValue = FolioCupon.Trim.ToUpper
                func.Exports("I_DOCUMENTO_DEV").ParamValue = FolioSAP
                func.Exports("I_SUCURSAL_DEV").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_IMP_RECUP").ParamValue = Desc
                func.Exports("I_IMP_DEV").ParamValue = Minimo

                func.Execute()
                R3.Close()

                Status = func.Imports("E_RESULTADO").ToString

                If CInt(Status) = 1 Then
                    oReCupon = New CuponDescuento
                    With oReCupon
                        .Folio = func.Imports("E_FOLIO_RECUP").ToString.ToUpper.Trim
                        .Descripcion = func.Imports("E_DESCRIPCION").ToString
                        FechaVig = func.Imports("E_FECHA_FIN").ToString
                        .FechaVigencia = CDate(FechaVig.Substring(6, 2) & "/" & FechaVig.Substring(4, 2) & "/" & FechaVig.Substring(0, 4))
                        .Minimo = func.Imports("E_MINIMO").ParamValue
                        .LimiteDescuento = func.Imports("E_LIMITE_DESCTO").ParamValue
                    End With
                End If

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_REVIVE_CUPON(ByRef FolioCupon As String, Optional ByRef cuponPadre As String = "") As String

        Dim Status As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCUP_CANCELACION
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCUP_CANCELACION")

                func.Exports("I_FOLIO_CUP").ParamValue = FolioCupon.Trim.ToUpper

                func.Execute()
                R3.Close()

                Status = func.Imports("E_RESULTADO").ToString
                cuponPadre = func.Imports("E_ORIGINAL").ToString()


                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_ACTUALIZA_RECUPON(ByRef FolioCupon As String, ByVal FolioSAP As String) As String

        Dim Status As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCUP_RECUPON_UTILIZABLE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCUP_RECUPON_UTILIZABLE")

                func.Exports("I_FOLIO_RECUP").ParamValue = FolioCupon.Trim.ToUpper
                func.Exports("I_DOCUMENTO_DEV").ParamValue = FolioSAP.Trim

                func.Execute()

                R3.Close()

                Status = func.Imports("E_RESULTADO").ToString

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_CHECK_PROMOS_VIGENTES(ByRef dtPromos As DataTable) As String

        Dim Status As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function Z_CHK_PROMOS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_CHK_PROMOS")

                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()
                R3.Close()

                Status = func.Imports("NO_DATA").ToString.ToUpper.Trim
                If Status = "A" Then
                    dtPromos = func.Tables("TT_DESCUENTOS").ToADOTable
                End If

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_UPD_PROMOS_VIGENTES(ByVal TipoDesc As Integer) As String

        Dim Status As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function Z_UPD_PROMOS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_UPD_PROMOS")

                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")
                func.Exports("TYPEDESC").ParamValue = CStr(TipoDesc)

                func.Execute()
                R3.Close()

                Status = func.Imports("RETURN").ToString.ToUpper.Trim

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_PRESTAMO_FINANCIERO(ByVal NoDist As String, ByVal Importe As String, _
                                              ByVal Intereses As String, ByVal Plaza As String, _
                                              ByVal NoDPVale As String, ByVal NoDesc As String, _
                                              ByVal NoTarjeta As String, ByVal IFE As String) As DataTable

        Try
            'Set Liccenses.

            Dim Lic As ERPConnectLIC.Lic
            Dim dtValores As New DataTable
            Dim dtMessage As New DataTable
            Dim strMensaje As String, strResult As String
            Dim oRow As DataRow
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                    oParent.SAPApplicationConfig.ApplicationServer, _
                    oParent.SAPApplicationConfig.System, _
                    oParent.SAPApplicationConfig.User, _
                    oParent.SAPApplicationConfig.Password, _
                    oParent.SAPApplicationConfig.Language, _
                    oParent.SAPApplicationConfig.Client)

            'si no se conecta, sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con servidos SAP. Verificar configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPRESTAMO_FINANCIERO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPRESTAMO_FINANCIERO")

                func.Exports("I_CLIENTEDIST").ParamValue = NoDist
                func.Exports("I_IMPORTE").ParamValue = Importe
                func.Exports("I_INTERESES").ParamValue = Intereses
                func.Exports("I_PLAZA").ParamValue = Plaza
                func.Exports("I_NUMVA").ParamValue = NoDPVale
                func.Exports("I_NUMDE").ParamValue = NoDesc
                func.Exports("I_NTARJETA").ParamValue = NoTarjeta
                func.Exports("I_TIENDA").ParamValue = "P" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_NIFE").ParamValue = IFE

                func.Execute()
                R3.Close()

                strResult = func.Imports("E_RESULT").ToString

                dtValores.Columns.Add(New DataColumn("NumFact", GetType(String)))
                dtValores.Columns.Add(New DataColumn("Result", GetType(String)))
                dtValores.Columns.Add(New DataColumn("NumDocContFactura", GetType(String)))
                dtValores.Columns.Add(New DataColumn("NumDocContPrestamo", GetType(String)))
                dtValores.Columns.Add(New DataColumn("Mensaje", GetType(String)))

                oRow = dtValores.NewRow
                oRow("numfact") = func.Imports("E_VBELN").ToString
                oRow("Result") = func.Imports("E_RESULT").ToString
                oRow("NumDocContFactura") = func.Imports("E_BELNR").ToString
                oRow("NumDocContPrestamo") = func.Imports("E_BELNR_P").ToString
                dtMessage = func.Tables("T_RETURN").ToADOTable


                If strResult = "D" Then
                    For Each oRow1 As DataRow In dtMessage.Rows
                        strMensaje = strMensaje & CStr(oRow1("message")).ToString & Microsoft.VisualBasic.vbCrLf
                    Next
                Else
                    If strResult = "C" Then
                        For Each oRow1 As DataRow In dtMessage.Rows
                            strMensaje = strMensaje & CStr(oRow1("message")).ToString & Microsoft.VisualBasic.vbCrLf
                        Next
                    Else
                        strMensaje = String.Empty
                    End If
                End If
                oRow("Mensaje") = strMensaje

                dtValores.Rows.Add(oRow)

                Return dtValores

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    'Friend Function ZBAPI_OBTENER_NDESCUENTOS(ByVal plaza As String, ByVal fecha As Date, ByVal monto As Decimal, ByVal strVale As String, _
    '                                          ByRef FechaCobro As Date, ByRef dtDetalle As DataTable) As Integer

    '    Try
    '        Dim intNumPeriodos As Integer
    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPI_OBTENER_NDESCUENTOS
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_OBTENER_NDESCUENTOS")
    '            Dim strFecha As String = ""

    '            'func.Exports("IPLAZA").ParamValue = plaza
    '            func.Exports("IPLAZA").ParamValue = oParent.SAPApplicationConfig.Plaza
    '            func.Exports("IFECHA").ParamValue = fecha.ToString("dd/MM/yyyy")
    '            func.Exports("IMONTO").ParamValue = monto.ToString
    '            func.Exports("I_VALE").ParamValue = strVale.PadLeft(10, "0")

    '            func.Execute()

    '            intNumPeriodos = CInt(func.Imports("ENPERIODO").ToString())
    '            strFecha = func.Imports("FECCO").ToString
    '            If strFecha.Trim <> "" AndAlso CLng(strFecha.Trim) > 0 Then
    '                strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
    '                FechaCobro = CDate(strFecha)
    '            Else
    '                FechaCobro = Today
    '            End If
    '            dtDetalle = func.Tables("T_RESULTS").ToADOTable()
    '            R3.Close()

    '            Return intNumPeriodos

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    'Friend Function ZBAPI_NOMBRE_CLIENTE(ByVal strNumAsociado As String) As String

    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPI_NOMBRE_CLIENTE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_NOMBRE_CLIENTE")

    '            func.Exports("I_KUNNR").ParamValue = strNumAsociado

    '            func.Execute()

    '            R3.Close()

    '            If func.Imports("E_EXIST").ToString = "S" Then
    '                Return func.Imports("E_NOMBRE").ToString
    '            Else
    '                Return String.Empty
    '            End If

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    Friend Function ZBAPI_VALIDANUMTARJETA(ByVal strNumTarj As String) As Boolean

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_NOMBRE_CLIENTE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_TARJETAS_DPFI")

                func.Exports("I_NUMERO").ParamValue = strNumTarj

                func.Execute()

                R3.Close()

                If func.Imports("E_EXISTE").ToString = "X" Then
                    Return True
                Else
                    Return False
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_VALIDA_FOLIO_PRO(ByVal FolioSap As String, ByVal ClienteId As String, ByRef strFIDOCUMENT As String, ByRef strSALESDOCUMENT As String) As String
        Dim result As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPISD_VALIDA_CANCELACION
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD_VALIDA_CANCELACION")

                func.Exports("REFERENCIA").ParamValue = FolioSap
                func.Exports("CLIENTE").ParamValue = ClienteId

                func.Execute()

                R3.Close()
                result = CStr(func.Imports("RESULT").ParamValue)
                If func.Imports("RESULT").ToString = "S" Then
                    strFIDOCUMENT = func.Imports("E_FIDOCUMENT").ToString
                    strSALESDOCUMENT = func.Imports("E_SDDOCUMENT").ToString
                Else
                    strFIDOCUMENT = String.Empty
                    strSALESDOCUMENT = String.Empty
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return result
    End Function

    Friend Function ZBAPI_REVIVE_VALE_EMPLEADO(ByVal FolioSap As String) As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Dim Status As String = ""
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZREVIVIRVALEDESCTO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZREVIVIRVALEDESCTO")

                func.Exports("FOLIOSD").ParamValue = FolioSap

                func.Execute()
                R3.Close()

                Status = func.Imports("E_RESULT").ToString

                Return Status

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_OBTENER_CLIENTES(ByVal strPalabraFind As String, Tipo As Integer, TipoCliente As Integer, EsDip As Boolean) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_OBTENER_CLIENTES
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_OBTENER_CLIENTES")

                func.Exports("I_NOMBRE1").ParamValue = strPalabraFind
                func.Exports("I_ID").ParamValue = Tipo.ToString
                func.Exports("I_TIPO_CLIENTE").ParamValue = TipoCliente.ToString
                If EsDip Then func.Exports("I_TIPO_CLIENTE_FINAL").ParamValue = "DP"

                func.Execute()

                R3.Close()

                Return func.Tables("TZCOMPRADORES").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZDPPRO_CENTRONUEVO() As Boolean

        'Dim dtResultado As DataTable
        Dim bRes As Boolean

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZDPPRO_CENTRONUEVO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPPRO_CENTRONUEVO")

                'func.Exports("I_CODCLIENTE").ParamValue = strCodAsociado.PadLeft(10, "0")
                'func.Exports("I_VKORG").ParamValue = "CDPT"
                'func.Exports("I_VTWEG").ParamValue = "T1"
                'func.Exports("I_SPART").ParamValue = "VG"

                func.Execute()

                R3.Close()

                'dtResultado = func.Tables("CENTROS").ToADOTable

                If CStr(func.Imports("E_RESULTADO").ParamValue).Trim = "1" Then
                    bRes = True
                Else
                    bRes = False
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return bRes

    End Function

    '------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 06/06/2013:  Se realizo el cambio de la funcion para agregarle que revisara por pedido Si Hay
    '------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZBAPI_VALIDACLIENTEVALECAJA(ByVal FolioFI As String, Optional ByVal PedidoFolioSAP As String = "") As String

        Dim strClienteID As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZDPPRO_CLIENTE_DEV
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPPRO_CLIENTE_DEV")
                If PedidoFolioSAP.Trim() <> "" Then
                    func.Exports("I_PEDIDO").ParamValue = PedidoFolioSAP
                Else
                    func.Exports("I_DEVFI").ParamValue = FolioFI.PadLeft(10, "0")
                End If


                func.Execute()

                R3.Close()

                strClienteID = func.Imports("E_KUNNR").ParamValue

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strClienteID

    End Function

    'Friend Function ZBAPI_TRASLADO_SALDOS(ByVal strClienteOrigen As String, ByVal strClienteDestino As String, ByVal strFolioFIDev As String) As String ', ByVal strFolioFIVenta As String) As String

    '    Dim strResult As String = ""
    '    Dim strFolioFITraspaso As String = ""
    '    Dim dtResult As DataTable

    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZDPPRO_TRASLADASALDO
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPPRO_TRASLADASALDO")

    '            func.Exports("I_KUNNR_O").ParamValue = strClienteOrigen.PadLeft(10, "0")
    '            func.Exports("I_KUNNR_D").ParamValue = strClienteDestino.PadLeft(10, "0")
    '            func.Exports("I_DEVFI").ParamValue = strFolioFIDev.Trim.PadLeft(10, "0")
    '            'func.Exports("I_FACT").ParamValue = strFolioFIVenta.Trim.PadLeft(10, "0")
    '            'func.Exports("I_VTWEG").ParamValue = "T1"
    '            'func.Exports("I_SPART").ParamValue = "VG"

    '            func.Execute()

    '            R3.Close()

    '            strResult = func.Imports("E_RESULT").ParamValue
    '            strFolioFITraspaso = func.Imports("E_DOCMNT").ParamValue
    '            dtResult = func.Tables("T_RETURN").ToADOTable

    '            If strResult.Trim.ToUpper <> "Y" Then
    '                strFolioFITraspaso = ""
    '                Dim oRow As DataRow
    '                Dim strError As String = ""

    '                For Each oRow In dtResult.Rows
    '                    strError = strError & vbCrLf & CStr(oRow!Message)
    '                Next

    '                MsgBox(strError, MsgBoxStyle.Exclamation, "Error")
    '            End If

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    '    Return strFolioFITraspaso

    'End Function

    Friend Function ZBAPI_GET_CLIENTE(ByVal strCodAsociado As String, ByVal TipoVenta As String) As DataTable

        Dim dtResultado As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_SELECTCLIENTEBYID
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_SELECTCLIENTEBYID")

                func.Exports("I_CODCLIENTE").ParamValue = strCodAsociado.PadLeft(10, "0")
                'func.Exports("I_VKORG").ParamValue = ConfigCierreFI.OrganizacionCompra
                'func.Exports("I_VTWEG").ParamValue = ConfigCierreFI.CanalDistribucion
                'func.Exports("I_SPART").ParamValue = ConfigCierreFI.Sector

                '---------------------------------------------------------------
                ' JNAVA (11.02.2016): Adaptación para retail
                '---------------------------------------------------------------
                Dim TipoCliente As String = ""
                Dim TipoBusqueda As String = ""

                Select Case TipoVenta
                    Case "D"
                        TipoCliente = "DP"
                        TipoBusqueda = "1"
                    Case Is <> String.Empty
                        'TipoCliente = ""
                        TipoBusqueda = "2"
                        'Case "I"
                        '    TipoCliente = "FF"
                        '    TipoBusqueda = "2"
                        'Case "V"
                        '    TipoCliente = "VL"
                        '    TipoBusqueda = "2"
                        'Case "A"
                        '    TipoCliente = "AP"
                        '    TipoBusqueda = "2"
                        'Case "K"
                        '    TipoCliente = "FO"
                        '    TipoBusqueda = "2"
                    Case String.Empty
                        TipoBusqueda = "3"
                End Select

                func.Exports("I_TIPO_CLIENTE").ParamValue = TipoBusqueda
                func.Exports("I_TIPO_CLIENTE_FINAL").ParamValue = TipoCliente
                '---------------------------------------------------------------

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("DATOSCLIENTE").ToADOTable

                Return dtResultado

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_GET_CLIENTE_BYRFC(ByVal strRFC As String) As DataTable

        Dim dtResultado As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_SELECTCLIENTEBYRFC    ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_SELECTCLIENTEBYRFC")

                func.Exports("I_RFC").ParamValue = strRFC.Trim

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("DATOSCLIENTE").ToADOTable

                Return dtResultado

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    'Friend Function ZBAPI_GENERAR_REVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByRef strResult As String) As String

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPI_GENERAR_REVALE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_GENERAR_REVALE")

    '            func.Exports("I_MONTO").ParamValue = decMonto
    '            func.Exports("I_VALEOROGEN").ParamValue = strDPvaleID.PadLeft(10, "0")

    '            func.Execute()

    '            R3.Close()

    '            strResult = func.Imports("E_RESULT").ToString

    '            Return func.Imports("E_REVALE").ToString

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    'Friend Function ZBAPI_DATOS_CLIENTE(ByVal strNumAsociado As String, TipoCliente As Integer) As String()

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPI_DATOS_CLIENTE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_DATOS_CLIENTE")

    '            func.Exports("I_KUNNR").ParamValue = strNumAsociado
    '            func.Exports("I_TIPO_CLIENTE").ParamValue = CStr(TipoCliente)

    '            func.Execute()

    '            R3.Close()

    '            Dim info(4) As String

    '            If func.Imports("E_EXIST").ToString = "S" Then
    '                info(0) = func.Imports("E_EXIST").ToString
    '                info(1) = func.Imports("E_NOMBRE").ToString
    '                info(2) = func.Imports("E_DOMICILIO").ToString
    '                info(3) = func.Imports("E_TELEFONO").ToString
    '                Return info
    '            Else
    '                Return info
    '            End If

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    'Friend Function ZBAPI_VALIDA_ReVale_Venta(ByVal cdpvale As cDPVale) As cDPVale

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function ZBAPI_VALIDA_REVALE_VENTA
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_REVALE_VENTA")

    '            func.Exports("INUMVA").ParamValue = cdpvale.INUMVA

    '            func.Execute()

    '            cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable

    '            R3.Close()

    '            Return cdpvale

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

    'Friend Function ZBAPI_GENERAR_REREVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByVal intPares As Integer, ByRef strResult As String) As String

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZBAPI_GENERAR_REREVALE
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_GENERAR_REREVALE")

    '            func.Exports("I_MONTO").ParamValue = decMonto
    '            func.Exports("I_VALEOROGEN").ParamValue = strDPvaleID.PadLeft(10, "0")
    '            func.Exports("I_PARES").ParamValue = intPares.ToString

    '            func.Execute()

    '            R3.Close()

    '            strResult = func.Imports("E_RESULT").ToString

    '            Return func.Imports("E_REVALE").ToString

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try


    'End Function

#End Region

#Region "Funciones Nuevas Auto Facturacion"

    Friend Function ZBAPI_ACTUALIZA_DIPS(ByVal strCliente As String) As String

        Dim strResultado As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_ACTUALIZA_DIPS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_ACTUALIZA_DIPS")

                func.Exports("FOLIOCLIENTE").ParamValue = strCliente

                func.Execute()

                R3.Close()

                Return func.Imports("RETURN").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_SELECT_DIPS(ByVal strCliente As String) As String

        Dim strResultado As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_SELECT_DIPS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_SELECT_DIPS")

                func.Exports("FOLIOCLIENTE").ParamValue = strCliente

                func.Execute()

                R3.Close()

                Return func.Imports("RETURN").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Shared Function RowToString(ByVal SourceRow As DataRow) As String
        Dim SB As New Text.StringBuilder
        If Not SourceRow Is Nothing Then
            Dim SR As DataRow = SourceRow
            Dim ST As DataTable = SR.Table
            Dim SC As DataColumn
            For Each SC In ST.Columns
                Try
                    SB.Append(SC.ColumnName & " = " & SR.Item(SC.ColumnName) & " " & System.Environment.NewLine)
                Catch oEx As Exception
                End Try
            Next
        Else
            SB.Append("SourceRow not available, stacktrace = " & System.Environment.StackTrace)
        End If
        Return SB.ToString.TrimEnd
    End Function
    Friend Function ZBAPIDPT01_REGISTRA_CLIENTE_PG(ByVal pCliente As ClientesSAP, ByVal dtDatos As DataTable, ByVal dtDatos2 As DataTable, ByVal dtDatos3 As DataTable, ByVal codalmacen As String) As String

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIDPT01_REGISTRA_CLIENTE_PG
                '*****************************************************
                ' Create a function object


                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIDPT01_REGISTRA_CLIENTE_PG")
                Dim oCliente As ERPConnect.RFCStructure = func.Exports("I_ZDP_CLIENTES_PG").ToStructure()
                Dim id_cliente As String = codalmacen & dtDatos3.Rows(0).Item("codcaja") & dtDatos3.Rows(0).Item("FOLIOFACTURA")

                'oCliente("IDCLIENTE") = codalmacen & dtDatos3.Rows(0).Item("codcaja") & dtDatos3.Rows(0).Item("FOLIOFACTURA")
                'oCliente("IDCLIENTE") = id_cliente
                oCliente("NOMBRE") = pCliente.Nombre
                oCliente("DOMICILIO") = pCliente.Domicilio
                oCliente("COLONIA") = pCliente.Colonia
                oCliente("TELEFONO") = pCliente.Telefono
                oCliente("CP") = pCliente.Cp
                oCliente("SEXO") = pCliente.Sexo
                oCliente("EMAIL") = pCliente.Email
                oCliente("FNACIMIENTO") = pCliente.Fechanac
                oCliente("PLAZA") = pCliente.Player
                oCliente("CIUDAD") = pCliente.Ciudad
                oCliente("ESTADO") = pCliente.Estado
                oCliente("CLAVEELECTOR") = pCliente.claveelector


                Dim T_Lines As ERPConnect.RFCTable = func.Tables("TZPG_FORMAPAGO")
                For Each oRow As DataRow In dtDatos2.Rows

                    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                    R_Lines("IDCLIENTE") = id_cliente
                    R_Lines("CLAVEELECTOR") = pCliente.claveelector
                    R_Lines("ZFORMAPAGO") = oRow.Item("CODFORMASPAGO")
                    R_Lines("MONTO") = oRow.Item("MONTOPAGO")
                Next

                Dim T_Lines2 As ERPConnect.RFCTable = func.Tables("TZPG_PRODUCTOS")
                For Each oRow As DataRow In dtDatos.Rows
                    Dim R_Lines2 As ERPConnect.RFCStructure = T_Lines2.AddRow()
                    R_Lines2("IDCLIENTE") = id_cliente
                    R_Lines2("CLAVEELECTOR") = pCliente.claveelector
                    R_Lines2("MATNR") = oRow.Item("CODARTICULO")
                    R_Lines2("ZTALLA") = oRow.Item("NUMERO")
                    R_Lines2("PRECIO") = oRow.Item("TOTAL")
                    R_Lines2("ZCANTIDAD") = oRow.Item("CANTIDAD")
                Next

                func.Execute()
                R3.Close()

                Return func.Imports("E_RESULT").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Sub ZBAPI_ABONO_CIERREDIA(ByVal oZBAPI_ABONO_CIERREDIA As ZBapiAbonoCierreDia, ByRef dt As DataTable)

        Dim dtResultado As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_ABONO_CIERREDIA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_ABONO_CIERREDIA")

                func.Exports("TIENDA").ParamValue = oZBAPI_ABONO_CIERREDIA.Tienda
                func.Exports("I_MOT_PED").ParamValue = oZBAPI_ABONO_CIERREDIA.MotivoPedido
                func.Exports("I_MODE").ParamValue = "N"
                func.Exports("FECHA").ParamValue = oZBAPI_ABONO_CIERREDIA.Fecha
                If oZBAPI_ABONO_CIERREDIA.Devolucion Then
                    func.Exports("I_DEVOLUCION").ParamValue = "X"
                Else
                    func.Exports("I_DEVOLUCION").ParamValue = ""
                End If
                '-----------------------------------------------------------------------
                ' JNAVA (15.03.2017): Validamos si es de Si Hay
                '-----------------------------------------------------------------------
                If oZBAPI_ABONO_CIERREDIA.SiHay Then
                    func.Exports("I_SIHAY").ParamValue = "X"
                Else
                    func.Exports("I_SIHAY").ParamValue = String.Empty
                End If
                '-----------------------------------------------------------------------
                Dim T_Documents As ERPConnect.RFCTable = func.Tables("I_T_DOCUMENTS")
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.Documents.Rows
                    Dim R_document As ERPConnect.RFCStructure = T_Documents.AddRow()
                    R_document("BSTNK") = row!BSTNK
                Next
                Dim T_FormasPago As ERPConnect.RFCTable = func.Tables("I_T_PAYMENTS")
                For Each row As DataRow In oZBAPI_ABONO_CIERREDIA.FormasPago.Rows
                    Dim R_FPagos As ERPConnect.RFCStructure = T_FormasPago.AddRow()
                    R_FPagos("TPAGO") = CStr(row("TPAGO"))
                    R_FPagos("CLCOB") = CStr(row("CLCOB"))
                    R_FPagos("BANCO") = CStr(row("BANCO"))
                    R_FPagos("REFBA") = CStr(row("REFBA"))
                    R_FPagos("MONTO") = CStr(row("MONTO"))
                    R_FPagos("RCAJA") = CStr(row("RCAJA"))
                    R_FPagos("COMPE") = CStr(row("COMPE"))
                    R_FPagos("PAGEN") = CStr(row("PAGEN"))
                    R_FPagos("BSTNK") = CStr(row("BSTNK"))
                    R_FPagos("SIHAY") = CStr(row("SIHAY"))
                Next
                func.Execute()

                R3.Close()
                dt = func.Tables("RETURN").ToADOTable
                Dim dtDocument As DataTable = func.Tables("I_T_RETURN_DOCS").ToADOTable()
                Dim doc As String = ""
                For Each row As DataRow In dtDocument.Rows
                    doc = CStr(row("BELNR"))
                Next
                WriteLogCierre(oZBAPI_ABONO_CIERREDIA, dtDocument, dt)
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Sub

    '---------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/03/2016: Guarda los logs del cierre de dia en un archivo
    '---------------------------------------------------------------------------------------------------------------------------

    Private Sub WriteLogCierre(ByVal cierre As ZBapiAbonoCierreDia, ByVal dtDocuments As DataTable, ByVal dtReturn As DataTable)
        Dim file As String = "LogCierre" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & Date.Today.ToString("yyyy-MM-dd") & ".txt"
        Dim writer As New System.IO.StreamWriter(file, True)
        writer.WriteLine("Cabecera")
        writer.WriteLine()
        writer.WriteLine("Tienda: " & cierre.Tienda)
        writer.WriteLine("Motivo Pedido: " & cierre.MotivoPedido)
        writer.WriteLine("Mode: N")
        writer.WriteLine("Fecha: " & cierre.Fecha)
        If cierre.Devolucion Then
            writer.WriteLine("Devolución: X")
        Else
            writer.WriteLine("Devolución: ")
        End If
        writer.WriteLine()
        writer.WriteLine("I_T_DOCUMENTS")
        For Each row As DataRow In cierre.Documents.Rows
            writer.WriteLine("BSTNK: " & CStr(row("BSTNK")))
        Next
        writer.WriteLine()
        writer.WriteLine("Formas de Pago")
        For Each row As DataRow In cierre.FormasPago.Rows
            writer.WriteLine("TPAGO: " & CStr(row("TPAGO")))
            writer.WriteLine("CLCOB: " & CStr(row("CLCOB")))
            writer.WriteLine("BANCO: " & CStr(row("BANCO")))
            writer.WriteLine("REFBA: " & CStr(row("REFBA")))
            writer.WriteLine("MONTO: " & CStr(row("MONTO")))
            writer.WriteLine("RCAJA: " & CStr(row("RCAJA")))
            writer.WriteLine("COMPE: " & CStr(row("COMPE")))
        Next
        writer.WriteLine()
        writer.WriteLine("Documentos Creados")
        For Each row As DataRow In dtDocuments.Rows
            writer.WriteLine("BLART: " & CStr(row("BLART")))
            writer.WriteLine("BELNR: " & CStr(row("BELNR")))
        Next
        writer.WriteLine()
        writer.WriteLine("Mensajes")
        For Each row As DataRow In dtReturn.Rows
            If dtReturn.Columns.Contains("MESSAGE") Then
                If row.IsNull("MESSAGE") = False Then
                    writer.WriteLine(CStr(row("MESSAGE")))
                End If
            End If
        Next
        writer.WriteLine()
        writer.Close()
        UploadFile(file)
    End Sub

    Private Sub UploadFile(ByVal file As String)
        Try
            'Get the object used to communicate with the server.
            Dim request As FtpWebRequest = CType(FtpWebRequest.Create("ftp://" & oParent.ConfigCierreFI.ServidorFTPCierre & "/" & file), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.UploadFile
            'This example assumes the FTP site uses anonymous logon.
            request.Credentials = New NetworkCredential(oParent.ConfigCierreFI.UsuarioFTPCierre, oParent.ConfigCierreFI.PasswordFTPCierre)
            'Copy the contents of the file to the request stream.
            Dim sourceStream As StreamReader = New StreamReader(file)
            Dim fileContents() As Byte = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd())
            sourceStream.Close()
            request.ContentLength = fileContents.Length
            Dim requestStream As Stream = request.GetRequestStream()
            requestStream.Write(fileContents, 0, fileContents.Length)
            requestStream.Close()
            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription)

            response.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        
    End Sub

    'Funcion Vale de Caja
    Friend Function ZBAPI_ABONO_CIERREDIAVC(ByVal strClienteIDVT As String, ByVal strFecha As String, ByVal strFolioFISAP As String, _
    ByVal strClienteIDDV As String, ByVal strFIDOCUMENT As String, ByVal decMonto As Decimal, ByRef dt As DataTable) As String

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZREFERENCIA_VALE_CAJA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZREFERENCIA_VALE_CAJA")

                func.Exports("I_CLIENTE_VT").ParamValue = strClienteIDVT
                func.Exports("I_FECHA").ParamValue = strFecha
                func.Exports("I_DOCFI_VT").ParamValue = strFolioFISAP
                func.Exports("I_CLIENTE_DV").ParamValue = strClienteIDDV
                func.Exports("I_DOCFI_DV").ParamValue = strFIDOCUMENT
                func.Exports("I_MONTO").ParamValue = CStr(decMonto)
                'func.Exports("I_DOCFI_TS").ParamValue = strFolioFITS.Trim.PadLeft(10, "0")


                func.Execute()

                R3.Close()
                dt = func.Tables("T_RETURN").ToADOTable
                Return func.Imports("E_RESULT").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    'Funcion Abonos
    Friend Function ZBAPI_ABONO_CIERREDIAAB(ByVal strClienteID As String, ByVal dtDatos As DataTable, ByRef dt As DataTable) As String

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZCOMPENSAR_APARTADO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCOMPENSAR_APARTADO")

                func.Exports("I_kUNNR").ParamValue = strClienteID


                Dim T_Lines As ERPConnect.RFCTable = func.Tables("TT_DOCTOS")
                For Each oRow As DataRow In dtDatos.Rows
                    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                    R_Lines("DocFI") = oRow.Item("DocFI")
                Next

                func.Execute()

                R3.Close()
                dt = func.Tables("RETURN").ToADOTable
                Return func.Imports("E_RESULT").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function


    Friend Function Z_FM_COMMX001_EXISTENCIAS_UPD(ByVal dtProductos As DataTable) As DataTable
        Dim dt As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZCANCELAR_APARTADO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX001_EXISTENCIAS_UPD")
                Dim Centro As String = oParent.Read_Centros

                func.Exports("PI_CENTRO_IN").ParamValue = Centro
                func.Exports("PI_CARGA_IN").ParamValue = ""
                func.Exports("PI_CODIGO_IN").ParamValue = "X"

                Dim T_MATERIAL As ERPConnect.RFCTable = func.Tables("PT_MATERIAL_IN")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each oRow In dtProductos.Rows
                    R_Lines = T_MATERIAL.AddRow
                    R_Lines("MATNR") = CStr(oRow!Codigo).Trim
                Next

                func.Execute()
                dt = func.Tables("PT_EXISTENCIA_OUT").ToADOTable
                R3.Close()


            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return dt

    End Function


    Friend Function ZCANCELAR_APARTADODEFINITIVO(ByVal ds As DataSet, ByVal ApartadoId As String, ByVal referencia As String, ByVal tienda As String) As String

        Dim dtResultado As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZCANCELAR_APARTADO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCANCELAR_APARTADO")


                Dim decTotal As Double = 0
                Dim strCliente As String
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))

                'Asigno el DocFi de los abonos a la Tabla , sumo el total de los abonos y obtengo el clienteid
                Dim T_Lines As ERPConnect.RFCTable = func.Tables("T_ANTICIPOS")
                For Each oRow As DataRow In ds.Tables(0).Rows
                    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                    R_Lines("BELNR") = oRow.Item("DocFI")
                    decTotal = decTotal + oRow.Item("Abono")
                    strCliente = oRow.Item("ClienteId")
                Next

                'Asigno valores a la Bapi
                'func.Exports("I_KUNNR").ParamValue = strCliente
                func.Exports("I_IMPORTE").ParamValue = CStr(decTotal)
                func.Exports("I_TIPO").ParamValue = "D"
                func.Exports("I_PENALIZACION").ParamValue = "0"
                func.Exports("I_DEVEFECTIVO").ParamValue = "0"
                func.Exports("I_MODO").ParamValue = "N"
                func.Exports("I_TIENDA").ParamValue = tienda
                func.Exports("I_CONTRATO").ParamValue = ApartadoId
                func.Exports("I_REFERENCIA").ParamValue = ""
                func.Exports("I_REF_PED").ParamValue = referencia
                'func.ex()


                func.Execute()

                R3.Close()
                'dt = func.Tables("RETURN").ToADOTable
                Return func.Imports("E_BELNR").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZCANCELAR_APARTADONC(ByVal ds As DataSet, ByVal strDevEfec As String, ByVal strPena As Decimal, _
    ByVal strDivision As String, ByVal strAlmacen As String, ByVal strFolioContrato As Integer, ByVal ReferenciaApartado As String) As String

        Dim dtResultado As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZCANCELAR_APARTADO
                '*****************************************************
                ' Create a function object

                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))
                '------------------------------------------------------

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCANCELAR_APARTADO")


                Dim decTotal As Double = 0
                Dim strCliente As String

                'Asigno el DocFi de los abonos a la Tabla , sumo el total de los abonos y obtengo el clienteid
                Dim T_Lines As ERPConnect.RFCTable = func.Tables("T_ANTICIPOS")
                For Each oRow As DataRow In ds.Tables(0).Rows
                    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                    R_Lines("BELNR") = oRow.Item("DocFI")
                    decTotal = decTotal + oRow.Item("Abono")
                    strCliente = oRow.Item("ClienteId")
                Next

                'Asigno valores a la Bapi
                func.Exports("I_IMPORTE").ParamValue = CStr(decTotal)
                func.Exports("I_TIPO").ParamValue = "V"
                func.Exports("I_PENALIZACION").ParamValue = CStr(strPena)
                func.Exports("I_DEVEFECTIVO").ParamValue = strDevEfec
                func.Exports("I_MODO").ParamValue = "N"
                func.Exports("I_TIENDA").ParamValue = strAlmacen
                func.Exports("I_CONTRATO").ParamValue = CStr(strFolioContrato)
                func.Exports("I_REFERENCIA").ParamValue = strNumRef
                func.Exports("I_REF_PED").ParamValue = ReferenciaApartado


                func.Execute()

                R3.Close()

                'dt = func.Tables("RETURN").ToADOTable
                Return func.Imports("E_BELNR").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZGENERARVALECAJADPVL(ByVal strCliente As String, ByVal strImporte As String, _
    ByVal strDivision As String, ByVal strAlmacen As String, ByVal strFIDOCUMENT As String, ByVal MotivoPedido As String) As String


        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZGENERAR_VALE_CAJA
                '*****************************************************
                ' Create a function object


                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGENERAR_VALE_CAJA")


                'Asigno valores a la Bapi
                func.Exports("I_KUNNR").ParamValue = strCliente
                func.Exports("I_IMPORTE").ParamValue = strImporte
                func.Exports("I_MODO").ParamValue = "N"
                'func.Exports("I_GSBER").ParamValue = strDivision
                'func.Exports("I_TIENDA").ParamValue = strAlmacen
                func.Exports("I_FDEVOLUCION").ParamValue = strFIDOCUMENT
                func.Exports("I_MOT_PED").ParamValue = MotivoPedido
                func.Execute()

                R3.Close()

                'dt = func.Tables("RETURN").ToADOTable
                Return func.Imports("E_BELNR").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function
    '--------------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 10.11.2014: RFC para aplicar los descuentos adicionales de las promociones vigentes en SAP (Cross Selling)
    '--------------------------------------------------------------------------------------------------------------------------------------------
    Friend Sub ZCS_ALGORITMO_PROMOS(ByVal dtMateriales As DataTable, ByVal TipoVenta As String, ByVal Fecha As Date, ByRef htTotales As Hashtable, _
    ByRef dtMatDesc As DataTable, ByRef dtPromos As DataTable, ByRef dtCrossSelling As DataTable)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZCS_ALGORITMO_PROMOS         ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCS_ALGORITMO_PROMOS")

                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim T_TVENTA As ERPConnect.RFCTable = func.Tables("T_TVENTA")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each oRow In dtMateriales.Rows
                    R_Lines = T_MATERIALES.AddRow
                    R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim.PadLeft(18, "0")
                    R_Lines("TALLA") = oRow!Talla
                    R_Lines("CANTIDAD") = oRow!Cantidad
                Next

                R_Lines = T_TVENTA.AddRow
                R_Lines("SIGN") = ""
                R_Lines("OPTION") = ""
                R_Lines("LOW") = TipoVenta
                R_Lines("HIGH") = ""
                'Next

                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim
                func.Exports("I_FECHA").ParamValue = Format(Fecha, "yyyyMMdd")
                func.Exports("I_CANAL").ParamValue = "10"
                func.Exports("I_VIGENTES").ParamValue = "X"
                func.Exports("I_CROSS_SELLING").ParamValue = "X"

                func.Execute()

                R3.Close()

                htTotales = New Hashtable
                htTotales("SubTotSinDesc") = func.Imports("E_SUBTOTAL_SINDESC").ParamValue
                htTotales("TotalPzas") = func.Imports("E_TOTAL_PIEZAS").ParamValue
                htTotales("TotalAhorro") = func.Imports("E_AHORRO").ParamValue
                htTotales("Total") = func.Imports("E_TOTAL_IMP").ParamValue

                dtMatDesc = func.Tables("T_RESULTADO_MAT_AGRUP").ToADOTable
                dtPromos = func.Tables("T_RESULTADO_XPROMO").ToADOTable
                dtCrossSelling = func.Tables("T_CROSS_SELLING").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub
    '--------------------------------------------------------------------------------------------------------------------------------------------
    'RGERMAIN 10.11.2014: RFC para obtener las promos vigentes y sus formas de pagos permitidas (Cross Selling)
    '--------------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZCS_PROMO_VIGENTES(ByVal Fecha As Date, ByRef dtVigencias As DataTable) As DataTable

        Dim dtResult As DataTable

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCS_PROMO_VIGENTES           ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCS_PROMO_VIGENTES")

                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim
                func.Exports("I_FECHA").ParamValue = Format(Fecha, "yyyyMMdd")

                func.Execute()

                R3.Close()

                dtResult = func.Tables("TE_FPAGO").ToADOTable
                If Not dtVigencias Is Nothing Then dtVigencias = New DataTable
                dtVigencias = func.Tables("TE_VIGCAB").ToADOTable
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResult

    End Function

#End Region

#Region "Validacion NC"
    Friend Function WRITE_ZBAPI_VALIDAR_DEVOLUCION(ByVal strKEY As String, ByRef dt As DataTable) As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_ACTUALIZA_DIPS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDAR_DEVOLUCION")

                func.Exports("I_KEYPRO").ParamValue = strKEY

                func.Execute()

                R3.Close()

                dt = func.Tables("T_ZDATOSDET").ToADOTable

                Return func.Imports("E_KUNNR").ToString & "/" _
                & func.Imports("E_FACTURA_O").ToString & "/" _
                & func.Imports("E_DOCFI").ToString & "/" _
                & func.Imports("E_DOCSD").ToString & "/" _
                & func.Imports("E_RESULT").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function
#End Region

#Region "Surtido Ecommerce"

    Friend Sub ZPOL_ACTTRASL(ByVal PedidoEC As String, ByVal FolioTS As String, ByVal Status As String, ByVal FacturaEC As String, ByVal Responsable As String, _
                             ByVal dtConfirmados As DataTable, ByVal ID_Solicitud As String)

        Try
            Dim strRes As String = ""
            Dim strMsg As String = ""

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZPOL_ACTTRASL                  ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_ACTTRASL")
                Dim Centro As String = oParent.Read_Centros

                func.Exports("I_PEDIDO").ParamValue = PedidoEC.Trim.PadLeft(10, "0")
                func.Exports("I_CESUM").ParamValue = Centro.Trim
                func.Exports("I_TRASLADO").ParamValue = "" 'FolioTS.Trim.PadLeft(10, "0")

                '-------------------------------------------------------------------------------------
                ' JNAVA (01.04.2016): Adecuaciones por Retail
                '-------------------------------------------------------------------------------------
                Dim strStatus As String = String.Empty
                If Status.Trim = "S" Then
                    strStatus = "F"
                ElseIf Status.Trim = "PS" Then
                    strStatus = "PF"
                Else
                    strStatus = Status.Trim
                End If

                func.Exports("I_STATUS").ParamValue = strStatus 'Status.Trim
                '-------------------------------------------------------------------------------------

                '-------------------------------------------------------------------------------------
                ' JNAVA (30.06.2016): Adecuaciones por Retail
                '-------------------------------------------------------------------------------------
                func.Exports("I_ID_SOLICITUD").ParamValue = ID_Solicitud.Trim
                '-------------------------------------------------------------------------------------

                func.Exports("I_FACTURA").ParamValue = FacturaEC.Trim
                func.Exports("I_FECHA_MODIF").ParamValue = Format(Today, "yyyyMMdd")
                func.Exports("I_RESPONSABLE").ParamValue = Responsable.Trim

                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                If Not dtConfirmados Is Nothing Then
                    For Each oRow In dtConfirmados.Rows
                        R_Lines = T_MATERIALES.AddRow
                        R_Lines("FOLIO_PEDIDO") = CStr(oRow!PedidoEC).Trim
                        R_Lines("ID_SOLICITUD") = ID_Solicitud.Trim
                        R_Lines("CENTRO") = Centro.Trim
                        R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim
                        R_Lines("ALMACEN") = "M001"
                        If IsNumeric(CStr(oRow!Talla)) Then
                            R_Lines("TALLA") = Format(CDec(oRow!Talla), "#.0")
                        Else
                            R_Lines("TALLA") = CStr(oRow!Talla).Trim
                        End If
                        'R_Lines("TALLA") = CStr(oRow!Talla).Trim
                        R_Lines("CANTIDAD") = oRow!Confirmados
                    Next
                End If

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MESSAGE").ToString

                If strRes.Trim <> "Y" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al actualizar el status del pedido en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        'Return dtMotivos

    End Sub

    Friend Sub ZPOL_TRASL_NEGAR(ByVal dtNegados As DataTable, ByVal FolioSAP As String, ByVal TipoMov As String, ByVal Responsable As String)

        Try
            Dim strRes As String = ""
            Dim strMsg As String = ""

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZPOL_TRASL_NEGAR                ***
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_TRASL_NEGAR")

                Dim T_NEGADOS As ERPConnect.RFCTable = func.Tables("T_NEGADOS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow
                Dim Centro As String = oParent.Read_Centros
                '     Dim i As Integer = 0

                For Each oRow In dtNegados.Rows
                    R_Lines = T_NEGADOS.AddRow
                    '-------------------------------------------------------------------------
                    ' JNAVA (21.06.2016): Agregamos ID de Solicitud y Almacen
                    '-------------------------------------------------------------------------
                    '  R_Lines("ID_SOLICITUD") = CStr(oRow!ID_Solicitud).Trim
                    '    i += 1
                    R_Lines("ID_SOLICITUD") = CStr(oRow!ID_SOLICITUD).Trim
                    R_Lines("ALMACEN") = "M001"
                    '-------------------------------------------------------------------------
                    R_Lines("FOLIO_PEDIDO") = CStr(oRow!PedidoEC).Trim
                    R_Lines("CENTRO") = Centro.Trim
                    R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim
                    If IsNumeric(CStr(oRow!Talla)) Then
                        R_Lines("TALLA") = Format(CDec(oRow!Talla), "#.0")
                    Else
                        R_Lines("TALLA") = CStr(oRow!Talla).Trim
                    End If
                    'R_Lines("TALLA") = CStr(oRow!Talla).Trim
                    R_Lines("CANTIDAD") = oRow!Negados
                    R_Lines("MOTIVO") = CStr(oRow!Motivo).Trim
                    R_Lines("MOTIVO_DESC") = CStr(oRow!MotivoDesc).Trim
                    R_Lines("FOLIO_SAP") = FolioSAP.Trim.PadLeft(10, "0")
                    R_Lines("TIPO_MOVTO") = TipoMov.Trim
                    R_Lines("RESPONSABLE") = Responsable.Trim
                    R_Lines("FECHA") = Format(Today, "yyyyMMdd")
                    R_Lines("HORA") = Format(Now, "HHmmss")
                Next

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MESSAGE").ToString

                If strRes.Trim <> "Y" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al insertar codigos negados del pedido en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        'Return dtMotivos

    End Sub

    Friend Function ZPOL_DEFECTUOSOS_INS(ByVal dtDefectuososEC As DataTable, ByVal FolioSAP As String, ByVal TipoMov As String, ByVal Responsable As String) As String

        Dim strRes As String = ""
        Try
            Dim strMsg As String = ""

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_DEFECTUOSOS_INS            ***
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_DEFECTUOSOS_INS")

                Dim T_DEFECTUOSOS As ERPConnect.RFCTable = func.Tables("TPRODUCTO")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow
                Dim Centro As String = oParent.Read_Centros

                For Each oRow In dtDefectuososEC.Rows
                    R_Lines = T_DEFECTUOSOS.AddRow
                    R_Lines("MATERIAL") = CStr(oRow!Material).Trim
                    'If IsNumeric(CStr(oRow!Talla)) Then
                    '    R_Lines("TALLA") = Format(CDec(oRow!Talla), "#.0")
                    'Else
                    '    R_Lines("TALLA") = CStr(oRow!Talla).Trim
                    'End If
                    'R_Lines("TALLA") = CStr(oRow!Talla).Trim
                    R_Lines("FECHA") = Format(Today, "yyyyMMdd")
                    R_Lines("HORA") = Format(Now, "HHmmss")
                    R_Lines("CANTIDAD") = oRow!Cantidad
                    R_Lines("MOTIVO") = CStr(oRow!Motivo).Trim
                    If FolioSAP.Trim <> "" Then R_Lines("MOTIVO") &= " " & FolioSAP.Trim
                    R_Lines("CENTRO") = Centro.Trim
                    R_Lines("RESPONSABLE") = Responsable.Trim
                    R_Lines("TIPO") = TipoMov.Trim
                    R_Lines("ID_DESMARQ") = oRow!DesmarcadoID
                    R_Lines("ID") = oRow!MarcadoID
                Next

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MESSAGE").ToString

                If strRes.Trim.ToUpper <> "Y" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al insertar codigos negados del pedido en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZPOL_TRASLADO_A_FACTURA(ByVal PedidoEC As String, ByVal dtTraspasos As DataTable) As String

        Dim FolioSD As String = ""
        Dim FolioFI As String = ""

        Try
            Dim strRes As String = ""
            Dim strMsg As String = ""

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_TRASLADO_A_FACTURA        ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_TRASLADO_A_FACTURA")

                func.Exports("I_PEDIDO").ParamValue = PedidoEC.Trim.PadLeft(10, "0")

                Dim T_TRASPASOS As ERPConnect.RFCTable = func.Tables("TRASLADOS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each oRow In dtTraspasos.Rows
                    R_Lines = T_TRASPASOS.AddRow
                    R_Lines("EBELN") = CStr(oRow!FolioTraspaso).Trim.PadLeft(10, "0")
                Next

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString

                Dim dtMessage As DataTable
                dtMessage = func.Tables("IT_RETURN").ToADOTable

                FolioFI = func.Imports("E_FIDOCUMENT").ToString
                FolioSD = func.Imports("E_SDDOCUMENT").ToString

                If strRes.Trim.ToUpper <> "OK" OrElse FolioFI.Trim = "" OrElse FolioSD.Trim = "" Then
                    FolioSD = ""
                    For Each oRow In dtMessage.Rows
                        strMsg &= oRow!Message & vbCrLf
                    Next
                    MsgBox("FolioSD: " & FolioSD.Trim & " FolioFI: " & FolioFI.Trim & vbCrLf & vbCrLf & strMsg, MsgBoxStyle.Exclamation, "Error al realizar factura en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return FolioSD

    End Function

    Friend Function ZPOL_CHK_CONCENTRA(ByVal FolioPedido As String) As DataTable

        Dim dtConcen As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_CHK_CONCENTRA             ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_CHK_CONCENTRA")

                func.Exports("PPEDIDO").ParamValue = FolioPedido.Trim.PadLeft(10, "0")

                func.Execute()

                R3.Close()

                dtConcen = func.Tables("TTRASLADOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtConcen

    End Function

    Friend Function ZPAQUETERIAS_RETR() As DataTable

        Dim dtPaq As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPAQUETERIAS_RETR               ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPAQUETERIAS_RETR")

                func.Execute()

                R3.Close()

                dtPaq = func.Tables("PAQUETERIAS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtPaq

    End Function

    Friend Function ZPOL_DATOS_ENVIO(ByVal Pedido As String, ByRef dtDatosG As DataTable) As DataTable

        Dim dtDatosEnvio As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_DATOS_ENVIO               ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_DATOS_ENVIO")

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim.PadLeft(10, "0")
                func.Exports("I_CESUM").ParamValue = oParent.Read_Centros().Trim

                func.Execute()

                R3.Close()

                dtDatosG = New DataTable("DatosGenerales")
                With dtDatosG
                    .Columns.Add("Tipo", GetType(String))
                    .Columns.Add("Local", GetType(String))
                    .Columns.Add("FacturaSAP", GetType(String))
                    .Columns.Add("TrasladoSAP", GetType(String))
                    .AcceptChanges()
                End With

                Dim oRow As DataRow = dtDatosG.NewRow

                With oRow
                    !Tipo = func.Imports("E_TIPO").ToString
                    !Local = func.Imports("E_LOCAL").ToString
                    !FacturaSAP = func.Imports("E_FACTURA").ToString
                    !TrasladoSAP = func.Imports("E_TRASLADO").ToString
                End With
                dtDatosG.Rows.Add(oRow)

                Dim sTemp As ERPConnect.RFCStructure = func.Imports("DIRECCION").ToStructure

                dtDatosEnvio = New DataTable("DatosEnvio")
                With dtDatosEnvio
                    .Columns.Add("Nombre", GetType(String))
                    .Columns.Add("Domicilio", GetType(String))
                    .Columns.Add("Ciudad", GetType(String))
                    .Columns.Add("Estado", GetType(String))
                    .Columns.Add("RFC", GetType(String))
                    .Columns.Add("Telefono", GetType(String))
                    .Columns.Add("CP", GetType(String))
                    .AcceptChanges()
                End With

                oRow = dtDatosEnvio.NewRow

                With oRow
                    !Nombre = sTemp("NAME1") & " " & sTemp("NAME2") & " " & sTemp("NAME3")
                    !Domicilio = sTemp("STREET") & sTemp("HOUSE_NUM1") & sTemp("CITY2")
                    !Ciudad = sTemp("CITY1")
                    !Estado = sTemp("REGION")
                    !RFC = sTemp("NAME4")
                    !CP = sTemp("POST_CODE1")
                    !Telefono = ""
                End With
                dtDatosEnvio.Rows.Add(oRow)

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtDatosEnvio

    End Function

    Friend Function ZGUIAS_RANGOS_RETR(ByVal Paqueteria As String) As DataTable

        Dim dtRangos As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGUIAS_RANGOS_RETR             ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGUIAS_RANGOS_RETR")

                func.Exports("I_CENTRO").ParamValue = oParent.Read_Centros.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.Trim

                func.Execute()

                R3.Close()

                dtRangos = func.Tables("TRANGOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtRangos

    End Function

    Friend Function ZPOL_GET_MOTIVOS(ByVal Modulo As String) As DataTable

        Dim dtMotivos As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_GET_MOTIVOS               ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_GET_MOTIVOS")

                func.Exports("PMODULO").ParamValue = Modulo.Trim

                func.Execute()
                R3.Close()

                dtMotivos = func.Tables("TMOTIVOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtMotivos

    End Function

    Friend Function ZPOL_GET_DEFT_CENTRO(ByVal Centro As String, Optional ByVal historico As String = "") As DataTable

        Dim dtDefecEC As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_GET_DEFT_CENTRO           ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_GET_DEFT_CENTRO")

                If Centro.Trim = "" Then Centro = oParent.Read_Centros

                func.Exports("WERKS").ParamValue = Centro.Trim
                func.Exports("I_HISTORICO").ParamValue = historico

                func.Execute()
                R3.Close()

                dtDefecEC = func.Tables("TPRODUCTO").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtDefecEC

    End Function

    Friend Function ZGUIAS_INSERTAR_RANGO(ByVal Paqueteria As String, ByVal FolioIni As String, ByVal FolioFin As String) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGUIAS_INSERTAR_RANGO          ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGUIAS_INSERTAR_RANGO")

                func.Exports("I_CENTRO").ParamValue = oParent.Read_Centros.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.Trim
                func.Exports("I_INICIAL").ParamValue = FolioIni
                func.Exports("I_FINAL").ParamValue = FolioFin

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""
                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error Rango Guias")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZRFC_INSERTA_DATOS_SMS(ByVal LADA As String, ByVal NumCel As String, ByVal FormaPago As String, ByVal CodCliente As String) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_INSERTA_DATOS_SMS         ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_INSERTA_DATOS_SMS")

                func.Exports("I_NUMCEL").ParamValue = NumCel.Trim
                func.Exports("I_ZONAVENTA").ParamValue = FormaPago.ToUpper.Trim
                func.Exports("I_KUNNR").ParamValue = CodCliente.Trim.PadLeft(10, "0")
                func.Exports("I_LADA").ParamValue = LADA.Trim

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""
                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "Y" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error Guardar Celular")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZRFC_INSERTA_DATOS_PROMO(ByVal LADA As String, ByVal NumCel As String, ByVal FormaPago As String, ByVal CodCliente As String, _
                                           ByVal Email As String, ByVal FolioSAP As String, ByVal KeyDPPRO As String) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_INSERTA_DATOS_PROMO       ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_INSERTA_DATOS_PROMO")

                func.Exports("I_NUMCEL").ParamValue = NumCel.Trim
                func.Exports("I_ZONAVENTA").ParamValue = FormaPago.ToUpper.Trim
                func.Exports("I_KUNNR").ParamValue = CodCliente.Trim.PadLeft(10, "0")
                func.Exports("I_LADA").ParamValue = LADA.Trim
                func.Exports("I_Email").ParamValue = Email.Trim
                func.Exports("I_Factura").ParamValue = FolioSAP.Trim
                func.Exports("I_Keydppro").ParamValue = KeyDPPRO

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""
                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "Y" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error Guardar Celular")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZGET_CONCENTRACIONES(ByVal OficinaVta As String, ByVal Almacen As String) As DataTable

        Dim dtRes As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGET_CONCENTRACIONES           ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGET_CONCENTRACIONES")

                func.Exports("I_VKBUR").ParamValue = OficinaVta.Trim

                '--------------------------------------------------
                ' CVALLADOLID 23/11/2016: Validación del folio de concentración
                '--------------------------------------------------
                func.Exports("I_ALMACEN").ParamValue = Almacen.Trim

                func.Execute()

                R3.Close()

                dtRes = func.Tables("T_CONCENT").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtRes

    End Function

    Friend Function ZSET_CONCENT_STATUS(ByVal Folio As String, ByVal Status As String) As String

        Dim strRes As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSET_CONCENT_STATUS            ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSET_CONCENT_STATUS")

                func.Exports("I_STATUS").ParamValue = Status.Trim.ToUpper
                func.Exports("I_FOLIO").ParamValue = Folio.Trim
                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString
                Select Case strRes
                    Case "N"
                        MsgBox("Ocurrió un error al actualizar el status de la concentración en SAP.", MsgBoxStyle.Exclamation, "Error en SAP")
                    Case "Y"
                        MsgBox("El folio ha sido desactivado", MsgBoxStyle.Information, "DPPRO")
                    Case "A"
                        MsgBox("El folio sigue Activo para nuevas solicitudes", MsgBoxStyle.Information, "DPPRO")
                    Case Else
                        MsgBox("Ocurrió un error al actualizar", MsgBoxStyle.Exclamation, "DPPRO")
                End Select
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZRFC_CENTROS_CDIS(ByVal Canal As String) As DataTable

        Dim dtRes As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_CENTROS_CDIS              ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_CENTROS_CDIS")

                func.Exports("I_VTWEG").ParamValue = oParent.ConfigCierreFI.CanalDistribucion
                func.Exports("I_VKORG").ParamValue = oParent.ConfigCierreFI.OrganizacionCompra

                func.Execute()

                R3.Close()

                dtRes = func.Tables("T_CENTROS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtRes

    End Function

    Friend Function ZRFC_DESCDIPS(ByVal ClienteID As String) As Decimal

        Dim Descuento As Decimal = 0

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_DESCDIPS                  ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_DESCDIPS")
                Dim Fecha As String = ""

                func.Exports("I_KUNNR").ParamValue = ClienteID.Trim.PadLeft(10, "0")
                '-------------------------------------------------------------------------------------------------------------------------
                'Calculamos la fecha inicial, restando un mes a la fecha actual, para sacar de ahi el primer dia del mes anterior
                '-------------------------------------------------------------------------------------------------------------------------
                Fecha = Format(CDate("01/" & Format(Today.AddMonths(-1), "MM/yyyy")), "dd.MM.yyyy")
                func.Exports("I_FECHAI").ParamValue = Fecha
                '-------------------------------------------------------------------------------------------------------------------------
                'Calculamos el ultimo dia del mes anterior restandole un dia al primer dia del mes actual
                '-------------------------------------------------------------------------------------------------------------------------
                Fecha = Format(CDate("01/" & Format(Today, "MM/yyyy")).AddDays(-1), "dd.MM.yyyy")
                func.Exports("I_FECHAF").ParamValue = Fecha

                func.Execute()

                R3.Close()

                Descuento = CDec(func.Imports("E_DESC").ToString)

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return Descuento

    End Function

    Friend Function ZRFC_INSERTA_TIEMPOS(ByVal FolioSAP As String, ByVal TipoDoc As String, ByVal TiempoOperacion As String, _
                                         ByVal TiempoSistema As String) As String

        Dim strRes As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFC_INSERTA_TIEMPO            ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFC_INSERTA_TIEMPOS")
                Dim strMsg As String = ""

                func.Exports("I_FOLIOSAP").ParamValue = FolioSAP.Trim.PadLeft(10, "0")
                func.Exports("I_TIPODOC").ParamValue = TipoDoc.Trim
                func.Exports("I_TIEMPO_OPER").ParamValue = TiempoOperacion.Trim
                func.Exports("I_TIEMPO_SAP").ParamValue = TiempoSistema.Trim

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MESSAGE").ToString

                If strRes.Trim <> "Y" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error al guardar tiempos en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZGUIAS_VALIDAR(ByVal Paqueteria As String, ByVal Guia As String) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGUIAS_VALIDAR                 ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGUIAS_VALIDAR")

                func.Exports("I_CENTRO").ParamValue = oParent.Read_Centros.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.Trim
                func.Exports("I_GUIA").ParamValue = Guia.Trim

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Guia No Valida")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZGUIAS_UTILIZAR(ByVal Paqueteria As String, ByVal Guia As String, ByVal Cancelada As Boolean) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZGUIAS_UTILIZAR                ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZGUIAS_UTILIZAR")

                func.Exports("I_CENTRO").ParamValue = oParent.Read_Centros.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.Trim
                func.Exports("I_GUIA").ParamValue = Guia.Trim
                func.Exports("I_CANCELADA").ParamValue = IIf(Cancelada, "X", "")

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox("Ocurrio un error al modificar status de la guia.", MsgBoxStyle.Exclamation, "Actualizar Guia")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZPOL_GRABAR_ENVIO(ByVal Pedido As String, ByVal Paqueteria As String, ByVal Guia As String, ByVal bEnviar As Boolean, ByVal Entrega As String, ByVal SolicitudID As String) As String

        Dim strRes As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_GRABAR_ENVIO              ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_GRABAR_ENVIO")

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim.PadLeft(10, "0")
                func.Exports("I_CESUM").ParamValue = oParent.Read_Centros.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.Trim
                func.Exports("I_GUIA").ParamValue = Guia.Trim
                func.Exports("I_PRUEBA").ParamValue = "" 'IIf(bEnviar, "", "2")

                '------------------------------------------------------------------------
                ' JNAVA (28.06.2016): Enviamos la Entrega y el ID de la Solicitud
                '------------------------------------------------------------------------
                func.Exports("I_ENTREGA").ParamValue = Entrega
                func.Exports("I_SOLICITUD_ID").ParamValue = SolicitudID

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Grabar Guia Utilizada")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZMM_VALIDA_TRASLADO_AL_100(ByVal Traslado As String) As DataTable

        Dim strRes As String
        Dim dtDif As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMM_VALIDA_TRASLADO_AL_100     ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_VALIDA_TRASLADO_AL_100")

                func.Exports("I_TRASLADO").ParamValue = Traslado.Trim.PadLeft(10, "0")
                func.Exports("I_641").ParamValue = "X"
                func.Exports("I_101").ParamValue = ""

                func.Execute()

                R3.Close()

                'Dim strMsg As String = ""

                strRes = func.Imports("E_RESULT").ToString
                dtDif = func.Tables("T_DIFERENCIAS").ToADOTable
                'strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox("Ocurrio un error al realizar el movimiento 351", MsgBoxStyle.Exclamation, "Error en traspaso en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtDif

    End Function

    Friend Function ZMM_BORRAR_TRASLADO_Y_352(ByVal Traslado As String, ByVal b352 As Boolean) As String

        Dim strRes As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMM_BORRAR_TRASLADO_Y_352      ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZFM_COMMX001_DPRO")
                'Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_BORRAR_TRASLADO_Y_352")

                func.Exports("I_TRASLADO").ParamValue = Traslado.Trim.PadLeft(10, "0")
                func.Exports("I_352").ParamValue = IIf(b352, "X", "")

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""

                strRes = func.Imports("E_RESULT").ToString
                strMsg = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al borrar el traspaso en SAP")
                    strRes = ""
                Else
                    strRes = func.Imports("E_MATERIALDOCUMENT").ToString
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZPOL_USI_CANCELA_PEDIDO_352(ByVal Pedido As String, ByVal CentroSAP As String, ByVal Folio352 As String, ByVal User As String) As String

        Dim strRes As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_USI_CANCELA_PEDIDO_352      ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_USI_CANCELA_PEDIDO_352")

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim.PadLeft(10, "0")
                func.Exports("I_CENTRO").ParamValue = CentroSAP.Trim
                func.Exports("I_DOCUMENTO").ParamValue = Folio352.Trim.PadLeft(10, "0")
                func.Exports("I_RESPONSABLE").ParamValue = User.Trim

                func.Execute()

                R3.Close()

                Dim strMsg As String = ""

                strRes = func.Imports("E_RESULT").ToString
                'strMsg = func.Imports("E_MENSAJE").ToString
                strMsg = "Ocurrió un error al intentar actualizar los datos en la tabla zpol_ped_canc"

                If strRes.Trim.ToUpper <> "S" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al cancelar traspaso en SAP")
                Else
                    'strRes = func.Imports("E_MATERIALDOCUMENT").ToString
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strRes

    End Function

    Friend Function ZSD_DATOS_FACTURA_GRAL(ByVal FacturaSAP As String, ByRef dtCliente As DataTable, ByRef decImporte As Decimal, ByRef dtFactura As DataTable, _
                                           ByRef CodVendedor As String, ByRef FolioCupon As String) As DataTable

        Dim dtDetalle As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSD_DATOS_FACTURA_GRAL         ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSD_DATOS_FACTURA_GRAL")

                func.Exports("I_FACTURA").ParamValue = FacturaSAP.Trim.PadLeft(10, "0")
                func.Exports("I_VALIDAR").ParamValue = "X"

                func.Execute()

                R3.Close()

                CodVendedor = "ONL" 'func.Imports("E_GPO_VEND").ToString
                FolioCupon = "" 'func.Imports("E_CUPON").ToString
                dtCliente = func.Tables("CLIENTE").ToADOTable
                'dtImportes = func.Tables("IMPORTES_GRALES").ToADOTable
                decImporte = func.Imports("E_DESCUENTO").ToString
                dtDetalle = func.Tables("DETALLE").ToADOTable

                'Dim sTemp As ERPConnect.RFCStructure
                Dim oNewRow As DataRow
                Dim Fecha As String = ""

                ''----------------------------------------------------------------------------------
                ' JNAVA (22.03.2016): Modificado por adecuaciones de migracion a Retail
                '-----------------------------------------------------------------------------------
                'sTemp = func.Imports("DATOS_FACT").ToStructure

                dtFactura = New DataTable("DatosFactura")
                dtFactura.Columns.Add("Fecha", GetType(DateTime))
                dtFactura.Columns.Add("Total", GetType(Decimal))
                dtFactura.Columns.Add("IVA", GetType(Decimal))
                dtFactura.AcceptChanges()

                Fecha = func.Imports("E_ERDAT").ToString 'sTemp("ERDAT")
                If Fecha.Trim = String.Empty OrElse Fecha.Trim("0") = String.Empty Then
                    Fecha = Format(Today, "yyyyMMdd")
                End If

                Fecha = Fecha.Substring(6, 2) & "/" & Fecha.Substring(4, 2) & "/" & Fecha.Substring(0, 4)

                oNewRow = dtFactura.NewRow
                With oNewRow
                    !Fecha = CDate(Fecha.Trim)
                    !Total = func.Imports("E_NETWR").ToString 'sTemp("NETWR")
                    !IVA = func.Imports("E_MWSBK").ToString 'sTemp("MWSBK")
                End With
                dtFactura.Rows.Add(oNewRow)
                '-----------------------------------------------------------------------------------

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtDetalle

    End Function

    Public Function ZPOL_VERSION_D_FACTURA(ByVal FacturaEC As String) As String
        Dim version As String = ""
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_VERSION_D_FACTURA")

                func.Exports("I_FACTURA").ParamValue = FacturaEC.Trim().PadLeft(10, "0")

                func.Execute()
                R3.Close()
                version = CStr(func.Imports("E_VERSION").ParamValue).TrimEnd
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return version
    End Function

    Friend Function ZPOL_TRASLPEN(ByVal Centro As String, ByRef dtDetalle As DataTable, ByRef dtTrasladosModif As DataTable) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZPOL_TRASLPEN
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_TRASLPEN")

                func.Exports("I_CENTRO").ParamValue = Centro.Trim

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("TZPOL_TRASL_CAB").ToADOTable
                dtDetalle = func.Tables("TZPOL_TRASL_DET").ToADOTable
                dtTrasladosModif = func.Tables("TZPOL_TRASL_EXTRA").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function

    Friend Function ZPOL_VALIDA_TRAS_ENV(ByVal Centro As String) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZPOL_VALIDA_TRAS_ENV
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_VALIDA_TRAS_ENV")

                If Centro.Trim = "" Then Centro = oParent.Read_Centros

                func.Exports("WERKS").ParamValue = Centro.Trim

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("TTRASLADOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function

    Friend Function ZPOL_TBUSCAR_GUIA(ByVal Pedido As String, ByVal Guia As String) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZPOL_TBUSCAR_GUIA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_TBUSCAR_GUIA")

                If Pedido.Trim <> "" Then
                    func.Exports("I_Pedido").ParamValue = Pedido.Trim
                ElseIf Guia.Trim <> "" Then
                    func.Exports("I_Guia").ParamValue = Guia.Trim
                End If

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("T_RESULT").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function

    'Friend Function ZPOL_PEDIDOSCANCELADOS(ByRef dtDetalle As DataTable, ByVal Centro As String) As DataTable

    '    Dim dtResultado As DataTable
    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServer, _
    '                 oParent.SAPApplicationConfig.System, _
    '                 oParent.SAPApplicationConfig.User, _
    '                 oParent.SAPApplicationConfig.Password, _
    '                 oParent.SAPApplicationConfig.Language, _
    '                 oParent.SAPApplicationConfig.Client)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            '*****************************************************
    '            'Call RFC function  ZPOL_PEDIDOSCANCELADOS
    '            '*****************************************************
    '            ' Create a function object

    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_PEDIDOSCANCELADOS")

    '            If Centro.Trim = "" Then Centro = oParent.Read_Centros

    '            func.Exports("I_CENTRO").ParamValue = Centro.Trim

    '            func.Execute()

    '            R3.Close()

    '            dtResultado = func.Tables("TZPOL_TRASL_CAB").ToADOTable
    '            dtDetalle = func.Tables("TZPOL_TRASL_DET").ToADOTable

    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    '    Return dtResultado

    'End Function

    Friend Function ZBAPIMM14_DESBLOQUEOART(ByVal strContrato As String, ByVal dtMateriales As DataTable) As String

        Dim FolioMM As String = ""
        Dim dtMessage As DataTable
        Dim strMensaje As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIMM14_DESBLOQUEOART         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPIMM14_DESBLOQUEOART")

                Dim strCentro As String = oParent.Read_Centros

                func.Exports("CENTRO").ParamValue = strCentro
                func.Exports("ALMACEN").ParamValue = "A001"
                func.Exports("CONTRATO").ParamValue = strContrato
                func.Exports("I_FECHA").ParamValue = CStr(Format(Today, "dd/MM/yyyy"))

                Dim T_APARTADO As ERPConnect.RFCTable = func.Tables("ZTABLA_APARTADO")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each oRow In dtMateriales.Rows
                    R_Lines = T_APARTADO.AddRow
                    R_Lines("CENTRO") = strCentro.Trim
                    R_Lines("CONTRATO") = strContrato.Trim
                    R_Lines("MATNR") = CStr(oRow!Codigo).Trim
                    R_Lines("CANTIDAD") = CStr(oRow!Confirmados).Trim
                    If IsNumeric(oRow!Talla) Then
                        R_Lines("TALLA") = Format(CDec(oRow!Talla), "##.0")
                    Else
                        R_Lines("TALLA") = CStr(oRow!Talla).Trim
                    End If
                Next

                func.Execute()

                R3.Close()

                FolioMM = func.Imports("DOCFI").ToString

                dtMessage = func.Tables("RETURN").ToADOTable

                If FolioMM.Trim = "" Then
                    For Each oRow In dtMessage.Rows
                        strMensaje &= CStr(oRow("message")).Trim & vbCrLf
                    Next
                    MsgBox(strMensaje, MsgBoxStyle.Exclamation, "Error al desbloquear materiales en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return FolioMM

    End Function

    '-----------------------------------------------------------------------------------------------------------------------
    ' JNAVA (12.03.2016): RFC nueva para surtir entrega de ecommerce
    '-----------------------------------------------------------------------------------------------------------------------
    Public Function ZPOL_SURTIDO_ENTREGA(ByVal Pedido As String, ByVal Guia As String, ByVal Paqueteria As String, ByVal dtMateriales As DataTable, ByRef MensajeError As String) As Hashtable
        Dim htRespuesta As Hashtable
        Dim dtRETURN As DataTable
        Dim Centro As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZPOL_SURTIDO_ENTREGA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_SURTIDO_ENTREGA")

                Centro = oParent.Read_Centros

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim
                func.Exports("I_CENTRO").ParamValue = Centro.Trim
                func.Exports("I_ALMACEN").ParamValue = "M001"
                func.Exports("I_GUIA").ParamValue = Guia.Trim
                func.Exports("I_PAQUETERIA").ParamValue = Paqueteria.TrimEnd

                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim i As Integer = 10
                For Each oRow As DataRow In dtMateriales.Rows
                    R_Lines = T_MATERIALES.AddRow
                    R_Lines("EBELP") = CStr(i).PadLeft(5, "0") 'CStr(oRow!EBELP)
                    R_Lines("MATNR") = CStr(oRow!Codigo)
                    R_Lines("PIKMG") = CInt(oRow!Confirmados)
                    R_Lines("LGORT") = "M001"
                    i += 10
                Next

                func.Execute()

                R3.Close()

                ' obtenemos datos
                htRespuesta = New Hashtable
                htRespuesta.Add("E_ENTREGA", func.Imports("E_ENTREGA").ParamValue)
                htRespuesta.Add("E_TRANSPORTE", func.Imports("E_TRANSPORTE").ParamValue)
                dtRETURN = func.Tables("RETURN").ToADOTable

                ' validamos si regreso informacion
                Dim strMensaje As String = String.Empty

                If htRespuesta("E_ENTREGA").ToString.Trim = String.Empty Then
                    strMensaje = ""
                    For Each oRow As DataRow In dtRETURN.Rows
                        strMensaje &= oRow!MESSAGE & vbCrLf
                    Next

                    MensajeError = strMensaje

                    Return Nothing

                Else

                    Return htRespuesta

                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '-----------------------------------------------------------------------------------------------------------------------
    ' JNAVA (14.03.2016): RFC nueva para generar reporte de pedidos ecommerce
    '-----------------------------------------------------------------------------------------------------------------------
    Public Function Z_FM_COMMX001_TRASL_PEDIDO(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal Status As String) As DataTable
        Dim dtPedidos As DataTable
        Dim Centro As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZPOL_SURTIDO_ENTREGA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX001_TRASL_PEDIDO")

                Centro = oParent.Read_Centros
                func.Exports("I_CENTRO").ParamValue = Centro.Trim
                func.Exports("I_FECHAINI").ParamValue = FechaInicio.ToString("yyyyMMdd")
                func.Exports("I_FECHAFIN").ParamValue = FechaFin.ToString("yyyyMMdd")

                If Status <> "TP" Then
                    func.Exports("I_STATUS").ParamValue = Status.TrimEnd
                End If

                func.Execute()

                R3.Close()

                ' obtenemos datos
                dtPedidos = func.Tables("T_TRASLADOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtPedidos

    End Function

#End Region

#Region "FacturacionSiHay"

    Public Function ZSH_DISPONIBILIDAD(ByVal dtArticulo As DataTable, Optional ByVal validarminimos As Boolean = False) As DataSet
        Dim data As DataSet = Nothing
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIMM14_DESBLOQUEOART         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_DISPONIBILIDAD")

                Dim strCentro As String = oParent.Read_Centros

                func.Exports("I_CENTRO").ParamValue = strCentro
                If validarminimos = True Then
                    func.Exports("I_CALCMINIMA").ParamValue = "X"
                End If

                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In dtArticulo.Rows
                    R_Lines = T_MATERIALES.AddRow()
                    R_Lines("MATERIAL") = CStr(row!CodArticulo)
                    If IsNumeric(CStr(row!Numero)) Then
                        R_Lines("TALLA") = Format(CDec(row!Numero), "#.0")
                    Else
                        R_Lines("TALLA") = CStr(row!Numero).Trim()
                    End If
                    R_Lines("CANTIDAD") = CInt(row!Cantidad)
                Next
                func.Execute()
                R3.Close()

                data = New DataSet("SiHay")
                data.Tables.Add(func.Tables("T_DISPONIBLES").ToADOTable())
                data.Tables.Add(func.Tables("T_DIFERENCIAS").ToADOTable())
                data.Tables.Add(func.Tables("T_MINIMAEXISTENCIA").ToADOTable())
  
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return data
    End Function

    Public Function ZSH_PARTICIPANTES(ByVal I_Tienda As String, Optional ByRef strError As String = "") As Hashtable
        Dim permisos As New Hashtable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_PARTICIPANTES               **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_PARTICIPANTES")

                func.Exports("I_TIENDA").ParamValue = I_Tienda
                func.Execute()
                R3.Close()

                permisos("Solicitar") = func.Imports("E_SOLIC").ToString()
                permisos("Suministrar") = func.Imports("E_SUMIN").ToString()
                Dim R_Lines As ERPConnect.RFCStructure = func.Imports("E_CONFIG").ToStructure()
                For Each row As ERPConnect.RFCTableColumn In R_Lines.Columns
                    permisos(row.Name) = R_Lines.Item(row.Name)
                Next

            End If
        Catch e1 As ERPConnect.RFCServerException
            'Throw e1
            strError = e1.ToString
            MsgBox(e1.ToString, MsgBoxStyle.Exclamation, "Error al ejecutar RFC ZSH_PARTICIPANTES en SAP")
        Catch e1 As ERPConnect.ERPException
            'Throw e1
            strError = e1.ToString
            MsgBox(e1.ToString, MsgBoxStyle.Exclamation, "Error al ejecutar RFC ZSH_PARTICIPANTES en SAP")
        End Try
        Return permisos
    End Function

    Public Function ZSH_PEDIDOS_HOMEDASH(ByVal centro As String) As DataSet
        Dim pedidos As DataSet = Nothing
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_PEDIDOS_HOMEDASH         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_PEDIDOS_HOMEDASH")

                func.Exports("I_CENTRO").ParamValue = centro
                func.Execute()
                R3.Close()

                pedidos = New DataSet
                pedidos.Tables.Add(func.Tables("T_CONTEO").ToADOTable())
                pedidos.Tables.Add(func.Tables("T_PEDIDOS").ToADOTable())

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return pedidos
    End Function

    Friend Function ZSH_PEDIDOS_PENDIENTES(ByVal Centro As String, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable, ByVal Status As Hashtable, ByVal R_MATERIALES As DataTable, ByVal FolioPedido As String) As DataTable

        Dim dtResultado As DataTable
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()



            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_PEDIDOS_PENDIENTES
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_PEDIDOS_PENDIENTES")

                func.Exports("I_CENTRO").ParamValue = Centro.Trim
                If FolioPedido.Trim <> "" Then func.Exports("I_PEDIDO").ParamValue = FolioPedido.Trim.PadLeft(10, "0")

                Dim T_STATUS As ERPConnect.RFCTable = func.Tables("T_STATUS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                For Each entry As DictionaryEntry In Status ' In dtMateriales.Rows
                    R_Lines = T_STATUS.AddRow
                    If IsDBNull(entry) = False Then
                        R_Lines("STATUS") = CStr(entry.Value).Trim.ToUpper
                    End If
                Next
                If Not R_MATERIALES Is Nothing Then
                    Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("R_MATERIALES")
                    Dim R_Fila As ERPConnect.RFCStructure
                    For Each row As DataRow In R_MATERIALES.Rows
                        R_Fila = T_MATERIALES.AddRow()
                        R_Fila("SIGN") = "I"
                        R_Fila("OPTION") = "EQ"
                        R_Fila("LOW") = CStr(row!Codigo)
                    Next
                End If

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("T_PEDIDOS").ToADOTable
                dtCabecera = func.Tables("T_CABECERA").ToADOTable
                dtDetalle = func.Tables("T_DETALLE").ToADOTable
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function



    Friend Function Z_FM_COMMX009_GET_BINFILESTORE(ByVal Centro As String, ByVal File As String) As Byte()

        Dim dtResultado As DataTable
        Dim respuesta As String = String.Empty
        Dim myBase64 As Byte()
        Dim size As Decimal = 0
        Dim binarycode As Byte()
        Dim bytes As Byte()

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
             oParent.SAPApplicationConfig.User, _
               oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  Z_FM_COMMX009_GET_BINFILESTORE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX010_GET_STRFILESTORE")  '("Z_FM_COMMX009_GET_BINFILESTORE") 

                func.Exports("PI_CENTRO_IN").ParamValue = Centro.Trim
                func.Exports("PI_FILE_IN").ParamValue = File
                func.Execute()

                Dim Salida As String = func.Imports("PE_FILE_STR_OUT").ToString

                '    respuesta = func.Imports("EX_FILE_OUT").ToString
                size = func.Imports("PE_SIZE_OUT").ToDouble
                '  dtResultado = func.Tables("PT_FILE_BIN_OUT").ToADOTable
                'Dim hexVal As Integer

                dtResultado = func.Tables("PE_T_FILE_STR_OUT").ToADOTable

                'For Each oRow As DataRow In dtResultado.Rows
                '    '  Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(oRow!Line)
                '    ' respuesta += System.Text.Encoding.UTF8.GetString(bytes)
                '    ' Dim ascii As Byte() = System.Text.Encoding.ASCII.GetBytes(oRow!Line)
                '    ' respuesta += System.Text.Encoding.UTF8.GetString(ascii)

                '    bytes = System.Text.Encoding.Unicode.GetBytes(oRow!Line)
                '    respuesta += System.Text.Encoding.Unicode.GetString(bytes)


                '    '   hexVal = Convert.ToInt32(oRow!Line, 16)
                '    '  respuesta += hexVal.ToString
                'Next

                R3.Close()


                'respuesta = "UEsDBBQAAAAIAHBUF1UKmvgfRDcAAPrNAQAIAAAAUFIwMS50eHSVnWuy7SiOhf9XRE2lAomn48x/XmWQva8Rr6WOut1ZmV+62RiD0GPJOfkfcuzpYufKXwnX/5z7Y8eR7r9Z/+L+D13//Y/rYHLO/5G/pnT5R3tHMaTr/tf+wu/R3kW66l+Qixy6R7uUXHt0/NH5fTQ5"
                'respuesta = "UEsDBBQAAAAIAKVYF1WT6sAvGhAAAAJ8AAAIAAAAUFIwMS50eHSVnemO7SoORv+31K/SwmaMzvu/V2M72QWEJJ+vVNLWrVUcRs+wQ7D/KHBonAK1f3Qcx/9C+MeBmYijfAj9Q/vvf8JAx9o/1H/UfnTqMMkHov6biabSYiD+R/VHx958Vjr0jwsdmvZkoukwmjn90b3V"
                'respuesta = "UEsDBBQAAAAIAKVYF1WT6sAvGhAAAAJ8AAAIAAAAUFIwMS50eHSVnemO7SoORv+31K/SwmaMzvu/V2M72QWEJJ+vVNLWrVUcRs+wQ7D/KHBonAK1f3Qcx/9C+MeBmYijfAj9Q/vvf8JAx9o/1H/UfnTqMMkHov6biabSYiD+R/VHx958Vjr0jwsdmvZkoukwmjn90b3V"

                '' Dim texto As String = HexStringToBinary(respuesta)
                '' Dim binaryDigits = HexStringToBinary(respuesta).ToCharArray

                'Dim newBytes As Byte() = Convert.FromBase64String(respuesta)
                ''dtResultado = func.Tables("T_PEDIDOS").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return bytes

    End Function


    Friend Function Z_FM_COMMX006_GET_TXT_FROM_ZIP(ByVal texto64 As String) As DataTable

        Dim dtResultado As DataTable
        Dim respuesta As String = String.Empty



        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)





            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  Z_FM_COMMX006_GET_TXT_FROM_ZIP
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_FM_COMMX006_GET_TXT_FROM_ZIP")
                func.Exports.Item(0).ParamValue = texto64



                ' func.Exports("PI_CENTRO_IN").ParamValue = Centro.Trim
                'func.Exports("PI_FILE_IN").ParamValue = File
                func.Execute()

                R3.Close()

                ' respuesta = func.Imports("EX_FILE_OUT").ToString



            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function





    Friend Function ZSH_ACTUALIZAR_SOLICITUD(ByVal Modulo As String, ByVal htCabecera As Hashtable, ByVal dtCabecera As DataTable, ByVal dtConfirmados As DataTable, ByVal dtNegados As DataTable, _
    Optional ByVal ValeCaja As String = "", Optional ByRef strRes As String = "") As Hashtable
        Dim Cupon As New Hashtable
        Dim strMensaje As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_ACTUALIZAR_SOLICITUD
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_ACTUALIZAR_SOLICITUD")

                func.Exports("I_MODULO").ParamValue = Modulo.Trim.ToUpper
                func.Exports("I_VALE_CAJA").ParamValue = ValeCaja.Trim

                'Q U I T A R ! Q U I T A R ! Q U I T A R ! Q U I T A R ! 
                'func.Exports("I_ROLLBACK").ParamValue = "X"
                'Q U I T A R ! Q U I T A R ! Q U I T A R ! Q U I T A R ! 

                Dim I_CABECERA As ERPConnect.RFCStructure = func.Exports("I_CABECERA").ToStructure

                Dim T_IDS As ERPConnect.RFCTable = func.Tables("T_IDS")
                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim T_NEGADOS As ERPConnect.RFCTable = func.Tables("T_NEGADOS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                'R_Lines.Item("Responsable") = htCabecera("Responsable")
                'R_Lines.Item("Traslado") = htCabecera("Traslado")
                'R_Lines.Item("Guia") = htCabecera("Guia")

                If htCabecera.Contains("Pedido") Then I_CABECERA.Item("VBELN") = htCabecera("Pedido")
                'If htCabecera.Contains("CentroSAP") Then I_CABECERA.Item("Cesum") = htCabecera("CentroSAP")
                If htCabecera.Contains("Responsable") Then I_CABECERA.Item("RESPONSABLE") = htCabecera("Responsable")
                If htCabecera.Contains("Traslado") Then I_CABECERA.Item("ENTREGA") = htCabecera("Traslado")
                If htCabecera.Contains("Guia") Then I_CABECERA.Item("GUIA") = htCabecera("Guia")

                If Not dtConfirmados Is Nothing Then
                    For Each oRow In dtConfirmados.Rows
                        R_Lines = T_MATERIALES.AddRow
                        R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim
                        If IsNumeric(CStr(oRow!Talla)) Then
                            R_Lines("TALLA") = Format(CDec(oRow!Talla), "#.0")
                        Else
                            R_Lines("TALLA") = CStr(oRow!Talla).Trim
                        End If
                        R_Lines("CANTIDAD") = oRow!Confirmados
                    Next
                End If

                If Not dtNegados Is Nothing Then
                    For Each oRow In dtNegados.Rows
                        R_Lines = T_NEGADOS.AddRow
                        R_Lines("MATNR") = CStr(oRow!Codigo).Trim
                        If IsNumeric(CStr(oRow!Talla)) Then
                            R_Lines("J_3ASIZE") = Format(CDec(oRow!Talla), "#.0")
                        Else
                            R_Lines("J_3ASIZE") = CStr(oRow!Talla).Trim
                        End If
                        R_Lines("CANTIDAD") = oRow!Negados
                        R_Lines("MOTIVO") = CStr(oRow!Motivo).Trim
                        R_Lines("MOTIVO_DESC") = CStr(oRow!MotivoDesc).Trim
                        R_Lines("VBELN") = CStr(htCabecera("Pedido")).Trim
                        R_Lines("WERKS") = CStr(htCabecera("CentroSAP")).Trim
                    Next
                End If

                If Not dtCabecera Is Nothing Then
                    For Each oRow In dtCabecera.Rows
                        R_Lines = T_IDS.AddRow
                        R_Lines("VBELN") = CStr(oRow!VBELN).Trim
                        R_Lines("ID_SOLICITUD") = oRow!ID_SOLICITUD
                        R_Lines("FECHA") = oRow!FECHA
                        R_Lines("HORA") = oRow!HORA
                        R_Lines("CESUM") = CStr(oRow!CESUM).Trim
                        R_Lines("STATUS_SUM") = CStr(oRow!STATUS_SUM).Trim
                        R_Lines("CEDES") = CStr(oRow!CEDES).Trim
                        R_Lines("STATUS_DES") = oRow!STATUS_DES
                        R_Lines("TIPO_ENVIO") = CStr(oRow!TIPO_ENVIO).Trim
                        R_Lines("ENTREGA") = CStr(oRow!ENTREGA).Trim
                        R_Lines("FOLIO_ENTREGA") = CStr(oRow!FOLIO_ENTREGA).Trim
                        R_Lines("ENVIADO") = CStr(oRow!ENVIADO).Trim
                        R_Lines("GUIA") = CStr(oRow!GUIA).Trim
                        R_Lines("FECHA_MODIF") = oRow!FECHA_MODIF
                        R_Lines("RESPONSABLE") = CStr(oRow!RESPONSABLE).Trim
                    Next
                End If

                func.Execute()
                R3.Close()

                Dim R_LinesI As ERPConnect.RFCStructure = func.Imports("E_CUPON").ToStructure()
                For Each row As ERPConnect.RFCTableColumn In R_LinesI.Columns
                    Cupon(row.Name) = R_LinesI.Item(row.Name)
                Next

                strRes = func.Imports("E_ERROR").ToString
                strMensaje = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper = "X" Then
                    MsgBox("Ocurrio un error al actualizar el Pedido SH en SAP. " & strMensaje & "", MsgBoxStyle.Exclamation, "Error al actualizar Pedido SH en SAP")
                    Cupon = Nothing
                Else
                    strRes = "S"
                End If
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            'si por alguna razon marco algun error bloquea ese pedido para que no se haga ningun movimiento
            If htCabecera.Contains("Pedido") Then
                ZPEDIDO_N_CURSO(htCabecera("Pedido"))
            End If
            Throw e1
        End Try

        Return Cupon

    End Function

    Friend Function ZSH_ACTUALIZAR_SOLICITUD(ByVal Modulo As String, ByVal htCabecera As Hashtable, ByVal dtCabecera As DataRow, ByVal dtConfirmados As DataTable, ByVal dtNegados As DataTable, _
    Optional ByVal ValeCaja As String = "", Optional ByRef strRes As String = "") As Hashtable
        Dim Cupon As New Hashtable
        Dim strMensaje As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_ACTUALIZAR_SOLICITUD
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_ACTUALIZAR_SOLICITUD")

                func.Exports("I_MODULO").ParamValue = Modulo.Trim.ToUpper
                func.Exports("I_VALE_CAJA").ParamValue = ValeCaja.Trim

                'Q U I T A R ! Q U I T A R ! Q U I T A R ! Q U I T A R ! 
                'func.Exports("I_ROLLBACK").ParamValue = "X"
                'Q U I T A R ! Q U I T A R ! Q U I T A R ! Q U I T A R ! 

                Dim I_CABECERA As ERPConnect.RFCStructure = func.Exports("I_CABECERA").ToStructure

                Dim T_IDS As ERPConnect.RFCTable = func.Tables("T_IDS")
                Dim T_MATERIALES As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                Dim T_NEGADOS As ERPConnect.RFCTable = func.Tables("T_NEGADOS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                'R_Lines.Item("Responsable") = htCabecera("Responsable")
                'R_Lines.Item("Traslado") = htCabecera("Traslado")
                'R_Lines.Item("Guia") = htCabecera("Guia")

                If htCabecera.Contains("Pedido") Then I_CABECERA.Item("VBELN") = htCabecera("Pedido")
                'If htCabecera.Contains("CentroSAP") Then I_CABECERA.Item("Cesum") = htCabecera("CentroSAP")
                If htCabecera.Contains("Responsable") Then I_CABECERA.Item("RESPONSABLE") = htCabecera("Responsable")
                If htCabecera.Contains("Traslado") Then I_CABECERA.Item("ENTREGA") = htCabecera("Traslado")
                If htCabecera.Contains("Guia") Then I_CABECERA.Item("GUIA") = htCabecera("Guia")

                If Not dtConfirmados Is Nothing Then
                    For Each oRow In dtConfirmados.Rows
                        R_Lines = T_MATERIALES.AddRow
                        R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim
                        If IsNumeric(CStr(oRow!Talla)) Then
                            R_Lines("TALLA") = Format(CDec(oRow!Talla), "#.0")
                        Else
                            R_Lines("TALLA") = CStr(oRow!Talla).Trim
                        End If
                        R_Lines("CANTIDAD") = oRow!Confirmados
                    Next
                End If

                If Not dtNegados Is Nothing Then
                    For Each oRow In dtNegados.Rows
                        R_Lines = T_NEGADOS.AddRow
                        R_Lines("MATNR") = CStr(oRow!Codigo).Trim
                        If IsNumeric(CStr(oRow!Talla)) Then
                            R_Lines("J_3ASIZE") = Format(CDec(oRow!Talla), "#.0")
                        Else
                            R_Lines("J_3ASIZE") = CStr(oRow!Talla).Trim
                        End If
                        R_Lines("CANTIDAD") = oRow!Negados
                        R_Lines("MOTIVO") = CStr(oRow!Motivo).Trim
                        R_Lines("MOTIVO_DESC") = CStr(oRow!MotivoDesc).Trim
                        R_Lines("VBELN") = CStr(htCabecera("Pedido")).Trim
                        R_Lines("WERKS") = CStr(htCabecera("CentroSAP")).Trim
                    Next
                End If

                If Not dtCabecera Is Nothing Then
                    'For Each oRow In dtCabecera.Rows
                    R_Lines = T_IDS.AddRow
                    R_Lines("VBELN") = CStr(dtCabecera!VBELN).Trim
                    R_Lines("ID_SOLICITUD") = dtCabecera!ID_SOLICITUD
                    R_Lines("FECHA") = dtCabecera!FECHA
                    R_Lines("HORA") = dtCabecera!HORA
                    R_Lines("CESUM") = CStr(dtCabecera!CESUM).Trim
                    R_Lines("STATUS_SUM") = CStr(dtCabecera!STATUS_SUM).Trim
                    R_Lines("CEDES") = CStr(dtCabecera!CEDES).Trim
                    R_Lines("STATUS_DES") = dtCabecera!STATUS_DES
                    R_Lines("TIPO_ENVIO") = CStr(dtCabecera!TIPO_ENVIO).Trim
                    R_Lines("ENTREGA") = CStr(dtCabecera!ENTREGA).Trim
                    R_Lines("FOLIO_ENTREGA") = CStr(dtCabecera!FOLIO_ENTREGA).Trim
                    R_Lines("ENVIADO") = CStr(dtCabecera!ENVIADO).Trim
                    R_Lines("GUIA") = CStr(dtCabecera!GUIA).Trim
                    R_Lines("FECHA_MODIF") = dtCabecera!FECHA_MODIF
                    R_Lines("RESPONSABLE") = CStr(dtCabecera!RESPONSABLE).Trim
                    'Next
                End If

                func.Execute()
                R3.Close()

                Dim R_LinesI As ERPConnect.RFCStructure = func.Imports("E_CUPON").ToStructure()
                For Each row As ERPConnect.RFCTableColumn In R_LinesI.Columns
                    Cupon(row.Name) = R_LinesI.Item(row.Name)
                Next

                strRes = func.Imports("E_ERROR").ToString
                strMensaje = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper = "X" Then
                    MsgBox("Ocurrio un error al actualizar el Pedido SH en SAP. " & strMensaje & "", MsgBoxStyle.Exclamation, "Error al actualizar Pedido SH en SAP")
                    Cupon = Nothing
                Else
                    strRes = "S"
                End If
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            'si por alguna razon marco algun error bloquea ese pedido para que no se haga ningun movimiento
            If htCabecera.Contains("Pedido") Then
                ZPEDIDO_N_CURSO(htCabecera("Pedido"))
            End If
            Throw e1
        End Try

        Return Cupon

    End Function

    Friend Function ZSH_DATOS_ENVIO(ByVal Pedido As String, ByRef dtDatosG As DataTable) As DataTable

        Dim dtDatosEnvio As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSH_DATOS_ENVIO                ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_DATOS_ENVIO")

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim.PadLeft(10, "0")

                func.Execute()

                R3.Close()

                'Dim DatosG As ERPConnect.RFCStructure = func.Exports("E_TIPO").ToStructure

                dtDatosG = New DataTable("DatosGenerales")
                With dtDatosG
                    .Columns.Add("Tipo", GetType(String))
                    '.Columns.Add("Local", GetType(String))
                    '.Columns.Add("FacturaSAP", GetType(String))
                    '.Columns.Add("TrasladoSAP", GetType(String))
                    .AcceptChanges()
                End With

                Dim oRow As DataRow = dtDatosG.NewRow

                With oRow
                    !Tipo = func.Imports("E_TIPO").ToString
                    '!Local = DatosG("E_LOCAL").ToString
                    '!FacturaSAP = func.Imports("E_FACTURA").ToString
                    '!TrasladoSAP = func.Imports("E_TRASLADO").ToString
                End With
                dtDatosG.Rows.Add(oRow)

                Dim sTemp As ERPConnect.RFCStructure = func.Imports("E_DIRECCION").ToStructure

                dtDatosEnvio = New DataTable("DatosEnvio")
                With dtDatosEnvio
                    .Columns.Add("Nombre", GetType(String))
                    .Columns.Add("Domicilio", GetType(String))
                    .Columns.Add("Ciudad", GetType(String))
                    .Columns.Add("Estado", GetType(String))
                    .Columns.Add("RFC", GetType(String))
                    .Columns.Add("Telefono", GetType(String))
                    .Columns.Add("CP", GetType(String))
                    .AcceptChanges()
                End With

                oRow = dtDatosEnvio.NewRow

                With oRow
                    !Nombre = sTemp("NAME1") & " " & sTemp("NAME2") & " " & sTemp("NAME3")
                    !Domicilio = sTemp("STREET") & sTemp("HOUSE_NUM1") & sTemp("CITY2")
                    !Ciudad = sTemp("CITY1")
                    !Estado = sTemp("REGION")
                    !RFC = sTemp("NAME4")
                    !CP = sTemp("POST_CODE1")
                    !Telefono = ""
                End With
                dtDatosEnvio.Rows.Add(oRow)

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtDatosEnvio

    End Function

    Friend Function ZSH_REEMBOLSO(ByVal strFolioPedido As String, ByVal strCliente As String, ByVal strAlmacen As String, ByVal decValeCaja As Decimal, ByVal decEfectivo As Decimal, ByVal strDivision As String, ByVal strTipo As String, ByVal ActualizarSiHay As String, ByVal strFolioSapFactura As String, ByVal decDPVale As Decimal, ByVal bRevale As Boolean) As Hashtable
        '---------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (22/05/2013) - RFC para reembolso en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------------
        Dim dtResultado As DataTable
        Dim strCentro As String
        Dim strMensaje As String
        Dim FolioDocumentos As New Hashtable
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_REEMBOLSO
                '*****************************************************
                ' Create a function object

                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))
                '------------------------------------------------------
                strCentro = oParent.Read_Centros()

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_REEMBOLSO")

                'Asigno valores
                func.Exports("I_TIPO").ParamValue = strTipo
                func.Exports("I_PEDIDO").ParamValue = strFolioPedido
                func.Exports("I_FACTURA").ParamValue = strFolioSapFactura.Trim.PadLeft(10, "0")
                func.Exports("I_CENTRO").ParamValue = strCentro
                func.Exports("I_KUNNR").ParamValue = strCliente
                func.Exports("I_IMPORTE_EFECTIVO").ParamValue = decEfectivo.ToString("F2") 'Solo dos decimales
                func.Exports("I_IMPORTE_VALECJA").ParamValue = decValeCaja.ToString("F2") 'Solo dos decimales
                func.Exports("I_GSBER").ParamValue = strDivision
                func.Exports("I_TIENDA").ParamValue = strAlmacen
                func.Exports("I_REFERENCIA").ParamValue = strNumRef
                func.Exports("I_MODO").ParamValue = "N"
                func.Exports("I_ACTUALIZASH").ParamValue = ActualizarSiHay

                '---------------------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (28/10/2014) - Nuevos Parametros para reembolso con formas de pago de DPVale
                '---------------------------------------------------------------------------------------------------------------------------------------------
                func.Exports("I_IMPORTE_DPVL").ParamValue = decDPVale.ToString("F2") 'Solo dos decimales
                func.Exports("I_REVALE").ParamValue = IIf(bRevale, "X", "")
                '---------------------------------------------------------------------------------------------------------------------------------------------

                'QUITAR!!!
                'func.Exports("I_ROLLBACK").ParamValue = "X"
                'QUITAR!!!

                func.Execute()
                R3.Close()

                dtResultado = func.Tables("T_RETURN").ToADOTable

                FolioDocumentos("E_BELNR_EFECTIVO") = func.Imports("E_BELNR_EFECTIVO").ParamValue
                FolioDocumentos("E_BELNR_VALECJA") = func.Imports("E_BELNR_VALECJA").ParamValue
                FolioDocumentos("MENSAJE") = ""

                If dtResultado.Rows.Count > 0 Then
                    Dim strError As String = ""
                    For Each oRow As DataRow In dtResultado.Rows
                        strError = strError & vbCrLf & CStr(oRow!Message)
                    Next
                    FolioDocumentos("MENSAJE") = strError
                End If

                Return FolioDocumentos

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/05/2013: RFC para guardar el pedido con todos sus detalles
    '-------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZSH_FACTURACION(ByVal exports As Hashtable, ByVal tablas As DataSet) As Hashtable
        Dim resultado As New Hashtable
        Dim valido As Boolean = False
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_FACTURACION
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_FACTURACION")
                func.Exports("I_VKBUR").ParamValue = CStr(exports("I_VKBUR"))
                'func.Exports("I_CLASEPEDIDO").ParamValue = CStr(exports("I_CLASEPEDIDO"))
                func.Exports("I_VKORG").ParamValue = CStr(exports("I_VKORG"))
                func.Exports("I_SERIALID").ParamValue = CStr(exports("I_SERIALID"))
                func.Exports("I_CANAL").ParamValue = CStr(exports("I_CANAL"))
                func.Exports("I_MOT_PEDIDO").ParamValue = CStr(exports("I_MOT_PEDIDO"))
                func.Exports("I_VALEEMP").ParamValue = CStr(exports("I_VALEEMP"))
                func.Exports("I_REFERENCIA").ParamValue = CStr(exports("I_REFERENCIA"))

                func.Exports("I_KUNNR").ParamValue = CStr(exports("I_KUNNR"))
                func.Exports("I_REP_VENTAS").ParamValue = CStr(exports("I_REP_VENTAS"))
                'func.Exports("I_VKGRP").ParamValue = CStr(exports("I_VKGRP"))
                'func.Exports("I_FACDPPRO").ParamValue = CStr(exports("I_FACDPPRO"))
                func.Exports("I_RESPONSABLE").ParamValue = CStr(exports("I_RESPONSABLE"))
                If tablas.Tables.Contains("T_PRODUCTOS") Then
                    Dim T_PLines As ERPConnect.RFCTable = func.Tables("T_PRODUCTOS")
                    For Each row As DataRow In tablas.Tables("T_PRODUCTOS").Rows
                        Dim R_PLines As ERPConnect.RFCStructure = T_PLines.AddRow()
                        R_PLines("INDEX") = CInt(row!INDEX)
                        If Not IsDBNull(row!CENTRO) Then
                            R_PLines("CENTRO") = CStr(row!CENTRO)
                        End If
                        R_PLines("MATNR") = CStr(row!MATNR)
                        Dim talla As String = CStr(row!Talla)
                        If IsNumeric(talla) Then
                            R_PLines("TALLA") = Format(CDec(talla), "#.0")
                        Else
                            R_PLines("TALLA") = talla
                        End If
                        R_PLines("CANTIDAD") = CInt(row!CANTIDAD)
                        R_PLines("CANT_FACT") = CInt(row!CANT_FACT)
                    Next
                End If
                If tablas.Tables.Contains("T_FPAGOS") Then
                    Dim T_FPLines As ERPConnect.RFCTable = func.Tables("T_FPAGOS")
                    For Each row As DataRow In tablas.Tables("T_FPAGOS").Rows
                        Dim R_FPLines As ERPConnect.RFCStructure = T_FPLines.AddRow()
                        Dim tipo As String = CStr(row!FORMA_PAGO)
                        R_FPLines("POSNR") = row!POSNR
                        R_FPLines("FORMA_PAGO") = tipo
                        R_FPLines("REFERENCIA") = CStr(row!REFERENCIA)
                        R_FPLines("PER_FINANC") = CStr(row!PER_FINANC)
                        R_FPLines("NUM_APROBACION") = CStr(row!NUM_APROBACION)
                        R_FPLines("NTARJETA") = CStr(row!NTARJETA)
                        R_FPLines("SIHAY") = CStr(row!SIHAY)
                        R_FPLines("PEDIDOSH") = CStr(row!PEDIDOSH)
                        R_FPLines("STATUS") = CStr(row!STATUS)
                        R_FPLines("FOLIO") = CStr(row!FOLIO)
                        If tipo = "DPVL" Then
1:                          R_FPLines("NUMVA") = CStr(row!NUMVA)
2:                          R_FPLines("DISTRIB") = CStr(row!DISTRIB)
3:                          'R_FPLines("KUNNR") = CStr(row!KUNNR)
                            R_FPLines("CTEDIST") = row!CTEDIST
                            '-----------------------------------------------------------------------------------------------------------------------------
                            'JNAVA 27/10/2013: Carga todas las formas de pago que se realizaron en el pedido
4:                          '-----------------------------------------------------------------------------------------------------------------------------
5:                          R_FPLines("NUMDE") = CStr(row!NUMDE)
6:                          R_FPLines("PARES_PZAS") = row!PARES_PZAS
                            R_FPLines("RPARES_PZAS") = row!RPARES_PZAS
                            R_FPLines("RMONTODPVALE") = row!RMONTODPVALE


7:                          R_FPLines("MONTOUTILIZADO") = CStr(row!MONTOUTILIZADO)
8:                          R_FPLines("MONTODPVALE") = CDec(row!MONTODPVALE)
9:                          R_FPLines("REVALE") = CStr(row!REVALE)
10:                         R_FPLines("FECCO") = CStr(row!FECCO)
                            '-----------------------------------------------------------------------------------------------------------------------------
                        End If
                        R_FPLines("IMPORTE") = CDec(row!IMPORTE)
                    Next
                End If
                If tablas.Tables.Contains("T_CONDICIONES") Then
                    Dim T_CLines As ERPConnect.RFCTable = func.Tables("T_CONDICIONES")
                    For Each row As DataRow In tablas.Tables("T_CONDICIONES").Rows
                        Dim R_CLines As ERPConnect.RFCStructure = T_CLines.AddRow()
                        R_CLines("INDEX") = CInt(row!INDEX)
                        R_CLines("CONDICION") = CStr(row!Condicion)
                        R_CLines("IMPORTE") = CDec(row!IMPORTE)
                    Next
                End If
                func.Execute()
                R3.Close()

                resultado("E_PEDIDO") = CStr(func.Imports("E_PEDIDO").ParamValue)
                resultado("E_FACTURA") = CStr(func.Imports("E_FACTURA").ParamValue)
                resultado("E_FACTURAFI") = CStr(func.Imports("E_FACTURAFI").ParamValue)
                resultado("T_RETURN") = func.Tables("T_RETURN").ToADOTable()
                Dim res As DataTable = CType(resultado("T_RETURN"), DataTable)
                If res.Rows.Count = 0 Then
                    valido = True
                End If

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        Catch ex As Exception
            Throw New ApplicationException(ex.ToString & " en linea " & Err.Erl)
        End Try
        resultado("Success") = valido
        Return resultado
    End Function

    Friend Function ZSH_FACTURAR_IDS(ByVal Pedido As String, ByVal Responsable As String, ByRef dtCabecera As DataTable, _
                                     ByRef FolioSAP As String, ByRef FolioFISAP As String, ByRef htCupon As Hashtable, _
                                     ByRef strRes As String) As DataTable

        Dim dtMateriales As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSH_FACTURAR_IDS               ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_FACTURAR_IDS")
                Dim T_IDS As ERPConnect.RFCTable = func.Tables("T_IDS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow

                If Not dtCabecera Is Nothing Then
                    For Each oRow In dtCabecera.Rows
                        R_Lines = T_IDS.AddRow
                        R_Lines("VBELN") = CStr(oRow!VBELN).Trim
                        R_Lines("ID_SOLICITUD") = oRow!ID_SOLICITUD
                        R_Lines("FECHA") = oRow!FECHA
                        R_Lines("HORA") = oRow!HORA
                        R_Lines("CESUM") = CStr(oRow!CESUM).Trim
                        R_Lines("STATUS_SUM") = CStr(oRow!STATUS_SUM).Trim
                        R_Lines("CEDES") = CStr(oRow!CEDES).Trim
                        R_Lines("STATUS_DES") = oRow!STATUS_DES
                        R_Lines("TIPO_ENVIO") = CStr(oRow!TIPO_ENVIO).Trim
                        R_Lines("ENTREGA") = CStr(oRow!ENTREGA).Trim
                        R_Lines("FOLIO_ENTREGA") = CStr(oRow!FOLIO_ENTREGA).Trim
                        R_Lines("ENVIADO") = CStr(oRow!ENVIADO).Trim
                        R_Lines("GUIA") = CStr(oRow!GUIA).Trim
                        R_Lines("FECHA_MODIF") = oRow!FECHA_MODIF
                        R_Lines("RESPONSABLE") = CStr(oRow!RESPONSABLE).Trim
                    Next
                End If

                func.Exports("I_PEDIDO").ParamValue = Pedido.Trim.PadLeft(10, "0")
                func.Exports("I_RESPONSABLE").ParamValue = Responsable.Trim

                func.Execute()

                R3.Close()

                strRes = func.Imports("E_RESULT").ToString.Trim.ToUpper

                If strRes = "Y" Then
                    dtMateriales = func.Tables("T_MATERIALES").ToADOTable
                    FolioSAP = func.Imports("E_SDDOCUMENT").ToString
                    FolioFISAP = func.Imports("E_FIDOCUMENT").ToString

                    Dim R_LinesI As ERPConnect.RFCStructure = func.Imports("E_CUPON").ToStructure()

                    htCupon = New Hashtable
                    For Each row As ERPConnect.RFCTableColumn In R_LinesI.Columns
                        htCupon(row.Name) = R_LinesI.Item(row.Name)
                    Next
                Else
                    Dim dtMessages As DataTable = func.Tables("T_RETURN").ToADOTable
                    Dim strMsg As String = ""
                    For Each oRow In dtMessages.Rows
                        strMsg &= CStr(oRow!Message).Trim & vbCrLf
                    Next
                    htCupon = Nothing
                    MsgBox(strMsg.Trim, MsgBoxStyle.Exclamation, "Error en SAP")
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtMateriales

    End Function



    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Realiza la cancelación del Pedido y retorna sus importes en vale de caja y efectivo
    '------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_CANCELAR_SOLICITUDES(ByVal FolioSAP As String, Optional ByVal Debug As String = "") As Hashtable
        Dim resultado As New Hashtable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSH_CANCELAR_SOLICITUDES       ****
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_MF_FYCMX1005_CANC_SOLICITUDS")

                func.Exports("I_PEDIDO").ParamValue = FolioSAP
                func.Exports("I_ROLLBACK").ParamValue = Debug
                func.Exports("I_RESPONSABLE").ParamValue = oParent.ApplicationContext.Security.CurrentUser.Name

                func.Execute()
                R3.Close()

                resultado("E_ERROR") = func.Imports("E_ERROR").ParamValue
                resultado("E_IMP_VALECAJA") = func.Imports("E_IMP_VALECAJA").ParamValue
                resultado("E_IMP_EFECTIVO") = func.Imports("E_IMP_EFECTIVO").ParamValue
                resultado("E_FACTENTIENDA") = func.Imports("E_FACTENTIENDA").ParamValue
                resultado("E_FACTXSIHAY") = func.Imports("E_FACTXSIHAY").ParamValue
                resultado("E_IMP_DPVALE") = func.Imports("E_IMP_DPVALE").ParamValue
                resultado("E_SALESDOCUMENT") = func.Imports("E_SALESDOCUMENT").ParamValue
                Dim cuponstr As ERPConnect.RFCStructure = func.Imports("E_CUPON").ToStructure()
                Dim dtCupon As New Hashtable
                For Each str As ERPConnect.RFCTableColumn In cuponstr.Columns
                    dtCupon(str.Name) = cuponstr(str.Name)
                Next
                resultado("E_CUPON") = dtCupon
                resultado("T_RETURN") = func.Tables("T_RETURN").ToADOTable()

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return resultado
    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 21/05/2013: Realiza el Reembolso por vale de caja o efectivo
    '-------------------------------------------------------------------------------------------------------------------------------------

    Public Function ZSH_REEMBOLSO(ByVal exportar As Hashtable) As Hashtable
        Dim resultado As New Hashtable
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSH_REEMBOLSO                  ****
                '*****************************************************
                ' Create a function object
                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_REEMBOLSO")
                func.Exports("I_TIPO").ParamValue = CStr(exportar("I_TIPO"))
                func.Exports("I_PEDIDO").ParamValue = CStr(exportar("I_PEDIDO"))
                func.Exports("I_CENTRO").ParamValue = oParent.Read_Centros
                func.Exports("I_KUNNR").ParamValue = CStr(exportar("I_KUNNR"))
                func.Exports("I_IMPORTE_EFECTIVO").ParamValue = CStr(exportar("I_IMPORTE_EFECTIVO"))
                func.Exports("I_IMPORTE_VALECJA").ParamValue = CStr(exportar("I_IMPORTE_VALECJA"))
                func.Exports("I_GSBER").ParamValue = CStr(exportar("I_GSBER"))
                func.Exports("I_TIENDA").ParamValue = CStr(exportar("I_TIENDA"))
                func.Exports("I_ACTUALIZASH").ParamValue = "X"
                func.Exports("I_REFERENCIA").ParamValue = strNumRef
                func.Exports("I_MODO").ParamValue = CStr(exportar("I_MODO"))
                func.Exports("I_ROLLBACK").ParamValue = "X"
                func.Execute()
                R3.Close()
                resultado("E_BELNR_EFECTIVO") = CStr(func.Imports("E_BELNR_EFECTIVO").ParamValue).Trim()
                resultado("E_BELNR_VALECJA") = CStr(func.Imports("E_BELNR_VALECJA").ParamValue).Trim()
                resultado("T_RETURN") = func.Tables("T_RETURN").ToADOTable()
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return resultado
    End Function

    Public Function ZPEDIDO_N_CURSO(ByVal Pedido As String) As String
        Dim resultado As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPEDIDO_N_CURSO                  ****
                '*****************************************************
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPEDIDO_N_CURSO")
                func.Exports("I_PEDIDO").ParamValue = CStr(Pedido)
                func.Exports("I_ERROR").ParamValue = "X"
                func.Execute()
                R3.Close()

                resultado = CStr(func.Imports("E_ERRORMSG").ParamValue).Trim()

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return resultado
    End Function

    Friend Function MSS_GET_SY_DATE_TIME() As DateTime

        Dim Fecha As DateTime = Now
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  MSS_GET_SY_DATE_TIME
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_MSS_GET_SY_DATE_TIME")

                func.Execute()

                R3.Close()

                Dim strFecha As String = ""

                strFecha = func.Imports("SAPDATE").ToString
                strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)

                Fecha = CDate(strFecha)

                strFecha = func.Imports("SAPTIME").ToString

                Fecha = New DateTime(Fecha.Year, Fecha.Month, Fecha.Day, strFecha.Substring(0, 2), strFecha.Substring(2, 2), strFecha.Substring(4, 2))

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return Fecha

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (24/06/2013) - RFC para compensar pedidos si hay
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZSH_COMPENSAR(ByVal FechaCierre As DateTime, ByVal dtFacturas As DataView, datos As Dictionary(Of String, Object)) As String
        Dim dtResultado As DataTable
        Dim strCentro As String = oParent.Read_Centros()
        Dim strResult As String = ""

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_COMPENSAR
                '*****************************************************
                ' Create a function object
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(FechaCierre.Date.Date, "ddMMyyyy")))
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_COMPENSAR")

                'Asigno valores
                func.Exports("CENTRO").ParamValue = strCentro
                func.Exports("I_FECHA").ParamValue = Format(FechaCierre, "yyyyMMdd")
                func.Exports("I_TIENDA").ParamValue = CStr(datos("TIENDA"))
                func.Exports("I_MOT_PED").ParamValue = CStr(datos("I_MOT_PED"))
                func.Exports("I_REFBA").ParamValue = strNumRef
                Dim T_Documents As ERPConnect.RFCTable = func.Tables("T_DOCUMENTS")
                For Each row As DataRowView In dtFacturas
                    Dim R_document As ERPConnect.RFCStructure = T_Documents.AddRow()
                    R_document("BSTNK") = row!Referencia
                    R_document("VBELN") = row!FolioSAP
                    'R_document("VCJA") = row!Vcja
                Next
                'Ejecutamos la RFC
                func.Execute()
                R3.Close()

                'Obtenemos el Resultado
                dtResultado = func.Tables("T_RETURN").ToADOTable

                strResult = func.Imports("E_ERROR").ToString
                'Revisamos si hay un mensaje de error
                If strResult.Trim <> "" Then
                    If dtResultado.Rows.Count > 0 Then
                        For Each oRow As DataRow In dtResultado.Rows
                            strResult += vbCrLf & CStr(oRow!Message)
                        Next

                    End If
                End If

                Return strResult

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (04/07/2013) - RFC para obtener desde SAP los importes disponible para Vale de caja, Efectivo y Facilito 
    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (28/10/2014) - RFC para obtener desde SAP los importes disponible para DPVale
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZSH_CALCULO_REEMBOLSOS(ByVal strFolioPedido As String, ByVal IncluirFacturado As String) As Hashtable
        Dim htImportesSAP As New Hashtable

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_CALCULO_REEMBOLSOS
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_CALCULO_REEMBOLSOS")

                'Asigno valores
                func.Exports("I_PEDIDO").ParamValue = strFolioPedido
                func.Exports("I_FACTURADO").ParamValue = IncluirFacturado

                func.Execute()
                R3.Close()

                htImportesSAP("E_IMP_EFECTIVO") = func.Imports("E_IMP_EFECTIVO").ToString
                htImportesSAP("E_IMP_VALECAJA") = func.Imports("E_IMP_VALECAJA").ToString
                htImportesSAP("E_IMP_FACILITO") = func.Imports("E_IMP_FACILITO").ToString
                htImportesSAP("E_IMP_DPVALE") = func.Imports("E_IMP_DPVALE").ToString 'JNAVA (28/10/2014)

                Return htImportesSAP

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZSH_ES_TIENDA_CATALOGO() As Boolean
        Dim bResult As Boolean = False

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_ES_TIENDA_CATALOGO
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_ES_TIENDA_CATALOGO")

                'Asigno valores
                func.Exports("I_OFVTA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")

                func.Execute()

                R3.Close()

                If func.Imports("E_CATALOGO").ToString.Trim.ToUpper = "X" Then
                    bResult = True
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return bResult

    End Function

    Friend Function ZSH_CIERRE(ByVal FechaCierre As Date) As String
        Dim dtResultado As DataTable
        Dim strCentro As String = oParent.Read_Centros()
        Dim strResult As String = ""

        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_CIERRE
                '*****************************************************
                ' Create a function object
                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(FechaCierre.Date.Date, "ddMMyyyy")))
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_CIERRE")
                func.Exports("CENTRO").ParamValue = strCentro
                func.Exports("Fecha").ParamValue = Format(FechaCierre, "yyyyMMdd")
                func.Execute()
                'Obtenemos los mensajes de errores
                dtResultado = func.Tables("T_RETURN").ToADOTable

                strResult = func.Imports("E_Error").ToString

                'Revisamos si hay un mensaje de error
                If strResult.Trim.ToUpper <> "" Then
                    If dtResultado.Rows.Count > 0 Then
                        strResult = ""
                        For Each oRow As DataRow In dtResultado.Rows
                            strResult &= vbCrLf & CStr(oRow!Message)
                        Next
                    End If
                End If
                R3.Close()

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strResult

    End Function

    Public Function ZMM_CAMBIOSMATERIALES(ByVal datFechaIni As Date, ByVal datFechaFin As Date, ByVal todo As Boolean, Optional ByVal material As String = "") As DataSet
        Dim dtUPC As New DataSet
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            '--------------------------------------------------------------------------------
            ' JNAVA (12.05.2016): Se aumenta el tiempo de Espera de SAP (TimeOut)
            '--------------------------------------------------------------------------------
            R3.HttpTimeout = oParent.SAPApplicationConfig.Timeout
            '--------------------------------------------------------------------------------

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_CIERRE
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_CAMBIOSMATERIALES")

                'Asigno valores
                func.Exports("FECHA_INICIO").ParamValue = "01012016"
                'func.Exports("FECHA_INICIO").ParamValue = datFechaIni.ToString("ddMMyyyy")
                func.Exports("FECHA_FIN").ParamValue = datFechaFin.ToString("ddMMyyyy")
                func.Exports("WERKS").ParamValue = oParent.Read_Centros() 'oParent.ApplicationContext.ApplicationConfiguration.Almacen
                If todo = True Then
                    func.Exports("INDIVI").ParamValue = ""
                Else
                    func.Exports("INDIVI").ParamValue = "X"
                    func.Exports("EAN").ParamValue = material.PadLeft(18, "0")
                End If
                'Ejecutamos la RFC
                func.Execute()

                R3.Close()

                dtUPC.Tables.Add(func.Tables("ZMMCAMBIOS").ToADOTable())

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtUPC
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (24.02.2017): RFC para cancelar venta de SH en SAP
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Public Function ZSH_CANCELACION_VENTA(ByVal Referencia As String, ByVal FolioSAP As String, ByVal DetalleFactura As DataTable, ByVal Tipo As String, ByRef MontoDPVL As Decimal, ByRef MontoValeCaja As Decimal, Optional ByRef strError As String = "") As String

        ' Se definen los parámetros TABLE            
        Dim strSalesDocument As String = "", strFiDocument As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSH_CANCELACION_VENTA  ***
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_CANCELACION_VENTA")
                ' Asigno valores a los objetos
                func.Exports("I_CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("I_FACTURA").ParamValue = FolioSAP.Trim
                func.Exports("I_REFERENCIA").ParamValue = Referencia.Trim
                func.Exports("I_TIPO_CANC").ParamValue = Tipo.Trim
                Dim T_Lines As ERPConnect.RFCTable = func.Tables("T_MATERIALES")
                For Each oRow As DataRow In DetalleFactura.Rows
                    Dim R_Lines As ERPConnect.RFCStructure = T_Lines.AddRow()
                    R_Lines("MATNR") = CStr(oRow!CodArticulo)
                    Dim Numero As String = CStr(oRow!Numero)
                    If IsNumeric(Numero) Then
                        R_Lines("TALLA") = Format(CDec(Numero), "#.0")
                    Else
                        R_Lines("TALLA") = Numero
                    End If
                    R_Lines("CANTIDAD") = CInt(oRow!Cantidad)
                    R_Lines("CONDICION") = CInt(oRow!Descuento)
                    R_Lines("IMPORTE") = CInt(oRow!PrecioOferta)
                Next

                'Ejecutamos RFC
                func.Execute()

                'Cerramos conexion
                R3.Close()

                'Obtenemos datos
                strSalesDocument = func.Imports("E_SALESDOCUMENT").ParamValue.ToString.Trim
                MontoDPVL = CDec(func.Imports("E_MONTO_DPVL").ParamValue)
                MontoValeCaja = CDec(func.Imports("E_MONTO_VCJA").ParamValue)
                Dim dtReturn As DataTable = func.Tables("RETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    strError &= CStr(row("MESSAGE"))
                Next
            End If

            Return strSalesDocument.Trim

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (21.03.2017): Nueva RFC para reembolso de SH en SAP
    '---------------------------------------------------------------------------------------------------------------------------------------------
    Friend Function Z_MF_FYCMX1005_REEMBOLSO_SH(ByVal strFolioPedido As String, ByVal strAlmacen As String, ByVal decValeCaja As Decimal, ByVal decEfectivo As Decimal, ByVal strFolioSapFactura As String, ByVal decDPVale As Decimal, ByVal bRevale As Boolean) As Dictionary(Of String, Object)
        Dim dtResultado As DataTable
        Dim result As New Dictionary(Of String, Object)
        Dim Documentos As New Dictionary(Of String, Object)
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  Z_MF_FYCMX1005_REEMBOLSO_SH
                '*****************************************************
                ' Create a function object

                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))
                '------------------------------------------------------

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("Z_MF_FYCMX1005_REEMBOLSO_SH")

                'Asigno valores
                If strFolioSapFactura.Trim <> String.Empty Then
                    func.Exports("IM_CANCEL").ParamValue = "X"
                Else
                    func.Exports("IM_CANCEL").ParamValue = String.Empty
                End If
                func.Exports("IM_PEDIDO").ParamValue = strFolioPedido
                If strFolioSapFactura.Trim <> String.Empty Then
                    func.Exports("IM_FACTURA").ParamValue = strFolioSapFactura.Trim.PadLeft(10, "0")
                Else
                    func.Exports("IM_FACTURA").ParamValue = strFolioSapFactura.Trim
                End If
                func.Exports("IM_TIENDA").ParamValue = "T" & strAlmacen
                func.Exports("IM_XBLNR").ParamValue = strNumRef
                func.Exports("IM_REVALE").ParamValue = IIf(bRevale, "X", "")
                func.Exports("IM_MONTO_EFEC").ParamValue = decEfectivo.ToString("F2") 'Solo dos decimales
                func.Exports("IM_MONTO_VCJA").ParamValue = decValeCaja.ToString("F2") 'Solo dos decimales
                func.Exports("IM_MONTO_DPVL").ParamValue = decDPVale.ToString("F2") 'Solo dos decimales

                func.Execute()
                R3.Close()

                ' Obtenemos tabla Return
                dtResultado = func.Tables("PT_RETURN").ToADOTable


                ' Obtenemos documentos del reembolso
                Documentos.Add("E_BELNR_EFECTIVO", func.Imports("E_DOC_EFEC").ParamValue)
                Documentos.Add("E_BELNR_VALECJA", func.Imports("E_DOC_VCJA").ParamValue)
                Documentos.Add("MENSAJE", "")

                ' Validamos mensajes de respuesta
                Dim strError As String = ""
                If dtResultado.Rows.Count > 0 Then
                    For Each oRow As DataRow In dtResultado.Rows
                        If CStr(oRow!TYPE).Trim = "E" Then
                            strError = strError & vbCrLf & CStr(oRow!Message)
                        End If
                    Next
                    Documentos("MENSAJE") = strError
                End If

                ' Adaptamos respuesta para funcionalidad posterior
                result.Add("SapZshReembolso", Documentos)
                result.Add("MENSAJE", strError)

                Return result

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function


#End Region

#Region "Descuentos Proxima Compra"

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 07/11/2013: Descuentos Proxima Compra
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZCDES_PROXIMACOMPRA_GET(ByVal Fecha As Date) As DataSet

        Dim T_DESCUENTOS, T_TIPOSVTA, T_FPAGO As DataTable
        Dim dsDPC As DataSet

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZCDES_PROXIMACOMPRA_GET      ******
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCDES_PROXIMACOMPRA_GET")

                func.Exports("FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")

                func.Execute()

                R3.Close()

                T_DESCUENTOS = func.Tables("T_DESCUENTOS").ToADOTable
                T_TIPOSVTA = func.Tables("T_TIPOSVTA").ToADOTable
                T_FPAGO = func.Tables("T_FPAGO").ToADOTable

                dsDPC = New DataSet("DescuentoProximaCompra")
                dsDPC.Tables.Add(T_DESCUENTOS)
                dsDPC.Tables.Add(T_TIPOSVTA)
                dsDPC.Tables.Add(T_FPAGO)

                Return dsDPC

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '-----------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA 08/11/2013: Genera cupon si existe promocion de descuento proxima compra
    '-----------------------------------------------------------------------------------------------------------------------------------------
    Friend Function ZCDES_PROXIMACOMPRA_CREADESCTO(ByVal Fecha As Date, ByVal ImporteFactura As Decimal, ByRef Mensaje As String) As Hashtable
        Dim Cupon As New Hashtable
        Dim strRes As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZCDES_PROXIMACOMPRA_CREADESCTO
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZCDES_PROXIMACOMPRA_CREADESCTO")

                func.Exports("I_FECHA").ParamValue = Format(Fecha, "yyyyMMdd").Trim
                func.Exports("I_SUCURSAL").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(3, "0")
                func.Exports("I_IMPORTEFACTURA").ParamValue = ImporteFactura

                func.Execute()
                R3.Close()

                Dim R_LinesI As ERPConnect.RFCStructure = func.Imports("E_CUPON").ToStructure()
                For Each row As ERPConnect.RFCTableColumn In R_LinesI.Columns
                    Cupon(row.Name) = R_LinesI.Item(row.Name)
                Next

                strRes = func.Imports("E_ERROR").ToString
                Mensaje = func.Imports("E_MENSAJE").ToString

                If strRes.Trim.ToUpper = "X" Then
                    Mensaje = "Ocurrio un error al actualizar el Pedido SH en SAP. " & Mensaje
                    Cupon = Nothing
                End If
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return Cupon

    End Function

#End Region

    '#Region "Captura Motivos de Rechazo DPVale"
    '    '---------------------------------------------------------------------------------------
    '    ' JNAVA 06/05/2014 - Se agrego lo correspondiente a la captura de motivos de rechazo
    '    '---------------------------------------------------------------------------------------
    '    Friend Function ZDPVL_GET_MOTIVOSRECHAZOS() As DataTable
    '        Dim dtResult As DataTable

    '        Try

    '            ''Set Licenses.
    '            Dim Lic As ERPConnectLIC.Lic
    '            Lic.SetLic()

    '            Dim R3 As New ERPConnect.R3Connection( _
    '                     oParent.SAPApplicationConfig.ApplicationServer, _
    '                     oParent.SAPApplicationConfig.System, _
    '                     oParent.SAPApplicationConfig.User, _
    '                     oParent.SAPApplicationConfig.Password, _
    '                     oParent.SAPApplicationConfig.Language, _
    '                     oParent.SAPApplicationConfig.Client)

    '            ' Si no se logro conectar con éxito, entonces sale de la rutina
    '            R3.Open()
    '            If R3.Ping = False Then
    '                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '                Exit Function
    '            Else
    '                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_GET_MOTIVOSRECHAZOS")
    '                func.Execute()
    '                R3.Close()
    '                dtResult = func.Tables("T_MOTIVO").ToADOTable
    '            End If

    '        Catch e1 As ERPConnect.RFCServerException
    '            Throw e1
    '        Catch e1 As ERPConnect.ERPException
    '            Throw e1
    '        End Try

    '        Return dtResult
    '    End Function

    Friend Function ZDPVL_REGISTRAR_RECHAZO(ByVal NumVale As String, ByVal ClaveMotivo As String, ByVal Plaza As String, ByVal TipoVenta As String) As String
        Dim Result As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_REGISTRAR_RECHAZO")
                func.Exports("I_NUMVA").ParamValue = CStr(NumVale).PadLeft(10, "0")
                func.Exports("I_OFVTA").ParamValue = Plaza
                func.Exports("I_MOTIVO").ParamValue = ClaveMotivo
                func.Exports("I_TIPO").ParamValue = TipoVenta
                func.Execute()
                R3.Close()

                Dim MensajeError, strMsg As String

                Result = func.Imports("E_RESULTADO").ToString
                MensajeError = func.Imports("E_MENSAJE").ToString
                strMsg = "Ocurrió un error al intentar registrar los datos: " & MensajeError & ""

                If Result.Trim.ToUpper = "X" Then
                    MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al registrar el motivo del rechazo en SAP")
                End If
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return Result
    End Function

    '#End Region

#Region "Otros Pagos"

    Friend Function ZPOL_REGISTRO_PAGO(ByVal oCabecera As Hashtable, ByVal dtDetalle As DataTable, ByRef strErrorMsg As String) As Boolean

        Dim bResult As Boolean = False

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZPOL_REGISTRO_PAGO           ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZPOL_REGISTRO_PAGO")

                Dim T_DETALLE As ERPConnect.RFCTable = func.Tables("T_DETALLE")
                Dim I_CABECERA As ERPConnect.RFCStructure = func.Exports("I_CABECERA").ToStructure
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow
                Dim Centro As String = oParent.Read_Centros

                With oCabecera
                    I_CABECERA("ORDEN") = !NoOrden
                    I_CABECERA("CANAL") = !Canal
                    I_CABECERA("PEDIDO") = !Pedido
                    I_CABECERA("REFERENCIA") = !Referencia
                    I_CABECERA("TOTAL") = !Importe
                    I_CABECERA("CENTRO") = Centro.Trim
                    I_CABECERA("STATUS") = !Status
                    I_CABECERA("USUARIO_SAP") = ""
                    I_CABECERA("VENDEDOR") = !Vendedor
                    I_CABECERA("FECHA") = Format(Now, "yyyyMMdd")
                    I_CABECERA("HORA") = Format(Now, "hhmmss")
                    I_CABECERA("WAERK") = !Moneda
                    If oCabecera.ContainsKey("Tipo") = True Then
                        I_CABECERA("Tipo") = !Tipo
                    End If
                End With

                For Each oRow In dtDetalle.Rows
                    R_Lines = T_DETALLE.AddRow
                    R_Lines("ORDEN") = CStr(oRow!NoOrden).Trim
                    R_Lines("REFERENCIA") = CStr(oRow!Referencia).Trim 'JNAVA (19.02.2015): Se agrego Referencia
                    R_Lines("FORMA_PAGO") = CStr(oRow!FormaPago).Trim
                    R_Lines("IMPORTE") = CStr(oRow!Importe).Trim
                    R_Lines("PARCIALIDADES") = ""
                    R_Lines("NUM_APROB") = CStr(oRow!NoAutorizacion).Trim
                Next

                func.Execute()

                R3.Close()

                strErrorMsg = func.Imports("E_ERROR").ToString

                If strErrorMsg.Trim = "" Then bResult = True

                Return bResult

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Venta de Electronicos"

    '---------------------------------------------------------------------------------------
    ' JNAVA 05/12/2014 - Se agrego lo correspondiente a las Ventas de Electronicos
    '---------------------------------------------------------------------------------------

    Friend Function ZDPT_GUARDAR_VENTAS_ELEC(ByVal TablaElectronicos As DataTable) As String

        Dim ErrorSAP As String = String.Empty

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZDPT_GUARDAR_VENTAS_ELEC     ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPT_GUARDAR_VENTAS_ELEC")

                Dim T_ELECTRONICOS As ERPConnect.RFCTable = func.Tables("T_ELECTRONICOS")
                Dim R_Lines As ERPConnect.RFCStructure
                Dim oRow As DataRow
                Dim Centro As String = oParent.Read_Centros

                For Each oRow In TablaElectronicos.Rows
                    R_Lines = T_ELECTRONICOS.AddRow
                    R_Lines("MATERIAL") = CStr(oRow!Material).Trim
                    R_Lines("NUMSERIE") = CStr(oRow!NumSerie).Trim
                    R_Lines("IMEI") = CStr(oRow!IMEI).Trim
                    '--------------------------------------------------------------------------
                    ' JNAVA (22.02.2016): se envia referencia en ves de factura (retail)
                    '--------------------------------------------------------------------------
                    'R_Lines("FACTURA") = CStr(oRow!Factura).Trim
                    R_Lines("BSTNK") = CStr(oRow!Factura).Trim
                    '--------------------------------------------------------------------------
                    R_Lines("DPVALE") = CStr(oRow!DPVale).Trim
                    R_Lines("FPAGO") = CStr(oRow!FormaPago).Trim
                Next

                func.Execute()

                R3.Close()

                ErrorSAP = func.Imports("E_ERROR").ToString

                Return ErrorSAP

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

#End Region

#Region "Entrega de Mercancias de proveedor"

    Public Function ZMM_ORDENCOMPRA_DETALLE(ByVal orden As String) As DataTable
        Dim data As DataTable = Nothing
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIMM14_DESBLOQUEOART         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_ORDENCOMPRA_DETALLE")
                func.Exports("I_EBELN").ParamValue = orden
                func.Execute()
                R3.Close()

                data = func.Tables("T_ORDEN_DETALLE").ToADOTable()

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return data
    End Function

    Public Function ZMM_ENTREGA_TIENDA(ByVal orden As String, ByVal AlmacenOrigen As String, ByVal AlmacenDestino As String, ByVal dtTraspaso As DataTable, ByRef documentYear As String, ByRef err As String) As String
        Dim referencia As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPIMM14_DESBLOQUEOART         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMM_ENTREGA_TIENDA")
                func.Exports("I_EBELN").ParamValue = orden
                func.Exports("I_CENTRO_ORIGEN").ParamValue = AlmacenOrigen
                func.Exports("I_CENTRO_DESTINO").ParamValue = AlmacenDestino
                func.Exports("I_FECHA").ParamValue = MSS_GET_SY_DATE_TIME().ToString("dd.MM.yyyy")
                func.Exports("I_ALMACEN_DESTINO").ParamValue = AlmacenDestino
                Dim T_PEDIDO As ERPConnect.RFCTable = func.Tables("T_PEDIDO")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In dtTraspaso.Rows
                    If CInt(row("Lecturado")) > 0 Then
                        R_Lines = T_PEDIDO.AddRow()
                        R_Lines("EBELP") = CStr(row!EBELP)
                        R_Lines("MATNR") = CStr(row!MATNR)
                        If CInt(row("Lecturado")) > CInt(row("QUANTITY")) Then
                            R_Lines("MENGE") = CStr(row("QUANTITY"))
                        Else
                            R_Lines("MENGE") = CStr(row("Lecturado"))
                        End If
                        R_Lines("J_3ASIZE") = CStr(row!J_3ASIZE)
                        R_Lines("ETENR") = CStr(row!ETENR)
                    End If
                Next
                func.Execute()
                R3.Close()

                referencia = CStr(func.Imports("E_MATERIALDOCUMENT").ParamValue)
                documentYear = CStr(func.Imports("E_MATDOCUMENTYEAR").ParamValue)
                Dim dtReturn As DataTable = func.Tables("T_RETURN").ToADOTable()
                Dim dtmesstab As DataTable = func.Tables("T_MESSTAB").ToADOTable()
                If dtReturn.Rows.Count > 0 Then
                    For Each row As DataRow In dtReturn.Rows
                        err &= CStr(row("MESSAGE"))
                    Next
                End If

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return referencia
    End Function

#End Region

#Region "Retail"

    Public Function ZSD_OBTENER_CORREO_OFI_VENTA(ByVal OficinaVtas As String) As String
        Dim strCorreo As String
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSD_OBTENER_CORREO_OFI_VENTA
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSD_OBTENER_CORREO_OFI_VENTA")

                'Asigno valores
                func.Exports("OFICINA_VENTA").ParamValue = OficinaVtas

                'Ejecutamos la RFC
                func.Execute()
                R3.Close()

                strCorreo = func.Imports("CORREO").ParamValue



            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return strCorreo
    End Function

    Friend Function ZFMCOM_ACLARACION(ByVal strFolio As String, ByVal dvDetalle As DataView, ByVal strTipo As String) As DataTable

        Dim strCentro As String = oParent.Read_Centros()
        Dim dtReturn As New DataTable

        Try

            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZFMCOM_ACLARACION               ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZFMCOM_ACLARACION")
                ' Asigno valores a los objetos

                If dvDetalle.Count > 0 Then
                    Dim T_Traslado As ERPConnect.RFCTable = func.Tables("PT_INPUT_DATA")
                    Dim R_Lines As ERPConnect.RFCStructure
                    For Each oRow As DataRowView In dvDetalle
                        R_Lines = T_Traslado.AddRow
                        If strTipo = "E" Then
                            R_Lines("ID_PR_AC") = CStr(oRow!ID_PR_AC)
                        End If
                        R_Lines("CENTRO") = strCentro
                        R_Lines("MATERIAL") = CStr(oRow!Codigo)
                        R_Lines("IDMOTIVO") = "01"
                        R_Lines("TALLA") = CStr(oRow!Talla)
                        R_Lines("ALMACEN") = "M001"
                        R_Lines("MOTIVODES") = "Traspaso Incompleto"
                        R_Lines("CANTIDAD") = CInt(oRow("cantidad")) - CInt(oRow("lecturado"))
                        R_Lines("TRASPASO") = strFolio
                        R_Lines("TIPOM") = strTipo
                    Next
                End If

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                dtReturn = func.Tables("PT_OUTPUT_DATA").ToADOTable

                Return dtReturn

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZFM_COMMX001_DPRO(ByVal strpedido As String, ByVal dtMateriales As DataTable, ByRef strMensaje As String, ByVal RecibirParcialmente As Boolean, Optional ByRef DocMaterial As String = "") As String
        '----------------------------------------------------------------------------------
        ' JNAVA (15.02.2016): Se agrego para hacer traslados
        '----------------------------------------------------------------------------------
        Dim strCentroDestino As String = oParent.Read_Centros()

        ' Se definen los parámetros TABLE            
        Dim dtReturn As New DataTable
        Dim StrNUMPEDMB01 As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC functionZFM_COMMX001_DPRO               ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZFM_COMMX001_DPRO")

                ' Asigno valores a los objetos
                func.Exports("PI_EBELN").ParamValue = strpedido
                func.Exports("PI_WERKS").ParamValue = strCentroDestino
                func.Exports("PI_CONTABILIZAR").ParamValue = "X"
                func.Exports("PI_LGORT").ParamValue = "M001"
                If RecibirParcialmente Then
                    Dim i As Integer = 10
                    If dtMateriales.Rows.Count > 0 Then
                        Dim T_Traslado As ERPConnect.RFCTable = func.Tables("TI_MATERIALES")
                        Dim R_Lines As ERPConnect.RFCStructure
                        For Each oRow As DataRow In dtMateriales.Rows
                            R_Lines = T_Traslado.AddRow
                            R_Lines("MATNR") = CStr(oRow!Codigo)
                            R_Lines("PIKMG") = CInt(oRow!Cantidad)
                            If IsDBNull(oRow("SERIE")) = False Then
                                R_Lines("SERNR") = CStr(oRow("Serie"))
                            Else
                                R_Lines("SERNR") = ""
                            End If
                            R_Lines("EBELP") = CStr(i).PadLeft(5, "0") 'CStr(oRow!EBELP)
                            i += 10
                        Next
                    End If
                Else
                    '---------------------------------------------------------------------------------------------------------------
                    ' JNAVA (18.05.2018): Validamos si hay materiales con seria para mandar el detalle de esos materiales
                    '---------------------------------------------------------------------------------------------------------------
                    If dtMateriales.Rows.Count > 0 Then
                        Dim i As Integer = 10
                        Dim T_Traslado As ERPConnect.RFCTable = func.Tables("TI_MATERIALES")
                        Dim R_Lines As ERPConnect.RFCStructure
                        For Each oRow As DataRow In dtMateriales.Rows
                            If IsDBNull(oRow("SERIE")) = False OrElse oRow("SERIE").ToString <> "" Then
                                R_Lines = T_Traslado.AddRow
                                R_Lines("MATNR") = CStr(oRow!Codigo)
                                R_Lines("PIKMG") = CInt(oRow!Cantidad)
                                R_Lines("SERNR") = CStr(oRow("Serie"))
                                R_Lines("EBELP") = CStr(i).PadLeft(5, "0")
                                i += 10
                            End If
                        Next
                    End If
                    '---------------------------------------------------------------------------------------------------------------
                End If

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                dtReturn = func.Tables("TI_RETURN").ToADOTable
                StrNUMPEDMB01 = func.Imports("PE_VBELN").ParamValue.ToString.Trim
                DocMaterial = CStr(func.Imports("PE_MBLNR").ParamValue)
                If StrNUMPEDMB01.Trim = String.Empty Then 'me traigo los campos
                    strMensaje = ""
                    strMensaje = "Pedido: " & strpedido & ", Centro Destino: " & strCentroDestino & vbCrLf
                    For Each oRow As DataRow In dtReturn.Rows
                        strMensaje &= oRow!MSGV1 & vbCrLf
                    Next
                End If

            End If

            Return StrNUMPEDMB01.Trim

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Friend Function ZBAPISD29_CANCELACIONFACT_AUTO(ByVal FolioSAP As String, ByVal CodVendedor As String, ByRef SalesDocument As String, ByRef FIDocument As String) As String
        ' Se definen los parámetros TABLE            
        Dim dtReturn As DataTable, strMensaje As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD29_CANCELACIONFACT_AUTO  ***
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD29_CANCELACIONFACT_AUTO")

                ' Asigno valores a los objetos
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("I_FACTURA").ParamValue = FolioSAP.Trim
                func.Exports("I_MODE").ParamValue = "N"
                func.Exports("I_AGENTE").ParamValue = CodVendedor.Trim
                func.Exports("I_WERKS").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")
                'func.Exports("I_DPCARD").ParamValue = FolioFISAP.Trim

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                SalesDocument = func.Imports("SALESDOCUMENT").ParamValue.ToString.Trim
                FIDocument = func.Imports("FIDOCUMENT").ParamValue.ToString.Trim

                dtReturn = func.Tables("RETURN").ToADOTable
                strMensaje = ""
                For Each oRow As DataRow In dtReturn.Rows
                    strMensaje &= oRow!MESSAGE & vbCrLf
                Next
                'If SalesDocument.Trim = String.Empty Then 'me traigo los campos
                '    strMensaje = ""
                '    For Each oRow As DataRow In dtReturn.Rows
                '        strMensaje &= oRow!MESSAGE & vbCrLf
                '    Next
                'End If
            End If

            Return strMensaje.Trim

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Friend Function ZBAPISD29_CANCELACION_DPVL_AUT(ByVal FolioSAP As String, ByVal CodVendedor As String, FolioFISAP As String, Optional ByRef strError As String = "") As String
        ' Se definen los parámetros TABLE            
        Dim strSalesDocument As String = "", strFiDocument As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD29_CANCELACION_DPVL_AUT  ***
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD29_CANCELACION_DPVL_AUT")

                ' Asigno valores a los objetos
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("I_FACTURA").ParamValue = FolioSAP.Trim
                func.Exports("I_MODE").ParamValue = "N"
                func.Exports("I_AGENTE").ParamValue = CodVendedor.Trim
                func.Exports("I_WERKS").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")
                func.Exports("I_FACT_SH").ParamValue = FolioFISAP.Trim

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                strSalesDocument = func.Imports("SALESDOCUMENT").ParamValue.ToString.Trim
                strFiDocument = func.Imports("FIDOCUMENT").ParamValue.ToString.Trim
                Dim dtReturn As DataTable = func.Tables("TRETURN").ToADOTable()
                For Each row As DataRow In dtReturn.Rows
                    strError &= CStr(row("MESSAGE"))
                Next
            End If

            Return strSalesDocument.Trim

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Friend Function ZMF_TALLA_COLOR(ByVal Materiales As DataTable) As DataTable
        '----------------------------------------------------------------------------------
        ' JNAVA (15.04.2016): Se agrego para obtener las tallas de una lista de materiales
        '----------------------------------------------------------------------------------
        Dim strCentroDestino As String = oParent.Read_Centros()

        ' Se definen los parámetros TABLE            
        Dim dtMateriales As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMF_TALLA_COLOR               ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMF_TALLA_COLOR_COPY")

                ' Asigno valores a los objetos
                Dim T_Traslado As ERPConnect.RFCTable = func.Tables.Item("T_MATERIALES")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each oRow As DataRow In Materiales.Rows
                    R_Lines = T_Traslado.AddRow
                    R_Lines("MATNR") = oRow("Material")
                Next

                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                dtMateriales = func.Tables("T_MATERIALES").ToADOTable

            End If

            Return dtMateriales

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Public Function ZSD_VALIDA_PEDIDOS(ByVal FechaCierre As DateTime) As DataTable
        Dim dtFacturas As New DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMF_TALLA_COLOR               ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSD_VALIDA_PEDIDOS")
                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_ERDAT").ParamValue = FechaCierre.ToString("yyyyMMdd")
                func.Exports("I_CON_VALE").ParamValue = "X"
                func.Execute()
                dtFacturas = func.Tables("T_PEDIDOS").ToADOTable()
                R3.Close()

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return dtFacturas
    End Function

    Public Function ZSD_VALIDA_PEDIDOS(ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Dim dtFacturas As New DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZMF_TALLA_COLOR               ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSD_VALIDA_PEDIDOS")
                func.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_ERDAT").ParamValue = FechaInicio.ToString("yyyyMMdd")
                func.Exports("I_ERDAT_FIN").ParamValue = FechaFin.ToString("yyyyMMdd")
                func.Exports("I_CON_VALE").ParamValue = "X"
                func.Execute()
                dtFacturas = func.Tables("T_PEDIDOS").ToADOTable()
                R3.Close()

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return dtFacturas
    End Function



#End Region

#Region "DPVale AFS"

    '--------------------------------------------------------------------
    ' JNAVA (14.04.2016): Funciones de DPVale Apuntando a AFS
    '--------------------------------------------------------------------
    Friend Function ZBAPI_VALIDA_DPVALE(ByVal cdpvale As cDPVale) As cDPVale

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_DPVALE")

                func.Exports("INUMVA").ParamValue = cdpvale.INUMVA
                If cdpvale.I_RUTA.Trim = String.Empty Then
                    func.Exports("I_RUTA").ParamValue = "X"
                Else
                    func.Exports("I_RUTA").ParamValue = cdpvale.I_RUTA
                End If

                func.Execute()
                R3.Close()

                cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable

                cdpvale.EEXIST = func.Imports("EEXIST").ToString
                cdpvale.ESTATU = func.Imports("ESTATU").ToString
                cdpvale.EPLAZA = func.Imports("EPLAZA").ToString
                cdpvale.LimiteCredito = CDec(func.Imports("ELCREDITO").ToString)
                cdpvale.Congelado = func.Imports("Congelado").ToString
                cdpvale.LimiteCreditoPrestamo = CDec(func.Imports("ECREDITOP").ToString)
                cdpvale.FlagPrestamo = func.Imports("EPRESTAMO").ToString


                Return cdpvale

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_NOMBRE_CLIENTE(ByVal strNumAsociado As String) As String

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_NOMBRE_CLIENTE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_NOMBRE_CLIENTE")

                func.Exports("I_KUNNR").ParamValue = strNumAsociado

                func.Execute()

                R3.Close()

                If func.Imports("E_EXIST").ToString = "S" Then
                    Return func.Imports("E_NOMBRE").ToString
                Else
                    Return String.Empty
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_OBTENER_NDESCUENTOS(ByVal plaza As String, ByVal fecha As Date, ByVal monto As Decimal, ByVal strVale As String, _
                                          ByRef FechaCobro As Date, ByRef dtDetalle As DataTable) As Integer

        Try
            Dim intNumPeriodos As Integer
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_OBTENER_NDESCUENTOS
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_OBTENER_NDESCUENTOS")
                Dim strFecha As String = ""

                'func.Exports("IPLAZA").ParamValue = plaza
                func.Exports("IPLAZA").ParamValue = oParent.SAPApplicationConfig.Plaza
                func.Exports("IFECHA").ParamValue = fecha.ToString("dd/MM/yyyy")
                func.Exports("IMONTO").ParamValue = monto.ToString
                func.Exports("I_VALE").ParamValue = strVale.PadLeft(10, "0")

                func.Execute()
                R3.Close()

                intNumPeriodos = CInt(func.Imports("ENPERIODO").ToString())
                strFecha = func.Imports("FECCO").ToString
                If strFecha.Trim <> "" AndAlso CLng(strFecha.Trim) > 0 Then
                    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                    FechaCobro = CDate(strFecha)
                Else
                    FechaCobro = Today
                End If
                dtDetalle = func.Tables("T_RESULTS").ToADOTable()


                Return intNumPeriodos

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function Valida_Clientes(ByVal strCliente As String, ByVal Todos As Boolean, ByRef Adeuda As Boolean) As String

        Dim dtClientes As DataTable
        Dim strMensaje, strResult As String
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD02_DGCLIENTES ******
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZVALIDA_COMPRADOR")

                func.Exports("I_KUNNR").ParamValue = strCliente
                func.Exports("I_TODOS").ParamValue = IIf(Todos, "X", "")

                func.Execute()
                R3.Close()

                dtClientes = func.Tables("T_TLINE").ToADOTable
                strResult = func.Imports("E_STATU").ToString


                Adeuda = IIf(func.Imports("E_ADEUDA").ToString.Trim = "X", True, False)

                If strResult = "X" Then
                    For Each oRow As DataRow In dtClientes.Rows
                        strMensaje = strMensaje & CStr(oRow("TDLINE")).ToString & Microsoft.VisualBasic.vbCrLf
                    Next

                    If strMensaje = String.Empty Then
                        strMensaje = "Cliente congelado"
                    End If
                Else
                    If strResult = "Z" Then
                        strMensaje = "DPVF "
                    Else
                        strMensaje = "TARJ "
                    End If
                    For Each oRow As DataRow In dtClientes.Rows
                        strMensaje = strMensaje & CStr(oRow("TDLINE")).ToString & Microsoft.VisualBasic.vbCrLf
                    Next
                End If

                Return strMensaje

            End If


        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function ZBAPI_GENERAR_REREVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByVal intPares As Integer, ByRef strResult As String, ByVal FolioCliente As String) As String

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_GENERAR_REREVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_GENERAR_REREVALE")

                func.Exports("I_MONTO").ParamValue = decMonto
                func.Exports("I_VALEOROGEN").ParamValue = strDPvaleID.PadLeft(10, "0")
                func.Exports("I_PARES").ParamValue = intPares.ToString
                '--------------------------------------------------------------
                ' JNAVA (12.08.2016): Se agrego parametro Cliente
                '--------------------------------------------------------------
                func.Exports("I_CLIENTE").ParamValue = FolioCliente.PadLeft(10, "0")
                '--------------------------------------------------------------

                func.Execute()

                R3.Close()

                strResult = func.Imports("E_RESULT").ToString

                Return func.Imports("E_REVALE").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    Friend Function Read_CreditoAsociadoSAP(ByVal IDAsociadoSAP As String) As CreditoAsociadoSAP
        '----------------------------------------------------------------------------------
        ' JNAVA (05.01.2016): Cambio de libreria para compatibilidad con SAP 6.0
        '----------------------------------------------------------------------------------
        Dim oResult As New CreditoAsociadoSAP
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_LIMITECREDITO     ****
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_LIMITECREDITO")

                'Captura de Info
                func.Exports("I_Kunnr").ParamValue = IDAsociadoSAP

                'Ejecutamos RFC
                func.Execute()
                R3.Close()

                'Obtenemos datos
                oResult.CodigoAsociadoSAP = IDAsociadoSAP
                oResult.LimiteCredito = func.Imports("LIMITE").ParamValue
                oResult.Credito = func.Imports("CREDITO").ParamValue
                oResult.Bloqueado = func.Imports("BLOQUEADO").ParamValue

            End If

        Catch e1 As ERPConnect.RFCServerException
            oResult.CodigoAsociadoSAP = String.Empty
            oResult.LimiteCredito = 0
            oResult.Credito = 0
            oResult.Bloqueado = "S"
        Catch e1 As ERPConnect.ERPException
            oResult.CodigoAsociadoSAP = String.Empty
            oResult.LimiteCredito = 0
            oResult.Credito = 0
            oResult.Bloqueado = "S"
        End Try

        Return oResult

    End Function

    Friend Function ZBAPI_VALIDA_REVALE(ByVal cdpvale As cDPVale) As cDPVale

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_REVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_REVALE")

                func.Exports("INUMVA").ParamValue = cdpvale.INUMVA

                func.Execute()
                R3.Close()

                cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable
                cdpvale.EEXIST = func.Imports("EEXIST").ToString

                Return cdpvale

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_GENERAR_REVALE(ByVal strDPvaleID As String, ByVal decMonto As Decimal, ByRef strResult As String) As String

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_GENERAR_REVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_GENERAR_REVALE")

                func.Exports("I_MONTO").ParamValue = decMonto
                func.Exports("I_VALEOROGEN").ParamValue = strDPvaleID.PadLeft(10, "0")

                func.Execute()

                R3.Close()

                strResult = func.Imports("E_RESULT").ToString

                Return func.Imports("E_REVALE").ToString

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_VALIDA_ReVale_Venta(ByVal cdpvale As cDPVale) As cDPVale

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_REVALE_VENTA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_VALIDA_REVALE_VENTA")

                func.Exports("INUMVA").ParamValue = cdpvale.INUMVA

                func.Execute()
                R3.Close()

                cdpvale.InfoDPVALE = func.Tables("T_DP_VALE").ToADOTable

                Return cdpvale

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_DATOS_CLIENTE(ByVal strNumAsociado As String, TipoCliente As Integer) As String()

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_DATOS_CLIENTE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_DATOS_CLIENTE")

                func.Exports("I_KUNNR").ParamValue = strNumAsociado
                func.Exports("I_TIPO_CLIENTE").ParamValue = CStr(TipoCliente)

                func.Execute()

                R3.Close()

                Dim info(4) As String

                If func.Imports("E_EXIST").ToString = "S" Then
                    info(0) = func.Imports("E_EXIST").ToString
                    info(1) = func.Imports("E_NOMBRE").ToString
                    info(2) = func.Imports("E_DOMICILIO").ToString
                    info(3) = func.Imports("E_TELEFONO").ToString
                    Return info
                Else
                    Return info
                End If

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

#Region "Captura Motivos de Rechazo DPVale"
    '---------------------------------------------------------------------------------------
    ' JNAVA 06/05/2014 - Se agrego lo correspondiente a la captura de motivos de rechazo
    '---------------------------------------------------------------------------------------
    Friend Function ZDPVL_GET_MOTIVOSRECHAZOS() As DataTable
        Dim dtResult As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_GET_MOTIVOSRECHAZOS")
                func.Execute()
                R3.Close()
                dtResult = func.Tables("T_MOTIVO").ToADOTable
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResult
    End Function

    'Friend Function ZDPVL_REGISTRAR_RECHAZO(ByVal NumVale As String, ByVal ClaveMotivo As String, ByVal Plaza As String, ByVal TipoVenta As String) As String
    '    Dim Result As String

    '    Try

    '        ''Set Licenses.
    '        Dim Lic As ERPConnectLIC.Lic
    '        Lic.SetLic()

    '        Dim R3 As New ERPConnect.R3Connection( _
    '                 oParent.SAPApplicationConfig.ApplicationServerDPVale, _
    '                 oParent.SAPApplicationConfig.SystemDPVale, _
    '                 oParent.SAPApplicationConfig.UserDPVale, _
    '                 oParent.SAPApplicationConfig.PasswordDPVale, _
    '                 oParent.SAPApplicationConfig.LanguageDPVale, _
    '                 oParent.SAPApplicationConfig.ClientDPVale)


    '        ' Si no se logro conectar con éxito, entonces sale de la rutina
    '        R3.Open()
    '        If R3.Ping = False Then
    '            MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
    '            Exit Function
    '        Else
    '            Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_REGISTRAR_RECHAZO")
    '            func.Exports("I_NUMVA").ParamValue = CStr(NumVale).PadLeft(10, "0")
    '            func.Exports("I_OFVTA").ParamValue = Plaza
    '            func.Exports("I_MOTIVO").ParamValue = ClaveMotivo
    '            func.Exports("I_TIPO").ParamValue = TipoVenta
    '            func.Execute()
    '            R3.Close()

    '            Dim MensajeError, strMsg As String

    '            Result = func.Imports("E_RESULTADO").ToString
    '            MensajeError = func.Imports("E_MENSAJE").ToString
    '            strMsg = "Ocurrió un error al intentar registrar los datos: " & MensajeError & ""

    '            If Result.Trim.ToUpper = "X" Then
    '                MsgBox(strMsg, MsgBoxStyle.Exclamation, "Error al registrar el motivo del rechazo en SAP")
    '            End If
    '        End If

    '    Catch e1 As ERPConnect.RFCServerException
    '        Throw e1
    '    Catch e1 As ERPConnect.ERPException
    '        Throw e1
    '    End Try

    '    Return Result
    'End Function

#End Region

    Friend Function ZBAPI_OBTENER_CLIENTES_DPVALE(ByVal strPalabraFind As String) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_OBTENER_CLIENTES
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_OBTENER_CLIENTES")

                func.Exports("I_NOMBRE1").ParamValue = strPalabraFind

                func.Execute()

                R3.Close()

                Return func.Tables("TZCOMPRADORES").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPI_GET_CLIENTE_DPVALE(ByVal strCodAsociado As String) As DataTable

        Dim dtResultado As DataTable

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZBAPI_SELECTCLIENTEBYID
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPI_SELECTCLIENTEBYID")

                func.Exports("I_CODCLIENTE").ParamValue = strCodAsociado.PadLeft(10, "0")
                func.Exports("I_VKORG").ParamValue = "CDPT"
                func.Exports("I_VTWEG").ParamValue = "T1"
                func.Exports("I_SPART").ParamValue = "VG"

                func.Execute()

                R3.Close()

                dtResultado = func.Tables("DATOSCLIENTE").ToADOTable

                Return dtResultado

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try


    End Function

    Friend Function ZBAPISD29_CANCELACION_DPVL_AUTAFS(ByVal FolioSAP As String, ByVal CodVendedor As String, FolioFISAP As String, ByVal EntregaDev As String) As String
        ' Se definen los parámetros TABLE            
        Dim strSalesDocument As String = "", strFiDocument As String = ""

        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZBAPISD29_CANCELACION_DPVL_AUT  ***
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD29_CANCELACION_DPVL_AUT")

                ' Asigno valores a los objetos
                func.Exports("CLASEPEDIDO").ParamValue = "ZDEV"
                func.Exports("I_FACTURA").ParamValue = FolioSAP.Trim
                func.Exports("I_MODE").ParamValue = "N"
                func.Exports("I_AGENTE").ParamValue = CodVendedor.Trim
                func.Exports("I_WERKS").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0")
                func.Exports("I_FACT_SH").ParamValue = FolioFISAP.Trim
                func.Exports("I_ENTREGA_DEV").ParamValue = EntregaDev
                'Ejecutamos RFC
                func.Execute()

                R3.Close()

                'Obtenemos datos
                strSalesDocument = func.Imports("SALESDOCUMENT").ParamValue.ToString.Trim
                strFiDocument = func.Imports("FIDOCUMENT").ParamValue.ToString.Trim

            End If

            Return strSalesDocument.Trim

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Function

    Public Function ZDPVL_VALSEGUROSAFS(ByVal DatoSeguro As Hashtable) As Boolean
        Dim valido As Boolean = False
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZDPVL_VALSEGUROS                ***
                '*****************************************************
                ' Create a function object
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZDPVL_VALSEGUROS")
                func.Exports("I_NUMVA").ParamValue = CStr(DatoSeguro("I_NUMVA"))
                func.Exports("I_KUNNR").ParamValue = CStr(DatoSeguro("I_KUNNR"))
                func.Exports("I_ZSEG").ParamValue = CStr(DatoSeguro("I_ZSEG"))
                func.Exports("I_FECCO").ParamValue = CStr(DatoSeguro("I_FECCO"))
                func.Exports("I_NUMDE").ParamValue = CStr(DatoSeguro("I_NUMDE"))
                func.Execute()
                R3.Close()
                Dim seguro As String = CStr(func.Imports("E_SEG").ParamValue)
                If seguro.Trim() = "1" Then
                    valido = True
                Else
                    valido = False
                End If

            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return valido
    End Function

    Friend Function ZRFCDPVL_FACTURAS_X_VALE(ByRef Fecha As Date) As DataTable

        Dim dtResultado As DataTable
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)
            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZRFCDPVL_FACTURAS_X_VALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZRFCDPVL_FACTURAS_X_VALE")

                func.Exports("I_OFVTA").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen
                func.Exports("I_FECHADIA").ParamValue = Format(Fecha, "yyyyMMdd")

                func.Execute()
                R3.Close()

                dtResultado = func.Tables("T_VALES").ToADOTable

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

        Return dtResultado

    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 30/05/2016: Se realizo el reembolso para el vale servidor SAP AFS
    '-------------------------------------------------------------------------------------------------------------------------------------

    Friend Function ZSH_REEMBOLSOAFS(ByVal strFolioPedido As String, ByVal strCliente As String, ByVal strAlmacen As String, ByVal decValeCaja As Decimal, ByVal decEfectivo As Decimal, ByVal strDivision As String, ByVal strTipo As String, ByVal ActualizarSiHay As String, ByVal strFolioSapFactura As String, ByVal decDPVale As Decimal, ByVal bRevale As Boolean) As Hashtable
        '---------------------------------------------------------------------------------------------------------------------------------------------
        'JNAVA (22/05/2013) - RFC para reembolso en SAP
        '---------------------------------------------------------------------------------------------------------------------------------------------
        Dim dtResultado As DataTable
        Dim strCentro As String
        Dim strMensaje As String
        Dim FolioDocumentos As New Hashtable
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_REEMBOLSO
                '*****************************************************
                ' Create a function object

                '----------------Numero de Referencia---------------
                Dim numref As New NumeroReferencia.cNumReferencia
                Dim strNumRef As String = numref.getNumReferencia(oParent.ApplicationContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), CStr(Format(Now.Date.Date, "ddMMyyyy")))
                '------------------------------------------------------
                strCentro = oParent.Read_Centros()

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_REEMBOLSO")

                'Asigno valores
                func.Exports("I_TIPO").ParamValue = strTipo
                func.Exports("I_PEDIDO").ParamValue = strFolioPedido
                func.Exports("I_FACTURA").ParamValue = strFolioSapFactura.Trim.PadLeft(10, "0")
                func.Exports("I_CENTRO").ParamValue = strCentro
                func.Exports("I_KUNNR").ParamValue = strCliente
                func.Exports("I_IMPORTE_EFECTIVO").ParamValue = decEfectivo.ToString("F2") 'Solo dos decimales
                func.Exports("I_IMPORTE_VALECJA").ParamValue = decValeCaja.ToString("F2") 'Solo dos decimales
                func.Exports("I_GSBER").ParamValue = strDivision
                func.Exports("I_TIENDA").ParamValue = strAlmacen
                func.Exports("I_REFERENCIA").ParamValue = strNumRef
                func.Exports("I_MODO").ParamValue = "N"
                func.Exports("I_ACTUALIZASH").ParamValue = ActualizarSiHay

                '---------------------------------------------------------------------------------------------------------------------------------------------
                'JNAVA (28/10/2014) - Nuevos Parametros para reembolso con formas de pago de DPVale
                '---------------------------------------------------------------------------------------------------------------------------------------------
                func.Exports("I_IMPORTE_DPVL").ParamValue = decDPVale.ToString("F2") 'Solo dos decimales
                func.Exports("I_REVALE").ParamValue = IIf(bRevale, "X", "")
                '---------------------------------------------------------------------------------------------------------------------------------------------

                'QUITAR!!!
                'func.Exports("I_ROLLBACK").ParamValue = "X"
                'QUITAR!!!

                func.Execute()
                R3.Close()

                dtResultado = func.Tables("T_RETURN").ToADOTable

                FolioDocumentos("E_BELNR_EFECTIVO") = func.Imports("E_BELNR_EFECTIVO").ParamValue
                FolioDocumentos("E_BELNR_VALECJA") = func.Imports("E_BELNR_VALECJA").ParamValue
                FolioDocumentos("MENSAJE") = ""

                If dtResultado.Rows.Count > 0 Then
                    Dim strError As String = ""
                    For Each oRow As DataRow In dtResultado.Rows
                        strError = strError & vbCrLf & CStr(oRow!Message)
                    Next
                    FolioDocumentos("MENSAJE") = strError
                End If

                Return FolioDocumentos

            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Function

    '-------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 27/07/2016: Actualiza el status del vale despues de la primera factura
    '-------------------------------------------------------------------------------------------------------------------------------------

    Public Function ActualizaStatusDPValeAFS(ByVal vale As String, ByRef mensaje As String) As String
        Dim strRes As String = ""
        Try
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZSH_ACTUALIZA_VALE
                '*****************************************************
                ' Create a function object

                '----------------Numero de Referencia---------------


                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSH_ACTUALIZA_VALE")
                func.Exports("I_NUMVA").ParamValue = vale

                func.Execute()
                R3.Close()

                strRes = CStr(func.Imports("E_RETURN").ParamValue)
                mensaje = CStr(func.Imports("E_MENSAJE").ParamValue)


            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return strRes
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 01/08/2016: Se realiza la cancelación parcial del si hay para la factura DPVale
    '------------------------------------------------------------------------------------------------------------------------------------------

    Public Sub CancelacionFacturaDPValeSHAFS(ByVal params As Dictionary(Of String, Object))
        Try
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServerDPVale, _
                     oParent.SAPApplicationConfig.SystemDPVale, _
                     oParent.SAPApplicationConfig.UserDPVale, _
                     oParent.SAPApplicationConfig.PasswordDPVale, _
                     oParent.SAPApplicationConfig.LanguageDPVale, _
                     oParent.SAPApplicationConfig.ClientDPVale)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZBAPI_VALIDA_DPVALE
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZBAPISD17_DEV_VENTAS_DPVL")
                'If FolioPedido.Trim <> "" Then
                '    func.Exports("I_FOLIOPEDIDO").ParamValue = FolioPedido.Trim
                'End If
                func.Exports("I_MONDPVL").ParamValue = CDec(params("MontoDPVL"))
                func.Exports("CLASEPEDIDO").ParamValue = "Z" & Mid(CStr(params("Almacen")), 2, 2) & "3"
                func.Exports("OFICINAVTA").ParamValue = "T" & CStr(params("Almacen"))
                func.Exports("I_Fecha").ParamValue = Format(CDate(params("Fecha")), "dd/MM/yyyy")
                func.Exports("I_AGENTE").ParamValue = CStr(params("CodVendedor"))
                func.Exports("I_WERKS").ParamValue = "T" & CStr(params("Almacen"))
                func.Exports("I_CREDITO").ParamValue = "N"
                func.Exports("I_KUNNR").ParamValue = CStr(params("Kunnr"))
                func.Exports("I_ZONAVTA").ParamValue = "EFEC"
                func.Exports("I_FACTURA").ParamValue = CStr(params("Referencia"))
                func.Exports("I_KEYPRO").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen & _
                oParent.ApplicationContext.ApplicationConfiguration.NoCaja
                func.Execute()
                R3.Close()
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/11/2016: Valida si hay pedidos pendientes por cerrar
    '------------------------------------------------------------------------------------------------------------------------------------------

    Public Function ZSD_VALIDA_INICIODIA(ByVal OficinaVta As String) As String
        Dim e_error As String = ""
        Try
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function ZSD_VALIDA_INICIODIA
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZSD_VALIDA_INICIODIA")
                func.Exports("I_OFICINA_VENTAS").ParamValue = "T" & OficinaVta
                func.Execute()
                e_error = CStr(func.Imports("E_ERROR").ParamValue)
                R3.Close()
            End If
        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try
        Return e_error
    End Function

#End Region

#Region "Esquemas de RFC SAP"

    Friend Sub ZCS_ALGORITMO_PROMOS_LOAD_ESQUEMA()
        Try

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)

            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Sub
            Else
                '*****************************************************
                'Call RFC function ZCS_ALGORITMO_PROMOS         ******
                '*****************************************************
                ' Create a function object

                oParent.funcEsquema = R3.CreateFunction("ZCS_ALGORITMO_PROMOS")

                '--------------------------------------------
                ' JNAVA (15.12.2017): Cerramos conexion a SAP
                '--------------------------------------------
                R3.Close()
                '--------------------------------------------
            End If

        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub

    Friend Sub ZCS_ALGORITMO_PROMOS_GETDATA(ByVal dtMateriales As DataTable, ByVal TipoVenta As String, ByVal Fecha As Date, ByRef htTotales As Hashtable, _
    ByRef dtMatDesc As DataTable, ByRef dtPromos As DataTable, ByRef dtCrossSelling As DataTable)
        Try
            dtPromos = Nothing
            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            '--------------------------------------------------------------------------
            ' JNAVA (07.12.2017): Limpiamos tablas y parametros del esquema precargado
            '--------------------------------------------------------------------------
            oParent.funcEsquema.Tables("T_MATERIALES").Clear()
            oParent.funcEsquema.Tables("T_TVENTA").Clear()
            oParent.funcEsquema.Exports("I_VKBUR").ParamValue = String.Empty
            oParent.funcEsquema.Exports("I_FECHA").ParamValue = String.Empty
            oParent.funcEsquema.Exports("I_CANAL").ParamValue = String.Empty
            oParent.funcEsquema.Exports("I_VIGENTES").ParamValue = String.Empty
            oParent.funcEsquema.Exports("I_CROSS_SELLING").ParamValue = String.Empty
            '--------------------------------------------------------------------------

            '*****************************************************
            'Call RFC function ZCS_ALGORITMO_PROMOS         ******
            '*****************************************************
            Dim T_MATERIALES As ERPConnect.RFCTable = oParent.funcEsquema.Tables("T_MATERIALES")
            Dim T_TVENTA As ERPConnect.RFCTable = oParent.funcEsquema.Tables("T_TVENTA")
            Dim R_Lines As ERPConnect.RFCStructure
            Dim oRow As DataRow

            For Each oRow In dtMateriales.Rows
                R_Lines = T_MATERIALES.AddRow
                R_Lines("MATERIAL") = CStr(oRow!Codigo).Trim.PadLeft(18, "0")
                R_Lines("TALLA") = oRow!Talla
                R_Lines("CANTIDAD") = oRow!Cantidad
            Next

            R_Lines = T_TVENTA.AddRow
            R_Lines("SIGN") = ""
            R_Lines("OPTION") = ""
            R_Lines("LOW") = TipoVenta
            R_Lines("HIGH") = ""
            'Next

            oParent.funcEsquema.Exports("I_VKBUR").ParamValue = "T" & oParent.ApplicationContext.ApplicationConfiguration.Almacen.Trim
            oParent.funcEsquema.Exports("I_FECHA").ParamValue = Format(Fecha, "yyyyMMdd")
            oParent.funcEsquema.Exports("I_CANAL").ParamValue = "10"
            oParent.funcEsquema.Exports("I_VIGENTES").ParamValue = "X"
            oParent.funcEsquema.Exports("I_CROSS_SELLING").ParamValue = "X"

            '--------------------------------------------
            ' JNAVA (15.12.2017): Abrimos conexion a SAP
            '--------------------------------------------
            oParent.funcEsquema.Connection.Open()
            '--------------------------------------------

            oParent.funcEsquema.Execute()

            '--------------------------------------------
            ' JNAVA (15.12.2017): Cerramos conexion a SAP
            '--------------------------------------------
            oParent.funcEsquema.Connection.Close()
            '--------------------------------------------

            htTotales = New Hashtable
            htTotales("SubTotSinDesc") = oParent.funcEsquema.Imports("E_SUBTOTAL_SINDESC").ParamValue
            htTotales("TotalPzas") = oParent.funcEsquema.Imports("E_TOTAL_PIEZAS").ParamValue
            htTotales("TotalAhorro") = oParent.funcEsquema.Imports("E_AHORRO").ParamValue
            htTotales("Total") = oParent.funcEsquema.Imports("E_TOTAL_IMP").ParamValue

            dtMatDesc = oParent.funcEsquema.Tables("T_RESULTADO_MAT_AGRUP").ToADOTable
            dtPromos = oParent.funcEsquema.Tables("T_RESULTADO_XPROMO").ToADOTable
            dtCrossSelling = oParent.funcEsquema.Tables("T_CROSS_SELLING").ToADOTable



        Catch e1 As ERPConnect.RFCServerException
            Throw e1
        Catch e1 As ERPConnect.ERPException
            Throw e1
        End Try

    End Sub

#End Region

#Region "Consignacion"

    Public Function ZMMOC01(ByVal Pedido As String, ByVal Almacen As String, ByVal Fecha As DateTime) As Dictionary(Of String, Object)
        Dim data As DataTable = Nothing
        Dim msg1 As String, msg2 As String, msg3 As String
        Dim result As New Dictionary(Of String, Object)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZMMOC01                         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMMOC01")
                Dim dtResult As DataTable, dtError As DataTable, Mensaje As String = ""
                func.Exports("EBELN").ParamValue = Pedido
                func.Exports("ZTIENDA").ParamValue = Almacen
                func.Exports("ZFECHA").ParamValue = Fecha.ToString("yyyyMMdd")
                func.Execute()
                R3.Close()
                dtResult = func.Tables("ET_INFOC").ToADOTable()
                dtError = func.Tables("ET_RETURN").ToADOTable()

                For Each row As DataRow In dtError.Rows
                    If CStr(row("TYPE")).Trim() = "E" Then
                        Mensaje &= CStr(row("MESSAGE")) & vbCrLf
                    End If
                Next
                If Mensaje.Trim() = "" Then
                    result("Success") = True
                    For Each row As DataRow In dtResult.Rows
                        row("EAN11") = CStr(row("EAN11")).PadLeft(18, "0")
                        row.AcceptChanges()
                    Next
                    dtResult.AcceptChanges()
                    result("Pedido") = dtResult
                Else
                    result("Success") = False
                    result("Mensaje") = Mensaje
                End If
            End If
        Catch e1 As ERPConnect.RFCServerException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        Catch e1 As ERPConnect.ERPException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        End Try
        Return result
    End Function

    Public Function ZMMOC02(ByVal dtDetallePedido As DataTable) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZMMOC01                         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMMOC02")
                Dim zdpro As ERPConnect.RFCTable = func.Tables("IT_RECMAT")
                Dim R_Lines As ERPConnect.RFCStructure
                For Each row As DataRow In dtDetallePedido.Rows
                    R_Lines = zdpro.AddRow()
                    R_Lines("MBLNR") = ""
                    R_Lines("EBELN") = row("EBELN")
                    R_Lines("WERKS") = row("WERKS")
                    R_Lines("TIENDA") = row("TXWRK")
                    R_Lines("TXZ01") = row("TXZ01")
                    R_Lines("MATNR") = row("MATNR")
                    R_Lines("MTART") = row("MTART")
                    R_Lines("MENGE") = row("MENGE")
                    R_Lines("ERFMG") = row("ERFMG")
                    R_Lines("EAN11") = row("EAN11")
                    R_Lines("LIFNR") = row("LIFNR")
                    R_Lines("NAME1") = row("TXLFN")
                    R_Lines("SERNR") = row("SERNR")
                    R_Lines("LFSNR") = row("LFSNR")
                    R_Lines("BKTXT") = row("BKTXT")
                    R_Lines("SERNR") = row("SERNR")
                    R_Lines("ZTOTPED") = row("ZTOTPED")
                    R_Lines("ZTOTREC") = row("ZTOTREC")
                Next
                func.Execute()
                R3.Close()
                Dim dtBtReturn As New DataTable, Mensaje As String = "", Mblnr As String = "", Err As String = ""
                Dim dtEtrecmat As New DataTable()
                dtBtReturn = func.Tables("ET_RETURN").ToADOTable()
                dtEtrecmat = func.Tables("IT_RECMAT").ToADOTable()
                For Each row As DataRow In dtBtReturn.Rows
                    If CStr(row("TYPE")).Trim() = "E" Then
                        Mensaje &= CStr(row("MESSAGE")) & vbCrLf
                        Err = CStr(row("NUMBER"))
                    ElseIf CStr(row("TYPE")).Trim() = "S" Then
                        Mblnr = CStr(row("MESSAGE_V1"))
                    End If
                Next
                For Each row As DataRow In dtEtrecmat.Rows
                    Mblnr = CStr(row("MBLNR"))
                Next
                If Mensaje.Trim() = "" Then
                    result("Success") = True
                    result("MBLNR") = Mblnr
                Else
                    result("Success") = False
                    result("Mensaje") = Mensaje
                    result("ErrorNumber") = Err
                End If
            End If
        Catch e1 As ERPConnect.RFCServerException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        Catch e1 As ERPConnect.ERPException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        End Try
        Return result
    End Function

    Public Function ZMMOD01(ByVal Pedido As String, ByVal Almacen As String, ByVal Fecha As DateTime) As Dictionary(Of String, Object)
        Dim data As DataTable = Nothing
        Dim msg1 As String, msg2 As String, msg3 As String
        Dim result As New Dictionary(Of String, Object)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  ZMMOD01                         **
                '*****************************************************
                ' Create a function object
                Dim dtResult As DataTable, dtError As DataTable, Mensaje As String = ""
                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMMOD01")
                func.Exports("EBELN").ParamValue = Pedido
                func.Exports("ZTIENDA").ParamValue = Almacen
                func.Exports("ZFECHA").ParamValue = Fecha.ToString("yyyyMMdd")
                func.Execute()
                R3.Close()
                dtResult = func.Tables("IT_DEVMAT").ToADOTable()
                dtError = func.Tables("ET_RETURN").ToADOTable()

                For Each row As DataRow In dtError.Rows
                    If CStr(row("TYPE")).Trim() = "E" Then
                        Mensaje &= CStr(row("MESSAGE")) & vbCrLf
                    End If
                Next
                If Mensaje.Trim() = "" Then
                    result("Success") = True
                    For Each row As DataRow In dtResult.Rows
                        row("EAN11") = CStr(row("EAN11")).PadLeft(18, "0")
                        row.AcceptChanges()
                    Next
                    result("Pedido") = dtResult
                Else
                    result("Success") = False
                    result("Mensaje") = Mensaje
                End If
            End If
        Catch e1 As ERPConnect.RFCServerException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        Catch e1 As ERPConnect.ERPException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        End Try
        Return result
    End Function

    Public Function ZMMOC03(ByVal Mblnr As String) As Dictionary(Of String, Object)
        Dim result As New Dictionary(Of String, Object)
        Try

            ''Set Licenses.
            Dim Lic As ERPConnectLIC.Lic
            Lic.SetLic()

            Dim R3 As New ERPConnect.R3Connection( _
                     oParent.SAPApplicationConfig.ApplicationServer, _
                     oParent.SAPApplicationConfig.System, _
                     oParent.SAPApplicationConfig.User, _
                     oParent.SAPApplicationConfig.Password, _
                     oParent.SAPApplicationConfig.Language, _
                     oParent.SAPApplicationConfig.Client)


            ' Si no se logro conectar con éxito, entonces sale de la rutina
            R3.Open()
            If R3.Ping = False Then
                MsgBox("No se pudo conectar con Servidor SAP. Verifique Configuración.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Proceso SAP")
                Exit Function
            Else
                '*****************************************************
                'Call RFC function  SMMOC02                         **
                '*****************************************************
                ' Create a function object

                Dim func As ERPConnect.RFCFunction = R3.CreateFunction("ZMMOC03")
                func.Exports("I_MBLNR").ParamValue = Mblnr
                func.Execute()
                R3.Close()
                Dim dtZequi As New DataTable()
                dtZequi = func.Tables("ET_EQUI").ToADOTable()
                result("Success") = True
                result("ZEQUI") = dtZequi
            End If
        Catch e1 As ERPConnect.RFCServerException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        Catch e1 As ERPConnect.ERPException
            result("Success") = False
            result("Mensaje") = e1.Message
            Throw e1
        End Try
        Return result
    End Function

#End Region

End Class
