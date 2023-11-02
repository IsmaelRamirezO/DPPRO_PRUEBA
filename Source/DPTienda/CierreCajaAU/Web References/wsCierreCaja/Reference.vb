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
Namespace wsCierreCaja
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="CierreCajaSoap", [Namespace]:="http://tempuri.org/wsCierreCaja/Service1")>  _
    Partial Public Class CierreCaja
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private CalcularTotalDPValeCreditoDirectoTEOperationCompleted As System.Threading.SendOrPostCallback
        
        Private CalcularTotalDPValeCreditoDirectoTMOperationCompleted As System.Threading.SendOrPostCallback
        
        Private CalcularTotalCreditoDirectoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        ''' 
        Public strURL As String
        Public Sub New()
            MyBase.New
            'Me.Url = Global.DportenisPro.DPTienda.ApplicationUnits.CierreCaja.My.MySettings.Default.CierreCajaAU_wsCierreCaja_CierreCaja
            strURL = "Credito/CierreCaja.asmx"
            Dim urlSetting As String = System.Configuration.ConfigurationManager.AppSettings("CierreCajaAU.wsCierreCaja.CierreCaja")
            If (Not (urlSetting) Is Nothing) Then
                Me.Url = String.Concat(urlSetting, "")
            Else
                Me.Url = "http://dpssvr/Credito/CierreCaja.asmx"
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
        Public Event CalcularTotalDPValeCreditoDirectoTECompleted As CalcularTotalDPValeCreditoDirectoTECompletedEventHandler
        
        '''<remarks/>
        Public Event CalcularTotalDPValeCreditoDirectoTMCompleted As CalcularTotalDPValeCreditoDirectoTMCompletedEventHandler
        
        '''<remarks/>
        Public Event CalcularTotalCreditoDirectoCompleted As CalcularTotalCreditoDirectoCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/wsCierreCaja/Service1/CalcularTotalDPValeCreditoDirectoTE", RequestNamespace:="http://tempuri.org/wsCierreCaja/Service1", ResponseNamespace:="http://tempuri.org/wsCierreCaja/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CalcularTotalDPValeCreditoDirectoTE(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String) As Decimal
            Dim results() As Object = Me.Invoke("CalcularTotalDPValeCreditoDirectoTE", New Object() {FechaCierre, CajaID, Almacen})
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Function BeginCalcularTotalDPValeCreditoDirectoTE(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CalcularTotalDPValeCreditoDirectoTE", New Object() {FechaCierre, CajaID, Almacen}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCalcularTotalDPValeCreditoDirectoTE(ByVal asyncResult As System.IAsyncResult) As Decimal
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalDPValeCreditoDirectoTEAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String)
            Me.CalcularTotalDPValeCreditoDirectoTEAsync(FechaCierre, CajaID, Almacen, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalDPValeCreditoDirectoTEAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal userState As Object)
            If (Me.CalcularTotalDPValeCreditoDirectoTEOperationCompleted Is Nothing) Then
                Me.CalcularTotalDPValeCreditoDirectoTEOperationCompleted = AddressOf Me.OnCalcularTotalDPValeCreditoDirectoTEOperationCompleted
            End If
            Me.InvokeAsync("CalcularTotalDPValeCreditoDirectoTE", New Object() {FechaCierre, CajaID, Almacen}, Me.CalcularTotalDPValeCreditoDirectoTEOperationCompleted, userState)
        End Sub
        
        Private Sub OnCalcularTotalDPValeCreditoDirectoTEOperationCompleted(ByVal arg As Object)
            If (Not (Me.CalcularTotalDPValeCreditoDirectoTECompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CalcularTotalDPValeCreditoDirectoTECompleted(Me, New CalcularTotalDPValeCreditoDirectoTECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/wsCierreCaja/Service1/CalcularTotalDPValeCreditoDirectoTM", RequestNamespace:="http://tempuri.org/wsCierreCaja/Service1", ResponseNamespace:="http://tempuri.org/wsCierreCaja/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CalcularTotalDPValeCreditoDirectoTM(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String) As Decimal
            Dim results() As Object = Me.Invoke("CalcularTotalDPValeCreditoDirectoTM", New Object() {FechaCierre, CajaID, Almacen})
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Function BeginCalcularTotalDPValeCreditoDirectoTM(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CalcularTotalDPValeCreditoDirectoTM", New Object() {FechaCierre, CajaID, Almacen}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCalcularTotalDPValeCreditoDirectoTM(ByVal asyncResult As System.IAsyncResult) As Decimal
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalDPValeCreditoDirectoTMAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String)
            Me.CalcularTotalDPValeCreditoDirectoTMAsync(FechaCierre, CajaID, Almacen, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalDPValeCreditoDirectoTMAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal userState As Object)
            If (Me.CalcularTotalDPValeCreditoDirectoTMOperationCompleted Is Nothing) Then
                Me.CalcularTotalDPValeCreditoDirectoTMOperationCompleted = AddressOf Me.OnCalcularTotalDPValeCreditoDirectoTMOperationCompleted
            End If
            Me.InvokeAsync("CalcularTotalDPValeCreditoDirectoTM", New Object() {FechaCierre, CajaID, Almacen}, Me.CalcularTotalDPValeCreditoDirectoTMOperationCompleted, userState)
        End Sub
        
        Private Sub OnCalcularTotalDPValeCreditoDirectoTMOperationCompleted(ByVal arg As Object)
            If (Not (Me.CalcularTotalDPValeCreditoDirectoTMCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CalcularTotalDPValeCreditoDirectoTMCompleted(Me, New CalcularTotalDPValeCreditoDirectoTMCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/wsCierreCaja/Service1/CalcularTotalCreditoDirecto", RequestNamespace:="http://tempuri.org/wsCierreCaja/Service1", ResponseNamespace:="http://tempuri.org/wsCierreCaja/Service1", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CalcularTotalCreditoDirecto(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String) As Decimal
            Dim results() As Object = Me.Invoke("CalcularTotalCreditoDirecto", New Object() {FechaCierre, CajaID, Almacen})
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Function BeginCalcularTotalCreditoDirecto(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CalcularTotalCreditoDirecto", New Object() {FechaCierre, CajaID, Almacen}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCalcularTotalCreditoDirecto(ByVal asyncResult As System.IAsyncResult) As Decimal
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Decimal)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalCreditoDirectoAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String)
            Me.CalcularTotalCreditoDirectoAsync(FechaCierre, CajaID, Almacen, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CalcularTotalCreditoDirectoAsync(ByVal FechaCierre As Date, ByVal CajaID As String, ByVal Almacen As String, ByVal userState As Object)
            If (Me.CalcularTotalCreditoDirectoOperationCompleted Is Nothing) Then
                Me.CalcularTotalCreditoDirectoOperationCompleted = AddressOf Me.OnCalcularTotalCreditoDirectoOperationCompleted
            End If
            Me.InvokeAsync("CalcularTotalCreditoDirecto", New Object() {FechaCierre, CajaID, Almacen}, Me.CalcularTotalCreditoDirectoOperationCompleted, userState)
        End Sub
        
        Private Sub OnCalcularTotalCreditoDirectoOperationCompleted(ByVal arg As Object)
            If (Not (Me.CalcularTotalCreditoDirectoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CalcularTotalCreditoDirectoCompleted(Me, New CalcularTotalCreditoDirectoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub CalcularTotalDPValeCreditoDirectoTECompletedEventHandler(ByVal sender As Object, ByVal e As CalcularTotalDPValeCreditoDirectoTECompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CalcularTotalDPValeCreditoDirectoTECompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Decimal
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Decimal)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub CalcularTotalDPValeCreditoDirectoTMCompletedEventHandler(ByVal sender As Object, ByVal e As CalcularTotalDPValeCreditoDirectoTMCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CalcularTotalDPValeCreditoDirectoTMCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Decimal
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Decimal)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub CalcularTotalCreditoDirectoCompletedEventHandler(ByVal sender As Object, ByVal e As CalcularTotalCreditoDirectoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CalcularTotalCreditoDirectoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Decimal
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Decimal)
            End Get
        End Property
    End Class
End Namespace