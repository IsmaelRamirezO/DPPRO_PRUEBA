
Imports DportenisPro.DPTienda.ApplicationUnits.ContabilizacionAU

Public Class FrmSegmentoContableDetalle
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
    Friend WithEvents grSegmentos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSegmentoContableDetalle))
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup()
        Me.grSegmentos = New Janus.Windows.GridEX.GridEX()
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.grSegmentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grSegmentos
        '
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.grSegmentos.DesignTimeLayout = GridEXLayout1
        Me.grSegmentos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grSegmentos.GroupByBoxVisible = False
        Me.grSegmentos.Location = New System.Drawing.Point(0, 0)
        Me.grSegmentos.Name = "grSegmentos"
        Me.grSegmentos.Size = New System.Drawing.Size(800, 264)
        Me.grSegmentos.TabIndex = 13
        Me.grSegmentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.ExplorerBar1.Controls.Add(Me.btnGuardar)
        Me.ExplorerBar1.Controls.Add(Me.grSegmentos)
        Me.ExplorerBar1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExplorerBarGroup1.Expandable = False
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.ShowGroupCaption = False
        ExplorerBarGroup1.Text = "Definición de Segmentos Contables"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(824, 312)
        Me.ExplorerBar1.TabIndex = 4
        Me.ExplorerBar1.TabStop = False
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(691, 272)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(104, 32)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'FrmSegmentoContableDetalle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(800, 310)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSegmentoContableDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Segmentos Contables"
        CType(Me.grSegmentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Member Variables"

    Private oSegmentoContable As SegmentoContable

    Private dsSegmentoContable As DataSet

    Private strCuenta As String

    Dim strTabla As String

    Dim strStoredProcedure As String

#End Region




#Region "Constructors"

    'Public Sub New(ByVal Cuenta As String)

    '    strCuenta = Cuenta

    'End Sub
#End Region




#Region "Properties"

    Public WriteOnly Property Cuenta() As String
        Set(ByVal Value As String)
            strCuenta = Value
        End Set
    End Property

#End Region




#Region "Member Methods"

    Private Sub Sm_InitializeObjects()

        oSegmentoContable = New SegmentoContable(oAppContext)


        Select Case strCuenta

            Case "Almacen"

                strTabla = "CatalogoAlmacenes"

                strStoredProcedure = "SegmentosContablesAlmacenUpd"

                dsSegmentoContable = oSegmentoContable.SelectDetail("SegmentosContablesAlmacenSel", strTabla)


            Case "Banco"

                strStoredProcedure = "SegmentosContablesBancoUpd"

                strTabla = "CatalogoBancos"

                dsSegmentoContable = oSegmentoContable.SelectDetail("SegmentosContablesBancoSel", strTabla)


            Case "TipoDescuento"

                strStoredProcedure = "SegmentosContablesTipoDescuentoUpd"

                strTabla = "CatalogoTipoDescuento"

                dsSegmentoContable = oSegmentoContable.SelectDetail("SegmentosContablesTipoDescuentoSel", strTabla)


            Case "FormaPago"

                strStoredProcedure = "SegmentosContablesFormasPagoUpd"

                strTabla = "CatalogoFormasPago"

                dsSegmentoContable = oSegmentoContable.SelectDetail("SegmentosContablesFormasPagoSel", strTabla)


            Case "TipoVenta"

                strStoredProcedure = "SegmentosContablesTipoVentaUpd"

                strTabla = "CatalogoTipoVenta"

                dsSegmentoContable = oSegmentoContable.SelectDetail("SegmentosContablesTipoVentaSel", strTabla)


            Case "Cliente"

                strTabla = "Clientes"

                dsSegmentoContable = oSegmentoContable.SelectDetailClientes

        End Select


        grSegmentos.SetDataBinding(dsSegmentoContable, strTabla)

        Sm_GridHeaderCaption()

    End Sub




    Private Sub Sm_FinalizeObjetcs()

        oSegmentoContable = Nothing

        dsSegmentoContable = Nothing

    End Sub




    Private Sub Sm_GridHeaderCaption()

        Select Case strCuenta

            Case "Almacen"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "ALM01"

                    .Columns("C02").Caption = "ALM02"

                    .Columns("C03").Caption = "ALM03"

                    .Columns("C04").Caption = "ALM04"

                    .Columns("C05").Caption = "ALM05"

                End With


            Case "Banco"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "BAN01"

                    .Columns("C02").Caption = "BAN02"

                    .Columns("C03").Caption = "BAN03"

                    .Columns("C04").Caption = "BAN04"

                    .Columns("C05").Caption = "BAN05"

                End With


            Case "TipoDescuento"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "TD01"

                    .Columns("C02").Caption = "TD02"

                    .Columns("C03").Caption = "TD03"

                    .Columns("C04").Caption = "TD04"

                    .Columns("C05").Caption = "TD05"

                End With


            Case "FormaPago"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "FP01"

                    .Columns("C02").Caption = "FP02"

                    .Columns("C03").Caption = "FP03"

                    .Columns("C04").Caption = "FP04"

                    .Columns("C05").Caption = "FP05"

                End With


            Case "TipoVenta"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "TV01"

                    .Columns("C02").Caption = "TV02"

                    .Columns("C03").Caption = "TV03"

                    .Columns("C04").Caption = "TV04"

                    .Columns("C05").Caption = "TV05"

                End With


            Case "Cliente"

                With grSegmentos.Tables(0)

                    .Columns("C01").Caption = "CLI01"

                    .Columns("C02").Caption = "CLI02"

                    .Columns("C03").Caption = "CLI03"

                    .Columns("C04").Caption = "CLI04"

                    .Columns("C05").Caption = "CLI05"

                End With

        End Select

    End Sub



    Private Function Fm_bolValidar() As Boolean

        Dim dr As DataRow

        For Each dr In dsSegmentoContable.Tables(strTabla).Rows

            If IsDBNull(dr!C01) = True Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            ElseIf (Trim(dr!C01) = String.Empty) Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            End If


            If IsDBNull(dr!C02) = True Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            ElseIf (Trim(dr!C02) = String.Empty) Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            End If


            If IsDBNull(dr!C03) = True Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            ElseIf (Trim(dr!C03) = String.Empty) Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            End If


            If IsDBNull(dr!C04) = True Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            ElseIf (Trim(dr!C04) = String.Empty) Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            End If


            If IsDBNull(dr!C05) = True Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            ElseIf (Trim(dr!C05) = String.Empty) Then

                MsgBox("En el Registro " & dr!Codigo & " falta información.")
                Exit Function

            End If

        Next

        Return True

    End Function



    Private Sub Sm_GuardarSegmentosContables()

        If Not (strCuenta = "Cliente" Or strCuenta = "Almacen") Then

            If (Fm_bolValidar() = False) Then
                Return
            End If

        End If




        If (strCuenta = "Cliente") Then

            oSegmentoContable.SegmentosContablesDetalleClientesUpd(dsSegmentoContable)


            grSegmentos.SetDataBinding(dsSegmentoContable, strTabla)

            'Sm_GridHeaderCaption()

        Else

            oSegmentoContable.SegmentosContablesDetalleUpd(dsSegmentoContable, strStoredProcedure, strTabla)

        End If

        MsgBox("Registros Guardados", MsgBoxStyle.Exclamation, "DPTienda")

    End Sub

#End Region



#Region "Members Methods [Events]"

    Private Sub FrmSegmentoContableDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Sm_InitializeObjects()

    End Sub



    Private Sub FrmSegmentoContableDetalle_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Sm_FinalizeObjetcs()

    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Sm_GuardarSegmentosContables()

    End Sub

#End Region

End Class
