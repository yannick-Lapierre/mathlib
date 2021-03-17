Public Class Mailleur

  'Public Shared Function Mailleur(ByVal Nb_Points As Integer) As Integer(,)
  '  '
  '  '   OBJET
  '  '       Mailler la surface composee de segments de droites
  '  '       Les mailles sont triangulaires
  '  '
  '  '   CONDITIONS D'UTILISATION
  '  '       - La surface est constituee de segments de droites dont les coordonnees des points sont connues 
  '  '       - La numerotation continue des points de la surface est realisee dans le sens trigonometrique
  '  '       - Pas de contrainte sur la definition du point de depart
  '  '       - Nombre minimum de points : 3
  '  '       - L'angle forme par deux cotes ne peut être un angle rentrant
  '  '         (angle dont la mesure est comprise entre 180° et 360°)
  '  '
  '  '   DATE        02/08/2004
  '  '
  '  '   VERSION     1.0
  '  '
  '  '   COMMENTAIRES VERSION
  '  '       -
  '  '
  '  '   ARGUMENTS
  '  '	Nom					Type			Designation
  '  '	Nb_Points			Integer			Nombre de points de la surface        
  '  '
  '  '   VARIABLES LOCALES
  '  '   Nom					Type			Designation
  '  '   i, j				Integer			Indices de boucles For
  '  '   Copy_Points			Integer()		Copie du tableau Points
  '  '   Nb_Elts_Points		Integer			Nombre d'elements du tableau de Nodes_Index de la serie suivante
  '  '										Une serie correspond à une suite de mailles sans cotes communs
  '  '   Nb_Triangles		Integer			Nombre de triangles necessaires pour discretiser la surface
  '  '   Nb_Nodes_Index		Integer			Nombre de Nodes_Index d'un triangle (trivial!)
  '  '   Parite				Integer			Parite du nombre d'elements du tableau Points
  '  '   Points				Integer()		Tableau de numerotation des Nodes_Index de la surface
  '  '   Triangles			Integer(,)		Tableau de numerotation des Nodes_Index des triangles
  '  '
  '  '   RETOUR        
  '  '   Nom					Type			Designation
  '  '   Triangles			Integer			Tableau de numerotation des Nodes_Index des triangles
  '  '
  '  '	FONCTIONS APPELEES
  '  '	Nom					Classe			Designation
  '  '	-					-				-
  '  '     

  '  Dim Nb_Triangles As Integer = Nb_Points - 2
  '  Dim Nb_Nodes_Index As Integer = 3

  '  Dim Points As Integer()
  '  Dim Nb_Elts_Points As Integer
  '  Dim Copy_Points As Integer()

  '  Dim Triangles As Integer(,)

  '  Dim i, j As Integer

  '  Dim Parite As Integer


  '  'CREER LE TABLEAU DE Nodes_Index DE LA SURFACE
  '  'Redimensionner le tableau
  '  ReDim Points(Nb_Points - 1)

  '  'Creer le tableau, numerotation continue
  '  For i = 0 To Nb_Points - 1
  '    Points(i) = i + 1
  '  Next

  '  ReDim Copy_Points(Points.Length - 1)
  '  ReDim Triangles(Nb_Triangles - 1, Nb_Nodes_Index - 1)

  '  j = 0

  '  Do While (Points.Length >= 3)
  '    'Copier le tableau Points vers le tableau Copy_Points
  '    Array.Copy(Points, Copy_Points, Points.Length)

  '    'Calculer le nombre d'elements du tableau de Nodes_Index de la serie suivante
  '    Nb_Elts_Points = Int(Copy_Points.Length / 2) + 1

  '    'Determiner la parite de ce nombre
  '    If (Points.Length Mod 2 = 0) Then
  '      Parite = 0
  '    Else
  '      Parite = 1
  '    End If

  '    'Definir la numerotation des Nodes_Index des triangles
  '    For i = 0 To Nb_Elts_Points - (3 - Parite)
  '      Triangles(i + j, 0) = Points(2 * i + 0)
  '      Triangles(i + j, 1) = Points(2 * i + 1)
  '      Triangles(i + j, 2) = Points(2 * i + 2)
  '    Next

  '    j += Nb_Elts_Points - (2 - Parite)

  '    'CONDITIONNER LE TABLEAU DE Nodes_Index DE LA SERIE SUIVANTE
  '    'n designe le nombre de triangles dans une serie
  '    'Les Nodes_Index d'un triangle sont numerotes de 1 à 3 dans le sens du parcours
  '    '(rappel, sens de parcours : sens trigonometrique)

  '    'Première etape, deplacer le sommet 3 du triangle n de la serie en cours
  '    'et l'element suivant du tableau (si parite = 0)
  '    For i = 0 To 1 - Parite
  '      Points(i) = Copy_Points(Copy_Points.Length - (2 - Parite - i))
  '    Next

  '    'Deuxième etape, deplacer les Nodes_Index 1 et 3 des n - 1 triangles de la serie en cours
  '    For i = 0 To Nb_Elts_Points - (3 - Parite)
  '      Points((2 - Parite) + i) = Copy_Points(2 * i)
  '    Next

  '    ReDim Preserve Points(Nb_Elts_Points - 1)
  '    ReDim Copy_Points(Nb_Elts_Points - 1)
  '  Loop

  '  Return Triangles

  'End Function

  'Friend Function Mailleur_Generique(ByVal Surface_Nodes As BLM.Tools.Math.T_Node()) As T_Point(,)
  '  '
  '  '   OBJET
  '  '       Mailler une surface composee de segments de droites
  '  '       Les mailles sont triangulaires
  '  '
  '  '   CONDITIONS D'UTILISATION
  '  '       -	La surface est constituee de segments de droites dont les coordonnees des points sont connues
  '  '       -	La numerotation des points de la surface est realisee dans le sens trigonometrique
  '  '       -	Pas de contrainte sur la definition du point de depart
  '  '       -	Nombre minimum de points : 3
  '  '
  '  '   DATE        06/08/2004
  '  '
  '  '   VERSION     1.0
  '  '
  '  '   COMMENTAIRES VERSION
  '  '       /
  '  '
  '  '   ARGUMENTS
  '  '   Nom										Type			Designation
  '  '   Surface_Nodes							T_Node			Identifiant et coordonnees des noeuds formant la surface
  '  '
  '  '   VARIABLES LOCALES
  '  '   Nom										Type			Designation
  '  '	Area									Double			Aire de la surface
  '  '	Copy_Current_Surface_Nodes_Index		Integer			Copie du tableau Current_Surface_Nodes_Index							
  '  '	Current_Surface_Nodes_Index				Integer			Indices des noeuds de la surface initiale					
  '  '	Current_Surface_Nodes_Index				Integer			Indices des noeuds de la surface courante					
  '  '	Current_Triangle_Nodes_Index			Integer			Indices des noeuds formant les sommets du triangle courant						
  '  '	Delta_Pente								Double			Difference de pente entre les cotes adjacents d'un triangle	
  '  '	i_Copy_Current_Surface_Nodes_Index		Integer			Indice courant (current index)							
  '  '	i_Current_Surface_Nodes_Index			Integer			Indice courant (current index)						
  '  '	i_Current_Triangle_Nodes_Coordinates	Integer			Indice courant (current index)							
  '  '	i_Surface_Nodes_Index					Integer			Indice courant (current index)				
  '  '	i_Triangles_Nodes_Index					Integer			Indice courant (current index)				
  '  '	Triangles_Nodes_Index					T_Triangle		Indices des noeuds formant les sommets des mailles de la surface					
  '  '	Unavailable_Sides						Boolean			Cotes non disponibles d'un triangle		
  '  '												
  '  '   RETOUR        
  '  '	Nom										Type			Designation
  '  '   Triangles_Nodes_Index					Integer			Indices des noeuds formant les sommets des triangles
  '  '

  '  Dim Surface_Nodes_Index As Integer()
  '  Dim i_Surface_Nodes_Index As Integer
  '  Dim Triangles_Nodes_Index As BLM.Tools.Math.T_Triangle()
  '  Dim i_Triangles_Nodes_Index As Integer
  '  Dim Current_Surface_Nodes_Index As Integer()
  '  Dim i_Current_Surface_Nodes_Index As Integer
  '  Dim Copy_Current_Surface_Nodes_Index As Integer()
  '  Dim i_Copy_Current_Surface_Nodes_Index As Integer
  '  Dim Current_Triangle_Nodes_Index As BLM.Tools.Math.T_Triangle
  '  Dim i_Current_Triangle_Nodes_Index As Integer
  '  Dim tableau As T_Point()
  '  ReDim tableau(2)
  '  Dim Delta_Pente As Double
  '  Dim Area As Double
  '  Dim Unavailable_Sides As Boolean()
  '  Dim Points As T_Point()
  '  Dim Copy_Points As T_Point()
  '  Dim Triangle As T_Point()
  '  Dim i As Integer
  '  Dim i_Points, i_Copy_Points As Integer
  '  Dim i_Triangles As Integer
  '  ReDim Current_Surface_Nodes_Index(Surface_Nodes.Length - 1)
  '  ReDim Copy_Current_Surface_Nodes_Index(Current_Surface_Nodes_Index.Length - 1)
  '  ReDim Triangles_Nodes_Index(Surface_Nodes.Length - 3)
  '  ReDim Points(Current_Surface_Nodes_Index.Length - 1)
  '  ReDim Copy_Points(Points.Length - 1)
  '  ReDim Unavailable_Sides(2)
  '  ReDim Triangle(2)

  '  For i = 0 To Surface_Nodes.Length - 1
  '    Current_Surface_Nodes_Index(i) = i
  '  Next

  '  'For i = 0 To Nodes_Index.Length - 1
  '  'Points(i) = Surface_Nodes(i).Point
  '  'Next
  '  'For i = 0 To 2
  '  'Unavailable_Sides(i) = True
  '  'Next

  '  Do While (Current_Surface_Nodes_Index.Length > 3)
  '    i_Current_Surface_Nodes_Index = 0
  '    'i_Copy_Current_Surface_Index = 0
  '    i_Surface_Nodes_Index = 0

  '    Do While (i_Surface_Nodes_Index <= Current_Surface_Nodes_Index.Length - 1)
  '      Delta_Pente = _
  '      (Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 2)).Point.Y - Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 0)).Point.Y) * _
  '      (Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 1)).Point.X - Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 0)).Point.X) - _
  '      (Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 1)).Point.Y - Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 0)).Point.Y) * _
  '      (Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 2)).Point.X - Surface_Nodes(Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 0)).Point.X)

  '      If (Delta_Pente <= 0) Then
  '        'ANGLE RENTRANT OU PLAT (NOEUDS ALIGNES)
  '        'Le sommet d'indice i_Nodes_Index est copie dans le tableau Copy_Nodes_Index
  '        Copy_Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index) = Current_Surface_Nodes_Index(i_Surface_Nodes_Index)
  '        'Incrementation
  '        i_Current_Surface_Nodes_Index += 1
  '        i_Surface_Nodes_Index += 1
  '      Else
  '        'ANGLE SORTANT
  '        'Sommets dans le triangle?
  '        'For i = 0 To 2
  '        'Triangle(i).X = Surface_Nodes(Nodes_Index(i_Nodes_Index + i)).Point.X
  '        'Triangle(i).Y = Surface_Nodes(Nodes_Index(i_Nodes_Index + i)).Point.Y
  '        'Next

  '        'For i = 0 To Nodes_Index.Length - 1
  '        '	Points(i).X = Surface_Nodes(Nodes_Index(i)).Point.X
  '        '	Points(i).Y = Surface_Nodes(Nodes_Index(i)).Point.Y
  '        '	Next

  '        'If (MATHEMATIQUES.Point_Into_Triangle(Triangle, Points, Unavailable_Sides) = 0) Then
  '        Copy_Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index) = Current_Surface_Nodes_Index(i_Surface_Nodes_Index)
  '        'Implementer le tableau de triangles
  '        Triangles_Nodes_Index(i_Triangles).first = Current_Surface_Nodes_Index(i_Surface_Nodes_Index)
  '        Triangles_Nodes_Index(i_Triangles).second = Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 1)
  '        Triangles_Nodes_Index(i_Triangles).last = Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 2)

  '        i_Surface_Nodes_Index += 2
  '        i_Current_Surface_Nodes_Index += 1
  '        i_Triangles += 1
  '        'Else
  '        '	'Le sommet d'indice i_Nodes_Index est dans copy_Nodes_Index
  '        '	Copy_Nodes_Index(i_Copy_Nodes_Index) = Nodes_Index(i_Nodes_Index)
  '        '	'Incrementation
  '        '	i_Copy_Nodes_Index += 1
  '        '	i_Nodes_Index += 1
  '        'End If
  '      End If

  '      'Il doit rester au moins 3 noeuds dans le tableau ou aucun
  '      If (i_Surface_Nodes_Index = Current_Surface_Nodes_Index.Length - 2) Then
  '        Local_B_M.Surface.Shift_Range(Copy_Current_Surface_Nodes_Index, i_Current_Surface_Nodes_Index, 0, 2)
  '        Copy_Current_Surface_Nodes_Index(0) = Current_Surface_Nodes_Index(i_Surface_Nodes_Index)
  '        Copy_Current_Surface_Nodes_Index(1) = Current_Surface_Nodes_Index(i_Surface_Nodes_Index + 1)

  '        ReDim Preserve Copy_Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index + 1)
  '        ReDim Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index + 1)

  '        Exit Do
  '      ElseIf (i_Surface_Nodes_Index = Current_Surface_Nodes_Index.Length - 1) Then
  '        Local_B_M.Surface.Shift_Range(Copy_Current_Surface_Nodes_Index, i_Current_Surface_Nodes_Index, 0, 1)

  '        Copy_Current_Surface_Nodes_Index(0) = Current_Surface_Nodes_Index(i_Surface_Nodes_Index)

  '        ReDim Preserve Copy_Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index)
  '        ReDim Current_Surface_Nodes_Index(i_Current_Surface_Nodes_Index)
  '      End If
  '    Loop

  '    Array.Copy(Copy_Current_Surface_Nodes_Index, Current_Surface_Nodes_Index, Copy_Current_Surface_Nodes_Index.Length)

  '  Loop

  '  'Implementer le tableau de triangles
  '  Triangles_Nodes_Index(i_Triangles).first = Current_Surface_Nodes_Index(0)
  '  Triangles_Nodes_Index(i_Triangles).second = Current_Surface_Nodes_Index(1)
  '  Triangles_Nodes_Index(i_Triangles).last = Current_Surface_Nodes_Index(2)

  '  Dim tableau2 As T_Point(,)

  '  ReDim tableau2(Triangles_Nodes_Index.Length - 1, 2)

  '  For i = 0 To Triangles_Nodes_Index.Length - 1
  '    tableau2(i, 0) = Surface_Nodes(Triangles_Nodes_Index(i).first).Point
  '    tableau2(i, 1) = Surface_Nodes(Triangles_Nodes_Index(i).second).Point
  '    tableau2(i, 2) = Surface_Nodes(Triangles_Nodes_Index(i).last).Point
  '  Next

  '  Return tableau2

  'End Function

End Class
