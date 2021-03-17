Imports MathLib.Algebra
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace algebraTests
    <TestClass()>
    Public Class RangeCheckResultTests

#Region "Equals"

        <TestMethod()>
        Public Sub TestEqualsWithNullObject()
            Dim checkResult As New RangeCheckResult(New Range, New Range, RangeCheckResultType.Overlap)
            'act
            Assert.IsFalse(checkResult.Equals(Nothing), "Test equal with Nothing shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithNonRangeObject()
            Dim checkResult As New RangeCheckResult(New Range, New Range, RangeCheckResultType.Overlap)
            'act
            ' ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(checkResult.Equals("String Object"), "Test equal with an other object type shall return False.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSameObject()
            Dim checkResult As New RangeCheckResult(New Range, New Range, RangeCheckResultType.Overlap)
            'act
            Assert.IsTrue(checkResult.Equals(checkResult), "Test equal with object it self shall return True.")
        End Sub

        <TestMethod()>
        Public Sub TestEqualsWithSimilarObject()
            Dim checkResult As New RangeCheckResult(New Range, New Range, RangeCheckResultType.Overlap)
            Dim checkResultReference As New RangeCheckResult(New Range, New Range, RangeCheckResultType.Overlap)
            'act
            Assert.IsTrue(checkResult.Equals(checkResultReference), "Test equal with similar object return True.")
        End Sub

#End Region

    End Class
End Namespace