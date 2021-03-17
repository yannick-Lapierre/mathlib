Option Strict On

''' <summary>Representation d'un angle</summary>
<DebuggerDisplay("{ToString}")> _
Public Class Angle
  ''' <summary>
  '''     Valeur de l'angle
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Value As Double
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Unit As UnitAngle

  ''' <summary>
  '''     Valeur de l'angle
  ''' </summary>
  ''' <value>
  '''     <para>
  '''         
  '''     </para>
  ''' </value>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public ReadOnly Property Value() As Double
    Get
      Return _Value
    End Get
  End Property

  ''' <summary>
  '''     Valeur de l'angle
  ''' </summary>
  ''' <value>
  '''     <para>
  '''         
  '''     </para>
  ''' </value>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public ReadOnly Property Value(ByVal Unit As UnitAngle) As Double
    Get
      Return MathLib.Common.Conversion.Angle(_Value, _Unit, Unit)
    End Get
  End Property

  Public ReadOnly Property ModuloValue() As Double
    Get

      Dim result As Double

      Select Case _Unit
        Case UnitAngle.Degree
          result = MathLib.General.Modulo(_Value, 360)
          If _Value < 0 Then result = 360 - result
        Case UnitAngle.Gradian
        Case UnitAngle.Pourcent
        Case UnitAngle.Radian
          result = MathLib.General.Modulo(_Value, 2 * MathLib.PI)
          If _Value < 0 Then result = (2 * MathLib.PI) - result
        Case Else
      End Select

      Return result

    End Get
  End Property

  ''' <summary>
  '''     Unité de l'angle
  ''' </summary>
  ''' <value>
  '''     <para>
  '''         
  '''     </para>
  ''' </value>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public ReadOnly Property Unit() As UnitAngle
    Get
      Return _Unit
    End Get
  End Property

  ''' <summary>
  '''     Defini les valeur de l'angle (en Radian)
  ''' </summary>
  ''' <param name="Angle" type="Single">
  '''     <para>
  '''         Valeur de l'angle
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal Angle As Double)
    _Value = Angle
    _Unit = UnitAngle.Radian
  End Sub

  ''' <summary>
  '''     Défini les valeur de l'anle
  ''' </summary>
  ''' <param name="Angle" type="Single">
  '''     <para>
  '''         Valeur de l'angle
  '''     </para>
  ''' </param>
  ''' <param name="Unit" type="MathLib.UnitAngle">
  '''     <para>
  '''         Unité de l'angle
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal Angle As Double, ByVal Unit As UnitAngle)
    _Value = Angle
    _Unit = Unit
  End Sub

  ''' <summary>
  '''     Constructeur de la classe
  ''' </summary>
  Public Sub New()

    _Value = 0.0#
    _Unit = UnitAngle.Radian

  End Sub

  ''' <summary>
  '''     Constructeur de la classe
  ''' </summary>
  ''' <param name="Angle" type="Single">
  '''     <para>
  '''         Valeur de l'angle
  '''     </para>
  ''' </param>
  Public Sub New(ByVal angle As Double)

    Me.SetValues(angle)

  End Sub

  ''' <summary>
  '''     Constructeur
  ''' </summary>
  ''' <param name="Angle" type="Single">
  '''     <para>
  '''         Valeur de l'angle
  '''     </para>
  ''' </param>
  ''' <param name="Unit" type="MathLib.UnitAngle">
  '''     <para>
  '''         Unité de l'angle.
  '''     </para>
  ''' </param>
  Public Sub New(ByVal angle As Double, ByVal unit As UnitAngle)

    Me.SetValues(angle, unit)

  End Sub

  ''' <summary>
  '''     Convertie un angle en une chaine de caractère
  ''' </summary>
  ''' <returns>
  '''     Chaine de caractère représentant un angle
  ''' </returns>
  Public Overrides Function ToString() As String

    Dim Result As String
    Dim StrUnit As String

    Select Case _Unit
      Case UnitAngle.Degree
        StrUnit = "°"
      Case UnitAngle.Gradian
        StrUnit = "g"
      Case UnitAngle.Pourcent
        StrUnit = "%"
      Case UnitAngle.Radian
        StrUnit = " rad"
      Case Else
        StrUnit = ""
    End Select

    Result = _Value & StrUnit

    Return Result

  End Function

#Region "Operator"

  ''' <summary>
  '''     Addition de 2 Angles
  ''' </summary>
  ''' <param name="a" type="MathLib.Point">
  '''     <para>
  '''         1er Angle
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Point">
  '''     <para>
  '''         2ème Angle
  '''     </para>
  ''' </param>
  Public Shared Operator +(ByVal a As Angle, ByVal b As Angle) As Angle

    Dim Result As New Angle
    Dim TmpDbl As Double

    If a.Unit = b.Unit Then
      TmpDbl = a.Value + b.Value
      Result.SetValues(TmpDbl, a.Unit)
    Else
      TmpDbl = a.Value(UnitAngle.Radian) + b.Value(UnitAngle.Radian)
      Result.SetValues(TmpDbl, UnitAngle.Radian)
    End If

    Return Result

  End Operator

  ''' <summary>Instancie un nouvel angle à 90°</summary>
  ''' <returns>A MathLib.Angle value...</returns>
  Public Shared Function GetAngle90Deg() As MathLib.Angle

    Return New MathLib.Angle(90, UnitAngle.Degree)

  End Function

  ''' <summary>Instancie un nouvel angle à 45°</summary>
  ''' <returns>A MathLib.Angle value...</returns>
  Public Shared Function GetAngle45Deg() As MathLib.Angle

    Return New MathLib.Angle(45, UnitAngle.Degree)

  End Function

  ''' <summary>Instancie un nouvel angle à 180°</summary>
  ''' <returns>A MathLib.Angle value...</returns>
  Public Shared Function GetAngle180Deg() As MathLib.Angle

    Return New MathLib.Angle(180, UnitAngle.Degree)

  End Function

  ''' <summary>Instancie un nouvel angle à 270°</summary>
  ''' <returns>A MathLib.Angle value...</returns>
  Public Shared Function GetAngle270Deg() As MathLib.Angle

    Return New MathLib.Angle(270, UnitAngle.Degree)

  End Function

  ''' <summary>Informe sur l'égalité entre l'angle et un objet.</summary>
  ''' <param name="obj"><para>Objet à comparer avec l'angle.</para></param>
  ''' <remarks>La comparaison se fait avec une precision de 10^-10</remarks>
  ''' <returns>A Boolean value...</returns>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    If Not IsNothing(obj) AndAlso TypeOf obj Is Angle Then
      Return MathLib.General.AreEquals(CType(obj, Angle).Value(UnitAngle.Radian), Me.Value(UnitAngle.Radian), 10)
    Else
      Return False
    End If

  End Function

  ''' <summary>Addition de 2 Angles</summary>
  ''' <param name="a">1er Angle</param>
  ''' <param name="b">2ème Angle</param>
  Public Shared Operator +(ByVal A As Double, ByVal B As Angle) As Angle

    Dim Result As New Angle

    Result.SetValues(B.Unit + A, B.Unit)

    Return Result

  End Operator

  ''' <summary>Addition de 2 Angles</summary>
  ''' <param name="a">1er Angle</param>
  ''' <param name="b">2ème Angle</param>
  Public Shared Operator +(ByVal A As Angle, ByVal B As Double) As Angle

    Dim Result As New Angle

    Result.SetValues(A.Unit + B, A.Unit)

    Return Result

  End Operator

  ''' <summary>Operation de base.</summary>
  ''' <param name="a">Angle cible</param>
  Public Shared Operator +(ByVal a As Angle) As Angle

    Dim Result As New Angle

    Result.SetValues(a._Value, a.Unit)
    Return Result

  End Operator

  ''' <summary>Suppression aux valeur d'un angle la valeur d'un 2ème angle</summary>
  ''' <param name="a">Angle cible</param>
  ''' <param name="b">Valeur d'angle à soustraire</param>
  Public Shared Operator -(ByVal a As Angle, ByVal b As Angle) As Angle

    Dim Result As New Angle
    Dim TmpSng As Double

    If a.Unit = b.Unit Then
      TmpSng = a.Value - b.Value
      Result.SetValues(TmpSng, a.Unit)
    Else
      TmpSng = a.Value(UnitAngle.Radian) - b.Value(UnitAngle.Radian)
      Result.SetValues(TmpSng, UnitAngle.Radian)
    End If

    Return Result

  End Operator

  ''' <summary>Inversion de la valeur d'un angle</summary>
  ''' <param name="a">Angle cible</param>
  Public Shared Operator -(ByVal a As Angle) As Angle

    Dim Result As New Angle

    Result.SetValues(-a._Value, a.Unit)
    Return Result

  End Operator

  ''' <summary>Suppression aux valeur d'un angle la valeur d'un 2ème angle</summary>
  ''' <param name="a">Angle cible</param>
  ''' <param name="b">Valeur d'angle à soustraire</param>
  Public Shared Operator -(ByVal A As Double, ByVal B As Angle) As Angle

    Dim Result As New Angle

    Result.SetValues(A - B.Value, B.Unit)

    Return Result

  End Operator

  ''' <summary>Suppression aux valeur d'un angle la valeur d'un 2ème angle</summary>
  ''' <param name="A">Angle cible</param>
  ''' <param name="B">Valeur d'angle à soustraire</param>
  Public Shared Operator -(ByVal A As Angle, ByVal B As Double) As Angle

    Dim Result As New Angle

    Result.SetValues(A.Value - B, A.Unit)

    Return Result

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator =(ByVal a As Angle, ByVal b As Angle) As Boolean

    If a.Unit = b.Unit Then
      If a.Value = b.Value Then
        Return True
      Else
        Return False
      End If
    Else
      If a.Value(UnitAngle.Radian) = b.Value(UnitAngle.Radian) Then
        Return True
      Else
        Return False
      End If
    End If

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator <>(ByVal a As Angle, ByVal b As Angle) As Boolean

    Return Not (a = b)

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator >(ByVal a As Angle, ByVal b As Angle) As Boolean

    If a.Unit = b.Unit Then
      If a.Value > b.Value Then
        Return True
      Else
        Return False
      End If
    Else
      If a.Value(UnitAngle.Radian) > b.Value(UnitAngle.Radian) Then
        Return True
      Else
        Return False
      End If
    End If

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator <(ByVal a As Angle, ByVal b As Angle) As Boolean

    If a.Unit = b.Unit Then
      If a.Value < b.Value Then
        Return True
      Else
        Return False
      End If
    Else
      If a.Value(UnitAngle.Radian) < b.Value(UnitAngle.Radian) Then
        Return True
      Else
        Return False
      End If
    End If

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator >=(ByVal a As Angle, ByVal b As Angle) As Boolean

    If a > b OrElse a = b Then
      Return True
    Else
      Return False
    End If

  End Operator

  ''' <summary>Comparateur de 2 Angles</summary>
  ''' <param name="a">1er angle</param>
  ''' <param name="b">2eme angle</param>
  Public Shared Operator <=(ByVal a As Angle, ByVal b As Angle) As Boolean

    If a < b OrElse a = b Then
      Return True
    Else
      Return False
    End If

  End Operator

#End Region
End Class