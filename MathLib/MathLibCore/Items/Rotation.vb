Option Strict On

''' <summary>Classe contenant les données necessaire a une rotation 2D/3D</summary>
Public Class Rotation

  ''' <summary>Constructeur</summary>
  Public Sub New()

    _xAxeAngle = Nothing
    _yAxeAngle = Nothing
    _zAxeAngle = Nothing

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="xAxeAngle">
  '''    <para>Angle de rotation suivant l'axe OX<br />
  '''    0 si pas de rotation sur cette axe</para>
  ''' </param>
  ''' <param name="yAxeAngle">
  '''    <para>Angle de rotation suivant l'axe OY<br />
  '''    0 si pas de rotation sur cette axe</para>
  ''' </param>
  ''' <param name="zAxeAngle">
  '''    <para>Angle de rotation suivant l'axe OZ<br />
  '''    0 si pas de rotation sur cette axe</para>
  ''' </param>
  Public Sub New(ByVal xAxeAngle As Double, ByVal yAxeAngle As Double, ByVal zAxeAngle As Double, ByVal Unit As MathLib.UnitAngle)

    If xAxeAngle = 0 Then
      _xAxeAngle = Nothing
    Else
      _xAxeAngle = New MathLib.Angle(xAxeAngle, Unit)
    End If

    If yAxeAngle = 0 Then
      _yAxeAngle = Nothing
    Else
      _yAxeAngle = New MathLib.Angle(yAxeAngle, Unit)
    End If

    If zAxeAngle = 0 Then
      _zAxeAngle = Nothing
    Else
      _zAxeAngle = New MathLib.Angle(zAxeAngle, Unit)
    End If

  End Sub

  ''' <summary>Constructeur</summary>
  ''' <param name="zAxeAngle"><para>Angle de rotation suivant l'axe OX</para></param>
  ''' <param name="Unit">Unité de l'angle</param>
  Public Sub New(ByVal zAxeAngle As Double, ByVal Unit As MathLib.UnitAngle)

    SetValues(0, 0, zAxeAngle, Unit)

  End Sub

  ''' <summary>Constructeur</summary>
  Public Sub New(ByVal zAxeAngle As MathLib.Angle)

    SetValues(Nothing, Nothing, zAxeAngle)

  End Sub

  ''' <summary>Constructeur</summary>
  Public Sub New(ByVal xAxeAngle As MathLib.Angle, ByVal yAxeAngle As MathLib.Angle, ByVal zAxeAngle As MathLib.Angle)

    _xAxeAngle = xAxeAngle
    _yAxeAngle = yAxeAngle
    _zAxeAngle = zAxeAngle

  End Sub

  ''' <summary>Defini les valeurs definissant la rotation</summary>
  ''' <param name="xAxeAngle">
  ''' Angle de rotation suivant l'axe OX<br />
  ''' 0 si pas de rotation sur cette axe
  ''' </param>
  ''' <param name="yAxeAngle">
  ''' Angle de rotation suivant l'axe OY<br />
  ''' 0 si pas de rotation sur cette axe
  ''' </param>
  ''' <param name="zAxeAngle">
  ''' Angle de rotation suivant l'axe OZ (Valeur 2D)<br />
  ''' 0 si pas de rotation sur cette axe
  ''' </param>
  ''' <param name="Unit">Unité des angles</param>
  Public Sub SetValues(ByVal xAxeAngle As Double, ByVal yAxeAngle As Double, ByVal zAxeAngle As Double, ByVal Unit As MathLib.UnitAngle)

    If xAxeAngle = 0 Then
      _xAxeAngle = Nothing
    Else
      _xAxeAngle = New MathLib.Angle(xAxeAngle, Unit)
    End If

    If yAxeAngle = 0 Then
      _yAxeAngle = Nothing
    Else
      _yAxeAngle = New MathLib.Angle(yAxeAngle, Unit)
    End If

    If zAxeAngle = 0 Then
      _zAxeAngle = Nothing
    Else
      _zAxeAngle = New MathLib.Angle(zAxeAngle, Unit)
    End If

  End Sub

  ''' <summary>Defini les valeurs definissant la rotation</summary>
  ''' <param name="zAxeAngle">Angle de rotation suivant l'axe OZ (Valeur 2D)</param>
  ''' <param name="Unit">Unité de l'angle</param>
  Public Sub SetValues(ByVal zAxeAngle As Double, ByVal Unit As MathLib.UnitAngle)

    SetValues(0, 0, zAxeAngle, Unit)

  End Sub

  ''' <summary>Defini les valeurs definissant la rotation</summary>
  ''' <param name="zAxeAngle">Angle de rotation suivant l'axe OZ (Valeur 2D)</param>
  Public Sub SetValues(ByVal zAxeAngle As MathLib.Angle)

    SetValues(Nothing, Nothing, zAxeAngle)

  End Sub

  ''' <summary>Defini les valeurs definissant la rotation</summary>
  ''' <param name="xAxeAngle">
  '''    <para>Angle de rotation suivant l'axe OX<br />
  '''    Nothing si pas de rotation sur cette axe</para>
  ''' </param>
  ''' <param name="yAxeAngle">
  ''' Angle de rotation suivant l'axe OY<br />
  ''' Nothing si pas de rotation sur cette axe
  ''' </param>
  ''' <param name="zAxeAngle">
  '''    <para>Angle de rotation suivant l'axe OZ (Valeur 2D)<br />
  '''    Nothing si pas de rotation sur cette axe</para>
  ''' </param>
  Public Sub SetValues(ByVal xAxeAngle As MathLib.Angle, ByVal yAxeAngle As MathLib.Angle, ByVal zAxeAngle As MathLib.Angle)

    _xAxeAngle = xAxeAngle
    _yAxeAngle = yAxeAngle
    _zAxeAngle = zAxeAngle

  End Sub

  ''' <summary>Informe si la rotation est Nulle. (Pas de rotation ou rotation d'angle 0)</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public ReadOnly Property IsNull() As Boolean
    Get
      If Not IsNothing(_xAxeAngle) AndAlso _xAxeAngle.Value <> 0 Then Return False
      If Not IsNothing(_yAxeAngle) AndAlso _yAxeAngle.Value <> 0 Then Return False
      If Not IsNothing(_zAxeAngle) AndAlso _zAxeAngle.Value <> 0 Then Return False
    End Get
  End Property

  ''' <summary>Informe/défini l'angle de rotation sur l'axe OX</summary>
  Public Property xAxeAngle() As MathLib.Angle
    Get
      Return _xAxeAngle
    End Get
    Set(ByVal Value As MathLib.Angle)
      _xAxeAngle = Value
    End Set
  End Property

  ''' <summary>Informe/défini l'angle de rotation sur l'axe OY</summary>
  Public Property yAxeAngle() As MathLib.Angle
    Get
      Return _yAxeAngle
    End Get
    Set(ByVal Value As MathLib.Angle)
      _yAxeAngle = Value
    End Set
  End Property

  ''' <summary>Informe/défini l'angle de rotation sur l'axe OZ</summary>
  Public Property zAxeAngle() As MathLib.Angle
    Get
      Return _zAxeAngle
    End Get
    Set(ByVal Value As MathLib.Angle)
      _zAxeAngle = Value
    End Set
  End Property
  ''' <summary>Angle de rotation sur l'axe OX</summary>
  Private _xAxeAngle As MathLib.Angle = Nothing
  ''' <summary>Angle de rotation sur l'axe OY</summary>
  Private _yAxeAngle As MathLib.Angle = Nothing
  ''' <summary>Angle de rotation sur l'axe OZ</summary>
  Private _zAxeAngle As MathLib.Angle = Nothing

End Class
