Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptAbonoApartado
Inherits DataDynamics.ActiveReports.ActiveReport
    Public Sub New(ByVal oForm As frmAbonosContratos)
        MyBase.New()
        InitializeComponent()

        Try
            With oForm



                Me.tbFolioAbono.Text = .oContratos.Referencia
                Me.tbDesCliente.Text = .ebDesCliente.Text
                Me.tbNumApartado.Text = .ebNumApartado.Text.PadLeft(10, "0")
                Me.tbFecha.Text = Now
                Me.tbSaldoActual.Text = .ebSaldoActual.Text.Replace("$", "")
                Me.tbAbono.Text = .ebAbono.Text.Replace("$", "")
                Me.tbSaldoNuevo.Text = .ebSaldoNuevo.Text.Replace("$", "")

                Dim Ob As New DportenisPro.DPTienda.ApplicationUnits.NumeroaLetras.Letras

                Dim parametros() As String = .ebAbono.Text.Split(".")
                parametros(0) = parametros(0).Replace("$", "")

                If parametros.Length > 1 Then
                    Me.tbImporteCLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & parametros(1) & "/100 M.N.)"
                Else
                    Me.tbImporteCLetra.Text = "(" & Ob.Letras(parametros(0)) & "Pesos " & "00/100 M.N.)"
                End If


            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#Region "ActiveReports Designer generated code"
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
	Private tbNumApartado As Label = Nothing
	Private tbDesCliente As Label = Nothing
	Private tbSaldoActual As Label = Nothing
	Private tbSaldoNuevo As Label = Nothing
	Private tbFecha As Label = Nothing
	Private tbImporteCLetra As Label = Nothing
	Private tbFolioAbono As Label = Nothing
	Private tbAbono As Label = Nothing
	Private Label1 As Label = Nothing
	Private Label2 As Label = Nothing
	Private Label3 As Label = Nothing
	Private Label4 As Label = Nothing
	Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptAbonoApartado))
            Me.Detail = New DataDynamics.ActiveReports.Detail()
            Me.PageHeader = New DataDynamics.ActiveReports.PageHeader()
            Me.PageFooter = New DataDynamics.ActiveReports.PageFooter()
            Me.tbNumApartado = New DataDynamics.ActiveReports.Label()
            Me.tbDesCliente = New DataDynamics.ActiveReports.Label()
            Me.tbSaldoActual = New DataDynamics.ActiveReports.Label()
            Me.tbSaldoNuevo = New DataDynamics.ActiveReports.Label()
            Me.tbFecha = New DataDynamics.ActiveReports.Label()
            Me.tbImporteCLetra = New DataDynamics.ActiveReports.Label()
            Me.tbFolioAbono = New DataDynamics.ActiveReports.Label()
            Me.tbAbono = New DataDynamics.ActiveReports.Label()
            Me.Label1 = New DataDynamics.ActiveReports.Label()
            Me.Label2 = New DataDynamics.ActiveReports.Label()
            Me.Label3 = New DataDynamics.ActiveReports.Label()
            Me.Label4 = New DataDynamics.ActiveReports.Label()
            CType(Me.tbNumApartado,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbDesCliente,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoActual,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbSaldoNuevo,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbImporteCLetra,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbFolioAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.tbAbono,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
            '
            'Detail
            '
            Me.Detail.ColumnSpacing = 0!
            Me.Detail.Height = 0.15625!
            Me.Detail.Name = "Detail"
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.tbNumApartado, Me.tbDesCliente, Me.tbSaldoActual, Me.tbSaldoNuevo, Me.tbFecha, Me.tbImporteCLetra, Me.tbFolioAbono, Me.tbAbono, Me.Label1, Me.Label2, Me.Label3, Me.Label4})
            Me.PageHeader.Height = 5.447222!
            Me.PageHeader.Name = "PageHeader"
            '
            'PageFooter
            '
            Me.PageFooter.Height = 0.1979167!
            Me.PageFooter.Name = "PageFooter"
            '
            'tbNumApartado
            '
            Me.tbNumApartado.Height = 0.2!
            Me.tbNumApartado.HyperLink = Nothing
            Me.tbNumApartado.Left = 1.4375!
            Me.tbNumApartado.Name = "tbNumApartado"
            Me.tbNumApartado.Style = ""
            Me.tbNumApartado.Text = ""
            Me.tbNumApartado.Top = 2.4375!
            Me.tbNumApartado.Width = 1!
            '
            'tbDesCliente
            '
            Me.tbDesCliente.Height = 0.2!
            Me.tbDesCliente.HyperLink = Nothing
            Me.tbDesCliente.Left = 0.5!
            Me.tbDesCliente.Name = "tbDesCliente"
            Me.tbDesCliente.Style = ""
            Me.tbDesCliente.Text = ""
            Me.tbDesCliente.Top = 1.75!
            Me.tbDesCliente.Width = 3.125!
            '
            'tbSaldoActual
            '
            Me.tbSaldoActual.Height = 0.2!
            Me.tbSaldoActual.HyperLink = Nothing
            Me.tbSaldoActual.Left = 1.75!
            Me.tbSaldoActual.Name = "tbSaldoActual"
            Me.tbSaldoActual.Style = "text-align: right"
            Me.tbSaldoActual.Text = ""
            Me.tbSaldoActual.Top = 3.25!
            Me.tbSaldoActual.Width = 1.125!
            '
            'tbSaldoNuevo
            '
            Me.tbSaldoNuevo.Height = 0.2!
            Me.tbSaldoNuevo.HyperLink = Nothing
            Me.tbSaldoNuevo.Left = 1.75!
            Me.tbSaldoNuevo.Name = "tbSaldoNuevo"
            Me.tbSaldoNuevo.Style = "text-align: right"
            Me.tbSaldoNuevo.Text = ""
            Me.tbSaldoNuevo.Top = 4!
            Me.tbSaldoNuevo.Width = 1.125!
            '
            'tbFecha
            '
            Me.tbFecha.Height = 0.2!
            Me.tbFecha.HyperLink = Nothing
            Me.tbFecha.Left = 0.5!
            Me.tbFecha.Name = "tbFecha"
            Me.tbFecha.Style = ""
            Me.tbFecha.Text = ""
            Me.tbFecha.Top = 2.8125!
            Me.tbFecha.Width = 2.25!
            '
            'tbImporteCLetra
            '
            Me.tbImporteCLetra.Height = 0.2!
            Me.tbImporteCLetra.HyperLink = Nothing
            Me.tbImporteCLetra.Left = 0.0625!
            Me.tbImporteCLetra.Name = "tbImporteCLetra"
            Me.tbImporteCLetra.Style = ""
            Me.tbImporteCLetra.Text = ""
            Me.tbImporteCLetra.Top = 4.5625!
            Me.tbImporteCLetra.Width = 5.625!
            '
            'tbFolioAbono
            '
            Me.tbFolioAbono.Height = 0.2!
            Me.tbFolioAbono.HyperLink = Nothing
            Me.tbFolioAbono.Left = 2.5625!
            Me.tbFolioAbono.Name = "tbFolioAbono"
            Me.tbFolioAbono.Style = ""
            Me.tbFolioAbono.Text = ""
            Me.tbFolioAbono.Top = 0.3125!
            Me.tbFolioAbono.Width = 1!
            '
            'tbAbono
            '
            Me.tbAbono.Height = 0.2!
            Me.tbAbono.HyperLink = Nothing
            Me.tbAbono.Left = 1.75!
            Me.tbAbono.Name = "tbAbono"
            Me.tbAbono.Style = "text-align: right"
            Me.tbAbono.Text = ""
            Me.tbAbono.Top = 3.625!
            Me.tbAbono.Width = 1.125!
            '
            'Label1
            '
            Me.Label1.Height = 0.2!
            Me.Label1.HyperLink = Nothing
            Me.Label1.Left = 0.6875!
            Me.Label1.Name = "Label1"
            Me.Label1.Style = "text-align: right"
            Me.Label1.Text = "Saldo $"
            Me.Label1.Top = 3.25!
            Me.Label1.Width = 1!
            '
            'Label2
            '
            Me.Label2.Height = 0.2!
            Me.Label2.HyperLink = Nothing
            Me.Label2.Left = 0.6875!
            Me.Label2.Name = "Label2"
            Me.Label2.Style = "text-align: right"
            Me.Label2.Text = "Abono $"
            Me.Label2.Top = 3.625!
            Me.Label2.Width = 1!
            '
            'Label3
            '
            Me.Label3.Height = 0.2!
            Me.Label3.HyperLink = Nothing
            Me.Label3.Left = 0.6875!
            Me.Label3.Name = "Label3"
            Me.Label3.Style = "text-align: right"
            Me.Label3.Text = "Saldo Nuevo $"
            Me.Label3.Top = 4!
            Me.Label3.Width = 1!
            '
            'Label4
            '
            Me.Label4.Height = 0.1875!
            Me.Label4.HyperLink = Nothing
            Me.Label4.Left = 0.1875!
            Me.Label4.Name = "Label4"
            Me.Label4.Style = ""
            Me.Label4.Text = "ABONO A APARTADO"
            Me.Label4.Top = 0.3125!
            Me.Label4.Width = 2.0625!
            '
            'ActiveReport1
            '
            Me.MasterReport = false
            Me.PageSettings.Margins.Top = 0.5!
            Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
            Me.PageSettings.PaperHeight = 11!
            Me.PageSettings.PaperWidth = 8.5!
            Me.PrintWidth = 6.208333!
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
            CType(Me.tbNumApartado,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbDesCliente,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoActual,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbSaldoNuevo,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFecha,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbImporteCLetra,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbFolioAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.tbAbono,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label1,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label2,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label3,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.Label4,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me,System.ComponentModel.ISupportInitialize).EndInit
        
	End Sub

#End Region


End Class
