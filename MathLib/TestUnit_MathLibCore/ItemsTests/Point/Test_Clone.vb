Namespace Obj.Point

    <TestClass()>
  Public Class Clone

        <TestInitialize()>
        Public Sub SetUp()

            _Pt1 = New MathLib.Point
            _expected = New MathLib.Point
            _actual = New MathLib.Point
        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Pt1 = Nothing
            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("(0;0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(0, 0)
            _Pt1.SetValues(0, 0)
            '--------------------------------------------------------------------

            _actual = _Pt1.Clone
            _Pt1.X = 1

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(10;10)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(10, 10)
            _Pt1.SetValues(10, 10)
            '--------------------------------------------------------------------

            _actual = _Pt1.Clone
            _Pt1.X = 12
            _Pt1.Y = 12

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(10;10)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(10, 10)
            _Pt1.SetValues(10, 10)
            '--------------------------------------------------------------------

            _actual = _Pt1.Clone
            _Pt1 = Nothing

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As MathLib.Point
        Private _expected As MathLib.Point

        Private _Pt1 As MathLib.Point

    End Class

End Namespace
