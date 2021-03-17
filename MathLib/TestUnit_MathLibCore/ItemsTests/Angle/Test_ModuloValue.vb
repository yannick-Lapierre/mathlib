Namespace Obj.Angle

    <TestClass()>
  Public Class ModuloValue

        <TestInitialize()>
        Public Sub SetUp()

            _angle = New MathLib.Angle
            _expected = Single.NaN
            _actual = Single.NaN

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _angle = Nothing

        End Sub

        <TestMethod()> <Description("50° -> 50")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 50
            _angle.SetValues(50, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = _angle.ModuloValue

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As Single

        Private _angle As MathLib.Angle
        Private _expected As Single

    End Class

End Namespace
