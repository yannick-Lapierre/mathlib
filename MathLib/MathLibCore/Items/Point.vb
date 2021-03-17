Option Strict On

''' <summary>Structure recuillant les coordonées d'un point</summary>
<DebuggerDisplay("{ToString}")> _
Public Class Point

  ''' <summary>Constructeur</summary>
  Public Sub New()

    Me.SetValues(0, 0, 0)

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="X">Valeur pour l'axe X</param>
  ''' <param name="Y">Valeur pour l'axe Y</param>
  Public Sub New(ByVal X As Double, ByVal Y As Double)

    Me.SetValues(X, Y)

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="X">Valeur pour l'axe X</param>
  ''' <param name="Y">Valeur pour l'axe Y</param>
  ''' <param name="Z">Valeur pour l'axe Z</param>
  Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)

    Me.SetValues(x, y, z)

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="Matrix">Matrice [2;1] ou [3;1] contenant les coordonnées du point.</param>
  Public Sub New(ByVal Matrix As MathLib.Matrix)

    Me.SetValues(Matrix)

  End Sub

  ''' <summary>Crée une nouvelle instance de l'objet</summary>
  Public Function Clone() As Point

    Return New Point(Me.X, Me.Y, Me.Z)

  End Function

  ''' <summary>Informe sur l'égalité entre le Point et un objet</summary>
  ''' <param name="obj">Objet a comparer avec le point.</param>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    Dim value1 As Double
    Dim value2 As Double

    If Not IsNothing(obj) AndAlso TypeOf obj Is Point Then
      ' X
      value1 = MathLib.General.Round(CType(obj, Point).X, ACCURANCY)
      value2 = MathLib.General.Round(_X, ACCURANCY)
      If value1 <> value2 Then Return False

      ' Y
      value1 = MathLib.General.Round(CType(obj, Point).Y, ACCURANCY)
      value2 = MathLib.General.Round(_Y, ACCURANCY)
      If value1 <> value2 Then Return False

      ' Z
      value1 = MathLib.General.Round(CType(obj, Point).Z, ACCURANCY)
      value2 = MathLib.General.Round(_Z, ACCURANCY)
      If value1 <> value2 Then Return False

      Return True

    Else
      Return False
    End If

  End Function

  ''' <summary>Défini les valeurs de coordonnées du point</summary>
  ''' <param name="X">Valeur pour l'axe X</param>
  ''' <param name="Y">Valeur pour l'axe Y</param>
  Public Sub SetValues(ByVal x As Double, ByVal y As Double)
    _X = x
    _Y = y
    _Z = 0
  End Sub

  ''' <summary>Défini les valeurs de coordonnées du point</summary>
  ''' <param name="X">Valeur pour l'axe X</param>
  ''' <param name="Y">Valeur pour l'axe Y</param>
  ''' <param name="Z">Valeur pour l'axe Z</param>
  Public Sub SetValues(ByVal X As Double, ByVal Y As Double, ByVal Z As Double)
    Me.X = X
    Me.Y = Y
    Me.Z = Z
  End Sub

  ''' <summary>Defini les valeurs des coordonnée du point depuis une matrice</summary>
  ''' <param name="Matrix">Matrice [2;1] ou [3;1] contenant les coordonnées du point.</param>
  Public Sub SetValues(ByVal Matrix As MathLib.Matrix)

    '-- Parameter Validation ----------------------------
    If IsNothing(Matrix) Then Throw New NullReferenceException("SetValue")
    If Matrix.RowSize < 2 Or Matrix.RowSize > 3 Or Matrix.ColSize <> 1 Then Throw New MathLib.Exception(300)
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------
    If Matrix.RowSize = 2 Then
      Me.SetValues(Matrix(0, 0), Matrix(1, 0))
    End If

    If Matrix.RowSize = 3 Then
      Me.SetValues(Matrix(0, 0), Matrix(1, 0), Matrix(2, 0))
    End If

  End Sub

  Public Overrides Function ToString() As String

    Dim Result As String

    Result = "(" & X & ";" & Y & ";" & Z & ")"

    Return Result

  End Function

  ''' <summary>X Value</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property X() As Double
    <Diagnostics.DebuggerStepThrough()> _
    Get
      Return _X
    End Get
    <Diagnostics.DebuggerStepThrough()> _
    Set(ByVal value As Double)
      _X = value
    End Set
  End Property

  ''' <summary>Y Value</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property Y() As Double
    <Diagnostics.DebuggerStepThrough()> _
    Get
      Return _Y
    End Get
    <Diagnostics.DebuggerStepThrough()> _
    Set(ByVal value As Double)
      _Y = value
    End Set
  End Property

  ''' <summary>Z Value</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property Z() As Double
    <Diagnostics.DebuggerStepThrough()> _
    Get
      Return _Z
    End Get
    <Diagnostics.DebuggerStepThrough()> _
    Set(ByVal value As Double)
      _Z = value
    End Set
  End Property
  ''' <summary>
  ''' Coordonnée X du point
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _X As Double
  ''' <summary>
  ''' Coordonnée Y du point
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Y As Double
  ''' <summary>
  ''' Coordonnée Z du point
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Z As Double

#Region "Operator"

  ''' <summary>
  '''     Addition de 2 coordonées
  ''' </summary>
  ''' <param name="a" type="MathLib.Point">
  '''     <para>
  '''         1er coordonée
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Point">
  '''     <para>
  '''         2ème coordonée
  '''     </para>
  ''' </param>
  Public Shared Operator +(ByVal a As Point, ByVal b As Point) As Point

    If IsNothing(a) Then Throw New NullReferenceException("'a' in '+ Operator'")
    If IsNothing(b) Then Throw New NullReferenceException("'b' in '+ Operator'")

    Dim Result As New Point

    Result.X = a.X + b.X
    Result.Y = a.Y + b.Y
    Result.Z = a.Z + b.Z

    Return Result

  End Operator

  ''' <summary>Test l'égalité entre 2 points</summary>
  ''' <param name="point1">1er point</param>
  ''' <param name="point2">2ème point</param>
  Public Shared Operator =(ByVal point1 As Point, ByVal point2 As Point) As Boolean

    If IsNothing(point1) And IsNothing(point2) Then Return True

    If IsNothing(point1) Xor IsNothing(point2) Then Return False

    Dim value1 As Double
    Dim value2 As Double

    ' X
    value1 = MathLib.General.Round(point1.X, ACCURANCY)
    value2 = MathLib.General.Round(point2.X, ACCURANCY)
    If value1 <> value2 Then Return False

    ' Y
    value1 = MathLib.General.Round(point1.Y, ACCURANCY)
    value2 = MathLib.General.Round(point2.Y, ACCURANCY)
    If value1 <> value2 Then Return False

    ' Z
    value1 = MathLib.General.Round(point1.Z, ACCURANCY)
    value2 = MathLib.General.Round(point2.Z, ACCURANCY)
    If value1 <> value2 Then Return False

    Return True

  End Operator

  ''' <summary>Test l'inégalité entre 2 Points</summary>
  ''' <param name="point1">1er point</param>
  ''' <param name="point2">2ème point</param>
  Public Shared Operator <>(ByVal point1 As Point, ByVal point2 As Point) As Boolean

    Return Not point1 = point2

  End Operator

  ''' <summary>
  '''     Suppression aux valeur d'une coordonée les valeur d'une 2ème coordonées
  ''' </summary>
  ''' <param name="a" type="MathLib.Point">
  '''     <para>
  '''         Coordonées cible
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Point">
  '''     <para>
  '''         Valeur de coordonées à soustraire
  '''     </para>
  ''' </param>
  Public Shared Operator -(ByVal a As Point, ByVal b As Point) As Point

    '-- Parameter Validation ----------------------------
    If IsNothing(a) Then Throw New NullReferenceException("'a' in '- Operator'")
    If IsNothing(b) Then Throw New NullReferenceException("'b' in '- Operator'")
    '-- Internal Data Validation ------------------------

    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    Dim Result As New Point

    Result.X = MathLib.General.Round(a.X - b.X, ACCURANCY)
    Result.Y = MathLib.General.Round(a.Y - b.Y, ACCURANCY)
    Result.Z = MathLib.General.Round(a.Z - b.Z, ACCURANCY)

    Return Result

  End Operator

#End Region

End Class
