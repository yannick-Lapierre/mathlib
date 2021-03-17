Namespace Obj.Matrix

    <TestClass()>
  Public Class OpMultiplication

        <TestMethod()> <Description("Test avec une Matrice non compatible"), ExpectedException(GetType(MathLib.Exception))> _
        Public Sub Exception_01()

            '-- Initialisation des valeurs --------------------------------------
            A = New MathLib.Matrix(2, 2)
            B = New MathLib.Matrix(1, 2)
            '--------------------------------------------------------------------

            Actual = A * B

        End Sub

        <TestMethod()> <Description("(1;2)(3;4) * (1;2)(3;4) = (7;10)(15;22)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            A = New MathLib.Matrix(2, 2)
            A(0, 0) = 1
            A(0, 1) = 2
            A(1, 0) = 3
            A(1, 1) = 4

            B = New MathLib.Matrix(2, 2)
            B(0, 0) = 1
            B(0, 1) = 2
            B(1, 0) = 3
            B(1, 1) = 4

            Expected = New MathLib.Matrix(2, 2)
            Expected(0, 0) = 7
            Expected(0, 1) = 10
            Expected(1, 0) = 15
            Expected(1, 1) = 22
            '--------------------------------------------------------------------

            Actual = A * B

            Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub

        <TestMethod()> <Description("(1;2)(3;4) * (1)(2) = (17)(39)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            A = New MathLib.Matrix(2, 2)
            A(0, 0) = 1
            A(0, 1) = 2
            A(1, 0) = 3
            A(1, 1) = 4

            B = New MathLib.Matrix(2, 1)
            B(0, 0) = 5
            B(1, 0) = 6

            Expected = New MathLib.Matrix(2, 1)
            Expected(0, 0) = 17
            Expected(1, 0) = 39
            '--------------------------------------------------------------------

            Actual = A * B

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
