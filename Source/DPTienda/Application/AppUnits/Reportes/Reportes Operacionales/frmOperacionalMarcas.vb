Imports DportenisPro.DPTienda.Core
Imports Microsoft.Office.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoAlmacenes
Imports DportenisPro.DPTienda.ApplicationUnits.NotasCreditoAU
Imports System.Threading
Imports Microsoft.Office.Interop
Imports DportenisPro.DPTienda.ApplicationUnits.ProcesoSAPAU

Public Class frmOperacionalMarcas
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDel As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grMarcas As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbAl As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbFiltro As Janus.Windows.EditControls.UIComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim UiComboBoxItem1 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem2 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim UiComboBoxItem3 As Janus.Windows.EditControls.UIComboBoxItem = New Janus.Windows.EditControls.UIComboBoxItem
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOperacionalMarcas))
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grMarcas = New Janus.Windows.GridEX.GridEX
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.cmbFiltro = New Janus.Windows.EditControls.UIComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnExportar = New Janus.Windows.EditControls.UIButton
        Me.btnGenerar = New Janus.Windows.EditControls.UIButton
        Me.cmbAl = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDel = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.grMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.Label6)
        Me.ExplorerBar1.Controls.Add(Me.Label5)
        Me.ExplorerBar1.Controls.Add(Me.Label4)
        Me.ExplorerBar1.Controls.Add(Me.Label3)
        Me.ExplorerBar1.Controls.Add(Me.grMarcas)
        Me.ExplorerBar1.Controls.Add(Me.UiGroupBox1)
        Me.ExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExplorerBar1.Location = New System.Drawing.Point(0, 0)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(896, 533)
        Me.ExplorerBar1.TabIndex = 0
        Me.ExplorerBar1.Text = "ExplorerBar1"
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(400, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "F9"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(288, 512)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "ESC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(424, 512)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Exportar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(320, 512)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Salir"
        '
        'grMarcas
        '
        Me.grMarcas.AllowColumnDrag = False
        Me.grMarcas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        Me.grMarcas.AlternatingColors = True
        Me.grMarcas.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.grMarcas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grMarcas.AutomaticSort = False
        GridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><CellLayoutMode>UseColumnSets</CellLayoutMode><Colum" & _
        "nSets Collection=""true""><ColumnSet0 ID=""ColumnSet1""><Key>ColumnSet1</Key><Column" & _
        "Count>1</ColumnCount><Position>0</Position><ColumnWidth0>61</ColumnWidth0><Entri" & _
        "esCount>1</EntriesCount><ColIndex0>0</ColIndex0><Row0>0</Row0><Col0>0</Col0><Row" & _
        "Span0>2</RowSpan0><ColSpan0>1</ColSpan0></ColumnSet0><ColumnSet1 ID=""""><Caption>" & _
        "Ventas</Caption><ColumnCount>3</ColumnCount><HeaderLineAlignment>Center</HeaderL" & _
        "ineAlignment><Position>1</Position><HeaderStyle><FontBold>True</FontBold><TextAl" & _
        "ignment>Center</TextAlignment></HeaderStyle><ColumnWidth0>106</ColumnWidth0><Col" & _
        "umnWidth1>100</ColumnWidth1><ColumnWidth2>100</ColumnWidth2><EntriesCount>4</Ent" & _
        "riesCount><ColIndex0>2</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSp" & _
        "an0><ColSpan0>1</ColSpan0><ColIndex1>3</ColIndex1><Row1>0</Row1><Col1>1</Col1><R" & _
        "owSpan1>2</RowSpan1><ColSpan1>1</ColSpan1><ColIndex2>4</ColIndex2><Row2>0</Row2>" & _
        "<Col2>2</Col2><RowSpan2>2</RowSpan2><ColSpan2>1</ColSpan2><ColIndex3>5</ColIndex" & _
        "3><Row3>0</Row3><Col3>2</Col3><RowSpan3>2</RowSpan3><ColSpan3>1</ColSpan3></Colu" & _
        "mnSet1><ColumnSet2 ID=""""><Caption>Inventario Inicial</Caption><HeaderLineAlignme" & _
        "nt>Center</HeaderLineAlignment><Position>2</Position><Visible>False</Visible><He" & _
        "aderStyle><FontBold>True</FontBold><TextAlignment>Center</TextAlignment></Header" & _
        "Style><ColumnWidth0>89</ColumnWidth0><ColumnWidth1>100</ColumnWidth1><EntriesCou" & _
        "nt>2</EntriesCount><ColIndex0>6</ColIndex0><Row0>0</Row0><Col0>0</Col0><RowSpan0" & _
        ">2</RowSpan0><ColSpan0>1</ColSpan0><ColIndex1>7</ColIndex1><Row1>0</Row1><Col1>1" & _
        "</Col1><RowSpan1>2</RowSpan1><ColSpan1>1</ColSpan1></ColumnSet2><ColumnSet3 ID=""" & _
        """><Caption>Inventario Final</Caption><ColumnCount>3</ColumnCount><Position>3</Po" & _
        "sition><HeaderStyle><FontBold>True</FontBold><TextAlignment>Center</TextAlignmen" & _
        "t></HeaderStyle><ColumnWidth0>125</ColumnWidth0><ColumnWidth1>100</ColumnWidth1>" & _
        "<ColumnWidth2>85</ColumnWidth2><EntriesCount>3</EntriesCount><ColIndex0>8</ColIn" & _
        "dex0><Row0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1</ColSpan0><Co" & _
        "lIndex1>9</ColIndex1><Row1>0</Row1><Col1>1</Col1><RowSpan1>2</RowSpan1><ColSpan1" & _
        ">1</ColSpan1><ColIndex2>10</ColIndex2><Row2>0</Row2><Col2>2</Col2><RowSpan2>2</R" & _
        "owSpan2><ColSpan2>1</ColSpan2></ColumnSet3><ColumnSet4 ID=""""><Caption>General</C" & _
        "aption><Position>4</Position><HeaderStyle><FontBold>True</FontBold><TextAlignmen" & _
        "t>Center</TextAlignment></HeaderStyle><ColumnWidth0>104</ColumnWidth0><ColumnWid" & _
        "th1>87</ColumnWidth1><EntriesCount>2</EntriesCount><ColIndex0>11</ColIndex0><Row" & _
        "0>0</Row0><Col0>0</Col0><RowSpan0>2</RowSpan0><ColSpan0>1</ColSpan0><ColIndex1>1" & _
        "2</ColIndex1><Row1>0</Row1><Col1>1</Col1><RowSpan1>2</RowSpan1><ColSpan1>1</ColS" & _
        "pan1></ColumnSet4></ColumnSets><Columns Collection=""true""><Column0 ID=""Marca""><A" & _
        "ggregateFunction>Count</AggregateFunction><Caption>Marca</Caption><DataMember>Ma" & _
        "rca</DataMember><Key>Marca</Key><Position>0</Position><Width>61</Width><TotalFor" & _
        "matString>n</TotalFormatString><CellStyle><FontBold>True</FontBold></CellStyle><" & _
        "HeaderStyle><FontBold>True</FontBold></HeaderStyle></Column0><Column1 ID=""Codigo" & _
        "s""><AggregateFunction>Sum</AggregateFunction><Caption>Codigos</Caption><DataMemb" & _
        "er>Codigos</DataMember><FormatString>n</FormatString><HeaderLineAlignment>Center" & _
        "</HeaderLineAlignment><Key>Codigos</Key><Position>1</Position><TextAlignment>Cen" & _
        "ter</TextAlignment><Visible>False</Visible><Width>65</Width><TotalFormatString>n" & _
        "</TotalFormatString><HeaderStyle><FontBold>True</FontBold><TextAlignment>Center<" & _
        "/TextAlignment></HeaderStyle></Column1><Column2 ID=""VenPP""><AggregateFunction>Su" & _
        "m</AggregateFunction><Caption>Pares/Piezas</Caption><DataMember>VenPP</DataMembe" & _
        "r><FormatString>n</FormatString><Key>VenPP</Key><Position>2</Position><TextAlign" & _
        "ment>Center</TextAlignment><Width>106</Width><TotalFormatString>n</TotalFormatSt" & _
        "ring><HeaderStyle><FontBold>True</FontBold><TextAlignment>Center</TextAlignment>" & _
        "</HeaderStyle></Column2><Column3 ID=""VenImpSIVA""><AggregateFunction>Sum</Aggrega" & _
        "teFunction><Caption>Importe S/IVA</Caption><DataMember>VenInvSIVA</DataMember><F" & _
        "ormatString>c</FormatString><Key>VenImpSIVA</Key><Position>3</Position><TextAlig" & _
        "nment>Center</TextAlignment><TotalFormatString>c</TotalFormatString><HeaderStyle" & _
        "><FontBold>True</FontBold><TextAlignment>Center</TextAlignment></HeaderStyle></C" & _
        "olumn3><Column4 ID=""VenCosSIVA""><AggregateFunction>Sum</AggregateFunction><Capti" & _
        "on>Costo S/IVA</Caption><DataMember>VenCoSIVA</DataMember><FormatString>c</Forma" & _
        "tString><Key>VenCosSIVA</Key><Position>4</Position><TextAlignment>Center</TextAl" & _
        "ignment><Visible>False</Visible><TotalFormatString>c</TotalFormatString><HeaderS" & _
        "tyle><FontBold>True</FontBold><TextAlignment>Center</TextAlignment></HeaderStyle" & _
        "></Column4><Column5 ID=""VenPPart""><AggregateFunction>Sum</AggregateFunction><Cap" & _
        "tion>% Part</Caption><DataMember>VenPPart</DataMember><FormatString>p</FormatStr" & _
        "ing><Key>VenPPart</Key><Position>5</Position><TextAlignment>Center</TextAlignmen" & _
        "t><TotalFormatString>p</TotalFormatString><HeaderStyle><FontBold>True</FontBold>" & _
        "<TextAlignment>Center</TextAlignment></HeaderStyle></Column5><Column6 ID=""InvIni" & _
        "PP""><AggregateFunction>Sum</AggregateFunction><Caption>Pares/Piezas</Caption><Da" & _
        "taMember>InvIniPP</DataMember><FormatString>n</FormatString><Key>InvIniPP</Key><" & _
        "Position>6</Position><TextAlignment>Center</TextAlignment><Visible>False</Visibl" & _
        "e><Width>89</Width><TotalFormatString>n</TotalFormatString><HeaderStyle><FontBol" & _
        "d>True</FontBold><TextAlignment>Center</TextAlignment></HeaderStyle></Column6><C" & _
        "olumn7 ID=""InvIniImp""><AggregateFunction>Sum</AggregateFunction><Caption>Inv Ini" & _
        "cial Importe</Caption><DataMember>IIIMP</DataMember><FormatString>c</FormatStrin" & _
        "g><Key>InvIniImp</Key><Position>7</Position><TextAlignment>Center</TextAlignment" & _
        "><Visible>False</Visible><TotalFormatString>c</TotalFormatString><HeaderStyle><F" & _
        "ontBold>True</FontBold><TextAlignment>Center</TextAlignment></HeaderStyle></Colu" & _
        "mn7><Column8 ID=""InvFinPP""><AggregateFunction>Sum</AggregateFunction><Caption>Pa" & _
        "res/Piezas</Caption><DataMember>IFPP</DataMember><FormatString>n</FormatString><" & _
        "Key>InvFinPP</Key><Position>8</Position><TextAlignment>Center</TextAlignment><Wi" & _
        "dth>125</Width><TotalFormatString>n</TotalFormatString><HeaderStyle><FontBold>Tr" & _
        "ue</FontBold><TextAlignment>Center</TextAlignment></HeaderStyle></Column8><Colum" & _
        "n9 ID=""InvFinImp""><AggregateFunction>Sum</AggregateFunction><Caption>Inv Final I" & _
        "mporte</Caption><DataMember>IFImp</DataMember><FormatString>c</FormatString><Key" & _
        ">InvFinImp</Key><Position>9</Position><TextAlignment>Center</TextAlignment><Tota" & _
        "lFormatString>c</TotalFormatString><HeaderStyle><FontBold>True</FontBold><TextAl" & _
        "ignment>Center</TextAlignment></HeaderStyle></Column9><Column10 ID=""InvFinPPart""" & _
        "><AggregateFunction>Sum</AggregateFunction><Caption>% Part</Caption><DataMember>" & _
        "IFPPart</DataMember><FormatString>p</FormatString><Key>InvFinPPart</Key><Positio" & _
        "n>10</Position><TextAlignment>Center</TextAlignment><Width>85</Width><TotalForma" & _
        "tString>p</TotalFormatString><HeaderStyle><FontBold>True</FontBold><TextAlignmen" & _
        "t>Center</TextAlignment></HeaderStyle></Column10><Column11 ID=""GenRot""><Aggregat" & _
        "eFunction>Sum</AggregateFunction><Caption>Rotacion</Caption><DataMember>Rotacion" & _
        "</DataMember><FormatString>n</FormatString><Key>GenRot</Key><Position>11</Positi" & _
        "on><TextAlignment>Center</TextAlignment><Width>104</Width><TotalFormatString>n</" & _
        "TotalFormatString><HeaderStyle><FontBold>True</FontBold><TextAlignment>Center</T" & _
        "extAlignment></HeaderStyle></Column11><Column12 ID=""GenMgn""><Caption>Mgn %</Capt" & _
        "ion><DataMember>Margen</DataMember><FormatString>p</FormatString><Key>GenMgn</Ke" & _
        "y><Position>12</Position><TextAlignment>Center</TextAlignment><Width>87</Width><" & _
        "TotalFormatString>p</TotalFormatString><HeaderStyle><FontBold>True</FontBold><Te" & _
        "xtAlignment>Center</TextAlignment></HeaderStyle></Column12></Columns><ColumnSetH" & _
        "eaderLines>3</ColumnSetHeaderLines><GroupCondition ID="""" /></RootTable></GridEXL" & _
        "ayoutData>"
        Me.grMarcas.DesignTimeLayout = GridEXLayout1
        Me.grMarcas.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grMarcas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grMarcas.GroupByBoxVisible = False
        Me.grMarcas.Location = New System.Drawing.Point(8, 108)
        Me.grMarcas.Name = "grMarcas"
        Me.grMarcas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True
        Me.grMarcas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.grMarcas.Size = New System.Drawing.Size(880, 396)
        Me.grMarcas.TabIndex = 2
        Me.grMarcas.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        Me.grMarcas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.cmbFiltro)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.btnExportar)
        Me.UiGroupBox1.Controls.Add(Me.btnGenerar)
        Me.UiGroupBox1.Controls.Add(Me.cmbAl)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cmbDel)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(20, 12)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(860, 88)
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
        Me.cmbFiltro.Location = New System.Drawing.Point(316, 56)
        Me.cmbFiltro.Name = "cmbFiltro"
        Me.cmbFiltro.SelectedIndex = 0
        Me.cmbFiltro.Size = New System.Drawing.Size(160, 23)
        Me.cmbFiltro.TabIndex = 8
        Me.cmbFiltro.Text = "Ninguno"
        Me.cmbFiltro.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(216, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Tipo de filtro:"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(724, 28)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(92, 32)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(608, 28)
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
        Me.cmbAl.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAl.Location = New System.Drawing.Point(312, 24)
        Me.cmbAl.Name = "cmbAl"
        Me.cmbAl.Size = New System.Drawing.Size(128, 23)
        Me.cmbAl.TabIndex = 3
        Me.cmbAl.Value = New Date(2009, 10, 28, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(288, 28)
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
        Me.cmbDel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDel.Location = New System.Drawing.Point(148, 24)
        Me.cmbDel.Name = "cmbDel"
        Me.cmbDel.Size = New System.Drawing.Size(128, 23)
        Me.cmbDel.TabIndex = 1
        Me.cmbDel.Value = New Date(2009, 10, 28, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Generar del:"
        '
        'frmOperacionalMarcas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 533)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOperacionalMarcas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operacional por Marcas"
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.grMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim dsMarcas As DataSet
    Dim dsMarcasFinal As DataSet
    Dim oManager As NotasCreditoManager
#Region "Metodos"



    Private Sub Reporte()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim FechaIni As New Date
            Dim FechaInicio As Date
            Dim FechaFin As Date
            Dim Year As Integer
            Dim CodAlmacen As String = ""
            Dim CodArticulo As String = ""
            Dim MesIni As Integer = 0
            Dim MesFin As Integer = 0
            Dim TIpoReporte As Integer = 2
            Dim InventarioGlobalPP As Double = 0
            Dim Filtro As Integer = 0
            Filtro = Me.cmbFiltro.SelectedIndex
            Dim IVA As Decimal = oAppContext.ApplicationConfiguration.IVA
            CodAlmacen = oAppContext.ApplicationConfiguration.Almacen

            FechaIni = Me.cmbDel.Value
            FechaFin = Me.cmbAl.Value
            MesIni = DatePart(DateInterval.Month, FechaIni)
            MesFin = DatePart(DateInterval.Month, FechaFin)
            Year = DatePart(DateInterval.Year, FechaIni)
            FechaInicio = "01/" & MesIni & "/" & Year
            Me.grMarcas.DataSource = Nothing
            Me.oManager = New NotasCreditoManager(oAppContext, oAppSAPConfig, oConfigCierreFI)
            Me.dsMarcas = oManager.ReporteOperacionalMarcas(CodAlmacen, Format(FechaIni, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"), Filtro, IVA)
            'Columna Ventas/Costo S/IVA
            'VenCoSIVA=VentasParesPiezas*CostoPromedio
            dsMarcas.Tables(0).Columns.Add("VenCoSIVA", GetType(Decimal), " VenPP * CostoProm")
            dsMarcas.Tables(0).AcceptChanges()
            'Columna Inventario Inicial Pares/Piezas
            dsMarcas.Tables(0).Columns.Add("InvIniPP", GetType(Decimal))
            dsMarcas.Tables(0).AcceptChanges()
            'Columna InventarioFinal/ParesPiezas
            dsMarcas.Tables(0).Columns.Add("IFPP", GetType(Decimal))
            dsMarcas.Tables(0).AcceptChanges()
            For Each oRow As DataRow In dsMarcas.Tables(0).Rows
                oRow("InvIniPP") = oManager.ReporteOperacionalMarcas_InventarioInicial(CodAlmacen, oRow("Material"), MesIni, Format(FechaIni, "dd/MM/yyyy"), Format(FechaInicio, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"))
                oRow("IFPP") = oManager.ReporteOperacionalMarcas_InventarioFinal(CodAlmacen, oRow("Material"), MesFin, Format(FechaIni, "dd/MM/yyyy"), Format(FechaFin, "dd/MM/yyyy"))

            Next
            'InventarioInicialImporte
            'IIImp=PrecioPublico/1.15* ParesPiezasInventarioInicial
            dsMarcas.Tables(0).Columns.Add("IIImp", GetType(Decimal), "CostoProm * InvIniPP")
            dsMarcas.Tables(0).AcceptChanges()
            dsMarcas.Tables(0).Columns.Add("IFImp", GetType(Decimal), "IFPP * CostoProm")
            dsMarcas.Tables(0).AcceptChanges()


            Me.dsMarcasFinal = dsMarcas.Clone
            'Remove
            Me.dsMarcasFinal.Tables(0).Columns.Remove("IIImp")
            Me.dsMarcasFinal.Tables(0).Columns.Remove("IFImp")
            Me.dsMarcasFinal.Tables(0).Columns.Remove("VenCoSIVA")
            'Add
            Me.dsMarcasFinal.Tables(0).Columns.Add("VenCoSIVA", GetType(Decimal))

            Me.dsMarcasFinal.Tables(0).Columns.Add("IIImp", GetType(Decimal))
            Me.dsMarcasFinal.Tables(0).Columns.Add("IFImp", GetType(Decimal))
            Me.dsMarcasFinal.Tables(0).Columns.Add("Rotacion", GetType(Decimal))
            Me.dsMarcasFinal.Tables(0).Columns.Add("Margen", GetType(Decimal))
            Me.dsMarcasFinal.Tables(0).Columns.Add("Utilidad", GetType(Decimal), " VenInvSIVA - VenCoSIVA ")
            Me.dsMarcasFinal.Tables(0).Columns("Utilidad").DefaultValue = 0


            dsMarcasFinal.Tables(0).AcceptChanges()

            For Each oRowOrigen As DataRow In dsMarcas.Tables(0).Rows
                Dim dvMarcas As New DataView(dsMarcasFinal.Tables(0), "Marca = '" & oRowOrigen("Marca") & "'", "Marca ASC", DataViewRowState.CurrentRows)
                dvMarcas.Sort = "Marca"
                If dvMarcas.Count > 0 Then

                    dvMarcas(0)("VenPP") += oRowOrigen("VenPP")
                    dvMarcas(0)("VenInvSIVA") += oRowOrigen("VenInvSIVA")
                    dvMarcas(0)("VenCoSIVA") += oRowOrigen("VenCoSIVA")
                    dvMarcas(0)("InvIniPP") += oRowOrigen("InvIniPP")
                    dvMarcas(0)("IFPP") += oRowOrigen("IFPP")
                    dvMarcas(0)("IIImp") += oRowOrigen("IIImp")
                    dvMarcas(0)("IFImp") += oRowOrigen("IFImp")

                    If dvMarcas(0)("VenPP") <> 0 Then
                        dvMarcas(0)("Rotacion") = dvMarcas(0)("InvIniPP") / dvMarcas(0)("VenPP")
                    Else
                        dvMarcas(0)("Rotacion") = 0
                    End If

                    If dvMarcas(0)("VenInvSIVA") <> 0 Then
                        dvMarcas(0)("Margen") = dvMarcas(0)("UTILIDAD") / dvMarcas(0)("VenInvSIVA")
                    Else
                        dvMarcas(0)("Margen") = 0
                    End If
                Else
                    Dim oNewRow As DataRow = Me.dsMarcasFinal.Tables(0).NewRow
                    oNewRow("Marca") = oRowOrigen("Marca")
                    oNewRow("Material") = ""
                    oNewRow("Descripcion") = oRowOrigen("Descripcion")
                    oNewRow("Codigos") = oRowOrigen("Codigos")

                    oNewRow("VenPP") = oRowOrigen("VenPP")
                    oNewRow("VenInvSIVA") = oRowOrigen("VenInvSIVA")
                    oNewRow("CostoProm") = 0
                    oNewRow("VenCoSIVA") = oRowOrigen("VenCoSIVA")

                    oNewRow("IFPP") = oRowOrigen("IFPP")
                    oNewRow("InvIniPP") = oRowOrigen("InvIniPP")
                    oNewRow("IIImp") = oRowOrigen("IIImp")
                    oNewRow("IFImp") = oRowOrigen("IFImp")
                    '
                    If oNewRow("VenPP") <> 0 Then
                        oNewRow("Rotacion") = oNewRow("InvIniPP") / oNewRow("VenPP")
                    Else
                        oNewRow("Rotacion") = 0
                    End If

                    If oNewRow("VenInvSIVA") <> 0 Then
                        oNewRow("Margen") = oNewRow("UTILIDAD") / oNewRow("VenInvSIVA")
                    Else
                        oNewRow("Margen") = 0
                    End If
                    '
                    dsMarcasFinal.Tables(0).Rows.Add(oNewRow)
                End If
                dsMarcasFinal.AcceptChanges()
            Next
            Me.dsMarcasFinal.Tables(0).Columns.Add("IFPPart", GetType(Decimal), "IFImp / Sum(IfImp)")
            Me.dsMarcasFinal.Tables(0).Columns.Add("VenPPart", GetType(Decimal), "VenInvSiva / SUM(VenInvSIVA)")
            Me.dsMarcasFinal.Tables(0).AcceptChanges()
            'Filtramos de acuerdo con la opciones que se haya seleccionado en el formulario

            If Filtro = 0 Then
                Me.grMarcas.Refresh()
                Dim dv As New DataView(dsMarcasFinal.Tables(0), "", "Marca DESC", DataViewRowState.CurrentRows)
                Me.grMarcas.DataSource = dv
                MessageBox.Show("El reporte se ha cargado de forma correcta.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Filtro = 2 Then
                Me.grMarcas.Refresh()
                Dim dv As New DataView(dsMarcasFinal.Tables(0), "", "VenInvSiva DESC", DataViewRowState.CurrentRows)
                Me.grMarcas.DataSource = dv
                MessageBox.Show("El reporte se ha cargado de forma correcta.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Filtro = 1 Then
                Me.grMarcas.Refresh()
                Dim dv As New DataView(dsMarcasFinal.Tables(0), "", "VenPP DESC", DataViewRowState.CurrentRows)
                Me.grMarcas.DataSource = dv
                MessageBox.Show("El reporte se ha cargado de forma correcta.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




        Catch ex As Exception
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
        oSheet.Cells(4, 3) = "Tipo de Filtro :" & Me.cmbFiltro.Text



        oSheet.Range("B5:D5").Merge()
        oSheet.Cells(5, 2) = "VENTAS"
        oSheet.Range("B5:D5").VerticalAlignment = 3
        oSheet.Range("B5:D5").HorizontalAlignment = 3
        oSheet.Cells(5, 2).font.bold = True


        oSheet.Range("E5:G5").Merge()
        oSheet.Cells(5, 5) = "INVENTARIO FINAL"
        oSheet.Range("E5:G5").VerticalAlignment = 3
        oSheet.Range("E5:G5").HorizontalAlignment = 3
        oSheet.Cells(5, 5).font.bold = True
        'oSheet.Columns(6).HorizontalAlignment = 3


        oSheet.Range("H5:I5").Merge()
        oSheet.Cells(5, 8) = "GENERALES"
        oSheet.Range("H5:I5").VerticalAlignment = 3
        oSheet.Range("H5:I5").HorizontalAlignment = 3
        oSheet.Cells(5, 8).font.bold = True

        'oSheet.Range("L5:M5").Merge()
        'oSheet.Cells(5, 12) = "GENERAL"
        'oSheet.Range("L5:M5").VerticalAlignment = 3
        'oSheet.Range("L5:M5").HorizontalAlignment = 3
        'oSheet.Cells(5, 12).font.bold = True

        oSheet.Cells(ROW_FIRST, 1) = "Marca"
        'oSheet.Cells(ROW_FIRST, 2) = "Codigos"
        oSheet.Cells(ROW_FIRST, 2) = "Pares / Piezas"
        oSheet.Cells(ROW_FIRST, 3) = "Importe s/iva"
        'oSheet.Cells(ROW_FIRST, 5) = "Costo s/iva"
        oSheet.Cells(ROW_FIRST, 4) = "% Part"
        'InventarioInicial
        'oSheet.Cells(ROW_FIRST, 7) = "Pares / Piezas"
        'oSheet.Cells(ROW_FIRST, 8) = "Inv. Inicial Imp."
        'InventarioFInal
        oSheet.Cells(ROW_FIRST, 5) = "Pares / Piezas"
        oSheet.Cells(ROW_FIRST, 6) = "Inv. Final Imp."
        oSheet.Cells(ROW_FIRST, 7) = "% Part"
        'Generales
        oSheet.Cells(ROW_FIRST, 8) = "Rotacion"
        oSheet.Cells(ROW_FIRST, 9) = "Mgn %"




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
            oSheet.Cells(iRow, 1) = grid.Item(ii).Item("Marca") ' "Marca"
            'oSheet.Cells(iRow, 2) = Format(grid.Item(ii).Item("Codigos"), "n") ' "Numero de codigos de esa marca"
            oSheet.Cells(iRow, 2) = Format(grid.Item(ii).Item("VenPP"), "n") ' Ventas
            oSheet.Cells(iRow, 3) = Format(grid.Item(ii).Item("VenInvSIVA"), "c") ' "Importe s/iva"
            'oSheet.Cells(iRow, 5) = Format(grid.Item(ii).Item("VenCoSIVA"), "c") ' "Costo s/iva"
            oSheet.Cells(iRow, 4) = Format(grid.Item(ii).Item("VenPPart"), "p") ' Ventas % Part
            'InventarioInicial
            'oSheet.Cells(iRow, 7) = Format(grid.Item(ii).Item("InvIniPP"), "n") ' "Pares / Piezas"
            'oSheet.Cells(iRow, 8) = Format(grid.Item(ii).Item("IIImp"), "c") ' "Inv. Inicial Imp."
            'InventarioFInal
            oSheet.Cells(iRow, 5) = Format(grid.Item(ii).Item("IFPP"), "n") ' "Pares / Piezas"
            oSheet.Cells(iRow, 6) = Format(grid.Item(ii).Item("IFImp"), "c") ' "Inv. Final Imp."
            oSheet.Cells(iRow, 7) = Format(grid.Item(ii).Item("IFPPart"), "p") ' "% Part"
            'Generales
            oSheet.Cells(iRow, 8) = Format(grid.Item(ii).Item("Rotacion"), "n") ' "Rotacion"
            oSheet.Cells(iRow, 9) = Format(grid.Item(ii).Item("Margen"), "p") ' "Mgn %"


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
        oSheet.Cells(ix + 1, 6).Value = "=SUMA(F7:F" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 6).font.bold = True
        oSheet.Cells(ix + 1, 7).Value = "=SUMA(G7:G" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 7).font.bold = True
        oSheet.Cells(ix + 1, 8).Value = "=SUMA(H7:H" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 8).font.bold = True
        oSheet.Cells(ix + 1, 9).Value = "=SUMA(I7:I" & Trim(Str(ix)) & ")"
        oSheet.Cells(ix + 1, 9).Font.Bold = True
        'oSheet.Cells(ix + 1, 10).Value = "=SUMA(J7:J" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 10).font.bold = True
        'oSheet.Cells(ix + 1, 11).Value = "=SUMA(K7:K" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 11).font.bold = True
        'oSheet.Cells(ix + 1, 12).Value = "=Suma(L7:L" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 12).Font.Bold = True
        'oSheet.Cells(ix + 1, 13).value = "=SUMA(M7:M" & Trim(Str(ix)) & ")"
        'oSheet.Cells(ix + 1, 13).Font.Bold = True
        ''__
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
#Region "Eventos Form"
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dv As New DataView
        Dim Filtro As Integer = Me.cmbFiltro.SelectedIndex
        dv = Me.dsMarcasFinal.Tables(0).DefaultView
        If Filtro = 0 Then
            dv.Sort = "Marca DESC"
            ExportaOrden(dv)
        End If
        If Filtro = 1 Then
            dv.Sort = "VenPP DESC"
            ExportaOrden(dv)
        End If
        If Filtro = 2 Then
            dv.Sort = "VenInvSiva DESC"
            ExportaOrden(dv)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub frmOperacionalMarcas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F9 Then
            Me.Cursor = Cursors.WaitCursor
            Dim dv As New DataView
            dv = Me.dsMarcasFinal.Tables(0).DefaultView
            dv.Sort = "Marca"
            ExportaOrden(dv)
            Me.Cursor = Cursors.Default
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim result As DialogResult
        Me.grMarcas.Refresh()
        result = MessageBox.Show("El reporte podria tardar varios minutos, desea continuar?", "Infomacion del reporte.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        If result = DialogResult.Yes Then
            oSubPro = New Thread(AddressOf Reporte)
            oSubPro.Start()
        Else
            Me.Close()
        End If
    End Sub
#End Region

    Private Sub frmOperacionalMarcas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
