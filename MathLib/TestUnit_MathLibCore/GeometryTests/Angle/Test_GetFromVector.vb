Option Strict On
Option Explicit On

Namespace Geometry.Angle

    <TestClass()>
  Public Class GetFromVector

        Private _actual As MathLib.Angle
        Private _expected As MathLib.Angle

        Private u As MathLib.Vector
        Private v As MathLib.Vector

        <TestInitialize()>
        Public Sub SetUp()

            _expected = New MathLib.Angle
            u = New MathLib.Vector
            v = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _expected = Nothing
            u = Nothing
            v = Nothing

        End Sub

#Region "GetFromVector(ByVal MathLib.Vector, ByVal MathLib.Vector)"

        <TestMethod()> <Description("u(0;1) v(2;0) = PI/2")> _
        Public Sub Test_a01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(MathLib.PI / 2)

            u.SetValues(New MathLib.Point(0, 1))
            v.SetValues(New MathLib.Point(2, 0))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.GetFromVector(u, v)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

#Region "GetFromVector(ByVal MathLib.Vector)"

        <TestMethod()> <Description("u(0;1) = PI/2")> _
        Public Sub Test_b01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(MathLib.PI / 2)

            u.SetValues(New MathLib.Point(0, 1))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.GetFromVector(u)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("u(4;4) = PI/4")> _
        Public Sub Test_b02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(MathLib.PI / 4)
            u.SetValues(New MathLib.Point(4, 4))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.GetFromVector(u)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("u(-1;0) = PI")> _
        Public Sub Test_b03()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(MathLib.PI)
            u.SetValues(New MathLib.Point(-1, 0))
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Angle.GetFromVector(u)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region
    End Class

End Namespace