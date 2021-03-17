''' <summary>
'''     Structure representant un point pondéré (Point affecté d'une masse).
''' </summary>
Public Structure WeightedPoint
  ''' <summary>
  '''     Coordoné du point
  ''' </summary>
  Dim Point As MathLib.Point
  ''' <summary>
  '''     Poids associé au point.
  ''' </summary>
  Dim Weight As Double

  ''' <summary>
  '''     Définition de l'élément
  ''' </summary>
  ''' <param name="X" type="double">
  '''     <para>
  '''         Valeur pour l'axe X
  '''     </para>
  ''' </param>
  ''' <param name="Y" type="double">
  '''     <para>
  '''         Valeur pour l'axe Y
  '''     </para>
  ''' </param>
  ''' <param name="Weight" type="double">
  '''     <para>
  '''         Poids associé au point
  '''     </para>
  ''' </param>
  Sub SetValues(ByVal X As Double, ByVal Y As Double, ByVal Weight As Double)
    Point.SetValues(X, Y)
    Me.Weight = Weight
  End Sub

  ''' <summary>
  '''     Définition de l'élément
  ''' </summary>
  ''' <param name="X" type="double">
  '''     <para>
  '''         Valeur pour l'axe X
  '''     </para>
  ''' </param>
  ''' <param name="Y" type="double">
  '''     <para>
  '''         Valeur pour l'axe Y
  '''     </para>
  ''' </param>
  ''' <param name="Z" type="double">
  '''     <para>
  '''         Valeur pour l'axe Z
  '''     </para>
  ''' </param>
  ''' <param name="Weight" type="double">
  '''     <para>
  '''         Poids associé au point
  '''     </para>
  ''' </param>
  Sub SetValues(ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal Weight As Double)
    Point.SetValues(X, Y, Z)
    Me.Weight = Weight
  End Sub

  ''' <summary>
  '''     Définition de l'élément
  ''' </summary>
  ''' <param name="Point" type="BLM.Tools.Globales.sPoint">
  '''     <para>
  '''         Coordonnées du point
  '''     </para>
  ''' </param>
  ''' <param name="Weight" type="double">
  '''     <para>
  '''         Poids associé au point
  '''     </para>
  ''' </param>
  Sub SetValues(ByVal Point As MathLib.Point, ByVal Weight As Double)
    Me.Point = Point
    Me.Weight = Weight
  End Sub

End Structure
