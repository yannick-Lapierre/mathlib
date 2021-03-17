''' <summary>
'''     Structure recuillant les valeurs de taille d'un element
''' </summary>
Public Structure Size

  ''' <summary>
  '''     Hauteur de l'élément (Usuellement axe X)
  ''' </summary>
  Dim Height As Double
  ''' <summary>
  '''     Largeur de l'élément (Usuellement axe Y)
  ''' </summary>
  Dim Width As Double
  ''' <summary>
  '''     Profondeur de l'élément (Usuellement axe Z)
  ''' </summary>
  Dim Deep As Double

  ''' <summary>
  '''     Defini les valeurs de taille
  ''' </summary>
  ''' <param name="Height" type="double">
  '''     <para>
  '''         Hauteur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Width" type="Double">
  '''     <para>
  '''         Largeur de l'élément
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal Height As Double, ByVal Width As Double)
    Me.Height = Height
    Me.Width = Width
    Me.Deep = 0
  End Sub

  ''' <summary>
  '''     Defini les valeurs de taille
  ''' </summary>
  ''' <param name="Height" type="Single">
  '''     <para>
  '''         Hauteur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Width" type="Single">
  '''     <para>
  '''         Largeur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Deep" type="Single">
  '''     <para>
  '''         Profondeur de l'élément
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal Height As Double, ByVal Width As Double, ByVal Deep As Double)
    Me.Height = Height
    Me.Width = Width
    Me.Deep = Deep
  End Sub

  ''' <summary>
  '''     Initialise une taille
  ''' </summary>
  ''' <param name="Height" type="Single">
  '''     <para>
  '''         Hauteur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Width" type="Single">
  '''     <para>
  '''         Largeur de l'élément
  '''     </para>
  ''' </param>
  Public Shared Function GetSize(ByVal Height As Double, _
                                 ByVal Width As Double) _
                                 As Size

    Dim Result As Size
    Result.SetValues(Height, Width)
    Return Result

  End Function

  ''' <summary>
  '''     Initialise une taille
  ''' </summary>
  ''' <param name="Height" type="Single">
  '''     <para>
  '''         Hauteur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Width" type="Single">
  '''     <para>
  '''         Largeur de l'élément
  '''     </para>
  ''' </param>
  ''' <param name="Deep" type="Single">
  '''     <para>
  '''         Profondeur de l'élément
  '''     </para>
  ''' </param>
  Public Shared Function GetSize(ByVal Height As Double, _
                                 ByVal Width As Double, _
                                 ByVal Deep As Double) _
                                 As Size

    Dim Result As Size
    Result.SetValues(Height, Width, Deep)
    Return Result

  End Function

End Structure
