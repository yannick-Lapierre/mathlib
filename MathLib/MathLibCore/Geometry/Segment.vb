Namespace Geometry

  Public Class Segment

    ''' <summary>
    '''     Calcule la distance entre entre Pt_1 et Pt_2 et le point isolé.
    ''' </summary>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point du segement
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point du segement
    '''     </para>
    ''' </param>
    ''' <param name="Isolated_Pt" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point isolé
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Single value...
    ''' </returns>
    Public Shared Function DistPoint(ByVal Pt_1 As MathLib.Point, _
                                     ByVal Pt_2 As MathLib.Point, _
                                     ByVal Isolated_Pt As MathLib.Point) _
                                     As Double

      ' permet calculer la distance à la perpendiculaire
      Dim dot1 As Integer
      Dim dot2 As Integer
      Dim dist As Double

      dist = Geometry.Line.DistPoint(Pt_1, Pt_2, Isolated_Pt)
      dot1 = CInt(General.ProduitSin(Pt_1, Pt_2, Isolated_Pt))
      dot2 = CInt(General.ProduitSin(Pt_2, Pt_1, Isolated_Pt))

      If (dot1 > 0) Then Return Geometry.Point.Lenght(Pt_2, Isolated_Pt)
      If (dot2 > 0) Then Return Geometry.Point.Lenght(Pt_1, Isolated_Pt)

      Return Math.Abs(dist)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul le point d'intersection entre 2 segments
    ''' </summary>
    ''' <param name="A">1er point du segment 1</param>
    ''' <param name="B">2éme point du segment 1</param>
    ''' <param name="C">1er point du segment 2</param>
    ''' <param name="D">2éme point du segment 2</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Intersection(ByVal A As MathLib.Point, _
                                        ByVal B As MathLib.Point, _
                                        ByVal C As MathLib.Point, _
                                        ByVal D As MathLib.Point) _
                                        As MathLib.Point

      Dim A1 As Double = A.Y - B.Y
      Dim B1 As Double = B.X - A.X
      Dim A2 As Double = C.Y - D.Y
      Dim B2 As Double = D.X - C.X
      Dim Jonction As New MathLib.Point
      Dim C1 As Double = CDbl(A1 * A.X + B1 * A.Y)
      Dim C2 As Double = CDbl(A2 * C.X + B2 * C.Y)

      Dim det As Decimal = CDec(A1 * B2 - A2 * B1)
      Dim Condi1 As Double = (Math.Round(A.X, 5) <= Math.Round(((B2 * C1 - B1 * C2) / det), 5)) And (Math.Round(((B2 * C1 - B1 * C2) / det), 5) <= Math.Round(B.X, 5))
      Dim Condi2 As Double = (Math.Round(B.X, 5) <= Math.Round(((B2 * C1 - B1 * C2) / det), 5)) And (Math.Round(((B2 * C1 - B1 * C2) / det), 5) <= Math.Round(A.X, 5))
      Dim Condi3 As Double = (Math.Round(A.Y, 5) <= Math.Round(((A1 * C2 - A2 * C1) / det), 5)) And (Math.Round(((A1 * C2 - A2 * C1) / det), 5) <= Math.Round(B.Y, 5))
      Dim Condi4 As Double = (Math.Round(B.Y, 5) <= Math.Round(((A1 * C2 - A2 * C1) / det), 5)) And (Math.Round(((A1 * C2 - A2 * C1) / det), 5) <= Math.Round(A.Y, 5))
      Dim Condi5 As Double = (Math.Round(C.X, 5) <= Math.Round(((B2 * C1 - B1 * C2) / det), 5)) And (Math.Round(((B2 * C1 - B1 * C2) / det), 5) <= Math.Round(D.X, 5))
      Dim Condi6 As Double = (Math.Round(D.X, 5) <= Math.Round(((B2 * C1 - B1 * C2) / det), 5)) And (Math.Round(((B2 * C1 - B1 * C2) / det), 5) <= Math.Round(C.X, 5))
      Dim Condi7 As Double = (Math.Round(C.Y, 5) <= Math.Round(((A1 * C2 - A2 * C1) / det), 5)) And (Math.Round(((A1 * C2 - A2 * C1) / det), 5) <= Math.Round(D.Y, 5))
      Dim Condi8 As Double = (Math.Round(D.Y, 5) <= Math.Round(((A1 * C2 - A2 * C1) / det), 5)) And (Math.Round(((A1 * C2 - A2 * C1) / det), 5) <= Math.Round(C.Y, 5))


      If (det = 0) Then
        Jonction.X = Nothing
        Jonction.Y = Nothing
      ElseIf (((Condi1 Or Condi2) And (Condi3 Or Condi4)) And ((Condi5 Or Condi6) And (Condi7 Or Condi8))) Then
        Jonction.X = (B2 * C1 - B1 * C2) / det
        Jonction.Y = (A1 * C2 - A2 * C1) / det
      End If
      Return Jonction

    End Function

    'todo A faire.
    Public Shared Function IsParallel(ByVal Line1Pt1 As MathLib.Point, ByVal Line1Pt2 As MathLib.Point, ByVal Line2Pt1 As MathLib.Point, ByVal Line2Pt2 As MathLib.Point) As Boolean



    End Function

    ''' <summary>
    '''     Calcul de la mediatrice d'un segement. La mediatrice est la droite coupant un segement en 2 parties égales.
    ''' </summary>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point du segment
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point du segement
    '''     </para>
    ''' </param>
    ''' <param name="Lenght" type="Single">
    '''     <para>
    '''         distance du point resultat avec le segement
    ''' Une valeur positive le placera a Gauche de [Pt_1,Pt_2]
    ''' Une valeur negative le placera a Droite de [Pt_1,Pt_2]
    '''     </para>
    ''' </param>
    ''' <returns>
    ''' </returns>
    Public Shared Function Mediatrix(ByVal Pt_1 As MathLib.Point, _
                                     ByVal Pt_2 As MathLib.Point, _
                                     ByVal Lenght As Double) _
                                     As MathLib.Point

      Dim Result As MathLib.Point
      Dim Ref As MathLib.Point    ' Point d'intersection entre médiatrice et segment
      Dim Alpha As MathLib.Angle

      ' Calcul du milieu du segment
      Ref = MathLib.General.Barycentre(Pt_1, Pt_2)

      ' Angle de la droite avec l'horizontal
      Alpha = Geometry.Angle.Two_Pt(Pt_1, Pt_2)

      ' Placement du point extrémité de la médiatrice
      Result = Geometry.Point.PPR(Ref, Lenght, Alpha + 90)

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcule les coordonnées des points d'un segment Parallele à un autre
    ''' </summary>
    ''' <param name="TabPts">Tableau de point du segment support</param>
    ''' <param name="Distance">
    ''' Distance (orthogonalement) entre le segment support et le nouveau segment.
    ''' Positif pour une parallele a gauche du segment support (en suivant l'orde des points du support)
    ''' Positif pour une parallele a droite du segment support (en suivant l'orde des points du support)
    ''' </param>
    ''' <returns>Tableau de point de la Parallele; 'Nothing' si non calculé</returns>
    ''' <remarks>
    ''' Indice de la 1ere valueur utils des tableau = 1
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	05/09/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Parallel(ByVal TabPts() As MathLib.Point, _
                                    ByVal Distance As Double) _
                                    As MathLib.Point()

      Dim Result() As MathLib.Point
      Dim Pt1 As MathLib.Point
      Dim Pt2 As MathLib.Point
      ' Tableau contenant les points des lignes Paralelle (Points de la ligne, Ligne)
      Dim TabLines(,) As MathLib.Point

      ' Si le tableau de point d'entré est vide ou possede moins de 2 point, on leve une execption
      If TabPts Is Nothing Then
        Throw New MathLib.Exception(0)
      ElseIf TabPts.Length < 3 Then   '	0,1,2
        Throw New MathLib.Exception(0)
      End If

      ReDim TabLines(1, TabPts.Length - 2)

      ' On calcul les droite
      For i As Integer = 1 To TabPts.Length - 2
        Pt1 = TabPts(i)
        Pt2 = TabPts(i + 1)

        ' On calcule un point Extrieur au segment dans le prolongement de celui-ci de la longueur voulue
        Pt1 = Geometry.Line.Placing_Point(TabPts(i), TabPts(i + 1), Distance)
        Pt2 = Geometry.Line.Placing_Point(TabPts(i + 1), TabPts(i), -Distance)

        ' On effectue une rotation de 90°
        TabLines(0, i) = Geometry.Point.Rotate(Pt1, TabPts(i), New MathLib.Rotation(0, 0, MathLib.Constant.PI / 2, UnitAngle.Radian))
        TabLines(1, i) = Geometry.Point.Rotate(Pt2, TabPts(i + 1), New MathLib.Rotation(0, 0, MathLib.Constant.PI / 2, UnitAngle.Radian))

      Next

      ' On Calcule les points de la //
      ' On redimentionne le tableau de resultat a sa taille finale
      ReDim Result(TabPts.Length - 1)
      ' 1er point
      Result(1) = TabLines(0, 1)
      ' Autre points (Intersection des 2 droites //)
      For i As Integer = 2 To TabPts.Length - 2
        Result(i - 1) = Geometry.Line.Intersection(TabLines(0, i - 1), TabLines(1, i - 1), TabLines(0, i), TabLines(1, i))
      Next
      ' Dernier points
      Result(Result.Length - 1) = TabLines(1, TabLines.Length - 1)

      Return Result

    End Function

  End Class

End Namespace
