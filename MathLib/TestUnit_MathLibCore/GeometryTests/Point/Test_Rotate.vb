Namespace Geometry.Point

    <TestClass()>
  Public Class Rotate

        <TestInitialize()>
        Public Sub SetUp()

            _expected = New MathLib.Point
            _actual = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _expected = Nothing
            _actual = Nothing

        End Sub
        Private _actual As MathLib.Point

        Private _expected As MathLib.Point
        Private _rotation As MathLib.Rotation

#Region "Rotate(ByVal MathLib.Point, ByVal MathLib.Rotation)"

        <TestMethod()> <Description("(1;0) r(90°) => (0;1)")> _
        Public Sub Test_01a()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0, 1)
            _rotation = New MathLib.Rotation(New MathLib.Angle(90, MathLib.UnitAngle.Degree))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Rotate(New MathLib.Point(1, 0), _rotation)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(1;1) r(180°) => (-1;-1)")> _
        Public Sub Test_02a()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-1, -1)
            _rotation = New MathLib.Rotation(New MathLib.Angle(180, MathLib.UnitAngle.Degree))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Rotate(New MathLib.Point(1, 1), _rotation)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

#Region "Rotate(ByVal MathLib.Point, ByVal MathLib.Point, ByVal MathLib.Rotation)"

        <TestMethod()> <Description("(1;0) b(0,0) r(90°) => (0;1)")> _
        Public Sub Test_01b()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0, 1)
            _rotation = New MathLib.Rotation(New MathLib.Angle(90, MathLib.UnitAngle.Degree))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Rotate(New MathLib.Point(1, 0), New MathLib.Point(0, 0), _rotation)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(1;0) b(1,1) r(90°) => (2;1)")> _
        Public Sub Test_02b()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(2, 1)
            _rotation = New MathLib.Rotation(New MathLib.Angle(90, MathLib.UnitAngle.Degree))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Rotate(New MathLib.Point(1, 0), New MathLib.Point(1, 1), _rotation)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
