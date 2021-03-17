Namespace Obj.Matrix

    <TestClass()>
  Public Class Det

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
            _expected = -5
            _matrix = New MathLib.Matrix("{[2;3][1;-1]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Det
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -17
            _matrix = New MathLib.Matrix("{[1;3][5;-2]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Det
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0
            _matrix = New MathLib.Matrix("{[2;1][4;2]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Det
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 11
            _matrix = New MathLib.Matrix("{[4;-3][1;2]}")
            '--------------------------------------------------------------------

            _actual = _matrix.Det
            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class


End Namespace
