Namespace Geometry

  Public Class Surface

    Public Function Circular_Permutation_Elts(ByVal Array As Integer(), _
                                              ByVal Shift As Integer) _
                                              As Integer()
      '
      '   OBJET
      '		Permutation circulaire d'elements de tableau
      '
      '   CONDITIONS D'UTILISATION	
      '		-
      '
      '   DATE        23/08/2004
      '
      '   VERSION     1.0
      '
      '   COMMENTAIRES VERSION
      '       -
      '
      '   ARGUMENTS
      '   Nom								Type						Designation
      '	Array       					Integer()       			Tableau d'origine
      '	Shift				            Integer                     Decaler de 'Shift' elements
      '
      '	VARIABLES LOCALES
      '	Copy_Index			            Integer()	                Copie du tableau Index
      '	i					            Integer		                Indice de manipulation de Tableaux
      '	Index				            Integer()	                Tableau d'indices
      '
      '   RETOUR
      '   Nom								Type						Designation
      '	Array							Integer()					Tableau après operation
      '
      '	FONCTIONS APPELEES
      '   Nom								Classe						Designation
      '	-								-							-
      '
      '	METHODOLOGIE
      '	-
      '

      Dim i As Integer
      ' Dim Index As Integer()
      Dim Copy_array As Double()

      ReDim Copy_array(Array.Length - 1)

      System.Array.Copy(Array, Copy_array, Array.Length)

      For i = 0 To Array.Length - 1
        Array((i + Shift) - Int((i + Shift) / Array.Length) * Array.Length) = Copy_array(i)
      Next

      Return Array

    End Function
    Public Function Circular_Permutation_Index(ByVal Array_Length As Integer, _
                                               ByVal Shift As Integer) _
                                               As Integer()
      '
      '   OBJET
      '		Permutation circulaire d'elements de tableau
      '
      '   CONDITIONS D'UTILISATION	
      '		-
      '
      '   DATE        23/08/2004
      '
      '   VERSION     1.0
      '
      '   COMMENTAIRES VERSION
      '       -
      '
      '   ARGUMENTS
      '   Nom								Type						Designation
      '	Array_Length   					Integer		       			Tableau d'origine
      '	Shift				            Integer                     Decaler de 'Shift' elements
      '
      '	VARIABLES LOCALES
      '	Copy_Index			            Integer()	                Copie du tableau Index
      '	i					            Integer		                Indice de manipulation de Tableaux
      '	Index				            Integer()	                Tableau d'indices
      '
      '   RETOUR
      '   Nom								Type						Designation
      '	Array							Integer()					Tableau après operation
      '
      '	FONCTIONS APPELEES
      '   Nom								Classe						Designation
      '	-								-							-
      '
      '	METHODOLOGIE
      '	-
      '

      Dim i As Integer
      Dim Copy_array As Double()
      Dim Array As Integer()

      ReDim Array(Array_Length - 1)

      For i = 0 To Array.Length - 1
        Array(i) = i
      Next

      ReDim Copy_array(Array.Length - 1)

      System.Array.Copy(Array, Copy_array, Array.Length)

      For i = 0 To Array.Length - 1
        Array((i + Shift) - Int((i + Shift) / Array.Length) * Array.Length) = Copy_array(i)
      Next

      Return Array

    End Function
    Public Function Permute(ByVal Array As Integer(), _
                            ByVal Index_Elt_1 As Integer, _
                            ByVal Index_Elt_2 As Integer) _
                            As Integer()
      '
      '   OBJET
      '		Permuter deux elements d'un tableau
      '
      '   CONDITIONS D'UTILISATION	
      '		-
      '
      '   DATE        23/08/2004
      '
      '   VERSION     1.0
      '
      '   COMMENTAIRES VERSION
      '       -
      '
      '   ARGUMENTS
      '   Nom								Type							Designation
      '	Array       					Integer()       				Tableau d'origine
      '	Index_Elt_1						Integer							Index du premier element
      '	Index_Elt_2						Integer							Index du second element
      '
      '	VARIABLES LOCALES
      '   Nom								Type							Designation
      '	Temp							Integer							Variable temporaire
      '
      '   RETOUR
      '   Nom								Type							Designation
      '	Array							Integer()						Tableau après operation
      '
      '	FONCTIONS APPELEES
      '   Nom								Classe							Designation
      '	-								-								-
      '
      '	METHODOLOGIE
      '	-
      '

      Dim Temp As Integer

      If (Index_Elt_1 < 0 Or Index_Elt_1 > Array.Length - 1) Then
        Throw New Exception()
        'Console.WriteLine("Arrays.Permute : l'index du premier element est en dehors de la plage du tableau")
        'Exit Function
      End If


      If (Index_Elt_2 < 0 Or Index_Elt_2 > Array.Length - 1) Then
        Throw New Exception()
        'Console.WriteLine("Arrays.Permute : l'index du second element est en dehors de la plage du tableau")
        'Exit Function
      End If


      Temp = Array(Index_Elt_1)

      Array(Index_Elt_1) = Array(Index_Elt_2)
      Array(Index_Elt_2) = Temp

      Return Array

    End Function
    Public Function Shift_Range(ByVal Array As Integer(), _
                                ByVal Range_Length As Integer, _
                                ByVal Range_Start_Index As Integer, _
                                ByVal Shift As Integer) _
                                As Integer()
      '
      '   OBJET
      '		Deplacer une plage d'elements
      '
      '   CONDITIONS D'UTILISATION	
      '		La plage doit rester dans les limites du tableau
      '
      '   DATE        16/08/2004
      '
      '   VERSION     1.0
      '
      '   COMMENTAIRES VERSION
      '       -
      '
      '   ARGUMENTS
      '   Nom								Type							Designation
      '   Array							Integer()						Tableau initial
      '   Range_Length					Integer							Taille de la plage d'elements
      '   Range_Start_Index				Integer							Indice du premier element de la plage
      '   Shift							Integer							Decaler de 'Shift' elements
      '
      '	VARIABLES LOCALES
      '   Nom								Type							Designation
      '	i								Integer							Indice de manipulation de Tableaux
      '
      '   RETOUR
      '   Nom								Type							Designation
      '	Array							Integer()						Tableau après operation
      '
      '	FONCTIONS APPELEES
      '   Nom								Classe							Designation
      '	-								-								-
      '
      '	METHODOLOGIE
      '	-
      '

      Dim i As Integer

      '
      'La plage reste dans les limites inferieure et superieure du tableau
      '
      If (Shift > 0 And Range_Start_Index + Range_Length - 1 + Shift <= Array.Length - 1) Then
        For i = Range_Length To 1 Step -1
          Array(Range_Start_Index + i - 1 + Shift) = _
          Array(Range_Start_Index + i - 1)
        Next
      ElseIf (Shift < 0 And Range_Start_Index - Shift >= 0) Then
        For i = 0 To Range_Length - 1
          Array(Range_Start_Index + Shift + i) = _
          Array(Range_Start_Index + i)
        Next
      Else
        '
        'Message d'erreur
        '
        Console.WriteLine("")
        Console.WriteLine("Shift_Range : Range_Length + Shift - Range_Start_Index > Array.Length Or Range_Start_Index - Shift < 0")
      End If

      Return Array

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''fonctions issue de la classe SURFACE    ''''''''''''''''''''''''''''''''''''''''''
    Public Function Vertices_Array_Maker(ByVal Vertex_0 As MathLib.Point, _
                                         ByVal Vertex_1 As MathLib.Point, _
                                         ByVal Vertex_2 As MathLib.Point) _
                                         As MathLib.Point()

      ' Dim i As Integer
      Dim Vertices_Array As MathLib.Point()

      ReDim Vertices_Array(2)

      Vertices_Array(0) = Vertex_0
      Vertices_Array(1) = Vertex_1
      Vertices_Array(2) = Vertex_2

      Return Vertices_Array

    End Function

  End Class

End Namespace
