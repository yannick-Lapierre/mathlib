Namespace Algebra.Matrix

    <TestClass()>
  Public Class Cramer2

        Private _coefMatrix As MathLib.Matrix
        Private _valueMatrix As MathLib.Matrix
        Private _actual As MathLib.Matrix
        Private _expected As MathLib.Matrix

        '<Test(),<Description("Parametre = Nothing"), ExpectedException(GetType(NullReferenceException))> _
        'Public Sub Exception_01()

        '  Call MathLib.Algebra.Matrix.Transpose(Nothing)

        'End Sub

        <TestMethod()> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("{[1;2]}")
            _coefMatrix = New MathLib.Matrix("{[1;1][2;1]}")
            _valueMatrix = New MathLib.Matrix("{[3][4]}")
            '--------------------------------------------------------------------

            _actual = MathLib.Algebra.Matrix.Cramer(_coefMatrix, _valueMatrix)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(0, 0)
            _coefMatrix = New MathLib.Matrix("{[1;1][1;1]}")
            _valueMatrix = New MathLib.Matrix("{[4][5]}")
            '--------------------------------------------------------------------

            _actual = MathLib.Algebra.Matrix.Cramer(_coefMatrix, _valueMatrix)
            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
