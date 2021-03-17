Namespace Geometry

  Public Class Circle

    ''' <summary>Aire d'un cercle</summary>
    ''' <param name="Rayon">Rayon de courbure</param>
    Public Shared Function Area(ByVal rayon As Double) As Double

      Dim Result As Double

      Result = Rayon * Rayon * MathLib.Constant.PI

      Return Result

    End Function

    ''' <summary>calcul du perimetre d'un cercle</summary>
    ''' <param name="Rayon">Rayon de courbure</param>
    Public Shared Function Perimeter(ByVal rayon As Double) As Double

      Dim Result As Double

      Result = 2 * Rayon * MathLib.Constant.PI

      Return Result

    End Function

    ''' <summary>Calcule l'equation de droite de la tangente à un point</summary>
    ''' <param name="Center">Centre du cercle</param>
    ''' <param name="TangentPt">Point de la tangente sur le cercle</param>
    ''' <returns>A MathLib.LineEquation value...</returns>
    Public Shared Function Tangent(ByVal Center As MathLib.Point, ByVal TangentPt As MathLib.Point) As MathLib.LineEquation

      Dim m As Double
      Dim a, b, c, d As Double

      ' On calcule la pente de la droite
      m = (TangentPt.Y - Center.Y) / (TangentPt.X - Center.X)
      ' Calcul de la pente de la tangente:
      If m <> 0.0# Then
        a = -1 / m
        b = -1
      Else
        a = 1
        b = 0
      End If

      c = 0
      ' Si Y=ax+b alors b=y-ax
      d = TangentPt.Y - (a * TangentPt.X)

      Return New MathLib.LineEquation(a, b, c, d)

    End Function

    ''La fonction qui dessine un cercle à partir :
    ''- un rayon
    ''- un centre
    ''- un point de depart et un point arrivée
    ''- SensTrigo , indique le sens à donner à la recuperation des valeurs
    '' retourne la liste des coordonnées 
    '''' -----------------------------------------------------------------------------
    '''' <summary>
    '''' 
    '''' </summary>
    '''' <param name="rayon"></param>
    '''' <param name="Centre"></param>
    '''' <param name="A"></param>
    '''' <param name="B"></param>
    '''' <param name="SensTrigo"></param>
    '''' <returns></returns>
    '''' <remarks>
    '''' </remarks>
    '''' <history>
    '''' 	[lap_y]	27/03/2006	Created
    ''''   [lap_y] 27/03/2006  Passage en "Shared"
    '''' </history>
    '''' -----------------------------------------------------------------------------
    'Public Function DessinCercle(ByVal rayon As Decimal, ByVal Centre As T_Point, ByVal A As T_Point, ByVal B As T_Point, Optional ByVal SensTrigo As Boolean = False) As T_Point()

    '  Dim Coef, x1, y1, x2, y2 As Decimal
    '  Dim i, DebutPos, FinPos As Integer

    '  'tableau resultat
    '  Dim Resultat() As T_Point
    '  ' Calcul de coordonnees
    '  Dim PointTbx, PointTby, CoordAx, CoordBx, CoordAy, CoordBy As Double
    '  CoordAx = Round(CDbl(A.X), 1)
    '  CoordBx = Round(CDbl(B.X), 1)
    '  CoordAy = Round(CDbl(A.Y), 1)
    '  CoordBy = Round(CDbl(B.Y), 1)
    '  x1 = rayon
    '  y1 = 0
    '  Coef = CDbl((2 * PI) / N)

    '  'enregistre toutes les valeurs
    '  For i = 0 To N - 1
    '    x2 = CDbl(rayon * Cos(Coef * i))
    '    y2 = CDbl(rayon * Sin(Coef * i))
    '    ReDim Preserve Resultat(i)
    '    Resultat(i).X = x2 + Centre.X
    '    Resultat(i).Y = y2 + Centre.Y
    '    PointTbx = Round(x2 + Centre.X, 1)
    '    PointTby = Round(y2 + Centre.Y, 1)

    '    If ((PointTbx = CoordAx) And (PointTby = CoordAy)) Then
    '      'donne la position du point de depart sur le cercle
    '      DebutPos = i
    '    End If
    '    If ((PointTbx = CoordBx) And (PointTby = CoordBy)) Then
    '      'donne la position du point de depart sur le cercle
    '      FinPos = i
    '    End If
    '    x1 = x2
    '    y1 = y2
    '  Next
    '  'donne toutes les valeurs du cercle pour n'extraire que les points du depart jusqu'a l'arrivée    
    '  Return listerValeurs(Resultat, DebutPos, FinPos, SensTrigo)

    'End Function
    ''Determine tout les points compris entre le point de depart jusqu'au point d'arrivée
    ''necessite  : le tableau de toutes les valeurs d'un cercle
    ''             le point de debut
    ''             le point d'arrivée
    ''             le sens trigonometrique
    'Private Function listerValeurs(ByVal tab() As T_Point, ByVal Debut As Integer, ByVal fin As Integer, ByVal SensTrigo As Boolean) As T_Point()
    '  Dim i = 0, j As Integer
    '  Dim msg As String
    '  Dim ListeValeur() As T_Point

    '  i = Debut
    '  'Tant que FinPos n'est pas trouv‚e
    '  For j = 0 To N - 1
    '    If SensTrigo = True Then
    '      i = i + 1
    '      If (i = N) Then
    '        i = 0
    '      End If
    '    Else
    '      i = i - 1
    '      If (i = 0) Then
    '        i = 1200
    '      End If
    '    End If

    '    If (i = fin) Then
    '      Return ListeValeur
    '    End If

    '    ReDim Preserve ListeValeur(j)
    '    ListeValeur(j).X = tab(i).X
    '    ListeValeur(j).Y = tab(i).Y

    '  Next
    '  Dim ca As Integer
    '  ca = 0
    '  Return ListeValeur
    'End Function

    Friend Sub New()

    End Sub

    'Nombre de point sur un cercle
    Private Const N As Integer = 1200

  End Class

End Namespace
