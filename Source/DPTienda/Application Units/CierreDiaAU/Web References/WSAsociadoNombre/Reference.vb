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
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.34209.
'
Namespace WSAsociadoNombre
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="AsociadoInfoSoap", [Namespace]:="http://tempuri.org/WSAsociadoInfo/AsociadoInfo")>  _
    Partial Public Class AsociadoInfo
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetAosiadoInfoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        ''' 
        Public strURL As String
        Public Sub New()
            MyBase.New
            'Me.Url = "http://operaciones/WSAsociadoInfo/AsociadoInfo.asmx"
            strURL = "WSAsociadoInfo/AsociadoInfo.asmx"
            Dim urlSetting As String = System.Configuration.ConfigurationManager.AppSettings("CierreDiaAU.WSAsociadoNombre.WSasociadoInfo")
            If (Not (urlSetting) Is Nothing) Then
                Me.Url = String.Concat(urlSetting, "")
            Else
                Me.Url = "http://dpssvr/Credito/EstadodeCuentaAsociado.asmx"
            End If
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
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
        Public Event GetAosiadoInfoCompleted As GetAosiadoInfoCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WSAsociadoInfo/AsociadoInfo/GetAosiadoInfo", RequestNamespace:="http://tempuri.org/WSAsociadoInfo/AsociadoInfo", ResponseNamespace:="http://tempuri.org/WSAsociadoInfo/AsociadoInfo", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetAosiadoInfo(ByVal ClienteId As Integer) As String
            Dim results() As Object = Me.Invoke("GetAosiadoInfo", New Object() {ClienteId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetAosiadoInfo(ByVal ClienteId As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetAosiadoInfo", New Object() {ClienteId}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetAosiadoInfo(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetAosiadoInfoAsync(ByVal ClienteId As Integer)
            Me.GetAosiadoInfoAsync(ClienteId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetAosiadoInfoAsync(ByVal ClienteId As Integer, ByVal userState As Object)
            If (Me.GetAosiadoInfoOperationCompleted Is Nothing) Then
                Me.GetAosiadoInfoOperationCompleted = AddressOf Me.OnGetAosiadoInfoOperationCompleted
            End If
            Me.InvokeAsync("GetAosiadoInfo", New Object() {ClienteId}, Me.GetAosiadoInfoOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetAosiadoInfoOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetAosiadoInfoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetAosiadoInfoCompleted(Me, New GetAosiadoInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub GetAosiadoInfoCompletedEventHandler(ByVal sender As Object, ByVal e As GetAosiadoInfoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetAosiadoInfoCompletedEventArgs
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
End Namespace