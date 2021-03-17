Imports System.Collections.Generic
Imports System.Globalization
Imports MathLib.Algebra
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace algebraTests
    <TestClass()>
    Public Class RangeCollectionTests

#Region "AddRange"

        <TestMethod()>
        <ExpectedException(GetType(ArgumentNullException))>
        Public Sub TestAddRangeWithNullCollection()
            Dim ranges As New RangeCollection
            'act
            ranges.AddRange(Nothing)
        End Sub

        <TestMethod()>
        Public Sub TestAddRangeWithValidList()
            Dim ranges As New RangeCollection
            Dim rangesToAdd As New List(Of Range)

            'arrange
            rangesToAdd.Add(New Range With {.LowEndValue = 10})
            rangesToAdd.Add(New Range With {.LowEndValue = 100})

            'act
            ranges.AddRange(rangesToAdd)
            Assert.AreEqual(rangesToAdd.Count, ranges.Count, "all item shall be added to the collection.")
            For i As Integer = 0 To rangesToAdd.Count - 1
                Assert.AreEqual(rangesToAdd(i), ranges(i), "each item shall have the same value as the original.")
            Next
        End Sub

#End Region

#Region "Gap"

        <TestMethod()>
        Sub TestGapWithEmptyCollection()
            Dim ranges As New RangeCollection
            'act
            Assert.IsFalse(ranges.HasGap, "If the collection contain 0 item it shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithNoRangeInCollection()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range)

            'act
            Assert.IsFalse(ranges.HasOverlapping, "If the collection contain 1 Range item it shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestGapWithGap()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)

            'arrange
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 5.0R})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = 20.0R})

            expectedErrorList.Add(New CheckErrorInfo(0, 1))

            'act
            Assert.IsTrue(ranges.HasGap,
                          "If the range definition contain a gap between range, it shall return True. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Gap, expectedErrorList)
        End Sub

        <TestMethod()>
        Public Sub TestGapWithTwoGaps()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)

            'arrange
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 5.0R})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = 20.0R})
            ranges.Add(New Range With {.LowEndValue = 30.0R,
                                           .HighEndValue = 50.0R})

            expectedErrorList.Add(New CheckErrorInfo(0, 1))
            expectedErrorList.Add(New CheckErrorInfo(1, 2))

            'act
            Assert.IsTrue(ranges.HasGap,
                          "If the range definition contain a gap between range, it shall return True. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Gap, expectedErrorList)
        End Sub

        <TestMethod()>
        Public Sub TestGapWithGapOnOneExcludedValue()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)

            'arrange
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 5.0R,
                                           .IsHighEndIncluded = False})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = 20.0R,
                                           .IsLowEndIncluded = False})

            expectedErrorList.Add(New CheckErrorInfo(0, 1))

            'act
            Assert.IsTrue(ranges.HasGap,
                          "If the range definition contain a gap between range, it shall return False. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Gap, expectedErrorList)
        End Sub

        <TestMethod()>
        Public Sub TestGapWithoutGap()
            Dim ranges As New RangeCollection
            Dim rangeCheckResults As RangeCheckResultCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 100.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = 200.0R,
                                           .IsLowEndIncluded = True})
            'act
            Assert.IsFalse(ranges.HasGap,
                           "If the range definition contain a gap between range, it shall return True. " & GetRangeDescription(ranges))
            rangeCheckResults = ranges.CheckGap
            CollectionAssert.AreEqual(New RangeCheckResultCollection, rangeCheckResults, "If the range definition don't contains gap, it shall return an empty result collection. " & GetRangeDescription(ranges))

        End Sub

#End Region

#Region "Overlapping"

        <TestMethod()>
        Public Sub TestOverlappingWithEmptyCollection()
            Dim ranges As New RangeCollection

            'act
            Assert.IsFalse(ranges.HasOverlapping, "If the collection contain 0 item it shall return False.")

        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithOneRangeInCollection()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range)

            'act
            Assert.IsFalse(ranges.HasOverlapping, "If the collection contain 1 Range item it shall return False. " & GetRangeDescription(ranges))
        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithNoOverlapping()
            Dim ranges As New RangeCollection
            Dim rangeCheckResults As RangeCheckResultCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                           .HighEndValue = 0.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = Double.PositiveInfinity})

            'act
            Assert.IsFalse(ranges.HasOverlapping,
                           "If the range definition don't contains overlapping, it shall return False.")
            rangeCheckResults = ranges.CheckOverlapping
            CollectionAssert.AreEqual(New RangeCheckResultCollection, rangeCheckResults, "If the range definition don't contains overlap, it shall return an empty result collection. " & GetRangeDescription(ranges))

        End Sub

        ''' <summary>
        '''     Test the Overlapping when the HighEnd value a a rang item is the same as the LowEnd of another range item and both of then include the value.
        '''     That make the value present on 2 Range items.
        ''' </summary>
        ''' <remarks></remarks>
        <TestMethod()>
        Public Sub TestOverlappingWithOverlappingOnSingleValue()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)

            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                           .HighEndValue = 0.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 10.0R,
                                           .IsLowEndIncluded = True,
                                          .IsHighEndIncluded = False})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = Double.PositiveInfinity,
                                           .IsLowEndIncluded = True})
            expectedErrorList.Add(New CheckErrorInfo(0, 1))

            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a value present on 2 different ranges items, it shall return True. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Overlap, expectedErrorList)
        End Sub

        ''' <summary>
        '''     Test the Overlapping when the HighEnd value a a rang item is the same as the LowEnd of another range item and both of then include the value.
        '''     That make the value present on 2 Range items.
        ''' </summary>
        ''' <remarks></remarks>
        <TestMethod()>
        Public Sub TestOverlappingWithOverlappingOnSingleValue2()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)
            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                           .HighEndValue = 0.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 10.0R,
                                           .IsLowEndIncluded = True,
                                          .IsHighEndIncluded = False})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = Double.PositiveInfinity,
                                           .IsLowEndIncluded = True})

            expectedErrorList.Add(New CheckErrorInfo(0, 1))

            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a value present on 2 different ranges items, it shall return True. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Overlap, expectedErrorList)
        End Sub

        ''' <summary>
        '''     Test the Overlapping when the HighEnd value a a rang item is the same as the LowEnd of another range item and both of then include the value.
        '''     That make the value present on 2 Range items.
        ''' </summary>
        ''' <remarks></remarks>
        <TestMethod()>
        Public Sub TestOverlappingWithOverlappingOnSingleValue3()
            Dim ranges As New RangeCollection
            Dim expectedErrorList As New List(Of CheckErrorInfo)
            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                       .HighEndValue = 100.0R,
                                       .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 100.0R,
                                       .HighEndValue = 100.0R,
                                       .IsLowEndIncluded = False,
                                       .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 100.0R,
                                       .HighEndValue = Double.PositiveInfinity,
                                       .IsLowEndIncluded = False,
                                       .IsHighEndIncluded = True})

            expectedErrorList.Add(New CheckErrorInfo(0, 1))

            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a value present on 2 different ranges items, it shall return True. " & GetRangeDescription(ranges))
            AssertCheckResultTest(ranges, RangeCheckResultType.Overlap, expectedErrorList)
        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithOverlapping()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                           .HighEndValue = 10.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 5.0R,
                                           .HighEndValue = Double.PositiveInfinity,
                                           .IsLowEndIncluded = True})
            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a range of value present on 2 different range items, it shall return True. " & GetRangeDescription(ranges))
        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithMultiOverlapping()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = Double.NegativeInfinity,
                                           .HighEndValue = 10.0R,
                                           .IsHighEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 5.0R,
                                           .HighEndValue = 100.0R,
                                           .IsLowEndIncluded = True})
            ranges.Add(New Range With {.LowEndValue = 50.0R,
                                           .HighEndValue = Double.PositiveInfinity,
                                           .IsLowEndIncluded = True})
            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a range of value present on 2 different range items, it shall return True. " & GetRangeDescription(ranges))
        End Sub

        <TestMethod()>
        Public Sub TestOverlappingWithRangeIncludedInAnotherRange()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = 0.0R,
                                           .HighEndValue = 100.0R})
            ranges.Add(New Range With {.LowEndValue = 10.0R,
                                           .HighEndValue = 20.0R})
            'act
            Assert.IsTrue(ranges.HasOverlapping,
                          "If the range definition contain a range included in another range, it shall return True. " & GetRangeDescription(ranges))
        End Sub

#End Region

#Region "ToString"

        <TestMethod()>
        <ExpectedException(GetType(ArgumentNullException))>
        Public Sub TestToStringArguments()
            'act
            RangeCollection.ToString(Nothing)
        End Sub

        <TestMethod()>
        Public Sub TestToStringWithNoItemInList()
            Dim ranges As New RangeCollection

            'act
            Assert.AreEqual("", ranges.ToString)
        End Sub

        <TestMethod()>
        Public Sub TestToStringWithOneItem()
            Dim ranges As New RangeCollection

            'arrange
            ranges.Add(New Range With {.LowEndValue = 10,
                                           .HighEndValue = 100})

            'act
            Assert.AreEqual(ranges(0).ToString, ranges.ToString)
        End Sub

        <TestMethod()>
        Public Sub TestToStringWithTowItems()
            Dim ranges As New RangeCollection
            Dim expected As String

            'arrange
            ranges.Add(New Range With {.LowEndValue = 10,
                                           .HighEndValue = 100})
            ranges.Add(New Range With {.LowEndValue = 100,
                                           .HighEndValue = 200})
            'act
            expected = String.Format(CultureInfo.InvariantCulture,
                         "{0},{1}",
                         ranges(0).ToString,
                         ranges(1).ToString)
            Assert.AreEqual(expected, ranges.ToString)
        End Sub
#End Region

#Region "Equals"

        <TestMethod()>
        Public Sub TestEqualsWithNullObject()
            Dim ranges As New RangeCollection
            'act
            Assert.IsFalse(ranges.Equals(Nothing), "Test equal with Nothing shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithNonRangeObject()
            Dim ranges As New RangeCollection
            'act
            ' ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(ranges.Equals("String Object"), "Test equal with an other object type shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSameObject()
            Dim ranges As New RangeCollection
            'act
            Assert.IsTrue(ranges.Equals(ranges), "Test equal with object it self shall return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSimilarObject()
            Dim ranges As New RangeCollection
            Dim rangesReference As New RangeCollection
            'act
            Assert.IsTrue(ranges.Equals(rangesReference), "Test equal with similar object return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentItem()
            Dim ranges As New RangeCollection
            Dim rangesReference As New RangeCollection
            'arrange
            ranges.Add(New Range With {.LowEndValue = 10.0R})
            rangesReference.Add(New Range With {.LowEndValue = 50.0R})
            'act
            Assert.IsFalse(ranges.Equals(rangesReference), "if Item in the collection are not the same, 2 ranges Collections are not equals.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentItemCount()
            Dim ranges As New RangeCollection
            Dim rangesReference As New RangeCollection
            'arrange
            ranges.Add(New Range)
            ranges.Add(New Range)
            rangesReference.Add(New Range)
            'act
            Assert.IsFalse(ranges.Equals(rangesReference), "if the number of item in the collection are not the same, 2 ranges Collections are not equals.")
        End Sub

#End Region

        Private Class CheckErrorInfo
            Property Range1Index As Integer
            Property Range2Index As Integer
            Sub New(range1Index As Integer, range2Index As Integer)
                Me.Range1Index = range1Index
                Me.Range2Index = range2Index
            End Sub
        End Class

        Private Shared Sub AssertCheckResultTest(ranges As RangeCollection, checkType As RangeCheckResultType, errorList As IEnumerable(Of CheckErrorInfo))
            Dim rangeCheckResults As RangeCheckResultCollection
            Dim expectedRangeResult As New RangeCheckResultCollection
            Dim errorCount As Integer = errorList.Count
            'arrange
            For Each errorInfo As CheckErrorInfo In errorList
                expectedRangeResult.Add(New RangeCheckResult(ranges(errorInfo.Range1Index), ranges(errorInfo.Range2Index), checkType))
            Next

            'act
            Select Case checkType
                Case RangeCheckResultType.Overlap
                    rangeCheckResults = ranges.CheckOverlapping
                Case RangeCheckResultType.Gap
                    rangeCheckResults = ranges.CheckGap
                Case Else
                    Throw New InvalidOperationException
            End Select
            Assert.AreEqual(errorCount, rangeCheckResults.Count, String.Format(CultureInfo.InvariantCulture,
                                                                               "If we have {0} check failing we shall get {0} item in result collection",
                                                                               errorCount))
            CollectionAssert.AreEqual(expectedRangeResult, rangeCheckResults, "Result shall return information about range that don't pass the check")
        End Sub

        Private Shared Function GetRangeDescription(rangeCollection As RangeCollection) As String
            Return String.Format(CultureInfo.InvariantCulture,
                                 "Range Collection : '{0}'.",
                                 rangeCollection.ToString)
        End Function

    End Class
End Namespace