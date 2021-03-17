Namespace Obj.Vector

    <TestClass()>
  Public Class Reverse

        <TestInitialize()>
        Public Sub SetUp()

            _Vect = New MathLib.Vector

            _expected = New MathLib.Vector
            _actual = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Vect = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)(1;0) -> (1;0)(0;0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(1, 0), New MathLib.Point(0, 0))
            _Vect.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            '--------------------------------------------------------------------

            _actual = _Vect.Reverse

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(10;4)(-5;8) -> (-5;8)(10;4)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(-5, 8), New MathLib.Point(10, 4))
            _Vect.SetValues(New MathLib.Point(10, 4), New MathLib.Point(-5, 8))
            '--------------------------------------------------------------------

            _actual = _Vect.Reverse

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As MathLib.Vector
        Private _expected As MathLib.Vector

        Private _Vect As MathLib.Vector


    End Class

End Namespace
