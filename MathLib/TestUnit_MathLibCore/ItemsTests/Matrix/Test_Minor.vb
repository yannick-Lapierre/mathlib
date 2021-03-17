Namespace Obj.Matrix

    <TestClass()>
  Public Class Minor

        Private _actual As Double
        Private _expected As Double

        Private _matrix As MathLib.Matrix

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _matrix = Nothing

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -9
            _matrix = New MathLib.Matrix("{[2;1;4][5;2;3][8;7;3]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Minor(0, 1)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -26
            _matrix = New MathLib.Matrix("{[2;1;4][5;2;3][8;7;3]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Minor(1, 1)
            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace