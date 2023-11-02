Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports System.IO
Imports System.Collections.Generic

'---------------------------------------------------------------------------------------------------------------------------------
'JNAVA 26/09/2014: Clase para tratar Otros Pagos
'---------------------------------------------------------------------------------------------------------------------------------
Public Class OtrosPagos

#Region "Constructores"
    '---------------------------------------------------------------------------------------------------------------------------------
    ' Constructor cuando se genera un pedido Nuevo
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New()

    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Constructor cuando se carga un pago por el ID Si el default es 0, 1: Referencia, 2: NumOrden
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub New(ByVal ID As String, ByVal ConceptoPago As String, Optional ByVal Opcion As Integer = 0)
        Me.LoadData(ID, ConceptoPago, Opcion)
    End Sub

#End Region

#Region "Variables Pedidos"

    Private m_OtrosPagosID As Integer = 0
    Private m_Concepto As String = String.Empty
    Private m_Referencia As String = String.Empty
    Private m_NumOrden As String = String.Empty
    Private m_TotalPago As Decimal = Decimal.Zero
    Private m_Fecha As DateTime = DateTime.Now
    Private m_Usuario As String = String.Empty
    Private m_OtrosPagosDetalles() As OtrosPagosDetalle
    Private m_CodAlmacen As String = String.Empty
    Private m_CodCaja As String = String.Empty
    Private m_CodVendedor As String = String.Empty

    Private m_IsNew As Boolean = True
    Private m_IsDirty As Boolean = False

    '------------------------------------------------------------------------------------
    'JNAVA (20.01.2015): Nuevos parametros para actualizacion de datos (Cancelacion de pago)
    '------------------------------------------------------------------------------------
    Private m_FechaCan As DateTime = DateTime.Now
    Private m_UsuarioCan As String = String.Empty
    Private m_Status As Boolean = False
    '------------------------------------------------------------------------------------
    'FLIZARRAGA 10/07/2019: Se agrega el total de piezas de la venta de ecommerce
    '------------------------------------------------------------------------------------
    Private m_Cantidad As Integer = 0
    '------------------------------------------------------------------------------------

    '--------------------------------------------------------------------------------------
    'FLIZARRAGA 17/08/2015: Variable para la venta asistida
    '--------------------------------------------------------------------------------------
    Private m_Tipo As String = ""

    Private RestService As New ProcesosRetail("pos/sihay", "POST")

#End Region

#Region "Propiedades"

    Public ReadOnly Property OtrosPagosID() As Integer
        Get
            Return m_OtrosPagosID
        End Get
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_CodAlmacen
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodAlmacen = Value
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_CodCaja
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodCaja = Value
        End Set
    End Property

    Public Property Concepto() As String
        Get
            Return m_Concepto
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Concepto = Value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_Referencia
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Referencia = Value
        End Set
    End Property

    Public Property NumOrden() As String
        Get
            Return m_NumOrden
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_NumOrden = Value
        End Set
    End Property

    Public Property TotalPago() As Decimal
        Get
            Return m_TotalPago
        End Get
        Set(ByVal Value As Decimal)
            Me.m_IsDirty = True
            m_TotalPago = Value
        End Set
    End Property

    Public Property CodVendedor() As String
        Get
            Return m_CodVendedor
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_CodVendedor = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_Usuario = Value
        End Set
    End Property


    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal Value As DateTime)
            Me.m_IsDirty = True
            m_Fecha = Value
        End Set
    End Property

    Public Property OtrosPagosDetalles() As OtrosPagosDetalle()
        Get
            Return m_OtrosPagosDetalles
        End Get
        Set(ByVal Value() As OtrosPagosDetalle)
            Me.m_IsDirty = True
            m_OtrosPagosDetalles = Value
        End Set
    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return m_IsNew
        End Get
    End Property

    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return m_IsDirty
        End Get
    End Property

    Public Property UsuarioCan() As String
        Get
            Return m_UsuarioCan
        End Get
        Set(ByVal Value As String)
            Me.m_IsDirty = True
            m_UsuarioCan = Value
        End Set
    End Property

    Public Property FechaCan() As DateTime
        Get
            Return m_FechaCan
        End Get
        Set(ByVal Value As DateTime)
            Me.m_IsDirty = True
            m_FechaCan = Value
        End Set
    End Property

    Public Property Status() As Boolean
        Get
            Return m_Status
        End Get
        Set(ByVal Value As Boolean)
            m_Status = Value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get

            Return m_Cantidad
        End Get
        Set(value As Integer)
            m_Cantidad = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return m_Tipo
        End Get
        Set(ByVal Value As String)
            m_Tipo = Value
        End Set
    End Property


#End Region

#Region "Metodos Privados"

    Private Function LoadData(ByVal ID As String, ByVal ConceptoPago As String, ByVal Opcion As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("LoadDataOtrosPagos", conexion)
        Dim adapter As SqlDataAdapter = Nothing
        Dim reader As SqlDataReader = Nothing
        Dim datos As New DataTable
        Try
            conexion.Open()
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@ID", ID)
            command.Parameters.Add("@Concepto", ConceptoPago)
            command.Parameters.Add("@Opcion", Opcion)
            reader = command.ExecuteReader()
            While reader.Read
                Me.m_OtrosPagosID = CInt(reader("OtrosPagosID"))
                Me.CodAlmacen = CStr(reader("CodAlmacen"))
                Me.CodCaja = CStr(reader("CodCaja"))
                Me.Concepto = CStr(reader("Concepto"))
                Me.Referencia = CStr(reader("Referencia"))
                Me.NumOrden = CStr(reader("NumOrden"))
                Me.TotalPago = CDec(reader("TotalPago"))
                Me.Fecha = CDate(reader("Fecha"))
                Me.Usuario = CStr(reader("Usuario"))
                Me.CodVendedor = CStr(reader("CodVendedor"))

                '------------------------------------------------------------------------------------
                'JNAVA (20.01.2015): Variables de Cancelacion de pagos
                '------------------------------------------------------------------------------------
                If Not DBNull.Value.Equals(reader("FechaCan")) Then
                    Me.FechaCan = CDate(reader("FechaCan"))
                Else
                    Me.FechaCan = Date.MinValue
                End If
                If Not DBNull.Value.Equals(reader("UsuarioCan")) Then
                    Me.UsuarioCan = CStr(reader("UsuarioCan"))
                Else
                    Me.UsuarioCan = String.Empty
                End If
                Me.Status = CStr(reader("Status"))

            End While
            Me.m_IsDirty = False
            command.Dispose()
            If Me.OtrosPagosID > 0 Then
                Me.OtrosPagosDetalles = OtrosPagosDetalle.GetOtrosPagosDetalleByOtrosPagosID(OtrosPagosID)
            End If
            reader.Close()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al leer el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al leer el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    Private Function ClearValues()

        Me.m_OtrosPagosID = 0
        Me.CodAlmacen = String.Empty
        Me.CodCaja = String.Empty
        Me.m_Concepto = String.Empty
        Me.m_Referencia = String.Empty
        Me.m_NumOrden = String.Empty
        Me.m_TotalPago = Decimal.Zero
        Me.m_Fecha = DateTime.Now
        Me.m_Usuario = String.Empty
        Me.m_CodVendedor = String.Empty

        '------------------------------------------------------------------------------------
        'JNAVA (20.01.2015): Nuevas Variables de Cancelacion de pagos
        '------------------------------------------------------------------------------------
        Me.m_FechaCan = DateTime.Now
        Me.m_UsuarioCan = String.Empty
        Me.m_Status = False

    End Function

    Private Function SetConcepto(ByVal Concepto As String) As String

        Dim strReturn As String = String.Empty

        Select Case Concepto
            Case "EC"
                strReturn = "ECommerce"

            Case Else
                strReturn = Concepto

        End Select

        Return strReturn
    End Function

#End Region

#Region "Metodos de Movimientos Generales"

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Guarda los datos del pago con sus detalle
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function Save(Optional ByVal Cancel As Boolean = False) As Boolean
        Dim valido As Boolean = False
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("OtrosPagosSave", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            Dim OtrosPagosParameter As New SqlParameter("@OtrosPagosID", SqlDbType.Int)
            OtrosPagosParameter.Direction = ParameterDirection.InputOutput
            OtrosPagosParameter.Value = Me.m_OtrosPagosID
            command.Parameters.Add(OtrosPagosParameter)
            command.Parameters.Add("@CodAlmacen", Me.CodAlmacen)
            command.Parameters.Add("@CodCaja", Me.CodCaja)
            command.Parameters.Add("@Concepto", Me.Concepto)
            command.Parameters.Add("@Referencia", Me.Referencia)
            command.Parameters.Add("@NumOrden", Me.NumOrden)
            command.Parameters.Add("@TotalPago", Me.TotalPago)
            command.Parameters.Add("@Usuario", Me.Usuario)
            command.Parameters.Add("@Fecha", Me.Fecha)
            command.Parameters.Add("@CodVendedor", Me.CodVendedor)
            '------------------------------------------------------------------------------------
            'JNAVA (20.01.2015): Nuevos parametros para actualizacion de datos (Cancelacion de pago)
            '------------------------------------------------------------------------------------
            command.Parameters.Add("@FechaCan", Me.FechaCan)
            command.Parameters.Add("@UsuarioCan", Me.UsuarioCan)
            command.Parameters.Add("@Status", Me.Status)
            command.Parameters.Add("@Cantidad", Me.Cantidad)
            '------------------------------------------------------------------------------------
            command.ExecuteScalar()
            If Not OtrosPagosParameter.Value Is Nothing Then
                Me.m_OtrosPagosID = CInt(OtrosPagosParameter.Value)
            End If
            ts.Commit()

            If Me.OtrosPagosID <> 0 Then
                For Each detalle As OtrosPagosDetalle In Me.OtrosPagosDetalles
                    If Me.m_IsNew = True Then
                        detalle.OtrosPagosID = Me.OtrosPagosID
                    End If
                    If Not detalle.Save() Then
                        GoTo no
                    End If
                Next
                Me.m_IsNew = False
                Me.m_IsDirty = False
                valido = True
            Else
No:
                ts.Rollback()
                RollBack(Me.OtrosPagosID)
            End If

            command.Dispose()
            conexion.Close()

        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                RollBack(Me.OtrosPagosID)
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al guardar el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al guardar el objeto en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                RollBack(Me.OtrosPagosID)
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
        Return valido
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Elimina los detalles y el pedido en caso de surgir un error
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function RollBack(ByVal ID As Integer)
        Dim conexion As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString())
        Dim command As New SqlCommand("RollBackOtrosPagosDetalles", conexion)
        Dim ts As SqlTransaction = Nothing
        Try
            conexion.Open()
            ts = conexion.BeginTransaction()
            command.Transaction = ts
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@OtrosPagosID", ID)
            command.ExecuteScalar()
            ts.Commit()
            command.Dispose()
            conexion.Close()
        Catch sql As SqlException
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(sql.Message, "Hubo un error al hacer el rollback el objeto en la base de datos")
            Throw New ApplicationException("Hubo un error al hacer el rollback en la base de datos", sql)
        Catch ex As Exception
            If conexion.State <> ConnectionState.Closed Then
                ts.Rollback()
                conexion.Close()
            End If
            EscribeLog(ex.Message, "Hubo un error en la aplicación")
            Throw New ApplicationException("Hubo un error en la aplicación", ex)
        End Try
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Funcion para refrescar el pedido con todos sus detalles
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Sub Refresh(ByVal Concepto As String)
        If Me.OtrosPagosID <> 0 Then
            Me.LoadData(Me.OtrosPagosID, Concepto, 0)
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (23.01.2015): Funcion para guardar los pagos en SAP
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function SavePagoSAP(Optional ByVal EsCancelacion As Boolean = False) As Boolean

        Dim bResp As Boolean = False
        Dim oSAPMgr As ProcesoSAPManager
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        Try

            If Me.OtrosPagosID <> 0 Then
                Me.Refresh(Me.Concepto)

                Dim oCabecera As New Hashtable
                Dim dtDetalle As DataTable
                Dim strMsg As String = String.Empty
                Dim bRespSAP As Boolean = False

                'Llenamos la Cabecera
                oCabecera("NoOrden") = Me.NumOrden
                oCabecera("Canal") = Me.Concepto 'EC o DC
                oCabecera("Pedido") = "" 'Vacios
                oCabecera("Referencia") = Me.Referencia
                oCabecera("Importe") = IIf(EsCancelacion, (Me.TotalPago * (-1)), Me.TotalPago) 'Cancelado en Negativo o Pagado en Positivo
                oCabecera("Status") = IIf(EsCancelacion, "C", "P") 'Cancelado o Pagado
                oCabecera("Vendedor") = Me.CodVendedor
                oCabecera("Moneda") = "MXN"
                oCabecera("Tipo") = Me.Tipo

                'Creamos la estructura de la Tabla Detalle
                dtDetalle = CrearTablaDetalleSAP()

                'Llenamos la Tabla con el Detalle del Pago
                dtDetalle = LlenarTablaDetalleSAP(dtDetalle, Me)

                'Guardamos en sap
                bRespSAP = oSAPMgr.ZPOL_REGISTRO_PAGO(oCabecera, dtDetalle, strMsg)
                If bRespSAP Then
                    bResp = True
                Else
                    MessageBox.Show(strMsg.Trim, "Error al registrar Pago EC en SAP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    EscribeLog(strMsg, "Ocurrio un error al Guardar el Pago de ECommerce en SAP.")
                    bResp = False
                End If

            Else
                bResp = False
            End If

        Catch ex As Exception

            MessageBox.Show("Ocurrio un error al Guardar el Pago de ECommerce en SAP.", "Pago EC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "Ocurrio un error al Guardar el Pago de ECommerce en SAP.")

        End Try

        Return bResp

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (23.01.2015): Funcion para formatear las formas de pagos en SAP
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function SetFormaPagoSAP(ByVal FormaPago As String) As String

        Dim strReturn As String = String.Empty

        Select Case FormaPago
            Case "EFEC"
                strReturn = "Efectivo"

            Case "TACR"
                strReturn = "Tarjeta Credito Banco"

            Case "TADB"
                strReturn = "Tarjeta Debito Banco"

            Case Else
                strReturn = FormaPago

        End Select

        Return strReturn

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (23.01.2015): Funcion para crear la tabla con los pagos en SAP
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function CrearTablaDetalleSAP() As DataTable

        Dim oDetalleTemp As New DataTable("DetalleSAP")

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NoOrden"
        oDetalleTemp.Columns.Add(dCol)

        '-----------------------------------------------------------
        'JNAVA (19.02.2015): Se agrego el campo de Referencia
        '-----------------------------------------------------------
        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Referencia"
        oDetalleTemp.Columns.Add(dCol)

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "FormaPago"
        oDetalleTemp.Columns.Add(dCol)

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "Importe"
        oDetalleTemp.Columns.Add(dCol)

        dCol = New DataColumn
        dCol.DataType = System.Type.GetType("System.String")
        dCol.ColumnName = "NoAutorizacion"
        oDetalleTemp.Columns.Add(dCol)

        oDetalleTemp.AcceptChanges()

        Return oDetalleTemp

    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    ' JNAVA (23.01.2015): Funcion para llenar tabla con los pagos en SAP
    '---------------------------------------------------------------------------------------------------------------------------------
    Private Function LlenarTablaDetalleSAP(ByVal dtDetalle As DataTable, ByVal oOtrosPagos As OtrosPagos) As DataTable

        For Each oDetalles As OtrosPagosDetalle In oOtrosPagos.OtrosPagosDetalles

            With oDetalles

                Dim oRow As DataRow = dtDetalle.NewRow()
                oRow("NoOrden") = oOtrosPagos.NumOrden
                oRow("Referencia") = oOtrosPagos.Referencia 'JNAVA (19.02.2015): Se agrego la Referencia
                oRow("FormaPago") = SetFormaPagoSAP(oDetalles.CodFormasPago)
                oRow("Importe") = oDetalles.MontoPago
                oRow("NoAutorizacion") = oDetalles.NumeroAutorizacion
                dtDetalle.Rows.Add(oRow)

            End With

        Next

        dtDetalle.AcceptChanges()

        Return dtDetalle

    End Function

    '-----------------------------------------------------------------------------
    'JNAVA (24.01.2014): Impresion del comprobantes de pagos
    '-----------------------------------------------------------------------------
    Public Sub ImprimirComprobantePago(ByVal strNumOrden As String, ByVal strConcepto As String, Optional ByVal strCliente As String = "", Optional ByVal EsCancelacion As Boolean = False, Optional ByVal CodVendedor As String = "")

        Try
            Dim EsReImpresion As Boolean = False

ReImprimir:

            Dim oARReporte
            Select Case Me.Concepto
                Case "EC"
                    oARReporte = New rptOtrosPagos(strNumOrden, strConcepto)
                Case "DC"
                    oARReporte = New rptComprobantePagoDPCard(CInt(strNumOrden), strCliente, strConcepto, EsCancelacion, CodVendedor)
            End Select
            oARReporte.Document.Name = "Comprobante de Pago"

            'Dim oARReporte As New rptOtrosPagos(oOtrosPagos.NumOrden, oOtrosPagos.Concepto)
            'oARReporte.Document.Name = "Comprobante de Pago"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                oARReporte.PageSettings.PaperHeight = 7
                oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '-----------------------------------------------------------------------------------
            ' JNAVA (25.01.2014): ReImprimimos ticket del seguro
            '-----------------------------------------------------------------------------------
            If Not EsReImpresion Then
                EsReImpresion = True
                GoTo ReImprimir
            End If

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
        End Try

    End Sub

    Public Sub ImprimirComprobantePagoEcomm(ByVal strNumOrden As String, ByVal strConcepto As String, ByVal tipoPago As Integer, ByVal vale As String)

        Try

            Dim oARReporte = New rptOtrosPagosEcomm(strNumOrden, strConcepto, tipoPago, vale)
            oARReporte.Document.Name = "Comprobante de Pago"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                oARReporte.PageSettings.PaperHeight = 7
                oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", "Otros pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
        End Try

    End Sub

    Public Sub ImprimirTicketPagoApi(ByVal html As String)

        Try

            Dim oARReporte = New rptPagosEcommApiTicket(html)
            oARReporte.Document.Name = "Comprobante de Pago"

            If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                'oARReporte.PageSettings.PaperHeight = 7
                'oARReporte.PageSettings.PaperWidth = 14
                oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName
                oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

            End If

            oARReporte.Run()

            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

            Try
                oARReporte.Document.print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", "Otros pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
        End Try

    End Sub

    Public Sub ImprimirTicketPagoApiPagare(ByVal html As String)

        Try

            Dim oARReporte = New rptPagosEcommApiPagare(html)
            oARReporte.Document.Name = "Comprobante de Pago"

            Dim oReportViewer As New ReportViewerForm
            oARReporte.Document.Name = "Pagare Ecommerce"
            oReportViewer.Report = oARReporte
            oARReporte.Run()
            oReportViewer.Show()

            Try
                oARReporte.Document.print(False, False)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Comprobante de Pago.", "Otros pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Comprobante de Otros Pagos.-")
        End Try

    End Sub
#End Region

#Region "e-Commerce"

    '---------------------------------------------------------------------------------------------------------------------------------
    ' Funcion que valida el Numero de orden del pedido EC y regresa su fecha e importe
    '---------------------------------------------------------------------------------------------------------------------------------
    Public Function ValidarNumeroOrdenWS(ByVal NumOrden As String, ByRef Fecha As Date, ByRef Importe As Decimal, ByRef Status As String, ByRef NumRef As String, Optional ByVal tipoPago As String = "") As Boolean

        Dim strSoapEnvelope As String = ""
        Dim bResp As Boolean = False
        Fecha = Date.MinValue
        Importe = 0
        Dim UrlWS As String = ""
        '-------------------------------------------------------------------------------------------------------------------------
        'FLIZARRAGA 18/08/2015: Se valida si es venta asistida, sino lo realiza con el otro servidor del broker
        '-------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.VentaAsistida = True Then
            UrlWS = oConfigCierreFI.ServerBrokerNew.TrimEnd("/") & ":" & oConfigCierreFI.PuertoBrokerNew & "/WS_PagosEcommerce?wsdl"
        Else
            UrlWS = oConfigCierreFI.ServerBroker.TrimEnd("/") & ":" & oConfigCierreFI.PuertoBroker & "/PAGOSECOMMERCE?wsdl"
        End If
        'UrlWS = "http://10.200.3.18:7802/PAGOSECOMMERCE?wsdl"

        Try
            If oConfigCierreFI.VentaAsistida = True Then
                strSoapEnvelope = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ws='http://WS_PagosEcommerce'>"
                strSoapEnvelope &= "    <soapenv:Header/>"
                strSoapEnvelope &= "    <soapenv:Body>"
                strSoapEnvelope &= "        <ws:Pagos>"
                strSoapEnvelope &= "            <orders_id>" & NumOrden & "</orders_id>"
                strSoapEnvelope &= "            <tipopago>" & tipoPago & "</tipopago>"
                strSoapEnvelope &= "        </ws:Pagos>"
                strSoapEnvelope &= "    </soapenv:Body>"
                strSoapEnvelope &= "</soapenv:Envelope>"
            Else
                strSoapEnvelope = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:dpor='http://www.dportenis.com.mx'>"
                strSoapEnvelope &= "   <soapenv:Header/>"
                strSoapEnvelope &= "   <soapenv:Body>"
                strSoapEnvelope &= "      <dpor:request>"
                strSoapEnvelope &= "         <orders_id>" & NumOrden & "</orders_id>"
                strSoapEnvelope &= "      </dpor:request>"
                strSoapEnvelope &= "   </soapenv:Body>"
                strSoapEnvelope &= "</soapenv:Envelope>"
            End If

            Dim dsPedidoEC As DataSet = ConsumeXML(UrlWS, strSoapEnvelope) 'ConsumeWSBroker(UrlWS, strSoapEnvelope)
            If oConfigCierreFI.VentaAsistida = True Then
                With dsPedidoEC.Tables
                    If .Contains("PagosResponse") Then
                        If !PagosResponse.Columns.Contains("IMPORT") Then
                            Importe = !PagosResponse.Rows(0)!IMPORT
                            'MsgBox("Importe: " & !Request.Rows(0)!IMPORT)
                        End If
                        If !PagosResponse.Columns.Contains("LASTUPDATE") Then
                            Fecha = Format(CDate(!PagosResponse.Rows(0)!LASTUPDATE), "dd/MM/yyyy")
                            'MsgBox("Fecha: " & Format(CDate(!Request.Rows(0)!LASTUPDATE), "dd/MM/yyyy"))
                        End If
                        If !PagosResponse.Columns.Contains("STATUS") Then
                            Status = CStr(!PagosResponse.Rows(0)!STATUS).Trim
                        End If
                        If !PagosResponse.Columns.Contains("DATAVALUE") Then
                            NumRef = CStr(!PagosResponse.Rows(0)!DATAVALUE).Trim
                        End If
                    End If
                End With

            Else
                With dsPedidoEC.Tables
                    If .Contains("Request") Then
                        If !Request.Columns.Contains("IMPORT") Then
                            Importe = !Request.Rows(0)!IMPORT
                            'MsgBox("Importe: " & !Request.Rows(0)!IMPORT)
                        End If
                        If !Request.Columns.Contains("LASTUPDATE") Then
                            Fecha = Format(CDate(!Request.Rows(0)!LASTUPDATE), "dd/MM/yyyy")
                            'MsgBox("Fecha: " & Format(CDate(!Request.Rows(0)!LASTUPDATE), "dd/MM/yyyy"))
                        End If
                        If !Request.Columns.Contains("STATUS") Then
                            Status = CStr(!Request.Rows(0)!STATUS).Trim
                        End If
                        If !Request.Columns.Contains("DATAVALUE") Then
                            NumRef = CStr(!Request.Rows(0)!DATAVALUE).Trim
                        End If
                    End If
                End With
            End If

            If Importe > 0 AndAlso Fecha <> Date.MinValue AndAlso Status.Trim <> "" AndAlso NumRef.Trim <> "" Then
                bResp = True
            End If

        Catch ex As Exception
            EscribeLog(ex.ToString, "Hubo un error al Validar el Numero de Orden de ECommerce")
            'Throw New ApplicationException("Hubo un error al Validar el Numero de Orden de ECommerce", ex)
        End Try

        Return bResp

    End Function

#End Region

#Region "DP Card"

    '--------------------------------------------------------------
    'JNAVA (15.01.2015): Leemos datos de tarjeta DPCard con PINPAD
    '--------------------------------------------------------------
    Public Function LeerDatosDPCard(ByRef NumTarjeta As String, Optional ByRef Nombre As String = "", Optional ByRef Vencimiento As String = "") As Boolean
        Dim Band As Boolean = True
        Dim oApp As Process
        Dim oProcesos() As Process
        'Dim pagoTarj As Decimal = 0

        Dim Ruta As String = "C:\LecturaTarjeta.txt"
        'Dim strPosEntry As String = ""
        Dim Datos() As String

        oProcesos = Process.GetProcessesByName("eHubEMV")
        For Each oApp In oProcesos
            oApp.CloseMainWindow()
            oApp.WaitForExit()
        Next

        Shell(Application.StartupPath & "\PinPadNurit293.exe /A", AppWinStyle.NormalFocus, True)

        If File.Exists(Ruta) Then
            Datos = LeerArchivoTarjeta(Ruta)
            File.Delete(Ruta)
        Else
            Band = False
            GoTo salir
        End If

        Dim strTrack() As String

        NumTarjeta = Datos(0)
        'Me.mPosEntryM = CInt(Datos(3) & "1")
        'Me.strCriptogramaM = Datos(5)
        'Nombre = Datos(6)
        Nombre = Datos(1)

        'strPosEntry = CStr(mPosEntryM).Trim.PadLeft(3, "0")

        strTrack = NumTarjeta.Split("=")
        NumTarjeta = strTrack(0)
        Vencimiento = Datos(2).Substring(2, 2) & "/" & Datos(2).Substring(0, 2)

Salir:
        Return Band

    End Function

    Private Function LeerArchivoTarjeta(ByVal Ruta As String) As String()

        Dim oStreamR As StreamReader
        Dim strContenido() As String

        oStreamR = New StreamReader(Ruta, System.Text.Encoding.ASCII)

        strContenido = oStreamR.ReadToEnd.Split("|")

        oStreamR.Close()

        Return strContenido

    End Function

    '-----------------------------------------------------------------------------
    'JNAVA (24.01.2014): Impresion del Voucher del pago de DPCard en KARUM
    '-----------------------------------------------------------------------------
    Public Sub ImprimirVoucherDPCard(ByVal htDatosDPC As Hashtable, Optional ByVal TipoVoucher As String = "VTA", Optional ByVal EsCopia As Boolean = False, Optional ByVal EsCancelacion As Boolean = False)

        Try

            If Not htDatosDPC Is Nothing AndAlso htDatosDPC.Count > 0 Then
                '-----------------------------------------------------------------------------------
                ' Voucher 
                '-----------------------------------------------------------------------------------
                Dim oARReporte As New rptVoucherDPCard(htDatosDPC, TipoVoucher, EsCopia, EsCancelacion)
                oARReporte.Document.Name = "Voucher DPCard"

                If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                    oARReporte.PageSettings.PaperHeight = 7
                    oARReporte.PageSettings.PaperWidth = 14
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                    oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                End If

                oARReporte.Run()

                'Dim oReportViewer As New ReportViewerForm
                'oReportViewer.Report = oARReporte
                'oReportViewer.Show()

                '-----------------------------------------------------------------------------------
                ' Imprimimos voucher 
                '-----------------------------------------------------------------------------------
                Try
                    oARReporte.Document.Print(False, False)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Else
                MessageBox.Show("No se han cargado los datos del DP Card. Favor de verificar.", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Voucher de Pago de DP Card.", "DP Card", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Voucher de Pago de DP Card.-")
        End Try


    End Sub

#End Region

#Region "Microcreditos Club DP"

    '------------------------------------------------------------------------------------
    'FLIZARRAGA 25/10/2017: Impresion del Voucher del Prestamo Microcredito ClubDP KARUM
    '------------------------------------------------------------------------------------
    Public Sub ImprimirVoucherMicrocredito(ByVal htDatosDPC As Hashtable, Optional ByVal TipoVoucher As String = "VTA", Optional ByVal EsCopia As Boolean = False, Optional ByVal EsCancelacion As Boolean = False)

        Try

            If Not htDatosDPC Is Nothing AndAlso htDatosDPC.Count > 0 Then
                '-----------------------------------------------------------------------------------
                ' Voucher 
                '-----------------------------------------------------------------------------------
                Dim oARReporte As New rptVoucherClubDP(htDatosDPC, TipoVoucher, EsCopia, EsCancelacion)
                oARReporte.Document.Name = "Voucher Microcredito Club DP"

                If Not oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then

                    oARReporte.PageSettings.PaperHeight = 7
                    oARReporte.PageSettings.PaperWidth = 14
                    oARReporte.Document.Printer.PrinterSettings.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName ' "\\pcara\SAMSUNG SRP-350"
                    oARReporte.Document.Printer.PrinterName = oAppContext.ApplicationConfiguration.MiniPrintName '"\\pcara\SAMSUNG SRP-350"
                    oARReporte.PageSettings.PaperSource = Printing.PaperSourceKind.TractorFeed

                End If

                oARReporte.Run()

                'Dim oReportViewer As New ReportViewerForm
                'oReportViewer.Report = oARReporte
                'oReportViewer.Show()

                '-----------------------------------------------------------------------------------
                ' Imprimimos voucher 
                '-----------------------------------------------------------------------------------
                Try
                    oARReporte.Document.Print(False, False)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Else
                MessageBox.Show("No se han cargado los datos del Microcredito ClubDP. Favor de verificar.", "Microcredito ClubDP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al imprimir el Voucher de Prestamo Microcreditos ClubDP.", "Microcredito ClubDP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EscribeLog(ex.ToString, "-Error al imprimir el Voucher de Pago de DP Card.-")
        End Try


    End Sub

#End Region

End Class
