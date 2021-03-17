Namespace Obj.Matrix

    <TestClass()>
  Public Class ToString

        Private A As MathLib.Matrix
        Private Actual As String
        Private Expected As String

        <TestMethod()> <Description("{[1;2][3;4]}")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            Expected = "{[1;2][3;4]}"

            A = New MathLib.Matrix(2, 2)
            A(0, 0) = 1
            A(0, 1) = 2
            A(1, 0) = 3
            A(1, 1) = 4
            '--------------------------------------------------------------------

            Actual = A.ToString

            Assert.AreEqual(Expected, Actual)

        End Sub

    End Class

End Namespace
