Option Strict On
Option Explicit On

Namespace Geometry.Line

    <TestClass()>
  Public Class GetEquation

        Dim _a As MathLib.Point
        Dim _actual As MathLib.LineEquation
        Dim _b As MathLib.Point
        Dim _expected As MathLib.LineEquation

        <TestInitialize()>
        Public Sub SetUp()

            _a = New MathLib.Point
            _b = New MathLib.Point
            _actual = New MathLib.LineEquation
            _expected = New MathLib.LineEquation

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _a = Nothing
            _b = Nothing
            _actual = Nothing
            _expected = Nothing

        End Sub

        <TestMethod()> <Description("A(1;1) B(2;2)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(1, -1, 0)
            _a.SetValues(1, 1)
            _b.SetValues(2, 2)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(1;3) B(3;1)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-2, -2, 8)
            _a.SetValues(1, 3)
            _b.SetValues(3, 1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(1;-1) B(4;-4)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-3, -3, 0)
            _a.SetValues(1, -1)
            _b.SetValues(4, -4)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(-1;-1) B(-4;-4)")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-3, 3, 0)
            _a.SetValues(-1, -1)
            _b.SetValues(-4, -4)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(-2;2) B(-6;6)")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(4, 4, 0)
            _a.SetValues(-2, 2)
            _b.SetValues(-6, 6)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(6.5;-1.5) B(-2.5;2)")> _
        Public Sub Test_06()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(3.5, 9, -9.25)
            _a.SetValues(6.5, -1.5)
            _b.SetValues(-2.5, 2)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("A(5;1) B(-2;-3)")> _
        Public Sub Test_07()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-4, 7, 13)
            _a.SetValues(5, 1)
            _b.SetValues(-2, -3)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Line.GetEquation(_a, _b)

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
