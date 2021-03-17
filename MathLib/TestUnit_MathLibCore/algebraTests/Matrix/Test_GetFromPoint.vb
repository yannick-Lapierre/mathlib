Namespace Algebra.Matrix

    <TestClass()>
    Public Class GetFromPoint

        ' "La detection du Nothing ne semble pas marcher."
        <TestMethod()>
        <Description("Parametre = Nothing"), ExpectedException(GetType(NullReferenceException))>
        <Ignore()>
        Public Sub Exception_01()

            Call MathLib.Algebra.Matrix.GetFromPoint(Nothing)

        End Sub

        <TestMethod()> <Description("Pt(1;2;3) = [(1)(2)(3)]")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            Pt = New MathLib.Point(1, 2, 3)

            Expected = New MathLib.Matrix(3, 1)
            Expected(0, 0) = 1
            Expected(1, 0) = 2
            Expected(2, 0) = 3
            '--------------------------------------------------------------------

            Actual = MathLib.Algebra.Matrix.GetFromPoint(Pt)

            Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub
        Private Actual As MathLib.Matrix
        Private Expected As MathLib.Matrix

        Private Msg As String
        Private Pt As MathLib.Point

    End Class

End Namespace
