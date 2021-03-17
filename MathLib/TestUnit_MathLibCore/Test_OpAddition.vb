Namespace Obj.Matrix

  <TestFixture(), Description("Test de l' operateur '+'"), Category("Object")> _
    Public Class OpAddition

    Private Msg As String
    Private A As MathLib.Matrix
    Private B As MathLib.Matrix
    Private Expected As MathLib.Matrix
    Private Actual As MathLib.Matrix

    '<Test(), Description("Test avec un polygone à 2 Cotés"), ExpectedException(GetType(BLM.Tools.BLMException))> _
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

    <Test(), Description("(0;0)(0;1) + (0;0)(1;0) = (0;0)(1;1)")> _
    Public Sub Test_01()

      '-- Initialisation des valeurs --------------------------------------
      A = New MathLib.Matrix(2, 2)
      A(0, 0) = 0
      A(0, 1) = 0
      A(1, 0) = 0
      A(0, 1) = 1

      B = New MathLib.Matrix(2, 2)
      A(0, 0) = 0
      A(0, 1) = 0
      A(1, 0) = 1
      A(0, 1) = 0

      Expected = New MathLib.Matrix(2, 2)
      Expected(0, 0) = 0
      Expected(0, 1) = 0
      Expected(1, 0) = 1
      Expected(0, 1) = 0
      '--------------------------------------------------------------------

      Actual = A + B

      Msg = "Expected : " & Expected.ToString & " - Actual : " & Actual.ToString
      Assert.AreEqual(Expected, Actual, Msg)

    End Sub

  End Class

End Namespace