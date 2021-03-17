Namespace Geometry

  Public Class Cylinder

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul du volume d'un cylinde
    ''' </summary>
    ''' <param name="Rayon">Rayon du cylindre</param>
    ''' <param name="Dist">Longueur du cylindre</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Volume(ByVal Rayon As Double, ByVal Dist As Double) As Double

      Dim Result As Double

      Result = MathLib.Geometry.Circle.Area(Rayon) * Dist

      Return Result

    End Function


    Friend Sub New()

    End Sub

  End Class

End Namespace
