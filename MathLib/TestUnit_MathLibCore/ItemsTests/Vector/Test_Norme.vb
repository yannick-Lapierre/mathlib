Namespace Obj.Vector

    <TestClass()>
    Public Class Norme

        <TestInitialize()>
        Public Sub SetUp()

            _Pt1 = New MathLib.Point
            _Pt2 = New MathLib.Point
            _Vect1 = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Pt1 = Nothing
            _Pt2 = Nothing
            _Vect1 = Nothing

        End Sub

        <Testmethod()> <Description("(0;0)(1;0) => 1")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(1, 0)
            _Vect1.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            _actual = _Vect1.Norm

            Assert.AreEqual(_expected, _actual)

        End Sub

        <Testmethod()> <Description("(0;0)(0;1) => 1")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(0, 1)
            _Vect1.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            _actual = _Vect1.Norm

            Assert.AreEqual(_expected, _actual)

        End Sub

        <Testmethod()> <Description("(0;0)(-2;0) => 2")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 2
            _Pt1.SetValues(0, 0)
            _Pt2.SetValues(-2, 0)
            _Vect1.SetValues(_Pt1, _Pt2)
            '--------------------------------------------------------------------

            _actual = _Vect1.Norm

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As Single
        Private _expected As Single

        Private _Pt1 As MathLib.Point
        Private _Pt2 As MathLib.Point
        Private _Vect1 As MathLib.Vector

    End Class

End Namespace
