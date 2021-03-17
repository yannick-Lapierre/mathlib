Namespace Geometry

  Public Class Triangle

    ''' <summary>
    '''     Calcul le point de depart de la hauteur d'un triangle
    ''' </summary>
    ''' <param name="Pt_Apex" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Sommet du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_Base_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_Base_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function Altitude(ByVal Pt_Apex As MathLib.Point, _
                                    ByVal Pt_Base_1 As MathLib.Point, _
                                    ByVal Pt_Base_2 As MathLib.Point) _
                                    As MathLib.Point

      Dim Result As MathLib.Point

      Result = Geometry.Point.Orthogonal_Projection(Pt_Apex, Pt_Base_1, Pt_Base_2)

      Return Result

    End Function

    ''' <summary>
    '''     Donne un angle dans un Triangle Rectangle
    ''' </summary>
    ''' <param name="AdjLen" type="Single">
    '''     <para>
    '''         Longueur du coté Adjacent
    '''     </para>
    ''' </param>
    ''' <param name="HypoLen" type="Single">
    '''     <para>
    '''         Longueur du coté Hypotenus
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Angle en Radiant
    ''' </returns>
    Public Shared Function Angle_1(ByVal AdjLen As Double, _
                                   ByVal HypoLen As Double) _
                                   As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim TmpDbl As Double

      If (AdjLen = 0) Or (HypoLen = 0) Then
        TmpDbl = MathLib.Geometry.Angle.ACos(AdjLen / HypoLen).Value
      Else
        TmpDbl = MathLib.Geometry.Angle.ACos(AdjLen / HypoLen).Value
      End If

      Result.SetValues(TmpDbl)

      Return Result

    End Function

    ''' <summary>
    '''     Donne un angle dans un Triangle Rectangle
    ''' </summary>
    ''' <param name="OppLen" type="Single">
    '''     <para>
    '''         Longueur du coté Opposé
    '''     </para>
    ''' </param>
    ''' <param name="HypoLen" type="Single">
    '''     <para>
    '''         Longueur du coté Hypotenus
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Angle en Radiant
    ''' </returns>
    Public Shared Function Angle_2(ByVal OppLen As Double, _
                                   ByVal HypoLen As Double) _
                                   As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim TmpDbl As Double

      If (OppLen = 0) Or (HypoLen = 0) Then
        TmpDbl = 0
      Else
        TmpDbl = MathLib.Geometry.Angle.ASin(OppLen / HypoLen).Value
      End If

      Result.SetValues(TmpDbl)

      Return Result

    End Function

    ''' <summary>
    '''     Donne un angle dans un Triangle Rectangle
    ''' </summary>
    ''' <param name="AdjLen" type="Single">
    '''     <para>
    '''         Longueur du coté Adjacent
    '''     </para>
    ''' </param>
    ''' <param name="OppLen" type="Single">
    '''     <para>
    '''         Longueur du coté Opposé
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Angle en Radiant
    ''' </returns>
    Public Shared Function Angle_3(ByVal AdjLen As Double, _
                                   ByVal OppLen As Double) _
                                   As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim TmpDbl As Double

      If (AdjLen = 0) Or (OppLen = 0) Then
        TmpDbl = 0
      Else
        TmpDbl = MathLib.Geometry.Angle.ATan(OppLen / AdjLen).Value
      End If

      Result.SetValues(TmpDbl)

      Return Result

    End Function

    ''' <summary>
    '''     Calcul l'angle d'un sommet d'un triangle
    ''' </summary>
    ''' <param name="Apex" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Sommet du triangle dont on veut mesurer l'angle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     L'angle du sommet. Cette angle est en radian, non signé, est a l'interieur du triangle.
    ''' </returns>
    Public Shared Function Angle(ByVal Apex As MathLib.Point, _
                                 ByVal Pt_1 As MathLib.Point, _
                                 ByVal Pt_2 As MathLib.Point) _
                                 As MathLib.Angle

      Dim Result As MathLib.Angle
      Dim TmpDbl As Double

      Result = Geometry.Angle.Three_Pt(Apex, Pt_1, Pt_2)

      If Result.Value > MathLib.Constant.PI Then
        TmpDbl = (2 * MathLib.Constant.PI) - Result.Value
        Result.SetValues(TmpDbl)
      End If

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul de l'aire d'un triangle
    ''' </summary>
    ''' <param name="Pt1">1er point du triangle</param>
    ''' <param name="Pt2">2eme point du triangle</param>
    ''' <param name="Pt3">3eme point du triangle</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Administrateur]	28/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Area(ByVal Pt1 As MathLib.Point, _
                                ByVal Pt2 As MathLib.Point, _
                                ByVal Pt3 As MathLib.Point) _
                                As Double

      Dim Base As Double
      Dim Hauteur As Double

      ' on va tester si les poins sont aligné.
      If Geometry.Point.IsOnTheLine(Pt1, Pt2, Pt3) Then Throw New MathLib.Exception(1)

      Base = Geometry.Point.Lenght(Pt1, Pt2)
      Hauteur = Geometry.Point.Lenght(Pt3, Altitude(Pt3, Pt1, Pt2))

      Return (Base * Hauteur) / 2

    End Function

    ''' <summary>
    '''     Calcul des coordonnées de la bissectrice d'un triangle
    ''' </summary>
    ''' <param name="Pt_Apex" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Sommet du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_Base_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_Base_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function Bisectrix(ByVal Pt_Apex As MathLib.Point, _
                                    ByVal Pt_Base_1 As MathLib.Point, _
                                    ByVal Pt_Base_2 As MathLib.Point) _
                                    As MathLib.Point

      Dim Result As MathLib.Point
      Dim AB1 As Double    ' Longueur Pt_Apex-Pt_Base_1
      Dim AB2 As Double    ' Longueur Pt_Apex-Pt_Base_2
      Dim Distance As Double    ' distance entre le sommet et les points Référence
      Dim Ref_1 As MathLib.Point    ' Point de référence de la droite Pt_Apex-Pt_Base_1
      Dim Ref_2 As MathLib.Point    ' Point de référence de la droite Pt_Apex-Pt_Base_2
      Dim Bar As MathLib.Point    ' Milieu du segment [Ref_1,Ref_2]


      ' Calcul des longueurs de chaque segment-------------------------------------------
      AB1 = Geometry.Point.Lenght(Pt_Apex, Pt_Base_1)
      AB2 = Geometry.Point.Lenght(Pt_Apex, Pt_Base_2)

      ' Test pour voir quel est le plus grand coté et pour affecter une distance entre---
      ' le sommet et les points références-----------------------------------------------
      If (AB1 > AB2) Then Distance = 2 * AB1
      If (AB2 > AB1) Then Distance = 2 * AB2
      If (AB1 = AB2) Then Distance = 2 * AB1

      ' Placement des deux points références---------------------------------------------
      Ref_1 = Geometry.Line.Placing_Point(Pt_Base_1, Pt_Apex, Distance - AB1)
      Ref_2 = Geometry.Line.Placing_Point(Pt_Base_2, Pt_Apex, Distance - AB2)

      'Placement du barycentre du segment [Ref_1-Ref_2]----------------------------------
      Bar = MathLib.General.Barycentre(Ref_1, Ref_2)

      ' Point permettant de tracer la bissectrice,de plus ce point se situe sur----------
      ' le segment [Pt_Base_1,Pt_Base_2]-------------------------------------------------
      Result = Geometry.Line.Intersection(Pt_Apex, Bar, Pt_Base_1, Pt_Base_2)

      Return Result

    End Function

    ''' <summary>Calcul l'hypoténuse d'un triangle rectangle</summary>
    ''' <param name="side1">Longueur du 1er coté</param>
    ''' <param name="side2">Longueur du 2éme coté</param>
    ''' <returns>A Double value...</returns>
    Public Shared Function Hypotenuse(ByVal side1 As Double, ByVal side2 As Double) As Double

      Return MathLib.General.Sqrt(MathLib.General.Sqr(side1) + MathLib.General.Sqr(side2))

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Donne la longueur du coté Adjacent d'un Triangle
    ''' </summary>
    ''' <param name="Angle">L'angle</param>
    ''' <param name="OppLen">Longueur du coté Opposé</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Cote_Adj1(ByVal Angle As MathLib.Angle, _
                                     ByVal OppLen As Double) _
                                     As Double

      If MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), MathLib.Constant.PI) = 0 Then
        ' Calcul Impossoble (CotAdj = Hypo)
        Return 0
      End If

      If MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), MathLib.Constant.PI) = 0 Then
        Return 0
        Exit Function
      End If

      Return OppLen * System.Math.Tan(Angle.Value(UnitAngle.Radian))

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Donne la longueur du coté opposé d'un Triangle Rectangle
    ''' </summary>
    ''' <param name="Angle">Angle</param>
    ''' <param name="AdjLen">Longueur du coté Adjacent</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function Cote_Opp1(ByVal Angle As MathLib.Angle, _
                              ByVal AdjLen As Double) _
                              As Double

      If MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), MathLib.Constant.PI) = 0 Then
        Return 0
      End If

      Return AdjLen / System.Math.Tan(Angle.Value(UnitAngle.Radian))

    End Function

    ''' <summary>
    '''     Calcul de la mediane d'un triangle
    ''' </summary>
    ''' <param name="Pt_Base_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <param name="Pt_Base_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point de la base du triangle
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function Median(ByVal Pt_Base_1 As MathLib.Point, _
                                  ByVal Pt_Base_2 As MathLib.Point) _
                                  As MathLib.Point

      Dim Result As MathLib.Point

      Result = MathLib.General.Barycentre(Pt_Base_1, Pt_Base_2)

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul du perimetre d'un triangle
    ''' </summary>
    ''' <param name="Pt_1">1er point du triangle</param>
    ''' <param name="Pt_2">2eme point du triangle</param>
    ''' <param name="Pt_3">3eme point du triangle</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Perimeter(ByVal Pt_1 As MathLib.Point, _
                                     ByVal Pt_2 As MathLib.Point, _
                                     ByVal Pt_3 As MathLib.Point) _
                                     As Double

      Dim Result As Double
      Dim L_12 As Double    ' Longueur Pt_1 - Pt_2
      Dim L_13 As Double    ' Longueur Pt_1 - Pt_3
      Dim L_23 As Double    ' Longueur Pt_2 - Pt_3

      L_12 = Geometry.Point.Lenght(Pt_1, Pt_2)
      L_13 = Geometry.Point.Lenght(Pt_1, Pt_3)
      L_23 = Geometry.Point.Lenght(Pt_2, Pt_3)

      Result = L_12 + L_13 + L_23

      Return Result

    End Function

  End Class

End Namespace
