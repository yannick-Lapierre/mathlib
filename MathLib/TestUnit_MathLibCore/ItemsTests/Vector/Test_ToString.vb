Namespace Obj.Vector

    <TestClass()>
    Public Class ToString

        <TestInitialize()>
        Public Sub SetUp()

            _a = New MathLib.Point
            _b = New MathLib.Point
            _vect = New MathLib.Vector

            _expected = String.Empty
            _actual = String.Empty

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _a = Nothing
            _b = Nothing
            _vect = Nothing

        End Sub

        <Testmethod()> <Description("(0;0;0)(1;1;1)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _a.SetValues(0, 0, 0)
            _b.SetValues(1, 1, 1)
            _expected = "[(0;0;0)(1;1;1)]"
            _vect.SetValues(_a, _b)
            '--------------------------------------------------------------------

            _actual = _vect.ToString
            Assert.AreEqual(_expected, _actual)

        End Sub

        Private _a As MathLib.Point
        Private _actual As String
        Private _b As MathLib.Point
        Private _expected As String
        Private _vect As MathLib.Vector

    End Class

End Namespace
