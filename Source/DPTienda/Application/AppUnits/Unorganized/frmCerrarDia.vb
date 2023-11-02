Imports System.Web.Mail
Imports System.Web.Util
Imports System.Net
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports DportenisPro.DPTienda.ApplicationUnits.CierreDiaAU
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonosApartadosAU
Imports DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda
Imports Microsoft.VisualBasic
Imports System.IO
Imports DportenisPro.DPTienda.Reports.Ventas
Imports DportenisPro.DPTienda.ApplicationUnits.Facturas
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.ArchivosTransAU
Imports DportenisPro.DPTienda.ApplicationUnits.AjusteGeneralTalla
Imports EmpGerInt
Imports DportenisPro.DPTienda.ApplicationUnits.ConfigSaveArchivos
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU
Imports DportenisPro.DPTienda.ApplicationUnits.FingerPrintAU
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.ApplicationUnits.Clientes
Imports System.Collections.Generic


Public Class frmCerrarDia
    Inherits System.Windows.Forms.Form

    Private m_strFirmaConfig As SaveConfigArchivos
    Private RestService As New ProcesosRetail("pos/sihay", "POST")

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal oFirma As SaveConfigArchivos)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        FirmaConfig = oFirma
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
    Friend WithEvents btnCerrarDia As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents LstReportes As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents uIProgressBar1 As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCerrarDia))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uIProgressBar1 = New Janus.Windows.EditControls.UIProgressBar()
        Me.LstReportes = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrarDia = New Janus.Windows.EditControls.UIButton()
        Me.ebFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.uIProgressBar1)
        Me.ExplorerBar1.Controls.Add(Me.LstReportes)
        Me.ExplorerBar1.Controls.Add(Me.Label2)
        Me.ExplorerBar1.Controls.Add(Me.btnCerrarDia)
        Me.ExplorerBar1.Controls.Add(Me.ebFecha)
        Me.ExplorerBar1.Controls.Add(Me.Label1)
        Me.ExplorerBar1.Controls.Add(Me.GroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(368, 364)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uIProgressBar1
        '
        Me.uIProgressBar1.Location = New System.Drawing.Point(33, 70)
        Me.uIProgressBar1.Name = "uIProgressBar1"
        Me.uIProgressBar1.Size = New System.Drawing.Size(296, 2)
        Me.uIProgressBar1.TabIndex = 12
        '
        'LstReportes
        '
        Me.LstReportes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstReportes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LstReportes.ItemHeight = 14
        Me.LstReportes.Items.AddRange(New Object() {"Ventas Facturadas", "Pedidos", "Notas de Credito", "Devolución de Tarjetas", "Devolución de Efectivo", "Vales de Caja", "Liquidaciones", "Abonos", "Abonos a CxC", "Cancelacion de Apartados", "Numero Referencia", "Ventas DPVale", "DPVale Ecommerce", "Notas de Venta Manual", "Ventas Totales Microcredito", "Reporte de concentrado del día", "Reporte Concentrado Cierre de Caja"})
        Me.LstReportes.Location = New System.Drawing.Point(42, 92)
        Me.LstReportes.Name = "LstReportes"
        Me.LstReportes.Size = New System.Drawing.Size(280, 214)
        Me.LstReportes.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(50, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Reportes del Cierre del Dia:"
        '
        'btnCerrarDia
        '
        Me.btnCerrarDia.Icon = CType(resources.GetObject("btnCerrarDia.Icon"), System.Drawing.Icon)
        Me.btnCerrarDia.Location = New System.Drawing.Point(112, 321)
        Me.btnCerrarDia.Name = "btnCerrarDia"
        Me.btnCerrarDia.Size = New System.Drawing.Size(152, 32)
        Me.btnCerrarDia.TabIndex = 2
        Me.btnCerrarDia.Text = "&Cerrar Dia"
        Me.btnCerrarDia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'ebFecha
        '
        '
        '
        '
        Me.ebFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        Me.ebFecha.Location = New System.Drawing.Point(178, 45)
        Me.ebFecha.Name = "ebFecha"
        Me.ebFecha.Size = New System.Drawing.Size(142, 23)
        Me.ebFecha.TabIndex = 0
        Me.ebFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(114, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(16, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 282)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'frmCerrarDia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 364)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCerrarDia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cerrar Dia"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ExplorerBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Declare Function ExitWindowsEx& Lib "user32" (ByVal uFlags&, ByVal dwReserved&)

#Region "Propiedades"
    Public Property FirmaConfig() As SaveConfigArchivos
        Get
            Return m_strFirmaConfig
        End Get
        Set(ByVal Value As SaveConfigArchivos)
            m_strFirmaConfig = Value
        End Set
    End Property
#End Region


#Region "Variables Miembros"

    Private oCierreDia As CierreDia

    Private oAjusteMgr As AjusteGeneralTallaManager

    Private oCierreDiasMgr As CierreDiaManager

    Private oCatalogoAlmaceMgr As CatalogoAlmacenesManager

    Private oGenerarPoliza As GenerarPoliza

    Private oGenerarArchTrans As GenerarArch

    Private dsDataSet As DataSet

    Private oUserSession As String = String.Empty

    Dim dtValeCajaReport As New DataTable("ValesCaja")

    Dim strConnectionString As String = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString

    Dim oSapMgr As ProcesoSAPManager

    Dim oFingerPMgr As FingerPrintManager

#End Region

#Region "Métodos Privados"

    Private Sub Sm_Inicializar()

        oGenerarPoliza = New GenerarPoliza(oAppContext)

        oCierreDiasMgr = New CierreDiaManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        oGenerarArchTrans = New GenerarArch(oAppContext)

        oCatalogoAlmaceMgr = New CatalogoAlmacenesManager(oAppContext)

        oAjusteMgr = New AjusteGeneralTallaManager(oAppContext)

        oSapMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)

        oFingerPMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)

        ebFecha.Value = Now.Date

    End Sub

    Private Sub Sm_Finalizar()

        oGenerarPoliza = Nothing

        oCierreDia = Nothing

        oCierreDiasMgr = Nothing

        oAjusteMgr = Nothing

        oFingerPMgr = Nothing

    End Sub

    Private Function Fm_bolTxtValidar() As Boolean

        '----------------------------------------------------------------------------------------------------------------------------------------
        'Si la caja no es la numero 1
        '----------------------------------------------------------------------------------------------------------------------------------------
        If (CInt(oAppContext.ApplicationConfiguration.NoCaja) <> 1) Then
            MessageBox.Show("Solo es posible cerrar día desde la caja 01", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If (oCierreDiasMgr.ValidarCierreDia(ebFecha.Value) = False) Then

            MsgBox("El Cierre de este día ya fue realizado.", MsgBoxStyle.Exclamation, "DPTienda.")
            ebFecha.Focus()

            Return False

        End If

        If (oCierreDiasMgr.ValidarCajasCerradas(ebFecha.Value) = False) Then

            MsgBox("No es posible realizar el Cierre del Día debido a que hay cajas sin cerrar.", MsgBoxStyle.Exclamation, "DPTienda.")

            Return False

        End If

        If (oCierreDiasMgr.ValidarInicioDia(ebFecha.Value) <= 0) Then

            MsgBox("No es posible realizar el Cierre del Día debido a que no lo ha iniciado.", MsgBoxStyle.Exclamation, "DPTienda.")
            Me.ebFecha.Focus()
            Return False

        End If

        Return True

    End Function

    '------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 23/12/2014: Envio de correos por problemas del cierre del día por las compensaciones
    '------------------------------------------------------------------------------------------------------------------
    ' JNAVA (02.11.2015): Se comento para ponerlo en el main module
    '------------------------------------------------------------------------------------------------------------------
    'Private Sub EnviarCorreos(ByVal mensaje As String, Optional ByVal Actualizacion As Boolean = False)
    '    Dim mmMail As New MailMessage
    '    Dim objSmtpServer As SmtpMail
    '    Dim strTo As String = ""
    '    Dim strMail As String = "", strSubject As String = "", strBody = ""
    '    '------------------------------------------------------------------------------------------------------------------------------
    '    ' JNAVA (02.11.2015): Agregamos validacion por si es actualizacion
    '    '------------------------------------------------------------------------------------------------------------------------------
    '    If oConfigCierreFI.EvitarCierreDia = True Or Actualizacion = True Then
    '        '------------------------------------------------------------------------------------------------------------------------------
    '        'FLIZARRAGA 23/12/2014: Agregamos los correos de los encargados del cierre del dia
    '        '------------------------------------------------------------------------------------------------------------------------------
    '        For Each strMail In oConfigCierreFI.MailCierreDia
    '            If Not strMail Is Nothing AndAlso strMail.Trim <> "" Then
    '                strTo &= strMail.Trim & ";"
    '            End If
    '        Next

    '        '------------------------------------------------------------------------------------------------------------------------------
    '        ' JNAVA (02.11.2015): Validamos si es actualizacion para cambiar textos
    '        '------------------------------------------------------------------------------------------------------------------------------
    '        If Actualizacion Then
    '            strSubject = "Error en la Actualización del Dportenis PRO en el almacén: " & oAppContext.ApplicationConfiguration.Almacen
    '            strBody = mensaje
    '        Else
    '            strSubject = "Hubo problemas en el cierre del día en el almacén: " & oAppContext.ApplicationConfiguration.Almacen
    '            strBody = "Hubo problemas al cierre del día este es el log del error: " & mensaje
    '        End If

    '        mmMail.From = oConfigCierreFI.CuentaCorreo.Trim
    '        mmMail.To = strTo

    '        '------------------------------------------------------------------------------------------------------------------------------
    '        ' JNAVA (02.11.2015): Modificado para enviar mensaje segun el tipo de error (Cierre ó Actualización)
    '        '------------------------------------------------------------------------------------------------------------------------------
    '        mmMail.Subject = strSubject '"Hubo problemas en el cierre del día en el almacen: " & oAppContext.ApplicationConfiguration.Almacen
    '        mmMail.Body = strBody '"Hubo problemas al cierre del día este es el log del error: " & mensaje

    '        objSmtpServer.SmtpServer = oConfigCierreFI.ServidorSMTP
    '        Try
    '            objSmtpServer.Send(mmMail)
    '        Catch ex As Exception
    '            EscribeLog(ex.ToString, "Error al enviar los correos del cierre de día")
    '        End Try
    '    End If
    'End Sub

    Private Function Sm_GuardarCierreDia() As Boolean
        'TODO earagon: Descomentar
        If (Fm_bolTxtValidar() = False) Then

            'Exit Function
            Return False

        End If
        'RestService = New ProcesosRetail("/pos/sorr", "POST")
        'Dim valido As Boolean = RestService.SapZSerialsReferencias(Date.Now)
        'If valido = False Then
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Facturas No Guardadas en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.FacturaSelDontSaved.Tables(0).Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Facturas Canceladas No Guardads en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.FacturaCANSelDontSaved.Tables(0).Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Cancelaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '''Facturas SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        ''Apartados, Cancelar Apartados, Abonos Apartados, Abonos a Apartados no registrados
        '1. - Este el Primero a Mandar a Llamar
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLApartadosSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos Apartados no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        '2. - Este el Segundo a Mandar a Llamar
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLAbonosApartadosSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos Abonos de Apartados no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        '3. - Este el Tercero a Mandar a Llamar
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLApartadosCanceladosSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos Apartados Cancelados no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        '4. - Este el Cuarto a Mandar a Llamar
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLAbonosApartadosCanceladosSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos Abonos Apartados Cancelados no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Abonos a Credito Directo no guardados en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLAbonosCDTSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos AbonosCDT no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Notas de Credito no Guardadas en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oCierreDiasMgr.ReadSQLNotasCreditoSinRegSAP.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Notas de Credito no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Ajustes de Talla Automaticos no Guardados en SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'If oAjusteMgr.LoadAjustesPendientesAllNC.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunos Ajustes de Talla Automáticos no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If

        Dim strMensaje As String = ""
        'strMensaje = Me.ValidarFacturasDPValeEnSAP()
        'If strMensaje.Trim <> "" Then
        '    MessageBox.Show(strMensaje, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    EnviarCorreos(strMensaje)
        '    EscribeLog(strMensaje, "El cierre del día no se realizo correctamente en SAP")
        '    'Return False
        '    'Exit Function
        'End If
        strMensaje = Me.ValidarPedidosNoGuardadosEnSAP()
        If strMensaje.Trim() <> "" Then
            MessageBox.Show(strMensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            EnviarCorreos(strMensaje)
            EscribeLog(strMensaje, "Facturas no guardadas en SAP")
            If oConfigCierreFI.EvitarCierreDia Then
                Exit Function
            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        'Pedidos EC pendientes por surtir, por facturar, por asignar guia o por cancelar
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.SurtirEcommerce AndAlso ValidarPedidosEC() = False Then
            Return False
            Exit Function
        End If
        '-------------------------------------------------------------------------------------------------------------------
        'JNAVA (04/06/2013): Validacion de Citas sin Concretar
        '-------------------------------------------------------------------------------------------------------------------
        If FacturacionSiHay = 1 Or FacturacionSiHay = 2 Or FacturacionSiHay = 3 Then
            Dim strMsg As String = ValidarCitaSiHay()
            If (strMsg <> "") Then
                MsgBox("No es posible realizar el Cierre del Día debido a que no se ha realizado el Reembolso de los siguientes Pedidos Insurtibles: " & vbCrLf & vbCrLf & strMsg, MsgBoxStyle.Exclamation, "DPTienda.")
                Me.ebFecha.Focus()
                Return False
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (12/06/2013) - Pedidos Si Hay pendientes por surtir, por facturar, por asignar guia, por cancelar o por reembolsar
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            'RGERMAIN 10.06.2015: Se agrego a las validaciones que revise si existen Pedidos SH sin Folio SAP
            '---------------------------------------------------------------------------------------------------------------------------------
            If Not ValidarPedidosSiHay() Then
                Return False
                Exit Function
            End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (20/06/2013) - Validamos los pedidos cancelados en las que sus facturas aun no estan canceladas
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------
            If Not ValidarPedidosCanceladosSiHay() Then
                Return False
                Exit Function
            End If
        End If

        oCierreDia = Nothing
        oCierreDia = oCierreDiasMgr.Create
        With oCierreDia

            .Fecha = ebFecha.Value
            .Usuario = UCase(oUserSession)

        End With
        ' ''---------------------------------------------------
        ' ''Generar el Archivo de Cierre de Dia
        Dim dsVentas As DataSet
        Dim strResult As String
        'Dim strMensaje As String = ""
        ''dsVentas = oCierreDiasMgr.VentasTienda(ebFecha.Value)

        ''---------------------------------------------------------------------------------------------------------------------------------------------------------
        ''Funcion para cobranza  VALE de CAJA de DPVALE
        ''---------------------------------------------------------------------------------------------------------------------------------------------------------
        'strResult = oCierreDiasMgr.VentasTiendaUpVCDPVL(ebFecha.Value, strMensaje)
        ''Se valida si se subieron todas , sino no, no permite hacer el cierre de día
        'If strResult = "N" Then
        '    If oConfigCierreFI.EvitarCierreDia Then
        '        EnviarCorreos("No se puede hacer el cierre de día. La Compensación de Vale de Caja DPVL no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje)
        '        EscribeLog("No se puede hacer el cierre de día. La Compensación de Vale de Caja DPVL no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje, "Compensación de Vale de Caja DPVL")
        '    Else
        '        MessageBox.Show("No se puede hacer el cierre de día. La Compensación de Vale de Caja DPVL no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '        Exit Function
        '    End If
        'ElseIf strResult = "" Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        ''VDPVLVDPVLVDPVLVDPVLVDPVLVDPVLVDPVLVDPVLVDPVLVDPVLVDPVL


        ''VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV
        ''Funcion para cobranza  VALE de CAJA
        'strResult = oCierreDiasMgr.VentasTiendaUpVC(ebFecha.Value, strMensaje)
        ''Se valida si se subieron todas , sino no, no permite hacer el cierre de día
        'If strResult = "N" Then
        '    If oConfigCierreFI.EvitarCierreDia Then
        '        EnviarCorreos("No se puede hacer el cierre de día. La Compensación de Vale de Caja no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje)
        '        EscribeLog(strMensaje, "Compensación de Vale de Caja")
        '    Else
        '        MessageBox.Show("No se puede hacer el cierre de día. La Compensación de Vale de Caja no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '        Exit Function
        '    End If
        'ElseIf strResult = "" Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        ''VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV





        ''CANCAPARCANCAPARCANCAPARCANCAPARCANCAPARCANCAPARCANCAPAR

        ''Funcion para cobranza  VALE de CAJA
        'strResult = oCierreDiasMgr.VentasTiendaUpVCCANCAPAR(ebFecha.Value, strMensaje)
        ''Se valida si se subieron todas , sino no, no permite hacer el cierre de día
        'If strResult = "N" Then
        '    EscribeLog(strMensaje, "La compensación de Vale de Caja por CA fallo")
        '    If oConfigCierreFI.EvitarCierreDia Then
        '        EnviarCorreos("No se puede hacer el cierre de día. La Compensación de Vale de Caja por CA no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje)
        '        'EscribeLog(strMensaje, "La compensación de Vale de Caja por CA fallo")
        '    Else
        '        MessageBox.Show("No se puede hacer el cierre de día. La Compensación de Vale de Caja por CA no se realizo en SAP. Favor de Llamar a SOPORTE." _
        '        & vbCrLf & vbCrLf & strMensaje, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '        Exit Function
        '    End If
        'ElseIf strResult = "" Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        'CANCAPARCANCAPARCANCAPARCANCAPARCANCAPARCANCAPARCANCAPAR

        'Realizamos la descarga de la cobranza de SAP
        Dim ofrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        ofrmProcesoSAP.bMostrarMensaje = False
        ofrmProcesoSAP.ShowDev("Cobranza")
        ofrmProcesoSAP.Dispose()
        ofrmProcesoSAP = Nothing

        'CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        'Funcion Cobranza Up
        strResult = oCierreDiasMgr.VentasTiendaUp(ebFecha.Value, strMensaje)
        'strResult = "N"
        'Se valida si se subieron todas , sino no, no permite hacer el cierre de día
        If strMensaje.Trim() <> "" Then
            'MsgBox("Se envia a correo")
            EnviarCorreos("El cierre del día no se realizo correctamente en SAP. Favor de Llamar a SOPORTE." _
                & vbCrLf & vbCrLf & strMensaje)
            EscribeLog(strMensaje, "El cierre del día no se realizo correctamente en SAP")
            'If oConfigCierreFI.EvitarCierreDia Then
            '    EnviarCorreos("No se puede hacer el cierre de día no se realizo correctamente en SAP. Favor de Llamar a SOPORTE." _
            '    & vbCrLf & vbCrLf & strMensaje)
            '    EscribeLog(strMensaje, "El cierre del día no se realizo correctamente en SAP")
            'Else
            '    MessageBox.Show("No se puede hacer el cierre de día. La COBRANZA no se Almacenó Correctamente en SAP. Favor de Llamar a SOPORTE." _
            '    & vbCrLf & vbCrLf & strMensaje, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return False
            '    Exit Function
            'End If
        End If
        'If strResult = "N" Then

        'ElseIf strResult = "" Then
        '    MessageBox.Show("No se puede hacer el cierre de día." & vbCrLf & " Algunas Facturas no se Almacenaron en SAP.", "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        '    Exit Function
        'End If
        'CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

        ''Verificamos que realmente se haya subido la cobranza
        'If oCierreDiasMgr.ValidarCierreDiaCobranza(CDate(Me.ebFecha.Value)) = False Then
        '    If oConfigCierreFI.EvitarCierreDia Then
        '        '----------------------------------------------------------------------------------------------
        '        'JNAVA (30.01.2015): Se comento por que anteriormente ya se mando con el error de SAP
        '        '----------------------------------------------------------------------------------------------
        '        'EnviarCorreos("No se puede hacer el cierre de día. No se registró completamente la cobranza." & vbCrLf & "Realize la descarga de cobranza e intente hacer el cierre de dia de nuevo")
        '        EscribeLog("No se puede hacer el cierre de día. No se registró completamente la cobranza." & vbCrLf & "Realize la descarga de cobranza e intente hacer el cierre de dia de nuevo", "Error en el cierre de día al subir la cobranza")
        '    Else
        '        MessageBox.Show("No se puede hacer el cierre de día. No se registró completamente la cobranza." & vbCrLf & "Realize la descarga de cobranza e intente hacer el cierre de dia de nuevo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Return False
        '        Exit Function
        '    End If
        'End If

        ''Guardar en SAP los archivos Polizas
        '*/*/*Se comento por que algunos archivos no se subian completos 
        'If Not oCierreDiasMgr.EjecutarZBAPIFI05_VENTASDIA(ebFecha.Value) Then
        ''Si no se carga Correctamente mandar mensajes
        'MessageBox.Show("No se cargo correctamente el Archivo de Cierre de Día en SAP Favor de Avisar a SOPORTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        '*/*/*
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        'Funcion para cobranza  Abonos
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        'strResult = oCierreDiasMgr.VentasTiendaUpAB(ebFecha.Value, strMensaje)
        'If strResult = "" Then
        '    If oConfigCierreFI.EvitarCierreDia Then
        '        EnviarCorreos("Error al compensar los abonos " & strMensaje)
        '        EscribeLog("Error al compensar los abonos " & strMensaje, "Error al compensar los abonos")
        '    Else
        '        MessageBox.Show("No se puede hacer el cierre de día. No se registró completamente la cobranza." & vbCrLf & "Realize la descarga de cobranza e intente hacer el cierre de dia de nuevo", "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Return False
        '        Exit Function
        '    End If
        'End If
        'Se valida si se subieron todas , sino no, no permite hacer el cierre de día
        'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 15.07.2013: Funcion para crear los SA en SAP a partir de los pagos DZ de los Pedidos Si Hay
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        If FacturacionSiHay = 1 Or FacturacionSiHay = 2 Or FacturacionSiHay = 3 Then
            '-------------------------------------------------------------------------------------------------
            ' JNAVA (15.03.2017): Se comenta por que ya no se usará
            '-------------------------------------------------------------------------------------------------
            'Try
            '    'Dim result As New Dictionary(Of String, Object)
            '    'RestService.Metodo = "/pos/sh"
            '    'result = RestService.SapZshCierre(Me.ebFecha.Value, oSapMgr.Read_Centros())
            '    'strResult = CStr(result("E_Error"))
            '    strResult = oSapMgr.ZSH_CIERRE(Me.ebFecha.Value)
            '    If strResult.Trim <> "" AndAlso oConfigCierreFI.ValidaCierreSH Then
            '        MessageBox.Show("No se puede hacer el cierre de día. La creacion de SA de los pedidos Si Hay no se realizó correctamente en SAP. Favor de Llamar a SOPORTE." _
            '                        & vbCrLf & vbCrLf & strResult, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        'Return False
            '        'Exit Function
            '    End If
            'Catch ex As Exception
            '    EscribeLog(ex.ToString, "Ocurrio un error al crear los SA de los pedidos Si Hay")
            '    MessageBox.Show("Ocurrió un error al crear SA en los pedidos Si Hay.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    'Return False
            '    'Exit Function
            'End Try
            '-------------------------------------------------------------------------------------------------

            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            'JNAVA (24/06/2013): FUNCION PARA COMPENSAR PEDIDOS SI HAY
            '---------------------------------------------------------------------------------------------------------------------------------------------------------
            Try
                strResult = oCierreDiasMgr.CompensarPedidosSiHay(Me.ebFecha.Value)
                If strResult.Trim <> "" AndAlso oConfigCierreFI.ValidaCierreSH Then
                    MessageBox.Show("No se puede hacer el cierre de día. La COMPENSACIÓN DE PEDIDOS SI HAY no se realizó correctamente en SAP. Favor de Llamar a SOPORTE." _
                                    & vbCrLf & vbCrLf & strResult, "DPTienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Return False
                    'Exit Function
                End If
            Catch ex As Exception
                EscribeLog(ex.ToString, "Ocurrio un error al compensar los pedidos Si Hay")
                MessageBox.Show("Ocurrió un error al compensar los pedidos Si Hay.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Return False
                'Exit Function
            End Try
        End If

        'Guarda el cierre de dia en las tablas locales
        oCierreDia.Save()



        ''''Emviar correo a Raul Quiroz de las capturas manuales (Comentado por Solicitud de Raul).
        '''Dim dsMotivos As New DataSet
        '''dsMotivos = oCierreDiasMgr.SelectMotivosFac(Me.ebFecha.Value, Me.ebFecha.Value, "TODOS")

        '''If dsMotivos.Tables(0).Rows.Count > 0 Then
        '''    'Genero el archivo TXT 
        '''    Dim strruta As String = ""
        '''    Dim strArchivo As String = ""
        '''    strruta = "C:\CapturaManual  " & oAppContext.ApplicationConfiguration.Almacen & "  " & Replace(Date.Today.ToShortDateString & ".txt", "/", "-")
        '''    strArchivo = "CapturaManual  " & oAppContext.ApplicationConfiguration.Almacen & "  " & Replace(Date.Today.ToShortDateString & ".txt", "/", "-")

        '''    Dim txtWriter As New System.IO.StreamWriter(strruta, False)
        '''    'txtWriter.WriteLine(Chr(13))
        '''    'Pongo el encabezado
        '''    txtWriter.WriteLine("SUCURSAL:" & oAppContext.ApplicationConfiguration.Almacen & "     FECHA:" & Date.Today.ToShortDateString)
        '''    txtWriter.WriteLine(Chr(13))
        '''    txtWriter.WriteLine(Chr(13))
        '''    txtWriter.WriteLine("CODIGO UPC               ARTICULO            TALLA     MOVIMIENTO     DESCRIPCION DEL MOTIVO")

        '''    'Pongo los articulos en el archivo txt
        '''    For Each oRowCorreo As DataRow In dsMotivos.Tables(0).Rows
        '''        txtWriter.WriteLine(CStr(oRowCorreo.Item("CodUpc")).PadRight(25, "") & CStr(oRowCorreo.Item("Articulo")).PadRight(20, "") & CStr(oRowCorreo.Item("Talla")).PadRight(10, "") & CStr(oRowCorreo.Item("TipoMovto")).PadRight(15, "") & oRowCorreo.Item("Descripcion"))
        '''    Next

        '''    txtWriter.Close()
        '''    txtWriter = Nothing


        '''    'Mando el correo
        '''    Dim mmMail As New MailMessage
        '''    Dim objSmtpServer As SmtpMail
        '''    Dim strTo As String = ""

        '''    For i As Integer = 0 To FirmaConfig.CuentasCorreoUPC.Length - 2
        '''        strTo &= FirmaConfig.CuentasCorreoUPC(i)
        '''        If i < FirmaConfig.CuentasCorreoUPC.Length - 2 Then
        '''            strTo &= ";"
        '''        End If
        '''    Next

        '''    mmMail.From = FirmaConfig.CuentaCorreo
        '''    mmMail.To = strTo
        '''    'mmMail.To = "Raul.Quiroz@dportenis.com.mx"
        '''    'mmMail.Cc = "beny.rios@dportenis.com.mx"
        '''    mmMail.Subject = "Codigos UPC con Captura Manual en sucursal " & oAppContext.ApplicationConfiguration.Almacen & " con fecha " & Date.Today.ToShortDateString
        '''    mmMail.Body = "En al archivo adjunto vienen el Codigo UPC, el codigo del Articulo y su Talla, Tipo de movimiento y la descripcion del motivo de la captura manual."
        '''    Dim oAttachment As MailAttachment = New MailAttachment(strruta)
        '''    mmMail.Attachments.Add(oAttachment)
        '''    objSmtpServer.SmtpServer = FirmaConfig.ServidorSMTP
        '''    Try
        '''        objSmtpServer.Send(mmMail)
        '''        If File.Exists(strruta) Then
        '''            File.Delete(strruta)
        '''        End If
        '''    Catch ex As Exception
        '''        MessageBox.Show("No se pudo enviar correo de Codigos UPC con Captura Manual." & Microsoft.VisualBasic.vbCrLf & "Favor de enviarlo manualmente a Raul Quiroz." & Microsoft.VisualBasic.vbCrLf & Microsoft.VisualBasic.vbCrLf & "La ruta es C:\" & Microsoft.VisualBasic.vbCrLf & "Archivo:" & strArchivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '''    End Try

        '''End If

        'TODO earagon: Descomentar
        'Dim strPedSap As String = ValidarPedidosNoGuardados()
        'If strPedSap.Trim() <> "" Then
        '    MessageBox.Show("No se pudo realizar el cierre del día debido a que estos pedidos no se compesaron" & vbCrLf & strPedSap, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
test:
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Imprimimos reportes de cierre de dia
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        Sm_ActionPrintReporteCierredeDia()
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Impresion del Concentrado
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        ImprimirConcentrado()
        'Exit Function
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Enviamos las ventas con tarjeta de credito y los totales al servidor
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        Try
            EnviarVentasTACR(Me.ebFecha.Value)
            EnviarTotales(Me.ebFecha.Value)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Ocurrio un error al enviar la información para los reportes de comisiones y ventas totales.")
            MessageBox.Show("Ocurrió un error al enviar la información para los reportes de comisiones y ventas totales.", "Dportenis Pro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Enviar ventas tipo venta PG al servidor
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        Try
            If oConfigCierreFI.UsarHuellas Then
                EnviarFacturasPG(Me.ebFecha.Value)
            End If
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al enviar las Ventas,Cancelaciones,Notas de credito o Formas de Pago al servidor")
        End Try
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 26.09.2015: Se envia la informacion de usuarios y roles al servidor central para cuestiones de auditoria y revision de los mismos
        '------------------------------------------------------------------------------------------------------------------------------------------------------
TestEnvio:
        Try
            ReplicarUsersRoles()

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al enviar los usuarios y roles al servidor central")
        End Try
        'Exit Function
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Respaldo de la Base de datos del Dportenis Pro
        '------------------------------------------------------------------------------------------------------------------------------------------------------
        Try
            If Not Directory.Exists("C:\RespaldoSQL") Then
                Directory.CreateDirectory("C:\RespaldoSQL")
            End If
            oCierreDiasMgr.RespaldoBDDportenisPRO("C:\RespaldoSQL")
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al realizar el respaldo de la BD de SQL")
            'MsgBox("Ocurrió un error al generar el respaldo.", MsgBoxStyle.Exclamation, "Dportenis Pro")
        End Try

        Dim oAlmacen As Almacen
        oAlmacen = oCatalogoAlmaceMgr.Load(oSapMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)
        Try
            ''----------------CIERRE DE DIA SISTEMA GERENCIAL
            Dim negGer As NegGerencial
            negGer = New EmpGerInt.NegGerencial(oAppContext.ApplicationConfiguration.DataStorageConfiguration.Server, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.Database, _
                                                        oAppContext.ApplicationConfiguration.DataStorageConfiguration.User, _
                                                       oAppContext.ApplicationConfiguration.DataStorageConfiguration.Password)
            negGer.CerrarDia(Date.Now.Date, "\ReportesGerencial", oAlmacen.Descripcion, oAlmacen.ID)
            ''----------------CIERRE DE DIA SISTEMA GERENCIAL
        Catch ex As Exception
            MessageBox.Show("Falta capturar las metas en Gerencial.", "Gerencial", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        '''Para quitar menús
        Me.DialogResult = DialogResult.OK

        Return True
    End Function

    Private Function ValidarTrasladosEnviadosEC(ByVal Pedido As String, ByRef EsConcentracion As Boolean) As Boolean

        Dim oRow As DataRowView
        Dim Centro As String = oSapMgr.Read_Centros()
        Dim dvConcen As DataView
        Dim dtTemp As DataTable
        Dim bRes As Boolean = True

        EsConcentracion = False

        dtTemp = oSapMgr.ZPOL_CHK_CONCENTRA(Pedido.Trim)

        dvConcen = New DataView(dtTemp, "PuestoExpedicion = '" & Centro.Trim & "'", "", DataViewRowState.CurrentRows)
        '---------------------------------------------------------------------------------------------------------------------------
        'Si es concentracion hay que revisar que todos los centros que participan ya hayan enviado sus respectivos traslados
        '---------------------------------------------------------------------------------------------------------------------------
        If Not dvConcen Is Nothing AndAlso dvConcen.Count > 1 Then
            EsConcentracion = True
            For Each oRow In dvConcen
                If CStr(oRow!PuestoExpedicion).Trim.ToUpper <> CStr(oRow!CESUM).Trim.ToUpper Then
                    If CStr(oRow!Guia).Trim = "" Then
                        bRes = False
                        Exit For
                    End If
                End If
            Next
        End If

        Return bRes

    End Function

    Private Function ValidarPedidosEC() As Boolean

        Dim bRes As Boolean = True
        Dim dtTempCab As DataTable
        Dim dtTempDet As DataTable
        'Dim dtTempTrasModif As DataTable
        Dim Pedidos As Integer = 0 ', Facturas As Integer = 0
        Dim Centro As String = oSapMgr.Read_Centros
        Dim oRow As DataRow
        Dim strFecha As String = ""

        '-----------------------------------------------------------------------------------------------------------------------------------
        'Revisamos los pedidos pendientes por surtir y por facturar
        '-----------------------------------------------------------------------------------------------------------------------------------
        dtTempCab = oSapMgr.ZPOL_TRASLPEN(Centro, dtTempDet) ', dtTempTrasModif)

        If Not dtTempCab Is Nothing AndAlso dtTempCab.Rows.Count > 0 Then
            For Each oRow In dtTempCab.Rows
                strFecha = CStr(oRow!Fecha_Creacion).Trim
                strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                If CStr(oRow!Status).Trim.ToUpper = "P" AndAlso CDate(strFecha).AddDays(oConfigCierreFI.DiasParaSurtirEC) <= Today Then 'OrElse dtTempTrasModif.Select("Traslado = '" & CStr(oRow!Folio_Traslado).Trim & "'").Length > 0 Then
                    Pedidos += 1

                    'ElseIf CStr(oRow!Facturar).Trim.ToUpper = "X" Then
                    '    '-----------------------------------------------------------------------------------------------------------------------------
                    '    'Si esta pendiente por facturar validamos que si es una concentración los demas centros ya hayan enviado sus traspasos o si no
                    '    'es una concentración solo que ya haya pasado los dias configurados desde la fecha de la petición de surtido
                    '    '-----------------------------------------------------------------------------------------------------------------------------                    
                    '    Dim bConcen As Boolean = False
                    '    Dim bEnviados As Boolean = False

                    '    bEnviados = ValidarTrasladosEnviadosEC(CStr(oRow!Folio_Pedido), bConcen)

                    '    If bConcen AndAlso bEnviados AndAlso CDate(strFecha).AddDays(oConfigCierreFI.DiasParaFacturarConcenEC) <= Today Then
                    '        Facturas += 1
                    '    ElseIf bConcen = False AndAlso CDate(strFecha).AddDays(oConfigCierreFI.DiasParaFacturarEC) <= Today Then
                    '        Facturas += 1
                    '    End If
                End If
            Next
        End If

        If Pedidos > 0 Then
            MessageBox.Show("No se puede hacer cierre de dia. Hay Pedidos de Ecommercependientes por surtir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
            'ElseIf Facturas > 0 Then
            '    MessageBox.Show("No se puede hacer cierre de dia. Hay Pedidos de Ecommerce pendientes por facturar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    bRes = False
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------
        'Revisamos los pedidos pendientes por asignar guia
        '-----------------------------------------------------------------------------------------------------------------------------------
        dtTempCab = Nothing

        dtTempCab = oSapMgr.ZPOL_VALIDA_TRAS_ENV(Centro)

        'If Not dtTempCab Is Nothing AndAlso dtTempCab.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer cierre de dia. Hay pedidos pendientes de asignar guía.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    bRes = False
        'End If

        '---------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (01.07.2016): Variable para obtener los pedidos sin guia que pasan de la fecha de envio configurado
        '---------------------------------------------------------------------------------------------------------------------------
        Dim PedidosSinGuia As String = String.Empty
        '---------------------------------------------------------------------------------------------------------------------------
        If Not dtTempCab Is Nothing AndAlso dtTempCab.Rows.Count > 0 Then
            Dim bPend As Boolean = True
            For Each oRow In dtTempCab.Rows
                '---------------------------------------------------------------------------------------------------------------------------
                'Si no tiene guia revisamos si ya esta facturado o si ya está surtido y ya tiene puesto de expedición al cual enviar para no
                'permitir hacer el cierre
                '---------------------------------------------------------------------------------------------------------------------------
                If (CStr(oRow!Facturar).Trim = "X" AndAlso CStr(oRow!Folio_Factura).Trim <> "") OrElse _
                (CStr(oRow!Facturar).Trim = "" AndAlso CStr(oRow!PuestoExpedicion).Trim <> "") Then
                    '---------------------------------------------------------------------------------------------------------------------------
                    'Revisamos si la solicitud de surtido ya tiene mas de los dias configurados para enviar, no permitir hacer el cierre
                    '---------------------------------------------------------------------------------------------------------------------------
                    strFecha = CStr(oRow!Fecha_Creacion).Trim
                    strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4)
                    If CDate(strFecha).AddDays(oConfigCierreFI.DiasParaEnviarEC) <= Today Then
                        bPend = False
                        '---------------------------------------------------------------------------------------------------------------------------
                        ' JNAVA (01.07.2016): Almacenamos los Pedidos perndientes por asignar guia y continuamos
                        '---------------------------------------------------------------------------------------------------------------------------
                        PedidosSinGuia &= " - " & CStr(oRow!FOLIO_PEDIDO).Trim & vbCrLf
                        'Exit For
                    End If
                End If
            Next

            '---------------------------------------------------------------------------------------------------------------------------
            ' JNAVA (01.07.2016): Agregamos en el mensaje los folios de los pedidos perndientes por asignar guia.
            '---------------------------------------------------------------------------------------------------------------------------
            If bPend = False Then
                MessageBox.Show("No se puede hacer cierre de dia. Los siguientes Pedidos de Ecommerce están pendientes de asignar guía:" & vbCrLf & vbCrLf & PedidosSinGuia.TrimEnd(vbCrLf), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bRes = False
            End If
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------
        'Revisamos los pedidos pendientes por cancelar
        '-----------------------------------------------------------------------------------------------------------------------------------
        'dtTempCab = Nothing

        'dtTempCab = oSapMgr.ZPOL_PEDIDOSCANCELADOS(dtTempDet)

        'If Not dtTempCab Is Nothing AndAlso dtTempCab.Rows.Count > 0 Then
        '    MessageBox.Show("No se puede hacer cierre de dia. Hay pedidos pendientes de cancelar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    bRes = False
        'End If

        Return bRes

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 22/06/2016: Validar facturas no creadas en SAP, pero que si estan en el dppro
    '------------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarPedidosNoGuardadosEnSAP() As String
        Dim strMensaje As String = ""
        Dim lstPedidos As New List(Of Dictionary(Of String, Object))
        'Dim dtFacturas As DataTable = oCierreDiasMgr.GetFacturasSinDPVale(Me.ebFecha.Value) ', Me.ebFecha.Value)
        Dim dtFacturas As DataTable = oCierreDiasMgr.GetFacturas(Me.ebFecha.Value, Me.ebFecha.Value)
        'Dim dtFacturasSAP As DataTable = oSapMgr.ZSD_VALIDA_PEDIDOS(Me.ebFecha.Value) ', Me.ebFecha.Value)
        Dim dtFacturasSAP As DataTable = oSapMgr.ZSD_VALIDA_PEDIDOS(Me.ebFecha.Value, Me.ebFecha.Value)
        Dim FormaPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
        Dim dtFormasPago As DataTable
        Dim rows() As DataRow = Nothing
        Dim refPRO As String = ""
        Dim refSAP As String = ""
        For Each rowPRO As DataRow In dtFacturas.Rows
            refPRO = CStr(rowPRO("Referencia")).Trim()
            rows = dtFacturasSAP.Select("BSTNK='" & refPRO & "'", "")
            If rows.Length = 0 Then
                FormaPago.ClearFields()
                dtFormasPago = FormaPago.Load(CInt(rowPRO("FacturaId"))).Tables(0)
                If CreateOrder(rowPRO, dtFormasPago) = False Then
                    strMensaje &= "Factura No Guardada: " & CStr(rowPRO("Referencia")) & vbCrLf
                End If
            End If
        Next
        Return strMensaje
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 14/09/2016: Validar facturas no creadas en SAP, pero que si estan en el dppro
    '------------------------------------------------------------------------------------------------------------------------------------

    Public Function ValidarPedidosNoGuardados() As String
        Dim strMensaje As String = ""
        Dim lstPedidos As New List(Of Dictionary(Of String, Object))
        Dim dtFacturas As DataTable = oCierreDiasMgr.GetFacturasSinDPVale(Me.ebFecha.Value) ', Me.ebFecha.Value)
        Dim dtFacturasSAP As DataTable = oSapMgr.ZSD_VALIDA_PEDIDOS(Me.ebFecha.Value) ', Me.ebFecha.Value)
        Dim FormaPago As New DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.FacturaFormaPago(oAppContext)
        Dim dtFormasPago As DataTable
        Dim rows() As DataRow = Nothing
        Dim refPRO As String = ""
        Dim refSAP As String = ""
        For Each rowPRO As DataRow In dtFacturas.Rows
            refPRO = CStr(rowPRO("Referencia")).Trim()
            rows = dtFacturasSAP.Select("BSTNK='" & refPRO & "'", "")
            If rows.Length = 0 Then
                strMensaje &= "Pedido con referencia: " & refPRO & vbCrLf
            End If
        Next
        Return strMensaje
    End Function

    Private Function CreateOrder(ByVal row As DataRow, ByVal FormasPago As DataTable) As Boolean
        Dim valido As Boolean = False
        Dim oProcesarVenta As New Dictionary(Of String, Object)
        Dim FactMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim response As New Dictionary(Of String, Object)
        Try
            Dim oFactura As Factura = FactMgr.Create()
            FactMgr.LoadInto(CInt(row("FacturaId")), oFactura)
            Dim serial As String = FactMgr.GetSerialByFacturaId(oFactura.FacturaID)
            oFactura.SerialId = serial
            With oProcesarVenta
                .Add("I_FECHA_CREACION", Format(oFactura.Fecha, "yyyy-MM-dd"))
                If oFactura.CodTipoVenta = "S" OrElse oFactura.CodTipoVenta = "D" Then
                    .Add("I_SOLICITANTE", oFactura.ClienteId)
                Else
                    .Add("I_SOLICITANTE", "")
                End If
                Dim CatalogoTipoVenta As New DportenisPro.DPTienda.ApplicationUnits.CatalogoTipoVenta.CatalogoTipoVentaManager(oAppContext)

                Dim MotivoPedido As String = ""
                .Add("I_REQUIERE_FACTURA", "")
                .Add("I_COSTO_ENVIO", 0)
                .Add("I_REFERENCIA", oFactura.Referencia)
                .Add("I_OFICINAVENTAS", "T" & oAppContext.ApplicationConfiguration.Almacen)
                If oFactura.CodTipoVenta = "A" Then
                    .Add("I_MOT_PEDIDO", "ZAF")
                Else
                    MotivoPedido = CatalogoTipoVenta.GetMotivoPedidoByTipoVenta(oFactura.CodTipoVenta)
                    .Add("I_MOT_PEDIDO", MotivoPedido)
                End If
                .Add("I_CLASEDOC", "")
                .Add("I_CANAL", "10")
                .Add("I_CEBE", "")
                .Add("I_CENTRO", "")
                .Add("I_GPOVENDEDOR", "")
                .Add("I_ORGVENTAS", "")
                .Add("I_SECTOR", "")
                .Add("I_VERSION_ID", "")
                .Add("I_REP_VENTAS", oFactura.CodVendedor)
                If oFactura.CodTipoVenta = "E" Then
                    Dim valeEmpleado As ValeEmpleado = FactMgr.GetValeEmpleado(oFactura.FacturaID)
                    .Add("I_FOLIO", valeEmpleado.Serie & "|" & valeEmpleado.Folio)
                Else
                    .Add("I_FOLIO", "")
                End If
                .Add("I_HORA", "")
                .Add("I_USUARIO", "")
                .Add("I_PLAZA", "")
                .Add("I_MONTO_TOTAL", 0)
                .Add("I_SERIALID", oFactura.SerialId)
                ' ------------------------------------------------------------------
                ' Llenamos datos de las Formas de Pago 
                '------------------------------------------------------------------
                Dim oFormasPago As New List(Of Dictionary(Of String, Object))
                Dim ImporteSeguro As Decimal = 0
                For Each oRow As DataRow In FormasPago.Rows
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oPago As New Dictionary(Of String, Object)
                    With oPago
                        .Add("FORMA_PAGO", oRow!CodFormasPago)
                        .Add("IMPORTE", CDec(oRow!MontoPago).ToString("##,##0.00").Replace(",", ""))
                        .Add("REFERENCIA", "")
                        .Add("FOLIO", "")
                        .Add("PER_FINANC", "")
                        .Add("NUM_APROBACION", "")
                        If oFactura.CodTipoVenta = "V" Then
                            Dim infoVale As Dictionary(Of String, Object) = FactMgr.GetInfoDetalleDPValeByFormaPago(CInt(oRow!FormaPagoID))
                            .Add("NUMVA", CStr(infoVale("DPValeID")).PadLeft(10, "0"))
                            .Add("NUMDE", CInt(infoVale("Numde")))
                            .Add("DISTRIB", CStr(infoVale("Distribuidor")).PadLeft(10, "0"))
                            .Add("CTEDIST", CStr(infoVale("Ctefinal")).PadLeft(10, "0"))
                            .Add("PARES_PZAS", CInt(infoVale("ParesPza")))
                            .Add("MONTO_UTILIZADO", CDec(infoVale("MontoUtilizado")).ToString("##,##0.00").Replace(",", ""))
                            .Add("MONTODPVALE", CDec(infoVale("MontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                            .Add("FECCO", CDate(infoVale("Fecco")).ToString("yyyyMMdd"))
                            If CBool(infoVale("Revale")) Then
                                .Add("REVALE", "X")
                            Else
                                .Add("REVALE", "")
                            End If
                            '----------------------------------------------------------------------------------------------------------
                            'FLIZARRAGA 05/05/2016: Se comento los RPAREZ_PZA porque no se ocupaba.
                            '----------------------------------------------------------------------------------------------------------
                            '.Add("RPARES_PZAS", oDpvaleSAP.RPARES_PZAS)
                            .Add("RMONTODPVALE", CDec(infoVale("RMontoDPVale")).ToString("##,##0.00").Replace(",", ""))
                            'If oConfigCierreFI.GenerarSeguro Then
                            '    Dim DataSecure As New Hashtable()
                            '    DataSecure("I_NUMVA") = CStr(infoVale("DPValeID")).PadLeft(10, "0")
                            '    DataSecure("I_KUNNR") = CStr(infoVale("Distribuidor")).PadLeft(10, "0")
                            '    If oConfigCierreFI.GenerarSeguro Then
                            '        DataSecure("I_ZSEG") = "1"
                            '    Else
                            '        DataSecure("I_ZSEG") = "0"
                            '    End If
                            '    DataSecure("I_FECCO") = CDate(infoVale("Fecco")).ToString("yyyyMMdd")
                            '    DataSecure("I_NUMDE") = CInt(infoVale("Numde"))
                            '    If oSapMgr.ZDPVL_VALSEGUROSAFS(DataSecure) = True Then
                            '        oFactura.SeguroVidaSAPDPVL = True
                            '        ImporteSeguro = CDec(infoVale("Impseg"))
                            '        .Add("ZSEG", "1")
                            '    Else
                            '        oFactura.SeguroVidaSAPDPVL = False
                            '        ImporteSeguro = 0
                            '        .Add("ZSEG", "0")
                            '    End If
                            'Else
                            '    .Add("ZSEG", "0")
                            'End If
                            .Add("ZSEG", "0")
                            .Add("IMPSEG", ImporteSeguro.ToString("##,##0.00").Replace(",", ""))
                            If infoVale.ContainsKey("Folseg") Then .Add("FOLSEG", CStr(infoVale("Folseg"))) Else .Add("FOLSEG", 0)
                            .Add("DIV", CStr(infoVale("Div")))
                        End If
                        .Add("NTARJETA", "")
                        .Add("SIHAY", "")
                        .Add("PEDIDOSH", "")
                        .Add("STATUS", "")
                    End With
                    oFormasPago.Add(oPago)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_FORMAS_PAGO", oFormasPago)
                oFactura.Detalle = FactMgr.GetFacturasById(oFactura.FacturaID)
                Dim oProductos As New List(Of Dictionary(Of String, Object))
                For Each oRow As DataRow In oFactura.Detalle.Tables(0).Rows
                    '------------------------------------------------------------------
                    ' Seteamos datos del detalle
                    '------------------------------------------------------------------
                    Dim oCodigo As New Dictionary(Of String, Object)
                    With oCodigo
                        .Add("POSNR", "")
                        .Add("ORDERITEM_ID", "")
                        .Add("MATNR", CStr(oRow!CodArticulo).PadLeft(10, "0"))
                        .Add("CANTIDAD", CInt(oRow!Cantidad))
                        If CDec(oRow!Descuento) > 0 Then
                            .Add("DESCUENTO", CDec(oRow!Descuento).ToString("##,##0.00").Replace(",", ""))
                            .Add("CLASE_CONDICION", "ZDP4")
                        Else
                            .Add("DESCUENTO", 0)
                            .Add("CLASE_CONDICION", "")
                        End If

                        'If oFactura.CodTipoVenta = "V" Then
                        '    .Add("CLASE_CONDICION", "ZDP4")
                        'Else
                        '    .Add("CLASE_CONDICION", "") '"ZDP1")
                        'End If

                        .Add("ID_PROMOCION", "")
                        .Add("ALMACEN", "")
                        .Add("MOT_RECHAZO", "")
                    End With
                    oProductos.Add(oCodigo)
                Next
                '------------------------------------------------------------------
                ' Metemos los datos al detalle del objeto para serializarlo a JSON
                '------------------------------------------------------------------
                .Add("T_PRODUCTOS", oProductos)
            End With
            If oFactura.CodTipoVenta.Trim() = "O" OrElse oFactura.CodTipoVenta = "I" OrElse oFactura.CodTipoVenta = "A" OrElse oFactura.CodTipoVenta = "K" Then
                Dim lstInterlocutor As New List(Of Dictionary(Of String, Object))
                Dim inter As New Dictionary(Of String, Object)
                inter("CLIENTE") = oFactura.ClienteId
                inter("TIPO_CLIENTE") = oFactura.TipoCliente
                lstInterlocutor.Add(inter)
                oProcesarVenta("T_INTERLOCUTORES") = lstInterlocutor
            End If
            '------------------------------------------------------------------
            'Ejecutamos la Transaccion
            '------------------------------------------------------------------
            Dim oRetail As New ProcesosRetail("/pos/ventas_directas", "POST")
            oRetail.Parametros.Add("SerialID", oFactura.SerialId)
            response = oRetail.SapZsdProcesoventa(oProcesarVenta, False)
            FactMgr.SaveSerial(oFactura.SerialId, "S", oAppContext.Security.CurrentUser.ID, oFactura.FacturaID)
            valido = True
        Catch ex As Exception
            EscribeLog(ex.Message, "Error en el DPVale")
            valido = False
        End Try
        Return valido
    End Function

    Private Function ValidarFacturasDPValeEnSAP() As String

        Dim strMensajeEncontrado As String = ""
        Dim strMensajeReferencia As String = ""

        '--------------------------------------------------------------------------------
        'Roket (29.12.2015): Implementacion de Servicios REST para SAP Retail
        '--------------------------------------------------------------------------------
        'Dim oRetail As New ProcesosRetail("/pos/ventas", "POST") '("/pos/facturacion", "POST")

        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (01.11.2016): Si está activo S2Credit, no hace nada (por el momento), de lo contrario realiza la comparacion de ventas con DPVale PRO - SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim dtFacturasSAP As DataTable
        If oConfigCierreFI.AplicarS2Credit Then
            ' POR LO PRONTO N OSE REGRESA ERROR
            dtFacturasSAP = Nothing
            Return String.Empty
            Exit Function
        Else
            dtFacturasSAP = oSapMgr.ZRFCDPVL_FACTURAS_X_VALE(Me.ebFecha.Value)
        End If
        'Dim dtFacturasSAP As DataTable = oSapMgr.ZRFCDPVL_FACTURAS_X_VALE(Me.ebFecha.Value)
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------

        'Dim dtFacturasSAP As DataTable = oRetail.ZrfcdpvlFacturasXVALE(Me.ebFecha.Value)
        Dim dtFacturasPRO As DataTable = oCierreDiasMgr.GetFacturasDPVale(Me.ebFecha.Value)
        Dim oRowS As DataRow
        Dim oRowP As DataRow
        Dim bEncontrado As Boolean = False
        Dim bNoReferencia As Boolean = False
        Dim lstValesRollback As New List(Of Dictionary(Of String, Object))
        Dim oRetail As New ProcesosRetail("/pos/rollback", "POST")
        If dtFacturasSAP.Rows.Count > 0 Then
            For Each oRowS In dtFacturasSAP.Rows
                bEncontrado = False
                bNoReferencia = True

                For Each oRowP In dtFacturasPRO.Rows

                    '-----------------------------------------------------------------------------------------------------------
                    ' JNAVA (25.04.2016): Si no tiene referencia en SAP, lo enviamos en el mensaje de error para enviar correo
                    '-----------------------------------------------------------------------------------------------------------
                    If IsDBNull(oRowP!Referencia) Then
                        bEncontrado = True
                        bNoReferencia = False
                        Exit For
                    End If
                    '-----------------------------------------------------------------------------------------------------------

                    If CStr(oRowP!Tipo) = "F" Then
                        'If CStr(oRowS!BSTNK).Trim = CStr(oRowP!Referencia).Trim Then 'AndAlso CStr(oRowS!BELNR).Trim = CStr(oRowP!FolioFISAP).Trim Then
                        If ("DPVL-" & CStr(oRowS!NUMVA).PadLeft(10, "0").Trim) = CStr(oRowP!Referencia).Trim Then
                            bEncontrado = True
                            Exit For
                        End If
                    Else
                        'If CStr(oRowS!BSTNK).Trim() = CStr(oRowP!Referencia).Trim() Then
                        If ("DPVL-" & CStr(oRowS!NUMVA).PadLeft(10, "0").Trim) = CStr(oRowP!Referencia).Trim Then
                            bEncontrado = True
                            Exit For
                        End If
                    End If

                Next
                If Not bEncontrado Then
                    strMensajeEncontrado &= "Referencia:  " & oRowS!VBELN & "   No.DPVale:  " & oRowS!NUMVA & vbCrLf
                    Dim item As New Dictionary(Of String, Object)
                    item("BSTNK") = CStr("DPVL-" & CStr(oRowS!NUMVA).PadLeft(10, "0").Trim)
                    lstValesRollback.Add(item)
                End If

                If Not bNoReferencia Then strMensajeReferencia &= "No. DPVale:  " & oRowS!NUMVA & vbCrLf
            Next
            If lstValesRollback.Count > 0 Then
                oRetail.SapZsdCancelarPedido("", "", lstValesRollback)
            End If
            If strMensajeEncontrado.Trim <> "" Then strMensajeEncontrado = "No se puede realizar el cierre de dia. Existen Facturas DPVale Guardadas en SAP pero en DportenisPRO NO." & vbCrLf & vbCrLf & strMensajeEncontrado
            If strMensajeReferencia.Trim <> "" Then strMensajeReferencia = "No se puede realizar el cierre de dia. Existen Facturas DPVale sin Referencia en DportenisPRO." & vbCrLf & vbCrLf & strMensajeReferencia
        End If

        Dim strMensaje As String = ""
        strMensaje = strMensajeEncontrado.TrimEnd & vbCrLf & vbCrLf & strMensajeReferencia.TrimEnd

        Return strMensaje

    End Function

    Public Sub ImprimirConcentrado()

        If oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
            Exit Sub
        End If

        Try

            Dim oARReporte As New rptConcentradoMiniPrinter(ebFecha.Value, GetAlmacen())

            oARReporte.Document.Name = "Impresión Concentrado Mini Printer"

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
                oARReporte.Document.Print(False, False)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Catch ex As ApplicationException
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GenerarArchTransDiarios()

        oGenerarArchTrans.GenArchMOVD(ebFecha.Value)
        oGenerarArchTrans.GenArchFTOT(ebFecha.Value)

    End Sub

    Private Function GetAlmacen() As String

        Dim oAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oAlmacen As Almacen
        Dim strAlmacen As String = oAppContext.ApplicationConfiguration.Almacen
        Dim AlmacenDescripcion As String = String.Empty
        oAlmacen = oAlmacenMgr.Create
        oAlmacenMgr.LoadInto(strAlmacen, oAlmacen)

        AlmacenDescripcion = strAlmacen & " " & oAlmacen.Descripcion

        oAlmacen = Nothing
        oAlmacenMgr = Nothing

        Return AlmacenDescripcion

    End Function

    Private Sub ProcesarCierreAño()

        oCierreDiasMgr.CerrarAnio(Year(ebFecha.Value))

    End Sub

    Private Sub EnviarVentasTACR(ByVal FechaCierre As Date)

        'Dim dtT1VtasTACR As DataTable
        'Dim dtT2VtasTACR As DataTable
        'Dim dtT3VtasTACR As DataTable
        Dim dtTotalVtasTACR As DataTable
        Dim dsVtasTACR As DataSet
        'Dim dtAbonosTACR As DataTable
        'Dim dvVtasTACR As DataView
        'Dim dvAbonosTACR As DataView
        Dim oNewRow As DataRow
        'Dim Importe6 As Decimal = 0, Importe12 As Decimal = 0
        Dim oFactMgr As New FacturaManager(oAppContext, oConfigCierreFI)

        dsVtasTACR = oFactMgr.GetVtasTACRDiarias(FechaCierre)
        'dtAbonosTACR = oFactMgr.GetVtasTACRDiarias(FechaCierre).Tables(1)
        dtTotalVtasTACR = dsVtasTACR.Tables(0).Clone

        oNewRow = dtTotalVtasTACR.NewRow
        For Each oRow As DataRow In dsVtasTACR.Tables(0).Rows

            With oNewRow
                !CodBanco = oRow!CodBanco
                !ImporteSeisMeses = oRow!ImporteSeisMeses
                !ImporteDoceMeses = oRow!ImporteDoceMeses
            End With
            dtTotalVtasTACR.Rows.Add(oNewRow)

        Next

        oNewRow = dtTotalVtasTACR.NewRow
        For Each oRow As DataRow In dsVtasTACR.Tables(1).Rows

            With oNewRow
                !CodBanco = oRow!CodBanco
                !ImporteSeisMeses = oRow!ImporteSeisMeses
                !ImporteDoceMeses = oRow!ImporteDoceMeses
            End With
            dtTotalVtasTACR.Rows.Add(oNewRow)

        Next

        oNewRow = dtTotalVtasTACR.NewRow
        For Each oRow As DataRow In dsVtasTACR.Tables(2).Rows

            With oNewRow
                !CodBanco = oRow!CodBanco
                !ImporteSeisMeses = oRow!ImporteSeisMeses
                !ImporteDoceMeses = oRow!ImporteDoceMeses
            End With
            dtTotalVtasTACR.Rows.Add(oNewRow)

        Next

        'dtTotalVtasTACR = dtVtasTACR.Clone

        'dvVtasTACR = New DataView(dtVtasTACR, "CodBanco = 'T2'", "CodBanco", DataViewRowState.CurrentRows)
        'dvAbonosTACR = New DataView(dtAbonosTACR, "CodBanco = 'T2'", "CodBanco", DataViewRowState.CurrentRows)

        'oNewRow = dtTotalVtasTACR.NewRow

        'If dvVtasTACR.Count > 0 Then
        '    If dvAbonosTACR.Count > 0 Then

        '        For Each drView As DataRowView In dvVtasTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        For Each drView As DataRowView In dvAbonosTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        oNewRow!ImporteSeisMeses = Importe6
        '        oNewRow!ImporteDoceMeses = Importe12

        '    Else

        '        For Each drView As DataRowView In dvVtasTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        oNewRow!ImporteSeisMeses = Importe6
        '        oNewRow!ImporteDoceMeses = Importe12

        '    End If

        'ElseIf dvAbonosTACR.Count > 0 Then

        '    For Each drView As DataRowView In dvAbonosTACR
        '        Importe6 += drView!ImporteSeisMeses
        '        Importe12 += drView!ImporteDoceMeses
        '    Next
        '    oNewRow!ImporteSeisMeses = Importe6
        '    oNewRow!ImporteDoceMeses = Importe12

        'Else

        '    oNewRow!ImporteSeisMeses = 0
        '    oNewRow!ImporteDoceMeses = 0

        'End If
        'oNewRow!CodBanco = "T2"
        'dtTotalVtasTACR.Rows.Add(oNewRow)

        'Importe6 = 0
        'Importe12 = 0
        'oNewRow = Nothing

        'dvVtasTACR = New DataView(dtVtasTACR, "CodBanco = 'T3'", "CodBanco", DataViewRowState.CurrentRows)
        'dvAbonosTACR = New DataView(dtAbonosTACR, "CodBanco = 'T3'", "CodBanco", DataViewRowState.CurrentRows)

        'oNewRow = dtTotalVtasTACR.NewRow
        'If dvVtasTACR.Count > 0 Then
        '    If dvAbonosTACR.Count > 0 Then

        '        For Each drView As DataRowView In dvVtasTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        For Each drView As DataRowView In dvAbonosTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        oNewRow!ImporteSeisMeses = Importe6
        '        oNewRow!ImporteDoceMeses = Importe12

        '    Else

        '        For Each drView As DataRowView In dvVtasTACR
        '            Importe6 += drView!ImporteSeisMeses
        '            Importe12 += drView!ImporteDoceMeses
        '        Next
        '        oNewRow!ImporteSeisMeses = Importe6
        '        oNewRow!ImporteDoceMeses = Importe12

        '    End If

        'ElseIf dvAbonosTACR.Count > 0 Then

        '    For Each drView As DataRowView In dvAbonosTACR
        '        Importe6 += drView!ImporteSeisMeses
        '        Importe12 += drView!ImporteDoceMeses
        '    Next
        '    oNewRow!ImporteSeisMeses = Importe6
        '    oNewRow!ImporteDoceMeses = Importe12

        'Else

        '    oNewRow!ImporteSeisMeses = 0
        '    oNewRow!ImporteDoceMeses = 0

        'End If
        'oNewRow!CodBanco = "T3"
        'dtTotalVtasTACR.Rows.Add(oNewRow)

        'dtVtasTACR = oFactMgr.GetVtasTACRDiarias(FechaCierre).Tables(2)
        'oNewRow = Nothing

        'oNewRow = dtTotalVtasTACR.NewRow
        'If dtVtasTACR.Rows.Count > 0 Then
        '    'For Each oRow As DataRow In dtVtasTACR.Rows
        '    oNewRow!ImporteSeisMeses = dtVtasTACR.Rows(0)!ImporteSeisMeses
        '    oNewRow!ImporteDoceMeses = dtVtasTACR.Rows(0)!ImporteDoceMeses
        '    oNewRow!CodBanco = dtVtasTACR.Rows(0)!CodBanco
        '    'Next
        'Else
        '    oNewRow!ImporteSeisMeses = 0
        '    oNewRow!ImporteDoceMeses = 0
        '    oNewRow!CodBanco = "T1"
        'End If
        'dtTotalVtasTACR.Rows.Add(oNewRow)

        dtTotalVtasTACR.AcceptChanges()

        oFactMgr.EnviarVtasTACRDiarias(dtTotalVtasTACR, FechaCierre)

        oFactMgr = Nothing

    End Sub

    Private Sub EnviarTotales(ByVal FechaCierre As Date)

        Dim dsVtasTotales As DataSet
        Dim oFactMgr As FacturaManager

        oFactMgr = New FacturaManager(oAppContext, oConfigCierreFI)

        dsVtasTotales = oFactMgr.GetVtasTotales(FechaCierre)

        oFactMgr.EnviarVtasTotales(dsVtasTotales.Tables(0), FechaCierre)

        oFactMgr = Nothing

    End Sub

    Private Sub EnviarFacturasPG(ByVal Fecha As Date)
        Dim dtVentasPG As DataTable
        Dim oFactMgr As FacturaManager
        Dim oFingerPMgr As FingerPrintManager
        Dim oFacturaPG As Factura
        Dim oNCMgr As NotasCreditoManager
        Dim oNC As NotaCredito
        Dim oRow As DataRow

        oFactMgr = New FacturaManager(oAppContext, oConfigCierreFI)
        oFingerPMgr = New FingerPrintManager(oAppContext, oConfigCierreFI)
        oFacturaPG = oFactMgr.Create
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Revisamos las facturas sin enviar al server PG
        '------------------------------------------------------------------------------------------------------------------------------------------------
        dtVentasPG = oFactMgr.GetVentasPGSinEnviar(1)

        For Each oRow In dtVentasPG.Rows
            oFacturaPG.ClearFields()
            With oFacturaPG
                .FolioSAP = oRow!FolioSAP
                .ClientPGID = oRow!ClientePGID
                .Total = oRow!Total
                .CodVendedor = oRow!CodVendedor
                .Usuario = oRow!Usuario
                .RazonRechazo = oRow!RazonRechazo
                .RazonRechazoID = oRow!RazonRechazoID
                '-------------------------------------------------------------------------
                ' JNAVA 17.02.2016): Se comento por que ya no se usa en Retail
                '-------------------------------------------------------------------------
                .CodPlaza = "" 'oSapMgr.Read_Plaza
                .CodAlmacen = oRow!CodAlmacen
                .Fecha = oRow!Fecha
                .FolioFISAP = oRow!FolioFISAP
            End With
            If oFingerPMgr.SaveClienteVenta(oFacturaPG) Then
                oFactMgr.ActualizaStatusEnvioServerPG(oFacturaPG.FolioSAP, 1)
            End If
        Next
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Revisamos las facturas canceladas sin enviar al server PG
        '------------------------------------------------------------------------------------------------------------------------------------------------
        dtVentasPG = oFactMgr.GetVentasPGSinEnviar(2).Copy

        For Each oRow In dtVentasPG.Rows
            If oFingerPMgr.CancelaClienteVenta(oRow!FolioSAP, oRow!FCFolioSAP, oRow!FCFolioFISAP) Then
                oFactMgr.ActualizaStatusEnvioServerPG(oRow!FolioSAP, 2)
            End If
        Next
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Revisamos las notas de credito sin enviar al server PG
        '------------------------------------------------------------------------------------------------------------------------------------------------
        oNCMgr = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

        dtVentasPG = oFactMgr.GetVentasPGSinEnviar(3).Copy

        For Each oRow In dtVentasPG.Rows
            oNC = oNCMgr.Create
            With oNC
                .SALESDOCUMENT = oRow!SalesDocument
                .FIDOCUMENT = oRow!FIDOCUMENT
                .FolioSAP = oRow!FolioSAP
                .ClientePGID = oRow!ClientePGID
                .Importe = oRow!Importe
                .PlayerID = oRow!CodVendedor
                .Usuario = oRow!Usuario
                .AlmacenID = oRow!CodAlmacen
                .Fecha = oRow!Fecha
            End With
            If oFingerPMgr.SaveClienteDevolucion(oNC, oNC.FolioSAP) Then
                oFactMgr.ActualizaStatusEnvioServerPG(oNC.SALESDOCUMENT, 3)
            End If
        Next
        '------------------------------------------------------------------------------------------------------------------------------------------------
        'Enviamos todas las formas de pago del dia
        '------------------------------------------------------------------------------------------------------------------------------------------------
        dtVentasPG = oFactMgr.GetFormasPagoDia(Fecha)

        oFactMgr.EnviarFormasPagoToServer(dtVentasPG)
    End Sub

    Private Sub ReplicarUsersRoles()

        Dim oFactMgr As New FacturaManager(oAppContext, oConfigCierreFI)
        Dim dsUsersRoles As DataSet

        dsUsersRoles = oFactMgr.GetAllUsersRoles()

        oFactMgr.EnviarUsersRoles(dsUsersRoles)

    End Sub

#End Region

#Region "Métodos Privados [Eventos]"

    Private Sub frmCerrarDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_Inicializar()

    End Sub

    Private Sub frmCerrarDia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_Finalizar()

    End Sub

    Private Sub frmCerrarDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub btnCerrarDia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarDia.Click

        If Sm_GuardarCierreDia() = False Then

            Exit Sub

        End If

        MsgBox("El Cierre de Dia ha sido guardado.", MsgBoxStyle.Information, "DPTienda.")
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '</Cierre de Año>
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If Year(ebFecha.Value) <> Year(ebFecha.Value.AddDays(1)) Then
            ProcesarCierreAño()
        End If
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Sacamos referencia Bancaria
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim FrmNumRef As New FrmNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), ebFecha.Value)
        FrmNumRef.ShowDialog()
        '-----------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 08/05/2013: Si la config esta activada borramos los precios de todos los códigos para asegurarnos que realicen la descarga 
        'nocturna, si la cortan los articulos se quedaran sin precio y no podrán facturarlos sin realizar la descarga de precios y descuento 
        'mínimo para esos códigos. Esto para evitar la diferencia de precios entre el DPPRO y SAP
        '-----------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.BorrarPreciosCierre Then oCierreDiasMgr.BorrarPreciosArticulos()
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Realizamos las descargas nocturnas y apagamos el equipo
        '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        RealizarDescargasNocturnas()
    End Sub

    Private Sub RealizarDescargasNocturnas()

        Dim ofrmAviso As New FrmEsperar
        ofrmAviso.Label1.Text = ""
        ofrmAviso.ControlBox = False
        ofrmAviso.timer1.Enabled = True
        ofrmAviso.HoraInicial = Now
        ofrmAviso.ShowDialog()

        Dim ofrmProcesoSAP As New InitialForm(oAppContext, oAppSAPConfig, oConfigCierreFI)
        ofrmProcesoSAP.Nocturna = True
        ofrmProcesoSAP.bMostrarMensaje = False
        ofrmProcesoSAP.CierreDia = True
        ofrmProcesoSAP.bPorCodigo = False
        ofrmProcesoSAP.ShowDialog()
        '------------------------------------------------------------------------------------------------------------------------------
        ' JNAVA (02.10.2015): Se verifica la version del DPPRo y si existe actualizacion se realiza y si hay error se obtiene mensaje
        '------------------------------------------------------------------------------------------------------------------------------
        Dim strErrorAct As String = ""
        If Not VerificarVersion(strErrorAct) Then
            EnviarCorreos(strErrorAct, True)
            Exit Sub
        End If

        Try
            Process.Start("shutdown.exe", " -s -t 0 -f")
        Catch ex As Exception
            Try
                Dim i As Integer
                i = ExitWindowsEx(1, 0&)  'Apaga el equipo 
            Catch ex2 As Exception
                MessageBox.Show("Descargas Realizadas Correctamente. No se pudo apagar el equipo.", "No se pudo apagar el equipo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Try

    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstReportes.DoubleClick
        'TODO Implementacion de Seleccion de Reportes.
        Select Case LstReportes.SelectedItem

            Case "Ventas Facturadas"

                Sm_ActionPreviewReporteVentasFacturadas()

            Case "Pedidos"

                Sm_ReportePedidosTotales()

            Case "Notas de Credito"

                Sm_ActionPreviewReporteNotasCredito()

            Case "Devolución de Tarjetas"

                Sm_ActionPreviewReporteDevolucionTarjeta(True)

            Case "Devolución de Efectivo"

                Sm_ActionPreviewReporteDevolucionTarjeta(False)

            Case "Vales de Caja"

                Sm_ActionPreviewReporteValeCaja()

            Case "Liquidaciones"

                Me.Cursor = Cursors.WaitCursor

                Sm_ActionPreviewReporteFacturasLiquidadas()

                Me.Cursor = Cursors.Default

            Case "Abonos"

                Sm_ActionPreviewReporteAbonosApartados()

            Case "Abonos a CxC"

                Sm_ActionPreviewReporteAbonosCreditoDirecto()

            Case "Cancelacion de Apartados"

                Sm_ActionPreviewReporteCancelacionApartados()

            Case "Poliza de Ingresos"

                dsDataSet = oGenerarPoliza.GeneraPoliza(ebFecha.Value, dsDataSet)

                Sm_ActionPreviewPoliza()

            Case "Numero Referencia"

                Dim FrmNumRef As New FrmNumReferencia(oAppContext.ApplicationConfiguration.Almacen.PadLeft(4, "0"), ebFecha.Value)
                FrmNumRef.ShowDialog()

            Case "Ventas DPVale"

                Me.Cursor = Cursors.WaitCursor

                VentasVale()

                Me.Cursor = Cursors.Default

                'Case "Ventas DPVale Financiero"

                '    Me.Cursor = Cursors.WaitCursor

                '    Sm_ActionPreviewDPValeFinanciero()

                '    Me.Cursor = Cursors.Default
            Case "DPVale Ecommerce"

                Sm_ActionPreviewReportePagosEcommerceDPVale()

            Case "Notas de Venta Manual"
                Me.Cursor = Cursors.WaitCursor

                ActionPreviewNotasVentaManuales()

                Me.Cursor = Cursors.Default
            Case "Ventas Totales Microcredito"
                Sm_ActionPreviewReporteVentasTotalesMicrocredito()

            Case "Reporte de concentrado del día"
                ReimprimirConcentradoDia()

            Case "Reporte Concentrado Cierre de Caja"
                ReImprimirConcentradoAuditoria()

        End Select

    End Sub

#End Region

#Region "Generación de los reportes"
    Private Sub ActionPreviewNotasVentaManuales()
        Dim oAReport As New rptCancelacionNotasVentaManuales(CDate(Me.ebFecha.Value))
        Dim OARViewer As New ReportViewerForm

        oAReport.Document.Name = "Notas de Venta Manual"
        oAReport.Run()

        OARViewer.Report = oAReport
        OARViewer.Show()

    End Sub
    Private Sub Sm_ActionPreviewDPValeFinanciero()

        Dim oAReport As New rptVentasDPValeFinanciero(CDate(Me.ebFecha.Value))
        Dim oARViewer As New ReportViewerForm

        oAReport.Document.Name = "Reporte Ventas DPVale Financiero"
        oAReport.Run()

        oARViewer.Report = oAReport
        oARViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteValeCaja()

        dtValeCajaReport = SelectValeCajaReportVentas()     'SelectValeCajaReport()

        Dim oARReporte As New ValesdeCajaReport(ebFecha.Value, _
                                                ebFecha.Value, _
                                                GetAlmacen(), _
                                                dtValeCajaReport)
        Dim oReportViewer As New ReportViewerForm
        oARReporte.Document.Name = "Reporte de Vales de Caja"
        oReportViewer.Report = oARReporte
        oARReporte.Run()
        oReportViewer.Show()

    End Sub
    Private Sub Sm_ActionPreviewReportePagosEcommerceDPVale()

        Dim oARReporte As New rptPagueTiendaEcommerceDPVale(ebFecha.Value)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reportes de Ventas a Credito DPVale"
        oARReporte.Run()

        Try

            oReportViewer.Report = oARReporte
            oReportViewer.Show()
            Dim lstVales As List(Of String), lstClientes As List(Of String)
            lstVales = oARReporte.GetValesInexistentes()
            lstClientes = oARReporte.GetClientesErroneos()
            Dim strVales As String = "", strClientes As String = ""
            If lstVales.Count > 0 Then
                strVales = String.Join(vbCrLf, lstVales)
                MessageBox.Show("La venta con vale no se almaceno correctamente:" & vbCrLf & strVales, "Vales inexistentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If lstClientes.Count > 0 Then
                strClientes = String.Join(vbCrLf, lstClientes)
                MessageBox.Show(strClientes, "Clientes Vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. El Reporte Póliza  no pudo ser impreso.", ex)

        End Try

        'Dim oARReporte As New rptVentasEcommerceDPVale(ebFecha.Value)
        'Dim oReportViewer As New ReportViewerForm
        'oARReporte.Document.Name = "Reporte de Pagos Ecommerce Vale"
        'oReportViewer.Report = oARReporte
        'oARReporte.Run()
        'oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteNotasCredito()

        Dim oARReporte As New CierreDiaNotasCredito(ebFecha.Value, GetAlmacen)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte Notas de Credito"
        oARReporte.Run()


        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteCancelacionApartados()

        Dim oARReporte As New CierreDiaCancelacionApartados(ebFecha.Value, GetAlmacen)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Reporte Cierre Día Cancelación Apartados"
        oARReporte.Run()


        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteAbonosApartados()

        Dim oARReporte As New rptAbonosApartados(ebFecha.Value)
        Dim oReportViewer As New ReportViewerForm


        oARReporte.Document.Name = "Reporte Cierre Día Abonos Apartados"
        oARReporte.Run()


        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteFacturasLiquidadas()

        Dim dsLiquidadas As DataSet

        dsLiquidadas = SelectFacturasLiquidadas()

        If (dsLiquidadas Is Nothing) Or (dsLiquidadas.Tables(0).Rows.Count = 0) Then

            MsgBox("No se cuenta con información en la fecha. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Cierre de Dia")

            dsLiquidadas = Nothing

            Exit Sub

        End If

        Dim oARReporte As New rptFacturasLiquidadas(dsLiquidadas, ebFecha.Value, GetAlmacen())

        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Liquidaciones"

        'Visualizar Reporte :

        oReportViewer.Report = oARReporte

        oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteAbonosCreditoDirecto()



        Dim oReportViewer As New ReportViewerForm
        Dim rptAbonoCDT As New rptReporteAbonosCreditoDirecto(Format(Date.Now, "Short Date"), oAppContext.ApplicationConfiguration.Almacen)

        rptAbonoCDT.Document.Name = "Reporte Abono Credito Directo - " & Format(Date.Now, "Short Date")

        oReportViewer.Report = rptAbonoCDT
        rptAbonoCDT.Run()
        Me.Cursor = Cursors.Default
        oReportViewer.Show()


        'Dim oAbonoCreditoDirectoMgr As New AbonoCreditoDirectoManager(oAppContext)

        'Dim dsAbonosCreditoDT As New DataSet

        'dsAbonosCreditoDT = oAbonoCreditoDirectoMgr.GetByDate(ebFecha.Value, oAppContext.ApplicationConfiguration.Almacen)

        'If dsAbonosCreditoDT Is Nothing Or (dsAbonosCreditoDT.Tables(0).Rows.Count = 0) Then

        '    MsgBox("No Existen Abonos de Crédito Directo en la Fecha", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cierre de Dia ")

        '    If Not dsAbonosCreditoDT Is Nothing Then

        '        dsAbonosCreditoDT.Dispose()
        '        dsAbonosCreditoDT = Nothing

        '        oAbonoCreditoDirectoMgr = Nothing

        '    End If

        '    Return

        'End If

        'Dim oARReporte As New frmAbonosCreditoDirecto(ebFecha.Value, dsAbonosCreditoDT)

        'Dim oReportViewer As New ReportViewerForm

        'oARReporte.Document.Name = "Reporte Cierre Día Abonos Crédito Directo"
        'oARReporte.Run()

        ''Visualizar Reporte :

        'oReportViewer.Report = oARReporte
        'oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewReporteVentasFacturadas()

        Dim oReport As New VentasReport
        Dim oReporter As New VentasTotalesReporter(oAppContext)
        Dim ds As New DataSet

        oReporter.ConnectionString = oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString()
        oReport.CurrentReporter = oReporter

        oReporter.FechaIni = ebFecha.Value
        oReporter.FechaFin = ebFecha.Value
        oReporter.CodCaja = "AL" 'oAppContext.ApplicationConfiguration.NoCaja
        oReporter.Almacen = oAppContext.ApplicationConfiguration.Almacen

        ds = oReport.GenerateNewPreview

        Dim oARReporte As New VentasTotales(ds, ebFecha.Value, ebFecha.Value)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Ventas Totales"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

    Private Sub Sm_ActionPreviewPoliza()
        Dim dsMultU As DataSet, drMultU As DataRow
        Dim vlEmpresa As String = ""
        Dim vlFecha As Date = Date.Today
        Dim vlDireccion As String = ""
        Dim vlRegFed As String = ""
        Dim vlCP As String = ""
        Dim vlRegEst As String = ""
        Dim vlRegCam As String = ""
        Dim vlFondo As Decimal = oGenerarPoliza.CalcularTotalFondoCaja(ebFecha.Value)
        dsMultU = oGenerarPoliza.DatosEmpresa()
        For Each drMultU In dsMultU.Tables(0).Rows
            vlEmpresa = drMultU!Nombre
            vlFecha = ebFecha.Value
            vlDireccion = drMultU!Direccion
            vlRegFed = drMultU!RegFed
            vlCP = drMultU!CP
            vlRegEst = drMultU!RegEstatal
            vlRegCam = drMultU!RegCamara
        Next
        dsMultU = Nothing

        Dim oARReporte As New Poliza(vlEmpresa, vlFecha, vlDireccion, vlRegFed, vlCP, vlRegEst, vlRegCam, dsDataSet, vlFondo)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Poliza"
        oARReporte.Run()

        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

        Try

            'oARReporte.Document.Print(False, False)

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. El Reporte Póliza  no pudo ser impreso.", ex)

        End Try

    End Sub

    Private Sub VentasVale()
        'Dim oFacturasMgr As New FacturaManager(oAppContext)
        'Dim dsVentasPTVenta As New DataSet

        'dsVentasPTVenta = oFacturasMgr.VentasDPValeDelDia(ebFecha.Value).Copy

        'If dsVentasPTVenta.Tables(0).Rows.Count > 0 OrElse dsVentasPTVenta.Tables(1).Rows.Count > 0 Then

        Dim oARReporte As New rptVentasCreditoDPVale(ebFecha.Value)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reportes de Ventas a Credito DPVale"
        oARReporte.Run()

        Try

            oReportViewer.Report = oARReporte
            oReportViewer.Show()
            Dim lstVales As List(Of String), lstClientes As List(Of String)
            lstVales = oARReporte.GetValesInexistentes()
            lstClientes = oARReporte.GetClientesErroneos()
            Dim strVales As String = "", strClientes As String = ""
            If lstVales.Count > 0 Then
                strVales = String.Join(vbCrLf, lstVales)
                MessageBox.Show("La venta con vale no se almaceno correctamente:" & vbCrLf & strVales, "Vales inexistentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If lstClientes.Count > 0 Then
                strClientes = String.Join(vbCrLf, lstClientes)
                MessageBox.Show(strClientes, "Clientes Vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. El Reporte Póliza  no pudo ser impreso.", ex)

        End Try

        'Else

        'MsgBox("No Existen Ventas a Credito DPVale en la Fecha", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Cierre de Dia ")

        'End If

    End Sub

    Private Sub Sm_ActionPrintPoliza()
        Dim dsMultU As DataSet, drMultU As DataRow
        Dim vlEmpresa As String = ""
        Dim vlFecha As Date = Date.Today
        Dim vlDireccion As String = ""
        Dim vlRegFed As String = ""
        Dim vlCP As String = ""
        Dim vlRegEst As String = ""
        Dim vlRegCam As String = ""
        Dim vlFondo As Decimal = oGenerarPoliza.CalcularTotalFondoCaja(ebFecha.Value)
        dsMultU = oGenerarPoliza.DatosEmpresa()
        For Each drMultU In dsMultU.Tables(0).Rows
            vlEmpresa = drMultU!Nombre
            vlFecha = ebFecha.Value
            vlDireccion = drMultU!Direccion
            vlRegFed = drMultU!RegFed
            vlCP = drMultU!CP
            vlRegEst = drMultU!RegEstatal
            vlRegCam = drMultU!RegCamara
        Next
        dsMultU = Nothing

        Dim oARReporte As New Poliza(vlEmpresa, vlFecha, vlDireccion, vlRegFed, vlCP, vlRegEst, vlRegCam, dsDataSet, vlFondo)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Poliza"
        oARReporte.Run()

        Try

            oARReporte.Document.Print(False, False)

        Catch ex As Exception

            Throw New ApplicationException("Se produjó un error. El Reporte Póliza  no pudo ser impreso.", ex)

        End Try

    End Sub

    Private Sub Sm_ActionPrintReporteCierredeDia()
        '------------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 05.12.2014: Imprimimos primero el nuevo reporte de auditoria si esta configurada la opcion
        '------------------------------------------------------------------------------------------------------------------------------------
        If oConfigCierreFI.MostrarConcenAUD Then
            Dim oRepAud As New rptConcenAuditoria(ebFecha.Value, GetAlmacen())
            'Dim oReportViewer As New ReportViewerForm
            oRepAud.Document.Name = "Reporte Concentrador de Cierre de Caja (Auditoria)"
            oRepAud.Run()

            Try

                oRepAud.Document.Print(False, False)
                'oReportViewer.Report = oRepAud
                'oReportViewer.Show()

            Catch ex As Exception

                EscribeLog(ex.ToString, "Error al imprimir el nuevo reporte de auditoria en el cierre de dia")
                Throw New ApplicationException("Se produjó un error. El Reporte de Auditoria  no pudo ser impreso.", ex)

            End Try
        End If

        Dim oARReporte As New RptCierredeDia(ebFecha.Value)

        oARReporte.Document.Name = "Reportes de Cierre de Día"
        oARReporte.Run()

        Try

            oARReporte.Document.Print(False, False)
            'oReportViewer.Report = oARReporte
            'oReportViewer.Show()

        Catch ex As Exception

            EscribeLog(ex.ToString, "Error al imprimir los reportes del cierre de dia")
            Throw New ApplicationException("Se produjó un error. Los reportes del cierre de día no pudieron ser impresos.", ex)

        End Try

    End Sub

#End Region

#Region "SQL Methods"

    Private Function SelectValeCajaReport() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daValesCaja As SqlDataAdapter
        Dim dtValesCaja As New DataTable("ValesCaja")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ValesdeCajaReporteSel]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = ebFecha.Value
            .Parameters("@FechaFinal").Value = ebFecha.Value

        End With

        daValesCaja = New SqlDataAdapter(sccmdSelect)

        Try

            daValesCaja.Fill(dtValesCaja)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daValesCaja.Dispose()
        daValesCaja = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtValesCaja

    End Function


    Private Function SelectValeCajaReportVentas() As DataTable

        Dim sccnnConnection As New SqlConnection(strConnectionString)

        Dim daValesCaja As SqlDataAdapter
        Dim dtValesCaja As New DataTable("ValesCaja")

        Dim sccmdSelect As SqlCommand
        sccmdSelect = New SqlCommand

        With sccmdSelect
            .Connection = sccnnConnection
            .CommandText = "[ValesdeCajaReporteSelVenta]"
            .CommandType = System.Data.CommandType.StoredProcedure
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaInicial", System.Data.SqlDbType.DateTime, 8))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FechaFinal", System.Data.SqlDbType.DateTime, 8))

            .Parameters("@FechaInicial").Value = ebFecha.Value
            .Parameters("@FechaFinal").Value = ebFecha.Value

        End With

        daValesCaja = New SqlDataAdapter(sccmdSelect)

        Try

            daValesCaja.Fill(dtValesCaja)

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser seleccionado debido a un error de aplicación.", ex)

        End Try

        daValesCaja.Dispose()
        daValesCaja = Nothing

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

        Return dtValesCaja

    End Function




    Private Function SelectFacturasLiquidadas() As DataSet

        Dim oFacturaMgrTemp As New FacturaManager(oAppContext)
        Dim dsFacturas As DataSet

        dsFacturas = oFacturaMgrTemp.GetFacturasLiquidadas(ebFecha.Value, ebFecha.Value)

        oFacturaMgrTemp = Nothing

        Return dsFacturas

    End Function

#End Region

#Region "Show"

    Public Sub ShowMe(ByVal strUserSession As String)

        oUserSession = strUserSession
        oAppContext.Security.CloseImpersonatedSession()
        Me.ShowDialog()

    End Sub

#End Region

#Region " Proyecto SiHay "

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (04/06/2013) - Realizamos la validacion de las citas concretadas segun los pedidos insurtibles sin reembolsar
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function ValidarCitaSiHay() As String
        Dim strMsg As String = ""
        Dim FechaCitaSH As Date
        Dim htFolios As Hashtable
        Dim ParticipaSH As Integer = ParticipaEnSH()

        If ParticipaSH <> 1 AndAlso ParticipaSH <> 3 Then
            GoTo Continuar
        End If

        'Status de los pedidos
        Dim htStatus As Hashtable
        htStatus = New Hashtable(1)
        htStatus(1) = "IP" 'Pedidos Insurtibles

        htFolios = GetFoliosPedidos(htStatus) 'Regresa HashTable (HT por default)

        If Not htFolios Is Nothing Then
            For i As Integer = 0 To htFolios.Count - 1
                FechaCitaSH = oCierreDiasMgr.GetFechaCitaSH(htFolios(i))
                If FechaCitaSH <> Date.MinValue Then
                    If FechaCitaSH <= Date.Now Then
                        strMsg += " - " & htFolios(i) & vbCrLf
                    End If
                Else
                    'Crear Cita Administrada
                    Dim oClientesMgr As ClientesManager
                    oClientesMgr = New ClientesManager(oAppContext)

                    oClientesMgr.SaveConcretarCitaSH(htFolios(i), Date.Now.AddDays(oConfigCierreFI.DiasRecogerReembolsoSH))
                    oClientesMgr = Nothing
                End If
            Next
        End If

Continuar:

        Return strMsg

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (04/06/2013) - Obtenemos la lista de Pedidos solicitados en el HashTable
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function GetFoliosPedidos(ByVal htStatus As Hashtable, Optional ByVal Tipo As String = "HT")

        Dim dtListaPedidos As DataTable
        Dim dtCabeceraSH As DataTable
        Dim dtPedidosDet As DataTable

        Dim i As Integer = 0

        Dim htPedidosSH As Hashtable
        htPedidosSH = New Hashtable

        dtListaPedidos = oSapMgr.ZSH_PEDIDOS_PENDIENTES(oSapMgr.Read_Centros, dtCabeceraSH, dtPedidosDet, htStatus)

        htStatus = Nothing
        'dtCabeceraSH = Nothing
        'dtPedidosDet = Nothing

        If Not dtListaPedidos Is Nothing AndAlso dtListaPedidos.Rows.Count > 0 Then

            'Modificamos el nombre de la columna para que coincida con el grid
            dtListaPedidos.Columns("VBELN").ColumnName = "Folio_Pedido"
            dtListaPedidos.AcceptChanges()

            'Eliminamos los folios duplicados
            dtListaPedidos = RegistrosDuplicados(dtListaPedidos)

            'Llenamos HashTable
            For Each oRow As DataRow In dtListaPedidos.Rows
                htPedidosSH(i) = oRow!Folio_Pedido
                i += 1
            Next
            i = 0
        Else
            dtListaPedidos = Nothing
            dtCabeceraSH = Nothing
            dtPedidosDet = Nothing
        End If

        If Tipo = "HT" Then
            dtListaPedidos = Nothing
            dtCabeceraSH = Nothing
            dtPedidosDet = Nothing
            Return htPedidosSH
        ElseIf Tipo = "DT" Then
            Dim dsPedidosAll As New DataSet
            If dtListaPedidos Is Nothing OrElse dtListaPedidos.Rows.Count <= 0 Then
                dsPedidosAll = Nothing
            Else
                dsPedidosAll.Tables.Add(dtListaPedidos.Copy) 'Lista Pedidos
                dsPedidosAll.Tables.Add(dtCabeceraSH.Copy) 'Cabecera Pedidos
                dsPedidosAll.Tables.Add(dtPedidosDet.Copy) 'Detalle Pedidos
                dsPedidosAll.AcceptChanges()
            End If
            dtListaPedidos = Nothing
            dtCabeceraSH = Nothing
            dtPedidosDet = Nothing
            Return dsPedidosAll
        End If

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (04/06/2013) - Eliminamos los folios duplicados
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function RegistrosDuplicados(ByVal dt As DataTable, Optional ByVal Sort As Boolean = False) As DataTable
        Dim dtCopy As DataTable = dt.Clone
        Dim oRowV As DataRowView
        Dim oView As DataView

        For Each oRow As DataRow In dt.Rows
            oView = New DataView(dtCopy, "Folio_Pedido = '" & oRow!Folio_Pedido & "'", IIf(Sort, "FECHA", ""), DataViewRowState.CurrentRows)
            If oView.Count <= 0 Then
                dtCopy.ImportRow(oRow)
            End If
        Next

        dtCopy.AcceptChanges()
        oView = Nothing
        oRowV = Nothing
        Return dtCopy
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 07/06/2013: Muestra reporte de los pedidos Totales
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function Sm_ReportePedidosTotales()
        Dim oARReporte As New PedidosTotales(ebFecha.Value, ebFecha.Value)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de Pedidos Totales"
        oARReporte.Run()

        oReportViewer.Report = oARReporte
        oReportViewer.Show()
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (10/06/2013) - Validamos Pedidos Si Hay
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function ValidarPedidosSiHay() As Boolean

        Dim bRes As Boolean = True
        Dim dsPedidos As DataSet
        Dim htStatus As Hashtable 'Status de los pedidos
        Dim TipoSiHay As Integer 'Como esta configura la tienda en SAP para Si Hay

        htStatus = New Hashtable
        htStatus(1) = "P"
        htStatus(2) = "RP"
        htStatus(3) = "PE-L"
        htStatus(4) = "PE-F"
        htStatus(5) = "PR"
        htStatus(6) = "PF"
        htStatus(7) = "PC"
        htStatus(8) = "IP"

        dsPedidos = GetFoliosPedidos(htStatus, "DT")  'DT Regresa Datatable
        TipoSiHay = ParticipaEnSH()

        Select Case TipoSiHay
            Case -1 'No participa
                GoTo Continuar
            Case 1 'Solo solicitante
                '-------------------------------------------------------------
                'Solicitante - Por Recibir
                '-------------------------------------------------------------
                Dim dtPorRecibir As DataTable 'STATUS PR
                If Not dsPedidos Is Nothing Then dtPorRecibir = GetPedidosBySTATUS(dsPedidos, "PR")

                If Not dtPorRecibir Is Nothing AndAlso dtPorRecibir.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorRecibir.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasRecibirSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Recibir." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorRecibir = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'Solicitante - Por Facturar
                '-------------------------------------------------------------
                Dim dtPorFacturar As DataTable 'STATUS PF
                If Not dsPedidos Is Nothing Then dtPorFacturar = GetPedidosBySTATUS(dsPedidos, "PF")

                If Not dtPorFacturar Is Nothing AndAlso dtPorFacturar.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorFacturar.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasFacturarSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Facturar." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorFacturar = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'Solicitante - Por Cancelar
                '-------------------------------------------------------------
                Dim dtPorCancelar As DataTable 'STATUS PC
                If Not dsPedidos Is Nothing Then dtPorCancelar = GetPedidosBySTATUS(dsPedidos, "PC")

                If Not dtPorCancelar Is Nothing AndAlso dtPorCancelar.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorCancelar.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasCancelarSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Cancelar." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorCancelar = Nothing
                '-------------------------------------------------------------

            Case 2 'Solo suministradora
                '-------------------------------------------------------------
                'suministradora - Por Surtir
                '-------------------------------------------------------------
                Dim dtPorSurtir As DataTable 'STATUS P y RP
                If Not dsPedidos Is Nothing Then dtPorSurtir = GetPedidosBySTATUS(dsPedidos, "P", "RP")

                If Not dtPorSurtir Is Nothing AndAlso dtPorSurtir.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorSurtir.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasSurtirSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Surtir." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorSurtir = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'suministradora - Por Sin Guia
                '-------------------------------------------------------------
                Dim dtSinGuia As DataTable 'STATUS PE-L y PE-F
                If Not dsPedidos Is Nothing Then dtSinGuia = GetPedidosBySTATUS(dsPedidos, "PE-L", "PE-F")

                If Not dtSinGuia Is Nothing AndAlso dtSinGuia.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtSinGuia.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasSinGuiaSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están Sin Guia." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtSinGuia = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'suministradora - Por Reembolsar (Insurtibles)
                '-------------------------------------------------------------
                'Dim dtPorReembolsar As DataTable 'STATUS IP
                'If Not dsPedidos Is Nothing Then dtPorReembolsar = GetPedidosBySTATUS(dsPedidos, "IP")

                'If Not dtPorReembolsar Is Nothing AndAlso dtPorReembolsar.Rows.Count > 0 Then
                '    Dim strFolios As String = ""
                '    For Each oRow As DataRow In dtPorReembolsar.Rows
                '        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasInsurtiblesSH) <= Today Then
                '            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                '        End If
                '    Next
                '    If strFolios <> "" Then
                '        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Reembolsar." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        bRes = False
                '    End If
                'End If
                ''liberamos memoria
                'dtPorReembolsar = Nothing
                '-------------------------------------------------------------

            Case 3 'Solicitante y Suministradora

                '-------------------------------------------------------------
                'Solicitante - Por Recibir
                '-------------------------------------------------------------
                Dim dtPorRecibir As DataTable 'STATUS PR
                If Not dsPedidos Is Nothing Then dtPorRecibir = GetPedidosBySTATUS(dsPedidos, "PR")

                If Not dtPorRecibir Is Nothing AndAlso dtPorRecibir.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorRecibir.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasRecibirSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Recibir." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorRecibir = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'Solicitante - Por Facturar
                '-------------------------------------------------------------
                Dim dtPorFacturar As DataTable 'STATUS PF
                If Not dsPedidos Is Nothing Then dtPorFacturar = GetPedidosBySTATUS(dsPedidos, "PF")

                If Not dtPorFacturar Is Nothing AndAlso dtPorFacturar.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorFacturar.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasFacturarSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Facturar." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorFacturar = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'Solicitante - Por Cancelar
                '-------------------------------------------------------------
                Dim dtPorCancelar As DataTable 'STATUS PC
                If Not dsPedidos Is Nothing Then dtPorCancelar = GetPedidosBySTATUS(dsPedidos, "PC")

                If Not dtPorCancelar Is Nothing AndAlso dtPorCancelar.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorCancelar.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasCancelarSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Cancelar." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorCancelar = Nothing
                '-------------------------------------------------------------

                '****************************************************************************************

                '-------------------------------------------------------------
                'suministradora - Por Surtir
                '-------------------------------------------------------------
                Dim dtPorSurtir As DataTable 'STATUS P y RP
                If Not dsPedidos Is Nothing Then dtPorSurtir = GetPedidosBySTATUS(dsPedidos, "P", "RP")

                If Not dtPorSurtir Is Nothing AndAlso dtPorSurtir.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtPorSurtir.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasSurtirSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Surtir." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtPorSurtir = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'suministradora - Por Sin Guia
                '-------------------------------------------------------------
                Dim dtSinGuia As DataTable 'STATUS PE-L y PE-F
                If Not dsPedidos Is Nothing Then dtSinGuia = GetPedidosBySTATUS(dsPedidos, "PE-L", "PE-F")

                If Not dtSinGuia Is Nothing AndAlso dtSinGuia.Rows.Count > 0 Then
                    Dim strFolios As String = ""
                    For Each oRow As DataRow In dtSinGuia.Rows
                        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasSinGuiaSH) <= Today Then
                            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                        End If
                    Next
                    If strFolios <> "" Then
                        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están Sin Guia." & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        bRes = False
                    End If
                End If
                'liberamos memoria
                dtSinGuia = Nothing
                '-------------------------------------------------------------

                '-------------------------------------------------------------
                'suministradora - Por Reembolsar (Insurtibles)
                '-------------------------------------------------------------
                'Dim dtPorReembolsar As DataTable 'STATUS IP
                'If Not dsPedidos Is Nothing Then dtPorReembolsar = GetPedidosBySTATUS(dsPedidos, "IP")

                'If Not dtPorReembolsar Is Nothing AndAlso dtPorReembolsar.Rows.Count > 0 Then
                '    Dim strFolios As String = ""
                '    For Each oRow As DataRow In dtPorReembolsar.Rows
                '        If CDate(oRow!Fecha).AddDays(oConfigCierreFI.DiasInsurtiblesSH) <= Today Then
                '            strFolios += " - " & oRow!Folio_Pedido & vbCrLf
                '        End If
                '    Next
                '    If strFolios <> "" Then
                '        MessageBox.Show("No se puede hacer cierre de dia. Los siguientes pedidos están pendientes por Reembolsar. " & vbCrLf & vbCrLf & strFolios, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        bRes = False
                '    End If
                'End If
                ''liberamos memoria
                'dtPorReembolsar = Nothing
                '-------------------------------------------------------------

        End Select

Continuar:
        '---------------------------------------------------------------------------------------------------------------------------------
        'RGERMAIN 10.06.2015: Validamos que no haya pedidos sin folio SAP
        '---------------------------------------------------------------------------------------------------------------------------------
        Dim dtPedSHSinFolioSAP As DataTable = oCierreDiasMgr.GetPedidosSHSinFolioSAP(Me.ebFecha.Value).Copy
        If dtPedSHSinFolioSAP.Rows.Count > 0 Then
            MessageBox.Show("No se puede hacer cierre de dia. Existen pedidos Si Hay sin Folio SAP", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            bRes = False
        End If

        'liberamos mas memoria
        dsPedidos = Nothing
        htStatus = Nothing

        Return bRes

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (10/06/2013) - Validamos si participa Si Hay
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function ParticipaEnSH() As Integer

        Dim ConfigSiHaySAP As Integer = -1
        Dim procesoMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        Dim permisos As Hashtable = procesoMgr.ZSH_PARTICIPANTES("T" & oAppContext.ApplicationConfiguration.Almacen.Trim.PadLeft(3, "0"))

        If CStr(permisos("Solicitar")).ToUpper() = "X" Then
            ImporteMinimoSH = CDec(permisos("IMPMIN"))
            PorcMasDescSH = CDec(permisos("MAXDESC"))
            ConfigSiHaySAP = 1
            If CStr(permisos("Suministrar")).ToUpper() = "X" Then
                ConfigSiHaySAP = 3
            End If
        ElseIf CStr(permisos("Suministrar")).ToUpper() = "X" Then
            ImporteMinimoSH = CDec(permisos("IMPMIN"))
            PorcMasDescSH = CDec(permisos("MAXDESC"))
            ConfigSiHaySAP = 2
        End If

        Return ConfigSiHaySAP

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (11/06/2013) - Funcion que obtiene, segun el STATUS ingresado, los pedidos correspondientes pendientes
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function GetPedidosBySTATUS(ByVal dsPedidos As DataSet, ByVal STATUS As String, Optional ByVal STATUS2 As String = "") As DataTable

        Dim dtListaPedidos As DataTable = dsPedidos.Tables(0).Copy 'Lista pedidos
        Dim dtCabeceraPedidos As DataTable = dsPedidos.Tables(1).Copy 'Cabecera
        'Dim dtDetallePedidos As DataTable = dsPedidos.Tables(2) 'Detalle

        'Creo mi datatable y columnas
        Dim dtReturn As New DataTable
        dtReturn.Columns.Add("FOLIO_PEDIDO")
        dtReturn.Columns.Add("FECHA")
        dtReturn.AcceptChanges()

        'Revisamos los pedidos 
        If Not dtListaPedidos Is Nothing AndAlso dtListaPedidos.Rows.Count > 0 Then
            Dim oRowV As DataRowView
            Dim oView As DataView
            Dim strFecha As String = ""

            'Creamos la Consulta para el DataView
            Dim ConsultaDV As String = ""
            ConsultaDV = "STATUS = '" & STATUS & "'"

            'Si se ingresa otro Status, rehace la consulta para obtener los registros de ambos STATUS ingresados
            If STATUS2 <> "" Then
                ConsultaDV = "STATUS = '" & STATUS & "' OR STATUS = '" & STATUS2 & "'"
            End If

            oView = New DataView(dtListaPedidos, ConsultaDV, "", DataViewRowState.CurrentRows)
            If oView.Count > 0 Then
                For Each oRowV In oView
                    For Each oRow As DataRow In dtCabeceraPedidos.Rows
                        strFecha = ""
                        If oRowV!Folio_Pedido = oRow!VBELN Then
                            'Formateamos la Fecha 
                            Dim oNewRow As DataRow = dtReturn.NewRow()
                            If STATUS = "P" OrElse STATUS = "RP" OrElse STATUS = "IP" OrElse STATUS2 = "RP" OrElse STATUS2 = "PE-F" Then
                                strFecha = CStr(oRow!FECHA).Trim
                            Else
                                strFecha = CStr(oRow!FECHA_MODIF).Trim
                            End If
                            strFecha = strFecha.Substring(6, 2) & "/" & strFecha.Substring(4, 2) & "/" & strFecha.Substring(0, 4) 'Formateamos Fecha

                            'Agregamos un registro al datatable que regresaremos
                            oNewRow("FOLIO_PEDIDO") = oRowV!Folio_Pedido 'Agregamos el Pedido
                            oNewRow("FECHA") = strFecha 'Fecha de ultima Modificacion                          
                            dtReturn.Rows.Add(oNewRow)
                            dtReturn.AcceptChanges()
                        End If
                    Next
                Next
            End If
        End If

        dtReturn = RegistrosDuplicados(dtReturn, True)

        Return dtReturn

    End Function

    '------------------------------------------------------------------------------------------------------------------------------------
    'JNAVA (19/06/2013) - Validamos los pedidos cancelados en las que sus facturas aun no estan canceladas
    '------------------------------------------------------------------------------------------------------------------------------------
    Private Function ValidarPedidosCanceladosSiHay() As Boolean

        Dim oFacturaSH As Factura
        Dim oPedido As Pedidos

        Dim strMsg As String = ""
        Dim bRes As Boolean = True

        Dim PedidosCan As DataTable
        Dim oRow As DataRow
        PedidosCan = oCierreDiasMgr.GetPedidosCanceladoSH(Me.ebFecha.Value)

        If Not PedidosCan Is Nothing AndAlso PedidosCan.Rows.Count > 0 Then
            For Each oRow In PedidosCan.Rows

                oPedido = Nothing
                oPedido = New Pedidos(oRow!PedidoID)

                'Cargar en objeto Factura
                If Not oPedido.Facturas Is Nothing Then
                    For Each oFacturaSH In oPedido.Facturas
                        If oFacturaSH.StatusRegistro = True Then
                            strMsg &= "Pedido: " & CStr(oRow!FolioSAP).Trim & "       "
                            strMsg &= "Factura: " & oFacturaSH.FolioSAP.Trim & vbCrLf
                        End If
                    Next
                End If
            Next
        End If

        oPedido = Nothing
        oFacturaSH = Nothing

        If strMsg <> "" Then
            If MessageBox.Show("Las siguientes facturas pertenecen a Pedidos SH cancelados. " & vbCrLf & vbCrLf & "Probablemente olvidaste cancelarlas." & vbCrLf & vbCrLf & _
                                strMsg.Trim & vbCrLf & vbCrLf & "¿Deseas continuar con el cierre de todos modos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                oAppContext.Security.CloseImpersonatedSession()
                If oAppContext.Security.StartImpersonatedSession("DportenisPro.DPTienda.Ventas.CerrarDia") = False Then
                    MessageBox.Show("No se puede hacer el cierre de dia. Es necesario identificarse para continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    bRes = False
                Else
                    Try
                        oFingerPMgr.SaveAutorizacion(oAppContext.Security.CurrentUser.SessionLoginName, oAppContext.Security.CurrentUser.Name, "Cierre de Dia, Pedidos Cancelados", oAppContext.ApplicationConfiguration.Almacen, oAppContext.ApplicationConfiguration.NoCaja)
                    Catch ex As Exception
                        EscribeLog(ex.ToString, "Error al guardar la autorizacion el servidor")
                    End Try
                End If
                oAppContext.Security.CloseImpersonatedSession()
            Else
                bRes = False
            End If
        End If

        Return bRes

    End Function

#End Region

#Region "Devolución Tarjeta"

    Private Sub Sm_ActionPreviewReporteDevolucionTarjeta(ByVal EsTarjeta As Boolean)

        Dim oARReporte As New CierreDiaDevolucionTarjeta(ebFecha.Value, GetAlmacen, EsTarjeta)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte Notas de Credito"
        oARReporte.Run()


        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

#End Region

#Region "Mejoras Microcreditos"

    Private Sub Sm_ActionPreviewReporteVentasTotalesMicrocredito()

        Dim oARReporte As New CierreDiaVentasTotalesMicrocreditos(ebFecha.Value, GetAlmacen)
        Dim oReportViewer As New ReportViewerForm

        oARReporte.Document.Name = "Reporte de ventas totales Microcreditos"
        oARReporte.Run()


        'Visualizar Reporte :

        oReportViewer.Report = oARReporte
        oReportViewer.Show()

    End Sub

#End Region

#Region "Mejoras en tiendas"

    Private Sub ReImprimirConcentradoAuditoria()
        If (oCierreDiasMgr.ValidarCierreDia(ebFecha.Value) = False) Then

            Dim oRepAud As New rptConcenAuditoria(ebFecha.Value, GetAlmacen())
            'Dim oReportViewer As New ReportViewerForm
            oRepAud.Document.Name = "Reporte Concentrador de Cierre de Caja (Auditoria)"
            oRepAud.Run()

            Try

                oRepAud.Document.Print(False, False)
                'oReportViewer.Report = oRepAud
                'oReportViewer.Show()

            Catch ex As Exception

                EscribeLog(ex.ToString, "Error al imprimir el nuevo reporte de auditoria en el cierre de dia")
                Throw New ApplicationException("Se produjó un error. El Reporte de Auditoria  no pudo ser impreso.", ex)

            End Try


            Dim oARReporte As New RptCierredeDia(ebFecha.Value)

            oARReporte.Document.Name = "Reportes de Cierre de Día"
            oARReporte.Run()

            Try

                oARReporte.Document.Print(False, False)
                'oReportViewer.Report = oARReporte
                'oReportViewer.Show()

            Catch ex As Exception

                EscribeLog(ex.ToString, "Error al imprimir el reporte del cierre de dia")
                Throw New ApplicationException("Se produjó un error. Los reportes del cierre de día no pudieron ser impresos.", ex)

            End Try

        Else
            MessageBox.Show("No se puede imprimir el concentrado de auditoría debido a que no se ha cerrado el día", "Cierre Día", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ReimprimirConcentradoDia()

        If (oCierreDiasMgr.ValidarCierreDia(ebFecha.Value) = False) Then
            If oAppContext.ApplicationConfiguration.MiniPrintName = String.Empty Then
                MessageBox.Show("No esta configurada la miniprinter", "Dportenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Try

                Dim oARReporte As New rptConcentradoMiniPrinter(ebFecha.Value, GetAlmacen())

                oARReporte.Document.Name = "Impresión Concentrado Mini Printer"

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
                    oARReporte.Document.Print(False, False)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Catch ex As ApplicationException
                MsgBox(ex.ToString)
            End Try
        Else
            MessageBox.Show("No se puede imprimir el concentrado del día debido a que no se ha cerrado el día", "Cierre Día", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region

    Private Sub LstReportes_DockChanged(sender As System.Object, e As System.EventArgs) Handles LstReportes.DockChanged

    End Sub
End Class
