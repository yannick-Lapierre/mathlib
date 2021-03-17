Namespace Geometry.Polygon

    <TestClass()>
  Public Class Area

        <TestInitialize()>
        Public Sub SetUp()

            _tabPt = New System.Collections.Generic.List(Of MathLib.Point)

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _tabPt = Nothing

        End Sub

        <TestMethod()> <Description("Test avec un polygone à 3 Cotés Avec tous les points positifs")> _
        Public Sub Test01()

            _expected = 0.5

            _tabPt.Add(New MathLib.Point(0, 0))
            _tabPt.Add(New MathLib.Point(1, 0))
            _tabPt.Add(New MathLib.Point(0, 1))
            _tabPt.Add(_tabPt(0))

            _actual = MathLib.Geometry.Polygon.Area(_tabPt.ToArray)

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As Single
        Private _expected As Single

        Private _tabPt As System.Collections.Generic.List(Of MathLib.Point)

    End Class

End Namespace
