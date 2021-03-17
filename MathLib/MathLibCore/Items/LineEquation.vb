Option Strict On

''' <summary>
'''     Contient les données d'une équation de droite du type Ax+By+Cz+D=0
''' </summary>
''' <remarks>
'''     
''' </remarks>
Public Class LineEquation

  ''' <summary>
  '''     Constante A (Axe X)
  ''' </summary>
  Private _A As Double
  ''' <summary>
  '''     Constante B (Axe Y)
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Private _B As Double
  ''' <summary>
  '''     Constante C (Axe Z)
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Private _C As Double
  ''' <summary>
  '''     Constante D (Pente)
  ''' </summary>
  ''' <remarks>
  '''     
  ''' </remarks>
  Private _D As Double

  ''' <summary>
  '''     Constante A (Axe X)
  ''' </summary>
  Public Property A() As Double
    Get
      Return _A
    End Get
    Set(ByVal value As Double)
      _A = value
    End Set
  End Property

  ''' <summary>
  '''     Constante B (Axe Y)
  ''' </summary>
  Public Property B() As Double
    Get
      Return _B
    End Get
    Set(ByVal value As Double)
      _B = value
    End Set
  End Property

  ''' <summary>
  '''     Constante C (Axe Z)
  ''' </summary>
  Public Property C() As Double
    Get
      Return _C
    End Get
    Set(ByVal value As Double)
      _C = value
    End Set
  End Property

  ''' <summary>
  '''     Constante D (Pente)
  ''' </summary>
  Public Property D() As Double
    Get
      Return _D
    End Get
    Set(ByVal value As Double)
      _D = value
    End Set
  End Property

  ''' <summary>Informe sur l'égalité entre L'equation de ligne et un objet.</summary>
  ''' <param name="obj"><para>Objet à comparer avec l'équation de ligne.</para></param>
  ''' <returns>A Boolean value...</returns>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    If Not IsNothing(obj) AndAlso TypeOf obj Is LineEquation Then
      Dim Data As LineEquation = CType(obj, LineEquation)
      If Data.A <> _A Then Return False
      If Data.B <> _B Then Return False
      If Data.C <> _C Then Return False
      If Data.D <> _D Then Return False
    Else
      Return False
    End If

    Return True

  End Function

  ''' <summary>
  '''     Forme de l'équation de droite 
  ''' </summary>
  Public ReadOnly Property Typ() As LineEquationType
    Get
      '-- Cherche le type de l'equation de Droite -----------
      'Constant Horizontal (OX)
      If _A = 0 And _B <> 0 And _C <> 0 Then
        Return LineEquationType.Const_X
      End If
      ' Constant Vertical (OY)
      If _A <> 0 And _B = 0 And _C <> 0 Then
        Return LineEquationType.Const_y
      End If
      ' Constant Profondeur(OZ)
      If _A <> 0 And _B <> 0 And _C = 0 Then
        Return LineEquationType.Const_Z
      End If

      Return LineEquationType.Normal

    End Get
  End Property

  ''' <summary>Renvois l'equation de droite orthogonal</summary>
  ''' <returns>A MathLib.LineEquation value...</returns>
  ''' <remarks>
  '''    <para>Méthode de calcul:</para>
  '''    <para>soit une équation de droite :D : Y=mX+P<br />
  '''    alors l'équation de droite orthogonales est: D' : Y=m'X+P avec avec m' =
  '''    -1/m</para>
  '''    <para></para>
  '''    <para>Donc si<br />
  '''    D : aX+bY+d = 0<br />
  '''    &lt;=&gt; (a/b)X + Y + (d/b) = 0<br />
  '''    d'ou m=a/b =&gt; m'=-(b/a)<br />
  '''    D' :-(b/a)X + Y + d/b = 0<br />
  '''    Donc a' = -(b/a); b' = 1 d' = d/b</para>
  ''' </remarks>
  Public Function GetOrthogonal() As LineEquation

    Dim a2 As Double
    Dim b2 As Double
    Dim c2 As Double
    Dim d2 As Double

    a2 = -(_B / _A)
    b2 = 1
    c2 = 0
    d2 = _D / _B

    Return New MathLib.LineEquation(a2, b2, c2, d2)

  End Function

  Public Sub New()

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="A">Valeur A</param>
  ''' <param name="B">Valeur B</param>
  ''' <param name="C">Valeur C</param>
  ''' <param name="D">Valeur D</param>
  Public Sub New(ByVal A As Double, ByVal B As Double, ByVal C As Double, ByVal D As Double)
    Me.new()
    Me.SetValues(A, B, C, D)
  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="A">Valeur A</param>
  ''' <param name="B">Valeur B</param>
  ''' <param name="D">Valeur D</param>
  Public Sub New(ByVal A As Double, ByVal B As Double, ByVal D As Double)
    Me.new()
    Me.SetValues(A, B, D)
  End Sub

  ''' <summary>Defini les valeur de l'équation de droite</summary>
  ''' <param name="A">Valeur A</param>
  ''' <param name="B">Valeur B</param>
  ''' <param name="C">Valeur C</param>
  ''' <param name="D">Valeur D</param>
  Public Sub SetValues(ByVal A As Double, ByVal B As Double, ByVal C As Double, ByVal D As Double)
    _A = A
    _B = B
    _C = C
    _D = D
  End Sub

  ''' <summary>Defini les valeur de l'équation de droite</summary>
  ''' <param name="A">Valeur A</param>
  ''' <param name="B">Valeur B</param>
  ''' <param name="D">Valeur D</param>
  Public Sub SetValues(ByVal A As Double, ByVal B As Double, ByVal D As Double)
    Me.SetValues(A, B, 0, D)
  End Sub

  ''' <summary>
  '''     Convertie l'équation de droite en une chaine de caractère
  ''' </summary>
  ''' <returns>
  '''     Chaine de caractère représentant une équation de droite
  ''' </returns>
  Public Overrides Function ToString() As String

    Dim Result As String

    Result = A & "x + " & B & "y + " & C & "z + " & D & " = 0"

    Return Result

  End Function

End Class
