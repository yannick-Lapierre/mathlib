Namespace Geometry.Point

    <TestClass()>
    Public Class Translation

        <TestInitialize()>
        Public Sub SetUp()

            _pt = New MathLib.Point
            _vect = New MathLib.Vector
            _expected = New MathLib.Point
            _actual = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _pt = Nothing
            _vect = Nothing
            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> <Description("(0;0) t(1;0) Lenght = 1 => (1;0)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(1, 0)

            _pt.SetValues(0, 0)
            _vect.SetValues(New MathLib.Point(1, 0))
            _lenght = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Translation(_pt, _vect, _lenght)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(1;1) t(0;1) Lenght = 3 => (1;4)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(1, 4)

            _pt.SetValues(1, 1)
            _vect.SetValues(New MathLib.Point(0, 1))
            _lenght = 3
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Translation(_pt, _vect, _lenght)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0;0) t(1;0) Lenght = -1 => (-1;0)")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(-1, 0)

            _pt.SetValues(0, 0)
            _vect.SetValues(New MathLib.Point(1, 0))
            _lenght = -1
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.Translation(_pt, _vect, _lenght)

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As MathLib.Point
        Private _expected As MathLib.Point
        Private _lenght As Single

        Private _msg As String
        Private _pt As MathLib.Point
        Private _vect As MathLib.Vector

    End Class

End Namespace
