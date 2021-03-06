Namespace Geometry.Trigonometry

    <TestClass()>
  Public Class Cos

        <TestInitialize()>
        Public Sub SetUp()

            _expected = Single.NaN
            _actual = Single.NaN

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Angle = Nothing
        End Sub
        Private _actual As Single
        Private _Angle As MathLib.Angle

        Private _expected As Single

#Region "Cos(ByVal Single)"

#End Region


#Region "Cos(ByVal MathLib.Angle)"

        <TestMethod()> <Description("Cos(0°)= 1")> _
        Public Sub Test_01b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1.0!
            _Angle = New MathLib.Angle(0, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(90°)= 0")> _
        Public Sub Test_02b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(90, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub


        <TestMethod()> <Description("Cos(180°)= -1")> _
        Public Sub Test_03b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -1.0!
            _Angle = New MathLib.Angle(180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(270°)= 0")> _
        Public Sub Test_04b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(270, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(120°)= -0.5")> _
        Public Sub Test_05b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(120, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(240°)= -0.5")> _
        Public Sub Test_06b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(240, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(60°)= 0.5")> _
        Public Sub Test_07b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(60, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(300°)= 0.5")> _
        Public Sub Test_08b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(300, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub


        <TestMethod()> <Description("Cos(-90°)= 0")> _
        Public Sub Test_09b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(-90, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(-120°)= -0.5")> _
        Public Sub Test_10b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(-120, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(-240°)= -0.5")> _
        Public Sub Test_11b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(-240, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(-60°)= 0.5")> _
        Public Sub Test_12b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(-60, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(300°)= 0.5")> _
        Public Sub Test_13b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(300, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(-180°)= -1")> _
        Public Sub Test_14b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -1.0!
            _Angle = New MathLib.Angle(-180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(450°)= 0")> _
        Public Sub Test_15b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(450, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Cos(420°)= 0.5")> _
        Public Sub Test_16b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(420, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Cos(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
