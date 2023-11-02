Imports System.Data.SqlClient
Imports System.Windows.Forms

Friend Class CatalogoAlmacenesDataGateway

    Private oParent As CatalogoAlmacenesManager
    Private m_strConnectionStringServer As String
    Private m_strConnectionStringHuellas As String
    Private m_strConnectionStringDPVale As String

#Region "Constructors / Destructors"

    Public Sub New(ByVal Parent As CatalogoAlmacenesManager)
        oParent = Parent

        If Not oParent.ConfigCierreFI Is Nothing Then

            With oParent.ConfigCierreFI
                m_strConnectionStringServer = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                    "DPVFinanciero; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                    oParent.ConfigCierreFI.PassHuellas()

                m_strConnectionStringHuellas = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                    oParent.ConfigCierreFI.BaseDatosHuellas & "; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                    oParent.ConfigCierreFI.PassHuellas

                If oParent.ConfigCierreFI.MigracionFinanciero Then
                    m_strConnectionStringDPVale = "data source = " & oParent.ConfigCierreFI.ServidorFinanciero & "; initial catalog = " & oParent.ConfigCierreFI.BaseFinanciero & _
                                    "; user id = " & Parent.ConfigCierreFI.UsuarioFinanciero & "; password = " & _
                                    oParent.ConfigCierreFI.PasswordFinanciero
                Else
                    m_strConnectionStringDPVale = "data source = " & oParent.ConfigCierreFI.ServerHuellas & "; initial catalog = " & _
                                    "DPVFinanciero; user id = " & Parent.ConfigCierreFI.UserHuellas & "; password = " & _
                                    oParent.ConfigCierreFI.PassHuellas()
                End If

            End With

        End If

    End Sub

#End Region

#Region "Methods"

    Public Function SelectRazonesRechazo(ByRef bResult As Boolean) As DataTable

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionStringHuellas)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsRazones As DataSet
        Dim scdaRazones As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsRazones = New DataSet("RazonesRechazo")
        scdaRazones = New SqlClient.SqlDataAdapter

        bResult = False

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[CatalogoRazonesSelAllTemp]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Modulo", SqlDbType.VarChar, 2))

            .Parameters("@Modulo").Value = ""

        End With

        scdaRazones.SelectCommand = sccmdSelAll

        Try

            oCon.Open()

            scdaRazones.Fill(scdsRazones, "RazonesRechazo")

            oCon.Close()

            bResult = True

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            'MsgBox(exSQL)

            'Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            'Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsRazones.Tables(0)

    End Function

    Public Function SelectCodigosPostales() As DataTable

        Dim oCon As New SqlClient.SqlConnection(m_strConnectionStringHuellas)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsRazones As DataSet
        Dim scdaRazones As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsRazones = New DataSet("CodigosPostales")
        scdaRazones = New SqlClient.SqlDataAdapter

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[CatalogoCodigosPostalesSelAll]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Todos", SqlDbType.Bit, 1))

        End With

        Try

            sccmdSelAll.Parameters("@Todos").Value = oParent.TiendaNueva

            scdaRazones.SelectCommand = sccmdSelAll

            oCon.Open()

            scdaRazones.Fill(scdsRazones, "CodigosPostales")

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            'MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsRazones.Tables(0)

    End Function

    Public Function SelectCodigosPostalesByColonia(ByVal CodEstado As String, ByVal CodMunicipio As String, ByVal Colonia As String) As DataSet

        Dim oCon As New SqlClient.SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)
        Dim sccmdSelAll As SqlClient.SqlCommand
        Dim scdsRazones As DataSet
        Dim scdaRazones As SqlClient.SqlDataAdapter

        sccmdSelAll = New SqlClient.SqlCommand
        scdsRazones = New DataSet("RazonesRechazo")
        scdaRazones = New SqlClient.SqlDataAdapter

        With sccmdSelAll

            .Connection = oCon
            .CommandText = "[CatalogoCodigosPostalesSel]"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@CodEstado", SqlDbType.Int, 4, "CodEstado"))
            .Parameters.Add(New SqlParameter("@CodMunicipio", SqlDbType.Int, 4, "CodMunicipio"))
            .Parameters.Add(New SqlParameter("@Criterio", SqlDbType.VarChar, 255, "Criterio"))

            .Parameters("@CodEstado").Value = CodEstado
            .Parameters("@CodMunicipio").Value = CodMunicipio
            .Parameters("@Criterio").Value = Colonia

        End With

        scdaRazones.SelectCommand = sccmdSelAll

        Try

            oCon.Open()

            scdaRazones.Fill(scdsRazones, "CodigosPostales")

            oCon.Close()

        Catch exSQL As SqlClient.SqlException

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            'MsgBox(exSQL)

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de base de datos")

        Catch ex As Exception

            If oCon.State <> ConnectionState.Closed Then
                oCon.Close()
            End If

            Throw New ApplicationException("Los registros no se pudieron obtener debido a un error de aplicación")

        End Try

        oCon.Dispose()
        oCon = Nothing

        Return scdsRazones

    End Function

    Public Sub Insert(ByVal pAlmacen As Almacen)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesIns As SqlCommand
        sccmdCatalogoAlmacenesIns = New SqlCommand

        With sccmdCatalogoAlmacenesIns

            .CommandText = "[CatalogoAlmacenesIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3, "CodPlaza"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.Bit, 1, "Tienda"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Calle", System.Data.SqlDbType.VarChar, 150, "Calle"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumExterior", System.Data.SqlDbType.VarChar, 10, "NumExterior"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumInterior", System.Data.SqlDbType.VarChar, 10, "NumInterior"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 30, "Colonia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.VarChar, 5, "CP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 30, "Ciudad"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 30, "Estado"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lada", System.Data.SqlDbType.VarChar, 5, "Lada"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MS", System.Data.SqlDbType.Bit, 1, "MostrarSeparaciones"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OficinaVta", System.Data.SqlDbType.VarChar, 4, "OficinaVta"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            '.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

            .Parameters("@CodAlmacen").Value = pAlmacen.ID
            .Parameters("@Descripcion").Value = pAlmacen.Descripcion
            .Parameters("@CodPlaza").Value = pAlmacen.PlazaID
            '.Parameters("@Tienda").Value = pAlmacen.EsTienda
            .Parameters("@Calle").Value = pAlmacen.DireccionCalle
            .Parameters("@NumExterior").Value = pAlmacen.DireccionNumExt
            '.Parameters("@NumInterior").Value = pAlmacen.DireccionNumInt
            '.Parameters("@Colonia").Value = pAlmacen.DireccionColonia
            .Parameters("@CP").Value = pAlmacen.DireccionCP
            .Parameters("@Ciudad").Value = pAlmacen.DireccionCiudad
            .Parameters("@Estado").Value = pAlmacen.DireccionEstado
            '.Parameters("@Lada").Value = pAlmacen.TelefonoLada
            .Parameters("@Telefono").Value = pAlmacen.TelefonoNum
            .Parameters("@MS").Value = pAlmacen.MostrarEnSeparaciones
            .Parameters("@OficinaVta").Value = pAlmacen.OficinaVta
            '.Parameters("@Usuario").Value = pAlmacen.RecordCreatedBy
            '.Parameters("@Fecha").Value = pAlmacen.RecordCreatedOn
            '.Parameters("@StatusRegistro").Value = pAlmacen.RecordEnabled

        End With

        Try
            sccnnDPTienda.Open()

            sccmdCatalogoAlmacenesIns.ExecuteNonQuery()

            pAlmacen.ResetFlagNew()
            pAlmacen.ResetFlagDirty()

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesIns.Dispose()
        sccmdCatalogoAlmacenesIns = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub InsertCentro(ByVal CentroSAP As String, ByVal OficinaVta As String, ByVal Desc As String, ByVal CentroFI As String)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesIns As SqlCommand
        sccmdCatalogoAlmacenesIns = New SqlCommand

        With sccmdCatalogoAlmacenesIns

            .CommandText = "[CatalogoCentrosIns]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCentro", System.Data.SqlDbType.VarChar, 4, "CodCentro"))
            .Parameters.Add(New SqlParameter("@OficinaVta", SqlDbType.VarChar, 4, "OficinaVta"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CentroFI", System.Data.SqlDbType.VarChar, 4, "CentroFI"))

            .Parameters("@CodCentro").Value = CentroSAP
            .Parameters("@Descripcion").Value = Desc
            .Parameters("@OficinaVta").Value = OficinaVta
            .Parameters("@CentroFI").Value = CentroFI

        End With

        Try
            sccnnDPTienda.Open()

            sccmdCatalogoAlmacenesIns.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesIns.Dispose()
        sccmdCatalogoAlmacenesIns = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Update(ByVal pAlmacen As Almacen)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesUpd As SqlCommand
        sccmdCatalogoAlmacenesUpd = New SqlCommand

        With sccmdCatalogoAlmacenesUpd
            .CommandText = "[CatalogoAlmacenesUpd]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4, "CodAlmacen"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 50, "Descripcion"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodPlaza", System.Data.SqlDbType.VarChar, 3, "CodPlaza"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Tienda", System.Data.SqlDbType.Bit, 1, "Tienda"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Calle", System.Data.SqlDbType.VarChar, 150, "Calle"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumExterior", System.Data.SqlDbType.VarChar, 10, "NumExterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@NumInterior", System.Data.SqlDbType.VarChar, 10, "NumInterior"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Colonia", System.Data.SqlDbType.VarChar, 30, "Colonia"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CP", System.Data.SqlDbType.VarChar, 5, "CP"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 30, "Ciudad"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 30, "Estado"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Lada", System.Data.SqlDbType.VarChar, 5, "Lada"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Telefono", System.Data.SqlDbType.VarChar, 30, "Telefono"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@MostrarSeparaciones", System.Data.SqlDbType.Bit, 1, "MostrarSeparaciones"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Usuario", System.Data.SqlDbType.VarChar, 12, "Usuario"))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, False, CType(0, Byte), CType(0, Byte), "Fecha", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@StatusRegistro", System.Data.SqlDbType.Bit, 1, "StatusRegistro"))

            .Parameters("@CodAlmacen").Value = pAlmacen.ID
            .Parameters("@Descripcion").Value = pAlmacen.Descripcion
            .Parameters("@CodPlaza").Value = pAlmacen.PlazaID
            .Parameters("@Tienda").Value = pAlmacen.EsTienda
            .Parameters("@Calle").Value = pAlmacen.DireccionCalle
            .Parameters("@NumExterior").Value = pAlmacen.DireccionNumExt
            .Parameters("@NumInterior").Value = pAlmacen.DireccionNumInt
            .Parameters("@Colonia").Value = pAlmacen.DireccionColonia
            .Parameters("@CP").Value = pAlmacen.DireccionCP
            .Parameters("@Ciudad").Value = pAlmacen.DireccionCiudad
            .Parameters("@Estado").Value = pAlmacen.DireccionEstado
            .Parameters("@Lada").Value = pAlmacen.TelefonoLada
            .Parameters("@Telefono").Value = pAlmacen.TelefonoNum
            .Parameters("@MostrarSeparaciones").Value = pAlmacen.MostrarEnSeparaciones
            .Parameters("@Usuario").Value = pAlmacen.RecordCreatedBy
            '.Parameters("@Fecha").Value = pAlmacen.RecordCreatedOn
            .Parameters("@StatusRegistro").Value = pAlmacen.RecordEnabled

        End With

        Try
            sccnnDPTienda.Open()

            sccmdCatalogoAlmacenesUpd.ExecuteNonQuery()

            pAlmacen.ResetFlagNew()
            pAlmacen.ResetFlagDirty()

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesUpd.Dispose()
        sccmdCatalogoAlmacenesUpd = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Sub Delete(ByVal ID As String)

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesDel As SqlCommand
        sccmdCatalogoAlmacenesDel = New SqlCommand

        With sccmdCatalogoAlmacenesDel

            .CommandText = "[CatalogoAlmacenesDel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodAlmacen", System.Data.DataRowVersion.Original, Nothing))

            .Parameters("@CodAlmacen").Value = ID

        End With

        Try
            sccnnDPTienda.Open()

            sccmdCatalogoAlmacenesDel.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesDel.Dispose()
        sccmdCatalogoAlmacenesDel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

    End Sub

    Public Function SeleccionaCentro(ByVal strtienda As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[ExistenciasSAPsel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@tienda", System.Data.SqlDbType.VarChar, 50))

            .Parameters("@tienda").Value = strtienda
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader()

            scsdrReader.Read()
            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'Cod Centro SAP
                End With
                scsdrReader.Close()
            Else

                strResult = String.Empty

            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoCentrosSel.Dispose()
        sccmdCatalogoCentrosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function SeleccionaColor(ByVal strCodigo As String) As String

        Dim strResult As String

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration. _
                                                 GetConnectionString)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoColoresSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Codigo", System.Data.SqlDbType.VarChar, 1))

            .Parameters("@Codigo").Value = strCodigo
        End With

        Try
            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoCentrosSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                With scsdrReader
                    strResult = .GetString(0) 'Cod Centro SAP
                End With
                scsdrReader.Close()

            Else

                strResult = String.Empty

            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoCentrosSel.Dispose()
        sccmdCatalogoCentrosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return strResult
    End Function

    Public Function SelByCiudad(ByVal Ciudad As String) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesSel As SqlCommand
        sccmdCatalogoAlmacenesSel = New SqlCommand

        With sccmdCatalogoAlmacenesSel
            .CommandText = "[CatalogoAlmacenesSelByCiudad]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@Ciudad", System.Data.SqlDbType.VarChar, 30, "Ciudad"))
            .Parameters("@Ciudad").Value = Ciudad
        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoAlmacenesSel

        Try
            sccnnDPTienda.Open()
            oResult = New DataSet
            scdaAlmacenesAdapter.Fill(oResult, "CatalogoAlmacenes")
        Catch ex As Exception
            Throw ex
        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesSel.Dispose()
        sccmdCatalogoAlmacenesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function


    Public Function [Select](ByVal ID As String, Optional ByVal Almacen As Almacen = Nothing) As Almacen

        Dim oResult As Almacen

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration. _
                                                 DataStorageConfiguration.GetConnectionString)

        '(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesSel As SqlCommand
        sccmdCatalogoAlmacenesSel = New SqlCommand

        With sccmdCatalogoAlmacenesSel
            .CommandText = "[CatalogoAlmacenesSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodAlmacen", System.Data.SqlDbType.VarChar, 4))

            .Parameters("@CodAlmacen").Value = ID
        End With

        Try

            sccnnDPTienda.Open()

            Dim scsdrReader As SqlDataReader

            scsdrReader = sccmdCatalogoAlmacenesSel.ExecuteReader(CommandBehavior.SingleResult Or CommandBehavior.SingleRow)

            scsdrReader.Read()

            If (scsdrReader.HasRows) Then

                If (Almacen Is Nothing) Then
                    oResult = oParent.Create
                Else
                    oResult = Almacen
                End If

                With scsdrReader

                    oResult.ID = .GetString(.GetOrdinal("CodAlmacen"))                          'CodAlmacen,
                    oResult.Descripcion = .GetString(.GetOrdinal("Descripcion"))                 'Descripcion,
                    oResult.PlazaID = .GetString(2)                     'CodPlaza,
                    'oResult.EsTienda = .GetBoolean(3)                   'Tienda,
                    oResult.DireccionCalle = .GetString(.GetOrdinal("Calle"))              'Calle,
                    oResult.DireccionNumExt = .GetString(.GetOrdinal("NumExterior"))             'NumExterior,
                    'oResult.DireccionNumInt = .GetString(6)             'NumInterior,
                    'oResult.DireccionColonia = .GetString(7)            'Colonia,
                    oResult.DireccionCP = .GetString(.GetOrdinal("CP"))                 'CP,
                    oResult.DireccionCiudad = .GetString(.GetOrdinal("Ciudad"))             'Ciudad,
                    oResult.DireccionEstado = .GetString(.GetOrdinal("Estado"))            'Estado,
                    'oResult.TelefonoLada = .GetString(11)               'Lada,
                    oResult.TelefonoNum = .GetString(.GetOrdinal("Telefono"))                'Telefono,
                    oResult.MostrarEnSeparaciones = .GetBoolean(.GetOrdinal("MostrarSeparaciones"))     'MostrarSeparaciones,
                    'oResult.RecordCreatedBy = .GetString(14)            'Usuario,
                    'oResult.RecordCreatedOn = .GetDateTime(15)          'Fecha,
                    'oResult.RecordEnabled = .GetBoolean(16)             'StatusRegistro()

                End With

                scsdrReader.Close()

                oResult.ResetFlagNew()
                oResult.ResetFlagDirty()

                'Else
                'MessageBox.Show("Código no existe", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesSel.Dispose()
        sccmdCatalogoAlmacenesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult

    End Function

    Public Function [Select](ByVal EnabledRecordsOnly As Boolean) As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(oParent.ApplicationContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdCatalogoAlmacenesSel As SqlCommand
        sccmdCatalogoAlmacenesSel = New SqlCommand

        With sccmdCatalogoAlmacenesSel
            .CommandText = "[CatalogoAlmacenesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@OnlyEnabledRecords", System.Data.SqlDbType.Bit, 1))

            .Parameters("@OnlyEnabledRecords").Value = EnabledRecordsOnly
        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoAlmacenesSel


        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoAlmacenes")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesSel.Dispose()
        sccmdCatalogoAlmacenesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function SelectFromServer() As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionStringDPVale)

        Dim sccmdCatalogoAlmacenesSel As SqlCommand
        sccmdCatalogoAlmacenesSel = New SqlCommand

        With sccmdCatalogoAlmacenesSel
            .CommandText = "[CatalogoAlmacenesSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoAlmacenesSel

        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoAlmacenes")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoAlmacenesSel.Dispose()
        sccmdCatalogoAlmacenesSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

    Public Function SelectCentrosFromServer() As DataSet

        Dim oResult As DataSet

        Dim sccnnDPTienda As New SqlConnection(m_strConnectionStringDPVale)

        Dim sccmdCatalogoCentrosSel As SqlCommand
        sccmdCatalogoCentrosSel = New SqlCommand

        With sccmdCatalogoCentrosSel
            .CommandText = "[CatalogoCentrosSelAll]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Connection = sccnnDPTienda
        End With

        Dim scdaAlmacenesAdapter As SqlDataAdapter
        scdaAlmacenesAdapter = New SqlDataAdapter

        scdaAlmacenesAdapter.SelectCommand = sccmdCatalogoCentrosSel

        Try

            sccnnDPTienda.Open()

            oResult = New DataSet

            scdaAlmacenesAdapter.Fill(oResult, "CatalogoCentros")

        Catch ex As Exception

            Throw ex

        Finally

            If (sccnnDPTienda.State <> ConnectionState.Closed) Then
                Try
                    sccnnDPTienda.Close()
                Catch
                End Try
            End If

        End Try

        sccmdCatalogoCentrosSel.Dispose()
        sccmdCatalogoCentrosSel = Nothing

        sccnnDPTienda.Dispose()
        sccnnDPTienda = Nothing

        Return oResult


    End Function

#End Region


End Class
