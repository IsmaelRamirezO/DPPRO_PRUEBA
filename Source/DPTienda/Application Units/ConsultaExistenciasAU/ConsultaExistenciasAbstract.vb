Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core
Imports DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos


''' <summary>
'''     Proporciona la funcionalidad base a heredar en otros objetos para obtener la existencia actual 
'''     en inventario de cierto producto.
''' </summary>
Public MustInherit Class ConsultaExistenciasAbstract


    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oConsultaExistenciasDG As ConsultaExistenciasDataGateway


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

        oConsultaExistenciasDG = New ConsultaExistenciasDataGateway(Me)

    End Sub

    'TODO: CLM - Agregar constructor para pasar el APPContext

#End Region


#Region "Methods"

    ''' <summary>
    '''     Ejecuta una consulta de existencias para el artículo especificado.
    ''' </summary>
    ''' <param name="ArticuloID" type="String">
    '''     <para>
    '''         Codigo del Artículo a consultar.
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Retorna un valor de tipo ResultadoConsultaExistencias.
    ''' </returns>
    Public Function Execute(ByVal ArticuloID As String, ByVal AlmacenID As String, Optional BuscaPadre As Boolean = False, Optional ByVal BuscaCodProv As Boolean = False) As ResultadoConsultaExistencias

        Dim oCatalogoArticulosMgr As DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager
        oCatalogoArticulosMgr = New DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)

        Dim oArticulo As DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim alterflag As String
        'Dim oResult As ResultadoConsultaExistencias
        Dim oResult As New ResultadoConsultaExistencias

        'TODO: CLM - Llenar la información general del objeto oResult
        FillGeneralData(ArticuloID, alterflag, oResult, BuscaCodProv)

        oArticulo = oCatalogoArticulosMgr.Load(ArticuloID)

        If oArticulo Is Nothing Then

            Exit Function
        Else
            'oArticulo = Nothing
            'TODO: CLM - Llenar la información del detalle del objeto oResult
            FillDetailData(ArticuloID, AlmacenID, oResult, BuscaPadre)
            Return oResult
        End If
    End Function


    ''' <summary>
    '''     Agrega la información general del artículo al ResultadoConsultaExistencias especificado.
    ''' </summary>
    ''' <param name="ArticleID" type="String">
    '''     <para>
    '''         Codigo del Artículo a consultar.
    '''     </para>
    ''' </param>
    ''' <param name="Result" type="ResultadoConsultaExistencias">
    '''     <para>
    '''         Objeto al que se agregará la información.
    '''     </para>
    ''' </param>
    Public Sub FillGeneralData(ByRef ArticleID As String, ByVal AlterFlag As String, ByVal Result As ResultadoConsultaExistencias, Optional ByVal BuscaCodProv As Boolean = False)

        'TODO: CLM - Obtenga la información del artículo y agreguela al objeto Result
        'Puede utilizar el datagateway o utilizar la unidad de aplicacion CatalogoArticulosAU para esta operacion.

        Dim oCatalogoArticulosMgr As DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager
        Dim oArticulo As DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.Articulo
        Dim oResultado As DportenisPro.DpTienda.ApplicationUnits.ConsultaExistencias.ResultadoConsultaExistencias


        ' Dim oFoto As DportenisPro.DPTienda.ApplicationUnits.CatalogoArticulos.Articulo

        'TODO: CLM - Crear instancia de CatalogoArticulosManager
        oCatalogoArticulosMgr = New DportenisPro.DpTienda.ApplicationUnits.CatalogoArticulos.CatalogoArticuloManager(oAppContext)

        oArticulo = Nothing

        oArticulo = oCatalogoArticulosMgr.LoadNew(ArticleID, BuscaCodProv)

        If oArticulo Is Nothing Then

            Exit Sub
        Else
            With Result
                ArticleID = oArticulo.CodArticulo
                .ArticuloID = oArticulo.CodArticulo
                .Descripcion = oArticulo.Descripcion
                .CodArtProv = oArticulo.CodArtProv
                '.CodCorrida = oArticulo.CodCorrida
                .CodCorrida = oArticulo.DescCodCorrida
                .Precio = oArticulo.PrecioVenta
                .Promocion = oArticulo.PrecioOferta
                .Descuento = oArticulo.Descuento
                '.Linea = oArticulo.Codlinea
                .Linea = oArticulo.DescCodLinea
                '.Familia = oArticulo.CodFamilia
                .Familia = oArticulo.DescCodFamilia
                '.Uso = oArticulo.CodUso
                .Uso = oArticulo.DescCodUso
                .Foto = oArticulo.Imagen
                .HaveImage = oArticulo.WithImage
                .Jeraquia = oArticulo.Jerarquia
                .CodMarca = oArticulo.CodMarca

                If AlterFlag = "Alter1" Then
                    oCatalogoArticulosMgr.GetImage(ArticleID)
                    .FotoAlter = oArticulo.ImagenAlter
                    .HaveImageAlter = oArticulo.WithImageAlter
                    Return
                Else
                    If AlterFlag = "Alter2" Then
                        oCatalogoArticulosMgr.GetImage(ArticleID)
                        .FotoAlter = oArticulo.ImagenAlter
                        .HaveImageAlter = oArticulo.WithImageAlter
                        Return
                    Else
                        If AlterFlag = "Alter3" Then
                            oCatalogoArticulosMgr.GetImage(ArticleID)
                            .FotoAlter = oArticulo.ImagenAlter
                            .HaveImageAlter = oArticulo.WithImageAlter
                            Return
                        End If
                    End If

                End If

            End With

            Result.ArticuloID = oArticulo.CodArticulo


            'oArticulo = Nothing
            oCatalogoArticulosMgr = Nothing



        End If


    End Sub

    ''' <summary>
    '''     Agrega la información de la existencia al ResultadoConsultaExistencias especificado.
    ''' </summary>
    ''' <remarks>
    '''     Este método debe ser reemplazado por la clase que herede de esta clase.
    ''' </remarks>
    ''' <param name="ArticleID" type="String">
    '''     <para>
    '''         Codigo del Artículo a consultar.
    '''     </para>
    ''' </param>
    ''' <param name="Result" type="ResultadoConsultaExistencias">
    '''     <para>
    '''         Objeto al que se agregará la información.
    '''     </para>
    ''' </param>
    ''' 


    'MustOverride Sub FillDetailDataPlaza(ByVal ArticleID As String, ByVal PlazaID As String, ByVal Result As ResultadoConsultaExistencias)

    MustOverride Sub FillDetailData(ByVal ArticleID As String, ByVal AlmacenID As String, ByVal Result As ResultadoConsultaExistencias, Optional BuscaPadre As Boolean = False)

#End Region


End Class
