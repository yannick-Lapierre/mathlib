Namespace GeometryTests.Polygon

    <TestClass()>
    Public Class Prallel

        Private _actual() As MathLib.Point
        Private _expected As System.Collections.Generic.List(Of MathLib.Point)

        Private _tabPt As System.Collections.Generic.List(Of MathLib.Point)

        <TestInitialize()>
        Public Sub SetUp()

            _expected = New System.Collections.Generic.List(Of MathLib.Point)
            _tabPt = New System.Collections.Generic.List(Of MathLib.Point)

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _expected = Nothing
            _tabPt = Nothing

        End Sub

        <TestMethod()>
        Public Sub Test01()

            _expected.Add(New MathLib.Point(-1, -1))
            _expected.Add(New MathLib.Point(-1, 5))
            _expected.Add(New MathLib.Point(5, 5))
            _expected.Add(New MathLib.Point(5, -1))

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(0, 4))
            _tabPt.Add(New MathLib.Point(4, 4))
            _tabPt.Add(New MathLib.Point(4, 0))

            _actual = MathLib.Geometry.Polygon.Parallel(_tabPt.ToArray, 1)

            CollectionAssert.AreEqual(_expected.ToArray, _actual)

        End Sub

        <TestMethod()>
        Public Sub Test02()

            _expected.Add(New MathLib.Point(1, 1))
            _expected.Add(New MathLib.Point(1, 3))
            _expected.Add(New MathLib.Point(3, 3))
            _expected.Add(New MathLib.Point(3, 1))

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(0, 4))
            _tabPt.Add(New MathLib.Point(4, 4))
            _tabPt.Add(New MathLib.Point(4, 0))

            _actual = MathLib.Geometry.Polygon.Parallel(_tabPt.ToArray, -1)

            CollectionAssert.AreEqual(_expected.ToArray, _actual)

        End Sub

        <TestMethod()>
        Public Sub Test03()

            _expected.Add(New MathLib.Point(1, 1))
            _expected.Add(New MathLib.Point(3, 1))
            _expected.Add(New MathLib.Point(3, 3))
            _expected.Add(New MathLib.Point(1, 3))

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(4, 0))
            _tabPt.Add(New MathLib.Point(4, 4))
            _tabPt.Add(New MathLib.Point(0, 4))

            _actual = MathLib.Geometry.Polygon.Parallel(_tabPt.ToArray, 1)

            CollectionAssert.AreEqual(_expected.ToArray, _actual)

        End Sub

        <TestMethod()>
        Public Sub Test04()

            _expected.Add(New MathLib.Point(-1, -1))
            _expected.Add(New MathLib.Point(-1, 5))
            _expected.Add(New MathLib.Point(5, 5))
            _expected.Add(New MathLib.Point(5, -1))

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(0, 4))
            _tabPt.Add(New MathLib.Point(4, 4))
            _tabPt.Add(New MathLib.Point(4, 0))

            _actual = MathLib.Geometry.Polygon.Parallel(_tabPt.ToArray, 1)

            CollectionAssert.AreEqual(_expected.ToArray, _actual)

        End Sub

        <TestMethod()>
        Public Sub Test05()

            Dim TabDistance As New System.Collections.Generic.List(Of Double)

            _expected.Add(New MathLib.Point(1, 1))
            _expected.Add(New MathLib.Point(1, 3))
            _expected.Add(New MathLib.Point(3, 3))
            _expected.Add(New MathLib.Point(3, 1))

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(0, 4))
            _tabPt.Add(New MathLib.Point(4, 4))
            _tabPt.Add(New MathLib.Point(4, 0))

            TabDistance.Add(-1)
            TabDistance.Add(-1)
            TabDistance.Add(-1)
            TabDistance.Add(-1)

            _actual = MathLib.Geometry.Polygon.Parallel(_tabPt.ToArray, TabDistance.ToArray)

            CollectionAssert.AreEqual(_expected.ToArray, _actual)

        End Sub

    End Class
End Namespace