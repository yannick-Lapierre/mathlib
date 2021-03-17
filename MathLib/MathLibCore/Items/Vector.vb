Option Strict On

''' <summary>
'''     Representation d'un vecteur.
''' </summary>
<DebuggerDisplay("{ToString}")> _
Public Class Vector

  ''' <summary>
  '''     Constructeur
  ''' </summary>
  Public Sub New()

    _base = Nothing
    _endPoint = Nothing

  End Sub

  ''' <summary>Crée une nouvelle instance de l'objet</summary>
  Public Function Clone() As Vector
    Return New Vector(_base, _endPoint)
  End Function

  ''' <summary>Constructeur</summary>
  ''' <param name="EndPoint">Point de destination du vecteur (Flêche)</param>
  Public Sub New(ByVal EndPoint As Point)
    Me.SetValues(EndPoint)
  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="Base">Point de départ du vecteur</param>
  ''' <param name="EndPoint">Point de destination du vecteur (Flêche)</param>
  Public Sub New(ByVal Base As Point, ByVal EndPoint As Point)
    Me.SetValues(Base, EndPoint)
  End Sub

  ''' <summary>Informe sur l'égalité entre le Vecteur et un objet</summary>
  ''' <param name="obj">Objet a comparer avec le vecteur.</param>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    If TypeOf obj Is Vector AndAlso _base.Equals(CType(obj, Vector).Base) And _endPoint.Equals(CType(obj, Vector).EndPoint) Then
      Return True
    Else
      Return False
    End If

  End Function

  ''' <summary>Initialise un vecteur</summary>
  ''' <param name="Base">Point de départ du vecteur</param>
  ''' <param name="EndPoint">Point de destination du vecteur (Flêche)</param>
  Public Shared Function GetVector(ByVal Base As Point, ByVal EndPoint As Point) As Vector

    Dim Result As New Vector

    Result.SetValues(Base, EndPoint)
    Return Result

  End Function

  ''' <summary>Initialise un vecteur</summary>
  ''' <param name="EndPoint">Point de destination du vecteur (Flêche)</param>
  Public Shared Function GetVector(ByVal EndPoint As Point) As Vector

    Dim Result As New Vector

    Result.SetValues(EndPoint)
    Return Result

  End Function

  ''' <summary>
  '''     Informe si le vecteur à la même direction qu'un autre
  ''' </summary>
  ''' <param name="Value" type="MathLib.Vector">
  '''     <para>
  '''         1er vecteur
  '''     </para>
  ''' </param>
  ''' <returns>
  ''' </returns>
  Public Function IsSameDirection(ByVal Value As Vector) As Boolean

    '-- Parameter Validation ----------------------------
    If IsNothing(Value) Then Throw New NullReferenceException
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    Return IsSameDirection(Me, Value)

  End Function

  ''' <summary>
  '''     Informe si 2 vecteurs on la même direction (colinéaire)
  ''' </summary>
  ''' <param name="Value1" type="MathLib.Vector">
  '''     <para>
  '''         1er vecteur
  '''     </para>
  ''' </param>
  ''' <param name="value2" type="MathLib.Vector">
  '''     <para>
  '''         2nd vecteur
  '''     </para>
  ''' </param>
  ''' <returns>
  ''' </returns>
  Public Shared Function IsSameDirection(ByVal Value1 As Vector, ByVal value2 As Vector) As Boolean

    '-- Parameter Validation ----------------------------
    If IsNothing(Value1) Then Throw New NullReferenceException
    If IsNothing(value2) Then Throw New NullReferenceException
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    Dim vect1 As New Vector
    Dim vect2 As New Vector

    vect1 = Value1.ZeroBasedVector
    vect2 = value2.ZeroBasedVector

    If vect1.EndPoint.X * vect2.EndPoint.Y = vect1.EndPoint.Y * vect2.EndPoint.X Then
      Return True
    Else
      Return False
    End If

  End Function

  ''' <summary>
  '''     Informe si le vecteur à la même norme qu'un autre vecteur
  ''' </summary>
  ''' <param name="Value" type="MathLib.Vector">
  '''     <para>
  '''         Valeur à comparer
  '''     </para>
  ''' </param>
  ''' <returns>
  '''     A Boolean value...
  ''' </returns>
  Public Function IsSameNorme(ByVal Value As Vector) As Boolean
    Return IsSameNorme(Me, Value)
  End Function

  ''' <summary>
  '''     Informe si les les normes des vecteurs sont identiques
  ''' </summary>
  ''' <param name="Value1" type="MathLib.Vector">
  '''     <para>
  '''         1er veteur
  '''     </para>
  ''' </param>
  ''' <param name="value2" type="MathLib.Vector">
  '''     <para>
  '''         2nd vecteur
  '''     </para>
  ''' </param>
  ''' <returns>
  '''     
  ''' </returns>
  Public Shared Function IsSameNorme(ByVal Value1 As Vector, ByVal value2 As Vector) As Boolean

    '-- Parameter Validation ----------------------------
    If IsNothing(Value1) Then Throw New NullReferenceException
    If IsNothing(value2) Then Throw New NullReferenceException
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    If Value1.Norm = value2.Norm Then
      Return True
    Else
      Return False
    End If

  End Function

  ''' <summary>
  '''     Informe si 2 vecteurs ont le meme sens
  ''' </summary>
  ''' <param name="value" type="MathLib.Vector">
  '''     <para>
  '''         vecteur à comparer
  '''     </para>
  ''' </param>
  ''' <returns>
  ''' </returns>
  Public Function IsSameWay(ByVal Value As Vector) As Boolean

    '-- Parameter Validation ----------------------------
    If IsNothing(Value) Then Throw New NullReferenceException
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    Return IsSameWay(Me, Value)

  End Function

  ''' <summary>
  '''     Informe si 2 vecteurs ont le meme sens
  ''' </summary>
  ''' <param name="Value1" type="MathLib.Vector">
  '''     <para>
  '''         1er vecteur
  '''     </para>
  ''' </param>
  ''' <param name="value2" type="MathLib.Vector">
  '''     <para>
  '''         2nd vecteur
  '''     </para>
  ''' </param>
  ''' <returns>
  ''' </returns>
  Public Shared Function IsSameWay(ByVal Value1 As Vector, ByVal value2 As Vector) As Boolean

    '-- Parameter Validation ----------------------------
    If IsNothing(Value1) Then Throw New NullReferenceException
    If IsNothing(value2) Then Throw New NullReferenceException
    '-- Exit Case ---------------------------------------

    '----------------------------------------------------

    Dim Vect1 As Vector
    Dim vect2 As Vector

    Vect1 = MathLib.Common.Vector.UnitVector(Value1.ZeroBasedVector)
    vect2 = MathLib.Common.Vector.UnitVector(value2.ZeroBasedVector)

    If Vect1.Equals(vect2) Then
      Return True
    Else
      Return False
    End If

  End Function

  ''' <summary>Inverese le sens d'un vecteur (La base devient le point de fin, Le point de fin devient la base)</summary>
  Public Function Reverse() As Vector

    Return New MathLib.Vector(Me.EndPoint.Clone, Me.Base.Clone)

  End Function

  ''' <summary>
  '''     Defini les valeurs du vecteur
  ''' </summary>
  ''' <param name="EndPoint" type="MathLib.Point">
  '''     <para>
  '''         Point de destination du vecteur (Flêche)
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal EndPoint As Point)

    _base = New MathLib.Point(0, 0, 0)
    _endPoint = EndPoint

  End Sub

  ''' <summary>
  '''     Défini les valeurs du vecteur
  ''' </summary>
  ''' <param name="Base" type="MathLib.Point">
  '''     <para>
  '''         Point de départ du vecteur
  '''     </para>
  ''' </param>
  ''' <param name="EndPoint" type="MathLib.Point">
  '''     <para>
  '''         Point de destination du vecteur (Flêche)
  '''     </para>
  ''' </param>
  Public Sub SetValues(ByVal Base As Point, ByVal EndPoint As Point)

    _base = Base
    _endPoint = EndPoint

  End Sub

  ''' <summary>
  '''     Convertie le vecteur en une chaine de caractère
  ''' </summary>
  ''' <returns>
  '''     Chaine de caractère représentant un vecteur
  ''' </returns>
  Public Overrides Function ToString() As String

    Dim Result As String

    'Result = "[" & _base.ToString & ";" & _endPoint.ToString & "]"
    Result = "[" & _base.ToString & _endPoint.ToString & "]"

    Return Result

  End Function

  ''' <summary>
  '''     Retourne un vecteur équivallant mais de base 0
  ''' </summary>
  ''' <returns>
  '''     vecteur équivallant de base 0
  ''' </returns>
  Public Function ZeroBasedVector() As Vector

    Dim Result As New Vector

    Result.SetValues(EndPoint - Base)

    Return Result

  End Function

  ''' <summary>
  '''     Origine du vecteur
  ''' </summary>
  Public Property Base() As Point
    Get
      Return _base
    End Get
    Set(ByVal value As Point)
      _base = value
    End Set
  End Property

  ''' <summary>
  '''     Destination du vecteur
  ''' </summary>
  Public Property EndPoint() As Point
    Get
      Return _endPoint
    End Get
    Set(ByVal value As Point)
      _endPoint = value
    End Set
  End Property

  ''' <summary>
  '''     Norme (Longueur) du vercteur.
  ''' </summary>
  ''' <value>
  '''     <para>
  '''         
  '''     </para>
  ''' </value>
  ''' <remarks>
  '''     
  ''' </remarks>
  Public ReadOnly Property Norm() As Double
    Get
      Return MathLib.Geometry.Point.Lenght(Base, EndPoint)
    End Get
  End Property

  ''' <summary>
  '''     Origine du vecteur
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Dim _base As Point
  ''' <summary>
  '''     Destination du vecteur
  ''' </summary>
  <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
  Dim _endPoint As Point

#Region "Operator"

  ''' <summary>
  '''     Addition de 2 vecteurs
  ''' </summary>
  ''' <param name="A" type="MathLib.Vector">
  '''     <para>
  '''         1er vecteur
  '''     </para>
  ''' </param>
  ''' <param name="B" type="MathLib.Vector">
  '''     <para>
  '''         2éme vecteur
  '''     </para>
  ''' </param>
  Public Shared Operator +(ByVal A As Vector, ByVal B As Vector) As Vector

    Dim Result As New Vector
    Dim TmpPt As Point

    TmpPt = A.EndPoint + B.ZeroBasedVector.EndPoint

    Result.SetValues(A.Base, TmpPt)

    Return Result

  End Operator

  ''' <summary>
  '''     Division par un scalaire
  ''' </summary>
  ''' <param name="a" type="Single">
  '''     <para>
  '''         Diviseur
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Vector">
  '''     <para>
  '''         Vecteur cible
  '''     </para>
  ''' </param>
  Public Shared Operator /(ByVal a As Double, ByVal b As Vector) As Vector

    Return (1 / a) * b

  End Operator

  ''' <summary>
  '''     Teste l'égalité de vecteur.
  ''' </summary>
  ''' <remarks>
  '''    <para>2 vecteurs sont égux si il ont:</para>
  '''    <list type="bullet">
  '''        <item></item>
  '''        <item>même sens</item>
  '''        <item>Même direction</item>
  '''        <item>même norme</item>
  '''    </list>
  ''' </remarks>
  ''' <param name="Value1" type="MathLib.Vector">
  '''	<para>
  '''         1er vecteur
  '''     </para>
  ''' </param>
  ''' <param name="Value2" type="MathLib.Vector">
  '''	<para>
  '''         2nd vecteur
  '''     </para>
  ''' </param>
  Public Shared Operator =(ByVal Value1 As Vector, ByVal Value2 As Vector) As Boolean

    If IsSameWay(Value1, Value2) And IsSameDirection(Value1, Value2) And IsSameNorme(Value1, Value2) Then
      Return True
    Else
      Return False
    End If

  End Operator

  ''' <summary>Teste la non égalité entre 2 vecteurs</summary>
  ''' <param name="Value1">1er vecteur</param>
  ''' <param name="Value2">2éme vecteur</param>
  Public Shared Operator <>(ByVal Value1 As Vector, ByVal Value2 As Vector) As Boolean

    Return Not (Value1 = Value2)

  End Operator

  ''' <summary>
  '''     Multiplication par un scalaire
  ''' </summary>
  ''' <param name="a" type="Single">
  '''     <para>
  '''         Multiplicateur
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Vector">
  '''     <para>
  '''         Vecteur cible
  '''     </para>
  ''' </param> 
  Public Shared Operator *(ByVal a As Double, ByVal b As Vector) As Vector

    Dim TmpVector As Vector
    Dim Pt As New Point

    TmpVector = b.ZeroBasedVector

    Pt.X = a * TmpVector.EndPoint.X
    Pt.Y = a * TmpVector.EndPoint.Y
    Pt.Z = a * TmpVector.EndPoint.Z

    TmpVector.SetValues(Pt)
    TmpVector = MathLib.Common.Vector.Translation(TmpVector, b.Base)

    Return TmpVector

  End Operator

#End Region

End Class
