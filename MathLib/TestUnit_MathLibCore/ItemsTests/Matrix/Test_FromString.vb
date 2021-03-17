Namespace Obj.Matrix

    <TestClass()>
  Public Class FromString

        Private _actual As MathLib.Matrix
        Private _expected As MathLib.Matrix

        Private _str As String

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _actual = Nothing
            _expected = Nothing

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(1, 1)
            _expected(0, 0) = 1
            _str = "{[1]}"
            '--------------------------------------------------------------------
            _actual = New MathLib.Matrix(_str)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(1, 2)
            _expected(0, 0) = 1
            _expected(0, 1) = 2
            _str = "{[1;2]}"
            '--------------------------------------------------------------------
            _actual = New MathLib.Matrix(_str)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(1, 2)
            _expected(0, 0) = 1.2
            _expected(0, 1) = -2
            _str = "{[1,2;-2]}"
            '--------------------------------------------------------------------
            _actual = New MathLib.Matrix(_str)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Matrix(3, 2)
            _expected(0, 0) = 11
            _expected(0, 1) = 12
            _expected(1, 0) = 21
            _expected(1, 1) = 22
            _expected(2, 0) = 31
            _expected(2, 1) = 32
            _str = "{[11;12][21;22][31;32]}"
            '--------------------------------------------------------------------
            _actual = New MathLib.Matrix(_str)

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
