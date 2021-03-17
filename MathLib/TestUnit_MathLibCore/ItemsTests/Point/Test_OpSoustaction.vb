Option Strict On
Option Explicit On

Namespace Obj.Point

    <TestClass()>
  Public Class OpSoustraction

        Private _a As MathLib.Point
        Private _actual As MathLib.Point
        Private _b As MathLib.Point

        Private _expected As MathLib.Point

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

        <TestMethod()> <Description("(1;1) - (1;1) = (0;0)")> _
        Public Sub Test_01()


            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0, 0)
            _a.SetValues(1, 1)
            _b.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = _a - _b

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0.035;0) - (0.034;0) = (0.001;0)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0.001, 0)
            _a.SetValues(0.035, 0)
            _b.SetValues(0.034, 0)
            '--------------------------------------------------------------------

            _actual = _a - _b

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
