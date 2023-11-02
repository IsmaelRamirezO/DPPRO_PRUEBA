Public Class ApplicationUnit
    Inherits DportenisPro.DPTienda.Core.BaseApplicationUnit

    Public Overrides ReadOnly Property Description() As String
        Get
            Return "Catalogo de Líneas"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            Return "DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas"
        End Get
    End Property

    Public Overrides Sub RegisterIntoApplication(ByVal ApplicationContext As Core.ApplicationContext)

        Dim intIndex As Integer
        Dim oFeature As DPSoft.Framework.Security.Feature

        With ApplicationContext.Security.Features

            intIndex = .Add("DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas", "Catalogo de Líneas")

            oFeature = .Item(intIndex)

            With oFeature.Operations

                .Add("DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas.CreateLinea", "Crear Linea")
                .Add("DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas.UpdateLinea", "Modificar Línea")
                .Add("DportenisPro.DPTienda.ApplicationUnits.CatalogoLineas.DeleteLinea", "Eliminar Línea")

            End With

        End With
    End Sub
End Class
