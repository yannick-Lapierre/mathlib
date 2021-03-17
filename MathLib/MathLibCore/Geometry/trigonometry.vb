Option Explicit On
Option Strict On

Namespace Geometry

  Public Class trigonometry

    ''' <summary>
    ''' Calcule l'arc cosinus d'un angle
    ''' </summary>
    ''' <param name="value">Angle en radiant</param>
    Public Shared Function ACos(ByVal value As Double) As Double
      Return System.Math.Acos(value)
    End Function


    ''' <summary>
    ''' Calcul l'arc sinus d'un angle
    ''' </summary>
    ''' <returns>ArcSinus de l'angle</returns>
    ''' <param name="value">Angle en radiant</param>
    Public Shared Function ASin(ByVal value As Double) As Double

      Return System.Math.Asin(value)

    End Function

    ''' <summary>
    ''' Calcul de l'arcTan 
    ''' </summary>
    ''' <returns>ArcTangeante</returns>
    ''' <param name="value">Angle en radiant</param>
    Public Shared Function ATan(ByVal value As Double) As Double

      Return System.Math.Atan(value)

    End Function

    ''' <summary>
    '''     Calcul le cosinus de l'angle spécifié
    ''' </summary>
    ''' <param name="Angle" type="MathLib.Angle">
    '''     <para>
    '''         Angle en Radian
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Cosinus de l'angle
    ''' </returns>
    Public Shared Function Cos(ByVal Angle As Double) As Double

      Return Math.Cos(Angle)

    End Function

    ''' <summary>
    '''     Calcul le cosinus de l'angle spécifié
    ''' </summary>
    ''' <returns>
    '''     Cosinus de l'angle
    ''' </returns>
    ''' <param name="Angle"><para>Angle</para></param>
    Public Shared Function Cos(ByVal Angle As MathLib.Angle) As Double

      '-- Amelioration de la precision -----------------------
      Select Case Angle.Unit
        Case UnitAngle.Degree
          Select Case MathLib.General.Modulo(Angle.Value, 360)
            Case 0
              Return 1
            Case 60, 300
              Return 0.5!
            Case 90, 270
              Return 0
            Case 120, 240
              Return -0.5!
            Case 180
              Return -1
          End Select
      End Select
      '-------------------------------------------------------

      Return CSng(Math.Cos(Angle.Value(UnitAngle.Radian)))

    End Function

    ''' <summary>
    '''     Calcul la secante de l'angle spécifié
    ''' </summary>
    ''' <returns>
    '''    <para>Secante de l'angle.</para>
    '''    <para>"Double.PositiveInfinity" si Angle = 90°<br />
    '''    "Double.NegativeInfinity" si Angle = 270°</para>
    ''' </returns>
    ''' <param name="Angle"><para>Angle</para></param>
    Public Shared Function Sec(ByVal Angle As MathLib.Angle) As Double

      Dim CosAngle As Double

      CosAngle = Cos(Angle)
      If CosAngle <> 0 Then
        Return 1 / CosAngle
      Else
        If Sin(Angle) > 0 Then
          Return Double.PositiveInfinity
        Else
          Return Double.NegativeInfinity
        End If
      End If

    End Function

    ''' <summary>
    '''     Calcul la secante de l'angle spécifié
    ''' </summary>
    ''' <returns>
    '''    <para>Secante de l'angle.</para>
    '''    <para>"Double.PositiveInfinity" si Angle = 90°<br />
    '''    "Double.NegativeInfinity" si Angle = 270°</para>
    ''' </returns>
    ''' <param name="Angle"><para>Angle</para></param>
    Public Shared Function Sec(ByVal Angle As Double) As Double

      Dim CosAngle As Double

      CosAngle = Cos(Angle)
      If CosAngle <> 0 Then
        Return 1 / CosAngle
      Else
        If Sin(Angle) > 0 Then
          Return Double.PositiveInfinity
        Else
          Return Double.NegativeInfinity
        End If
      End If

    End Function

    ''' <summary>
    '''     Calcul la Cosecante de l'angle spécifié
    ''' </summary>
    ''' <returns>
    '''    <para>CoSecante de l'angle.</para>
    '''    <para>"Double.PositiveInfinity" si Angle = 0°<br />
    '''    "Double.NegativeInfinity" si Angle = 180°</para>
    ''' </returns>
    ''' <param name="Angle"><para>Angle</para></param>
    Public Shared Function CoSec(ByVal Angle As MathLib.Angle) As Double

      Dim SinAngle As Double

      SinAngle = Sin(Angle)
      If SinAngle <> 0 Then
        Return 1 / SinAngle
      Else
        If Cos(Angle) > 0 Then
          Return Double.PositiveInfinity
        Else
          Return Double.NegativeInfinity
        End If
      End If

    End Function

    ''' <summary>
    '''     Calcul la cosecante de l'angle spécifié
    ''' </summary>
    ''' <returns>
    '''    <para>cosecante de l'angle.</para>
    '''    <para>"Double.PositiveInfinity" si Angle = 90°<br />
    '''    "Double.NegativeInfinity" si Angle = 270°</para>
    ''' </returns>
    ''' <param name="Angle"><para>Angle</para></param>
    Public Shared Function CoSec(ByVal Angle As Double) As Double

      Dim SinAngle As Double

      SinAngle = Sin(Angle)
      If SinAngle <> 0 Then
        Return 1 / SinAngle
      Else
        If Cos(Angle) > 0 Then
          Return Double.PositiveInfinity
        Else
          Return Double.NegativeInfinity
        End If
      End If

    End Function

    Public Shared Function OppositeLenght(ByVal HypotenuseLen As Double, ByVal Angle As MathLib.Angle) As Double

      Dim Result As Double

      Result = MathLib.Geometry.trigonometry.Sin(Angle) * HypotenuseLen

      'Result = CSng(Math.Sin(MathLib.Common.Conversion.Angle(Angle, MathLib.UnitAngle.Degree, MathLib.UnitAngle.Radian)) * HypotenuseLen)

      Return Result

    End Function

    ''' <summary>
    '''     Calcul le sinus de l'angle spécifié
    ''' </summary>
    ''' <param name="Angle" type="MathLib.Angle">
    '''     <para>
    '''         Angle en Radian
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Sinus de l'angle
    ''' </returns>
    Public Shared Function Sin(ByVal Angle As Double) As Double

      Return Math.Sin(Angle)

    End Function

    ''' <summary>
    '''     Calcul le sinus de l'angle spécifié
    ''' </summary>
    ''' <param name="Angle" type="MathLib.Angle">
    '''     <para>
    '''         Angle en Radian
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Sinus de l'angle
    ''' </returns>
    Public Shared Function Sin(ByVal Angle As MathLib.Angle) As Double

      '-- Amelioration de la precision -----------------------
      With Angle
        Select Case .Unit
          Case UnitAngle.Degree
            Select Case MathLib.General.Modulo(Angle.Value, 360)
              Case 0, 180, 360
                Return 0
              Case 30, 150
                Return 0.5
              Case 90
                Return 1
              Case 210, 330
                Return -0.5
              Case 270
                Return -1
            End Select
            'If .Value = 0 Or .Value = 180 Or .Value = 360 Then Return 0
            'If .Value = 30 Or .Value = 150 Then Return 0.5
            'If .Value = 90 Then Return 1
            'If .Value = 210 Or .Value = 330 Then Return -0.5
            'If .Value = 270 Then Return -1
        End Select
      End With
      '-------------------------------------------------------

      Return CSng(Math.Sin(Angle.Value(UnitAngle.Radian)))

    End Function

    ''' <summary>
    '''     Calcul la Tangente de l'angle spécifié
    ''' </summary>
    ''' <param name="Angle" type="Single">
    '''     <para>
    '''         Angle en degrée
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Single value...
    ''' </returns>
    Public Shared Function Tan(ByVal Angle As Double) As Double

      Return Math.Tan(Angle)

    End Function

    ''' <summary>
    '''     Calcul la Tangente de l'angle spécifié
    ''' </summary>
    ''' <param name="Angle" type="Single">
    '''     <para>
    '''         Angle en degrée
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Single value...
    ''' </returns>
    Public Shared Function Tan(ByVal Angle As MathLib.Angle) As Double

      '-- Amelioration de la precision -----------------------
      With Angle
        Select Case .Unit
          Case UnitAngle.Degree
            If .Value = 0 Then Return 0
            If .Value = 45 Then Return 1
        End Select
      End With
      '-------------------------------------------------------

      Return CSng(Math.Tan(Angle.Value(UnitAngle.Radian)))

    End Function

  End Class

End Namespace
