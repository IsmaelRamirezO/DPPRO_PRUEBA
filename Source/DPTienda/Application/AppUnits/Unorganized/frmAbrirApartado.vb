Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoCajas
Imports DportenisPro.DPTienda.ApplicationUnits.ContratosAU

Public Class frmAbrirApartado
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents explorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents uIButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents uIButton2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents lblCodCaja As System.Windows.Forms.Label
    Friend WithEvents ebFolioApartado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebCodCaja As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents grpGroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbrirApartado))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.uIButton2 = New Janus.Windows.EditControls.UIButton()
        Me.uIButton1 = New Janus.Windows.EditControls.UIButton()
        Me.grpGroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblCodCaja = New System.Windows.Forms.Label()
        Me.ebFolioApartado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ebCodCaja = New Janus.Windows.GridEX.EditControls.EditBox()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        Me.grpGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.Controls.Add(Me.uIButton2)
        Me.explorerBar1.Controls.Add(Me.uIButton1)
        Me.explorerBar1.Controls.Add(Me.grpGroupBox1)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Expanded = False
        ExplorerBarGroup1.Image = CType(resources.GetObject("ExplorerBarGroup1.Image"), System.Drawing.Image)
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Datos Generales"
        Me.explorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(274, 183)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'uIButton2
        '
        Me.uIButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uIButton2.Location = New System.Drawing.Point(153, 136)
        Me.uIButton2.Name = "uIButton2"
        Me.uIButton2.Size = New System.Drawing.Size(104, 28)
        Me.uIButton2.TabIndex = 3
        Me.uIButton2.Text = "&Cancelar"
        Me.uIButton2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'uIButton1
        '
        Me.uIButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uIButton1.Location = New System.Drawing.Point(17, 136)
        Me.uIButton1.Name = "uIButton1"
        Me.uIButton1.Size = New System.Drawing.Size(104, 28)
        Me.uIButton1.TabIndex = 2
        Me.uIButton1.Text = "&Aceptar"
        Me.uIButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'grpGroupBox1
        '
        Me.grpGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.grpGroupBox1.Controls.Add(Me.lblLabel1)
        Me.grpGroupBox1.Controls.Add(Me.lblCodCaja)
        Me.grpGroupBox1.Controls.Add(Me.ebFolioApartado)
        Me.grpGroupBox1.Controls.Add(Me.ebCodCaja)
        Me.grpGroupBox1.Location = New System.Drawing.Point(13, 32)
        Me.grpGroupBox1.Name = "grpGroupBox1"
        Me.grpGroupBox1.Size = New System.Drawing.Size(248, 88)
        Me.grpGroupBox1.TabIndex = 1
        Me.grpGroupBox1.TabStop = False
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(28, 52)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(96, 16)
        Me.lblLabel1.TabIndex = 10
        Me.lblLabel1.Text = "Folio Apartado  :"
        '
        'lblCodCaja
        '
        Me.lblCodCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblCodCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodCaja.Location = New System.Drawing.Point(28, 20)
        Me.lblCodCaja.Name = "lblCodCaja"
        Me.lblCodCaja.Size = New System.Drawing.Size(96, 16)
        Me.lblCodCaja.TabIndex = 9
        Me.lblCodCaja.Text = "Cod. Caja         :"
        '
        'ebFolioApartado
        '
        Me.ebFolioApartado.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebFolioApartado.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioApartado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebFolioApartado.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebFolioApartado.Location = New System.Drawing.Point(132, 49)
        Me.ebFolioApartado.MaxLength = 8
        Me.ebFolioApartado.Name = "ebFolioApartado"
        Me.ebFolioApartado.Size = New System.Drawing.Size(88, 22)
        Me.ebFolioApartado.TabIndex = 8
        Me.ebFolioApartado.Text = "0"
        Me.ebFolioApartado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebFolioApartado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebFolioApartado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ebCodCaja
        '
        Me.ebCodCaja.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebCodCaja.ButtonFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodCaja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebCodCaja.Location = New System.Drawing.Point(132, 17)
        Me.ebCodCaja.MaxLength = 2
        Me.ebCodCaja.Name = "ebCodCaja"
        Me.ebCodCaja.Size = New System.Drawing.Size(48, 22)
        Me.ebCodCaja.TabIndex = 7
        Me.ebCodCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.ebCodCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmAbrirApartado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(274, 183)
        Me.ControlBox = False
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAbrirApartado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   Abrir Apartado"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.grpGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    'Variable Caja
    Dim oCajasMgr As CatalogoCajaManager
    Dim oCajas As Caja

    'Varable Contrato
    Dim oContratoMgr As ContratoManager
    Public oContrato As Contrato

#Region "Inicializar"

    Private Sub InitializeObjects()

        'Variable Cajas
        oCajasMgr = New CatalogoCajaManager(oAppContext)
        oCajas = oCajasMgr.Create

        'Varable Contratos
        oContratoMgr = New ContratoManager(oAppContext)
        oContrato = oContratoMgr.Create

    End Sub

#End Region

#Region "Methods"

    Private Sub frmAbrirApartado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeObjects()

    End Sub

#End Region

    Private Sub ebCodCaja_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        If ebCodCaja.Text <> String.Empty Then

            If IsNumeric(ebCodCaja.Text) Then

                ebCodCaja.Text = Format(Val(ebCodCaja.Text), "00")
                oCajas = Nothing
                oCajas = oCajasMgr.Create
                oCajas = oCajasMgr.Load(ebCodCaja.Text)

                If oCajas Is Nothing Then

                    MsgBox("Código de Caja no Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, " Abrir Apartado")
                    e.Cancel = True

                End If

            Else

                ebCodCaja.Text = ""
                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub uIButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uIButton2.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub frmAbrirApartado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                SendKeys.Send("{TAB}")

            Case Keys.Escape

                Me.DialogResult = DialogResult.Cancel

        End Select

    End Sub

    Private Sub uIButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uIButton1.Click

        If ebCodCaja.Text = String.Empty Then

            MsgBox("Ingrese Código de Caja donde se realizó el Apartado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abrir Apartado")
            ebCodCaja.Focus()
            Exit Sub

        End If

        If ebFolioApartado.Value <= 0 Then

            MsgBox("Ingrese Folio de Apartado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abrir Apartado")
            ebFolioApartado.Focus()
            Exit Sub

        End If

        'Cargamos el Apartado

        SelectFolioApartadoCaja(ebCodCaja.Text, ebFolioApartado.Value)
        If oContrato.ID = 0 Then

            MsgBox("El Folio del Apartado No Existe. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abrir Apartado")

        Else

            If oContrato.Entregada = "S" Then

                MsgBox("El Folio de Apartado ya fue Facturado. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abrir Apartado")

            Else

                If oContrato.Saldo > 0 Then

                    MsgBox("El Apartado está pendiente de Liquidación. ", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, " Abrir Apartado")

                Else

                    Me.DialogResult = DialogResult.OK

                End If

            End If

        End If

    End Sub

#Region "Methods"

    Private Sub [SelectFolioApartadoCaja](ByVal vCodCaja As String, ByVal vFolioApartado As Integer)

        oContrato = Nothing
        oContrato = oContratoMgr.Create

        Dim sccnnConnection As New SqlConnection(oAppContext.ApplicationConfiguration.DataStorageConfiguration.GetConnectionString)

        Dim sccmdSelect As SqlCommand
        Dim scdrReader As SqlDataReader

        Dim dsDataSet As DataSet
        dsDataSet = New DataSet("Apartados")

        sccmdSelect = New SqlCommand

        With sccmdSelect

            .Connection = sccnnConnection
            .CommandText = "[ApartadosSelFolioCaja]"
            .CommandType = System.Data.CommandType.StoredProcedure

            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodCaja", System.Data.SqlDbType.VarChar, 2))
            .Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolioApartado", System.Data.SqlDbType.Int, 4))

        End With

        Try

            sccnnConnection.Open()

            With sccmdSelect
                'Assign Parameters Values
                .Parameters("@CodCaja").Value = vCodCaja
                .Parameters("@FolioApartado").Value = vFolioApartado

                'Execute Command
                scdrReader = .ExecuteReader(CommandBehavior.SingleResult And CommandBehavior.SingleRow)

                'Assign Other Values
                scdrReader.Read()

                If (scdrReader.HasRows) Then

                    'Traspaso General :
                    With scdrReader

                        oContrato.ID = .GetInt32(0)
                        oContrato.FolioApartado = .GetInt32(1)
                        oContrato.PlayerID = .GetString(2)
                        oContrato.ClienteID = .GetString(3)
                        oContrato.ImporteTotal = .GetDecimal(4)
                        oContrato.Saldo = .GetDecimal(5)
                        oContrato.DescuentoTotal = .GetDecimal(6)

                        If (IsDBNull(.Item(7)) = False) Then
                            oContrato.TipoDescuentoID = .GetString(7)
                        Else
                            oContrato.TipoDescuentoID = String.Empty
                        End If

                        oContrato.IVA = .GetDecimal(8)
                        oContrato.Entregada = .GetString(9)
                        oContrato.ComentarioDesc = .GetString(10)
                        oContrato.Usuario = .GetString(11)
                        oContrato.Fecha = .GetDateTime(12)
                        oContrato.StatusRegistro = .GetBoolean(13)
                        oContrato.CodCaja = .GetString(14)
                        oContrato.Referencia = CStr(scdrReader("Referencia"))
                        .Close()

                    End With


                    'Traspaso Corrida [GRID] :

                    Dim scdaAdapter As New SqlDataAdapter

                    sccmdSelect.Dispose()
                    sccmdSelect = Nothing

                    sccmdSelect = New SqlCommand

                    With sccmdSelect

                        .Connection = sccnnConnection

                        .CommandText = "[ApartadosDetalleSel]"
                        .CommandType = System.Data.CommandType.StoredProcedure

                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
                        .Parameters.Add(New System.Data.SqlClient.SqlParameter("@ApartadoID", System.Data.SqlDbType.Int))

                        .Parameters("@ApartadoID").Value = oContrato.ID

                    End With

                    scdaAdapter.SelectCommand = sccmdSelect
                    scdaAdapter.Fill(dsDataSet, "ContratoDetalle")

                    oContrato.Detalle = dsDataSet

                    dsDataSet.Dispose()
                    sccmdSelect.Dispose()
                    scdaAdapter.Dispose()

                    dsDataSet = Nothing
                    sccmdSelect = Nothing
                    scdaAdapter = Nothing

                Else

                    oContrato.ID = 0

                End If

            End With

            sccnnConnection.Close()

        Catch oSqlException As SqlException

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de base de datos.", oSqlException)

        Catch ex As Exception

            If (sccnnConnection.State <> ConnectionState.Closed) Then
                Try
                    sccnnConnection.Close()
                Catch
                End Try
            End If

            Throw New ApplicationException("El registro no pudo ser leido debido a un error de aplicación.", ex)

        End Try

        sccnnConnection.Dispose()
        sccnnConnection = Nothing

    End Sub

#End Region


End Class
