Option Strict On
Option Explicit On

Namespace Obj.Angle

    <TestClass()>
  Public Class OpSoustraction

        Private _a As MathLib.Angle
        Private _actual As MathLib.Angle
        Private _b As MathLib.Angle

        Private _expected As MathLib.Angle

        <TestInitialize()>
        Public Sub SetUp()

            _a = New MathLib.Angle
            _b = New MathLib.Angle

            _expected = New MathLib.Angle
            _actual = New MathLib.Angle

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _a = Nothing
            _b = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("-Angle")> _
        Public Sub Test_01()


            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-180, MathLib.UnitAngle.Degree)
            _a.SetValues(180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = -_a

            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
