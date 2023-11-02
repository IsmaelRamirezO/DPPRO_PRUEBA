Imports System.Collections.Generic

Public Class ProcessAsync

#Region "Variables"

    Private t As Timers.Timer
    Private FuncionAsync As FunctionAsync
    Private Fin As Boolean
    Public Delegate Function FunctionAsync(ByVal Traspaso As Dictionary(Of String, Object)) As Boolean
    Private Traspaso As Dictionary(Of String, Object)
    Private Reintento As Integer = 0

#End Region

#Region "Constructores"

    Public Sub New(ByVal Traspaso As Dictionary(Of String, Object))
        Me.Traspaso = Traspaso
        Fin = False
        t = New Timers.Timer
        t.Interval = 1000
    End Sub

#End Region

#Region "Metodos y funciones"

    Public Sub Execute(ByVal FuncionAsync As FunctionAsync)
        Me.FuncionAsync = FuncionAsync
        AddHandler t.Elapsed, AddressOf InicioAsync
        t.Start()
    End Sub

    Private Sub InicioAsync()
        t.Stop()
        t.Interval = oConfigCierreFI.TiempoIntervaloConsignacion
        t.Start()
        If Fin <> True Then
            If Reintento <= oConfigCierreFI.ReintentoConsignacion Then
                t.Stop()
                Fin = Me.FuncionAsync(Me.Traspaso)
                Reintento += 1
                t.Start()
            Else
                t.Stop()
            End If
        Else
            t.Stop()
        End If
        't.Stop()
        'While Fin <> True OrElse reintento <= oConfigCierreFI.ReintentoConsignacion
        '    Fin = Me.FuncionAsync(Me.Traspaso)
        '    reintento += 1
        '    Threading.Thread.Sleep(oConfigCierreFI.TiempoIntervaloConsignacion)
        'End While
    End Sub
#End Region

End Class
