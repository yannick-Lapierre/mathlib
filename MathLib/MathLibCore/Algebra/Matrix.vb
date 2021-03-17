Namespace Algebra


  ''' <summary>Calcul réalisable à partir des Matrices</summary>
  Public Class Matrix

    ''' <summary>Renvois la matrice [3,1] associé à un point</summary>
    ''' <returns>
    ''' Matrice de taille [3,1] contenant les coordonnées du point<br />
    ''' Mat(0,0) = X<br />
    ''' Mat(1,0) = Y<br />
    ''' Mat(2,0) = Z
    ''' </returns>
    ''' <param name="Point">Point à transphormer en matrice</param>
    Public Shared Function GetFromPoint(ByVal Point As MathLib.Point) As MathLib.Matrix

      '-- Parameter Validation ----------------------------
      If IsNothing(Point) Then Throw New NullReferenceException
      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      Dim result As New MathLib.Matrix(3, 1)

      result(0, 0) = Point.X
      result(1, 0) = Point.Y
      result(2, 0) = Point.Z

      Return result

    End Function

    ''' <summary>Informe si 2 matrice sont compatibles</summary>
    ''' <remarks>
    ''' L'ordre des matrices a une importance, car 2 matrice sont compatibles si :<br />
    ''' le nombre de colonnes de la première matrice est le même que le nombre de lignes de la
    ''' deuxième matrice.
    ''' </remarks>
    ''' <param name="matrix1">1 ére matrice</param>
    ''' <param name="matrix2">2 ème matrice</param>
    Public Shared Function IsCompatible(ByVal matrix1 As MathLib.Matrix, ByVal matrix2 As MathLib.Matrix) As Boolean

      '-- Parameter Validation ----------------------------
      If IsNothing(matrix1) Then Throw New NullReferenceException
      If IsNothing(matrix2) Then Throw New NullReferenceException
      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      If matrix1.ColSize = matrix2.RowSize Then
        Return True
      Else
        Return False
      End If

    End Function

        'Public Shared Function GaussianElimination(ByVal Value As MathLib.Matrix) As MathLib.Matrix



        'End Function

        ''' <summary>Utilisation de la methode de Cramer pour resoude des equation à inconue</summary>
        ''' <returns>Valeur des inconues.</returns>
        ''' <remarks>Le Nb d'équation (Lignes) doit etre egal aux Nb d'inconue (Colonnes)</remarks>
        ''' <example>
        '''    <para></para>
        '''    <para></para>
        '''    <code lang="VB" title="Equation a 2 inconnus" description=
        '''    "Calcul des variable d'une équation a 2 inconus">
        ''' <![CDATA[
        ''' ' Supposons 2 equations:
        ''' ' 2x + y = 5
        ''' ' x + 2y = 4
        ''' ' Recherche de x &amp; y:
        ''' 
        ''' Dim MatrixCoef = New MathLib.Matrix("{[2;1][1;2]}")
        ''' Dim MatrixValue = New MathLib.Matrix("{[5][4]}")
        ''' Dim MatrixResult As MathLib.Matrix
        ''' Dim x, y As Double
        ''' 
        ''' MatrixResult = MathLib.Algebra.Matrix.Cramer(MatrixCoef, MatrixValue)
        ''' 
        ''' x = MatrixResult(0,0)
        ''' y = MatrixResult(0,1)]]>
        ''' </code>
        ''' </example>
        ''' <param name="CoefMatrix">Matrix contenant les coefficients des inconnues.</param>
        ''' <param name="RightMember">
        ''' contient les membres de droite des équations du système.<br/>
        ''' Les resultat sont placé dans une matrice [1,N] ou les valeur sont des les meme colonnes que celle des inconnues de la matrice des coefficients  
        ''' </param>
    Public Shared Function Cramer(ByVal CoefMatrix As MathLib.Matrix, ByVal RightMember As MathLib.Matrix) As MathLib.Matrix

      '-- Parameter Validation ----------------------------
      If IsNothing(CoefMatrix) Then Throw New NullReferenceException
      If IsNothing(RightMember) Then Throw New NullReferenceException
      If Not CoefMatrix.IsSquareMatrix Then Throw New MathLib.Exception(206)
      If CoefMatrix.RowSize <> RightMember.RowSize Then Throw New MathLib.Exception(202)

      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      Dim result As New MathLib.Matrix(1, CoefMatrix.ColSize)
      Dim TmpMatrix As MathLib.Matrix
      Dim DetCoefMatrix As Double
      Dim i, j As Integer

      DetCoefMatrix = CoefMatrix.Det

      'For i = 0 To CoefMatrix.RowSize - 1
      '  TmpMatrix = CoefMatrix.Clone
      '  For j = 0 To CoefMatrix.ColSize - 1
      '    TmpMatrix.Item(i, j) = RightMember(i, 0)
      '  Next

      '  result(0, i) = TmpMatrix.Det / DetCoefMatrix

      'Next

      If DetCoefMatrix = 0.0# Then
        Return New MathLib.Matrix(0, 0)
      End If

      For i = 0 To result.ColSize - 1
        TmpMatrix = CoefMatrix.Clone
        For j = 0 To TmpMatrix.RowSize - 1
          TmpMatrix(j, i) = RightMember(j, 0)
        Next


        result(0, i) = TmpMatrix.Det / DetCoefMatrix
      Next

      Return result

    End Function

    ''' <summary>Calcule la matrice de rotation dans un repere orthonormé.</summary>
    ''' <returns>Matrice carré de niveau 3 (3x3)</returns>
    ''' <param name="zAxeRotation">Angle de rotation autoure de l'axe OZ (Cas de la 2D)</param>
    Public Shared Function RotationMatrix(ByVal zAxeRotation As MathLib.Angle) As MathLib.Matrix

      Return RotationMatrixOnlyZ(zAxeRotation)

    End Function

    ''' <summary>Calcule la matrice de rotation dans un repere orthonormé.</summary>
    ''' <param name="rotation">
    '''    <para>Données definissant les angles de rotations.</para>
    ''' </param>
    ''' <param name="rotationOrder"><para>Defini l'ordre des rotations. Les rotations se faisant axe par axe.</para></param>
    Public Shared Function RotationMatrix(ByVal rotation As MathLib.Rotation, ByVal rotationOrder As MathLib.MatrixRotationAxesOrder) As MathLib.Matrix

      Select Case rotationOrder
        Case MatrixRotationAxesOrder.XYZ
          Return MathLib.Algebra.Matrix.RotationMatrixOptimizedXYZ((rotation))
        Case MatrixRotationAxesOrder.XZY
          Return (RotationMatrixOnlyX(rotation.xAxeAngle) * RotationMatrixOnlyZ(rotation.zAxeAngle)) * RotationMatrixOnlyY(rotation.yAxeAngle)
        Case MatrixRotationAxesOrder.YXZ
          Return (RotationMatrixOnlyY(rotation.yAxeAngle) * RotationMatrixOnlyX(rotation.xAxeAngle)) * RotationMatrixOnlyZ(rotation.zAxeAngle)
        Case MatrixRotationAxesOrder.YZX
          Return (RotationMatrixOnlyY(rotation.yAxeAngle) * RotationMatrixOnlyZ(rotation.zAxeAngle)) * RotationMatrixOnlyX(rotation.xAxeAngle)
        Case MatrixRotationAxesOrder.ZXY
          Return (RotationMatrixOnlyZ(rotation.zAxeAngle) * RotationMatrixOnlyX(rotation.xAxeAngle)) * RotationMatrixOnlyY(rotation.yAxeAngle)
        Case MatrixRotationAxesOrder.ZYX
          Return (RotationMatrixOnlyZ(rotation.zAxeAngle) * RotationMatrixOnlyY(rotation.yAxeAngle)) * RotationMatrixOnlyX(rotation.xAxeAngle)
        Case Else
          Throw New System.Exception
      End Select

    End Function

    ''' <summary>Calcule la matrice de rotation dans un repere orthonormé.</summary>
    ''' <returns>Matrice carré de niveau 3 (3x3)</returns>
    ''' <param name="Rotation">Angle de rotation autoure de l'axe OZ (Cas de la 2D)</param>
    Public Shared Function RotationMatrix(ByVal Rotation As MathLib.Rotation) As MathLib.Matrix

      Return RotationMatrixOnlyZ(Rotation.zAxeAngle)

    End Function

    ''' <summary>Calcul du transposé (Noté "t") d'un matrice.</summary>
    ''' <param name="matrixSource">Matrice à transposer</param>
    Public Shared Function Transpose(ByVal matrixSource As MathLib.Matrix) As MathLib.Matrix

      '-- Parameter Validation ----------------------------
      If IsNothing(matrixSource) Then Throw New NullReferenceException
      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      Dim i, j As Integer
      Dim result As New MathLib.Matrix(matrixSource.ColSize, matrixSource.RowSize)
      For i = 0 To result.RowSize - 1
        For j = 0 To result.ColSize - 1
          result(i, j) = matrixSource(j, i)
        Next
      Next

      Return result
    End Function

    Private Shared Function RotationMatrixOnlyX(ByVal xAxeRotation As MathLib.Angle) As MathLib.Matrix

      Dim result As New MathLib.Matrix(3, 3)

      If IsNothing(xAxeRotation) Then
        result(0, 0) = 1
        result(0, 1) = 0
        result(0, 2) = 0
        result(1, 0) = 0
        result(1, 1) = 1
        result(1, 2) = 0
        result(2, 0) = 0
        result(2, 1) = 0
        result(2, 2) = 1
      Else
        result(0, 0) = 1
        result(0, 1) = 0
        result(0, 2) = 0
        result(1, 0) = 0
        result(1, 1) = MathLib.Geometry.trigonometry.Cos(xAxeRotation)
        result(1, 2) = -MathLib.Geometry.trigonometry.Sin(xAxeRotation)
        result(2, 0) = 0
        result(2, 1) = MathLib.Geometry.trigonometry.Sin(xAxeRotation)
        result(2, 2) = MathLib.Geometry.trigonometry.Cos(xAxeRotation)
      End If

      Return result

    End Function

    Private Shared Function RotationMatrixOnlyY(ByVal yAxeRotation As MathLib.Angle) As MathLib.Matrix

      Dim result As New MathLib.Matrix(3, 3)

      If IsNothing(yAxeRotation) Then
        result(0, 0) = 1
        result(0, 1) = 0
        result(0, 2) = 0
        result(1, 0) = 0
        result(1, 1) = 1
        result(1, 2) = 0
        result(2, 0) = 0
        result(2, 1) = 0
        result(2, 2) = 1
      Else
        result(0, 0) = MathLib.Geometry.trigonometry.Cos(yAxeRotation)
        result(0, 1) = 0
        result(0, 2) = -MathLib.Geometry.trigonometry.Sin(yAxeRotation)
        result(1, 0) = 0
        result(1, 1) = MathLib.Geometry.trigonometry.Sin(yAxeRotation)
        result(1, 2) = MathLib.Geometry.trigonometry.Cos(yAxeRotation)
        result(2, 0) = 0
        result(2, 1) = 0
        result(2, 2) = 1
      End If

      Return result

    End Function

    Private Shared Function RotationMatrixOnlyZ(ByVal zAxeRotation As MathLib.Angle) As MathLib.Matrix

      Dim result As New MathLib.Matrix(3, 3)

      If IsNothing(zAxeRotation) Then
        result(0, 0) = 1
        result(0, 1) = 0
        result(0, 2) = 0
        result(1, 0) = 0
        result(1, 1) = 1
        result(1, 2) = 0
        result(2, 0) = 0
        result(2, 1) = 0
        result(2, 2) = 1
      Else
        result(0, 0) = MathLib.Geometry.trigonometry.Cos(zAxeRotation)
        result(0, 1) = -MathLib.Geometry.trigonometry.Sin(zAxeRotation)
        result(0, 2) = 0
        result(1, 0) = MathLib.Geometry.trigonometry.Sin(zAxeRotation)
        result(1, 1) = MathLib.Geometry.trigonometry.Cos(zAxeRotation)
        result(1, 2) = 0
        result(2, 0) = 0
        result(2, 1) = 0
        result(2, 2) = 1
      End If

      Return result

    End Function

    Private Shared Function RotationMatrixOptimizedXYZ(ByVal rotation As MathLib.Rotation)

      Dim A, B, C, D, E, F, AD, BD As Double

      ' Axe X
      If IsNothing(rotation.xAxeAngle) Then
        A = 1
        B = 0
      Else
        A = MathLib.Geometry.trigonometry.Cos(rotation.xAxeAngle)
        B = MathLib.Geometry.trigonometry.Sin(rotation.xAxeAngle)
      End If

      ' Axe Y
      If IsNothing(rotation.yAxeAngle) Then
        C = 1
        D = 0
      Else
        C = MathLib.Geometry.trigonometry.Cos(rotation.yAxeAngle)
        D = MathLib.Geometry.trigonometry.Sin(rotation.yAxeAngle)
      End If

      ' Axe Z
      If IsNothing(rotation.zAxeAngle) Then
        E = 1
        F = 0
      Else
        E = MathLib.Geometry.trigonometry.Cos(rotation.zAxeAngle)
        F = MathLib.Geometry.trigonometry.Sin(rotation.zAxeAngle)
      End If

      AD = A * D
      BD = B * D

      Dim Result As New MathLib.Matrix(3, 3)

      Result(0, 0) = C * E
      Result(0, 1) = -C * F
      Result(0, 2) = -D
      Result(1, 0) = -BD * E + A * F
      Result(1, 1) = BD * F + A * E
      Result(1, 2) = -B * C
      Result(2, 0) = AD * E + B * F
      Result(2, 1) = -AD * F + B * E
      Result(2, 2) = A * C

      Return Result

    End Function

  End Class

End Namespace
