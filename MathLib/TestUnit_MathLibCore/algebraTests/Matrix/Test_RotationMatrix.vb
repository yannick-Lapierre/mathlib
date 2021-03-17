Namespace Algebra.Matrix

    <TestClass()>
  Public Class RotationMatrix

        Private _actual As MathLib.Matrix
        Private _expected As MathLib.Matrix

        Private xAxeAngle As MathLib.Angle
        Private yAxeAngle As MathLib.Angle
        Private zAxeAngle As MathLib.Angle

        <TestInitialize()>
        Public Sub SetUp()
            xAxeAngle = New MathLib.Angle
            yAxeAngle = New MathLib.Angle
            zAxeAngle = New MathLib.Angle
        End Sub

        <TestCleanup()>
        Public Sub TearDown()
            xAxeAngle = Nothing
            yAxeAngle = Nothing
            zAxeAngle = Nothing
        End Sub

        <TestMethod()> <Description("Parametre = Nothing"), ExpectedException(GetType(NullReferenceException))> _
        Public Sub Exception_01()

            Call MathLib.Algebra.Matrix.Transpose(Nothing)

        End Sub

#Region "RotationMatrix(ByVal MathLib.Angle, ByVal MathLib.Angle, ByVal MathLib.Angle)"

        <TestMethod()> <Description("90° sur axe Z = [(0;-1;0)(1;0;0)(0;0;1)]")> _
        Public Sub Test_a01()

            '-- Initialisation des valeurs --------------------------------------
            zAxeAngle.SetValues(90, MathLib.UnitAngle.Degree)

            _expected = New MathLib.Matrix(3, 3)
            _expected(0, 0) = 0
            _expected(0, 1) = -1
            _expected(0, 2) = 0
            _expected(1, 0) = 1
            _expected(1, 1) = 0
            _expected(1, 2) = 0
            _expected(2, 0) = 0
            _expected(2, 1) = 0
            _expected(2, 2) = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Algebra.Matrix.RotationMatrix(New MathLib.Rotation(Nothing, Nothing, zAxeAngle))

            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

#Region "RotationMatrix(ByVal MathLib.Angle)"

        <TestMethod()> <Description("90° sur axe Z = [(0;-1;0)(1;0;0)(0;0;1)]")> _
        Public Sub Test_b01()

            '-- Initialisation des valeurs --------------------------------------
            zAxeAngle.SetValues(90, MathLib.UnitAngle.Degree)

            _expected = New MathLib.Matrix(3, 3)
            _expected(0, 0) = 0
            _expected(0, 1) = -1
            _expected(0, 2) = 0
            _expected(1, 0) = 1
            _expected(1, 1) = 0
            _expected(1, 2) = 0
            _expected(2, 0) = 0
            _expected(2, 1) = 0
            _expected(2, 2) = 1
            '--------------------------------------------------------------------

            _actual = MathLib.Algebra.Matrix.RotationMatrix(zAxeAngle)

            '  Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            'Assert.AreEqual(Expected, Actual, Msg)
            Assert.AreEqual(_expected, _actual)

        End Sub

#End Region

    End Class

End Namespace
