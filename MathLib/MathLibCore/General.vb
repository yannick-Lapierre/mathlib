Option Strict On

Public Class General

  ''' <summary>Retourne la valeur absolu d'une valeur</summary>
  ''' <param name="Value">Valeur à convertir</param>
  Public Shared Function Abs(ByVal Value As Double) As Double

    Return System.Math.Abs(Value)

  End Function

  ''' <summary>
  ''' Informe sur l'egalité entre 2 élément
  ''' </summary>
  ''' <param name="Value1">1er élément</param>
  ''' <param name="Value2">2ème élément</param>
  ''' <param name="Accuancy">Precision</param>
  ''' <returns></returns>
  Public Shared Function AreEquals(ByVal Value1 As Double, ByVal Value2 As Double, ByVal Accuancy As Short) As Boolean

    If MathLib.General.Abs(Value1 - Value2) < MathLib.General.Pow10(1, -Accuancy) Then
      Return True
    Else
      Return False
    End If

  End Function
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul du barycentre de 2 points
  ''' </summary>
  ''' <param name="Point_1">Coordonné du 1er point</param>
  ''' <param name="Point_2">coordonné du 2eme point</param>
  ''' <param name="Poids_1">Poids a affecter au 1er point</param>
  ''' <param name="Poids_2">Poids a affecter au 2eme point</param>
  ''' <returns>Coordonnée du barycentre</returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Barycentre(ByVal Point_1 As MathLib.Point, ByVal Point_2 As MathLib.Point, Optional ByVal Poids_1 As Integer = 1, Optional ByVal Poids_2 As Integer = 1) As MathLib.Point

    Dim Result As New MathLib.Point
    Dim TempSng As Double
    Dim Val_Min As Double
    Dim Val_Max As Double

    '--Pour les Abscisse--------------
    If Point_1.X < Point_2.X Then
      Val_Min = Point_1.X
      Val_Max = Point_2.X
    Else
      Val_Min = Point_2.X
      Val_Max = Point_1.X
    End If

    TempSng = Val_Max - Val_Min

    If Point_1.X < Point_2.X Then
      Result.X = Point_1.X + ((TempSng * Poids_1) / (Poids_1 + Poids_2))
    Else
      Result.X = Point_2.X + ((TempSng * Poids_2) / (Poids_1 + Poids_2))
    End If
    '---------------------------------

    '--Pour les Ordonnées-------------
    If Point_1.Y < Point_2.Y Then
      Val_Min = Point_1.Y
      Val_Max = Point_2.Y
    Else
      Val_Min = Point_2.Y
      Val_Max = Point_1.Y
    End If

    TempSng = Val_Max - Val_Min

    If Point_1.Y < Point_2.Y Then
      Result.Y = Point_1.Y + ((TempSng * Poids_1) / (Poids_1 + Poids_2))
    Else
      Result.Y = Point_2.Y + ((TempSng * Poids_2) / (Poids_1 + Poids_2))
    End If
    '---------------------------------

    Return Result

  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Arrondie un nombre dynamiquement
  ''' </summary>
  ''' <param name="Value">Valeur a arrondire</param>
  ''' <param name="Delta">
  ''' Valeur dynamique
  ''' delta = 6; 123,45678 --D 123,456
  ''' delta = 5; 123,45678 --D 123,45
  ''' delta = 4; 123,45678 --D 123,4
  ''' delta = 3; 123,45678 --D 123
  ''' delta = 2; 123,45678 --D 123
  ''' delta = 1; 123,45678 --D 123
  ''' </param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Dynamic_Rnd(ByVal Value As Double, Optional ByVal Delta As Integer = 5) As Double

    Dim Result As Double
    Dim Pd_Max As Integer
    Dim Precision As Integer
    ' Dim i As Integer
    Dim TempSng1 As Double
    '  Dim TempSng2 As Double

    ' On recherche le poid max du nombre
    Pd_Max = 0
    If Value >= 10 Then
      Do
        Pd_Max = Pd_Max + 1
        TempSng1 = (Value / (10 ^ Pd_Max))
      Loop Until TempSng1 <= 1
    End If

    ' On regle la précision
    If Pd_Max < Delta Then
      Precision = Delta - Pd_Max
    Else
      Precision = 0
    End If

    ' On arrondie
    Result = System.Math.Round(Value, Precision)

    Return Result

  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Test si une valeur passé est paire
  ''' </summary>
  ''' <param name="value">Valeur a tester</param>
  ''' <returns>True si la valeur est paire</returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function IsPaire(ByVal Value As Object) As Boolean

    Dim Result As Boolean

    If Not IsNumeric(Value) Then
      Throw New MathLib.Exception(12, "Value : '" & Value.ToString & "'")
    End If

    If ((Val(Value)) Mod 2) = 0 Then
      Result = True
    Else
      Result = False
    End If

    Return Result

  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul du modulo d'une valeur
  ''' </summary>
  ''' <param name="Valeur">Valeur dont on doit calculer le modulo</param>
  ''' <param name="sModule">Modulo a utiliser</param>
  ''' <param name="Trunc">Defini si il faut couper le resultat. Pour obtenir un entier</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Modulo(ByVal Valeur As Double, ByVal sModule As Double, Optional ByVal Trunc As Boolean = False) As Double

    Dim Result As Double
    Dim TempLng As Double

    If sModule <= 0 Then
      Result = Valeur
      GoTo FIN
    End If

    '--On fait le modulo-------------------
    TempLng = Fix(Valeur / sModule)
    Result = Valeur - (TempLng * sModule)
    '--------------------------------------
    '--On recupere une valeur positive-----
    Result = Result + sModule
    TempLng = Fix(Result / sModule)
    Result = Result - (TempLng * sModule)
    '--------------------------------------
    If Trunc Then Result = Int(Result)

FIN:

    Return Result

  End Function

  ''' <summary>
  ''' Calcul la puissance d'un nombre
  ''' </summary>
  ''' <param name="Value">Valeur de base</param>
  ''' <param name="Power">Puissance à affecter à la valeur</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function Pow(ByVal Value As Double, ByVal Power As Double) As Double
    Return Math.Pow(Value, Power)
  End Function

  ''' <summary>
  ''' Calcul la puissance 10 d'un nombre
  ''' </summary>
  ''' <param name="Value">Valeur de base</param>
  ''' <param name="Power">Puissance 10 à affecter à la valeur</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function Pow10(ByVal Value As Double, ByVal Power As Double) As Double
    Return Value * Math.Pow(10, Power)
  End Function

  ' Pythagore avec 2 Distance
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul du theoreme de pythagore a partir de 2 longueur
  ''' </summary>
  ''' <param name="Hauteur">Valeur de la hauteur</param>
  ''' <param name="Largeur">Valeur de la largeur</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	28/03/2006	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Pythagore(ByVal Hauteur As Double, ByVal Largeur As Double) As Double

    Dim TempSng1 As Double
    Dim TempSng2 As Double
    Dim Result As Double

    TempSng1 = Hauteur * Hauteur
    TempSng2 = Largeur * Largeur

    Result = MathLib.General.Sqrt(TempSng1 + TempSng2)

    Return Result

  End Function

  ' Pythagore avec 2 Points
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul du theoreme de pytagore a partir de 2 points
  ''' </summary>
  ''' <param name="Point1">1er point</param>
  ''' <param name="Point2">2eme point</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	28/03/2006	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Pythagore(ByVal Point1 As MathLib.Point, _
                                   ByVal Point2 As MathLib.Point) _
                                   As Double

    Dim Result As Double
    Dim TempSng1 As Double
    Dim TempSng2 As Double
    Dim TempSng3 As Double

    TempSng1 = Sqr(Point2.X - Point1.X)
    TempSng2 = Sqr(Point2.Y - Point1.Y)
    TempSng3 = 0   ' pour la 3D voir la classe C_Point.Lenght

    Result = MathLib.General.Sqrt(TempSng1 + TempSng2 + TempSng3)

    Return Result

  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Arrondie un nombre dynamiquement
  ''' </summary>
  ''' <param name="Value">Valeur a arrondire</param>
  ''' <param name="accuracy">
  ''' Valeur dynamique
  ''' delta = 6; 123,45678 --D 123,456
  ''' delta = 5; 123,45678 --D 123,45
  ''' delta = 4; 123,45678 --D 123,4
  ''' delta = 3; 123,45678 --D 123
  ''' delta = 2; 123,45678 --D 123
  ''' delta = 1; 123,45678 --D 123
  ''' </param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Round(ByVal value As Double, Optional ByVal accuracy As Integer = 5) As Double

    Dim Result As Double
    Dim Pd_Max As Integer
    Dim Precision As Integer
    Dim TempSng1 As Double

    ' On recherche le poid max du nombre
    Pd_Max = 0
    If value >= 10 Then
      Do
        Pd_Max = Pd_Max + 1
        TempSng1 = (value / (10 ^ Pd_Max))
      Loop Until TempSng1 <= 1
    End If

    ' On regle la précision
    If Pd_Max < accuracy Then
      Precision = accuracy - Pd_Max
    Else
      Precision = 0
    End If

    ' On arrondie
    Result = Math.Round(value, accuracy, MidpointRounding.ToEven)

    Return Result

  End Function

  ' Puissance N éme d'une valeur
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul de la puissance Néme d'une valeur
  ''' </summary>
  ''' <param name="Value">Valeur dont on veut calculer la puissance Néme</param>
  ''' <param name="Level">Niveau N de la puissance</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	28/03/2006	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Sqr(ByVal Value As Double, Optional ByVal Level As Integer = 2) As Double

    Dim Result As Double
    Dim i As Integer

    If Level = 0 Then Return 1

    Result = Value
    For i = 2 To Level
      Result = Result * Value
    Next i

    Return Result

  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Calcul de la racine N éme d'une valeur
  ''' </summary>
  ''' <param name="Value">Valeur dont on veut la racine Néme</param>
  ''' <param name="Level">Niveau N de racine a calculer</param>
  ''' <returns></returns>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	01/06/2005	Created
  '''   [lap_y] 28/03/2006  Passage en "Shared"
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Shared Function Sqrt(ByVal Value As Double, Optional ByVal Level As Integer = 2) As Double

    Dim Result As Double
    Dim i As Integer

    Result = Value
    For i = 2 To Level
      Result = System.Math.Sqrt(Result)
    Next i

    Return Result

  End Function

  Friend Shared Function ProduitCos(ByVal A As MathLib.Point, ByVal B As MathLib.Point, ByVal C As MathLib.Point) As Double
    Dim AB(2) As Double
    Dim AC(2) As Double
    AB(0) = B.X - A.X
    AB(1) = B.Y - A.Y
    AC(0) = C.X - A.X
    AC(1) = C.Y - A.Y
    Dim produit As Double = MathLib.General.Round(AB(0) * AC(1) - AB(1) * AC(0), 4)
    Return produit
  End Function

  Friend Shared Function ProduitSin(ByVal A As MathLib.Point, ByVal B As MathLib.Point, ByVal C As MathLib.Point) As Double
    Dim AB(2) As Double
    Dim BC(2) As Double
    AB(0) = B.X - A.X
    AB(1) = B.Y - A.Y
    BC(0) = C.X - B.X
    BC(1) = C.Y - B.Y
    Dim produit As Double = MathLib.General.Round(AB(0) * BC(0) + AB(1) * BC(1), 4)
    Return produit
  End Function

#Region "Unité de Mesures"

#End Region

#Region "Unité de Mesures"

  Public Enum AnglePosition3D
    XOY = 1
    XOZ = 2
    YOZ = 3
  End Enum

  ''' <summary>
  '''     Moment flechissant
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public Enum BendingMoment
    Newton_Metre
    DecaNewton_Metre
    KiloNewton_Metre
    MegaNewton_Metre
    Tonne_Metre
  End Enum

  Public Enum PlanPosition
    ' Longueur suivant l'axe X
    OX = 1
    ' Longueur suivant l'axe Y
    OY = 2
    ' Longueur suivant l'axe Z
    OZ = 3
    ' Longueur suivant le plan XOY
    XOY = 4
    ' Longueur suivant le plan XOZ
    XOZ = 5
    ' Longueur suivant le plan YOZ
    YOZ = 6
    ' Longueur en 3D
    XYZ = 7
  End Enum

  ''' <summary>
  '''     Masse volumique
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public Enum RelativeDensity
    Tonne_Metre3
  End Enum

  ''' <summary>
  '''     Effort
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public Enum Strain
    Kilogrames
    Tonnes
    Newton
    DecaNewton
    KiloNewton
    MegaNewton
  End Enum

  ''' <summary>
  '''     Contraintes
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public Enum Stress
    Mega_Pascal
  End Enum

  Public Enum Surface
    Centimetre
    Millimetre
    Meter
    Micrometre
    PicoMetre
    Kilometre
    Hectometre
    inch
    foot
    yard
    Are
    hectar
    NanoMetre
  End Enum


  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Unité de meusure de distance
  ''' </summary>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[Administrateur]	07/12/2006	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Enum UnitMetric

    ''' <summary>
    ''' Centimetre (10^-2 metre)
    ''' </summary>
    Centimetre
    ''' <summary>
    ''' Milimetre (10^-3 metre)
    ''' </summary>
    Millimetre
    ''' <summary>
    ''' Metre
    ''' </summary>
    meter
    ''' <summary>
    ''' Micrometre (10^-6 metre)
    ''' </summary>
    micrometre
    ''' <summary>
    ''' Picometre (10^-12 metre)
    ''' </summary>
    PicoMetre
    ''' <summary>
    ''' Kilometre (10^3 metre)
    ''' </summary>
    Kilometre
    ''' <summary>
    ''' Hectometre (10^2 metre)
    ''' </summary>
    hectometre
    ''' <summary>
    ''' Inch
    ''' </summary>
    inch
    ''' <summary>
    ''' Foot
    ''' </summary>
    foot
    ''' <summary>
    ''' Yard
    ''' </summary>
    yard
    ''' <summary>
    ''' Nanometre (10^-9 metre)
    ''' </summary>
    NanoMetre
  End Enum

  Public Enum Volumetry
    Centimetre
    Millimetre
    Meter
    Micrometre
    PicoMetre
    Kilometre
    Hectometre
    Inch
    Foot
    Yard
    Litre
    Centilitre
    Mililitre
    Hectolitre
    NanoMetre
  End Enum

#End Region

#Region "Declarartion Globales"

  Friend Structure Node
    Public Id As Integer
    Public Point As Point
  End Structure
  'SOMMETS D'UN TRIANGLE
  Friend Structure Triangle
    Public first As Integer
    Public second As Integer
    Public last As Integer
  End Structure

#End Region

End Class
