Imports System.Collections.ObjectModel
Imports MathLib.Utilities

Namespace Algebra
    Public Class RangeCollection
        Inherits Collection(Of IRange)

        Public Sub AddRange(ranges As IEnumerable(Of IRange))
            Contracts.Contract.Requires(Of ArgumentNullException)(ranges IsNot Nothing, "ranges")

            For Each range As IRange In ranges
                Add(range)
            Next
        End Sub

#Region "Gap"

        Public Function HasGap() As Boolean
            Return HasGap(Me)
        End Function

        Public Shared Function HasGap(rangeList As IEnumerable(Of IRange)) As Boolean
            Return CheckGap(rangeList).Count > 0
        End Function

        Public Function CheckGap() As RangeCheckResultCollection
            Return CheckGap(Me)
        End Function

        Public Shared Function CheckGap(rangeList As IEnumerable(Of IRange)) As RangeCheckResultCollection
            ' ReSharper disable CompareOfFloatsByEqualityOperator
            Dim result As New RangeCheckResultCollection
            Dim orderedRanges As IOrderedEnumerable(Of IRange)

            orderedRanges = From range In rangeList Order By range.LowEndValue

            For i As Integer = 0 To orderedRanges.Count - 2
                If (orderedRanges(i).HighEndValue < orderedRanges(i + 1).LowEndValue) OrElse
                    (
                        (orderedRanges(i).HighEndValue = orderedRanges(i + 1).LowEndValue) AndAlso
                        (Not orderedRanges(i).IsHighEndIncluded) AndAlso
                        (Not orderedRanges(i + 1).IsLowEndIncluded)
                    ) Then

                    result.Add(New RangeCheckResult(orderedRanges(i), orderedRanges(i + 1), RangeCheckResultType.Gap))
                End If
            Next

            Return result
            ' ReSharper restore CompareOfFloatsByEqualityOperator
        End Function

#End Region

#Region "Overlap"
        Public Function HasOverlapping() As Boolean
            Return HasOverlapping(Me)
        End Function

        Public Shared Function HasOverlapping(rangeList As IEnumerable(Of IRange)) As Boolean
            Return CheckOverlapping(rangeList).Count > 0
        End Function

        Public Function CheckOverlapping() As RangeCheckResultCollection
            Return CheckOverlapping(Me)
        End Function

        Public Shared Function CheckOverlapping(rangeList As IEnumerable(Of IRange)) As RangeCheckResultCollection
            Dim result As New RangeCheckResultCollection

            Dim orderedRanges As IOrderedEnumerable(Of IRange)

            orderedRanges = From range In rangeList Order By range.LowEndValue

            For i As Integer = 0 To orderedRanges.Count - 2
                For j As Integer = i + 1 To orderedRanges.Count - 1
                    If (i <> j) AndAlso CheckRangeOverlap(orderedRanges(i), orderedRanges(j)) Then
                        result.Add(New RangeCheckResult(orderedRanges(i), orderedRanges(j), RangeCheckResultType.Overlap))
                    End If
                Next
            Next

            Return result
        End Function
#End Region

        Public Overrides Function ToString() As String
            Return ToString(Items)
        End Function

        Public Overloads Shared Function ToString(ranges As IEnumerable(Of IRange)) As String
            Contracts.Contract.Requires(Of ArgumentNullException)(ranges IsNot Nothing, "ranges")

            Return EnumerableToString(ranges, ",")
        End Function

        Public Overloads Function Equals(ByVal obj As RangeCollection) As Boolean
            Dim result As Boolean

            If obj IsNot Nothing AndAlso obj.Count = Count Then
                result = True
                For i As Integer = 0 To Count - 1
                    If Not Item(i).Equals(obj.Items(i)) Then
                        result = False
                    End If
                Next
            End If

            Return result
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Dim result As Boolean
            Dim heavyTypedObject As RangeCollection = TryCast(obj, RangeCollection)

            If heavyTypedObject Is Nothing Then
                result = False
            Else
                result = Equals(heavyTypedObject)
            End If

            Return result
        End Function

        Public Overrides Function GetHashCode() As Integer
            Dim result As Integer
            For i As Integer = 0 To Items.Count - 1
                result = result Xor Items(i).GetHashCode
            Next
            Return result
        End Function

        Public Shared Function CheckRangeOverlap(range1 As IRange, range2 As IRange) As Boolean
            Contracts.Contract.Requires(Of ArgumentNullException)(range1 IsNot Nothing, "range1")
            Contracts.Contract.Requires(Of ArgumentNullException)(range2 IsNot Nothing, "range2")

            ' ReSharper disable CompareOfFloatsByEqualityOperator
            Dim result As Boolean

            If Range.CheckRangeIncluded(range1, range2) OrElse Range.CheckRangeIncluded(range2, range1) Then
                result = True
            Else
                ' LowEnd
                If Range.CheckValueInRange(range1.LowEndValue, range2) Then
                    If range1.LowEndValue = range2.LowEndValue Then
                        If range1.IsLowEndIncluded AndAlso range2.IsLowEndIncluded Then
                            result = True
                        End If
                    ElseIf range1.LowEndValue = range2.HighEndValue Then
                        If range1.IsLowEndIncluded AndAlso range2.IsHighEndIncluded Then
                            result = True
                        End If
                    Else
                        result = True
                    End If
                End If

                ' HighEnd
                If Range.CheckValueInRange(range1.HighEndValue, range2) Then
                    If range1.HighEndValue = range2.LowEndValue Then
                        If range1.IsHighEndIncluded AndAlso range2.IsLowEndIncluded Then
                            result = True
                        End If
                    ElseIf range1.HighEndValue = range2.HighEndValue Then
                        If range1.IsHighEndIncluded AndAlso range2.IsHighEndIncluded Then
                            result = True
                        End If
                    Else
                        result = True
                    End If
                End If
            End If
            ' ReSharper restore CompareOfFloatsByEqualityOperator
            Return result
        End Function

    End Class
End Namespace