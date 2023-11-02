Public Class InventarioReport

    Private m_oCurrentReporter As IInventarioReporter
    Private m_dsData As DataSet
    Private m_dsDataToReport As DataSet


#Region "Properties"

    Public Property CurrentReporter() As IInventarioReporter
        Get
            Return m_oCurrentReporter
        End Get
        Set(ByVal Value As IInventarioReporter)
            m_oCurrentReporter = Value
        End Set
    End Property

    Public ReadOnly Property Data() As DataSet
        Get
            Return m_dsData
        End Get
    End Property

    Public ReadOnly Property DataToReport() As DataSet
        Get
            Return m_dsDataToReport
        End Get
    End Property
#End Region


#Region "Constructors"

    Public Sub New()

        Clear()

    End Sub

    Public Sub New(ByVal Reporter As IInventarioReporter)

        m_oCurrentReporter = Reporter

    End Sub

#End Region


#Region "Methods"

    Public Function Generate() As DataSet

        m_dsData = New DataSet

        m_dsData = m_oCurrentReporter.Run()

        Return m_dsData

    End Function

    Public Function GenerateToReport() As DataSet

        m_dsDataToReport = New DataSet

        m_dsDataToReport = m_oCurrentReporter.RunTOReport
        If Not m_dsDataToReport Is Nothing Then
            dsArticulos = m_dsDataToReport.Copy
        End If
        Return m_dsDataToReport


    End Function

    Public Sub Clear()

        m_oCurrentReporter = Nothing
        m_dsData = Nothing

    End Sub

#End Region


#Region "DataSet Para Reporte"

    Public dsArticulos As DataSet
    Public dsExistencias As DataSet

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

        Dim dcCodigoAnterior As New DataColumn
        With dcCodigoAnterior
            .ColumnName = "CodigoAnterior"
            .Caption = "Codigo Anterior"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCodCategoria As New DataColumn
        With dcCodCategoria
            .ColumnName = "CodCategoria"
            .Caption = "Codigo Categoria"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcNombreCat As New DataColumn
        With dcNombreCat
            .ColumnName = "NombreCat"
            .Caption = "Nombre Categoria"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCodMarca As New DataColumn
        With dcCodMarca
            .ColumnName = "CodMarca"
            .Caption = "Marca"
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
            .Add(dcCodigoAnterior)
            .Add(dcCodCategoria)
            .Add(dcNombreCat)
            .Add(dcCodMarca)
        End With

        dsExistencias.Tables.Add(dtExistencias)
        dsExistencias.AcceptChanges()

    End Sub

    Public Function FormatToReport() As DataSet
        Try
            CreateTable()

            ' BEGIN OF INSERT SF EAHM
            Dim articuloProceso As String = ""
            Dim articuloAnterior As String = ""
            Dim id_DPPRO As String = ""
            Dim id_DPPROAnterior As String = ""
            Dim listColor As New Collection
            Dim listID_PRPRO As New Collection

            For Each row As DataRow In dsArticulos.Tables(0).Rows

                id_DPPRO = CStr(row("CodigoAnterior")).Trim
                articuloProceso = ((row("CodArticulo"))).ToString
                If articuloProceso <> articuloAnterior Then
                    listColor.Clear()
                    articuloAnterior = articuloProceso
                End If
                If id_DPPRO <> id_DPPROAnterior Then
                    listColor.Clear()
                    id_DPPROAnterior = id_DPPRO
                End If

                'If articuloProceso = "000000001000022" Then ' SF TEST
                '    articuloProceso = articuloProceso
                'End If

                Dim bandNewRow As Boolean = True

                'Dim listColor As New Collection
                Dim color As String
                Dim colorActual As String = ""

                Dim Array() As String
                Array = Split(((row("Descripcion").ToString)).Trim, ",") ' SF EAHM 13 06 2016 nuevo

                colorActual = CStr(row("Color")).Trim
                ''If Array.Length >= 3 Then
                ''    colorActual = Array(2) ' SF EAHM 13/06/2016 nuevo
                ''End If

                Dim esContRow As Boolean = False
                For Each row2 As DataRow In dsExistencias.Tables("Existencias").Rows
                    esContRow = True
                    'If CStr(row("CodArticulo")).Trim = CStr(row2("Articulo")) Then ' SF EAHM 13/06/2016 anterior
                    If (((row("CodArticulo"))).ToString).TrimStart(CChar("0")) = CStr(row2("CodigoAnterior")) Then ' SF EAHM 13/06/2016 nuevo
                        ' SF EAHM nuevo ->
                        For Each color In listColor
                            If colorActual = color Then
                                bandNewRow = False
                            Else
                                'listColor.Add(colorActual)
                            End If
                        Next
                        ' SF EAHM nuevo -<
                        'bandNewRow = False ' SF EAHM quitar
                        'Else
                        'listColor.Add(colorActual)
                    End If

                Next
                'If esContRow = False Then
                '    listColor.Add(colorActual)
                'End If

                'For Each color In listColor
                '    If colorActual = color Then

                '    End If
                'Next


                If bandNewRow Then

                    listColor.Add(colorActual)

                    'Dim Array() As String
                    'Array = Split(((row("Descripcion").ToString)).Trim, ",") ' SF EAHM 13 06 2016 nuevo

                    Dim newRow As DataRow = dsExistencias.Tables("Existencias").NewRow
                    Dim TVentas As Integer

                    'newRow("Articulo") = CStr(row("CodArticulo")).Trim ' SF EAHM 13/06/2016 - anterior
                    newRow("Articulo") = CStr(row("CodigoAnterior")).Trim ' ' SF EAHM 13/06/2016 Se cambia la posicion de la presentacion - nuevo
                    'newRow("Descripcion") = CStr(row("Descripcion")).Trim
                    If Array.Length >= 1 Then
                        newRow("Descripcion") = Array(0)
                    End If



                    'newRow("Color") = "" 'CStr(row("Color")).Trim ' SF EAHM 13/06/2016 anterior
                    newRow("Color") = CStr(row("Color")).Trim
                    ''If Array.Length >= 3 Then
                    ''    newRow("Color") = Array(2) ' SF EAHM 13/06/2016 nuevo
                    ''End If


                    'newRow("Total") = dsArticulos.Tables("Inventario").Compute("sum(TotalMes)", "CodArticulo like '" & CStr(row("CodArticulo")) & "'") ' SF EAHM quitar
                    Dim total As Integer = 0
                    For Each row2 As DataRow In dsArticulos.Tables("Inventario").Rows

                        Dim Array2() As String
                        Dim colorActual2 As String = ""
                        Array2 = Split(((row2("Descripcion").ToString)).Trim, ",") ' SF EAHM 13 06 2016 nuevo

                        colorActual2 = CStr(row2("Color")).Trim
                        'If Array2.Length >= 3 Then
                        '    colorActual2 = Array2(2) ' SF EAHM 13/06/2016 nuevo
                        'End If

                        If CStr(row2("CodArticulo")) = CStr(row("CodArticulo")) And
                            id_DPPRO = CStr(row2("CodigoAnterior")).Trim And
                            colorActual2 = colorActual Then ' SF EAHM 
                            Dim i As Integer = 0
                            Dim space As String = String.Empty
                            ' SF EAHM

                            Dim contNum As Integer = 0
                            Dim contTot As Integer = 0
                            Dim difNum As Integer = 0
                            Dim difTot As Integer = 0
                            Dim dest As Integer = 0

                            contNum = CStr(row2("Numero")).Length
                            contTot = CStr(CInt(row2("TotalMes"))).Length

                            difNum = contNum - contTot
                            difTot = contTot - contNum

                            If difNum >= difTot Then
                                dest = contNum
                            Else
                                dest = contTot
                            End If
                            'dest += 1
                            contNum = dest - contNum
                            contTot = dest - contTot
                            Dim contador As Integer = 0
                            Dim espacioNum As String = ""
                            Dim espacioTot As String = ""
                            For contador = 1 To contNum
                                espacioNum += " "
                            Next

                            For contador = 1 To contTot
                                espacioTot += " "
                            Next

                            newRow("Tallas") = CStr(newRow("Tallas")) & CStr(row2("Numero")) & espacioNum & "|"
                            'If newRow("Tallas") Is "" Then
                            '    newRow("Tallas") = CStr(row2("Numero"))
                            'Else
                            '    'newRow("Tallas") = CStr(newRow("Tallas")) & " " & CStr(row2("Numero"))
                            '    newRow("Tallas") = CStr(newRow("Tallas")) & espacioNum & CStr(row2("Numero"))
                            'End If

                            ' SF EAHM

                            ' newRow("Tallas") = CStr(newRow("Tallas")) & " " & CStr(row2("Numero")) SF EAHM quitar

                            'space = space.PadLeft(CStr(row2("Numero")).Length) ' SF EAHM 13(06/2016 quitar

                            ' SF EAHM
                            newRow("TotalNum") = CStr(newRow("TotalNum")) & CStr(CInt(row2("TotalMes"))) & espacioTot & "|"
                            'If newRow("TotalNum") Is "" Then
                            '    newRow("TotalNum") = CStr(CInt(row2("TotalMes")))
                            'Else
                            '    'newRow("TotalNum") = CStr(newRow("TotalNum")) & " " & CStr(CInt(row2("TotalMes")))
                            '    newRow("TotalNum") = CStr(newRow("TotalNum")) & espacioTot & CStr(CInt(row2("TotalMes")))
                            'End If
                            ' SF EAHM
                            'CStr(CInt(row2("TotalMes")))
                            'total = total + Integer.Parse((row2("TotalMes")).ToString) ' SF EANHM nuevo
                            total = total + CInt(row2("TotalMes"))
                            ' newRow("TotalNum") = CStr(newRow("TotalNum")) & space() & CStr(CInt(row2("TotalMes"))) ' SF EAHM quitar

                        End If
                    Next

                    newRow("Total") = total ' SF EAHM nuevo

                    newRow("Tallas") = CStr(newRow("Tallas")) '.TrimStart()
                    newRow("TotalNum") = CStr(newRow("TotalNum")) '.TrimStart
                    If CStr(row("CodCategoria")).Trim = "011" Then
                        newRow("CodCategoria") = CStr(row("CodCategoria")).Trim
                        newRow("NombreCat") = CStr(row("NombreCat")).Trim
                    Else
                        newRow("CodCategoria") = String.Empty
                        newRow("NombreCat") = String.Empty
                    End If

                    ' newRow("CodigoAnterior") = CStr(row("CodigoAnterior")).Trim ' SF EAHM 13/06/2016 - anterior
                    'Dim valtrim As String
                    'valtrim = ((row("CodArticulo"))).ToString
                    'valtrim = (((row("CodArticulo"))).ToString).TrimStart(CChar("0"))
                    'textbox1.text = tboxs(nums).TrimStart("0"c)
                    'newRow("CodigoAnterior") = valtrim.TrimStart(CChar("0")) ' SF EAHM 13/06/2016 - nuevo
                    newRow("CodigoAnterior") = (((row("CodArticulo"))).ToString).TrimStart(CChar("0"))

                    newRow("CodMarca") = CStr(row("CodMarca")).Trim

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
