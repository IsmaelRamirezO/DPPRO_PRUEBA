Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptGuiaDHL
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal Nombre As String, ByVal Direccion As String, ByVal Ciudad As String, ByVal Estado As String, ByVal CP As String, ByVal Telefono As String)

        MyBase.New()
        InitializeComponent()

        Me.txtNombre.Text = Nombre.Trim
        Me.txtDireccion.Text = Direccion.Trim
        Me.txtCP.Text = CP.Trim
        Me.txtCiudadEstado.Text = Estado.Trim & ", " & Ciudad.Trim
        Me.txtTelefono.Text = Telefono.Trim

    End Sub

#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private txtNombre As TextBox = Nothing
	Private txtDireccion As TextBox = Nothing
	Private txtCP As TextBox = Nothing
	Private txtDescripcion As TextBox = Nothing
	Private txtCiudadEstado As TextBox = Nothing
	Private txtTelefono As TextBox = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptGuiaDHL))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.txtNombre = New DataDynamics.ActiveReports.TextBox()
            Me.txtDireccion = New DataDynamics.ActiveReports.TextBox()
            Me.txtCP = New DataDynamics.ActiveReports.TextBox()
            Me.txtDescripcion = New DataDynamics.ActiveReports.TextBox()
            Me.txtCiudadEstado = New DataDynamics.ActiveReports.TextBox()
            Me.txtTelefono = New DataDynamics.ActiveReports.TextBox()
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDireccion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCP,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtCiudadEstado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.txtTelefono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNombre, Me.txtDireccion, Me.txtCP, Me.txtDescripcion, Me.txtCiudadEstado, Me.txtTelefono})
            Me.PageHeader.Height = 4.625!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0!
            Me.PageFooter.Name = "PageFooter"
            '
            'txtNombre
            '
            Me.txtNombre.Height = 0.375!
            Me.txtNombre.Left = 0.125!
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Text = "Nombre"
            Me.txtNombre.Top = 2.4375!
            Me.txtNombre.Width = 2.9375!
            '
            'txtDireccion
            '
            Me.txtDireccion.Height = 0.8125!
            Me.txtDireccion.Left = 0.125!
            Me.txtDireccion.Name = "txtDireccion"
            Me.txtDireccion.Text = "Direccion"
            Me.txtDireccion.Top = 2.9375!
            Me.txtDireccion.Width = 2.9375!
            '
            'txtCP
            '
            Me.txtCP.Height = 0.25!
            Me.txtCP.Left = 0.125!
            Me.txtCP.Name = "txtCP"
            Me.txtCP.Style = "font-size: 9.75pt; vertical-align: bottom"
            Me.txtCP.Text = "CP"
            Me.txtCP.Top = 3.9375!
            Me.txtCP.Width = 0.9375!
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Height = 0.8125!
            Me.txtDescripcion.Left = 3.3125!
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Text = "Calzado(s) / Artículos y Ropa Deportiva"
            Me.txtDescripcion.Top = 1.625!
            Me.txtDescripcion.Width = 2.5625!
            '
            'txtCiudadEstado
            '
            Me.txtCiudadEstado.Height = 0.25!
            Me.txtCiudadEstado.Left = 1.8125!
            Me.txtCiudadEstado.Name = "txtCiudadEstado"
            Me.txtCiudadEstado.Style = "vertical-align: bottom"
            Me.txtCiudadEstado.Text = "Estado, Ciudad"
            Me.txtCiudadEstado.Top = 3.9375!
            Me.txtCiudadEstado.Width = 1.5!
            '
            'txtTelefono
            '
            Me.txtTelefono.Height = 0.25!
            Me.txtTelefono.Left = 1.8125!
            Me.txtTelefono.Name = "txtTelefono"
            Me.txtTelefono.Style = "font-size: 9.75pt; vertical-align: bottom"
            Me.txtTelefono.Text = "Telefono"
            Me.txtTelefono.Top = 4.25!
            Me.txtTelefono.Width = 1.5!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Left = 0!
            Me.PageSettings.Margins.Right = 0.5!
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 5.833333!
            Me.Sections.Add(Me.PageHeader)
            Me.Sections.Add(Me.Detail)
            Me.Sections.Add(Me.PageFooter)
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei"& _ 
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"))
            Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo"& _ 
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"))
            CType(Me.txtNombre,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDireccion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCP,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtDescripcion,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtCiudadEstado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.txtTelefono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region

End Class
