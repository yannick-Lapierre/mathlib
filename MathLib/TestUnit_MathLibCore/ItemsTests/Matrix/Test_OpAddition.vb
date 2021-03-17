Namespace Obj.Matrix

    <TestClass()>
  Public Class OpAddition

        <TestMethod()> <Description("(0;0)(0;1) + (0;0)(1;0) = (0;0)(1;1)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            A = New MathLib.Matrix(2, 2)
            A(0, 0) = 0
            A(0, 1) = 0
            A(1, 0) = 0
            A(1, 1) = 1

            B = New MathLib.Matrix(2, 2)
            B(0, 0) = 0
            B(0, 1) = 0
            B(1, 0) = 1
            B(1, 1) = 0

            Expected = New MathLib.Matrix(2, 2)
            Expected(0, 0) = 0
            Expected(0, 1) = 0
            Expected(1, 0) = 1
            Expected(1, 1) = 1
            '--------------------------------------------------------------------

            Actual = A + B

            Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub
        Private A As MathLib.Matrix
        Private Actual As MathLib.Matrix
        Private B As MathLib.Matrix
        Private Expected As MathLib.Matrix

        Private Msg As String

    End Class

End Namespace
