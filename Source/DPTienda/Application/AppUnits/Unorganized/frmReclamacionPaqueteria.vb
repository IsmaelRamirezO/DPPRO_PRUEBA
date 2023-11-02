Imports DataDynamics.ActiveReports.Export.Pdf
Imports System.IO
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmReclamacionPaqueteria
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Inicializar()
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
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents rbPMM As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents lblLabel3 As System.Windows.Forms.Label
    Friend WithEvents rbDHL As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbEstafeta As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cmbPaqueterias As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents expPMM As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents ebChofer2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ebChofer1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ebNombrePersona As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblLabel1 As System.Windows.Forms.Label
    Friend WithEvents ebComentarios As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents expDHL As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents rbDaños As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTotal As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbParcial As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents ebDaños As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDaños As System.Windows.Forms.Label
    Friend WithEvents ebNoReporteDHL As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ebNoGuia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLabel6 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaEnvio As Janus.Windows.CalendarCombo.CalendarCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReclamacionPaqueteria))
        Me.explorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebNoGuia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ebNombrePersona = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.ebComentarios = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPaqueterias = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.rbEstafeta = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDHL = New Janus.Windows.EditControls.UIRadioButton()
        Me.lblLabel3 = New System.Windows.Forms.Label()
        Me.rbPMM = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.expDHL = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.cmbFechaEnvio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblLabel6 = New System.Windows.Forms.Label()
        Me.ebNoReporteDHL = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ebDaños = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.lblDaños = New System.Windows.Forms.Label()
        Me.rbDaños = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTotal = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbParcial = New Janus.Windows.EditControls.UIRadioButton()
        Me.expPMM = New Janus.Windows.ExplorerBar.ExplorerBar()
        Me.ebChofer2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ebChofer1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.explorerBar1.SuspendLayout()
        CType(Me.expDHL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expDHL.SuspendLayout()
        CType(Me.expPMM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expPMM.SuspendLayout()
        Me.SuspendLayout()
        '
        'explorerBar1
        '
        Me.explorerBar1.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.None
        Me.explorerBar1.Controls.Add(Me.ebNoGuia)
        Me.explorerBar1.Controls.Add(Me.Label3)
        Me.explorerBar1.Controls.Add(Me.ebNombrePersona)
        Me.explorerBar1.Controls.Add(Me.lblLabel1)
        Me.explorerBar1.Controls.Add(Me.ebComentarios)
        Me.explorerBar1.Controls.Add(Me.Label4)
        Me.explorerBar1.Controls.Add(Me.cmbPaqueterias)
        Me.explorerBar1.Controls.Add(Me.rbEstafeta)
        Me.explorerBar1.Controls.Add(Me.rbDHL)
        Me.explorerBar1.Controls.Add(Me.lblLabel3)
        Me.explorerBar1.Controls.Add(Me.rbPMM)
        Me.explorerBar1.Controls.Add(Me.btnCancelar)
        Me.explorerBar1.Controls.Add(Me.btnAceptar)
        Me.explorerBar1.Controls.Add(Me.expDHL)
        Me.explorerBar1.Controls.Add(Me.expPMM)
        Me.explorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.explorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.explorerBar1.Name = "explorerBar1"
        Me.explorerBar1.Size = New System.Drawing.Size(482, 432)
        Me.explorerBar1.TabIndex = 0
        Me.explorerBar1.Text = "ExplorerBar1"
        Me.explorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'ebNoGuia
        '
        Me.ebNoGuia.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoGuia.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoGuia.Enabled = False
        Me.ebNoGuia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoGuia.Location = New System.Drawing.Point(8, 88)
        Me.ebNoGuia.Name = "ebNoGuia"
        Me.ebNoGuia.Size = New System.Drawing.Size(136, 23)
        Me.ebNoGuia.TabIndex = 3
        Me.ebNoGuia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "No. Guía"
        '
        'ebNombrePersona
        '
        Me.ebNombrePersona.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNombrePersona.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNombrePersona.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNombrePersona.Location = New System.Drawing.Point(8, 208)
        Me.ebNombrePersona.Name = "ebNombrePersona"
        Me.ebNombrePersona.Size = New System.Drawing.Size(464, 23)
        Me.ebNombrePersona.TabIndex = 5
        Me.ebNombrePersona.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombrePersona.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel1.Location = New System.Drawing.Point(8, 192)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(251, 23)
        Me.lblLabel1.TabIndex = 124
        Me.lblLabel1.Text = "Nombre Persona Recibe"
        '
        'ebComentarios
        '
        Me.ebComentarios.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebComentarios.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebComentarios.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebComentarios.Location = New System.Drawing.Point(8, 128)
        Me.ebComentarios.Multiline = True
        Me.ebComentarios.Name = "ebComentarios"
        Me.ebComentarios.Size = New System.Drawing.Size(464, 64)
        Me.ebComentarios.TabIndex = 4
        Me.ebComentarios.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebComentarios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 23)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Comentarios"
        '
        'cmbPaqueterias
        '
        Me.cmbPaqueterias.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.cmbPaqueterias.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.cmbPaqueterias.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        GridEXLayout1.LayoutString = resources.GetString("GridEXLayout1.LayoutString")
        Me.cmbPaqueterias.DesignTimeLayout = GridEXLayout1
        Me.cmbPaqueterias.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPaqueterias.Location = New System.Drawing.Point(280, 40)
        Me.cmbPaqueterias.Name = "cmbPaqueterias"
        Me.cmbPaqueterias.ReadOnly = True
        Me.cmbPaqueterias.Size = New System.Drawing.Size(144, 23)
        Me.cmbPaqueterias.TabIndex = 119
        Me.cmbPaqueterias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbPaqueterias.Visible = False
        Me.cmbPaqueterias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'rbEstafeta
        '
        Me.rbEstafeta.BackColor = System.Drawing.Color.Transparent
        Me.rbEstafeta.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEstafeta.Location = New System.Drawing.Point(144, 40)
        Me.rbEstafeta.Name = "rbEstafeta"
        Me.rbEstafeta.Size = New System.Drawing.Size(103, 24)
        Me.rbEstafeta.TabIndex = 2
        Me.rbEstafeta.Text = "ESTAFETA"
        Me.rbEstafeta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbDHL
        '
        Me.rbDHL.BackColor = System.Drawing.Color.Transparent
        Me.rbDHL.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDHL.Location = New System.Drawing.Point(80, 40)
        Me.rbDHL.Name = "rbDHL"
        Me.rbDHL.Size = New System.Drawing.Size(64, 24)
        Me.rbDHL.TabIndex = 1
        Me.rbDHL.Text = "DHL"
        Me.rbDHL.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'lblLabel3
        '
        Me.lblLabel3.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel3.Location = New System.Drawing.Point(8, 16)
        Me.lblLabel3.Name = "lblLabel3"
        Me.lblLabel3.Size = New System.Drawing.Size(456, 23)
        Me.lblLabel3.TabIndex = 116
        Me.lblLabel3.Text = "Selecciona la paquetería"
        '
        'rbPMM
        '
        Me.rbPMM.BackColor = System.Drawing.Color.Transparent
        Me.rbPMM.Checked = True
        Me.rbPMM.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPMM.Location = New System.Drawing.Point(8, 40)
        Me.rbPMM.Name = "rbPMM"
        Me.rbPMM.Size = New System.Drawing.Size(64, 24)
        Me.rbPMM.TabIndex = 0
        Me.rbPMM.TabStop = True
        Me.rbPMM.Text = "PMM"
        Me.rbPMM.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageSize = New System.Drawing.Size(25, 25)
        Me.btnCancelar.Location = New System.Drawing.Point(280, 392)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(192, 32)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageSize = New System.Drawing.Size(25, 25)
        Me.btnAceptar.Location = New System.Drawing.Point(8, 392)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(192, 32)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Emitir Carta"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'expDHL
        '
        Me.expDHL.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.RaisedLight3D
        Me.expDHL.Controls.Add(Me.cmbFechaEnvio)
        Me.expDHL.Controls.Add(Me.lblLabel6)
        Me.expDHL.Controls.Add(Me.ebNoReporteDHL)
        Me.expDHL.Controls.Add(Me.Label5)
        Me.expDHL.Controls.Add(Me.ebDaños)
        Me.expDHL.Controls.Add(Me.lblDaños)
        Me.expDHL.Controls.Add(Me.rbDaños)
        Me.expDHL.Controls.Add(Me.rbTotal)
        Me.expDHL.Controls.Add(Me.rbParcial)
        Me.expDHL.Location = New System.Drawing.Point(8, 240)
        Me.expDHL.Name = "expDHL"
        Me.expDHL.Size = New System.Drawing.Size(464, 144)
        Me.expDHL.TabIndex = 6
        Me.expDHL.Visible = False
        Me.expDHL.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2010
        '
        'cmbFechaEnvio
        '
        '
        '
        '
        Me.cmbFechaEnvio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        Me.cmbFechaEnvio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFechaEnvio.Location = New System.Drawing.Point(344, 48)
        Me.cmbFechaEnvio.Name = "cmbFechaEnvio"
        Me.cmbFechaEnvio.Size = New System.Drawing.Size(112, 22)
        Me.cmbFechaEnvio.TabIndex = 11
        Me.cmbFechaEnvio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003
        '
        'lblLabel6
        '
        Me.lblLabel6.AutoSize = True
        Me.lblLabel6.BackColor = System.Drawing.Color.Transparent
        Me.lblLabel6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel6.Location = New System.Drawing.Point(264, 48)
        Me.lblLabel6.Name = "lblLabel6"
        Me.lblLabel6.Size = New System.Drawing.Size(78, 14)
        Me.lblLabel6.TabIndex = 134
        Me.lblLabel6.Text = "Fecha Envío"
        '
        'ebNoReporteDHL
        '
        Me.ebNoReporteDHL.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebNoReporteDHL.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebNoReporteDHL.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebNoReporteDHL.Location = New System.Drawing.Point(88, 48)
        Me.ebNoReporteDHL.Name = "ebNoReporteDHL"
        Me.ebNoReporteDHL.Size = New System.Drawing.Size(112, 23)
        Me.ebNoReporteDHL.TabIndex = 10
        Me.ebNoReporteDHL.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNoReporteDHL.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 14)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "No. Reporte"
        '
        'ebDaños
        '
        Me.ebDaños.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebDaños.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebDaños.Enabled = False
        Me.ebDaños.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDaños.Location = New System.Drawing.Point(8, 96)
        Me.ebDaños.Multiline = True
        Me.ebDaños.Name = "ebDaños"
        Me.ebDaños.Size = New System.Drawing.Size(448, 40)
        Me.ebDaños.TabIndex = 12
        Me.ebDaños.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDaños.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblDaños
        '
        Me.lblDaños.AutoSize = True
        Me.lblDaños.BackColor = System.Drawing.Color.Transparent
        Me.lblDaños.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaños.Location = New System.Drawing.Point(8, 80)
        Me.lblDaños.Name = "lblDaños"
        Me.lblDaños.Size = New System.Drawing.Size(174, 14)
        Me.lblDaños.TabIndex = 129
        Me.lblDaños.Text = "En caso de daño especificar"
        '
        'rbDaños
        '
        Me.rbDaños.BackColor = System.Drawing.Color.Transparent
        Me.rbDaños.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDaños.Location = New System.Drawing.Point(288, 8)
        Me.rbDaños.Name = "rbDaños"
        Me.rbDaños.Size = New System.Drawing.Size(120, 24)
        Me.rbDaños.TabIndex = 9
        Me.rbDaños.Text = "Daños"
        Me.rbDaños.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbTotal
        '
        Me.rbTotal.BackColor = System.Drawing.Color.Transparent
        Me.rbTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTotal.Location = New System.Drawing.Point(152, 8)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(120, 24)
        Me.rbTotal.TabIndex = 8
        Me.rbTotal.Text = "Pérdida Total"
        Me.rbTotal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'rbParcial
        '
        Me.rbParcial.BackColor = System.Drawing.Color.Transparent
        Me.rbParcial.Checked = True
        Me.rbParcial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbParcial.Location = New System.Drawing.Point(8, 8)
        Me.rbParcial.Name = "rbParcial"
        Me.rbParcial.Size = New System.Drawing.Size(120, 24)
        Me.rbParcial.TabIndex = 7
        Me.rbParcial.TabStop = True
        Me.rbParcial.Text = "Pérdida Parcial"
        Me.rbParcial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
        '
        'expPMM
        '
        Me.expPMM.BorderStyle = Janus.Windows.ExplorerBar.BorderStyle.RaisedLight3D
        Me.expPMM.Controls.Add(Me.ebChofer2)
        Me.expPMM.Controls.Add(Me.Label2)
        Me.expPMM.Controls.Add(Me.ebChofer1)
        Me.expPMM.Controls.Add(Me.Label1)
        Me.expPMM.Location = New System.Drawing.Point(8, 240)
        Me.expPMM.Name = "expPMM"
        Me.expPMM.Size = New System.Drawing.Size(464, 144)
        Me.expPMM.TabIndex = 6
        Me.expPMM.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'ebChofer2
        '
        Me.ebChofer2.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebChofer2.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebChofer2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebChofer2.Location = New System.Drawing.Point(8, 72)
        Me.ebChofer2.Name = "ebChofer2"
        Me.ebChofer2.Size = New System.Drawing.Size(448, 23)
        Me.ebChofer2.TabIndex = 8
        Me.ebChofer2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebChofer2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 23)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Nombre Chofer 2"
        '
        'ebChofer1
        '
        Me.ebChofer1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ebChofer1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ebChofer1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebChofer1.Location = New System.Drawing.Point(8, 24)
        Me.ebChofer1.Name = "ebChofer1"
        Me.ebChofer1.Size = New System.Drawing.Size(448, 23)
        Me.ebChofer1.TabIndex = 7
        Me.ebChofer1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebChofer1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 23)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Nombre Chofer 1"
        '
        'frmReclamacionPaqueteria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(482, 432)
        Me.Controls.Add(Me.explorerBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReclamacionPaqueteria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reclamación Paqueteria"
        CType(Me.explorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.explorerBar1.ResumeLayout(False)
        Me.explorerBar1.PerformLayout()
        CType(Me.expDHL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expDHL.ResumeLayout(False)
        Me.expDHL.PerformLayout()
        CType(Me.expPMM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expPMM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public strCodSucOrigen As String = ""
    Public strGuia As String = ""
    Public strNoBultos As String = ""
    Public strPiezasFaltantes As String = ""
    Public dvFaltantes As DataView
    Public strFolioTraspaso As String = ""
    Public strTransportista As String = ""
    Public dtTraspasoSAP As DataTable

    Dim oSAPMgr As ProcesoSAPManager

    Private Sub Inicializar()
        oSAPMgr = New ProcesoSAPManager(oAppContext, oAppSAPConfig)
    End Sub

    Private Sub FillPaqueterias()

        Dim dtPaqueterias As DataTable

        dtPaqueterias = oSAPMgr.ZPAQUETERIAS_RETR

        With Me.cmbPaqueterias
            .Clear()
            .DropDownList.Columns.Add("Descripción")
            .DataSource = dtPaqueterias
            '.DropDownList.Columns("Cod.").Width = 50
            .DropDownList.Columns("Descripción").DataMember = "Paqueteria"
            .DropDownList.Columns("Descripción").Width = 200
            .DisplayMember = "Paqueteria"
            .ValueMember = "Paqueteria"
            .Refresh()
        End With

    End Sub

    Private Sub ImprimirCartaReclamacion()

        Try
            Dim Paqueteria As String = ""
1:          Dim oRptView As New ReportViewerForm
2:          Dim oARReclam As DataDynamics.ActiveReports.ActiveReport
3:          Dim oARReclamDet As DataDynamics.ActiveReports.ActiveReport
            Dim bDetalle As Boolean = False

            If Me.rbDHL.Checked Then

                Paqueteria = "DHL"

                Dim TipoPerdida As String = ""

                If Me.rbParcial.Checked Then
                    TipoPerdida = "Parcial"
                ElseIf Me.rbTotal.Checked Then
                    TipoPerdida = "Total"
                ElseIf Me.rbDaños.Checked Then
                    TipoPerdida = "Daños"
                End If

                bDetalle = True

4:              oARReclamDet = New rptCartaReclamacionDHLDetalle(dvFaltantes)

5:              oARReclam = New rptCartaReclamacionDHL(strCodSucOrigen, Me.ebNoGuia.Text.Trim, strNoBultos, strPiezasFaltantes, _
                                       Me.ebComentarios.Text.Trim, dvFaltantes, strFolioTraspaso, Paqueteria, _
                                       Me.ebNombrePersona.Text.Trim, dtTraspasoSAP, TipoPerdida, Me.ebDaños.Text.Trim, _
                                       Me.ebNoReporteDHL.Text, Me.cmbFechaEnvio.Value, Me.ebNoReporteDHL.Text)

            ElseIf Me.rbEstafeta.Checked Then

                Paqueteria = "ESTAFETA"

6:              oARReclam = New rptCartaReclamacionPMM(strCodSucOrigen, Me.ebNoGuia.Text.Trim, strNoBultos, strPiezasFaltantes, _
                                                       Me.ebComentarios.Text.Trim, dvFaltantes, strFolioTraspaso, Paqueteria, _
                                                       Me.ebNombrePersona.Text.Trim, Me.ebChofer1.Text.Trim, Me.ebChofer2.Text.Trim, _
                                                       dtTraspasoSAP)

            ElseIf Me.rbPMM.Checked Then

                Paqueteria = "PMM"

7:              oARReclam = New rptCartaReclamacionPMM(strCodSucOrigen, strGuia, strNoBultos, strPiezasFaltantes, Me.ebComentarios.Text.Trim, _
                                                       dvFaltantes, strFolioTraspaso, Paqueteria, Me.ebNombrePersona.Text.Trim, _
                                                       Me.ebChofer1.Text.Trim, Me.ebChofer2.Text.Trim, dtTraspasoSAP)
            End If

8:          oARReclam.Document.Name = "Carta Reclamación A " & Paqueteria '& IIf(Me.rbDHL.Checked, "DHL", "PMM")
9:          oARReclam.Run()

10:         ExportarPDF(Paqueteria & "_" & strFolioTraspaso.Trim, oARReclam.Document, True)

11:         oRptView.Report = oARReclam

12:         oRptView.Show()

            If bDetalle Then

13:             oRptView = New ReportViewerForm

14:             oARReclamDet.Document.Name = "Carta Reclamación A " & Paqueteria '& IIf(Me.rbDHL.Checked, "DHL", "PMM")
15:             oARReclamDet.Run()

16:             ExportarPDF("Detalle" & Paqueteria & "_" & strFolioTraspaso.Trim, oARReclamDet.Document, False)

17:             oRptView.Report = oARReclamDet

18:             oRptView.Show()

            End If

            '5:          oARReclam.Document.Print(False, False)

            '6:          oARReclam = New rptCartaReclamacionPMM(strCodSucOrigen, strGuia, strNoBultos, strPiezasFaltantes, Me.ebComentarios.Text.Trim, _
            '                                                        dvFaltantes, strFolioTraspaso, IIf(Me.rbDHL.Checked, "DHL", "P. M. M."), Me.ebNombrePersona.Text.Trim, _
            '                                                        Me.ebChofer1.Text.Trim, Me.ebChofer2.Text.Trim, dtTraspasoSAP)

            '7:          oARReclam.Document.Name = "Carta Reclamación A " & IIf(Me.rbDHL.Checked, "DHL", "PMM")
            '8:          oARReclam.Run()

            '9:          oRptView.Report = oARReclam

            '10:         oARReclam.Document.Print(False, False)

        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al imprimir carta reclamacion del traspaso " & strFolioTraspaso.Trim & " Linea: " & Err.Erl)
        End Try

    End Sub

    Private Sub ExportarPDF(ByVal NombreArchivo As String, ByVal Doc As DataDynamics.ActiveReports.Document.Document, ByVal bMsg As Boolean)

        Try
1:          Dim oExp As New PdfExport
2:          Dim ruta As String = "C:\CartasReclamacion\" & Format(Today, "ddMMyyyy") & "\"
3:          Dim archivo As String = "CartaReclamacion" & NombreArchivo & "_" & Format(Now, "HHmmss") & ".pdf"

4:          If Directory.Exists(ruta) = False Then
5:              Directory.CreateDirectory(ruta)
            End If
6:          oExp.Export(Doc, ruta & archivo)

7:          If bMsg Then MessageBox.Show("La carta de reclamación se guardó en " & ruta & archivo, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            EscribeLog(ex.ToString, "Error al guardar carta reclamación paqueteria en pdf: Linea " & Err.Erl)
        End Try

    End Sub

    Private Sub MostrarDatosPaqueteria()

        LimpiarDatos()

        If Me.rbPMM.Checked OrElse Me.rbEstafeta.Checked Then
            Me.expPMM.Visible = True
            Me.expDHL.Visible = False
        ElseIf Me.rbDHL.Checked Then
            Me.expDHL.Visible = True
            Me.expPMM.Visible = False
        End If

    End Sub

    Private Sub LimpiarDatos()

        Me.ebNoGuia.Text = strGuia
        If Me.ebNoGuia.Text.Trim <> "" Then
            Me.ebNoGuia.Enabled = False
        Else
            Me.ebNoGuia.Enabled = True
        End If
        Me.ebComentarios.Text = ""
        Me.ebNombrePersona.Text = ""
        Me.ebChofer1.Text = ""
        Me.ebChofer2.Text = ""
        Me.rbParcial.Checked = True
        'Me.rbPMM.Checked = True
        Me.ebNoReporteDHL.Text = ""
        Me.ebDaños.Text = ""

    End Sub

    Private Function ValidaCampos() As Boolean

        Dim bRes As Boolean = True

        If Me.ebNoGuia.Text.Trim = "" Then ' AndAlso Me.rbPMM.Checked = False Then
            MessageBox.Show("Es necesario especificar el número de guía.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNoGuia.Focus()
            bRes = False
        ElseIf Me.ebComentarios.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar la razón de la carta reclamación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebComentarios.Focus()
            bRes = False
        ElseIf Me.ebNombrePersona.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar el nombre de la persona que esta recibiendo la mercancia.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNombrePersona.Focus()
            bRes = False
        ElseIf Me.rbDHL.Checked AndAlso Me.ebNoReporteDHL.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar el número de reporte levantado ante DHL.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebNoReporteDHL.Focus()
            bRes = False
        ElseIf Me.rbDHL.Checked AndAlso Me.rbDaños.Checked AndAlso Me.ebDaños.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar los daños.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebDaños.Focus()
            bRes = False
        ElseIf Me.rbDHL.Checked = False AndAlso Me.ebChofer1.Text.Trim = "" Then
            MessageBox.Show("Es necesario especificar al menos el nombre de un chofer.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ebChofer1.Focus()
            bRes = False
        End If

        Return bRes

    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ValidaCampos() Then
            ValidaTransportista()
            ImprimirCartaReclamacion()
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub ValidaTransportista()

        If InStr(Me.strTransportista.Trim.ToUpper, "DHL") > 0 Then
            If Me.rbPMM.Checked OrElse Me.rbEstafeta.Checked Then
                If MessageBox.Show("La paqueteria que estas eligiendo no coincide con la del Traspaso." & vbCrLf & "¿Estas seguro que deseas cambiar de Paqueteria?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.rbDHL.Checked = True
                End If
            End If
        ElseIf InStr(Me.strTransportista.Trim.ToUpper, "PMM") > 0 Then
            If Me.rbDHL.Checked OrElse Me.rbEstafeta.Checked Then
                If MessageBox.Show("La paqueteria que estas eligiendo no coincide con la del Traspaso." & vbCrLf & "¿Estas seguro que deseas cambiar de Paqueteria?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.rbPMM.Checked = True
                End If
            End If
        ElseIf InStr(Me.strTransportista.Trim.ToUpper, "ESTAFETA") > 0 Then
            If Me.rbDHL.Checked OrElse Me.rbPMM.Checked Then
                If MessageBox.Show("La paqueteria que estas eligiendo no coincide con la del Traspaso." & vbCrLf & "¿Estas seguro que deseas cambiar de Paqueteria?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.rbEstafeta.Checked = True
                End If
            End If
        End If

    End Sub

    Private Sub frmReclamacionPaqueteria_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.DialogResult = DialogResult.Cancel AndAlso MessageBox.Show("¿Estas seguro que deseas cancelar la emision de la carta reclamacion a la paqueteria?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub frmReclamacionPaqueteria_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub frmReclamacionPaqueteria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Me.strTransportista.Trim.Trim <> "" Then
        If InStr(Me.strTransportista.Trim.ToUpper, "DHL") > 0 Then
            Me.rbDHL.Checked = True
        ElseIf InStr(Me.strTransportista.Trim.ToUpper, "ESTAFETA") > 0 Then
            Me.rbEstafeta.Checked = True
        Else
            Me.rbPMM.Checked = True
        End If
        'End If
    End Sub

    Private Sub rbPMM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPMM.CheckedChanged, rbDHL.CheckedChanged, rbEstafeta.CheckedChanged
        MostrarDatosPaqueteria()
    End Sub

    Private Sub rbDaños_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDaños.CheckedChanged

        Me.ebDaños.Enabled = Me.rbDaños.Checked
        If Me.rbDaños.Checked = False Then Me.ebDaños.Text = ""

    End Sub

End Class
