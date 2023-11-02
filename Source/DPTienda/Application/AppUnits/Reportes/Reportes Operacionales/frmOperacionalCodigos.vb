Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports DportenisPro.DPTienda.Core
Imports Microsoft.Office.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports System.Threading
Imports Microsoft.Office.Interop
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmOperacionalCodigos
    Inherits System.Windows.Forms.Form
    Private oSubPro As Thread

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
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDel As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAl As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents dgCodigos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblFiltro As System.Windows.Forms.Label
    Friend WithEvents cmbFiltro As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOperacionalCodigos))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgCodigos = New Janus.Windows.GridEX.GridEX
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.cmbFiltro = New Janus.Windows.EditControls.UIComboBox
        Me.lblFiltro = New System.Windows.Forms.Label
        Me.btnExportar = New Janus.Windows.EditControls.UIButton
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton
        Me.cmbAl = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDel = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.Label8)
        Me.ExplorerBar1.Controls.Add(Me.Label7)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.dgCodigos)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Effect = Janus.Windows.ExplorerBar.Effect.None
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(720, 533)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(400, 512)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 19)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Exportar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(384, 512)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "F9"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(264, 512)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Salir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(240, 512)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ESC"
        '
        'dgCodigos
        '
        Me.dgCodigos.AllowColumnDrag = False
        Me.dgCodigos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        Me.dgCodigos.AlternatingColors = True
        Me.dgCodigos.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.dgCodigos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCodigos.AutomaticSort = False
        GridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><CellLayoutMode>UseColumnSets</CellLayoutMode><Colum" & _
        "nSets Collection=""true""><ColumnSet0 ID=""""><ColumnCount>1</ColumnCount><Position>" & _
        "0</Position><ColumnWidth0>147</ColumnWidth0><EntriesCount>1</EntriesCount><ColIn" & _
        "dex0>0</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1<" & _
        "/ColSpan0></ColumnSet0><ColumnSet1 ID=""""><Caption>Ventas</Caption><HeaderAlignme" & _
        "nt>Center</HeaderAlignment><Position>1</Position><HeaderStyle><FontBold>True</Fo" & _
        "ntBold><FontName>Tahoma</FontName></HeaderStyle><ColumnWidth0>106</ColumnWidth0>" & _
        "<ColumnWidth1>122</ColumnWidth1><EntriesCount>2</EntriesCount><ColIndex0>1</ColI" & _
        "ndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1</ColSpan0><C" & _
        "olIndex1>2</ColIndex1><Row1>0</Row1><Col1>1</Col1><RowSpan1>2</RowSpan1><ColSpan" & _
        "1>1</ColSpan1></ColumnSet1><ColumnSet2 ID=""""><Caption>Inventario Inicial</Captio" & _
        "n><ColumnCount>1</ColumnCount><HeaderAlignment>Center</HeaderAlignment><Position" & _
        ">2</Position><HeaderStyle><FontBold>True</FontBold><FontName>Tahoma</FontName></" & _
        "HeaderStyle><ColumnWidth0>146</ColumnWidth0><EntriesCount>1</EntriesCount><ColIn" & _
        "dex0>5</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1<" & _
        "/ColSpan0></ColumnSet2><ColumnSet3 ID=""""><Caption>Inventario Final</Caption><Col" & _
        "umnCount>1</ColumnCount><HeaderAlignment>Center</HeaderAlignment><Position>3</Po" & _
        "sition><HeaderStyle><FontBold>True</FontBold><FontName>Tahoma</FontName></Header" & _
        "Style><ColumnWidth0>139</ColumnWidth0><EntriesCount>1</EntriesCount><ColIndex0>7" & _
        "</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1</ColSp" & _
        "an0></ColumnSet3><ColumnSet4 ID=""""><Caption>General</Caption><HeaderAlignment>Ce" & _
        "nter</HeaderAlignment><Position>4</Position><Visible>False</Visible><HeaderStyle" & _
        "><FontBold>True</FontBold><FontName>Tahoma</FontName></HeaderStyle><ColumnWidth0" & _
        ">56</ColumnWidth0><ColumnWidth1>66</ColumnWidth1><EntriesCount>2</EntriesCount><" & _
        "ColIndex0>10</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSp" & _
        "an0>1</ColSpan0><ColIndex1>11</ColIndex1><Row1>0</Row1><Col1>1</Col1><RowSpan1>2" & _
        "</RowSpan1><ColSpan1>1</ColSpan1></ColumnSet4></ColumnSets><Columns Collection=""" & _
        "true""><Column0 ID=""Material""><AggregateFunction>Count</AggregateFunction><Captio" & _
        "n>Material</Caption><DataMember>Material</DataMember><HeaderAlignment>Center</He" & _
        "aderAlignment><Key>Material</Key><Position>0</Position><Width>147</Width><TotalF" & _
        "ormatString>n</TotalFormatString><CellStyle><FontBold>True</FontBold><FontName>T" & _
        "ahoma</FontName><TextAlignment>Near</TextAlignment></CellStyle><HeaderStyle><Fon" & _
        "tBold>True</FontBold></HeaderStyle></Column0><Column1 ID=""VentasPP""><AggregateFu" & _
        "nction>Sum</AggregateFunction><Caption>Pares/Piezas</Caption><DataMember>VenPP</" & _
        "DataMember><FormatString>n</FormatString><HeaderAlignment>Center</HeaderAlignmen" & _
        "t><Key>VentasPP</Key><Position>1</Position><Width>106</Width><TotalFormatString>" & _
        "n</TotalFormatString><CellStyle><TextAlignment>Center</TextAlignment></CellStyle" & _
        "><HeaderStyle><FontBold>True</FontBold><FontName>Tahoma</FontName></HeaderStyle>" & _
        "</Column1><Column2 ID=""VentasImpSIVA""><AggregateFunction>Sum</AggregateFunction>" & _
        "<Caption>Importe S/IVA</Caption><DataMember>VenSIVA</DataMember><FormatString>c<" & _
        "/FormatString><HeaderAlignment>Center</HeaderAlignment><Key>VentasImpSIVA</Key><" & _
        "Position>2</Position><Width>122</Width><TotalFormatString>c</TotalFormatString><" & _
        "CellStyle><TextAlignment>Center</TextAlignment></CellStyle><HeaderStyle><FontBol" & _
        "d>True</FontBold><FontName>Tahoma</FontName></HeaderStyle></Column2><Column3 ID=" & _
        """VentasCostoSIVA""><AggregateFunction>Sum</AggregateFunction><Caption>Costos S/IV" & _
        "A</Caption><DataMember>VenCoSIVA</DataMember><FormatString>c</FormatString><Head" & _
        "erAlignment>Center</HeaderAlignment><Key>VentasCostoSIVA</Key><Position>3</Posit" & _
        "ion><Visible>False</Visible><Width>94</Width><TotalFormatString>c</TotalFormatSt" & _
        "ring><CellStyle><TextAlignment>Center</TextAlignment></CellStyle><HeaderStyle><F" & _
        "ontBold>True</FontBold><FontName>Tahoma</FontName></HeaderStyle></Column3><Colum" & _
        "n4 ID=""VentasPPart""><AggregateFunction>Sum</AggregateFunction><Caption>% Part</C" & _
        "aption><DataMember>VenPPart</DataMember><FormatString>p</FormatString><HeaderAli" & _
        "gnment>Center</HeaderAlignment><Key>VentasPPart</Key><Position>4</Position><Visi" & _
        "ble>False</Visible><Width>50</Width><TotalFormatString>p</TotalFormatString><Cel" & _
        "lStyle><TextAlignment>Center</TextAlignment></CellStyle><HeaderStyle><Font>Tahom" & _
        "a, 8.25pt, style=Bold</Font><FontBold>True</FontBold></HeaderStyle></Column4><Co" & _
        "lumn5 ID=""IIPP""><AggregateFunction>Sum</AggregateFunction><Caption>Pares/Piezas<" & _
        "/Caption><DataMember>IIPP</DataMember><FormatString>n</FormatString><HeaderAlign" & _
        "ment>Center</HeaderAlignment><Key>IIPP</Key><Position>5</Position><Width>146</Wi" & _
        "dth><TotalFormatString>n</TotalFormatString><CellStyle><TextAlignment>Center</Te" & _
        "xtAlignment></CellStyle><HeaderStyle><FontBold>True</FontBold></HeaderStyle></Co" & _
        "lumn5><Column6 ID=""IIInvIniImp""><AggregateFunction>Sum</AggregateFunction><Capti" & _
        "on>Inv Inicial Imp</Caption><DataMember>IIPPSIVA</DataMember><FormatString>c</Fo" & _
        "rmatString><HeaderAlignment>Center</HeaderAlignment><Key>IIInvIniImp</Key><Posit" & _
        "ion>6</Position><Visible>False</Visible><Width>93</Width><TotalFormatString>c</T" & _
        "otalFormatString><CellStyle><TextAlignment>Center</TextAlignment></CellStyle><He" & _
        "aderStyle><FontBold>True</FontBold></HeaderStyle></Column6><Column7 ID=""IFPP""><A" & _
        "ggregateFunction>Sum</AggregateFunction><Caption>Pares/Piezas</Caption><DataMemb" & _
        "er>ifpp</DataMember><FormatString>n</FormatString><HeaderAlignment>Center</Heade" & _
        "rAlignment><Key>IFPP</Key><Position>7</Position><Width>139</Width><TotalFormatSt" & _
        "ring>n</TotalFormatString><CellStyle><TextAlignment>Center</TextAlignment></Cell" & _
        "Style><HeaderStyle><FontBold>True</FontBold></HeaderStyle></Column7><Column8 ID=" & _
        """IFInvFinImp""><AggregateFunction>Sum</AggregateFunction><Caption>Inv Final Imp</" & _
        "Caption><DataMember>IFPSIVA</DataMember><FormatString>c</FormatString><HeaderAli" & _
        "gnment>Center</HeaderAlignment><Key>IFInvFinImp</Key><Position>8</Position><Visi" & _
        "ble>False</Visible><Width>94</Width><TotalFormatString>c</TotalFormatString><Cel" & _
        "lStyle><TextAlignment>Center</TextAlignment></CellStyle><HeaderStyle><FontBold>T" & _
        "rue</FontBold></HeaderStyle></Column8><Column9 ID=""IFPPart""><AggregateFunction>S" & _
        "um</AggregateFunction><Caption>% Part</Caption><DataMember>PPart</DataMember><Fo" & _
        "rmatString>p</FormatString><HeaderAlignment>Center</HeaderAlignment><Key>IFPPart" & _
        "</Key><Position>9</Position><Visible>False</Visible><Width>68</Width><TotalForma" & _
        "tString>p</TotalFormatString><CellStyle><TextAlignment>Center</TextAlignment></C" & _
        "ellStyle><HeaderStyle><FontBold>True</FontBold></HeaderStyle></Column9><Column10" & _
        " ID=""GenRot""><AggregateFunction>Sum</AggregateFunction><Caption>Rotacion</Captio" & _
        "n><DataMember>Rotacion</DataMember><FormatString>n</FormatString><HeaderAlignmen" & _
        "t>Center</HeaderAlignment><Key>GenRot</Key><Position>10</Position><Visible>False" & _
        "</Visible><Width>56</Width><TotalFormatString>n</TotalFormatString><CellStyle><T" & _
        "extAlignment>Center</TextAlignment></CellStyle><HeaderStyle><FontBold>True</Font" & _
        "Bold></HeaderStyle></Column10><Column11 ID=""GenMgn""><Caption>Mgn%</Caption><Data" & _
        "Member>GenMgn</DataMember><FormatString>p</FormatString><HeaderAlignment>Center<" & _
        "/HeaderAlignment><Key>GenMgn</Key><Position>11</Position><Visible>False</Visible" & _
        "><Width>66</Width><TotalFormatString>p</TotalFormatString><CellStyle><TextAlignm" & _
        "ent>Center</TextAlignment></CellStyle><HeaderStyle><FontBold>True</FontBold></He" & _
        "aderStyle></Column11></Columns><ColumnSetHeaderLines>2</ColumnSetHeaderLines><Gr" & _
        "oupCondition ID="""" /></RootTable></GridEXLayoutData>"
        Me.dgCodigos.DesignTimeLayout = GridEXLayout1
        Me.dgCodigos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.dgCodigos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgCodigos.GroupByBoxVisible = False
        Me.dgCodigos.Location = New System.Drawing.Point(8, 108)
        Me.dgCodigos.Name = "dgCodigos"
        Me.dgCodigos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True
        Me.dgCodigos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgCodigos.Size = New System.Drawing.Size(708, 396)
        Me.dgCodigos.TabIndex = 2
        Me.dgCodigos.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        Me.dgCodigos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.cmbFiltro)
        Me.UiGroupBox1.Controls.Add(Me.lblFiltro)
        Me.UiGroupBox1.Controls.Add(Me.btnExportar)
        Me.UiGroupBox1.Controls.Add(Me.btnGenerar)
        Me.UiGroupBox1.Controls.Add(Me.cmbAl)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cmbDel)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(20, 12)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(684, 88)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Datos para el reporte"
        '
        'cmbFiltro
        '
        UiComboBoxItem1.FormatStyle.Alpha = 0
        UiComboBoxItem1.Text = "Ninguno"
        UiComboBoxItem1.Value = "0"
        UiComboBoxItem2.FormatStyle.Alpha = 0
        UiComboBoxItem2.Text = "+ Vendidos"
        UiComboBoxItem2.Value = "1"
        UiComboBoxItem3.FormatStyle.Alpha = 0
        UiComboBoxItem3.Text = "+ Importe"
        UiComboBoxItem3.Value = "2"
        Me.cmbFiltro.Items.AddRange(New Janus.Windows.EditControls.UIComboBoxItem() {UiComboBoxItem1, UiComboBoxItem2, UiComboBoxItem3})
        Me.cmbFiltro.Location = New System.Drawing.Point(216, 56)
        Me.cmbFiltro.Name = "cmbFiltro"
        Me.cmbFiltro.SelectedIndex = 0
        Me.cmbFiltro.Size = New System.Drawing.Size(124, 23)
        Me.cmbFiltro.TabIndex = 8
        Me.cmbFiltro.Text = "Ninguno"
        Me.cmbFiltro.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Location = New System.Drawing.Point(116, 56)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(96, 19)
        Me.lblFiltro.TabIndex = 7
        Me.lblFiltro.Text = "Tipo de filtro:"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnExportar.Location = New System.Drawing.Point(560, 28)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(92, 32)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(452, 28)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(92, 32)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'cmbAl
        '
        '
        'cmbAl.DropDownCalendar
        '
        Me.cmbAl.DropDownCalendar.Location = New System.Drawing.Point(0, 0)
        Me.cmbAl.DropDownCalendar.Name = ""
        Me.cmbAl.DropDownCalendar.Size = New System.Drawing.Size(164, 167)
        Me.cmbAl.DropDownCalendar.TabIndex = 0
        Me.cmbAl.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.cmbAl.Location = New System.Drawing.Point(264, 24)
        Me.cmbAl.Name = "cmbAl"
        Me.cmbAl.Size = New System.Drawing.Size(128, 23)
        Me.cmbAl.TabIndex = 3
        Me.cmbAl.Value = New Date(2009, 10, 26, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Al:"
        '
        'cmbDel
        '
        '
        'cmbDel.DropDownCalendar
        '
        Me.cmbDel.DropDownCalendar.Location = New System.Drawing.Point(0, 0)
        Me.cmbDel.DropDownCalendar.Name = ""
        Me.cmbDel.DropDownCalendar.Size = New System.Drawing.Size(164, 167)
        Me.cmbDel.DropDownCalendar.TabIndex = 0
        Me.cmbDel.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Standard
        Me.cmbDel.Location = New System.Drawing.Point(100, 24)
        Me.cmbDel.Name = "cmbDel"
        Me.cmbDel.Size = New System.Drawing.Size(124, 23)
        Me.cmbDel.TabIndex = 1
        Me.cmbDel.Value = New Date(2009, 10, 26, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generar del:"
        '
        'frmOperacionalCodigos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 533)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOperacionalCodigos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Operacional por Codigos"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Objetos"
    '''Factura
    Dim dsFacturas As DataSet
    Dim oManager As NotasCreditoManager


#End Region
#Region "Metodos"
    Private Sub Reporte()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim FechaIni As New Date
            Dim FechaFin As Date
            Dim FechaInicio As Date
            Dim FechaFinal As Date
            Dim CodAlmacen As String = ""
            Dim CodArticulo As String = ""
            Dim MesIni As Integer = 0
            Dim Dias As Integer
            'Dim Fecha As Date
            Dim MesFin As Integer = 0
            Dim Year As Integer = 0
            Dim YearNow As Integer = 0
            Dim TipoReporte As Integer = 2
            Dim InventarioGlobalPP As Double = 0
            'Se agrega un combo para poner el tipo de filtro
            Dim Filtro As Integer = 0
            Dim IVA As Decimal = oAppContext.ApplicationConfiguration.IVA
            CodAlmacen = oAppContext.ApplicationConfiguration.Almacen
            'Fecha = Me.cmbDel.Value

            FechaFin = Me.cmbAl.Value
            FechaIni = Me.cmbDel.Value
            MesIni = DatePart(DateInterval.Month, FechaIni)
            MesFin = DatePart(DateInterval.Month, FechaFin)
            Year = DatePart(DateInterval.Year, FechaIni)
            FechaInicio = "01/" & MesIni & "/" & Year

            Filtro = Me.cmbFiltro.SelectedIndex
            YearNow = DatePart(DateInterval.Year, Now)

            Select Case MesIni
                Case 2 : Dias = IIf(IsDate("29/" & MesIni & "/" & Now.Today.Year), 29, 28)
                Case 1, 3, 5, 7, 8, 10, 12 : Dias = 31
                Case 4, 6, 9, 11 : Dias = 30
            End Select

            FechaFinal = Dias & "/" & MesIni & "/" & Year
            Me.oManager = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)

            dsFacturas = oManager.ReporteOperacionalMaterial(CodAlmacen, Format(FechaIni, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"), Filtro, Year, YearNow, IVA)
            InventarioGlobalPP = oManager.Articulos_Globales(MesFin, TipoReporte)

            'Ventas/CostoSIVA
            dsFacturas.Tables(0).Columns.Add("VenCoSIVA", GetType(Decimal), " VenPP * CostoP ")
            dsFacturas.Tables(0).AcceptChanges()

            'Porcentaje Participacion
            dsFacturas.Tables(0).Columns.Add("VenPPart", GetType(Decimal), " VenSIVA / sum(VenSIVA)")
            dsFacturas.Tables(0).AcceptChanges()

            ''Mgn %	       
            dsFacturas.Tables(0).Columns.Add("GenMgn", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            'Inventario Inicial Pares/Piezas
            dsFacturas.Tables(0).Columns.Add("IIPP", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            'Inventario Inicial/Precio Venta S/Iva
            dsFacturas.Tables(0).Columns.Add("IIPPSIVA", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            'Inventairo FInal Pares/Piezas
            dsFacturas.Tables(0).Columns.Add("IFPP", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            'Inventario Final Importe/IF
            dsFacturas.Tables(0).Columns.Add("IFPSIVA", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            '% Part.	Total piezas inv final artículo * 100 / total global de las piezas en inventario								
            ' % Part = (IFPP * 100) / Total Global de las piezas en inventario
            dsFacturas.Tables(0).Columns.Add("PPart", GetType(Double))
            dsFacturas.Tables(0).AcceptChanges()

            'Utilidad
            dsFacturas.Tables(0).Columns.Add("Utilidad", GetType(Decimal), "VenSIVA-VenCoSIVA")
            dsFacturas.Tables(0).AcceptChanges()

            'Generales/Rotacion
            dsFacturas.Tables(0).Columns.Add("Rotacion", GetType(Decimal))
            dsFacturas.Tables(0).AcceptChanges()

            If Me.dsFacturas.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Los datos ingresados para el reporte no han producido ningun resultado, intente cambiando los datos.", "Informacion del reporte.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                For Each oROw As DataRow In Me.dsFacturas.Tables(0).Rows
                    CodArticulo = oROw.Item(0)
                    If MesIni <> MesFin Then
                        oROw("IIPP") = oManager.Inventario_Inicial_Cruzado(CodAlmacen, CodArticulo, MesIni, Format(FechaIni, "dd/MM/yyyy"), Format(FechaInicio, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"), Format(FechaFinal, "dd/MM/yyyy"))
                    Else
                        oROw("IIPP") = oManager.Inventario_Inicial(CodAlmacen, CodArticulo, MesIni, Format(FechaIni, "dd/MM/yyyy"), Format(FechaInicio, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"))
                    End If

                    oROw("IFPP") = oManager.Inventario_Final(CodAlmacen, CodArticulo, MesFin, Format(FechaIni, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"))
                    oROw("GenMgn") = oROw("Utilidad") / oROw("VenSIVA")

                    If oROw("IIPP") <> 0 Then
                        oROw("Rotacion") = (oROw.Item(4) * oROw("VenPP")) / oROw("IIPP")
                    Else
                        oROw("Rotacion") = 0
                    End If
                    oROw("IIPPSIVA") = oROw("IIPP") * oROw("CostoP")

                    oROw("IFPSIVA") = oROw("IFPP") * oROw("CostoP")

                    If oROw("IFPP") <> 0 Then
                        oROw("PPart") = (oROw("IFPP") * 100) / InventarioGlobalPP
                    Else
                        oROw("PPart") = 0
                    End If
                Next
            End If


            Me.dgCodigos.DataSource = dsFacturas
            dgCodigos.DataMember = dsFacturas.Tables(0).TableName
            MessageBox.Show("El reporte se ha cargado de forma correcta.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As DivideByZeroException
            MessageBox.Show("En el rango de fechas que ha seleccionado hay un valor igual a Cero (0).", "Error al generar el reporte.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

            Throw ex

        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region
#Region "ExportarExcel"
    Private Sub ExportaOrden(ByVal grid As DataView)
        Dim oExcel As Excel.ApplicationClass
        Dim oBooks As Excel.Workbooks
        Dim oBook As Excel.WorkbookClass
        Dim oSheet As Excel.Worksheet
        Dim oAlmacen As Almacen
        Dim oCatalogoAlmacenMgr As New CatalogoAlmacenesManager(oAppContext)
        Dim oSAPMgr As New ProcesoSAPManager(oAppContext, oAppSAPConfig)
        oAlmacen = oCatalogoAlmacenMgr.Load(oSAPMgr.Read_Centros) 'oAppContext.ApplicationConfiguration.Almacen)

        Dim CodFranquicia As String = oAppContext.ApplicationConfiguration.Almacen

        Dim dtrow As DataRow

        If oExcel Is Nothing Then
            oExcel = CreateObject("Excel.Application")
            If oExcel Is Nothing Then
                MsgBox("Necesita Microsoft Excel para utilizar esta opción.", vbCritical)
                Exit Sub
            Else
                oExcel.Visible = False
                oBooks = oExcel.Workbooks
                oBook = oExcel.Workbooks.Add
                oSheet = oBook.Sheets(1)
            End If
        Else
            oExcel = CreateObject("Excel.Application")
            oExcel.Visible = False
            oBooks = oExcel.Workbooks
            oBook = oExcel.Workbooks.Add
            oSheet = oBook.Sheets(1)
        End If

        Const ROW_FIRST = 6
        Dim i As Integer

        'Fila/Columna
        oSheet.Cells(1, 3) = "No Tienda:"
        oSheet.Cells(1, 4) = oAppContext.ApplicationConfiguration.Almacen
        oSheet.Cells(2, 3) = "Tienda:"
        oSheet.Cells(2, 4) = oAlmacen.Descripcion
        oSheet.Cells(3, 3) = "Fecha Del reporte:"
        oSheet.Cells(3, 4) = "Del: " & Me.cmbDel.Text
        oSheet.Cells(3, 5) = "Al: " & Me.cmbAl.Text
        oSheet.Cells(4, 3) = "Filtro Aplicado:" & Me.cmbFiltro.Text



        oSheet.Range("B5:C5").Merge()
        oSheet.Cells(5, 2) = "VENTAS"
        oSheet.Range("B5:C5").VerticalAlignment = 3
        oSheet.Range("B5:C5").HorizontalAlignment = 3
        oSheet.Cells(5, 2).font.bold = True


        oSheet.Range("D5:D5").Merge()
        oSheet.Cells(5, 4) = "INVENTARIO INICIAL"
        oSheet.Range("D5:D5").VerticalAlignment = 3
        oSheet.Range("D5:D5").HorizontalAlignment = 3
        oSheet.Cells(5, 4).font.bold = True
        'oSheet.Columns(6).HorizontalAlignment = 3


        oSheet.Range("E5:E5").Merge()
        oSheet.Cells(5, 5) = "INVENTARIO FINAL"
        oSheet.Range("E5:E5").VerticalAlignment = 3
        oSheet.Range("E5:E5").HorizontalAlignment = 3
        oSheet.Cells(5, 5).font.bold = True

        'oSheet.Range("K5:L5").Merge()
        'oSheet.Cells(5, 11) = "GENERAL"
        'oSheet.Range("K5:L5").VerticalAlignment = 3
        'oSheet.Range("K5:L5").HorizontalAlignment = 3
        'oSheet.Cells(5, 11).font.bold = True

        oSheet.Cells(ROW_FIRST, 1) = "Material"
        oSheet.Cells(ROW_FIRST, 2) = "Pares / Piezas"
        oSheet.Cells(ROW_FIRST, 3) = "Importe s/iva"
        'oSheet.Cells(ROW_FIRST, 4) = "Costo s/iva"
        'oSheet.Cells(ROW_FIRST, 5) = "% Part"
        'InventarioInicial
        oSheet.Cells(ROW_FIRST, 4) = "Pares / Piezas"
        'oSheet.Cells(ROW_FIRST, 7) = "Inv. Inicial Imp."
        'InventarioFInal
        oSheet.Cells(ROW_FIRST, 5) = "Pares / Piezas"
        'oSheet.Cells(ROW_FIRST, 9) = "Inv. Final Imp."
        'oSheet.Cells(ROW_FIRST, 10) = "% Part"
        'Generales
        'oSheet.Cells(ROW_FIRST, 11) = "Rotacion"
        'oSheet.Cells(ROW_FIRST, 12) = "Mgn %"




        For i = 1 To 15
            oSheet.Cells(ROW_FIRST, i).font.bold = True
            oSheet.Columns(i).ColumnWidth = 25
            If i = 1 Then
                oSheet.Columns(i).HorizontalAlignment = 3
            Else
                oSheet.Columns(i).HorizontalAlignment = 1
            End If

        Next
        oSheet.Columns(3).columnWidth = 35

        Dim ix, ii As Integer

        ix = grid.Count + ROW_FIRST
        ii = 0

        For iRow As Integer = ROW_FIRST + 1 To ix

            'Ventas
            oSheet.Cells(iRow, 1) = grid.Item(ii).Item("Material") ' "Material"
            oSheet.Cells(iRow, 2) = Format(grid.Item(ii).Item("VenPP"), "n") ' "Pares / Piezas"
            oSheet.Cells(iRow, 3) = Format(grid.Item(ii).Item("VenSIVA"), "c") ' "Importe s/iva"
            'oSheet.Cells(iRow, 4) = Format(grid.Item(ii).Item("VenCoSIVA"), "c") ' "Costo s/iva"
            'oSheet.Cells(iRow, 5) = Format(grid.Item(ii).Item("VenPPart"), "p") ' Ventas % Part
            'InventarioInicial
            oSheet.Cells(iRow, 4) = Format(grid.Item(ii).Item("IIPP"), "n") ' "Pares / Piezas"
            'oSheet.Cells(iRow, 7) = Format(grid.Item(ii).Item("IIPPSIVA"), "c") ' "Inv. Inicial Imp."
            'InventarioFInal
            oSheet.Cells(iRow, 5) = Format(grid.Item(ii).Item("IFPP"), "n") ' "Pares / Piezas"
            'oSheet.Cells(iRow, 9) = Format(grid.Item(ii).Item("IFPSIVA"), "c") ' "Inv. Final Imp."
            'oSheet.Cells(iRow, 10) = Format(grid.Item(ii).Item("PPart"), "p") ' "% Part"
            'Generales
            'oSheet.Cells(iRow, 11) = Format(grid.Item(ii).Item("Rotacion"), "n") ' "Rotacion"
            'oSheet.Cells(iRow, 12) = Format(grid.Item(ii).Item("GenMgn"), "p") ' "Mgn %"


            ii = ii + 1
        Next


        oSheet.Cells(ix + 1, 2).Value = "=SUMA(B7:B" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 2).font.bold = True
        oSheet.Cells(ix + 1, 3).Value = "=SUMA(C7:C" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 3).font.bold = True
        oSheet.Cells(ix + 1, 4).Value = "=SUMA(D7:D" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 4).font.bold = True
        oSheet.Cells(ix + 1, 5).Value = "=SUMA(E7:E" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 5).font.bold = True
        'oSheet.Cells(ix + 1, 6).Value = "=SUMA(F7:F" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 6).font.bold = True
        'oSheet.Cells(ix + 1, 7).Value = "=SUMA(G7:G" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 7).font.bold = True
        'oSheet.Cells(ix + 1, 8).Value = "=SUMA(H7:H" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 8).font.bold = True
        'oSheet.Cells(ix + 1, 9).Value = "=SUMA(I7:I" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 9).Font.Bold = True
        'oSheet.Cells(ix + 1, 10).Value = "=SUMA(J7:J" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 10).font.bold = True
        'oSheet.Cells(ix + 1, 11).Value = "=SUMA(K7:K" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 11).font.bold = True
        'oSheet.Cells(ix + 1, 12).Value = "=G" & Trim(Str(ix + 1)) & "/D" & Trim(Str(ix + 1))
        'oSheet.Cells(ix + 1, 12).font.bold = True
        'oSheet.Range("L" & ix + 1 & ":L" & ix + 1).NumberFormat = "###,###,###.00"


        'oSheet.Cells(ix + 1, 13).Value = "=SUMA(M7:M" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 13).font.bold = True

        'oSheet.Cells(ix + 1, 14).Value = "=(M" & Trim(Str(ix + 1)) & "/C" & Trim(Str(ix + 1)) & ")"
        'oSheet.Cells(ix + 1, 14).font.bold = True
        'oSheet.Range("N" & ix + 1 & ":N" & ix + 1).NumberFormat = "0.00%"
        oSheet.Columns.AutoFit()



        If Me.SaveFileDialog.ShowDialog = DialogResult.OK Then
            Try
                oBook.SaveAs(SaveFileDialog.FileName)
                MsgBox("Ya se guardó el archivo en '" & SaveFileDialog.FileName & "'", MsgBoxStyle.Information)
            Catch es As Exception
            End Try
        End If



        oExcel.Visible = True

    End Sub
#End Region
#Region "EventosForm"
    Private Sub frmOperacionalCodigos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor
            ExportaOrden(Me.dsFacturas.Tables(0).DefaultView)
            Me.Cursor = Cursors.Default
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        If Me.cmbFiltro.Text = "" Then
            MessageBox.Show("UFF! para poder generar el reporte se necesita poner un tipo de filtro, seleccione uno e intente de nuevo.", "Falta Filtro.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbFiltro.Focus()
        Else
            Dim result As DialogResult
            result = MessageBox.Show("El reporte podria tardar varios minutos, desea continuar?", "Infomacion del reporte.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If result = DialogResult.Yes Then
                oSubPro = New Thread(AddressOf Reporte)
                oSubPro.Start()
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.Cursor = Cursors.WaitCursor
        ExportaOrden(Me.dsFacturas.Tables(0).DefaultView)
        Me.Cursor = Cursors.Default
    End Sub
#End Region


End Class
