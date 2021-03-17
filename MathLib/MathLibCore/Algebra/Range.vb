Imports System.Globalization

Namespace Algebra

    Public Interface IRange
        Property LowEndValue As Double
        Property HighEndValue As Double
        Property IsLowEndIncluded As Boolean
        Property IsHighEndIncluded As Boolean
    End Interface

    Public Class Range
        Implements IRange
        Private _lowEndValue As Double = Double.NegativeInfinity
        Private _highEndValue As Double = Double.PositiveInfinity

        Public Property IsLowEndIncluded As Boolean Implements IRange.IsLowEndIncluded
        Public Property IsHighEndIncluded As Boolean Implements IRange.IsHighEndIncluded

        Public Property LowEndValue As Double Implements IRange.LowEndValue
            Get
                Return _lowEndValue
            End Get
            Set(value As Double)
                If value > HighEndValue Then
                    Throw New ArgumentOutOfRangeException("value", value, String.Format(CultureInfo.InvariantCulture,
                                                                                        "Should be not he higher than HighEnd."))
                End If
                _lowEndValue = value
            End Set
        End Property

        Public Property HighEndValue As Double Implements IRange.HighEndValue
            Get
                Return _highEndValue
            End Get
            Set(value As Double)
                If value < LowEndValue Then
                    Throw New ArgumentOutOfRangeException("value", value, String.Format(CultureInfo.InvariantCulture,
                                                                                        "Should be not he lower than LowEnd."))
                End If
                _highEndValue = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return ToString(LowEndValue, HighEndValue, IsLowEndIncluded, IsHighEndIncluded)
        End Function

        Public Overloads Shared Function ToString(lowEnd As Double, highEnd As Double, includeLowEnd As Boolean, includeHighEnd As Boolean) As String
            Dim result As String

            result = String.Format(CultureInfo.InvariantCulture,
                                   "{0}{1},{2}{3}",
                                   GetLowEndBracket(includeLowEnd),
                                   lowEnd,
                                   highEnd,
                                   GetHighEndBracket(includeHighEnd))

            Return result
        End Function

        Public Shared Function CheckValueInRange(testedValue As Double, range As IRange) As Boolean
            Contracts.Contract.Requires(Of ArgumentNullException)(range IsNot Nothing, "range")

            Return CheckValueInRange(testedValue, range.LowEndValue, range.HighEndValue, range.IsLowEndIncluded, range.IsHighEndIncluded)
        End Function

        Private Shared Function CheckValueInRange(testedValue As Double, lowValue As Double, highValue As Double, Optional includeLowValue As Boolean = True, Optional includeHighValue As Boolean = True) As Boolean
            ' ReSharper disable CompareOfFloatsByEqualityOperator
            Dim result As Boolean = True

            If testedValue < lowValue Then
                result = False
            ElseIf (Not includeLowValue) AndAlso (testedValue = lowValue) Then
                result = False
            ElseIf (testedValue > highValue) Then
                result = False
            ElseIf (Not includeHighValue) AndAlso (testedValue = highValue) Then
                result = False
            End If

            Return result
            ' ReSharper restore CompareOfFloatsByEqualityOperator
        End Function

        Public Shared Function CheckRangeIncluded(testedIncludingRange As IRange, range As IRange) As Boolean
            Contracts.Contract.Requires(Of ArgumentNullException)(testedIncludingRange IsNot Nothing, "testedIncludingRange")
            Contracts.Contract.Requires(Of ArgumentNullException)(range IsNot Nothing, "range")

            Return (AreRangeEquals(testedIncludingRange, range)
                    ) OrElse ((CheckValueInRange(testedIncludingRange.LowEndValue,
                                       range.LowEndValue,
                                       range.HighEndValue, testedIncludingRange.IsLowEndIncluded OrElse range.IsLowEndIncluded,
                                       testedIncludingRange.IsLowEndIncluded OrElse range.IsHighEndIncluded)
                              ) AndAlso (
                              CheckValueInRange(testedIncludingRange.HighEndValue,
                                                range.LowEndValue,
                                                range.HighEndValue, testedIncludingRange.IsHighEndIncluded OrElse range.IsLowEndIncluded,
                                                testedIncludingRange.IsHighEndIncluded OrElse range.IsHighEndIncluded)
                              )
                    )
        End Function

        Private Shared Function GetHighEndBracket(isIncluded As Boolean) As Char
            Dim result As Char

            If isIncluded Then
                result = "]"c
            Else
                result = "["c
            End If

            Return result
        End Function

        Private Shared Function GetLowEndBracket(isIncluded As Boolean) As Char
            Dim result As Char

            If isIncluded Then
                result = "["c
            Else
                result = "]"c
            End If

            Return result
        End Function


        Public Shared Operator =(range1 As Range, range2 As Range) As Boolean
            If range1 Is Nothing Then
                Throw New ArgumentNullException("range1")
            End If
            If range2 Is Nothing Then
                Throw New ArgumentNullException("range2")
            End If
            Return AreRangeEquals(range1, range2)
        End Operator
        Public Shared Operator <>(range1 As Range, range2 As Range) As Boolean
            If range1 Is Nothing Then
                Throw New ArgumentNullException("range1")
            End If
            If range2 Is Nothing Then
                Throw New ArgumentNullException("range2")
            End If
            Return Not AreRangeEquals(range1, range2)
        End Operator

        Public Shared Function AreRangeEquals(range1 As IRange, range2 As IRange) As Boolean
            If range1 Is Nothing Then
                Throw New ArgumentNullException("range1")
            End If
            If range2 Is Nothing Then
                Throw New ArgumentNullException("range2")
            End If

            ' ReSharper disable CompareOfFloatsByEqualityOperator
            Return (range1.LowEndValue = range2.LowEndValue) AndAlso
                (range1.HighEndValue = range2.HighEndValue) AndAlso
                (range1.IsLowEndIncluded = range2.IsLowEndIncluded) AndAlso
                (range1.IsHighEndIncluded = range2.IsHighEndIncluded)
            ' ReSharper restore CompareOfFloatsByEqualityOperator
        End Function



        Public Overloads Function Equals(ByVal obj As IRange) As Boolean
            Return obj IsNot Nothing AndAlso AreRangeEquals(Me, obj)
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            Dim result As Boolean
            Dim heavyTypedObject As IRange = TryCast(obj, IRange)

            If (heavyTypedObject Is Nothing) Then
                result = False
            Else

                result = Equals(heavyTypedObject)
            End If

            Return result
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return LowEndValue.GetHashCode Xor
                HighEndValue.GetHashCode Xor
                IsLowEndIncluded.GetHashCode Xor
                IsHighEndIncluded.GetHashCode
        End Function
    End Class
End Namespace