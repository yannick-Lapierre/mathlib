Namespace Geometry

  Public Class Arc

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul de la longueur d'un arc. Se differencie du perimetre dans le fait que seul la partie courbe est prise en compte.
    ''' </summary>
    ''' <param name="Rayon">Rayon de courbure de l'arc</param>
    ''' <param name="Angle">Angle de l'arc</param>
    ''' <returns>Longueur de l'arc</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Lenght(ByVal Rayon As Double, _
                                  ByVal Angle As MathLib.Angle) _
                                  As Double

      Dim Result As Double
      Dim Nb_Tour As Integer

      Result = 0

      ' Nb de tour
      Nb_Tour = CInt(Angle.Value(UnitAngle.Radian)) \ CInt(2 * MathLib.Constant.PI)
      ' Reste
      Angle.SetValues(MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), 2 * MathLib.Constant.PI))

      If Nb_Tour > 0 Then
        Result = Nb_Tour * (2 * Rayon * MathLib.Constant.PI)
      End If

      Result = Result + (Rayon * Angle.Value(UnitAngle.Radian))

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' calcul du perimetre d'une arc (Rayon Compris)
    ''' </summary>
    ''' <param name="Rayon">Rayan de courbure de l'arc</param>
    ''' <param name="Angle">Angle de l'arc</param>
    ''' <returns>Perimetre d'un arc</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Perimeter(ByVal Rayon As Double, _
                                     ByVal Angle As MathLib.Angle) _
                                     As Double
      Dim Result As Double

      Result = 0
      Result = Arc.Lenght(Rayon, Angle)
      Result = Result + (2 * Rayon)

      Return Result

    End Function

  End Class

End Namespace
