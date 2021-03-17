Option Strict On
Option Explicit On

Namespace Common.Vector

    <TestClass()>
  Public Class RotateAroundBase

        Private _actual As MathLib.Vector
        Private _expected As MathLib.Vector
        Private _sourceVector As MathLib.Vector

        Private _xAxeAngle As MathLib.Angle
        Private _yAxeAngle As MathLib.Angle
        Private _zAxeAngle As MathLib.Angle

        <TestInitialize()>
        Public Sub SetUp()

            _sourceVector = New MathLib.Vector
            _expected = New MathLib.Vector
            _actual = New MathLib.Vector

            _xAxeAngle = New MathLib.Angle
            _yAxeAngle = New MathLib.Angle
            _zAxeAngle = New MathLib.Angle

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _sourceVector = Nothing
            _expected = Nothing
            _actual = Nothing

            _xAxeAngle = Nothing
            _yAxeAngle = Nothing
            _zAxeAngle = Nothing

        End Sub

        <TestMethod()> <Description("(0;0;0)(1;0;0) Rotat° 90° sur axe Z = (0;0;0)(0;1;0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Vector(New MathLib.Point(0, 1))

            _zAxeAngle.SetValues(90, MathLib.UnitAngle.Degree)
            _sourceVector.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.RotateAroundBase(_sourceVector, New MathLib.Rotation(_zAxeAngle))

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(1;0;0)(2;0;0) Rotat° 90° sur axe Z = (1;0;0)(1;1;0)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Vector(New MathLib.Point(1, 0), New MathLib.Point(1, 1))

            _zAxeAngle.SetValues(90, MathLib.UnitAngle.Degree)
            _sourceVector.SetValues(New MathLib.Point(1, 0), New MathLib.Point(2, 0))
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.RotateAroundBase(_sourceVector, New MathLib.Rotation(_zAxeAngle))

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0;0;0)(1;0;0) Rotat° -90° sur axe Z = (0;0;0)(0;-1;0)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = New MathLib.Vector(New MathLib.Point(0, 0), New MathLib.Point(0, -1))

            _zAxeAngle.SetValues(-90, MathLib.UnitAngle.Degree)
            _sourceVector.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.RotateAroundBase(_sourceVector, New MathLib.Rotation(_zAxeAngle))

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
