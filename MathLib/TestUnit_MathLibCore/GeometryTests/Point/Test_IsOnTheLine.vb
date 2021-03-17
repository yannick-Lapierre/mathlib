Namespace Geometry.Point

    <TestClass()>
  Public Class IsOnTheLine

        <TestInitialize()>
        Public Sub SetUp()

            _refPt = New MathLib.Point
            _a = New MathLib.Point
            _b = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _refPt = Nothing
            _a = Nothing
            _b = Nothing

        End Sub

        <TestMethod()>
        <Description("(0.5;0.5) € (0;0),(1;1)")>
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(0.5, 0.5)
            _a.SetValues(0, 0)
            _b.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub

        <TestMethod()>
        <Description("(2;2) € (0;0),(1;1)")>
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(2, 2)
            _a.SetValues(0, 0)
            _b.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub

        <TestMethod()>
        <Description("(-1;-1) € (0;0),(1;1)")>
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(-1, -1)
            _a.SetValues(0, 0)
            _b.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub

        <Testmethod()> <Description("(0.5;-0.5) € (0;0),(1;-1)")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(0.5, -0.5)
            _a.SetValues(0, 0)
            _b.SetValues(1, -1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub

        <Testmethod()> <Description("(2;-2) € (0;0),(1;-1)")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(2, -2)
            _a.SetValues(0, 0)
            _b.SetValues(1, -1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub

        <Testmethod()> <Description("(-0.5;0.5) € (0;0),(1;-1)")> _
        Public Sub Test_06()

            '-- Initialisation des valeurs --------------------------------------
            _refPt.SetValues(-0.5, 0.5)
            _a.SetValues(0, 0)
            _b.SetValues(1, -1)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Point.IsOnTheLine(_a, _b, _refPt)

            Assert.IsTrue(_actual)

        End Sub
        Private _a As MathLib.Point
        Private _actual As Boolean
        Private _b As MathLib.Point

        Private _refPt As MathLib.Point

    End Class

End Namespace
