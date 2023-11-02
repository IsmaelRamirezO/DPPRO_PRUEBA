Public Class Reporter

#Region "Reporte Auditoria"

    Public dtArticulos As DataTable  'Con Material
    Public dtToReport As DataTable  'Formateado
    Public dtAReport As DataTable 'Formato de salida 

    Private Sub CreateTableAuditoria()


        Dim dcCodLinea As New DataColumn
        With dcCodLinea
            .ColumnName = "CodLinea"
            .Caption = "Cod Linea"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With


        Dim dcDesLinea As New DataColumn
        With dcDesLinea
            .ColumnName = "DesLinea"
            .Caption = "Des. Linea"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCodFamilia As New DataColumn
        With dcCodFamilia
            .ColumnName = "CodFamilia"
            .Caption = "Cod Familia"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With


        Dim dcDesFamilia As New DataColumn
        With dcDesFamilia
            .ColumnName = "DesFamilia"
            .Caption = "Des. Familia"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCodMarca As New DataColumn
        With dcCodMarca
            .ColumnName = "CodMarca"
            .Caption = "Cod Marca"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With


        Dim dcDesMarca As New DataColumn
        With dcDesMarca
            .ColumnName = "DesMarca"
            .Caption = "Des. Marca"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcArticulo As New DataColumn
        With dcArticulo
            .ColumnName = "CodArticulo"
            .Caption = "Cod Articulo"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTallas As New DataColumn
        With dcTallas
            .ColumnName = "Tallas"
            .Caption = "Tallas"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcFisico As New DataColumn
        With dcFisico
            .ColumnName = "Fisico"
            .Caption = "Fisico"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcSistema As New DataColumn
        With dcSistema
            .ColumnName = "Sistema"
            .Caption = "Sistema"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTFisico As New DataColumn
        With dcTFisico
            .ColumnName = "TFisico"
            .Caption = "TFisico"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcTSistema As New DataColumn
        With dcTSistema
            .ColumnName = "TSistema"
            .Caption = "TSistema"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcDiferencia As New DataColumn
        With dcDiferencia
            .ColumnName = "Diferencia"
            .Caption = "Diferencia"
            .DataType = GetType(System.Int32)
            .Expression = "TFisico - TSistema"
        End With

        Dim dcCosto As New DataColumn
        With dcCosto
            .ColumnName = "Costo"
            .Caption = "Costo"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With


        Dim dcTCosto As New DataColumn
        With dcTCosto
            .ColumnName = "TCosto"
            .Caption = "TCosto"
            .DataType = GetType(System.Decimal)
            .Expression = "Diferencia * Costo"
        End With

        Dim dcDiferenciaTalla As New DataColumn
        With dcDiferenciaTalla
            .ColumnName = "DiferenciaTalla"
            .Caption = "DiferenciaTalla"
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

        Dim dcCodProv As New DataColumn
        With dcCodProv
            .ColumnName = "CodProv"
            .Caption = "CodProveedor"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        dtToReport = New DataTable
        With Me.dtToReport.Columns
            .Add(dcCodLinea)
            .Add(dcDesLinea)
            .Add(dcCodFamilia)
            .Add(dcDesFamilia)
            .Add(dcCodMarca)
            .Add(dcDesMarca)
            .Add(dcArticulo)
            .Add(dcDescripcion)
            .Add(dcTallas)
            .Add(dcFisico)
            .Add(dcSistema)
            .Add(dcTFisico)
            .Add(dcTSistema)
            .Add(dcDiferencia)
            .Add(dcCosto)
            .Add(dcTCosto)
            .Add(dcDiferenciaTalla)
            .Add(dcCodProv)
            .Add("CodArticuloOriginal", GetType(String))
            .Add("Talla", GetType(String))
            .Add("Color", GetType(String))
        End With
        Me.dtToReport.AcceptChanges()
    End Sub

    Public Function FormatToReportAuditoria() As DataTable
        Try

            Me.CreateTableAuditoria()
            'Dim oCatMgr As New CatalogosManager(
            Dim CodPadre As String = ""
            Dim dvTallas As New DataView(Me.dtArticulos, "", "Talla", DataViewRowState.CurrentRows)
            Dim newRow As DataRow, Descripcion() As String, strCodPadres As String = "", strColor As String = "", Talla As String = ""
            For Each oRow As DataRow In dtArticulos.Rows
                If Not oRow!CodArticulo = String.Empty Then

                    Dim dvTemp As New DataView(Me.dtToReport, "CodArticuloOriginal ='" & oRow("CodArticulo") & "'" _
                    , "CodArticulo", DataViewRowState.CurrentRows)
                    If dvTemp.Count = 0 Then
                        CodPadre = ""
                        CodPadre = CStr(oRow("CodArticulo")).Trim.Substring(0, CStr(oRow("CodArticulo")).Trim.Length - 3)
                        If IsDBNull(oRow("Color")) Then
                            strColor = ""
                        Else
                            strColor = CStr(oRow("Color")).Trim
                        End If
                        If IsDBNull(oRow("Talla")) Then
                            Talla = ""
                        Else
                            Talla = CStr(oRow("Talla")).Trim()
                        End If
                        Talla = CStr(oRow("Talla"))
                        dvTemp = New DataView(Me.dtToReport, "CodArticulo like '" & CodPadre & "%' AND Color='" & strColor & "'", "", DataViewRowState.CurrentRows)
                        If dvTemp.Count = 0 Then
                            'If InStr(strCodPadres.Trim.ToUpper, CodPadre.Trim.ToUpper & strColor.Trim.ToUpper & Talla & ",") <= 0 Then
                            strCodPadres &= CodPadre.Trim.ToUpper & strColor.Trim.ToUpper & Talla & ","

                            dvTallas.RowFilter = "CodArticulo like '" & CodPadre & "%' And Color = '" & strColor.Trim.ToUpper & "'"

                            newRow = dtToReport.NewRow

                            If IsDBNull(oRow("CodLinea")) Then
                                newRow("CodLinea") = ""
                            Else
                                newRow("CodLinea") = oRow("CodLinea")
                            End If
                            newRow("Talla") = Talla
                            newRow("Color") = strColor
                            'newRow("CodLinea") = IIf(IsDBNull(oRow("CodLinea")), "", CStr(oRow("CodLinea")))
                            If IsDBNull(oRow("DesLinea")) Then
                                newRow("DesLinea") = ""
                            Else
                                newRow("DesLinea") = oRow("DesLinea")
                            End If
                            'newRow("DesLinea") = IIf(IsDBNull(oRow("DesLinea")), "", CStr(oRow("DesLinea")))
                            If IsDBNull(oRow("CodFamilia")) Then
                                newRow("CodFamilia") = ""
                            Else
                                newRow("CodFamilia") = oRow("CodFamilia")
                            End If
                            'newRow("CodFamilia") = IIf(IsDBNull(oRow("CodFamilia")), "", CStr(oRow("CodFamilia")))
                            If IsDBNull(oRow("DesFamilia")) Then
                                newRow("DesFamilia") = ""
                            Else
                                newRow("DesFamilia") = oRow("DesFamilia")
                            End If
                            'newRow("DesFamilia") = IIf(IsDBNull(oRow("DesFamilia")), "", CStr(oRow("DesFamilia")))
                            If IsDBNull(oRow("CodMarca")) Then
                                newRow("CodMarca") = ""
                            Else
                                newRow("CodMarca") = oRow("CodMarca")
                            End If
                            'newRow("CodMarca") = IIf(IsDBNull(oRow("CodMarca")), "", CStr(oRow("CodMarca")))
                            If IsDBNull(oRow("DesMarca")) Then
                                newRow("DesMarca") = ""
                            Else
                                newRow("DesMarca") = CStr(oRow("DesMarca")).Trim
                            End If
                            'newRow("DesMarca") = IIf(IsDBNull(oRow("DesMarca")), "", CStr(oRow("DesMarca")))
                            If IsDBNull(oRow("Descripcion")) Then
                                newRow("Descripcion") = ""
                            Else
                                Descripcion = CStr(oRow("Descripcion")).Trim.Split(",")
                                If Descripcion.Length > 0 Then
                                    newRow("Descripcion") = Descripcion(0) & " " & strColor.Trim.ToUpper
                                Else
                                    newRow("Descripcion") = CStr(oRow("Descripcion")).Trim
                                End If
                            End If
                            If IsDBNull(oRow("CodProv")) Then
                                newRow("CodProv") = ""
                            Else
                                newRow("CodProv") = CStr(oRow("CodProv")).Trim
                            End If
                            'newRow("CodProv") = IIf(IsDBNull(oRow("CodProv")), "", CStr(oRow("CodProv")))
                            'If IsDBNull(oRow("DesMarca")) Then
                            '        newRow("DesMarca") = String.Empty
                            '    Else
                            '        newRow("DesMarca") = CStr(oRow("DesMarca"))
                            'End If
                            'newRow("CodArticulo") = CStr(oRow("CodArticulo"))
                            newRow("CodArticulo") = CodPadre.Trim
                            newRow("CodArticuloOriginal") = CStr(oRow("CodArticulo"))
                            'newRow("Descripcion") = IIf(CStr(oRow("Descripcion")).Length > 18, Mid(CStr(oRow("Descripcion")), 1, 18), CStr(oRow("Descripcion")))
                            If IsDBNull(oRow("Costo")) Then
                                newRow("Costo") = ""
                            Else
                                newRow("Costo") = CStr(oRow("Costo")).Trim
                            End If
                            'newRow("Costo") = IIf(IsDBNull(oRow("Costo")), "", CStr(oRow("Costo")))

                            Dim TFisico As Integer = 0
                            Dim TSistema As Integer = 0
                            Dim space As String = ""

                            For Each oRowView As DataRowView In dvTallas
                                Dim spaceTemp As String = ""


                                TFisico += CInt(oRowView("Cantidad")) 'Recolectora
                                TSistema += CInt(oRowView("Libre")) 'Libre

                                If TFisico <> TSistema Then
                                    newRow("DiferenciaTalla") = "X"
                                End If
                                'If CStr(newRow("Tallas")).Length = 0 Then
                                '    newRow("Tallas") = CStr(oRowView("Talla"))
                                'Else
                                '    newRow("Tallas") = CStr(newRow("Tallas")) & space & CStr(oRowView("Talla"))
                                'End If



                                'If (CStr(oRowView("Talla")).Trim.Length >= CStr(oRowView("Libre")).Length) AndAlso (CStr(oRowView("Libre")).Length >= CStr(oRowView("Cantidad")).Length) Then
                                '    space = " "
                                'Else
                                '    If (CStr(oRowView("Libre")).Length > CStr(oRowView("Cantidad")).Length) Then
                                '        space = String.Empty
                                '        space = space.PadLeft(CStr(oRowView("Libre")).Length, " ")
                                '    Else
                                '        space = String.Empty
                                '        space = space.PadLeft(CStr(oRowView("Cantidad")).Length - 1, " ")
                                '    End If
                                'End If

                                'If CStr(newRow("Sistema")).Length = 0 Then
                                '    newRow("Sistema") = Format(oRowView("Libre"), "#####0")
                                '    newRow("Fisico") = Format(oRowView("Cantidad"), "#####0")
                                'Else
                                Dim lTalla As Integer = CStr(oRowView("Talla")).Trim.Length
                                Dim lSistema As Integer = CStr(oRowView("Libre")).Trim.Length
                                Dim lFisico As Integer = CStr(oRowView("Cantidad")).Trim.Length
                                'Dim Diferencia As Integer = 0

                                '----------------------------------------------------------------------------------------------
                                ' JNAVA (25.10.2016): Determinamos cual de los tres es mayor para poner los digitos correctos.
                                '----------------------------------------------------------------------------------------------
                                Dim lMayor As Integer = NumeroMayor(lTalla, lSistema, lFisico)
                                newRow("Tallas") &= CStr(oRowView("Talla")).PadLeft(lMayor, " ") & "|"
                                newRow("Sistema") &= Format(oRowView("Libre"), "#####0").PadLeft(lMayor, " ") & "|"
                                newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0").PadLeft(lMayor, " ") & "|"

                                '----------------------------------------------------------------------------------------------
                                ' JNAVA (25.10.2016): comentado por lo anterior
                                '----------------------------------------------------------------------------------------------
                                'Try
                                '    If lTalla > lSistema AndAlso lTalla > lFisico Then
                                '        newRow("Tallas") &= CStr(oRowView("Talla")) & "|"
                                '        newRow("Sistema") &= Format(oRowView("Libre"), "#####0").PadLeft(lTalla, " ") & "|"
                                '        newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0").PadLeft(lTalla, " ") & "|"
                                '    ElseIf lSistema > lTalla AndAlso lSistema > lFisico Then
                                '        newRow("Tallas") &= CStr(oRowView("Talla")).PadLeft(lSistema, " ") & "|"
                                '        newRow("Sistema") &= Format(oRowView("Libre"), "#####0") & "|"
                                '        newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0").PadLeft(lSistema, " ") & "|"
                                '    ElseIf lFisico > lTalla AndAlso lFisico > lSistema Then
                                '        newRow("Tallas") &= CStr(oRowView("Talla")).PadLeft(lFisico, " ") & "|"
                                '        newRow("Sistema") &= Format(oRowView("Libre"), "#####0").PadLeft(lFisico, " ") & "|"
                                '        newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0") & "|"
                                '    Else
                                '        newRow("Tallas") &= CStr(oRowView("Talla")) & "|"
                                '        newRow("Sistema") &= Format(oRowView("Libre"), "#####0").PadLeft(lTalla, " ") & "|"
                                '        newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0").PadLeft(lTalla, " ") & "|"
                                '    End If
                                '    'If lSistema > lFisico Then
                                '    '    'spaceTemp = spaceTemp.PadLeft(((CStr(newRow("Tallas")).Length - CStr(newRow("Sistema")).Length) - CStr(oRowView("Talla")).Length), " ")
                                '    '    spaceTemp = "".PadLeft(lSistema - lFisico, " ")
                                '    '    newRow("Sistema") &= Format(oRowView("Libre"), "#####0") & "|"
                                '    '    newRow("Fisico") &= spaceTemp & Format(oRowView("Cantidad"), "#####0") & "|"
                                '    'ElseIf lFisico > lSistema Then
                                '    '    'spaceTemp = spaceTemp.PadLeft(((CStr(newRow("Tallas")).Length - CStr(newRow("Fisico")).Length) - CStr(oRowView("Talla")).Length), " ")
                                '    '    'Diferencia = lFisico - lSistema
                                '    '    spaceTemp = "".PadLeft(lFisico - lSistema, " ")
                                '    '    newRow("Sistema") &= spaceTemp & Format(oRowView("Libre"), "#####0") & "|"
                                '    '    newRow("Fisico") &= Format(oRowView("Cantidad"), "#####0") & "|"
                                '    'Else
                                '    '    newRow("Sistema") &= Format(oRowView("Libre"), "#####0") & "|"
                                '    '    newRow("Fisico") &= Format(oRowView("Cantidad"), "#####0") & "|"
                                '    'End If
                                'Catch ex As Exception
                                'End Try
                                '----------------------------------------------------------------------------------------------

                                'newRow("Sistema") = CStr(newRow("Sistema")) & spaceTemp.PadLeft(spaceTemp.Length + Diferencia, " ") & Format(oRowView("Libre"), "#####0")
                                'newRow("Fisico") = CStr(newRow("Fisico")) & spaceTemp & Format(oRowView("Cantidad"), "#####0")
                                'newRow("Sistema") &= Format(oRowView("Libre"), "#####0") & "|"
                                'newRow("Fisico") &= Format(oRowView("Cantidad"), "#####0") & "|"
                                'End If

                            Next
                            newRow("TSistema") = TSistema
                            newRow("TFisico") = TFisico

                            newRow("Tallas") = CStr(newRow("Tallas"))
                            newRow("Sistema") = CStr(newRow("Sistema"))
                            newRow("Fisico") = CStr(newRow("Fisico"))

                            'newRow("CodProv") &= vbCrLf & newRow("CodArticulo") & vbCrLf & "Sistema" & vbCrLf & "Fisico"

                            'newRow("CodArticulo") = ""

                            dtToReport.Rows.Add(newRow)
                            dtToReport.AcceptChanges()
                        End If
                    End If
                Else

                    'Dim newRow As DataRow = dsToReport.Tables("Materiales").NewRow
                    'newRow("CodArticulo") = "zNo encontrado"
                    'newRow("Descripcion") = "zNo encontrado"
                    'newRow("CodUPC") = CStr(oRow("CodUPC"))
                    'newRow("TCantidades") = CStr(oRow("Cantidad"))

                    'dsToReport.Tables("Materiales").Rows.Add(newRow)
                    'dsToReport.AcceptChanges()

                End If
            Next

        Catch ex As Exception
            Throw New ApplicationException(ex.ToString, ex)
        End Try


        Return Me.dtToReport

    End Function

    '----------------------------------------------------------------------------------
    ' JNAVA (25.10.2016): Determina el mayor de 3 numeros
    '----------------------------------------------------------------------------------
    Private Function NumeroMayor(ByVal N1 As Integer, ByVal N2 As Integer, ByVal N3 As Integer) As Integer
        Dim Mayor As Integer = 0
        If N1 > N2 AndAlso N1 > N3 Then
            Mayor = N1
        Else
            If N2 > N1 AndAlso N2 > N3 Then
                Mayor = N2
            Else
                Mayor = N3
            End If
        End If
        Return Mayor
    End Function



    Private Sub CreateTableDiferenciasInventario()
        Dim dcArticulo1 As New DataColumn
        With dcArticulo1
            .ColumnName = "CodArticulo1"
            .Caption = "Cod Articulo"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcPiezas1 As New DataColumn
        With dcPiezas1
            .ColumnName = "Piezas1"
            .Caption = "No. Piezas"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcEntrada As New DataColumn
        With dcEntrada
            .ColumnName = "Entrada"
            .Caption = "Entrada Talla"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcArticulo2 As New DataColumn
        With dcArticulo2
            .ColumnName = "CodArticulo2"
            .Caption = "Cod Articulo"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcPiezas2 As New DataColumn
        With dcPiezas2
            .ColumnName = "Piezas2"
            .Caption = "No. Piezas"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With


        Dim dcSalida As New DataColumn
        With dcSalida
            .ColumnName = "Salida"
            .Caption = "Salida Talla"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcFisico As New DataColumn
        With dcFisico
            .ColumnName = "Fisico"
            .Caption = "Fisico"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcSistema As New DataColumn
        With dcSistema
            .ColumnName = "Sistema"
            .Caption = "Sistema"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcTFisico As New DataColumn
        With dcTFisico
            .ColumnName = "TFisico"
            .Caption = "TFisico"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcTSistema As New DataColumn
        With dcTSistema
            .ColumnName = "TSistema"
            .Caption = "TSistema"
            .DataType = GetType(System.Int32)
            .DefaultValue = 0
        End With

        Dim dcDiferencia As New DataColumn
        With dcDiferencia
            .ColumnName = "Diferencia"
            .Caption = "Diferencia"
            .DataType = GetType(System.Int32)
            .Expression = "TFisico - TSistema"
        End With

        Dim dcCosto As New DataColumn
        With dcCosto
            .ColumnName = "Costo"
            .Caption = "Costo Unitario"
            .DataType = GetType(System.Decimal)
            .DefaultValue = 0
        End With

        Dim dcDescripcion As New DataColumn
        With dcDescripcion
            .ColumnName = "Descripcion"
            .Caption = "Descripcion"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        Dim dcCodProv As New DataColumn
        With dcCodProv
            .ColumnName = "CodProv"
            .Caption = "CodProveedor"
            .DataType = GetType(System.String)
            .DefaultValue = String.Empty
        End With

        dtAReport = New DataTable
        With Me.dtAReport.Columns
            .Add(dcArticulo1)
            .Add(dcPiezas1)
            .Add(dcEntrada)
            .Add(dcArticulo2)
            .Add(dcPiezas2)
            .Add(dcSalida)
            .Add(dcFisico)
            .Add(dcSistema)
            .Add(dcTFisico)
            .Add(dcTSistema)
            .Add(dcDiferencia)
            .Add(dcCosto)
            .Add(dcDescripcion)
            .Add(dcCodProv)
        End With
        Me.dtAReport.AcceptChanges()
    End Sub

    Public Function FormatAReportDiferenciasInventario() As DataTable
        Try

            Me.CreateTableDiferenciasInventario()

            For Each oRow As DataRow In dtArticulos.Rows
                If Not oRow!CodArticulo = String.Empty Then

                    Dim dvTemp As New DataView(Me.dtAReport, "CodArticulo1 ='" & oRow("CodArticulo") & "' or CodArticulo2 ='" & oRow("CodArticulo") & "'" _
                                        , "CodArticulo1", DataViewRowState.CurrentRows)

                    If dvTemp.Count = 0 Then

                        Dim dvTallas As New DataView(Me.dtArticulos, "CodArticulo ='" & oRow("CodArticulo") & "' and Cantidad <> Libre " _
                        , "Talla", DataViewRowState.CurrentRows)

                        Dim strCadena As String, intTipo As Integer, strOrden As String, _
                        TFisico As Integer, _
                        TSistema As Integer

                        For Each oRowView As DataRowView In dvTallas
                            TFisico = 0
                            TSistema = 0
                            TFisico = CInt(oRowView("Cantidad")) 'Recolectora
                            TSistema = CInt(oRowView("Libre")) 'Libre
                            'validar que tipo de movimiento va a ser : salida o entrada
                            If oRowView("cantidad") > oRowView("libre") Then
                                strCadena = "CodArticulo2 ='" & oRowView("CodArticulo") & "' and CodArticulo1=''"
                                intTipo = 1
                                strOrden = "CodArticulo1"
                            Else
                                strCadena = "CodArticulo1 ='" & oRowView("CodArticulo") & "' and CodArticulo2=''"
                                intTipo = 2
                                strOrden = "CodArticulo2"
                            End If

                            Dim dvValida As New DataView(Me.dtAReport, strCadena, strOrden, DataViewRowState.CurrentRows)

                            If dvValida.Count > 0 Then
                                If intTipo = 1 Then
                                    dvValida.Item(0)("piezas1") = CStr(oRowView("cantidad") - oRowView("libre"))
                                    dvValida.Item(0)("entrada") = oRowView("talla")
                                    dvValida.Item(0)("TFisico") = dvValida.Item(0)("TFisico") + oRowView("Cantidad")
                                    dvValida.Item(0)("TSistema") = dvValida.Item(0)("TSistema") + oRowView("Libre")
                                    dvValida.Item(0)("CodArticulo1") = oRowView("CodArticulo")
                                Else
                                    dvValida.Item(0)("piezas2") = CStr(oRowView("libre") - oRowView("cantidad"))
                                    dvValida.Item(0)("salida") = oRowView("talla")
                                    dvValida.Item(0)("TFisico") = dvValida.Item(0)("TFisico") + oRowView("Cantidad")
                                    dvValida.Item(0)("TSistema") = dvValida.Item(0)("TSistema") + oRowView("Libre")
                                    dvValida.Item(0)("CodArticulo2") = oRowView("CodArticulo")
                                End If
                                dtAReport.AcceptChanges()
                            Else
                                Dim newRow As DataRow = dtAReport.NewRow
                                If oRowView("cantidad") > oRowView("libre") Then

                                    newRow("CodArticulo1") = CStr(oRowView("CodArticulo"))
                                    newRow("Piezas1") = CStr(oRowView("cantidad") - oRowView("libre"))
                                    newRow("Entrada") = CStr(oRowView("Talla"))
                                    newRow("Descripcion") = CStr(oRowView("Descripcion"))
                                    newRow("TSistema") = TSistema
                                    newRow("TFisico") = TFisico
                                    newRow("Costo") = oRowView("Costo")
                                    dtAReport.Rows.Add(newRow)
                                    dtAReport.AcceptChanges()
                                Else
                                    newRow("CodArticulo2") = CStr(oRowView("CodArticulo"))
                                    newRow("Piezas2") = CStr(oRowView("libre") - oRowView("cantidad"))
                                    newRow("Salida") = CStr(oRowView("Talla"))
                                    newRow("Descripcion") = CStr(oRowView("Descripcion"))
                                    newRow("TSistema") = TSistema
                                    newRow("TFisico") = TFisico
                                    newRow("Costo") = oRowView("Costo")
                                    dtAReport.Rows.Add(newRow)
                                    dtAReport.AcceptChanges()
                                End If
                            End If


                        Next
                    End If  'fin del If dvTemp.Count = 0 Then
                End If 'fin de la comparacion del If Not oRow!CodArticulo = String.Empty Then
            Next

        Catch ex As Exception
            Throw New ApplicationException(ex.ToString, ex)
        End Try
        Return Me.dtAReport

    End Function

#End Region

End Class
