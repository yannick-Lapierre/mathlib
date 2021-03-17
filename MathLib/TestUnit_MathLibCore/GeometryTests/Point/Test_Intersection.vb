Namespace Geometry.Point

    <TestClass()>
  Public Class Intersection

        Private _actual As MathLib.Point
        Private _expected As MathLib.Point
        Private _equation1 As MathLib.LineEquation
        Private _equation2 As MathLib.LineEquation

        <TestInitialize()>
        Public Sub SetUp()

            _expected = New MathLib.Point
            _actual = New MathLib.Point
            _equation1 = New MathLib.LineEquation
            _equation2 = New MathLib.LineEquation

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _expected = Nothing
            _actual = Nothing
            _equation1 = Nothing
            _equation2 = Nothing

        End Sub

#Region ""

        <TestMethod()> _
        Public Sub Test_01a()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-2, -2)
            _equation1.SetValues(0, 1, 2)
            _equation2.SetValues(1, 0, 2)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Intersection(_equation1, _equation2)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
