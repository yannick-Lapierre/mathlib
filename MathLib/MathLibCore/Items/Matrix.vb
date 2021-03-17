''' <summary>Representation d'une matrice</summary>
<DebuggerDisplay("Matrix({RowSize},{ColSize}) = {ToString}")> _
Public Structure Matrix

  Private _Data(,) As Double

  ''' <summary>Copie les élément de la matrice vers un tableau</summary>
  ''' <returns>A Double(,) value...</returns>
  Public Function ToArray() As Double(,)
    Return _Data
  End Function

  ''' <summary>Informe si une matrice est carrée</summary>
  ''' <remarks>une matrice est carrée si Nb colonnes = Nb lignes</remarks>
  Public ReadOnly Property IsSquareMatrix() As Boolean
    Get
      Return Me.ColSize = Me.RowSize
    End Get
  End Property

  ''' <summary>Informe sur le Nb de collones de la matrice</summary>
  ''' <remarks>Dimention 1 du tableau de la matrice</remarks>
  Public ReadOnly Property ColSize() As Short
    Get
      Return _Data.GetLength(1)
    End Get
  End Property

  ''' <summary>Crée une nouvelle instance de l'objet</summary>
  ''' <returns></returns>
  Public Function Clone() As Matrix

    Dim TabData(,) As Double

    TabData = _Data.Clone
    Return New Matrix(TabData)

  End Function

  ''' <summary>
  '''     Informe sur le nombre de ligne de la matrice
  ''' </summary>
  ''' <value>
  '''     <para>
  '''         
  '''     </para>
  ''' </value>
  ''' <remarks>
  '''     Dimension 0 du tableau de la matrice
  ''' </remarks>
  Public ReadOnly Property RowSize() As Short
    Get
      Return _Data.GetLength(0)
    End Get
  End Property

  Default Public Property Item(ByVal row As Short, ByVal col As Short) As Double
    Get
      Return _Data.GetValue(row, col)
    End Get
    Set(ByVal value As Double)
      _Data.SetValue(value, row, col)
    End Set
  End Property

  ''' <summary>Calcul le derminant de la matrice</summary>
  ''' <returns>A Double value...</returns>
  Public Function Det() As Double

    Dim Result As Double

    If ColSize = 2 And RowSize = 2 Then
      Result = (Item(0, 0) * Item(1, 1)) - (Item(0, 1) * Item(1, 0))
    Else
      Result = DetSizeSup2()
    End If

    Return Result

  End Function

  Private Function DetSizeSup2() As Double
    Dim Result As Double
    Dim SupprRowIndex As Integer = -1
    Dim SupprColIndex As Integer = -1

    ' On cherche la ligne ou la colonne avec la plus de 0
    Dim MaxNbZero As Integer = 0
    Dim NbZero As Integer = 0
    Dim i, j As Integer

    ' Recherche par ligne
    For i = 0 To RowSize - 1
      NbZero = 0
      For j = 0 To ColSize - 1
        If Item(i, j) = 0 Then NbZero += 1
      Next
      If NbZero > MaxNbZero Then
        SupprRowIndex = i
        MaxNbZero = NbZero
      End If
    Next

    ' Recherche par Colonne
    For i = 0 To ColSize - 1
      NbZero = 0
      For j = 0 To RowSize - 1
        If Item(j, i) = 0 Then NbZero += 1
      Next
      If NbZero > MaxNbZero Then
        SupprColIndex = i
        MaxNbZero = NbZero
      End If
    Next

    ' Un petit test pour le cas ou il n'y ai pas de 0 dans la matrice
    If SupprRowIndex = -1 And SupprColIndex = -1 Then SupprRowIndex = 0

    Result = 0
    ' On calcul
    If SupprRowIndex >= SupprColIndex Then
      ' On supprime 1 ligne => On progresse par colonnes:
      For i = 0 To Me.ColSize - 1
        If Item(SupprRowIndex, i) <> 0 Then
          Result += Item(SupprRowIndex, i) * Cofactor(SupprRowIndex, i)
        End If
      Next

    Else
      ' On supprime 1 colonne => On progresse par lignes:
      For i = 0 To Me.RowSize - 1
        If Item(i, SupprColIndex) <> 0 Then
          Result += Item(i, SupprColIndex) * Cofactor(i, SupprColIndex)
        End If
      Next

    End If

    Return Result

  End Function

  ''' <summary>Supprime une colonne de la matrice</summary>
  ''' <param name="Index">Colonne à supprimer</param>
  Public Sub RemoveCol(ByVal index As Integer)

    Dim i, j As Integer

    For i = 0 To RowSize - 1
      For j = index To ColSize - 2
        _Data(i, j) = _Data(i, j + 1)
      Next
    Next

    ReDim Preserve _Data(_Data.GetLength(0) - 1, _Data.GetLength(1) - 2)

  End Sub

  ''' <summary>Supprime une ligne de la matrice</summary>
  ''' <param name="Index">Ligne à supprimer</param>
  Public Sub RemoveRow(ByVal index As Integer)

    Dim i, j As Integer
    Dim Result(,) As Double

    For i = index To RowSize - 2
      For j = 0 To ColSize - 1
        _Data(i, j) = _Data(i + 1, j)
      Next
    Next

    ReDim Result(_Data.GetLength(0) - 2, _Data.GetLength(1) - 1)

    For i = 0 To Result.GetLength(0) - 1
      For j = 0 To Result.GetLength(1) - 1
        Result(i, j) = _Data(i, j)
      Next
    Next

    _Data = Result.Clone

  End Sub

  ''' <summary>calcul le determinant mineur de la matrice en cours</summary>
  ''' <param name="Row">Indice de la ligne a minorer de la matrice courrante</param>
  ''' <param name="Col">Indice de la colonne a minorer de la matrice courrante</param>
  ''' <returns>A MathLib.Matrix value...</returns>
  Public Function Minor(ByVal Row As Integer, ByVal Col As Integer) As Double

    Dim Result As MathLib.Matrix

    Result = Me.Clone

    Result.RemoveRow(Row)
    Result.RemoveCol(Col)

    Return Result.Det

  End Function

  ''' <summary>Genere le Cofacteur de la matrice en cours</summary>
  ''' <param name="Row">Indice de la ligne a minorer de la matrice courrante</param>
  ''' <param name="Col">Indice de la colonne a minorer de la matrice courrante</param>
  ''' <returns>A MathLib.Matrix value...</returns>
  Public Function Cofactor(ByVal Row As Integer, ByVal Col As Integer) As Double

    If MathLib.General.IsPaire(Row + Col) Then
      Return Minor(Row, Col)
    Else
      Return -Minor(Row, Col)
    End If

  End Function

  ''' <summary>
  '''     Constructeur
  ''' </summary>
  ''' <param name="Value" type="Single(,)">
  '''     <para>
  '''         Tableau a 2 dimension (Ligne,Colone) representant la matrice
  '''     </para>
  ''' </param>
  Public Sub New(ByVal Value(,) As Double)
    _Data = Value
  End Sub

  ''' <summary>
  '''     Constructeur
  ''' </summary>
  ''' <param name="rowSize" type="Short">
  '''     <para>
  '''       Nb lignee de la matrice  
  '''     </para>
  ''' </param>
  ''' <param name="colSize" type="Short">
  '''     <para>
  '''         Nb Colonnes de la matrice
  '''     </para>
  ''' </param>
  Public Sub New(ByVal rowSize As Integer, ByVal colSize As Integer)

    ReDim _Data(rowSize - 1, colSize - 1)
    InitMatrix(Me)

  End Sub

  ''' <summary>
  '''     Constructeur
  ''' </summary>
  Public Sub New(ByVal Data As String)

    Call FromString(Data)

  End Sub

  ''' <summary></summary>
  ''' <param name="Data"></param>
  Public Sub FromString(ByVal Data As String)

    Dim tmpstr As String
    Dim TabRows() As String
    Dim TabCells() As String

    Dim i, j As Integer

    tmpstr = Data

    ' On supprime les '{' & '}'
    tmpstr = tmpstr.Replace("{", String.Empty)
    tmpstr = tmpstr.Replace("}", String.Empty)

    ' Petit tour de passe-passe pour utitliser un Split par la suite.
    tmpstr = tmpstr.Replace("][", "]~[")

    ' On Splite les lignes:
    TabRows = tmpstr.Split("~")

    'on Supprime les caractere non desirable
    For i = 0 To TabRows.Length - 1
      TabRows(i) = TabRows(i).Replace("[", String.Empty)
      TabRows(i) = TabRows(i).Replace("]", String.Empty)
    Next

    ' On remplie l'objet
    TabCells = TabRows(0).Split(";")
    ReDim _Data(TabRows.Length - 1, TabCells.Length - 1)
    InitMatrix(Me)
    For i = 0 To TabRows.Length - 1
      TabCells = TabRows(i).Split(";")
      For j = 0 To TabCells.Length - 1
        _Data(i, j) = TabCells(j)
      Next
    Next

  End Sub

  ''' <summary>
  '''     Retourne les valeurs de la matrice sous forme de chaine de caractère
  ''' </summary>
  ''' <returns>
  '''     A String value...
  ''' </returns>
  Public Overrides Function ToString() As String

    Dim Result As String = String.Empty
    Dim i, j As Short

    Result &= "{"

    For i = 0 To _Data.GetUpperBound(0)
      Result &= "["
      For j = 0 To _Data.GetUpperBound(1)
        If j > 0 Then Result &= ";"
        Result &= _Data(i, j)
      Next
      Result &= "]"
    Next
    Result &= "}"

    Return Result

  End Function

  ''' <summary>
  '''      Informe sur l'égalité entre la matrice et un objet
  ''' </summary>
  ''' <param name="obj" type="Object">
  '''     <para>
  '''         Objet a comparer avec la matrice.
  '''     </para>
  ''' </param>
  ''' <returns>
  '''     A Boolean value...
  ''' </returns>
  Public Overrides Function Equals(ByVal obj As Object) As Boolean

    If TypeOf obj Is Matrix Then
      Return Me = CType(obj, Matrix)
    Else
      Return False
    End If

  End Function

#Region "Operator"

  ''' <summary>
  '''     Addition de 2 Matrice 
  ''' </summary>
  ''' <param name="a" type="MathLib.Matrix">
  '''     <para>
  '''         1ère matrice
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Matrix">
  '''     <para>
  '''         2ème matrice
  '''     </para>
  ''' </param>
  Public Shared Operator +(ByVal a As Matrix, ByVal b As Matrix) As Matrix

    Dim Result As New Matrix(a.RowSize, a.ColSize)
    Dim i, j As Short

    If a.RowSize <> b.RowSize Or a.ColSize <> b.ColSize Then Throw New MathLib.Exception(200)

    For i = 0 To a.RowSize - 1
      For j = 0 To a.ColSize - 1
        Result(i, j) = a(i, j) + b(i, j)
      Next
    Next

    Return Result

  End Operator

  ''' <summary>
  '''     Soustraction de 2 Matrice 
  ''' </summary>
  ''' <param name="a" type="MathLib.Matrix">
  '''     <para>
  '''         1ère matrice
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Matrix">
  '''     <para>
  '''         2ème matrice
  '''     </para>
  ''' </param>
  Public Shared Operator -(ByVal a As Matrix, ByVal b As Matrix) As Matrix

    Dim Result As New Matrix(a.RowSize, a.ColSize)
    Dim i, j As Short

    If a.RowSize <> b.RowSize Or a.ColSize <> b.ColSize Then Throw New MathLib.Exception(200)

    For i = 0 To a.RowSize - 1
      For j = 0 To a.ColSize - 1
        Result(i, j) = a(i, j) - b(i, j)
      Next
    Next

    Return Result

  End Operator

  ''' <summary>
  '''     Test l'égalité entre 2 matrices
  ''' </summary>
  ''' <param name="a" type="MathLib.Matrix">
  '''     <para>
  '''         1ere matrice
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Matrix">
  '''     <para>
  '''         2eme matrice
  '''     </para>
  ''' </param>
  Public Shared Operator =(ByVal a As Matrix, ByVal b As Matrix) As Boolean

    Dim i, j As Short

    If a.RowSize <> b.RowSize Or a.ColSize <> b.ColSize Then Throw New MathLib.Exception(200)

    For i = 0 To a.RowSize - 1
      For j = 0 To a.ColSize - 1
        If a(i, j) <> b(i, j) Then Return False
      Next
    Next

    Return True

  End Operator

  ''' <summary>
  '''     test l'inegalité entre 2 matrices
  ''' </summary>
  ''' <param name="a" type="MathLib.Matrix">
  '''     <para>
  '''         1ere matrice
  '''     </para>
  ''' </param>
  ''' <param name="b" type="MathLib.Matrix">
  '''     <para>
  '''         2ème matrice
  '''     </para>
  ''' </param>
  Public Shared Operator <>(ByVal a As Matrix, ByVal b As Matrix) As Boolean

    Return Not (a = b)

  End Operator

  ''' <summary>
  ''' Réalise la multiplication du matrice
  ''' </summary>
  ''' <param name="a">1ere matrice</param>
  ''' <param name="b">2éme matrice</param>
  ''' <returns></returns>
  Public Shared Operator *(ByVal a As Matrix, ByVal b As Matrix) As Matrix

    If Not MathLib.Algebra.Matrix.IsCompatible(a, b) Then Throw New Exception(201)

    Dim i, j, k As Short
    ' Il s'agie de la taille commune (a.ColSize = b.RowSize)
    Dim commonSize As Short
    Dim value As Double
    Dim result As New Matrix(a.RowSize, b.ColSize)

    commonSize = a.ColSize

    For i = 0 To result.RowSize - 1
      For j = 0 To result.ColSize - 1
        value = 0
        For k = 0 To commonSize - 1
          value += a(i, k) * b(k, j)
        Next
        result(i, j) = value
      Next
    Next

    Return result

  End Operator

  Private Shared Sub InitMatrix(ByRef a As Matrix)

    Dim i, j As Short

    For i = 0 To a.RowSize - 1
      For j = 0 To a.ColSize - 1
        a(i, j) = 0
      Next
    Next

  End Sub



#End Region

End Structure