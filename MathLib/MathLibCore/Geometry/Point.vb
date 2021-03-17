Option Strict On

Namespace Geometry

  Public Class Point

    ''' <summary>Calcule le point d'intersection de 2 droites</summary>
    ''' <param name="LineEquation1">équation de la 1ere ligne</param>
    ''' <param name="LineEquation2">équation de la 2eme ligne</param>
    ''' <returns>A MathLib.Point value...</returns>
    Public Shared Function Intersection(ByVal LineEquation1 As MathLib.LineEquation, _
                                        ByVal LineEquation2 As MathLib.LineEquation) _
                                        As MathLib.Point

      Dim result As New MathLib.Point

      Dim CoefMatrix As New MathLib.Matrix(2, 2)
      Dim ValueMatrix As New MathLib.Matrix(2, 1)
      Dim ResultMatrix As MathLib.Matrix

      CoefMatrix.Item(0, 0) = LineEquation1.A
      CoefMatrix.Item(1, 0) = LineEquation2.A
      CoefMatrix.Item(0, 1) = LineEquation1.B
      CoefMatrix.Item(1, 1) = LineEquation2.B

      ValueMatrix(0, 0) = -LineEquation1.D
      ValueMatrix(1, 0) = -LineEquation2.D

      ResultMatrix = MathLib.Algebra.Matrix.Cramer(CoefMatrix, ValueMatrix)

      result.SetValues(ResultMatrix(0, 0), ResultMatrix(0, 1))

      Return result

    End Function

    ''' <summary>
    '''     Inverse l'ordre des points d'un tableau
    ''' </summary>
    ''' <param name="Tab" type="BLM.Tools.Globales.sPoint()">
    '''     <para>
    '''         Tableau de points
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Tableau de point inversé.
    ''' </returns>
    Public Shared Function Inverse(ByVal Tab() As MathLib.Point) As MathLib.Point()

      Dim i, j As Integer
      Dim Remplace() As MathLib.Point

      ReDim Remplace(Tab.Length - 1)
      j = 0
      For i = Tab.Length - 1 To 0 Step -1
        Remplace(j).X = Tab(i).X
        Remplace(j).Y = Tab(i).Y
        j += 1
      Next

      Return Remplace

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Informe si 1 point est sur une droite
    ''' </summary>
    ''' <param name="Pt_1">1er point de la ligne support</param>
    ''' <param name="Pt_2">2eme point de la ligne support</param>
    ''' <param name="Tested_Pt">point à tester</param>
    ''' <returns>True si Tested_Pt se trouve sur la droite passant par P1 et P2 </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	02/06/2005	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsOnTheLine(ByVal Pt_1 As MathLib.Point, _
                                       ByVal Pt_2 As MathLib.Point, _
                                       ByVal Tested_Pt As MathLib.Point) _
                                       As Boolean

      Dim Result As Boolean
      Dim TmpDbl As Double
      Dim Line As MathLib.LineEquation

      Result = False

      If Pt_1 = Tested_Pt Then
        Result = True
        GoTo FIN
      End If

      If Pt_2 = Tested_Pt Then
        Result = True
        GoTo FIN
      End If

      ' Equation de la droite
      Line = MathLib.Geometry.Line.GetEquation(Pt_1, Pt_2)

      ' Vérification du fait que Pt_3 soit sur la ligne

      TmpDbl = MathLib.General.Round((Line.A * Tested_Pt.X) - Tested_Pt.Y + Line.D, 4)
      If TmpDbl = 0 Then Result = True

FIN:
      Return Result

    End Function

    ''' <summary>
    '''     Informe si 1 point est sur une droite
    ''' </summary>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la ligne support
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme point de la ligne support
    '''     </para>
    ''' </param>
    ''' <param name="Tested_Pt" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         point à tester
    '''     </para>
    ''' </param>
    ''' <param name="Margin" type="Single">
    '''     <para>
    '''         Marge de tolerance (Distance max entre le point et la ligne pour etre acceptable)
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     True si Tested_Pt se trouve sur la droite passant par P1 et P2
    ''' </returns>
    Public Shared Function IsOnTheLine(ByVal Pt_1 As MathLib.Point, _
                                       ByVal Pt_2 As MathLib.Point, _
                                       ByVal Tested_Pt As MathLib.Point, _
                                       ByVal Margin As Double) _
                                       As Boolean

      Dim PPt As MathLib.Point

      If IsOnTheLine(Pt_1, Pt_2, Tested_Pt) Then
        Return True
      Else
        ' Il reste à voir si on est dans la tolerance.
        ' On calcule le projeté Orthogonal du point sur la droite
        PPt = Point.Orthogonal_Projection(Tested_Pt, Pt_1, Pt_2)
        ' On verifie que la distance entre le point et sont projeté est dans la tolerance.
        If Point.Lenght(Tested_Pt, PPt) <= Margin Then
          Return True
        Else
          Return False
        End If
      End If

    End Function

    '''  -----------------------------------------------------------------------------
    ''' <summary>
    ''' Test si un point est sur un segment.
    ''' </summary>
    ''' <param name="Pt_1">1er point du segement</param>
    ''' <param name="Pt_2">2eme point du segement</param>
    ''' <param name="Tested_Pt">Point a tester</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	29/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsOnTheSegment(ByVal Pt_1 As MathLib.Point, _
                                          ByVal Pt_2 As MathLib.Point, _
                                          ByVal Tested_Pt As MathLib.Point) _
                                          As Boolean

      Dim Dist1, Dist2, Dist3 As Double

      ' On verifie que le point est sur la droite
      If Not IsOnTheLine(Pt_1, Pt_2, Tested_Pt) Then Return False

      '-- test si le point est dans le segment ------------------------------
      ' Si c'est le cas alors la distance entre ce point et et les extremité du segment sont < a la longueur du segment.
      ' Longeur segement
      Dist1 = Point.Lenght(Pt_1, Pt_2)
      ' Longeur Pt_1, Point a tester
      Dist2 = Point.Lenght(Tested_Pt, Pt_1)
      ' Longeur Pt_2, Point a tester
      Dist3 = Point.Lenght(Tested_Pt, Pt_2)

      If Dist1 >= Dist2 And Dist1 >= Dist3 Then
        Return True
      Else
        Return False
      End If

    End Function

    ''' <summary>
    '''     Test si un point est sur un segment.
    ''' </summary>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point du segement
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme point du segement
    '''     </para>
    ''' </param>
    ''' <param name="Tested_Pt" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point a tester
    '''     </para>
    ''' </param>
    ''' <param name="Margin" type="Single">
    '''     <para>
    '''         Marge de tolerance (Distance max entre le point et la ligne pour etre acceptable)
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     True si Tested_Pt se trouve sur le segment [P1,P2]
    ''' </returns>
    Public Shared Function IsOnTheSegment(ByVal Pt_1 As MathLib.Point, _
                                          ByVal Pt_2 As MathLib.Point, _
                                          ByVal Tested_Pt As MathLib.Point, _
                                          ByVal Margin As Double) _
                                          As Boolean

      Dim PPt As MathLib.Point
      Dim LgSegment As Double
      Dim Lg1 As Double
      Dim Lg2 As Double

      If IsOnTheSegment(Pt_1, Pt_2, Tested_Pt) Then
        Return True
      Else
        ' Il reste à voir si on est dans la tolerance.
        ' On test les extremitées
        If Point.Lenght(Tested_Pt, Pt_1) <= Margin Then Return True
        If Point.Lenght(Tested_Pt, Pt_2) <= Margin Then Return True
        ' On calcule le projeté orthgonale du point sur la droite
        PPt = Point.Orthogonal_Projection(Tested_Pt, Pt_1, Pt_2)
        ' On regarde si le projeté et bien sur le segment
        LgSegment = Point.Lenght(Pt_1, Pt_2)
        Lg1 = Point.Lenght(PPt, Pt_1)
        Lg2 = Point.Lenght(PPt, Pt_2)
        If LgSegment < Lg1 Or LgSegment < Lg2 Then
          Return False
        Else
          If Point.Lenght(Tested_Pt, PPt) <= Margin Then
            Return True
          Else
            Return False
          End If
        End If
      End If

    End Function

    ''' <summary>
    '''     Calcul le longueur entre 2 points
    ''' </summary>
    ''' <param name="Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er Point
    '''     </para>
    ''' </param>
    ''' <param name="Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2ème Point
    '''     </para>
    ''' </param>
    ''' <param name="Plan" type="BLM.Tools.Globales.E_Pos_Plan">
    '''     <para>
    '''         plan Sur quelle doit etre calculé la distance
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Single value...
    ''' </returns>
    Public Shared Function Lenght(ByVal Pt_1 As MathLib.Point, _
                                  ByVal Pt_2 As MathLib.Point, _
                                  Optional ByVal Plan As General.PlanPosition = General.PlanPosition.XYZ) _
                                  As Double

      Dim Result As Double
      Dim TempSng1 As Double
      Dim TempSng2 As Double
      Dim TempSng3 As Double

      Result = 0

      TempSng1 = MathLib.General.Sqr(Pt_2.X - Pt_1.X)
      TempSng2 = MathLib.General.Sqr(Pt_2.Y - Pt_1.Y)
      TempSng3 = MathLib.General.Sqr(Pt_2.Z - Pt_1.Z)

      Select Case Plan
        Case General.PlanPosition.OX
          Result = MathLib.General.Sqrt(TempSng1)
        Case General.PlanPosition.OY
          Result = MathLib.General.Sqrt(TempSng2)
        Case General.PlanPosition.OZ
          Result = MathLib.General.Sqrt(TempSng3)
        Case General.PlanPosition.XOY
          Result = MathLib.General.Sqrt(TempSng1 + TempSng2)
        Case General.PlanPosition.XOZ
          Result = MathLib.General.Sqrt(TempSng1 + TempSng3)
        Case General.PlanPosition.YOZ
          Result = MathLib.General.Sqrt(TempSng2 + TempSng3)
        Case General.PlanPosition.XYZ
          Result = MathLib.General.Sqrt(TempSng1 + TempSng2 + TempSng3)
      End Select
      Return Result

    End Function

    ''' <summary>
    '''     Donne les coordonnées d'un point affecté d'une distance perpendiculairement à une droite 
    ''' </summary>
    ''' <param name="Pt_To_Project" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de reference
    '''     </para>
    ''' </param>
    ''' <param name="Lenght" type="Single">
    '''     <para>
    '''         Distance à affecté (Une valeur positive l'eloigne de la droite une valeur negative le rapproche)
    '''     </para>
    ''' </param>
    ''' <param name="Line_Pt_1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la droite
    '''     </para>
    ''' </param>
    ''' <param name="Line_Pt_2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme point de la droite
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A BLM.Tools.Globales.sPoint value...
    ''' </returns>
    Public Shared Function Orthogonal_Projection(ByVal Pt_To_Project As MathLib.Point, _
                                                ByVal Lenght As Double, _
                                                ByVal Line_Pt_1 As MathLib.Point, _
                                                ByVal Line_Pt_2 As MathLib.Point) _
                                                As MathLib.Point

      Dim Result As MathLib.Point
      Dim Alpha As MathLib.Angle

      Alpha = MathLib.Geometry.Angle.Two_Pt(Line_Pt_1, Line_Pt_2) + 90

      Result = MathLib.Geometry.Point.PPR(Pt_To_Project, Lenght, Alpha)

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Donne les coordonnées du projeté orthogonal d'un point sur une droite
    ''' </summary>
    ''' <param name="Pt_To_Project">Coordonées du point a projeter</param>
    ''' <param name="Line_Pt_1">1er point de la droite</param>
    ''' <param name="Line_Pt_2">2ème point de la droite</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	28/03/2006	Created
    '''   [lap_y] 28/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Orthogonal_Projection(ByVal Pt_To_Project As MathLib.Point, _
                                                  ByVal Line_Pt_1 As MathLib.Point, _
                                                  ByVal Line_Pt_2 As MathLib.Point) _
                                                  As MathLib.Point

      Dim Result As MathLib.Point
      Dim Alpha As MathLib.Angle
      Dim L_1 As Double
      Dim L_2 As Double

      Alpha = MathLib.Geometry.Angle.Three_Pt(Line_Pt_1, Line_Pt_2, Pt_To_Project)
      L_1 = Point.Lenght(Line_Pt_1, Pt_To_Project)

      L_2 = L_1 * MathLib.Geometry.trigonometry.Cos(Alpha)

      Result = Line.Placing_Point(Line_Pt_1, Line_Pt_2, -L_2)

      Return Result

    End Function

    ''' <summary>
    '''     Calcul le Point Polaire Relatif a un autre point
    ''' </summary>
    ''' <param name="Point" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de refereance
    '''     </para>
    ''' </param>
    ''' <param name="Distance" type="Single">
    '''     <para>
    '''         Distance entre le point de reference et le point polaire
    '''     </para>
    ''' </param>
    ''' <param name="Angle" type="MathLib.Angle">
    '''     <para>
    '''         Angle entre le point polaire et l'axe OX passant par le point de référence
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Coordonée du point polaire
    ''' </returns>
    Public Shared Function PPR(ByVal Point As MathLib.Point, _
                              ByVal Distance As Double, _
                              ByVal Angle As MathLib.Angle) _
                              As MathLib.Point

      Dim Result As New MathLib.Point
      Dim TempSng As Double
      Dim Alpha As Double

      Alpha = MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), 2 * MathLib.Constant.PI)
      '--Calculons le 1er point--------------------------
      ' Valeur X
      If (Alpha = MathLib.Constant.PI / 2) Or (Alpha = (3 * MathLib.Constant.PI) / 4) Then
        Result.X = Point.X
      Else
        TempSng = Distance * MathLib.Geometry.trigonometry.Cos(Alpha)
        Result.X = Point.X + TempSng
      End If

      ' Valeur Y
      If (Alpha = 0) Or (Alpha = MathLib.Constant.PI) Then
        Result.Y = Point.Y
      Else
        TempSng = Distance * MathLib.Geometry.trigonometry.Sin(Alpha)
        Result.Y = Point.Y + TempSng
      End If
      '--------------------------------------------------

      Return Result

    End Function

    ''' <summary>
    '''     Calcul le Point Polaire Relatif a un autre point en prenant un droite comme base d'angle
    ''' </summary>
    ''' <param name="Point" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de référence
    '''     </para>
    ''' </param>
    ''' <param name="DirectionPoint" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point definissant la droite porteuse
    '''     </para>
    ''' </param>
    ''' <param name="Distance" type="Single">
    '''     <para>
    '''         Distance entre le point de reference et le point polaire
    '''     </para>
    ''' </param>
    ''' <param name="Angle" type="Single">
    '''     <para>
    '''         Angle entre le point polaire et la droite porteuse
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Coordonée du point polaire
    ''' </returns>
    Public Shared Function PPR(ByVal Point As MathLib.Point, _
                               ByVal DirectionPoint As MathLib.Point, _
                               ByVal Distance As Double, _
                               ByVal Angle As MathLib.Angle) _
                               As MathLib.Point

      ' Angle entre la droite porteuse et l'axe OX 
      Dim Alpha As New MathLib.Angle
      ' Angle entre la droite porteuse et le PPR
      Dim Beta As New MathLib.Angle
      Dim TmpDbl As Double


      TmpDbl = MathLib.General.Modulo(Angle.Value(UnitAngle.Radian), 2 * MathLib.Constant.PI)
      Beta.SetValues(TmpDbl)
      ' On calcul l'angle entre OX et la droite porteuse
      TmpDbl = MathLib.Geometry.Angle.Two_Pt(Point, DirectionPoint).Value
      Alpha.SetValues(TmpDbl)

      Return PPR(Point, Distance, Alpha + Beta)

    End Function

    ''' <summary>
    '''     Defini les coordonnées de la projection d'un point sur un Segment suivant un angle de base OX
    ''' </summary>
    ''' <param name="Pt" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         Point de reference
    '''     </para>
    ''' </param>
    ''' <param name="Polygon" type="BLM.Tools.Globales.sPoint()">
    '''     <para>
    '''         Ligne brisé cible
    '''     </para>
    ''' </param>
    ''' <param name="Angle" type="Single">
    '''     <para>
    '''         Angle (Trigonometrique) de la projection (Base OX)
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Object value...
    ''' </returns>
        Public Shared Function ProjectionPt(ByVal Pt As MathLib.Point, _
                                            ByVal Polygon() As MathLib.Point, _
                                            ByVal Angle As Double) _
                                            As MathLib.Point

            Throw New NotImplementedException
            Dim Result As MathLib.Point
            Dim i As Integer

            For i = 0 To Polygon.Length - 1

            Next

            Return Result

        End Function

    ''' <summary>Calcule la rotation d'un point autour d'un autre.</summary>
    ''' <param name="sourcePoint">Point qui va subire la rotation.</param>
    ''' <param name="base">Point de reference de rotation.</param>
    ''' <param name="rotation">Angles de rotation.</param>
    Public Shared Function Rotate(ByVal sourcePoint As MathLib.Point, ByVal base As MathLib.Point, ByVal rotation As MathLib.Rotation) As MathLib.Point

      '-- Parameter Validation ----------------------------
      If IsNothing(sourcePoint) Then Throw New NullReferenceException("sourcePoint")
      If IsNothing(base) Then Throw New NullReferenceException("base")
      If IsNothing(rotation) Then Throw New NullReferenceException("rotation")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------
      If sourcePoint = base Then Return sourcePoint
      '----------------------------------------------------

      Dim result As MathLib.Point
      Dim TmpPoint As MathLib.Point

      TmpPoint = sourcePoint - base
      TmpPoint = MathLib.Geometry.Point.Rotate(TmpPoint, rotation)

      result = base + TmpPoint

      Return result

    End Function

    ''' <summary>Calcule la rotation d'un point dans l'espace.</summary>
    ''' <param name="sourcePoint">Point qui va subire la rotation.</param>
    ''' <param name="Rotation">Angles de rotation.</param>
    Public Shared Function Rotate(ByVal sourcePoint As MathLib.Point, ByVal Rotation As MathLib.Rotation) As MathLib.Point

      '-- Parameter Validation ----------------------------
      If IsNothing(sourcePoint) Then Throw New NullReferenceException("sourcePoint")
      If IsNothing(Rotation) Then Throw New NullReferenceException("rotation")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      Dim rotationMatrix As MathLib.Matrix
      Dim result As New MathLib.Point

      rotationMatrix = MathLib.Algebra.Matrix.RotationMatrix(Rotation)

      result.SetValues(rotationMatrix * MathLib.Algebra.Matrix.GetFromPoint(sourcePoint))

      Return result

    End Function

    ''' <summary>
    '''      Calcul la translation d'un point suivant un vecteur
    ''' </summary>
    ''' <param name="Point" type="MathLib.Point">
    '''     <para>
    '''         Point de depart
    '''     </para>
    ''' </param>
    ''' <param name="Vector" type="MathLib.Vector">
    '''     <para>
    '''         Vecteur support de la translation
    '''     </para>
    ''' </param>
    ''' <param name="Lenght" type="Single">
    '''     <para>
    '''         Distance du nouveau point par rapport au point de départ
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Object value...
    ''' </returns>
    Public Shared Function Translation(ByVal Point As MathLib.Point, ByVal Vector As MathLib.Vector, ByVal Lenght As Double) As MathLib.Point

      '-- Parameter Validation ----------------------------
      If IsNothing(Point) Then Throw New NullReferenceException("Point")
      If IsNothing(Vector) Then Throw New NullReferenceException("Vector")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------
      If Lenght = 0 Then Return Point
      '----------------------------------------------------

      Dim result As MathLib.Point
      Dim vect As MathLib.Vector

      vect = Lenght * MathLib.Common.Vector.UnitVector(Vector.ZeroBasedVector)

      result = Point + vect.EndPoint

      Return result

    End Function

  End Class

End Namespace
