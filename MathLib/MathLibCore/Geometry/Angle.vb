Option Strict On

Namespace Geometry

  Public Class Angle

    ''' <summary>Calcule l'arc cosinus d'un angle.</summary>
    ''' <param name="Value">Angle</param>
    ''' <param name="Unit">Unité dans laquelle l'angle doit être renvoyé</param>
    Public Shared Function ACos(ByVal value As Double, ByVal Unit As MathLib.UnitAngle) As MathLib.Angle

      Return MathLib.Geometry.Angle.Convert(ACos(value), Unit)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcule l'arc cosinus d'un angle
    ''' </summary>
    ''' <param name="Value">Angle</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ACos(ByVal value As Double) As MathLib.Angle

      Dim result As New MathLib.Angle
      Dim alpha As Double

      alpha = System.Math.Acos(value)
      result.SetValues(alpha, UnitAngle.Radian)

      Return result

    End Function

    ''' <summary>Calcule l'arc sinus d'un angle.</summary>
    ''' <param name="Value">Angle</param>
    ''' <param name="Unit">Unité dans laquelle l'angle doit être renvoyé</param>
    Public Shared Function ASin(ByVal value As Double, ByVal Unit As MathLib.UnitAngle) As MathLib.Angle

      Return MathLib.Geometry.Angle.Convert(ASin(value), Unit)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul l'arc sinus d'un angle
    ''' </summary>
    ''' <param name="Value">Angle</param>
    ''' <returns>ArcSinus de l'angle</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ASin(ByVal value As Double) As MathLib.Angle

      Dim result As New MathLib.Angle
      Dim alpha As Double

      alpha = System.Math.Asin(value)
      result.SetValues(alpha, UnitAngle.Radian)

      Return result

    End Function

    ''' <summary>Calcule l'arc tangente d'un angle.</summary>
    ''' <param name="Value">Angle</param>
    ''' <param name="Unit">Unité dans laquelle l'angle doit être renvoyé</param>
    Public Shared Function ATan(ByVal value As Double, ByVal Unit As MathLib.UnitAngle) As MathLib.Angle

      Return MathLib.Geometry.Angle.Convert(ATan(value), Unit)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Calcul de l'arcTan 
    ''' </summary>
    ''' <param name="Value">Angle</param>
    ''' <returns>ArcTangeante</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ATan(ByVal value As Double) As MathLib.Angle

      Dim result As New MathLib.Angle
      Dim alpha As Double

      alpha = System.Math.Atan(value)
      result.SetValues(alpha, UnitAngle.Radian)

      Return result

    End Function

    ''' <summary>Convertie la valeur d'un angle d'une unité de meusure vers une autre.</summary>
    ''' <param name="Source">Angle à convertire</param>
    ''' <param name="Unit">Unité dans laquelle l'angle sera convertie</param>
    Public Shared Function Convert(ByVal Source As MathLib.Angle, ByVal Unit As MathLib.UnitAngle) As MathLib.Angle

      If Source.Unit = Unit Then
        Return Source
      Else
        Return New MathLib.Angle(MathLib.Common.Conversion.Angle(Source.Value, Source.Unit, Unit), Unit)
      End If

    End Function

    ''' <summary>Convertie la valeur d'un angle d'une unité de meusure vers une autre.</summary>
    ''' <param name="Source">Angle à convertire</param>
    ''' <param name="Unit">Unité dans laquelle l'angle sera convertie</param>
    ''' <param name="accuracy">
    '''    <para>Precision a appliquer lors de la conversion.</para>
    '''    <para>Cette valeur represente le nombre de chiffre après la virgule
    '''    significatifs.</para>
    ''' </param>
    Public Shared Function Convert(ByVal Source As MathLib.Angle, ByVal Unit As MathLib.UnitAngle, ByVal accuracy As Integer) As MathLib.Angle

      Dim result As New MathLib.Angle

      result.SetValues(MathLib.General.Round(Convert(Source, Unit).Value, accuracy), Unit)

      Return result

    End Function

    ''' <summary>
    '''     Renvois l'angle entre 3 points
    ''' </summary>
    ''' <returns>Angle orienté (Sens trigo) en radian entre le point 1 et le point 2</returns>
    ''' <param name="Apex" type="Mathlib.point">
    '''	<para>
    '''        Sommet des 3 points 
    '''     </para>
    ''' </param>
    ''' <param name="Pt1" type="Mathlib.point">
    '''	<para>
    '''         1er point
    '''     </para>
    ''' </param>
    ''' <param name="Pt2" type="Mathlib.point">
    '''	<para>
    '''         2eme Point
    '''     </para>
    ''' </param>
    Public Shared Function GetFromPoint(ByVal apex As MathLib.Point, _
                                        ByVal pt1 As MathLib.Point, _
                                        ByVal pt2 As MathLib.Point) _
                                        As MathLib.Angle

      Dim Vect1 As New MathLib.Vector
      Dim Vect2 As New MathLib.Vector

      ' On defini 2 vecteur Apex,Pt1 & Apex Pt2
      Vect1.SetValues(apex, pt1)
      Vect2.SetValues(apex, pt2)

      Return GetFromVector(Vect1, Vect2)

    End Function

    ''' <remarks><para>Angle orienté‚ (Sens trigo) en radian du vecteur1 vers le vecteur2</para></remarks>
    ''' <summary>Calcul l'angle entre 2 vecteurs</summary>
    ''' <returns>Angle en radiant.</returns>
    ''' <param name="vector1">1er vecteur</param>
    ''' <param name="vector2">2nd vecteur</param>
    Public Shared Function GetFromVector(ByVal vector1 As MathLib.Vector, _
                                         ByVal vector2 As MathLib.Vector) _
                                         As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim DotProduct As Double

      '-- Parameter Validation ----------------------------
      If IsNothing(vector1) Then Throw New NullReferenceException
      If IsNothing(vector2) Then Throw New NullReferenceException
      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      'Calcul : Cos(AOB) = OA.OB / ( ||OA||*||OB|| ) 

      DotProduct = MathLib.Common.Vector.DotProduct(vector1, vector2)

      Result.SetValues(MathLib.Geometry.Angle.ACos(DotProduct / (vector1.Norm * vector2.Norm)).Value)

      Return Result

    End Function

    ''' <summary>Calcul L'angle d'un vecteur avec le vecteur OX</summary>
    ''' <returns>
    '''    <para>Angle orienté‚ (Sens trigo) en radian du vecteur OX vers le vecteur
    '''    cible</para>
    ''' </returns>
    ''' <param name="Vector">Vecteur cible</param>
    Public Shared Function GetFromVector(ByVal Vector As MathLib.Vector) _
                                          As MathLib.Angle


      Dim VectorOX As New MathLib.Vector(New MathLib.Point(1.0#, 0.0#))

      Return GetFromVector(VectorOX, Vector)

    End Function

    ''' <summary>
    '''     Renvois l'angle entre 3 points
    ''' </summary>
    ''' <param name="Apex" type="Mathlib.point">
    '''     <para>
    '''        Sommet des 3 points 
    '''     </para>
    ''' </param>
    ''' <param name="Pt1" type="Mathlib.point">
    '''     <para>
    '''         1er point
    '''     </para>
    ''' </param>
    ''' <param name="Pt2" type="Mathlib.point">
    '''     <para>
    '''         2eme Point
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     Angle trigo (En radian) entre le point 1 et le point 2
    ''' </returns>
    Public Shared Function Three_Pt(ByVal Apex As MathLib.Point, _
                                    ByVal Pt1 As MathLib.Point, _
                                    ByVal Pt2 As MathLib.Point) _
                                    As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim Alpha As MathLib.Angle      ' Angle entre S et Pt_1
      Dim Beta As MathLib.Angle       ' Angle entre S et Pt_2
      Dim Gamma As MathLib.Angle
      Dim TmpDbl As Double

      ' Calcul des angles-----------------------------------------------------------------
      ' Calcul de l'angle entre l'horizontal et Pt_L_1
      Alpha = Two_Pt(Apex, Pt1)

      ' Calcul de l'angle entre l'horizontal et Pt_L_2
      Beta = Two_Pt(Apex, Pt2)

      Gamma = Beta - Alpha
      TmpDbl = MathLib.General.Modulo(Gamma.Value, 360)
      Result.SetValues(TmpDbl)

      Return Result

    End Function

    ''' <summary>
    '''     Renvois l'angle fait par 1 droite avec L'axe OX
    ''' </summary>
    ''' <param name="Pt1" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         1er point de la droite
    '''     </para>
    ''' </param>
    ''' <param name="Pt2" type="BLM.Tools.Globales.sPoint">
    '''     <para>
    '''         2eme Point de la droite
    '''     </para>
    ''' </param>
    ''' <remarks>
    ''' L'ordre des points formant la droite influent sur la valeur de l'angle
    ''' </remarks>
    ''' <returns>
    '''     Angle
    ''' </returns>
    Public Shared Function Two_Pt(ByVal Pt1 As MathLib.Point, _
                                  ByVal Pt2 As MathLib.Point) _
                                  As MathLib.Angle

      Dim Result As New MathLib.Angle
      Dim Cot_Adj As Double
      Dim Cot_Opp As Double

      Cot_Adj = Pt2.X - Pt1.X
      Cot_Opp = Pt2.Y - Pt1.Y

      If Cot_Adj = 0 And Cot_Opp = 0 Then
        Result.SetValues(0)
        Return Result
      End If

      If Cot_Adj = 0 Then
        If Cot_Opp >= 0 Then
          Result.SetValues(MathLib.Constant.PI / 2)   ' 90°
        Else
          Result.SetValues((3 * MathLib.Constant.PI) / 2)   ' 270°
        End If
        Return Result
      End If

      ' En Radian
      Result.SetValues(MathLib.Geometry.trigonometry.ATan(Cot_Opp / Cot_Adj))
      If Cot_Adj < 0 Then Result.SetValues(Result.Value + MathLib.Constant.PI)
      Result.SetValues(MathLib.General.Modulo(Result.Value, 2 * MathLib.Constant.PI))

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Renvois l'angle fait par 1 droite et 1 axe
    ''' </summary>
    ''' <param name="Pt_1">1er point de la droite</param>
    ''' <param name="Pt_2">2eme Point de la droite</param>
    ''' <param name="Axe">Axe de referance du calcule d'angle</param>
    ''' <returns>Angle en degré</returns>
    ''' <remarks>
    ''' L'ordre des points formant la droite influent sur la valeur de l'angle
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	06/06/2005	Created
    '''   [lap_y] 27/03/2006  Passé an Shared
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Two_Pt_d(ByRef Pt_1 As MathLib.Point, _
                                  ByRef Pt_2 As MathLib.Point, _
                                  ByRef Axe As General.AnglePosition3D) _
                                  As Double

      Dim Result As Double
      Dim Cot_Adj As Double
      Dim Cot_Opp As Double

      Select Case Axe
        Case General.AnglePosition3D.XOY
          Cot_Adj = Pt_2.X - Pt_1.X
          Cot_Opp = Pt_2.Y - Pt_1.Y
        Case General.AnglePosition3D.XOZ
          Cot_Adj = Pt_2.X - Pt_1.X
          Cot_Opp = Pt_2.Z - Pt_1.Z
        Case General.AnglePosition3D.YOZ
          Cot_Adj = Pt_2.Y - Pt_1.Y
          Cot_Opp = Pt_2.Z - Pt_1.Z
      End Select

      If Cot_Adj = 0 And Cot_Opp = 0 Then
        Result = 0
        GoTo FIN
      End If

      If Cot_Adj = 0 Then
        If Cot_Opp >= 0 Then
          Result = 90
        Else
          Result = 270
        End If
        GoTo FIN
      End If

      ' En Radian
      Result = MathLib.Geometry.trigonometry.ATan(Cot_Opp / Cot_Adj)

      ' En Degré
      Result = MathLib.Common.Conversion.Angle(Result, UnitAngle.Radian, UnitAngle.Degree)
      ' Le modulo permet d'avoir un engle < 360 et positif (-300° --> 60°)
      Result = MathLib.General.Modulo(Result, 360)

FIN:
      Return Result
    End Function

  End Class

End Namespace
