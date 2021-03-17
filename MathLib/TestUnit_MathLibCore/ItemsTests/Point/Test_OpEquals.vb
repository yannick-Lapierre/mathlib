Namespace Obj.Point

    <TestClass()>
    Public Class OpEquals

        <TestInitialize()>
        Public Sub SetUp()

            _pt1 = New MathLib.Point
            _pt2 = New MathLib.Point

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

        End Sub

        <TestMethod()> <Description("(1;1;1) = (1;1;1) => True")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _pt1.SetValues(1, 1, 1)
            _pt2.SetValues(1, 1, 1)
            '--------------------------------------------------------------------

            Assert.IsTrue(_pt1 = _pt2)

        End Sub

        <TestMethod()> <Description("(1,2) = (1,1) => False")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _pt1.SetValues(1, 2)
            _pt2.SetValues(1, 1)
            '--------------------------------------------------------------------

            Assert.IsFalse(_pt1 = _pt2)

        End Sub

        <TestMethod()> <Description("Nothing = Nothing => True")> _
        Public Sub Test_03()

            '-- Initialisation des valeurs --------------------------------------
            _pt1 = Nothing
            _pt2 = Nothing
            '--------------------------------------------------------------------

            Assert.IsTrue(_pt1 = _pt2)

        End Sub

        <TestMethod()> <Description("(1,1) = Nothing => False")> _
        Public Sub Test_04()

            '-- Initialisation des valeurs --------------------------------------
            _pt1.SetValues(1, 1)
            _pt2 = Nothing
            '--------------------------------------------------------------------

            Assert.IsFalse(_pt1 = _pt2)

        End Sub

        <TestMethod()> <Description("Nothing = (1,1)=> False")> _
        Public Sub Test_05()

            '-- Initialisation des valeurs --------------------------------------
            _pt1 = Nothing
            _pt2.SetValues(1, 1)
            '--------------------------------------------------------------------

            Assert.IsFalse(_pt1 = _pt2)

        End Sub

        <TestMethod()> <Description("(0.065;0.07;0) = (0.065;0.07;0) => True")> _
        Public Sub Test_06()

            '-- Initialisation des valeurs --------------------------------------
            _pt1.SetValues(0.065, 0.07)
            _pt2.SetValues(0.065, 0.07)
            '--------------------------------------------------------------------

            Assert.IsTrue(_pt1 = _pt2)

        End Sub

        Private _pt1 As MathLib.Point
        Private _pt2 As MathLib.Point

    End Class

End Namespace
