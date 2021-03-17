Namespace Algebra.Matrix

  <TestFixture(), Description("Test la fonction Cramer"), Category("Items")> _
    Public Class Cramer

    Private _actual As MathLib.Matrix
    Private _expected As MathLib.Matrix
    Private _coefMatrix As MathLib.Matrix
    Private _valueMatrix As MathLib.Matrix

    <SetUp()> _
Public Sub SetUp()

    End Sub

    <TearDown()> _
    Public Sub TearDown()
      _actual = Nothing
      _expected = Nothing
      _coefMatrix = Nothing
      _valueMatrix = Nothing
    End Sub

    <Test(), Description("")> _
    Public Sub Test_a01()

      '-- Initialisation des valeurs --------------------------------------
      _expected = New MathLib.Matrix("{[2;1]}")
      _coefMatrix = New MathLib.Matrix("{[2;1][1;2]}")
      _valueMatrix = New MathLib.Matrix("{[5][4]}")
      '--------------------------------------------------------------------

      _actual = MathLib.Algebra.Matrix.Cramer(_coefMatrix, _valueMatrix)

      Assert.AreEqual(_expected, _actual)

    End Sub

  End Class

End Namespace
