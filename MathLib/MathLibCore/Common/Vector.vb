Option Explicit On

Namespace Common

  Public Class Vector

    ''' <summary>
    '''     Calcul du produit scalaire de 2 vecteurs
    ''' </summary>
    ''' <param name="U" type="MathLib.Vector">
    '''     <para>
    '''         1er vecteur
    '''     </para>
    ''' </param>
    ''' <param name="V" type="MathLib.Vector">
    '''     <para>
    '''         2ème vecteur
    '''     </para>
    ''' </param>
    Public Shared Function DotProduct(ByVal U As MathLib.Vector, ByVal V As MathLib.Vector) As Double

      Dim Pt1 As MathLib.Point
      Dim Pt2 As MathLib.Point

      Pt1 = U.ZeroBasedVector.EndPoint
      Pt2 = V.ZeroBasedVector.EndPoint

      ' Calcul Matriciel.
      '
      '                    [Vx]
      ' U.V = [Ux Uy Uz] . [Vy]
      '                    [Vz]

      Return Pt1.X * Pt2.X + Pt1.Y * Pt2.Y + Pt1.Z * Pt2.Z

    End Function

    ''' <summary>Calcule la rotation d'un vecteur dans l'espace.</summary>
    ''' <param name="sourceVector">Vecteur qui va subire la rotation.</param>
    ''' <param name="Base">Base de la rotation</param>
    ''' <param name="rotation">Rotation à appliquer.</param>
    Public Shared Function Rotate(ByVal sourceVector As MathLib.Vector, ByVal Base As MathLib.Point, ByVal rotation As MathLib.Rotation) As MathLib.Vector

      Dim vectBase As New MathLib.Point
      Dim vectEndpoint As New MathLib.Point

      vectBase = MathLib.Geometry.Point.Rotate(sourceVector.Base - Base, rotation)
      vectEndpoint = MathLib.Geometry.Point.Rotate(sourceVector.EndPoint - Base, rotation)

      Return New MathLib.Vector(vectBase + Base, vectEndpoint + Base)


    End Function

    ''' <summary>Calcule la rotation d'un vecteur dans l'espace.</summary>
    ''' <param name="sourceVector">Vecteur qui va subire la rotation.</param>
    ''' <param name="rotation">Rotation à appliquer.</param>
    Public Shared Function Rotate(ByVal sourceVector As MathLib.Vector, ByVal rotation As MathLib.Rotation) As MathLib.Vector

      '-- Parameter Validation ----------------------------
      If IsNothing(sourceVector) Then Throw New NullReferenceException("sourceVector")
      If IsNothing(rotation) Then Throw New NullReferenceException("rotation")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      Dim base As MathLib.Point
      Dim endpoint As MathLib.Point

      base = MathLib.Geometry.Point.Rotate(sourceVector.Base, rotation)
      endpoint = MathLib.Geometry.Point.Rotate(sourceVector.EndPoint, rotation)

      Return New MathLib.Vector(base, endpoint)

    End Function

    ''' <summary>Calcule la rotation d'un vecteur autour de sa base.</summary>
    ''' <param name="sourceVector">Vecteur qui va subire la rotation.</param>
    ''' <param name="rotation">defini les angles de rotation.<br/>
    '''    Nothing si pas de rotation sur cette axe.</param>
    ''' <returns>A MathLib.Vector value...</returns>
    Public Shared Function RotateAroundBase(ByVal sourceVector As MathLib.Vector, ByVal rotation As MathLib.Rotation) As MathLib.Vector

      Dim endPt As MathLib.Point
      Dim result As New MathLib.Vector

      endPt = MathLib.Geometry.Point.Rotate(sourceVector.EndPoint, sourceVector.Base, rotation)

      result.SetValues(sourceVector.Base, endPt)

      Return result

    End Function

    ''' <summary>
    '''      Calcul la translation d'un point suivant un vecteur
    ''' </summary>
    ''' <param name="SourceVector" type="MathLib.vector">
    '''     <para>
    '''         Vecteur à translater
    '''     </para>
    ''' </param>
    ''' <param name="Length" type="double">
    '''     <para>
    '''         Distance du nouveau Vecteur par rapport au vecteur de départ
    '''     </para>
    ''' </param>
    ''' <returns>
    ''' </returns>
    Public Shared Function Translation(ByVal SourceVector As MathLib.Vector, ByVal Length As Double) As MathLib.Vector

      Return Translation(SourceVector, SourceVector, Length)

    End Function

    ''' <summary>
    '''     Translation de vecteur
    ''' </summary>
    ''' <param name="Vect" type="MathLib.Vector">
    '''     <para>
    '''         Vecteur de réference
    '''     </para>
    ''' </param>
    ''' <param name="NewBase" type="MathLib.Point">
    '''     <para>
    '''         Nouvelle coordonées de la base du vecteur
    '''     </para>
    ''' </param>
    ''' <returns>
    ''' </returns>
    Public Shared Function Translation(ByVal Vect As MathLib.Vector, ByVal NewBase As MathLib.Point) As MathLib.Vector

      Dim Result As New MathLib.Vector

      Dim Delta As MathLib.Point

      Delta = Vect.Base - NewBase

      Result.SetValues(Vect.Base - Delta, Vect.EndPoint - Delta)

      Return Result

    End Function

    ''' <summary>
    '''      Calcul la translation d'un point suivant un vecteur
    ''' </summary>
    ''' <param name="SourceVector" type="MathLib.vector">
    '''     <para>
    '''         Vecteur à translater
    '''     </para>
    ''' </param>
    ''' <param name="GuidingVector" type="MathLib.Vector">
    '''     <para>
    '''         Vecteur support de la translation
    '''     </para>
    ''' </param>
    ''' <param name="Length" type="double">
    '''     <para>
    '''         Distance du nouveau Vecteur par rapport au vecteur de départ
    '''     </para>
    ''' </param>
    ''' <returns>
    ''' </returns>
    Public Shared Function Translation(ByVal SourceVector As MathLib.Vector, ByVal GuidingVector As MathLib.Vector, ByVal Length As Double) As MathLib.Vector

      Dim result As MathLib.Vector
      Dim ptBase As MathLib.Point
      Dim ptEnd As MathLib.Point

      ptBase = MathLib.Geometry.Point.Translation(SourceVector.Base, GuidingVector, Length)
      ptEnd = MathLib.Geometry.Point.Translation(SourceVector.EndPoint, GuidingVector, Length)

      result = New MathLib.Vector(ptBase, ptEnd)

      Return result

    End Function

    ''' <summary>
    '''     Vecteur unitaire d'un vecteur
    ''' </summary>
    ''' <param name="Vect" type="MathLib.Vector">
    '''     <para>
    '''         Vecteur cible.
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Vecteur unitaire associé au vecteur
    ''' </returns>
    Public Shared Function UnitVector(ByVal Vect As MathLib.Vector) As MathLib.Vector

      Dim Result As MathLib.Vector

      '   1
      ' ----- * v 
      ' ||v||
      Result = (1 / Vect.Norm) * Vect

      Return Result

    End Function

  End Class

End Namespace
