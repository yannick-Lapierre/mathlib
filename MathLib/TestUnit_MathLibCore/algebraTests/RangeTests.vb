Imports System.Globalization
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MathLib.Algebra

Namespace algebraTests

    <TestClass()> Public Class RangeTests

        <TestMethod()>
        Sub TestWhenHighEndEqualLowEndByChangingHighEndValue()
            Dim rangeItemRule As New Range With {.LowEndValue = 10, .HighEndValue = 20}
            rangeItemRule.HighEndValue = rangeItemRule.LowEndValue
        End Sub

        <TestMethod()>
        Sub TestWhenHighEndEqualLowEndByChangingLowEndValue()
            Dim rangeItemRule As New Range With {.LowEndValue = 10, .HighEndValue = 20}
            rangeItemRule.LowEndValue = rangeItemRule.HighEndValue
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentOutOfRangeException), "Changing HighEnd Value to a value lower than LowEnd value shall fire an exception.")>
        Sub TestWhenHighEndIsLowerThanLowEndByChangingHighEndValue()
            Dim rangeItemRule As New Range With {.LowEndValue = 10, .HighEndValue = 20}
            rangeItemRule.HighEndValue = 5
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentOutOfRangeException), "Changing LowEnd Value to a value higher than HighEnd value shall fire an exception.")>
        Sub TestWhenHighEndIsLowerThanLowEndByChangingLowEndValue()
            Dim rangeItemRule As New Range With {.LowEndValue = 10, .HighEndValue = 20}
            rangeItemRule.LowEndValue = 100
        End Sub

        <TestMethod()>
        Sub TestToString()
            Dim range As Range

            range = New Range With {.LowEndValue = Double.NegativeInfinity,
                                        .HighEndValue = Double.PositiveInfinity,
                                        .IsLowEndIncluded = True,
                                        .IsHighEndIncluded = True}
            Assert.AreEqual("[-Infinity,Infinity]", range.ToString)

            range = New Range With {.LowEndValue = -10.0R,
                                        .HighEndValue = 10.0R,
                                        .IsLowEndIncluded = True,
                                        .IsHighEndIncluded = True}
            Assert.AreEqual("[-10,10]", range.ToString)

            range = New Range With {.LowEndValue = -10.0R,
                                        .HighEndValue = 10.0R,
                                        .IsLowEndIncluded = False,
                                        .IsHighEndIncluded = False}
            Assert.AreEqual("]-10,10[", range.ToString)
        End Sub

#Region "CheckRangeIncluded"

        <TestMethod>
        Sub TestCheckRangeIncludedWithRangeIncluded()

            Dim range1 As Range
            Dim range2 As Range
            'arrange
            range1 = New Range With {.LowEndValue = 0.0R,
                                         .HighEndValue = 100.0R}
            range2 = New Range With {.LowEndValue = 40.0R,
                                         .HighEndValue = 50.0R}

            Assert.IsFalse(Range.CheckRangeIncluded(range1, range2),
                           String.Format(CultureInfo.InvariantCulture,
                                         "Shall be False if the the range {1} is Not included in the range {0}",
                                         range1,
                                         range2)
                            )

            Assert.IsTrue(Range.CheckRangeIncluded(range2, range1),
                          String.Format(CultureInfo.InvariantCulture,
                                        "Shall be True if the the range {1} is included in the range {0}",
                                         range2,
                                         range1)
                            )
        End Sub

        <TestMethod>
        Sub TestCheckRangeIncludedWithRangeOneValueRangeAtLowEnd()
            'arrange
            Dim range1 As New Range With {.LowEndValue = 0.0R,
                                              .HighEndValue = 100.0R,
                                              .IsLowEndIncluded = True}
            Dim range2 As New Range With {.LowEndValue = 0.0R,
                                              .HighEndValue = 100.0R,
                                              .IsLowEndIncluded = True}

            'act
            Assert.IsTrue(Range.CheckRangeIncluded(range1, range2),
                          String.Format(CultureInfo.InvariantCulture,
                                        "Shall be False if the the range {1} is not included in the range {0}",
                                         range1,
                                         range2)
                            )
            Assert.IsTrue(Range.CheckRangeIncluded(range2, range1),
                          String.Format(CultureInfo.InvariantCulture,
                                        "Shall be True if the the range {1} is included in the range {0}",
                                         range2,
                                         range1)
                            )
        End Sub

        <TestMethod>
        Sub TestCheckRangeIncludedWithRangeOneValueRangeAtHighEnd()
            'arrange
            Dim range1 As New Range With {.LowEndValue = 0.0R,
                                              .HighEndValue = 100.0R,
                                              .IsHighEndIncluded = True}
            Dim range2 As New Range With {.LowEndValue = 100.0R,
                                              .HighEndValue = 100.0R,
                                              .IsLowEndIncluded = False,
                                              .IsHighEndIncluded = True}

            'act
            Assert.IsFalse(Range.CheckRangeIncluded(range1, range2),
                          String.Format(CultureInfo.InvariantCulture,
                                        "Shall be False if the the range {1} is not included in the range {0}",
                                         range1,
                                         range2)
                            )
            Assert.IsTrue(Range.CheckRangeIncluded(range2, range1),
                          String.Format(CultureInfo.InvariantCulture,
                                        "Shall be True if the the range {1} is included in the range {0}",
                                         range2,
                                         range1)
                            )
        End Sub

#End Region

#Region "= operator"

        <TestMethod()>
        Public Sub TestEqualOperatorWithNullObject()
            Dim range As New Range
            'act
            Assert.IsFalse(range.Equals(Nothing), "Test equal with Nothing shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithSameObject()
            Dim range As New Range
            'act
            ' ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(range = range, "Test equal with object it self shall return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithSimilarObject()
            Dim range As New Range
            Dim rangeReference As New Range
            'act
            Assert.IsTrue(range = rangeReference, "Test equal with similar object return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithDifferentLowEndValue()
            Dim range As New Range With {.LowEndValue = 10.0R}
            Dim rangeReference As New Range With {.LowEndValue = 20.0R}
            'act
            Assert.IsFalse(range = rangeReference, "If LowEndValue are not the same, 2 ranges are not =.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithDifferentHighEndValue()
            Dim range As New Range With {.HighEndValue = 10.0R}
            Dim rangeReference As New Range With {.HighEndValue = 20.0R}
            'act
            Assert.IsFalse(range = rangeReference, "If HighEndValue are not the same, 2 ranges are not =.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithDifferentIsLowEndValue()
            Dim range As New Range With {.IsLowEndIncluded = False}
            Dim rangeReference As New Range With {.IsLowEndIncluded = True}
            'act
            Assert.IsFalse(range = rangeReference, "If IsLowEndIncluded are not the same, 2 ranges are not =.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualOperatorWithDifferentIsHighEndValue()
            Dim range As New Range With {.IsHighEndIncluded = False}
            Dim rangeReference As New Range With {.IsHighEndIncluded = True}
            'act
            Assert.IsFalse(range = rangeReference, "If IsHighEndIncluded are not the same, 2 ranges are not =.")
        End Sub
#End Region

#Region "Equality / differences tests"

        <TestMethod()>
        Public Sub TestEqualityWithSameObject()
            Dim range As New Range
            'act
            AssertEquality(range, range, True, True, False)
        End Sub

        <TestMethod()>
        Public Sub TestEqualityWithSimilarObject()
            Dim range As New Range
            Dim rangeReference As New Range
            'act
            AssertEquality(range, rangeReference, True, True, False)
        End Sub

        <TestMethod()>
        Public Sub TestEqualityWithDifferentLowEndValue()
            Dim range As New Range With {.LowEndValue = 10.0R}
            Dim rangeReference As New Range With {.LowEndValue = 20.0R}
            'act
            AssertEquality(range, rangeReference, False, False, True)
        End Sub

        <TestMethod()>
        Public Sub TestEqualityWithDifferentHighEndValue()
            Dim range As New Range With {.HighEndValue = 10.0R}
            Dim rangeReference As New Range With {.HighEndValue = 20.0R}
            'act
            AssertEquality(range, rangeReference, False, False, True)
        End Sub

        <TestMethod()>
        Public Sub TestEqualityWithDifferentIsLowEndValue()
            Dim range As New Range With {.IsLowEndIncluded = False}
            Dim rangeReference As New Range With {.IsLowEndIncluded = True}
            'act
            AssertEquality(range, rangeReference, False, False, True)
        End Sub

        <TestMethod()>
        Public Sub TestEqualityWithDifferentIsHighEndValue()
            Dim range As New Range With {.IsHighEndIncluded = False}
            Dim rangeReference As New Range With {.IsHighEndIncluded = True}
            'act
            AssertEquality(range, rangeReference, False, False, True)
        End Sub

        Private Sub AssertEquality(range1 As Range, range2 As Range, equalsExpectedResult As Boolean, equalOperatorExpectedResult As Boolean, differentOperatorExpectedResult As Boolean)

            'test equals
            If equalsExpectedResult = True Then
                Assert.IsTrue(range1.Equals(range2), "Test equal with similar objects return True. " & Get2RangeString(range1, range2))
            Else
                Assert.IsFalse(range1.Equals(range2), "Test equal with diffrent objects shall return False. " & Get2RangeString(range1, range2))
            End If

            'test =
            If equalOperatorExpectedResult = True Then
                Assert.IsTrue(range1 = range2, "Test '=' operator with similar objects return True. " & Get2RangeString(range1, range2))
            Else
                Assert.IsFalse(range1 = range2, "Test '=' operator with diffrent objects shall return False. " & Get2RangeString(range1, range2))
            End If

            'test <>
            If differentOperatorExpectedResult = True Then
                Assert.IsTrue(range1 <> range2, "Test '<>' operator with diffrent objects return True. " & Get2RangeString(range1, range2))
            Else
                Assert.IsFalse(range1 <> range2, "Test '<>' operator with similar objects shall return False. " & Get2RangeString(range1, range2))
            End If

        End Sub

        Private Shared Function Get2RangeString(range1 As Range, range2 As Range) As String
            Return String.Format(Globalization.CultureInfo.InvariantCulture,
                                 "Range1 :'{0}' Range2'{1}'",
                                 range1.ToString,
                                 range2.ToString)

        End Function

#End Region



#Region "Equals"

        <TestMethod()>
        Public Sub TestEqualsWithNullObject()
            Dim range As New Range
            'act
            Assert.IsFalse(range.Equals(Nothing), "Test equal with Nothing shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithNonRangeObject()
            Dim range As New Range
            'act
            ' ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(range.Equals("String Object"), "Test equal with an other object type shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSameObject()
            Dim range As New Range
            'act
            Assert.IsTrue(range.Equals(range), "Test equal with object it self shall return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSimilarObject()
            Dim range As New Range
            Dim rangeReference As New Range
            'act
            Assert.IsTrue(range.Equals(rangeReference), "Test equal with similar object return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentLowEndValue()
            Dim range As New Range With {.LowEndValue = 10.0R}
            Dim rangeReference As New Range With {.LowEndValue = 20.0R}
            'act
            Assert.IsFalse(range.Equals(rangeReference), "if LowEnd are not the same, 2 ranges are not equals.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentHighEndValue()
            Dim range As New Range With {.HighEndValue = 10.0R}
            Dim rangeReference As New Range With {.HighEndValue = 20.0R}
            'act
            Assert.IsFalse(range.Equals(rangeReference), "if HighEnd are not the same, 2 ranges are not equals.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentIsLowEndValue()
            Dim range As New Range With {.IsLowEndIncluded = False}
            Dim rangeReference As New Range With {.IsLowEndIncluded = True}
            'act
            Assert.IsFalse(range.Equals(rangeReference), "if IsLowEnd are not the same, 2 ranges are not equals.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithDifferentIsHighEndValue()
            Dim range As New Range With {.IsHighEndIncluded = False}
            Dim rangeReference As New Range With {.IsHighEndIncluded = True}
            'act
            Assert.IsFalse(range.Equals(rangeReference), "if IsHighEnd are not the same, 2 ranges are not equals.")
        End Sub
#End Region


    End Class
End Namespace