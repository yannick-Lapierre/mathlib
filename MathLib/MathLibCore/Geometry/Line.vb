Option Strict On

Namespace Geometry

  Public Class Line

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
      Dim dist As Double

      dist = General.ProduitCos(Pt_1, Pt_2, Isolated_Pt) / MathLib.Geometry.Point.Lenght(Pt_1, Pt_2)

      Return Math.Abs(dist)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Donne les coefficients nécessaires à l'équation d'une droite pour l'instant en 2D du type Ax - By + Cz + D = 0
    ''' </summary>
    ''' <param name="Pt1">1er point de la droite</param>
    ''' <param name="Pt2">2ème point de la droite</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Methode :
    ''' Soit  A(xa;ya)
    '''       B(xb;yb)
    ''' Soit  M € (AB)
    '''       M(xm,ym)
    '''
    ''' vect(AB) = (xb-xa;yb-ya)
    ''' vect(AM) = (xm-xa;ym-ya)
    '''
    ''' Comme M € (AB) alors det(Vect(AM);Vect(AB)) = 0
    ''' D'ou
    ''' (AMx*ABy)-(AMy*ABx) = 0
    ''' (x-xA)(yB-yA)-(y-yA)(xB-xA) = 0
    ''' équivaut à:
    ''' (yb-ya)X - (xb-xa)Y + (xb*ya) - (xa*yb)  = 0
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function GetEquation(ByVal Pt1 As MathLib.Point, _
                                      ByVal Pt2 As MathLib.Point) _
                                      As LineEquation
      Dim Result As New LineEquation

      If (Pt1.X = Pt2.X) And (Pt1.Y = Pt2.Y) Then
        Return Nothing
      End If

      'Result.A = Pt_1.Y - Pt_2.Y
      'Result.B = Pt_2.X - Pt_1.X
      'Result.C = 0
      'Result.D = (Pt_1.X * Pt_2.Y) - (Pt_2.X * Pt_1.Y)
      Result.A = Pt2.Y - Pt1.Y
      Result.B = Pt1.X - Pt2.X
      Result.C = 0
      Result.D = (Pt2.X * Pt1.Y) - (Pt1.X * Pt2.Y)

      ' On aura toujours x >= 0
      'If Result.A < 0 Then
      '  Result.A = -Result.A
      '  Result.B = -Result.B
      '  Result.C = -Result.C
      '  Result.D = -Result.D
      'End If

      '------------------------------------------------------
FIN:
      Return Result

    End Function

    ''' <summary>Calcul le point d'intersection de 2 droites</summary>
    ''' <param name="Line1">1ere droite</param>
    ''' <param name="Line2">2eme droite</param>
    ''' <returns>A MathLib.Point value...</returns>
    Public Shared Function Intersection(ByVal Line1 As MathLib.Line, _
                                    ByVal Line2 As MathLib.Line) _
                                    As MathLib.Point

      Return Intersection(Line1.Point1, Line1.Point2, Line2.Point1, Line2.Point2)

    End Function

    ''' <summary>Calcul le point d'intersection de 2 droites</summary>
    ''' <param name="A">1er point de la Ligne 1</param>
    ''' <param name="B">2eme point de la Ligne 1</param>
    ''' <param name="C">1er point de la Ligne 2</param>
    ''' <param name="D">2eme point de la Ligne 2</param>
    ''' <returns>Nothing si aucun point d'intersection</returns>
    Public Shared Function Intersection(ByVal A As MathLib.Point, _
                                        ByVal B As MathLib.Point, _
                                        ByVal C As MathLib.Point, _
                                        ByVal D As MathLib.Point) _
                                        As MathLib.Point

      Dim A1 = A.Y - B.Y
      Dim B1 = B.X - A.X
      Dim A2 = C.Y - D.Y
      Dim B2 = D.X - C.X
      Dim Jonction As New MathLib.Point
      Dim C1 = CDbl(A1 * A.X + B1 * A.Y)
      Dim C2 = CDbl(A2 * C.X + B2 * C.Y)

      Dim det = CDec(A1 * B2 - A2 * B1)

      If (det = 0) Then
        Jonction = Nothing
      Else
        Jonction.X = (B2 * C1 - B1 * C2) / det
        Jonction.Y = (A1 * C2 - A2 * C1) / det
      End If
      Return Jonction

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de savoir si 2 lignes (ou un segements) on un point d'intersection
    ''' </summary>
    ''' <param name="Line1_Pt_1">1er point de la ligne 1</param>
    ''' <param name="Line1_Pt_2">2ème point de la ligne 1</param>
    ''' <param name="Line2_Pt_1">1er point de la ligne 2</param>
    ''' <param name="Line2_Pt_2">2ème point de la ligne 2</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	28/03/2006	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsIntersection(ByVal Line1_Pt_1 As MathLib.Point, _
                                          ByVal Line1_Pt_2 As MathLib.Point, _
                                          ByVal Line2_Pt_1 As MathLib.Point, _
                                          ByVal Line2_Pt_2 As MathLib.Point) _
                                          As Boolean

      Dim Result As Boolean

      Dim a1 As Double   'coefficient de l'equation de la droite (Line1) de la forme
      ' y=a1x+b1
      Dim a2 As Double   'coefficient de l'equation de la droite (Line2) de la forme
      ' y=a2x+b2


      Result = True

      If (Line1_Pt_1.X = Line1_Pt_2.X) And (Line2_Pt_1.X = Line2_Pt_2.X) Then Result = True

      If (Line1_Pt_1.Y = Line1_Pt_2.Y) And (Line2_Pt_1.Y = Line2_Pt_2.Y) Then Result = True

      If ((Line1_Pt_1.X <> Line1_Pt_2.X) And (Line2_Pt_1.X <> Line1_Pt_2.X)) And _
         ((Line1_Pt_1.Y <> Line1_Pt_2.Y) And (Line2_Pt_1.Y <> Line2_Pt_2.Y)) Then

        a1 = (Line1_Pt_1.Y - Line1_Pt_2.Y) / (Line1_Pt_1.X - Line1_Pt_2.X)
        a2 = (Line2_Pt_2.Y - Line2_Pt_1.Y) / (Line2_Pt_2.X - Line2_Pt_1.X)

        If (a1 = a2) Then Result = False

      End If

      Return Result

    End Function

    ''' <summary>
    '''     Informe sur le paralélisme de 2 Droite
    ''' </summary>
    ''' <param name="Line1Pt1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la 1ére droite
    '''     </para>
    ''' </param>
    ''' <param name="Line1Pt2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point de la 1ére droite
    '''     </para>
    ''' </param>
    ''' <param name="Line2Pt1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la 2ème droite
    '''     </para>
    ''' </param>
    ''' <param name="Line2Pt2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème point de la 2ème droite
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Boolean value...
    ''' </returns>
    Public Shared Function IsParallel(ByVal Line1Pt1 As MathLib.Point, _
                                      ByVal Line1Pt2 As MathLib.Point, _
                                      ByVal Line2Pt1 As MathLib.Point, _
                                      ByVal Line2Pt2 As MathLib.Point) _
                                      As Boolean

      Dim EqD1 As MathLib.LineEquation
      Dim EqD2 As MathLib.LineEquation

      EqD1 = GetEquation(Line1Pt1, Line1Pt2)
      EqD2 = GetEquation(Line2Pt1, Line2Pt2)

      If EqD1.D = EqD2.D Then
        Return True
      Else
        Return False
      End If

    End Function

    ''' <summary>
    ''' Calcule les coordonnées des points d'une ligne Parallele a une autre
    ''' </summary>
    ''' <param name="TabPts">Tableau de point de la ligne support</param>
    ''' <param name="Length">
    ''' Distance (orthogonalement) entre la ligne support et la nouvelle ligne.
    ''' Positif pour une parallele a gauche de la droite support (en suivant l'orde des points du support)
    ''' Positif pour une parallele a droite de la droite support (en suivant l'orde des points du support)
    ''' </param>
    ''' <returns>Tableau de point de la Parallele; 'Nothing' si non calculé</returns>
    Public Shared Function Parallel(ByVal TabPts() As MathLib.Point, _
                                    ByVal Length() As Double) _
                                    As MathLib.Point()

      '-- Parameter Validation ----------------------------
      If IsNothing(TabPts) Then Throw New NullReferenceException("TabPts")
      If IsNothing(Length) Then Throw New NullReferenceException("Length")
      If TabPts.Length < 2 Then Throw New MathLib.Exception(0)
      If TabPts.Length - 1 <> Length.Length Then Throw New MathLib.Exception(0)
      '-- Internal Data Validation ------------------------
      '-- Exit Case ---------------------------------------
      '----------------------------------------------------

      Dim Result() As MathLib.Point
      ' Tableau contenant les points des lignes Paralelle (Points de la ligne, Ligne)
      Dim TabLines() As MathLib.Line
      Dim TmpLine As MathLib.Line
      Dim IntersectionPt As MathLib.Point

      ReDim TabLines(TabPts.Length - 2)
      ReDim Result(TabPts.Length - 1)

      ' On calcul les droite
      For i As Integer = 0 To TabPts.Length - 2
        TmpLine = New MathLib.Line(TabPts(i), TabPts(i + 1))
        If TmpLine.HasMixedPoint Then Throw New MathLib.Exception(500)
        TabLines(i) = MathLib.Geometry.Line.Parallel(TmpLine, Length(i))
      Next

      Result(0) = TabLines(0).Point1
      ' On calcul les intersections
      For i = 1 To Result.Length - 2
        IntersectionPt = MathLib.Geometry.Line.Intersection(TabLines(i - 1), TabLines(i))
        If IsNothing(IntersectionPt) Then
          ' Les droites sont //
          Result(i) = TabLines(i).Point1
        Else
          Result(i) = IntersectionPt
        End If

      Next
      Result(Result.Length - 1) = TabLines(TabLines.Length - 1).Point2

      Return Result

    End Function

    ''' <summary>Calcul la parallele a une ligne brisé</summary>
    ''' <param name="TabPts">Point composant la ligne brisé</param>
    ''' <param name="Length">
    ''' Distance (orthogonalement) entre la ligne support et la nouvelle ligne.
    ''' Positif pour une parallele a gauche de la droite support (en suivant l'orde des points du support)
    ''' Positif pour une parallele a droite de la droite support (en suivant l'orde des points du support)
    ''' </param>
    ''' <returns>A MathLib.Point() value...</returns>
    Public Shared Function Parallel(ByVal TabPts() As MathLib.Point, _
                                ByVal Length As Double) _
                                As MathLib.Point()

      '-- Parameter Validation ----------------------------
      If IsNothing(TabPts) Then Throw New NullReferenceException("TabPts")
      If TabPts.Length < 2 Then Throw New MathLib.Exception(0)
      '-- Internal Data Validation ------------------------
      '-- Exit Case ---------------------------------------
      If Length = 0.0# Then Return TabPts
      '----------------------------------------------------

      Dim TabLength() As Double
      Dim i As Integer

      ReDim TabLength(TabPts.Length - 2)
      For i = 0 To TabPts.Length - 2
        TabLength(i) = Length
      Next

      Return Parallel(TabPts, TabLength)

    End Function


    ''' <summary>Calcul la parallele à une droite</summary>
    ''' <returns>A MathLib.Line value...</returns>
    ''' <param name="targetLine">Ligne de reference</param>
    ''' <param name="Length">
    '''    <para>Distance (orthogonalement) entre la ligne support et la nouvelle
    '''    ligne.</para>
    '''    <para>Positif pour une parallele à gauche de la droite support (en suivant l'orde
    '''    des points du support)<br />
    '''    Négatif pour une parallele à droite de la droite support (en suivant l'orde des
    '''    points du support)</para>
    ''' </param>
    Public Shared Function Parallel(ByVal targetLine As MathLib.Line, ByVal Length As Double) As MathLib.Line

      Dim Result As New MathLib.Line
      Dim TmpVect As MathLib.Vector
      Dim Rotation As New MathLib.Rotation

      '-- Parameter Validation ----------------------------
      If IsNothing(targetLine) Then Throw New NullReferenceException("targetLine")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------
      If Length = 0 Then Return targetLine.Clone
      '----------------------------------------------------

      ' 1er Point
      TmpVect = targetLine.ToVector
      Rotation.SetValues(New MathLib.Angle(90, UnitAngle.Degree))
      TmpVect = MathLib.Common.Vector.RotateAroundBase(TmpVect, Rotation)
      Result.Point1 = MathLib.Geometry.Point.Translation(targetLine.Point1, TmpVect, Length)

      ' 2eme Point
      TmpVect = targetLine.ToVector.Reverse
      Rotation.SetValues(New MathLib.Angle(-90, UnitAngle.Degree))
      TmpVect = MathLib.Common.Vector.RotateAroundBase(TmpVect, Rotation)
      Result.Point2 = MathLib.Geometry.Point.Translation(targetLine.Point2, TmpVect, Length)

      Return Result

    End Function

    ''' <summary>
    ''' Defini un point grâce à un point de départ,un point permettant d'avoir une ligne
    ''' porteuse et une longueur entre le point de départ et le point cherché. 
    ''' </summary>
    ''' <param name="Start_Point" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de depart
    '''     </para>
    ''' </param>
    ''' <param name="Alignment_Point" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point d'alignement
    '''     </para>
    ''' </param>
    ''' <param name="Lenght" type="Single">
    '''     <para>
    '''         Distance avec le point de depart (en direction opposé du point d'alignement)
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function Placing_Point(ByVal Start_Point As MathLib.Point, _
                                        ByVal Alignment_Point As MathLib.Point, _
                                        ByVal Lenght As Double) _
                                        As MathLib.Point

      Dim Result As New MathLib.Point
      Dim L As Double    ' Longueur entre Start_Point et Alignment_Point
      Dim Alpha As Double    ' Angle nécessaire pour utiliser le PPR
      Dim Beta As Double   ' Angle Intermédiaire afin de trouver Alpha
      Dim TmpDbl As Double

      ' Calcul de la distance Start_Point-Alignment_Point----------------------------------
      L = (MathLib.Geometry.Point.Lenght(Start_Point, Alignment_Point))

      If L = 0 Then Throw New MathLib.Exception(10)

      ' Calcul de l'angle-----------------------------------------------------------------
      If (Alignment_Point.Y = Start_Point.Y) Then
        If (Alignment_Point.X > Start_Point.X) Then
          If (Lenght > 0) Then
            Alpha = MathLib.Constant.PI
          Else
            Alpha = 0
          End If
        Else
          If (Lenght > 0) Then
            Alpha = 0
          Else
            Alpha = MathLib.Constant.PI
          End If
        End If
      End If

      If (Alignment_Point.X = Start_Point.X) Then
        If (Alignment_Point.Y > Start_Point.Y) Then
          If (Lenght > 0) Then
            Alpha = (3 * MathLib.Constant.PI) / 2
          Else
            Alpha = MathLib.Constant.PI / 2
          End If
        Else
          If (Lenght > 0) Then
            Alpha = MathLib.Constant.PI / 2
          Else
            Alpha = (3 * MathLib.Constant.PI) / 2
          End If
        End If
      End If

      If (Start_Point.Y > Alignment_Point.Y) Then
        If (Start_Point.X < Alignment_Point.X) Then
          If (Lenght > 0) Then
            TmpDbl = (Alignment_Point.X - Start_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = MathLib.Constant.PI - Beta
          Else
            TmpDbl = (Alignment_Point.X - Start_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = (2 * MathLib.Constant.PI) - Beta
          End If
        Else
          If (Lenght > 0) Then
            TmpDbl = (Start_Point.X - Alignment_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = Beta
          Else
            TmpDbl = (Start_Point.X - Alignment_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = Beta + MathLib.Constant.PI
          End If
        End If
      Else
        If (Start_Point.X < Alignment_Point.X) Then
          If (Lenght > 0) Then
            TmpDbl = (Alignment_Point.X - Start_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = MathLib.Constant.PI + Beta
          Else
            TmpDbl = (Alignment_Point.X - Start_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = Beta
          End If
        Else
          If (Lenght > 0) Then
            TmpDbl = (Start_Point.X - Alignment_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = (2 * MathLib.Constant.PI) - Beta
          Else
            TmpDbl = (Start_Point.X - Alignment_Point.X) / L
            Beta = MathLib.Geometry.Angle.ACos(TmpDbl).Value
            Alpha = MathLib.Constant.PI - Beta
          End If
        End If
      End If

      ' Placement du point-----------------------------------------------------------------
      Dim Angle As New MathLib.Angle
      Angle.SetValues(Alpha)
      Result = MathLib.Geometry.Point.PPR(Start_Point, System.Math.Abs(Lenght), Angle)

      Return Result

    End Function

  End Class

End Namespace
