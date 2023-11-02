Public Class FacturaFormaPagoCollection

    Inherits System.Collections.CollectionBase

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal facValue As FacturaFormaPagoCollection)
        MyBase.New()
        Me.AddRange(facValue)
    End Sub

    Public Sub New(ByVal facValue() As FacturaFormaPago)
        MyBase.New()
        Me.AddRange(facValue)
    End Sub

    Default Public Property Item(ByVal intIndex As Integer) As FacturaFormaPago
        Get
            Return CType(List(intIndex), FacturaFormaPago)
        End Get
        Set(ByVal Value As FacturaFormaPago)
            List(intIndex) = Value
        End Set
    End Property

    Public Function Add(ByVal facValue As FacturaFormaPago) As Integer
        Return List.Add(facValue)
    End Function

    Public Overloads Sub AddRange(ByVal facValue() As FacturaFormaPago)
        Dim intCounter As Integer = 0
        Do While (intCounter < facValue.Length)
            Me.Add(facValue(intCounter))
            intCounter = (intCounter + 1)
        Loop
    End Sub

    Public Overloads Sub AddRange(ByVal facValue As FacturaFormaPagoCollection)
        Dim intCounter As Integer = 0
        Do While (intCounter < facValue.Count)
            Me.Add(facValue(intCounter))
            intCounter = (intCounter + 1)
        Loop
    End Sub

    Public Function Contains(ByVal facValue As FacturaFormaPago) As Boolean
        Return List.Contains(facValue)
    End Function

    Public Sub CopyTo(ByVal facArray() As FacturaFormaPago, ByVal intIndex As Integer)
        List.CopyTo(facArray, intIndex)
    End Sub

    Public Function IndexOf(ByVal facValue As FacturaFormaPago) As Integer
        Return List.IndexOf(facValue)
    End Function

    Public Sub Insert(ByVal intIndex As Integer, ByVal facValue As FacturaFormaPago)
        List.Insert(intIndex, facValue)
    End Sub

    Public Shadows Function GetEnumerator() As FacturaFormaPagoEnumerator
        Return New FacturaFormaPagoEnumerator(Me)
    End Function

    Public Sub Remove(ByVal facValue As FacturaFormaPago)
        List.Remove(facValue)
    End Sub

    Public Class FacturaFormaPagoEnumerator

        Inherits Object
        Implements System.Collections.IEnumerator

        Private iEnBase As System.Collections.IEnumerator

        Private iEnLocal As System.Collections.IEnumerable

        Public Sub New(ByVal facMappings As FacturaFormaPagoCollection)
            MyBase.New()
            Me.iEnLocal = CType(facMappings, System.Collections.IEnumerable)
            Me.iEnBase = iEnLocal.GetEnumerator
        End Sub

        Public ReadOnly Property Current() As FacturaFormaPago
            Get
                Return CType(iEnBase.Current, FacturaFormaPago)
            End Get
        End Property

        ReadOnly Property System_Collections_IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return iEnBase.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean
            Return iEnBase.MoveNext
        End Function

        Function System_Collections_IEnumerator_MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            Return iEnBase.MoveNext
        End Function

        Public Sub Reset()
            iEnBase.Reset()
        End Sub

        Sub System_Collections_IEnumerator_Reset() Implements System.Collections.IEnumerator.Reset
            iEnBase.Reset()
        End Sub

    End Class

End Class