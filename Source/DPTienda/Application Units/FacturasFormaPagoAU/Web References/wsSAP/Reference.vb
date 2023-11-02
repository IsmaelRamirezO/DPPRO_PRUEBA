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
Imports System.Configuration
'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.34209.
'
Namespace wsSAP
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="Credito .:::· SAPSoap", [Namespace]:="http://ws.dportenis.com.mx/Credito/SAP")>  _
    Partial Public Class CreditoSAP
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private SaveFIDocumentOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetDistribuidorSAPOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        ''' 
        Public strUrl As String
        Public Sub New()
            MyBase.New
            'Me.Url = Global.DportenisPro.DPTienda.ApplicationUnits.FacturasFormaPago.My.MySettings.Default.FacturasFormaPagoAU_wsSAP_Credito_x0020___x003A__x003A__x003A___x0020_SAP
            strUrl = "credito/SAP.asmx"
            Dim urlSetting As String = System.Configuration.ConfigurationManager.AppSettings("FacturasFormaPagoAU.wsSAP.Credito .:::· SAP")
            If (Not (urlSetting) Is Nothing) Then
                Me.Url = String.Concat(urlSetting, "")
            Else
                Me.Url = "http://localhost/credito/sap.asmx"
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
        Public Event SaveFIDocumentCompleted As SaveFIDocumentCompletedEventHandler
        
        '''<remarks/>
        Public Event GetDistribuidorSAPCompleted As GetDistribuidorSAPCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.dportenis.com.mx/Credito/SAP/SaveFIDocument", RequestNamespace:="http://ws.dportenis.com.mx/Credito/SAP", ResponseNamespace:="http://ws.dportenis.com.mx/Credito/SAP", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub SaveFIDocument(ByVal strSucursal As String, ByVal strCodCaja As String, ByVal intFolioFactura As Integer, ByVal strFIDocument As String)
            Me.Invoke("SaveFIDocument", New Object() {strSucursal, strCodCaja, intFolioFactura, strFIDocument})
        End Sub
        
        '''<remarks/>
        Public Function BeginSaveFIDocument(ByVal strSucursal As String, ByVal strCodCaja As String, ByVal intFolioFactura As Integer, ByVal strFIDocument As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SaveFIDocument", New Object() {strSucursal, strCodCaja, intFolioFactura, strFIDocument}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Sub EndSaveFIDocument(ByVal asyncResult As System.IAsyncResult)
            Me.EndInvoke(asyncResult)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SaveFIDocumentAsync(ByVal strSucursal As String, ByVal strCodCaja As String, ByVal intFolioFactura As Integer, ByVal strFIDocument As String)
            Me.SaveFIDocumentAsync(strSucursal, strCodCaja, intFolioFactura, strFIDocument, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SaveFIDocumentAsync(ByVal strSucursal As String, ByVal strCodCaja As String, ByVal intFolioFactura As Integer, ByVal strFIDocument As String, ByVal userState As Object)
            If (Me.SaveFIDocumentOperationCompleted Is Nothing) Then
                Me.SaveFIDocumentOperationCompleted = AddressOf Me.OnSaveFIDocumentOperationCompleted
            End If
            Me.InvokeAsync("SaveFIDocument", New Object() {strSucursal, strCodCaja, intFolioFactura, strFIDocument}, Me.SaveFIDocumentOperationCompleted, userState)
        End Sub
        
        Private Sub OnSaveFIDocumentOperationCompleted(ByVal arg As Object)
            If (Not (Me.SaveFIDocumentCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SaveFIDocumentCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ws.dportenis.com.mx/Credito/SAP/GetDistribuidorSAP", RequestNamespace:="http://ws.dportenis.com.mx/Credito/SAP", ResponseNamespace:="http://ws.dportenis.com.mx/Credito/SAP", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetDistribuidorSAP(ByVal AsociadoID As Integer) As String
            Dim results() As Object = Me.Invoke("GetDistribuidorSAP", New Object() {AsociadoID})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Function BeginGetDistribuidorSAP(ByVal AsociadoID As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetDistribuidorSAP", New Object() {AsociadoID}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndGetDistribuidorSAP(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetDistribuidorSAPAsync(ByVal AsociadoID As Integer)
            Me.GetDistribuidorSAPAsync(AsociadoID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetDistribuidorSAPAsync(ByVal AsociadoID As Integer, ByVal userState As Object)
            If (Me.GetDistribuidorSAPOperationCompleted Is Nothing) Then
                Me.GetDistribuidorSAPOperationCompleted = AddressOf Me.OnGetDistribuidorSAPOperationCompleted
            End If
            Me.InvokeAsync("GetDistribuidorSAP", New Object() {AsociadoID}, Me.GetDistribuidorSAPOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetDistribuidorSAPOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetDistribuidorSAPCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetDistribuidorSAPCompleted(Me, New GetDistribuidorSAPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub SaveFIDocumentCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")>  _
    Public Delegate Sub GetDistribuidorSAPCompletedEventHandler(ByVal sender As Object, ByVal e As GetDistribuidorSAPCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetDistribuidorSAPCompletedEventArgs
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
