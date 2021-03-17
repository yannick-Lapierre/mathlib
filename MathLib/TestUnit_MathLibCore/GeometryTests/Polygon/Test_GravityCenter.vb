Namespace Geometry.Polygon

    <TestClass()>
  Public Class GravityCenter

        <TestInitialize()>
        Public Sub SetUp()

            _tabPt = New System.Collections.Generic.List(Of MathLib.Point)

            _expected = New MathLib.Point
            _actual = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _tabPt = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()> _
        Public Sub Test01()

            _tabPt.Clear()
            _expected.SetValues(1 / 3, 1 / 3) '1/3 = 0.33333.......

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(1, 0))
            _tabPt.Add(New MathLib.Point(0, 1))

            _actual = MathLib.Geometry.Polygon.GravityCenter(_tabPt.ToArray)

            Assert.AreEqual(_expected, _actual)

        End Sub


        <TestMethod()> _
        Public Sub Test02()

            _tabPt.Clear()
            _expected.SetValues(-1 / 3, 1 / 3) '1/3 = 0.33333.......

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(-1, 0))
            _tabPt.Add(New MathLib.Point(0, 1))

            _actual = MathLib.Geometry.Polygon.GravityCenter(_tabPt.ToArray)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> _
        Public Sub Test03()

            _tabPt.Clear()
            _expected.SetValues(-1 / 3, -1 / 3) '1/3 = 0.33333.......

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(-1, 0))
            _tabPt.Add(New MathLib.Point(0, -1))

            _actual = MathLib.Geometry.Polygon.GravityCenter(_tabPt.ToArray)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Test avec un polygone à 2 Cotés"), ExpectedException(GetType(MathLib.Exception))> _
        Public Sub With_2_Bound()

            '-- Test 01 ---------------------------------------------------------
            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(1, 0))

            Call MathLib.Geometry.Polygon.GravityCenter(_tabPt.ToArray)

        End Sub
        Private _actual As MathLib.Point
        Private _expected As New MathLib.Point

        Private _tabPt As New System.Collections.Generic.List(Of MathLib.Point)

    End Class

End Namespace
