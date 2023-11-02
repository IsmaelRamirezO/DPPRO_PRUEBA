Public Class ArticulosSinMovimientos
    Implements IInventarioReporter


#Region "Variables Parametros Reporte"

    Private m_strCodLinea As String
    Private m_strCodFamilia As String
    Private m_strCodMarca As String
    Private m_intDias As Integer
    Private m_strCodAlmacen As String
    Private m_datdsExistencias As DataSet
    Private m_datdsArticulos As DataSet

#End Region

#Region "Implementación.: Implements IInventarioReporter"

    Private m_strConnectionString As String

    Public Property ConnectionString() As String Implements IInventarioReporter.ConnectionString
        Get

        End Get
        Set(ByVal Value As String)
            m_strConnectionString = Value
        End Set
    End Property

    Public Function Run() As System.Data.DataSet Implements IInventarioReporter.Run

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Me.dsArticulos = oDataGateway.GetArticulosSinMovimientos(Me.CodMarca, Me.CodLinea, Me.CodFamilia, Me.Dias, Me.CodAlmacen)

        Return dsArticulos

    End Function

    Private Function RunToReport() As System.Data.DataSet Implements IInventarioReporter.RunTOReport

    End Function

#End Region
   
#Region "Parametros Reporte"
    Public Property Dias() As Integer
        Get
            Return m_intDias
        End Get
        Set(ByVal Value As Integer)
            m_intDias = Value
        End Set
    End Property

    Public Property CodMarca() As String
        Get
            Return m_strCodMarca
        End Get
        Set(ByVal Value As String)
            m_strCodMarca = Value
        End Set
    End Property

    Public Property CodFamilia() As String
        Get
            Return m_strCodFamilia
        End Get
        Set(ByVal Value As String)
            m_strCodFamilia = Value
        End Set
    End Property

    Public Property CodLinea() As String
        Get
            Return m_strCodLinea
        End Get
        Set(ByVal Value As String)
            m_strCodLinea = Value
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set
    End Property

    Public Property dsExistencias() As DataSet
        Get
            Return m_datdsExistencias
        End Get
        Set(ByVal Value As DataSet)
            m_datdsExistencias = Value
        End Set
    End Property

#End Region

#Region "DataSet Original"

    Public Property dsArticulos() As DataSet
        Get
            Return m_datdsArticulos
        End Get
        Set(ByVal Value As DataSet)
            m_datdsArticulos = Value
        End Set
    End Property
#End Region

#Region "DataSet Para Grid"
    Public Function FormatToGrid() As DataSet

        Dim oDataGateway As New ReporteInventarioDataGateway(m_strConnectionString)

        Return oDataGateway.FormatDataSet(Me.dsArticulos)

    End Function
#End Region

#Region "DataSet Para Reporte"

    Private Sub CreateTable()

        dsExistencias = New DataSet("Existencias")
        Dim dtExistencias As New DataTable("Existencias")

        Dim dcArticulo As New DataColumn
        With dcArticulo
            .ColumnName = "Articulo"
            .Caption = "Articulos"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .Caption = "Descripcion"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTotal As New DataColumn
        With dcTotal
            .ColumnName = "Total"
            .Caption = "Total"
            .DataType = GetType(System.Int32)
        End With


        Dim dcTallas As New DataColumn
        With dcTallas
            .ColumnName = "Tallas"
            .Caption = "Tallas"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTotalNumero As New DataColumn
        With dcTotalNumero
            .ColumnName = "TotalNum"
            .Caption = "T. Numero"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcColor As New DataColumn
        With dcColor
            .ColumnName = "Color"
            .Caption = "Color"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        With dtExistencias.Columns
            .Add(dcArticulo)
            .Add(dcDescripcion)
            .Add(dcTotal)
            .Add(dcTallas)
            .Add(dcTotalNumero)
            .Add(dcColor)
        End With

        dsExistencias.Tables.Add(dtExistencias)
        dsExistencias.AcceptChanges()

    End Sub

    Public Function FormatToReport() As DataSet
        Try

            CreateTable()

            For Each row As DataRow In dsArticulos.Tables(0).Rows
                Dim bandNewRow As Boolean = True

                For Each row2 As DataRow In dsExistencias.Tables("Existencias").Rows

                    If CStr(row("CodArticulo")).Trim = CStr(row2("Articulo")) Then

                        bandNewRow = False

                    End If

                Next

                If bandNewRow Then

                    Dim newRow As DataRow = dsExistencias.Tables("Existencias").NewRow
                    Dim TVentas As Integer

                    newRow("Articulo") = CStr(row("CodArticulo")).Trim
                    newRow("Descripcion") = CStr(row("Descripcion")).Trim
                    newRow("Color") = CStr(row("Color")).Trim
                    newRow("Total") = dsArticulos.Tables("Inventario").Compute("sum(TotalMes)", "CodArticulo like '" & CStr(row("CodArticulo")) & "'")

                    For Each row2 As DataRow In dsArticulos.Tables("Inventario").Rows
                        If CStr(row2("CodArticulo")) = CStr(row("CodArticulo")) Then
                            Dim i As Integer = 0
                            Dim space As String = String.Empty
                            newRow("Tallas") = CStr(newRow("Tallas")) & " " & CStr(row2("Numero"))
                            For i = 1 To CStr(row2("Numero")).Length
                                space &= " "
                            Next
                            newRow("TotalNum") = CStr(newRow("TotalNum")) & space & Format(row2("TotalMes"), "#####")
                        End If
                    Next
                    newRow("Tallas") = CStr(newRow("Tallas")).TrimStart()
                    newRow("TotalNum") = CStr(newRow("TotalNum")).TrimStart

                    dsExistencias.Tables("Existencias").Rows.Add(newRow)
                    dsExistencias.AcceptChanges()

                End If

            Next

        Catch ex As Exception

            Throw ex

        End Try


        Return Me.dsExistencias

    End Function

#End Region


End Class
