Option Strict On
Option Explicit On

Namespace Common.Vector

    <TestClass()>
    Public Class DotProduct

        <TestInitialize()>
        Public Sub SetUp()

            u = New MathLib.Vector
            v = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            u = Nothing
            v = Nothing

        End Sub

        <TestMethod()>
        <Description("u(0;0)(0;1) . v(0;0)(1;0) = 0")>
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            Expected = 0
            u.SetValues(New MathLib.Point(0, 0), New MathLib.Point(0, 1))
            v.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            '--------------------------------------------------------------------

            Actual = MathLib.Common.Vector.DotProduct(u, v)

            Assert.AreEqual(Expected, Actual)

        End Sub

        <TestMethod()>
        <Description("u(-4;1) . v(8;-3) = -35")>
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            Expected = -35
            u.SetValues(New MathLib.Point(-4, 1))
            v.SetValues(New MathLib.Point(8, -3))
            '--------------------------------------------------------------------

            Actual = MathLib.Common.Vector.DotProduct(u, v)

            Assert.AreEqual(Expected, Actual)

        End Sub

        Private Actual As Double
        Private Expected As Double

        Private u As MathLib.Vector
        Private v As MathLib.Vector

    End Class

End Namespace
