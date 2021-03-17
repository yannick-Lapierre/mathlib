Option Strict On

''' <summary>
''' Structure recuillant les coordonées d'un point
''' </summary>
<DebuggerDisplay("{ToString}")> _
Public Class Line

  ''' <summary>
  ''' Coordonnée X du point
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Pt1 As MathLib.Point
  ''' <summary>
  ''' Coordonnée Y du point
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Private _Pt2 As MathLib.Point

  ''' <summary>Constructeur</summary>
  Public Sub New()
    Me.SetValues(New MathLib.Point, New MathLib.Point)
  End Sub

  ''' <summary>Informe sur la possibilité que les point format la droite soient confondu</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public ReadOnly Property HasMixedPoint() As Boolean
    Get
      If Not IsNothing(_Pt1) And Not IsNothing(_Pt2) Then
        Return _Pt1 = _Pt2
      Else
        Return False
      End If
    End Get
  End Property

  ''' <summary>Distance entre les points de la ligne (Longueur du segemnt)</summary>
  ''' <returns>A Double value...</returns>
  Public Function Lenght() As Double
    Return MathLib.Geometry.Point.Lenght(_Pt1, _Pt2)
  End Function

  ''' <summary>Concertie une ligne en un vecteur équivalant</summary>
  ''' <returns>A MathLib.Vector value...</returns>
  ''' <remarks>
  '''    <para>
  '''        Le <see cref="Point1">Point1 Property</see> devient la Base du vecteur<br />
  '''        Le <see cref="Point2">Point2 Property</see> devient la flêche du vecteur
  '''    </para>
  ''' </remarks> 
  Public Function ToVector() As MathLib.Vector
    Return New MathLib.Vector(_Pt1, _Pt2)
  End Function

  ''' <summary>Constructeur</summary>
  ''' <param name="point1">1er point de la ligne</param>
  ''' <param name="point2">2eme point de la ligne</param>
  Public Sub New(ByVal point1 As Point, ByVal point2 As Point)
    Me.SetValues(point1, point2)
  End Sub

  ''' <summary>Crée une nouvelle instance de l'objet</summary>
  ''' <returns></returns>
  Public Function Clone() As Line

    Return New Line(Me.Point1, Me.Point2)

  End Function

  ''' <summary>Informe sur l'égalité entre le Point et un objet</summary>
  ''' <param name="obj">Objet a comparer avec le point.</param>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    If Not IsNothing(obj) AndAlso TypeOf obj Is Line Then
      Return (_Pt1 = CType(obj, Line).Point1 And _Pt2 = CType(obj, Line).Point2)
    Else
      Return False
    End If

  End Function

  ''' <summary>Coordonée de la ligne</summary>
  ''' <param name="point1">1er Point</param>
  ''' <param name="point2">2eme point</param>
  Public Sub SetValues(ByVal point1 As MathLib.Point, ByVal point2 As MathLib.Point)

    '-- Parameter Validation ----------------------------
    If IsNothing(point1) Then Throw New NullReferenceException("point1")
    If IsNothing(point2) Then Throw New NullReferenceException("point2")
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    _Pt1 = point1
    _Pt2 = point2

  End Sub

  Public Overrides Function ToString() As String

    Dim Result As String

    Result = _Pt1.ToString & _Pt2.ToString

    Return Result

  End Function

  ''' <summary>
  ''' Valeur du 1er Point
  ''' </summary>
  Public Property Point1() As MathLib.Point
    <DebuggerStepThrough()> _
    Get
      Return _Pt1
    End Get
    <DebuggerStepThrough()> _
    Set(ByVal value As MathLib.Point)
      _Pt1 = value
    End Set
  End Property

  ''' <summary>
  ''' Valeur du 2eme Point
  ''' </summary>
  Public Property Point2() As MathLib.Point
    <DebuggerStepThrough()> _
    Get
      Return _Pt2
    End Get
    <DebuggerStepThrough()> _
    Set(ByVal value As MathLib.Point)
      _Pt2 = value
    End Set
  End Property

#Region "Operator"

  ''' <summary>Test l'égalité entre 2 Ligne</summary>
  ''' <param name="Line1">1ere Ligne</param>
  ''' <param name="Line2">2eme ligne</param>
  Public Shared Operator =(ByVal Line1 As Line, ByVal Line2 As Line) As Boolean

    If IsNothing(Line1) And IsNothing(Line1) Then Return True
    If IsNothing(Line1) Xor IsNothing(Line1) Then Return False
    Return (Line1.Point1 = Line2.Point1 And Line1.Point2 = Line2.Point2)

  End Operator

  ''' <summary>Test l'inégalité entre 2 Ligne</summary>
  ''' <param name="Line1">1ere Ligne</param>
  ''' <param name="Line2">2eme ligne</param>
  Public Shared Operator <>(ByVal Line1 As Line, ByVal Line2 As Line) As Boolean

    Return Not Line1 = Line2

  End Operator

#End Region

End Class