Namespace Obj.Matrix

    <TestClass()>
    Public Class RemoveRow

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
            _expected = New MathLib.Matrix("[4;5;6][7;8;9]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveRow(0)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("[1;2;3][7;8;9]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveRow(1)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix("[1;2;3][4;5;6]")
            _matrix = New MathLib.Matrix("[1;2;3][4;5;6][7;8;9]")
            '--------------------------------------------------------------------

            _matrix.RemoveRow(2)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(0, 3)
            _matrix = New MathLib.Matrix("[1;2;3]")
            '--------------------------------------------------------------------

            _matrix.RemoveRow(0)
            _actual = _matrix

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
