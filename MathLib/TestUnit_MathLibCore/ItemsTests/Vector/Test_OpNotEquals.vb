Namespace Obj.Vector

    <TestClass()>
  Public Class OpNotEquals

        <TestInitialize()>
        Public Sub SetUp()

            _Vect1 = New MathLib.Vector
            _vect2 = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Vect1 = Nothing
            _vect2 = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(0;0)(1,0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _Vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _vect2 = _Vect1
            '--------------------------------------------------------------------

            Assert.IsFalse(_Vect1 <> _vect2)

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) ;(10;0)(12,0)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _Vect1.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _vect2.SetValues(New MathLib.Point(10, 0), New MathLib.Point(12, 0))
            '--------------------------------------------------------------------

            Assert.IsTrue(_Vect1 <> _vect2)

        End Sub

        Private _Vect1 As MathLib.Vector
        Private _vect2 As MathLib.Vector

    End Class

End Namespace
