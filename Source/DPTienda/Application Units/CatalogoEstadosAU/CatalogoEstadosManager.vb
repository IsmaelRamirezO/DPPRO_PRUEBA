Imports DportenisPro.DPTienda
Imports DportenisPro.DPTienda.Core

Public Class CatalogoEstadosManager

    Private oAppContext As DportenisPro.DPTienda.Core.ApplicationContext
    Private oCatalogoEstadosDG As CatalogoEstadosDataGateway

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

        oCatalogoEstadosDG = New CatalogoEstadosDataGateway(Me)

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        oCatalogoEstadosDG = Nothing

    End Sub

#End Region


#Region "Methods"

    Public Function Create() As Estado

        Dim oNewEstado As Estado
        oNewEstado = New Estado(Me)

        Return oNewEstado

    End Function

    Public Function Load(ByVal ID As Integer) As Estado

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Estado")
        End If

        Dim oReadedEstado As Estado

        oReadedEstado = oCatalogoEstadosDG.Select(ID)

        Return oReadedEstado

    End Function


    Public Sub LoadInto(ByVal ID As Integer, ByVal Estado As Estado)

        oCatalogoEstadosDG.Select(ID, Estado)

    End Sub

    Public Sub Save(ByVal Estado As Estado)

        If (Estado Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Estado no puede ser nulo.")
        End If

        If (Estado.IsNew) Then
            oCatalogoEstadosDG.Insert(Estado)
        Else
            oCatalogoEstadosDG.Update(Estado)
        End If

    End Sub

    Public Sub Delete(ByVal ID As Integer)

        If (ID = 0) Then
            Throw New ArgumentException("Debe especificar un Código de Estados")
        End If

        oCatalogoEstadosDG.Delete(ID)

    End Sub

    Public Sub Delete(ByVal Estado As Estado)

        If (Estado Is Nothing) Then
            Throw New ArgumentNullException("El parámetro Estado no puede ser nulo.")
        End If

        Try
            oCatalogoEstadosDG.Delete(Estado.CodEstado)

            Estado.Clear()

        Catch ex As Exception
            Throw New ApplicationException("No se pudo eliminar el Estado especificado.")
        End Try

    End Sub

    Public Function GetAll(Optional ByVal EnabledRecordsOnly As Boolean = False) As DataSet

        Return oCatalogoEstadosDG.Select(EnabledRecordsOnly)

    End Function

#End Region

End Class
