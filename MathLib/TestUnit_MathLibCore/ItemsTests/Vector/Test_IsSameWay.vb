Namespace Obj.Vector

    <TestClass()>
  Public Class IsSameWay

        <TestInitialize()>
        Public Sub SetUp()

            _vect1 = New MathLib.Vector
            _vect2 = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _vect1 = Nothing
            _vect2 = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(0;0)(1,0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _vect2 = _vect1
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(10;0)(11,0)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _vect2.SetValues(New MathLib.Point(10, 0), New MathLib.Point(11, 0))
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(1;1)(2;2) ;(3;3)(4,4)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(1, 1), New MathLib.Point(2, 2))
            _vect2.SetValues(New MathLib.Point(3, 3), New MathLib.Point(4, 4))
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(1;1)(2;2) ;(2;2)(1,1)")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(1, 1), New MathLib.Point(2, 2))
            _vect2.SetValues(New MathLib.Point(2, 2), New MathLib.Point(1, 1))
            '--------------------------------------------------------------------

            Assert.IsFalse(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(0;0)(1;1) ;(0;0)(-1,-1)")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 1))
            _vect2.SetValues(New MathLib.Point(0, 0), New MathLib.Point(-1, -1))
            '--------------------------------------------------------------------

            Assert.IsFalse(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(0;0)(1;1) ;(0;0)(2,2)")> _
        Public Sub Test_06()

            '-- Initialisation des valeurs --------------------------------------
            _vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 1))
            _vect2.SetValues(New MathLib.Point(0, 0), New MathLib.Point(2, 2))
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameWay(_vect1, _vect2))

        End Sub

        Private _vect1 As MathLib.Vector
        Private _vect2 As MathLib.Vector
    End Class

End Namespace
