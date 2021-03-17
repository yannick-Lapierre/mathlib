Option Strict On
Option Explicit On

Namespace GeometryTests.Polygon

    ' TODO "Non codé"
    <TestClass()>
    Public Class ProjectionPt

        <TestInitialize()>
        Public Sub SetUp()

            _tabPt = New System.Collections.Generic.List(Of MathLib.Point)
            _refPt = New MathLib.Point
            _pt = New MathLib.Point
            _angle = New MathLib.Angle

            _expected = New MathLib.Point
            _actual = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _tabPt = Nothing
            _refPt = Nothing
            _pt = Nothing
            _angle = Nothing

            _expected = Nothing
            _actual = Nothing

        End Sub

        <TestMethod()>
        <Description("Test avec un polygone a valeur Positive et angle compris entre 0 et 90°")>
        <Ignore()>
        Public Sub Test_01()

            '-- Test 01 ---------------------------------------------------------
            _tabPt.Clear()
            _expected.SetValues(0.5, 0.5)

            _angle.SetValues(45, MathLib.UnitAngle.Degree)
            _refPt.SetValues(0, 0)

            _pt.SetValues(0, 1)
            _tabPt.Add(_pt.Clone)
            _pt.SetValues(1, 0)
            _tabPt.Add(_pt.Clone)
            _pt.SetValues(1, 1)
            _tabPt.Add(_pt.Clone)

            _actual = MathLib.Geometry.Polygon.ProjectionPt(_refPt, _tabPt.ToArray, _angle)

            Assert.AreEqual(_expected, _actual)

        End Sub
        Private _actual As MathLib.Point
        Private _angle As MathLib.Angle

        Private _expected As MathLib.Point
        Private _pt As MathLib.Point
        Private _refPt As MathLib.Point

        Private _tabPt As System.Collections.Generic.List(Of MathLib.Point)

    End Class
End Namespace