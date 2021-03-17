Namespace Obj.Matrix

    <TestClass()>
  Public Class RemoveCol

        Private _actual As MathLib.Matrix
        Private _expected As MathLib.Matrix
        Private _matrix As MathLib.Matrix

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _actual = Nothing
            _expected = Nothing
            _matrix = Nothing

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("[2;3][5;6][8;9]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveCol(0)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("[1;3][4;6][7;9]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveCol(1)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("[1;2][4;5][7;8]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveCol(2)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(3, 0)
            _matrix = New MathLib.Matrix("[1][2][3]")
            '--------------------------------------------------------------------

            _matrix.RemoveCol(0)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace