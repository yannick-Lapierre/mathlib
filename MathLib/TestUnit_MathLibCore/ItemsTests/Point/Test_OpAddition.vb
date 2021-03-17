Namespace Obj.Point

    <TestClass()>
  Public Class OpAddition

        <TestInitialize()>
        Public Sub SetUp()

            _a = New MathLib.Point
            _b = New MathLib.Point

            _expected = New MathLib.Point
            _actual = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _a = Nothing
            _b = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("(1;1) + (1;1) = (2;2)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(2, 2)
            _a.SetValues(1, 1)
            _b.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = _a + _b

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0;4) + (1;0) = (1;4)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(1, 4)
            _a.SetValues(0, 4)
            _b.SetValues(1, 0)
            '--------------------------------------------------------------------

            _actual = _a + _b

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0.034;0) + (0.001;0) = (0.035;0)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0.035, 0)
            _a.SetValues(0.034, 0)
            _b.SetValues(0.001, 0)
            '--------------------------------------------------------------------

            _actual = _a + _b

            Assert.AreEqual(_expected, _actual)

        End Sub

        Private _a As MathLib.Point
        Private _actual As MathLib.Point
        Private _b As MathLib.Point
        Private _expected As MathLib.Point

    End Class

End Namespace
