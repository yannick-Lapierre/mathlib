Namespace Geometry

  Public Class Polygon

    ''' <summary>Calcule les coordonnées des points d'un Poligone Parallele à un autre</summary>
    ''' <param name="Poly">Point definissant le polygone</param>
    ''' <param name="Length">
    ''' Distance (orthogonalement) entre la ligne support et la nouvelle ligne.
    ''' Positif pour une parallele a gauche de la droite support (en suivant l'orde des points du support)
    ''' Positif pour une parallele a droite de la droite support (en suivant l'orde des points du support)
    ''' </param>
    ''' <returns>Tableau de point de la Parallele; 'Nothing' si non calculé</returns>
    Public Shared Function Parallel(ByVal Poly() As MathLib.Point, ByVal Length As Double) As MathLib.Point()

      Dim TabLength() As Double
      Dim i As Integer

      ReDim TabLength(Poly.Length - 1)

      For i = 0 To Poly.Length - 1
        TabLength(i) = Length
      Next

      Return Parallel(Poly, TabLength)

    End Function

    ''' <summary>Calcule les coordonnées des points d'un Poligone Parallele à un autre</summary>
    ''' <param name="Poly">Point definissant le polygone</param>
    ''' <param name="TabLength">
    ''' Distance (orthogonalement) entre la ligne support et la nouvelle ligne.
    ''' Positif pour une parallele a gauche de la droite support (en suivant l'orde des points du support)
    ''' Positif pour une parallele a droite de la droite support (en suivant l'orde des points du support)
    ''' </param>
    ''' <returns>A MathLib.Point() value...</returns>
    Public Shared Function Parallel(ByVal Poly() As MathLib.Point, ByVal TabLength() As Double) As MathLib.Point()

      Dim TabPoint() As MathLib.Point
      Dim TabDist() As Double
      Dim result() As MathLib.Point
      Dim i As Integer

      TabPoint = Poly.Clone
      ReDim Preserve TabPoint(Poly.Length + 1)
      TabPoint(TabPoint.Length - 2) = Poly(0)
      TabPoint(TabPoint.Length - 1) = Poly(1)

      TabDist = TabLength.Clone
      ReDim Preserve TabDist(TabLength.Length)
      TabDist(TabDist.Length - 1) = TabLength(0)

      TabPoint = MathLib.Geometry.Line.Parallel(TabPoint, TabDist)

      ReDim result(Poly.Length - 1)

      result(0) = TabPoint(TabPoint.Length - 2)
      For i = 1 To result.Length - 1
        result(i) = TabPoint(i)
      Next

      Return result

    End Function

    ''' <summary>Calcule l'aire d'un poygone</summary>
    ''' <param name="Points">Sommets du polygne</param>
    Public Shared Function Area(ByVal Points() As MathLib.Point) As Double

      Dim aire As Double
      Dim N As Integer = CInt(Points.Length)

      'Croises les sommets et les soustraits entre eux
      Dim i As Integer
      For i = 0 To N - 1
        If (i < N - 1) Then
          Dim cross As Double = CDbl((Points(i).X * Points(i + 1).Y) - (Points(i + 1).X * Points(i).Y))
          aire += cross
        Else
          Return MathLib.General.Abs(aire / 2.0#)
        End If
      Next

    End Function

    ''' <summary>Calcul les coordonnées du centre de gravité d'un polygone</summary>
    ''' <param name="Points">Sommets du polygone</param>
    Public Shared Function GravityCenter(ByVal Points() As MathLib.Point) As MathLib.Point

      Dim i As Integer
      Dim TabWPt As New System.Collections.Generic.List(Of MathLib.WeightedPoint)
      Dim WPt As New MathLib.WeightedPoint

      For i = 0 To Points.Length - 1
        WPt.SetValues(Points(i), 1)
        TabWPt.Add(WPt)
      Next

      Return GravityCenter(TabWPt.ToArray)

    End Function

    ''' <summary>
    '''     Calcul les coordonnées du centre de gravité d'un polygone (Avec une ponderation des sommets)
    ''' </summary>
    ''' <param name="Points" type="BLM.Tools.Globales.sWeightedPoint()">
    '''     <para>
    '''         Sommets pondérés du polygone
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function GravityCenter(ByVal Points() As MathLib.WeightedPoint) As MathLib.Point

      Dim TabPoint As New System.Collections.Generic.List(Of MathLib.WeightedPoint)
      Dim i As Integer
      Dim xg, yg, zg, pg As Double
      Dim Result As New MathLib.Point

      TabPoint.AddRange(Points)

      If TabPoint.Count < 3 Then Throw New MathLib.Exception(11)

      ' On test les 1ers et dernieres Point pour voir si ils sont identiques
      If TabPoint(0).Point = TabPoint(TabPoint.Count - 1).Point Then
        ' Si il sont Identique on peut supprimer le dernier.
        TabPoint.RemoveAt(TabPoint.Count - 1)
      End If

      xg = 0
      yg = 0
      zg = 0
      pg = 0

      For i = 0 To TabPoint.Count - 1
        With TabPoint(i)
          xg += .Weight * .Point.X  'TabPoint(i).Point.X
          yg += .Weight * .Point.Y  'TabPoint(i).Point.Y
          zg += .Weight * .Point.Z
          pg += .Weight  'TabPoint(i).Weight
        End With
      Next

      Result.X = xg / pg 'x = (m1x1 + m2x2 + ... + mnxn)/(m1 + m2 + ... + mn)
      Result.Y = yg / pg 'y = (m1y1 + m2y2 + ... + mnyn)/(m1 + m2 + ... + mn)
      Result.Z = zg / pg

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de dire si un point se trouve dans un polygone
    ''' </summary>
    ''' <param name="Points"></param>
    ''' <param name="Tested_Pt"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Le conture du polygone est accepté
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsInPolygone(ByVal Points() As MathLib.Point, _
                                        ByVal Tested_Pt As MathLib.Point) _
                                        As Boolean

      Dim N As Integer
      N = Points.Length
      Dim cnt As Integer
      cnt = 0

      'Donne un point à l'extremité de la droite  
      Dim x2 = CSng(Rnd() * 10 + 100)
      Dim y2 = CSng(Rnd() * 10 + 100)
      Dim i As Integer
      Dim c As New MathLib.Point
      Dim d As New MathLib.Point
      Dim Test As New MathLib.Point

      c.X = Tested_Pt.X
      c.Y = Tested_Pt.Y
      i = 0
      d.X = x2
      d.Y = y2

      For i = 0 To N - 1
        If Geometry.Point.IsOnTheSegment(Points(i), Points((i + 1) Mod N), c) Then
          Return True
        End If
        Test = Geometry.Segment.Intersection(Points(i), Points((i + 1) Mod N), c, d)
        If (Test.X <> Nothing And Test.Y <> Nothing) Then
          cnt += 1
        End If
      Next

      If (cnt Mod 2 = 0) Then
        Return False
      Else
        Return True
      End If

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de dire si un point se trouve sur le perimetre d'un polygone
    ''' </summary>
    ''' <param name="Points"></param>
    ''' <param name="Tested_Pt"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Le conture du polygone est accepté
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsOnPolygone(ByVal Points() As MathLib.Point, _
                                        ByVal Tested_Pt As MathLib.Point) _
                                        As Boolean

      Dim i As Integer

      For i = 0 To Points.Length - 2
        If Geometry.Point.IsOnTheSegment(Points(i), Points(i + 1), Tested_Pt) Then Return True
      Next
      ' On test la fermeture
      If Geometry.Point.IsOnTheSegment(Points(0), Points(Points.Length - 1), Tested_Pt) Then Return True

      ' Si on ne l'a pas trouvé sur le polygone, On le dit ^^
      Return False

    End Function

    ''' <summary>Permet de dire si un point se trouve à l'exterieur du polygone</summary>
    ''' <param name="Points"></param>
    ''' <param name="Tested_Pt"></param>
    ''' <returns></returns>
    ''' <remarks>Le conture du polygone est accepté</remarks>
    Public Shared Function IsOutPolygone(ByVal Points() As MathLib.Point, _
                                         ByVal Tested_Pt As MathLib.Point) _
                                         As Boolean

      ' C'est trivial ^^

      If IsInPolygone(Points, Tested_Pt) Then
        Return False
      End If

      If IsOnPolygone(Points, Tested_Pt) Then
        Return False
      End If

      ' DQFD ^^
      Return True

    End Function

    ''' <summary>
    '''     Defini les coordonnées de la projection d'un point sur un polygone suivant un angle de base OX
    ''' </summary>
    ''' <param name="Pt" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de reference
    '''     </para>
    ''' </param>
    ''' <param name="Polygon" type="BLM.Tools.Globales.sPoint()">
    '''     <para>
    '''         Sommet du polygone cible (Celui-ci est pas fermé automatiquement)
    '''     </para>
    ''' </param>
    ''' <param name="Angle" type="double">
    '''     <para>
    '''         Angle (Trigonometrique) de la projection (Base OX)
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Object value...
    ''' </returns>
    Public Shared Function ProjectionPt(ByVal Pt As MathLib.Point, _
                                        ByVal Polygon() As MathLib.Point, _
                                        ByVal Angle As MathLib.Angle) _
                                        As MathLib.Point

      Dim Result As New MathLib.Point
      ' 2eme point de la droite support du projeté 
      Dim Pt2 As MathLib.Point
      Dim TmpPt As MathLib.Point
      Dim i As Integer
      Dim TabPt As New System.Collections.Generic.List(Of MathLib.Point)

      TabPt.AddRange(Polygon)

      ' On ajoute le 1er point a la fin de la liste (Simplification pour la boucle)
      TabPt.Add(TabPt(0))

      ' Calcul le 2eme point definissant la droite support
      Pt2 = Geometry.Point.PPR(Pt, 1, Angle)

      TmpPt = Nothing
      For i = 0 To TabPt.Count - 2
        TmpPt = Geometry.Line.Intersection(Pt, Pt2, TabPt(i), TabPt(i + 1))
        ' On verifi que le point est bien sur le segment du polygone
        If Geometry.Point.IsOnTheSegment(TabPt(i), TabPt(i + 1), TmpPt) Then
          ' On verifi que le point est bien sur la bonne partie de la droite support
          If Geometry.Angle.Two_Pt(Pt, TmpPt) = Angle Then
            ' La c'est bon, rest a verifié que l'on a pas deja trouvé un point plus proche
            If IsNothing(TmpPt) OrElse Geometry.Point.Lenght(Pt, TmpPt) < Geometry.Point.Lenght(Pt, Result) Then
              Result = TmpPt
            End If
          End If
        End If
      Next

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Classement des points d'un polygone dans le sens Trigonometrique ou Geometrique
    ''' </summary>
    ''' <param name="ordered_PT">Point ordonnées formant le polygone</param>
    ''' <param name="Orientation">Sens d'orientation desiré</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Sort_Pts(ByVal ordered_PT() As MathLib.Point, _
                                    ByVal Orientation As MathLib.AngleOrientation) _
                                    As MathLib.Point()

      Dim i As Integer
      Dim TabPT() As MathLib.Point
      Dim Count_Trigo As Integer = 0
      Dim Count_Geo As Integer = 0
      Dim Result() As MathLib.Point

      ' Points particuliers
      TabPT = ordered_PT
      ' On ajoute les point n, 1 et 2 pour pouvoir calculer les angles (n-1;n;1) et (n;1;2)
      ReDim TabPT(TabPT.Length + 1)
      TabPT(TabPT.Length - 3) = ordered_PT(ordered_PT.Length - 2)
      TabPT(TabPT.Length - 2) = ordered_PT(ordered_PT.Length - 2)
      TabPT(TabPT.Length - 1) = ordered_PT(ordered_PT.Length - 2)

      For i = 1 To ordered_PT.Length - 3
        Select Case Angle.Three_Pt(TabPT(i + 1), TabPT(i), TabPT(i + 2)).Value
          Case 0, MathLib.Constant.PI, 2 * MathLib.Constant.PI
            ' On ne fait rien
          Case Is < MathLib.Constant.PI
            ' On est dans le sens geo
            Count_Geo += 1
          Case Is > MathLib.Constant.PI
            ' on est dans le sens Trigo
            Count_Trigo += 1
          Case Is > 2 * MathLib.Constant.PI
            ' Erreur
        End Select
      Next

      If Count_Trigo = Count_Geo Then Return Nothing

      Result = ordered_PT
      ' On inverse si necessaire
      If Count_Trigo < Count_Geo Xor Orientation = MathLib.AngleOrientation.Geometric Then System.Array.Reverse(Result)

      Return Result

    End Function

  End Class

End Namespace
