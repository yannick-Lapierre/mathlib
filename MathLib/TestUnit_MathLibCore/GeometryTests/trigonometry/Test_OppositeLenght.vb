Option Strict On
Option Explicit On

Namespace Geometry.Trigonometry

    <TestClass()>
  Public Class OppositeLenght

        Private _angle As MathLib.Angle
        Private _hypothenus As Double

        Private _expected As Double
        Private _actual As Double

        <TestInitialize()>
        Public Sub SetUp()

            _angle = New MathLib.Angle

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _angle = Nothing

        End Sub

        <TestMethod()> <Description("Hypo = 1; Angle = 0°")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0
            _hypothenus = 1
            _angle.SetValues(0, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.OppositeLenght(_hypothenus, _angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Hypo = 1; Angle = 90°")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1
            _hypothenus = 1
            _angle.SetValues(90, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.OppositeLenght(_hypothenus, _angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Hypo = 1; Angle = 180°")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0
            _hypothenus = 1
            _angle.SetValues(180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.OppositeLenght(_hypothenus, _angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Hypo = 1; Angle = 270°")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -1
            _hypothenus = 1
            _angle.SetValues(270, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.OppositeLenght(_hypothenus, _angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Hypo = 1; Angle = 360°")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0
            _hypothenus = 1
            _angle.SetValues(360, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.OppositeLenght(_hypothenus, _angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
