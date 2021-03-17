Namespace Obj.LineEquation

    <TestClass()>
  Public Class ToString

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

        <TestMethod()> <Description("A=1 B=1 C=0 D=0")> _
        Public Sub Test_01()

            Dim Msg As String
            Dim EqLine As New MathLib.LineEquation
            Dim Expected As String
            Dim Actual As String

            '-- Initialisation des valeurs --------------------------------------
            Expected = "1x + 1y + 0z + 0 = 0"
            EqLine.SetValues(1, 1, 0, 0)
            '--------------------------------------------------------------------

            Actual = EqLine.ToString
            Msg = "Expected : " & Expected & " - Actual : " & Actual
            Assert.AreEqual(Expected, Actual, Msg)

        End Sub

    End Class

End Namespace
