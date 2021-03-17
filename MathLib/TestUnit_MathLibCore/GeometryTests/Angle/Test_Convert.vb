Option Strict On
Option Explicit On

Namespace Geometry.Angle

    <TestClass()>
    Public Class Convert

        Private _TestAngle As MathLib.Angle

        Private _actual As MathLib.Angle
        Private _expected As MathLib.Angle

        <TestInitialize()>
        Public Sub SetUp()

            _TestAngle = New MathLib.Angle

            _expected = New MathLib.Angle
            _actual = New MathLib.Angle

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _TestAngle = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()>
        <Description("Pi rad = 180°")>
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(180, MathLib.UnitAngle.Degree)
            _TestAngle.SetValues(MathLib.PI, MathLib.UnitAngle.Radian)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.Convert(_TestAngle, MathLib.UnitAngle.Degree)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()>
        <Description("Pi/2 rad = 90°")>
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(90, MathLib.UnitAngle.Degree)
            _TestAngle.SetValues(MathLib.PI / 2, MathLib.UnitAngle.Radian)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.Convert(_TestAngle, MathLib.UnitAngle.Degree)

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
