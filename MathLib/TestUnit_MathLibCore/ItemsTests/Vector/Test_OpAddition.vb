Namespace Obj.Vector

    <TestClass()>
  Public Class OpAddition

        <TestInitialize()>
        Public Sub SetUp()

            _vect1 = New MathLib.Vector
            _vect2 = New MathLib.Vector
            _expected = New MathLib.Vector
            _actual = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _vect1 = Nothing
            _vect2 = Nothing
            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)(0;4) + (0;0)(1;0) = (0;0)(1;4)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 4))

            _vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(0, 4))
            _vect2.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            '--------------------------------------------------------------------

            _actual = _vect1 + _vect2

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(1;1)(2;4) + (0;0)(1;1) = (1;1)(3;5)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(1, 1), New MathLib.Point(3, 5))

            _vect1.SetValues(New MathLib.Point(1, 1), New MathLib.Point(2, 4))
            _vect2.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 1))
            '--------------------------------------------------------------------

            _actual = _vect1 + _vect2

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(10;1)(5;0) + (9;10)(10;12) = (10;1)(6;2)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(10, 1), New MathLib.Point(6, 2))

            _vect1.SetValues(New MathLib.Point(10, 1), New MathLib.Point(5, 0))
            _vect2.SetValues(New MathLib.Point(9, 10), New MathLib.Point(10, 12))
            '--------------------------------------------------------------------

            _actual = _vect1 + _vect2

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As MathLib.Vector
        Private _expected As MathLib.Vector

        Private _vect1 As MathLib.Vector
        Private _vect2 As MathLib.Vector

    End Class

End Namespace
