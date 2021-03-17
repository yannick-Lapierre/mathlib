Namespace Obj.Vector

    <TestClass()>
  Public Class IsSameDirection

        <TestInitialize()>
        Public Sub SetUp()

            _Pt1 = New MathLib.Point
            _Pt2 = New MathLib.Point
            _Vect1 = New MathLib.Vector
            _vect2 = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Pt1 = Nothing
            _Pt2 = Nothing
            _Vect1 = Nothing
            _vect2 = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(0;0)(1,0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(1, 0)
            _Vect1.SetValues(_Pt1, _Pt2)
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(1, 0)
            _vect2.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameDirection(_Vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(10;0)(11,0)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(1, 0)
            _Vect1.SetValues(_Pt1, _Pt2)
            _Pt1.SetValues(10, 0)
            _Pt2.SetValues(11, 0)
            _vect2.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameDirection(_Vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(1;1)(2;2) ;(3;3)(4,4)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _Pt1.SetValues(1, 1)
            _Pt2.SetValues(2, 2)
            _Vect1.SetValues(_Pt1, _Pt2)
            _Pt1.SetValues(3, 3)
            _Pt2.SetValues(4, 4)
            _vect2.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameDirection(_Vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(1;1)(2;2) ;(2;2)(1,1)")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _Pt1.SetValues(1, 1)
            _Pt2.SetValues(2, 2)
            _Vect1.SetValues(_Pt1, _Pt2)
            _vect2.SetValues(_Pt2, _Pt1)
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameDirection(_Vect1, _vect2))

        End Sub

        <TestMethod()> <Description("(0;0)(1;1) ;(0;0)(-1,-1)")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(1, 1)
            _Vect1.SetValues(_Pt1, _Pt2)
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(-1, -1)
            _vect2.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            Assert.IsTrue(MathLib.Vector.IsSameDirection(_Vect1, _vect2))

        End Sub

        Private _Pt1 As MathLib.Point
        Private _Pt2 As MathLib.Point
        Private _Vect1 As MathLib.Vector
        Private _vect2 As MathLib.Vector

    End Class

End Namespace
