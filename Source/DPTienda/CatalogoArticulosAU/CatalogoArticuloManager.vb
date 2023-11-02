Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoArticuloManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoArticuloDG As CatalogoArticuloDataGateWay

#Region "Properties"

    Public ReadOnly Property ApplicationContext() As DportenisPro.DPTienda.Core.ApplicationContext
        Get
            Return oAppContext
        End Get
    End Property

#End Region

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oAppContext = ApplicationContext

        oCatalogoArticuloDG = New CatalogoArticuloDataGateWay(Me)

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oCatalogoArticuloDG = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Function Create() As Articulo

        Dim oNewArticulo As Articulo
        oNewArticulo = New Articulo(Me)

        Return oNewArticulo

    End Function

    Public Function Load(ByVal ID As String) As Articulo

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Articulo")
        End If

        Dim oReadedArticulo As Articulo

        oReadedArticulo = oCatalogoArticuloDG.SelectByID(ID)


        Return oReadedArticulo

    End Function

    Public Function LoadNew(ByVal ID As String, Optional ByVal BuscaCodProv As Boolean = False) As Articulo

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Articulo")
        End If

        Dim oReadedArticulo As Articulo

        oReadedArticulo = oCatalogoArticuloDG.SelectByIDDes(ID, BuscaCodProv)

        Return oReadedArticulo

    End Function


    Public Function SelectCondicionVenta(ByVal ID As String) As Double()

        Return oCatalogoArticuloDG.SelectCondicionVenta(ID)

    End Function


    Public Sub LoadInto(ByVal ID As String, ByVal oArticulo As Articulo, Optional ByVal Last As Boolean = False)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Articulo")
        End If

        oCatalogoArticuloDG.SelectInto(ID, oArticulo, Last)

    End Sub


    Public Sub GetImage(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Articulo")
        End If

        oCatalogoArticuloDG.SelectImage(ID)

    End Sub

    Public Sub Save(ByVal Articulo As Articulo)

        If (Articulo Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Articulo no puede ser nulo.")
        End If

        If (Articulo.IsNew) Then
            oCatalogoArticuloDG.Insert(Articulo)
        Else
            oCatalogoArticuloDG.Update(Articulo)
        End If

    End Sub

    Public Sub Delete(ByVal ID As String)

        If (ID = String.Empty) Then
            Throw New ArgumentException("Debe especificar un Código de Articulo")
        End If

        oCatalogoArticuloDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Articulo As Articulo)

        If (Articulo Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Articulo no puede ser nulo.")
        End If

        Try

            oCatalogoArticuloDG.Delete(Articulo.CodArticulo)
            Articulo.ClearFields()

        Catch ex As Exception

            Throw New ApplicationException("No se pudo eliminar el Articulo especificado.")

        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoArticuloDG.SelectAll(EnabledRecordsOnly)

    End Function

#End Region

#Region "Etiquetas"
    Public Function SelectCorridaMaxMin(ByVal CodArticulo As String) As String()
        Return oCatalogoArticuloDG.SelectCorridaMaxMin(CodArticulo)
    End Function

    Public Function SelectCorridaMaxMinImp(ByVal CodArticulo As String, ByVal StrTipo As String) As String
        Return oCatalogoArticuloDG.SelectCorridaMaxMinImp(CodArticulo, StrTipo)
    End Function

    Public Function SelectCodColor(ByVal CodArticulo As String) As String
        Return oCatalogoArticuloDG.SelectCodColor(CodArticulo)
    End Function


#End Region



#Region "SAP Retail"
    Public Function GetMotivosDefectuosos() As DataTable
        Return oCatalogoArticuloDG.GetMotivosDefectuosos()
    End Function

    Public Function GetCodMoTivoDefectuoso(ByVal Description As String) As String
        Return oCatalogoArticuloDG.GetCodMoTivoDefectuoso(Description)
    End Function

    Public Function GetDetalleArticuloDefectuosos(ByVal CodArticulo As String) As DataTable
        Return oCatalogoArticuloDG.GetDetalleArticuloDefectuosos(CodArticulo)
    End Function

    Public Function ValidaCodigoProveedor(ByVal CodProveedor As String) As String
        Return oCatalogoArticuloDG.ValidaCodigoProveedor(CodProveedor)
    End Function

    Public Function GetTallaByCodigo(ByVal CodArticulo As String) As String
        Return oCatalogoArticuloDG.GetTallaByCodigo(CodArticulo)
    End Function

    Public Function LoadIntoByCodPadre(ByVal CodPadre As String) As DataTable
        Return oCatalogoArticuloDG.LoadIntoByCodPadre(CodPadre)
    End Function

    Public Function GetArticulosNoLeturados(ByVal CodArticulo As String, ByVal FolioTraslado As String) As DataTable
        Return oCatalogoArticuloDG.SelArticulosNoLecturados(CodArticulo, FolioTraslado)
    End Function

#End Region

#Region "Cambio de talla"

    Public Function GetExistenciaByCodigo(ByVal CodArticulo As String) As Hashtable
        Return oCatalogoArticuloDG.GetExistenciaByCodigo(CodArticulo)
    End Function

#End Region

End Class
