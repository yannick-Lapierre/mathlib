Namespace Algebra

    Public Enum RangeCheckResultType
        Overlap
        Gap
    End Enum

    Public Interface IRangeCheckResult
        ReadOnly Property Ranges As RangeCollection
        Property CheckResultType As RangeCheckResultType
        Function Equals(obj As IRangeCheckResult) As Boolean
    End Interface

    Public Class RangeCheckResult
        Implements IRangeCheckResult

        Private ReadOnly _ranges As New RangeCollection
        Public ReadOnly Property Ranges As RangeCollection Implements IRangeCheckResult.Ranges
            Get
                Return _ranges
            End Get
        End Property

        Public Property CheckResultType As RangeCheckResultType Implements IRangeCheckResult.CheckResultType

        Public Sub New(range1 As IRange, range2 As IRange, type As RangeCheckResultType)
            Ranges.Add(range1)
            Ranges.Add(range2)
            CheckResultType = type
        End Sub

        Public Overloads Function Equals(ByVal obj As IRangeCheckResult) As Boolean Implements IRangeCheckResult.Equals
            Dim result As Boolean

            If obj Is Nothing Then
                result = False
            Else
                If CheckResultType = obj.CheckResultType AndAlso
                   Ranges.Equals(obj.Ranges) Then
                    result = True
                Else
                    result = False
                End If
            End If

            Return result
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Dim result As Boolean
            Dim heavyTypedObject As IRangeCheckResult = TryCast(obj, IRangeCheckResult)

            If heavyTypedObject Is Nothing Then
                result = False
            Else

                result = Equals(heavyTypedObject)
            End If

            Return result
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return CheckResultType.GetHashCode Xor Ranges.GetHashCode
        End Function
    End Class

End Namespace