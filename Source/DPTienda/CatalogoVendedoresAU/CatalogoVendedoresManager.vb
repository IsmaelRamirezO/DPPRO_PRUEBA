
Option Explicit On 

Imports DportenisPro.DPTienda.Core


Public Class CatalogoVendedoresManager

    Private oApplicationContext As ApplicationContext
    Private oCatalogoVendedoresDG As CatalogoVendedoresDataGateway



#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

        oCatalogoVendedoresDG = New CatalogoVendedoresDataGateway(Me)

    End Sub



    Public Sub dispose()

        MyBase.Finalize()

        oCatalogoVendedoresDG = Nothing

    End Sub

#End Region



#Region "Properties"

    Public ReadOnly Property ApplicationContext() As ApplicationContext

        Get
            Return oApplicationContext
        End Get

    End Property

#End Region



#Region "Methods"

    Public Function Create() As Vendedor

        Dim oNuevoVendedor As Vendedor
        oNuevoVendedor = New Vendedor(Me)

        Return oNuevoVendedor

    End Function



    Public Function Load(ByVal ID As String) As Vendedor

        If (ID = String.Empty) Then
            MsgBox("Debe especificar un Código de Vendedor")
            Return Nothing
            Exit Function
            'Throw New ArgumentException("Debe especificar un Código de Vendedor")
        End If

        'If (ID.Length > 3) Then
        '    Throw New ArgumentException("El Código de Vendedor no debe exceder los 3 caracteres de longitud.")
        'End If

        Dim oReadedVendedor As Vendedor

        oReadedVendedor = oCatalogoVendedoresDG.SelectByID(ID)

        Return oReadedVendedor

    End Function

    Public Sub LoadInto(ByVal ID As String, ByVal oVendedor As Vendedor)

        oCatalogoVendedoresDG.SelectInto(ID, oVendedor)

    End Sub



    Public Function GetAll(ByVal EnabledRecordsOnly As Boolean) As DataSet

        Return oCatalogoVendedoresDG.SelectAll()

    End Function

#End Region

End Class
