Namespace Algebra.Matrix

    <TestClass()>
  Public Class Transpose

        <TestMethod()> <Description("Parametre = Nothing"), ExpectedException(GetType(NullReferenceException))> _
        Public Sub Exception_01()

            Call MathLib.Algebra.Matrix.Transpose(Nothing)

        End Sub

        <TestMethod()> <Description("[(1;3)(9;-2)(5;0)] = [(1;9;5)(3;-2;0)]")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            A = New MathLib.Matrix(3, 2)
            A(0, 0) = 1
            A(0, 1) = 3
            A(1, 0) = 9
            A(1, 1) = -2
            A(2, 0) = 5
            A(2, 1) = 0

            Expected = New MathLib.Matrix(2, 3)
            Expected(0, 0) = 1
            Expected(0, 1) = 9
            Expected(0, 2) = 5
            Expected(1, 0) = 3
            Expected(1, 1) = -2
            Expected(1, 2) = 0
            '--------------------------------------------------------------------

            Actual = MathLib.Algebra.Matrix.Transpose(A)

            Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub
        Private A As MathLib.Matrix
        Private Actual As MathLib.Matrix
        Private Expected As MathLib.Matrix

        Private Msg As String

    End Class

End Namespace
