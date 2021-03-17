Option Strict On
Option Explicit On

Namespace Common.Vector

    <TestClass()>
  Public Class Translation

        <TestInitialize()>
        Public Sub SetUp()

            _sourceVect = New MathLib.Vector
            _guidingVect = New MathLib.Vector
            _Point = New MathLib.Point

            _actual = New MathLib.Vector
            _expected = New MathLib.Vector

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _sourceVect = Nothing
            _guidingVect = Nothing
            _Point = Nothing

            _actual = Nothing
            _expected = Nothing

        End Sub

        Private _actual As MathLib.Vector
        Private _expected As MathLib.Vector
        Private _guidingVect As MathLib.Vector
        Private _Length As Single
        Private _Point As MathLib.Point

        Private _sourceVect As MathLib.Vector

#Region "Translation(ByVal MathLib.Vector, ByVal MathLib.Point)"

        <TestMethod()> <Description("(0;0)(0;1)|(1;1) => (1;1)(1;2)")> _
        Public Sub Test_a01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(1, 1), New MathLib.Point(1, 2))

            _sourceVect.SetValues(New MathLib.Point(0, 0), New MathLib.Point(0, 1))
            _Point.SetValues(1, 1)
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.Translation(_sourceVect, _Point)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

#Region "Translation(ByVal MathLib.Vector, ByVal MathLib.Vector, ByVal Single)"

        <TestMethod()> <Description("(0;0)(0;1)|(1;0)|1 => (1;0)(1;1)")> _
        Public Sub Test_b01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(1, 0), New MathLib.Point(1, 1))

            _sourceVect.SetValues(New MathLib.Point(0, 0), New MathLib.Point(0, 1))
            _guidingVect.SetValues(New MathLib.Point(1, 0))
            _Length = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.Translation(_sourceVect, _guidingVect, _Length)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

#Region "Translation(ByVal MathLib.Vector, ByVal Single)"

        <TestMethod()> <Description("(0;0)(1;0)|1 => (1;0)(2;0)")> _
        Public Sub Test_c01()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(1, 0), New MathLib.Point(2, 0))

            _sourceVect.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _Length = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.Translation(_sourceVect, _Length)

            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("(0;0)(1;0)|1 => (1;0)(2;0)")> _
        Public Sub Test_c02()

            '-- Initialisation des valeurs --------------------------------------
            _expected.SetValues(New MathLib.Point(-1, 0), New MathLib.Point(0, 0))

            _sourceVect.SetValues(New MathLib.Point(0, 0), New MathLib.Point(1, 0))
            _Length = -1
            '--------------------------------------------------------------------

            _actual = MathLib.Common.Vector.Translation(_sourceVect, _Length)

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
