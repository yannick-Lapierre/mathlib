Option Strict On
Option Explicit On

Namespace Common.Conversion

    <TestClass()>
  Public Class Angle

        '<Test(),<Description("Test avec un polygone à 2 Cotés"), ExpectedException(GetType(BLM.Tools.BLMException))> _
        'Public Sub With_2_Bound()

        '  Dim TabPt As New System.Collections.Generic.List(Of sPoint)
        '  Dim Pt As sPoint

        '  '-- Test 01 ---------------------------------------------------------
        '  Pt.SetValues(0, 0)
        '  TabPt.Add(Pt)
        '  Pt.SetValues(1, 0)
        '  TabPt.Add(Pt)

        '  Call BLM.Tools.Math.polygon.GravityCenter(TabPt.ToArray)

        'End Sub

        <TestMethod()> <Description("Angle = 0; Degré -> Radian")> _
        Public Sub Test_01()

            '-- Initialisation des valeurs --------------------------------------
            Expected = 0

            InType = MathLib.UnitAngle.Degree
            OutType = MathLib.UnitAngle.Radian
            Angle = 0
            '--------------------------------------------------------------------

            Actual = MathLib.Common.Conversion.Angle(Angle, InType, OutType)

            Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub

        Private Actual As Double

        Private Angle As Double
        Private Expected As Double
        Private InType As MathLib.UnitAngle

        Private Msg As String
        Private OutType As MathLib.UnitAngle

    End Class

End Namespace
