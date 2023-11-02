﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.34209
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.34209.
'
Namespace wsEstadoDeCuentaAsociado
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="EstadodeCuentaAsociadoSoap", [Namespace]:="http://tempuri.org/Credito/EstadodeCuentaAsociado")>  _
    Partial Public Class EstadodeCuentaAsociado
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private InsertMovimientoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetMovimientoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        ''' 
        Public strURL As String
        Public Sub New()
            MyBase.New
            'Me.Url = Global.DportenisPro.DPTienda.ApplicationUnits.AbonoCreditoDirectoTienda.My.MySettings.Default.AbonoCreditoDirectoTienda_wsEstadoDeCuentaAsociado_EstadodeCuentaAsociado
            strURL = "Credito/EstadodeCuentaAsociado.asmx"
            Dim urlSetting As String = System.Configuration.ConfigurationManager.AppSettings("AbonoCreditoDirectoTienda.wsEstadoDeCuentaAsociado.EstadodeCuentaAsociado")
            If (Not (urlSetting) Is Nothing) Then
                Me.Url = String.Concat(urlSetting, "")
            Else
                Me.Url = "http://dpssvr/Credito/EstadodeCuentaAsociado.asmx"
            End If
            If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
                Me.UseDefaultCredentials = True
                Me.useDefaultCredentialsSetExplicitly = False
            Else
                Me.useDefaultCredentialsSetExplicitly = True
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event InsertMovimientoCompleted As InsertMovimientoCompletedEventHandler
        
        '''<remarks/>
        Public Event GetMovimientoCompleted As GetMovimientoCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Credito/EstadodeCuentaAsociado/InsertMovimiento", RequestNamespace:="http://tempuri.org/Credito/EstadodeCuentaAsociado", ResponseNamespace:="http://tempuri.org/Credito/EstadodeCuentaAsociado", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function InsertMovimiento(ByVal Modulo As String, ByVal oMovimientoInfo As MovimientosInfo) As String
            Dim results() As Object = Me.Invoke("InsertMovimiento", New Object() {Modulo, oMovimientoInfo})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginInsertMovimiento(ByVal Modulo As String, ByVal oMovimientoInfo As MovimientosInfo, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("InsertMovimiento", New Object() {Modulo, oMovimientoInfo}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndInsertMovimiento(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub InsertMovimientoAsync(ByVal Modulo As String, ByVal oMovimientoInfo As MovimientosInfo)
            Me.InsertMovimientoAsync(Modulo, oMovimientoInfo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub InsertMovimientoAsync(ByVal Modulo As String, ByVal oMovimientoInfo As MovimientosInfo, ByVal userState As Object)
            If (Me.InsertMovimientoOperationCompleted Is Nothing) Then
                Me.InsertMovimientoOperationCompleted = AddressOf Me.OnInsertMovimientoOperationCompleted
            End If
            Me.InvokeAsync("InsertMovimiento", New Object() {Modulo, oMovimientoInfo}, Me.InsertMovimientoOperationCompleted, userState)
        End Sub
        
        Private Sub OnInsertMovimientoOperationCompleted(ByVal arg As Object)
            If (Not (Me.InsertMovimientoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent InsertMovimientoCompleted(Me, New InsertMovimientoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Credito/EstadodeCuentaAsociado/GetMovimiento", RequestNamespace:="http://tempuri.org/Credito/EstadodeCuentaAsociado", ResponseNamespace:="http://tempuri.org/Credito/EstadodeCuentaAsociado", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMovimiento(ByVal Modulo As String, ByVal AsociadoID As Integer) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("GetMovimiento", New Object() {Modulo, AsociadoID})
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Function BeginGetMovimiento(ByVal Modulo As String, ByVal AsociadoID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetMovimiento", New Object() {Modulo, AsociadoID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetMovimiento(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetMovimientoAsync(ByVal Modulo As String, ByVal AsociadoID As Integer)
            Me.GetMovimientoAsync(Modulo, AsociadoID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetMovimientoAsync(ByVal Modulo As String, ByVal AsociadoID As Integer, ByVal userState As Object)
            If (Me.GetMovimientoOperationCompleted Is Nothing) Then
                Me.GetMovimientoOperationCompleted = AddressOf Me.OnGetMovimientoOperationCompleted
            End If
            Me.InvokeAsync("GetMovimiento", New Object() {Modulo, AsociadoID}, Me.GetMovimientoOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetMovimientoOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetMovimientoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMovimientoCompleted(Me, New GetMovimientoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/Credito/EstadodeCuentaAsociado")>  _
    Partial Public Class MovimientosInfo
        
        Private fechaMovimientoField As Date
        
        Private codigoAlmacenField As String
        
        Private codigoCajaField As String
        
        Private folioMovimientoField As Integer
        
        Private tipoDocumentoField As String
        
        Private usuarioField As String
        
        Private statusRegistroField As Integer
        
        Private cargoField As Decimal
        
        Private abonoField As Decimal
        
        Private asociadoIDField As Integer
        
        Private mesField As Integer
        
        Private añoField As Integer
        
        '''<comentarios/>
        Public Property FechaMovimiento() As Date
            Get
                Return Me.fechaMovimientoField
            End Get
            Set
                Me.fechaMovimientoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property CodigoAlmacen() As String
            Get
                Return Me.codigoAlmacenField
            End Get
            Set
                Me.codigoAlmacenField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property CodigoCaja() As String
            Get
                Return Me.codigoCajaField
            End Get
            Set
                Me.codigoCajaField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property FolioMovimiento() As Integer
            Get
                Return Me.folioMovimientoField
            End Get
            Set
                Me.folioMovimientoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property TipoDocumento() As String
            Get
                Return Me.tipoDocumentoField
            End Get
            Set
                Me.tipoDocumentoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Usuario() As String
            Get
                Return Me.usuarioField
            End Get
            Set
                Me.usuarioField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property StatusRegistro() As Integer
            Get
                Return Me.statusRegistroField
            End Get
            Set
                Me.statusRegistroField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Cargo() As Decimal
            Get
                Return Me.cargoField
            End Get
            Set
                Me.cargoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Abono() As Decimal
            Get
                Return Me.abonoField
            End Get
            Set
                Me.abonoField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property AsociadoID() As Integer
            Get
                Return Me.asociadoIDField
            End Get
            Set
                Me.asociadoIDField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Mes() As Integer
            Get
                Return Me.mesField
            End Get
            Set
                Me.mesField = value
            End Set
        End Property
        
        '''<comentarios/>
        Public Property Año() As Integer
            Get
                Return Me.añoField
            End Get
            Set
                Me.añoField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub InsertMovimientoCompletedEventHandler(ByVal sender As Object, ByVal e As InsertMovimientoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class InsertMovimientoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub GetMovimientoCompletedEventHandler(ByVal sender As Object, ByVal e As GetMovimientoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetMovimientoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataSet
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataSet)
            End Get
        End Property
    End Class
End Namespace