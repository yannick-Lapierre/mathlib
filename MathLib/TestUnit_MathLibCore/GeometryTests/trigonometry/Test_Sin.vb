Namespace Geometry.Trigonometry

    <TestClass()>
  Public Class Sin

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

#Region "Sin(ByVal Single)"

#End Region


#Region "Sin(ByVal MathLib.Angle)"

        <TestMethod()> <Description("Sin(0°)= 0")> _
        Public Sub Test_01b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(0, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(90°)= 1")> _
        Public Sub Test_02b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1.0!
            _Angle = New MathLib.Angle(90, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub


        <TestMethod()> <Description("Sin(180°)= 0")> _
        Public Sub Test_03b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(30°)= 0.5")> _
        Public Sub Test_04b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(30, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(150°)= 0.5")> _
        Public Sub Test_05b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(150, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(210°)= -0.5")> _
        Public Sub Test_06b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(210, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(330°)= -0.5")> _
        Public Sub Test_07b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(330, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(360°)= 0")> _
        Public Sub Test_08b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(360, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub


        <TestMethod()> <Description("Sin(-90°)= -1")> _
        Public Sub Test_09b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -1.0!
            _Angle = New MathLib.Angle(-90, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(-30°)= -0.5")> _
        Public Sub Test_10b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(-30, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(-150)= -0.5")> _
        Public Sub Test_11b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = -0.5!
            _Angle = New MathLib.Angle(-150, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(-210°)= 0.5")> _
        Public Sub Test_12b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(-210, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(-330°)= 0.5")> _
        Public Sub Test_13b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(-330, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(-180°)= 0")> _
        Public Sub Test_14b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.0!
            _Angle = New MathLib.Angle(-180, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(450°)= 1")> _
        Public Sub Test_15b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 1.0!
            _Angle = New MathLib.Angle(450, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

        <TestMethod()> <Description("Sin(390°)= 0.5")> _
        Public Sub Test_16b()

            '-- Initialisation des valeurs --------------------------------------
            _expected = 0.5!
            _Angle = New MathLib.Angle(390, MathLib.UnitAngle.Degree)
            '--------------------------------------------------------------------

            _actual = MathLib.Geometry.trigonometry.Sin(_Angle)
            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
