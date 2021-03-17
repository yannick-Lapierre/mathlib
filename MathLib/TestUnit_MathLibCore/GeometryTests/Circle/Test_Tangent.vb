Option Strict On
Option Explicit On

Namespace Geometry.Circle

    <TestClass()>
  Public Class Tangent

        Dim _center As MathLib.Point
        Dim _TangentPt As MathLib.Point
        Dim _actual As MathLib.LineEquation
        Dim _expected As MathLib.LineEquation

        <TestInitialize()>
        Public Sub SetUp()

            _center = New MathLib.Point
            _TangentPt = New MathLib.Point
            _actual = New MathLib.LineEquation
            _expected = New MathLib.LineEquation

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _center = Nothing
            _TangentPt = Nothing
            _actual = Nothing
            _expected = Nothing

        End Sub

        <TestMethod()> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0, -1, 0, 2)
            _center.SetValues(0, 0)
            _TangentPt.SetValues(0, 2)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Circle.Tangent(_center, _TangentPt)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(1, 0, 0, -2)
            _center.SetValues(0, 0)
            _TangentPt.SetValues(2, 0)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Circle.Tangent(_center, _TangentPt)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(3 / 2, -1, 0, 9 / 2)
            _center.SetValues(2, 1)
            _TangentPt.SetValues(-1, 3)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Circle.Tangent(_center, _TangentPt)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(2 / 3, -1, 0, 13 / 3)
            _center.SetValues(2, -3)
            _TangentPt.SetValues(-2, 3)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Circle.Tangent(_center, _TangentPt)

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
