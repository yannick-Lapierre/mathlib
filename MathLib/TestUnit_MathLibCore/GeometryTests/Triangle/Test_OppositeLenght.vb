Option Strict On
Option Explicit On

Namespace Geometry.Triangle

    <TestClass()>
  Public Class Hypotenuse

        Private _Lenght1 As Double
        Private _Lenght2 As Double
        Private _actual As Double
        Private _expected As Double

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

        End Sub

        <TestMethod()> <Description("Side1 = 1; Side2 = 1 => Sqrt(2)")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            _expected = MathLib.General.Sqrt(2)
            _Lenght1 = 1
            _Lenght2 = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Triangle.Hypotenuse(_Lenght1, _Lenght2)

            'Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            'Assert.AreEqual(Expected, Actual, Msg)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Side1 = -1; Side2 = 1 => Sqrt(2)")> _
        Public Sub Test_02()

            '-- Initialisation des valeurs --------------------------------------
            _expected = MathLib.General.Sqrt(2)
            _Lenght1 = -1
            _Lenght2 = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.Triangle.Hypotenuse(_Lenght1, _Lenght2)

            'Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            'Assert.AreEqual(Expected, Actual, Msg)
            Assert.AreEqual(_expected, _actual)

        End Sub

    End Class

End Namespace
