#Region "Structure"

''' <summary>
'''     Liste des differente orientation d'angle possible
''' </summary>
''' <remarks>
'''     
''' </remarks>
Public Enum AngleOrientation
  ''' <summary>
  '''     Sens géometrique (Sens des aiguilles d'une montre)
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Geometric = 0
  ''' <summary>
  '''     Sens Trigonometrique
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Trigonomeric = 1
End Enum

''' <summary>Liste les axes d'un repère 3D</summary>
Public Enum Axes

  ''' <summary>Axe OX</summary>
  Xaxe
  ''' <summary>Axe OY</summary>
  Yaxe
  ''' <summary>Axe OZ</summary>
  Zaxe

End Enum

Public Enum LineEquationType
  Normal
  Const_X
  Const_y
  Const_Z
End Enum

''' <summary>Liste des possibilitées d'ordre de calcul des rotations autour des axes</summary>
''' <remarks>
'''    <div class="paragraph">
'''        En réalité, il n'y a pas de façon correcte de combiner les matrices de
'''        rotation. Néanmoins, afin de prédire les résultats de la combinaison des
'''        matrices, un peu d'organisation est nécéssaire.
'''    </div><br />
'''    <div class="paragraph">
'''        Le moyen le plus simple de tourner un objet est de multiplier les matrices dans
'''        cette ordre :
'''    </div>
'''    <div class="paragraph"></div>
'''    <div class="paragraph">
'''        <strong>M = X * Y * Z</strong>
'''    </div><br />
'''    <div class="image" style="TEXT-ALIGN: left">
'''        Où <strong>M</strong> est la matrice de rotation finale, et <strong>X</strong>,
'''        <strong>Y</strong>, <strong>Z</strong> les matrices de rotations individuelles.
'''    </div>
''' </remarks>
Public Enum MatrixRotationAxesOrder
  ''' <summary>Calcul la rotation autour de l'axe OX puis OY puis OZ</summary>
  XYZ
  ''' <summary>Calcul la rotation autour de l'axe OX puis OZ puis OY</summary>
  XZY
  ''' <summary>Calcul la rotation autour de l'axe OY puis OX puis OZ</summary>
  YXZ
  ''' <summary>Calcul la rotation autour de l'axe OY puis OZ puis OX</summary>
  YZX
  ''' <summary>Calcul la rotation autour de l'axe OZ puis OX puis OY</summary>
  ZXY
  ''' <summary>Calcul la rotation autour de l'axe OZ puis OY puis OX</summary>
  ZYX
End Enum

''' <summary>Liste des plans d'un repère orthonormé</summary>
Public Enum Plane
  ''' <summary>
  '''    <para>Plan représenté par les vecteur OX et OY</para>
  '''    <para>Le plus utilisé en 2D</para>
  ''' </summary>
  XOY
  ''' <summary>Plan représenté par les vecteur OY et OZ</summary>
  YOZ
  ''' <summary>Plan représenté par les vecteur OX et OZ</summary>
  XOZ
End Enum

''' <summary>
'''     Liste les Differentes unitées d'angle possible
''' </summary>
''' <remarks>
'''     
''' </remarks>
Public Enum UnitAngle
  ''' <summary>
  '''     Degré
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Degree = 1
  ''' <summary>
  '''     Radian
  ''' </summary>
  ''' <remarks>
  '''     Unité de mesure International (IS)
  ''' </remarks>
  Radian = 2
  ''' <summary>
  '''     Gradian
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Gradian = 3
  ''' <summary>
  '''     Pourcentage %
  ''' </summary>
  Pourcent = 4
End Enum

Public Module Constant

  ''' <summary>
  ''' Precision appliqué en interne par MathLib pour éviter des résultats incoherant
  ''' </summary>
  ''' <example>
  '''    <code lang="VB" title="Exemple d'imprecision">
  ''' Dim a As Double = 0.3
  ''' Dim b As Double = 0.2
  ''' 
  ''' Dim Result As Double
  ''' 
  ''' Result = a - b
  ''' 
  ''' If Result = 0.1 Then
  '''    ' Code qui devrait etre executé
  ''' Else
  '''    ' Code qui sera executé car  a - b = 0.099999999999999978
  ''' End If
  ''' </code>
  ''' </example>
  Public Const ACCURANCY As Integer = 10

  ''' <summary>Valeur PI.</summary>
  ''' <remarks>
  '''    <para>Une valeur plus precise serai:</para>
  '''    <para>3.1415926535 8979323846 2643383279 5028841971 6939937510
  '''    5820974944 5923078164 0628620899 8628034825 3421170679</para>
  ''' </remarks>
  Public Const PI As Double = System.Math.PI
End Module

#End Region