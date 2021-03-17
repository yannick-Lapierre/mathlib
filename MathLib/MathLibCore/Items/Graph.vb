Option Strict On

<DebuggerDisplay("Name = {name} | nodes = {Nodes.Count} | Edges = {Edges.Count}")> _
Public Class Graph

  Implements System.ICloneable

  Private _directed As Boolean
  Private _EdgeCollection As EdgeCollection
  Private _Name As String
  Private _NodeCollection As NodeCollection

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Direction des arc
  ''' </summary>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' 	[lap_y]	13/07/2006	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Enum EdgeDirection
    ''' <summary>Arc Partant du node de reference</summary>
    Head
    ''' <summary>Arc pointant ver le node de reference</summary>
    Tail
    ''' <summary>Arc dans les 2 sens</summary>
    Both
  End Enum

  ''' <summary>
  ''' Constructeur de classe
  ''' </summary>
  ''' <param name="Directed">Defini si le graphe esr orienté ou non. (AB different de BA ou pas)</param>
  Public Sub New(ByVal Directed As Boolean)
    _directed = Directed

    Call Init()

  End Sub

  ''' <summary>
  ''' Constructeur de classe
  ''' </summary>
  ''' <param name="Name">Nom du graphe</param>
  ''' <param name="Directed">Defini si le graphe esr orienté ou non. (AB different de BA ou pas)</param>
  Public Sub New(ByVal Name As String, ByVal Directed As Boolean)

    _Name = Name
    _directed = Directed

    Call Init()

  End Sub

  ''' <summary>
  ''' Defini si le graphe est orienté ou non
  ''' </summary>
  ''' <value></value>
  ''' <remarks>
  ''' La diference entre un graphe orienté est un graphe non orienté se fait au niveau des aretes
  ''' supposons 2 sommets AB, et une arete {A,B}
  ''' Dans un graphe non orienté il existe 2 chemins : de A vers B et de B vers A
  ''' Dans un graphe orienté il existe 1 seul chemin : A vers B Pour avoir un chemin de B ver A il faut ajouter l'arete {B,A}
  ''' </remarks>
  Public ReadOnly Property Directed() As Boolean
    <DebuggerStepThrough()> _
    Get
      Return _directed
    End Get
  End Property

  ''' <summary>Accesseur à la liste des Aretes</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property Edges() As EdgeCollection
    <DebuggerStepThrough()> _
    Get
      Return _EdgeCollection
    End Get
    <DebuggerStepThrough()> _
    Set(ByVal value As EdgeCollection)
      _EdgeCollection = value
    End Set
  End Property

  ''' <summary> Informe/défini le nom du graphe</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property Name() As String
    Get
      Return _Name
    End Get
    Set(ByVal value As String)
      _Name = value
    End Set
  End Property

  ''' <summary>Accesseur à la liste des sommets</summary>
  ''' <value><para></para></value>
  ''' <remarks></remarks>
  Public Property Nodes() As NodeCollection
    <DebuggerStepThrough()> _
    Get
      Return _NodeCollection
    End Get
    <DebuggerStepThrough()> _
    Friend Set(ByVal value As NodeCollection)
      _NodeCollection = value
    End Set
  End Property

  Private Sub Init()

    _NodeCollection = New NodeCollection(Me)
    _EdgeCollection = New EdgeCollection(Me)

  End Sub

  ''' <summary>
  ''' Genere un clone d'un objet Graphe
  ''' </summary>
  Public Overridable Function Clone() As Object Implements System.ICloneable.Clone

    Return Clone(True)

  End Function
  Public Overridable Function Clone(ByVal keepID As Boolean) As Object

    Dim Result As Graph

    Result = New Graph(Me.Directed)

    Result.Nodes = Me.Nodes.Clone(keepID)
    Result.Nodes.Parent = Result
    Result.Edges = Me.Edges.Clone
    Result.Edges.Parent = Result
    Result.Name = Me.Name

    Return Result

  End Function

  Public Overloads Function Equals(ByVal obj As Graph) As Boolean

    ' On test le niveau graph
    With obj
      If ._directed <> _directed Then Return False
      If Not (.Nodes.Equals(obj.Nodes)) Then Return False
      If Not (.Edges.Equals(obj.Edges)) Then Return False
    End With
    Return True

  End Function

  ''' <summary>
  ''' Informe si le graphe est connexe
  ''' </summary>
  ''' <remarks>
  '''    <para>Utilisation de l'algorithme de parcours en largeur.<br />
  '''    Un graphe non orienté est connexe, si et seulement si pour toute paire de sommets
  '''    [a,b] il existe une chaîne entre les sommets a et b. Si on parle de connexité pour
  '''    un graphe orienté, c'est que l'on considère non pas ce graphe, mais le graphe
  '''    non-orienté correspondant.</para>
  ''' </remarks>
  Public Function Isconnected() As Boolean

    Dim TabNode As New System.Collections.Generic.Queue(Of NodeItem)
    Dim Node As NodeItem
    Dim Neighbors As New NodeCollection
    Dim i As Integer

    Nodes.SetFlagsLocal(False)

    TabNode.Enqueue(Nodes(0))

    ' Explore les noeud jusqu'a ce que la liste soit vide
    Do
      ' On prende (et enleve) le 1er Noed de la liste
      Node = Nodes.ItemByID(TabNode.Dequeue.ID)
      ' On le marque comme parcouru, pour les passages suivants
      Node.FlagLocal = True
      ' On liste les noeuds voisin
      Neighbors = Node.Neighbors(EdgeDirection.Head)
      For i = 0 To Neighbors.Count - 1
        If Neighbors(i).FlagLocal = False Then
          ' Si le neaud n'a pas deja était parcouru, on l'ajoute en fin de liste
          TabNode.Enqueue(Neighbors(i))
        End If
      Next

    Loop Until TabNode.Count = 0

    Return Nodes.IsAllFlaguedLocal(True)

  End Function

  <DebuggerDisplay("Item = {Count}")> _
  Public Class EdgeCollection

    Implements ICollection(Of EdgeItem)

    Private _IsReadOnly As Boolean
    Private _Parent As Graph
    Private _TabEdge As New List(Of EdgeItem)

    ''' <summary>Constructeur</summary>
    Public Sub New()

      _Parent = Nothing

    End Sub

    ''' <summary>Constructeur</summary>
    ''' <param name="parent">Parent de la collebtion</param>
    Public Sub New(ByRef parent As Graph)

      _Parent = parent

    End Sub

    ''' <summary>Informe sur le Nombre d'arête de la collection</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of EdgeItem).Count
      Get
        Return _TabEdge.Count
      End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of EdgeItem).IsReadOnly
      Get
        Return _IsReadOnly
      End Get
    End Property

    ''' <summary>Permet d'acceder à un élément de la collection</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal Index As Integer) As EdgeItem
      <DebuggerStepThrough()> _
      Get
        Return _TabEdge(Index)
      End Get
      <DebuggerStepThrough()> _
      Set(ByVal value As EdgeItem)
        _TabEdge(Index) = value
      End Set
    End Property

    ''' <value><para></para></value>
    ''' <summary>Accesseur à une arête du graphe</summary>
    ''' <param name="tail">Node de départ de l'arête</param>
    ''' <param name="head">Node d'arrivé de l'arête</param>
    Default Public Property Item(ByVal tail As NodeItem, ByVal head As NodeItem) As EdgeItem
      Get
        Dim i As Integer

        For i = 0 To _TabEdge.Count - 1
          If _TabEdge(i).Head = head And _TabEdge(i).Tail = tail Then Return _TabEdge(i)
        Next

        Return Nothing

      End Get
      Set(ByVal value As EdgeItem)
        Item(head, tail) = value
      End Set
    End Property

    ''' <summary>Accesseur au graph parent de la collection</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public Property Parent() As Graph
      <DebuggerStepThrough()> _
      Get
        Return _Parent
      End Get
      <DebuggerStepThrough()> _
      Friend Set(ByVal value As Graph)
        _Parent = value
      End Set
    End Property

    Private Sub RemoveAt(ByVal Index As Integer)
      _TabEdge.RemoveAt(Index)
    End Sub

    ''' <summary>Place toutes les arêtes de la collection dans une état défini</summary>
    ''' <param name="Value">Valeur a affecter aux flags</param>
    Friend Sub SetFlagsLocal(ByVal Value As Boolean)

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        _TabEdge(i).FlagLocal = Value
      Next

    End Sub

    ''' <summary>Ajoute une arête à collection.</summary>
    ''' <param name="item">Arête à ajouter.</param>
    Public Sub Add(ByVal item As EdgeItem) Implements System.Collections.Generic.ICollection(Of EdgeItem).Add

      'Public Function Add(ByVal edge As EdgeItem) As EdgeItem

      '-- Parameter Validation ----------------------------
      If IsNothing(item) Then Throw New NullReferenceException("edge")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      ' On verifie que l'on a pas deja un arc Avec Le meme point de depart et la meme arrivé
      If Not Exist(item) Then
        ' Ajout de l'arête
        item.Parent = Me
        _TabEdge.Add(item)
      ElseIf Me.Item(item.Tail, item.Head).Weight = item.Weight Then
        ' On ne fait rien
      Else
        Throw New MathLib.Exception(409, "Old : " & Me.Item(item.Tail, item.Head).ToString & " | New : " & item.ToString)
      End If

      ' Ajout de l'arête dans l'autre sens
      If Not IsNothing(Parent) AndAlso Not (Parent.Directed) Then
        Dim Edge2 As New EdgeItem(item.Head, item.Tail, item.Weight)
        If Not Exist(Edge2) Then
          ' Ajout de l'arête
          Edge2.Parent = Me
          _TabEdge.Add(Edge2)
        ElseIf Me.Item(Edge2.Tail, Edge2.Head).Weight = Edge2.Weight Then
          ' On ne fait rien
        Else
          Throw New MathLib.Exception(409, "Old : " & Me.Item(Edge2.Tail, Edge2.Head).ToString & " | New : " & Edge2.ToString)
        End If

      End If

    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of EdgeItem).Clear
      If Not _IsReadOnly Then
        _TabEdge.Clear()
      End If
    End Sub

    ''' <summary>Clonne uène collection d'arete</summary>
    ''' <returns>A MathLib.Graph.EdgeCollection value...</returns>
    Public Function Clone() As EdgeCollection

      Dim i As Integer
      Dim ClonedEdge As EdgeItem
      Dim Result As New EdgeCollection

      For i = 0 To Me.Count - 1
        ClonedEdge = Me.Item(i).Clone
        ClonedEdge.Parent = Me
        Result.Add(ClonedEdge)
      Next

      Return Result

    End Function

    Public Function Contains(ByVal item As EdgeItem) As Boolean Implements System.Collections.Generic.ICollection(Of EdgeItem).Contains
      Return _TabEdge.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As EdgeItem, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of EdgeItem).CopyTo
      _TabEdge.CopyTo(array, arrayIndex)
    End Sub

    Public Overloads Function Equals(ByVal obj As EdgeCollection) As Boolean

      Dim i, j As Integer
      Dim Founded As Boolean

      If Me.Count <> obj.Count Then Return False
      ' On test le niveau graph
      With obj
        For i = 0 To Me.Count - 1
          Founded = False
          For j = 0 To obj.Count - 1
            If Me.Item(i) = obj.Item(j) Then
              Founded = True
              Exit For
            End If
            If Not Founded Then Return False
          Next
        Next
      End With

      Return True

    End Function

    ''' <summary>Informe sur l'existance de cette arête</summary>
    ''' <param name="edge">Arête à tester</param>
    ''' <returns>A Boolean value...</returns>
    Public Function Exist(ByVal edge As EdgeItem) As Boolean

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        If edge.IsSameWay(_TabEdge(i)) Then Return True
      Next

      Return False

    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
      Return _TabEdge.GetEnumerator()
    End Function

    Public Function GetTypedEnumerator() As System.Collections.Generic.IEnumerator(Of EdgeItem) Implements System.Collections.Generic.IEnumerable(Of EdgeItem).GetEnumerator
      Return _TabEdge.GetEnumerator()
    End Function

    ''' <summary> Informe si tout les element on leur flag à une valeur voulue</summary>
    ''' <param name="Value">Valeur voulu</param>
    ''' <returns>A Boolean value...</returns>
    Public Function IsAllFlagued(ByVal Value As Boolean) As Boolean

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        If _TabEdge(i).Flag <> Value Then Return False
      Next

      Return True

    End Function

    ''' <summary> Informe si tout les element on leur flag à une valeur voulue</summary>
    ''' <param name="Value">Valeur voulu</param>
    ''' <returns>A Boolean value...</returns>
    Public Function IsAllFlaguedLocal(ByVal Value As Boolean) As Boolean

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        If _TabEdge(i).FlagLocal <> Value Then Return False
      Next

      Return True

    End Function

    ''' <summary>Suppression d'une arête.</summary>
    ''' <param name="index">Indice de l'arête à supprimer</param>
    Public Sub Remove(ByVal index As Integer)

      Dim Edge As EdgeItem

      Edge = Item(index)
      Remove(Edge)

    End Sub

    ''' <summary>Suppression d'une arête.</summary>
    ''' <param name="item">Arête à supprimer</param>
    Public Function Remove(ByVal item As EdgeItem) As Boolean Implements System.Collections.Generic.ICollection(Of EdgeItem).Remove

      For i = 0 To _TabEdge.Count - 1
        If _TabEdge(i) = item Then
          Me.RemoveAt(i)
          Exit For
        End If
      Next

      If Not IsNothing(Parent) AndAlso Not Parent.Directed Then
        Dim Edge2 As New EdgeItem(item.Head, item.Tail)
        If Exist(Edge2) Then Remove(Edge2)
      End If

    End Function

    ''' <summary>Place tout les flags des sommets de la collection dans une état défini</summary>
    ''' <param name="Value">Valeur a affecter aux flags</param>
    Public Sub SetFlags(ByVal Value As Boolean)

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        _TabEdge(i).Flag = Value
      Next

    End Sub

    ''' <summary>
    ''' Defini une valeur identique au cout de toutes les aretes
    ''' </summary>
    ''' <param name="Weight">Cout a affecter aux aretes</param>
    ''' <remarks>
    ''' </remarks>
    Public Sub SetWeight(ByVal Weight As Double)

      Dim i As Integer

      For i = 0 To _TabEdge.Count - 1
        _TabEdge(i).Weight = Weight
      Next

    End Sub

    ''' <summary>
    ''' Convertie la collection en une chaine de caractère<br />
    ''' ex: {(1,2),(2,3)}
    ''' </summary>
    Public Overrides Function ToString() As String

      Dim Result As String
      Dim i As Integer

      Result = "{"
      For i = 0 To _TabEdge.Count - 1
        If i > 0 Then Result &= ","
        Result &= _TabEdge(i).ToString
      Next
      Result &= "}"

      Return Result

    End Function
  End Class

  ''' <summary>Arete des Graphes</summary>
  ''' <remarks>
  ''' Cette structure etant utilisé dans l'objet Edge, on suppose que le sommet de depart est connue.
  ''' </remarks>
  <DebuggerDisplay("{ToString}")> _
  Public Class EdgeItem

    Private _Flag As Boolean

    Private _FlagLocal As Boolean

    ''' <summary>Sommet destination de l'arete</summary>
    Private _head As NodeItem
    Private _Index As Integer

    Private _Parent As EdgeCollection
    ''' <summary>Sommet de depart de l'arete</summary>
    Private _tail As NodeItem
    ''' <summary>Cout de l'arete</summary>
    Private _weight As Double


    Public Sub New()

      _tail = Nothing
      _head = Nothing
      _weight = 0

    End Sub

    ''' <summary>Constructeur</summary>
    ''' <param name="tail">Node de départ de l'arête</param>
    ''' <param name="head">Node d'arrivé de l'arête</param>
    Public Sub New(ByVal tail As NodeItem, ByVal head As NodeItem)

      Call SetValue(tail, head, 1)

    End Sub

    ''' <summary>Constructeur</summary>
    ''' <param name="tail">Node de départ de l'arête</param>
    ''' <param name="head">Node d'arrivé de l'arête</param>
    ''' <param name="weight">Poid associé à l'arête</param>
    Public Sub New(ByVal tail As NodeItem, ByVal head As NodeItem, ByVal weight As Double)

      Call SetValue(tail, head, weight)

    End Sub

    ''' <summary>
    '''    <para>Informe/Defini l'état du Flag de l'arête.<br />
    '''    Cette variable ne sert que pour des calculs interne à la classe .</para>
    ''' </summary>
    ''' <value><para></para></value>
    Friend Property FlagLocal() As Boolean
      Get
        Return _FlagLocal
      End Get
      Set(ByVal value As Boolean)
        _FlagLocal = value
      End Set
    End Property

    ''' <summary>Informe/Defini l'état du Flag du node</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public Property Flag() As Boolean
      Get
        Return _Flag
      End Get
      Set(ByVal value As Boolean)
        _Flag = value
      End Set
    End Property

    ''' <summary>Sommet destination de l'arete</summary>
    Public Property Head() As NodeItem
      Get
        Return _head
      End Get
      Set(ByVal value As NodeItem)
        _head = value
      End Set
    End Property

    ''' <summary>Accesseur à la collection Parente</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public Property Parent() As EdgeCollection
      Get
        Return _Parent
      End Get
      Set(ByVal value As EdgeCollection)
        _Parent = value
      End Set
    End Property

    ''' <summary>Accesseur au graphe parent</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public ReadOnly Property ParentGraph() As Graph
      <DebuggerStepThrough()> _
      Get
        Return _Parent.Parent
      End Get
    End Property

    ''' <summary>Sommet de depart de l'arete</summary>
    Public Property Tail() As NodeItem
      Get
        Return _tail
      End Get
      Set(ByVal value As NodeItem)
        _tail = value
      End Set
    End Property

    ''' <summary>Cout de l'arete</summary>
    Public Property Weight() As Double
      Get
        Return _weight
      End Get
      Set(ByVal value As Double)
        _weight = value
      End Set
    End Property

    ''' <summary>
    ''' Permet de réaliser un copie d'un arc
    ''' </summary>
    ''' <remarks>
    ''' Aucun donnée n'est passé par reference.
    ''' </remarks>
    Public Function Clone() As EdgeItem

      Dim Result As New EdgeItem

      With Result
        .Head = Head
        .Tail = Tail
        .Weight = Weight
        .Flag = Me.Flag
        .FlagLocal = Me.FlagLocal
        .Parent = Me.Parent
      End With

      Return Result

    End Function

    ''' <summary>
    ''' Compare 2 Objets Edge
    ''' </summary>
    ''' <param name="obj">Objet à comparer avec l'objet en cour</param>
    ''' <param name="Isdirected">Defini si on doit tester dans un cas orienté</param>
    Public Overloads Function Equals(ByVal obj As EdgeItem, ByVal Isdirected As Boolean) As Boolean

      Dim Ok1 As Boolean
      Dim Ok2 As Boolean

      If IsNothing(obj) Then Return False

      If Me.Weight <> obj.Weight Then Return False

      '-- Cas orienté ------------------
      Ok1 = True
      If Me.Tail.Name.ToLower <> obj.Tail.Name.ToLower Then Ok1 = False
      If Me.Head.Name.ToLower <> obj.Head.Name.ToLower Then Ok1 = False

      '-- Test le cas non orienté ------
      If Not Isdirected Then
        Ok2 = True
        If Me.Tail.Name.ToLower <> obj.Head.Name.ToLower Then Ok2 = False
        If Me.Head.Name.ToLower <> obj.Tail.Name.ToLower Then Ok2 = False
      End If

      ' Si 1 des cas est bon, c'est bon!!!!
      Return Ok1 Or Ok2

    End Function

    ''' <summary>Informe sur le fait que 2 aretes aient le même point de départ et le meme point d'arrivé</summary>
    ''' <param name="edge">Node a comparté avec la node actuel</param>
    ''' <returns>A Boolean value...</returns>
    Public Function IsSameWay(ByVal edge As EdgeItem) As Boolean

      Return IsSameWay(Me, edge)

    End Function

    ''' <summary>Informe sur le fait que 2 aretes aient le même point de départ et le meme point d'arrivé</summary>
    ''' <param name="edge1">1ère arête</param>
    ''' <param name="edge2">2ème arête</param>
    ''' <returns>A Boolean value...</returns>
    Public Shared Function IsSameWay(ByVal edge1 As EdgeItem, ByVal edge2 As EdgeItem) As Boolean

      If edge1.Head <> edge2.Head Then Return False
      If edge1.Tail <> edge2.Tail Then Return False

      Return True

    End Function

    ''' <summary>
    ''' Ajoute une arete au graphe
    ''' </summary>
    ''' <param name="Tail">Depart de l'arete (pour les graphes orienté)</param>
    ''' <param name="Head">Destination de l'arete (pour les graphes orienté)</param>
    ''' <param name="Weight">Cout de l'arete</param>
    Public Sub SetValue(ByVal tail As NodeItem, ByVal head As NodeItem, ByVal weight As Double)

      '-- Parameter Validation ----------------------------
      If IsNothing(tail) Then Throw New NullReferenceException("tail")
      If IsNothing(head) Then Throw New NullReferenceException("head")
      '-- Internal Data Validation ------------------------

      '-- Exit Case ---------------------------------------

      '----------------------------------------------------

      _tail = tail
      _head = head
      _weight = weight

    End Sub

    Public Overrides Function ToString() As String

      Return "(" & Tail.ToString & "," & Head.ToString & "," & Weight.ToString & ")"

    End Function

    Public Shared Operator =(ByVal Val1 As EdgeItem, ByVal Val2 As EdgeItem) As Boolean

      If IsNothing(Val1) And IsNothing(Val2) Then Return True

      If IsNothing(Val1) Xor IsNothing(Val2) Then Return False

      If Val1.Head <> Val2.Head Then Return False
      If Val1.Tail <> Val2.Tail Then Return False
      If Val1.Weight <> Val2.Weight Then Return False

      Return True

    End Operator

    Public Shared Operator <>(ByVal Val1 As EdgeItem, ByVal Val2 As EdgeItem) As Boolean
      Return Not Val1 = Val2
    End Operator

  End Class

  <DebuggerDisplay("Item = {Count}")> _
  Public Class NodeCollection

    Implements ICollection(Of NodeItem)

    Private _IsReadOnly As Boolean
    Private _Parent As Graph
    Private _TabNode As New List(Of NodeItem)

    ''' <summary>Constructeur</summary>
    Public Sub New()

      _Parent = Nothing

    End Sub


    ''' <summary>Constructeur</summary>
    ''' <param name="parent">Parent de la collebtion</param>
    Public Sub New(ByRef parent As Graph)

      _Parent = parent

    End Sub

    ''' <summary>Informe sur le nombre de sommet present dans la collection</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of NodeItem).Count
      Get
        Return _TabNode.Count
      End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of NodeItem).IsReadOnly
      Get
        Return _IsReadOnly
      End Get
    End Property

    ''' <summary>Accesseur à un élément de la liste</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal Index As Integer) As NodeItem
      Get
        Return _TabNode(Index)
      End Get
      Set(ByVal value As NodeItem)
        _TabNode(Index) = value
      End Set
    End Property

    ''' <summary>Accesseur à un élément de la liste</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Default Public Property Item(ByVal Name As String) As NodeItem
      Get

        Dim i As Integer

        For i = 0 To _TabNode.Count - 1
          If String.Equals(_TabNode(i).Name, Name, StringComparison.OrdinalIgnoreCase) Then
            Return Item(i)
          End If
        Next

        Return Nothing

      End Get
      Set(ByVal value As NodeItem)

        For i = 0 To _TabNode.Count - 1
          If String.Equals(_TabNode(i).Name, Name, StringComparison.OrdinalIgnoreCase) Then
            Me.Item(i) = value
          End If
        Next

        Throw New Exception(404, "Name : '" & Name & "'")

      End Set
    End Property

    ''' <summary>Accesseur a un élément de la liste en fonction de son identifiant</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public Property ItemByID(ByVal ID As String) As NodeItem
      Get
        Return Item(GetIndexFromID(ID))
      End Get
      Set(ByVal value As NodeItem)
        value.ID = ID
        Item(GetIndexFromID(ID)) = value
      End Set
    End Property

    Public Property Parent() As Graph
      <DebuggerStepThrough()> _
      Get
        Return _Parent
      End Get
      <DebuggerStepThrough()> _
      Friend Set(ByVal value As Graph)
        _Parent = value
      End Set
    End Property

    ''' <summary>Genere un Identifiant unique pour le sommet</summary>
    ''' <returns>A Integer value...</returns>
    Private Function GenID() As String

      Return System.Guid.NewGuid.ToString

    End Function

    ''' <summary> Informe si tout les element on leur flag Local à une valeur voulue</summary>
    ''' <param name="Value">Valeur voulu</param>
    ''' <returns>A Boolean value...</returns>
    Friend Function IsAllFlaguedLocal(ByVal Value As Boolean) As Boolean

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        If _TabNode(i).FlagLocal <> Value Then Return False
      Next

      Return True

    End Function

    ''' <summary>Ajoute un sommet à collection.</summary>
    ''' <param name="item">Sommet à ajouter.</param>
    Public Sub Add(ByVal item As NodeItem) Implements System.Collections.Generic.ICollection(Of NodeItem).Add
      'Public Function Add(ByVal node As NodeItem) As NodeItem

      Call Add(item, False)

    End Sub

    ''' <summary>Ajoute un sommet à collection.</summary>
    ''' <param name="node">Sommet à ajouter.</param>
    ''' <param name="keepID">Defini si le node doit garder la même ID</param>
    ''' <returns>A MathLib.Graph.NodeItem value...</returns>
    Public Function Add(ByVal node As NodeItem, ByVal keepID As Boolean) As NodeItem

      Dim NewNode As NodeItem

      NewNode = node.Clone

      If Not keepID Then NewNode.ID = GenID()
      ' On verifie que l'on a pas deja un node avec ce nom
      For i = 0 To _TabNode.Count - 1
        If _TabNode(i) = NewNode Then Throw New MathLib.Exception(2, NewNode.ToString)
      Next

      NewNode.Parent = Me
      _TabNode.Add(NewNode)

      Return NewNode

    End Function

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of NodeItem).Clear

    End Sub

    ''' <summary>Clonne uène collection de sommet</summary>
    ''' <returns>A MathLib.Graph.EdgeCollection value...</returns>
    Public Function Clone(ByVal KeepId As Boolean) As NodeCollection

      Dim i As Integer
      Dim Result As New NodeCollection
      Dim ClonedNode As NodeItem

      For i = 0 To Me.Count - 1
        ClonedNode = Me.Item(i).Clone
        ClonedNode.Parent = Me
        Result.Add(ClonedNode, KeepId)
      Next

      Return Result

    End Function

    Public Function Contains(ByVal item As NodeItem) As Boolean Implements System.Collections.Generic.ICollection(Of NodeItem).Contains

      Return _TabNode.Contains(item)

    End Function

    Public Sub CopyTo(ByVal array() As NodeItem, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of NodeItem).CopyTo

      _TabNode.CopyTo(array, arrayIndex)

    End Sub

    Public Overloads Function Equals(ByVal obj As NodeCollection) As Boolean

      Dim i, j As Integer
      Dim Founded As Boolean

      If Me.Count <> obj.Count Then Return False
      ' On test le niveau graph
      With obj
        For i = 0 To Me.Count - 1
          Founded = False
          For j = 0 To obj.Count - 1
            If Me.Item(i) = obj.Item(j) Then
              Founded = True
              Exit For
            End If
            If Not Founded Then Return False
          Next
        Next
      End With

      Return True

    End Function

    ''' <summary> Informe de l'existance dans la liste d'un node Ayant un identifiant défini</summary>
    ''' <param name="ID">Identifiant à rechercher</param>
    ''' <returns>A Boolean value...</returns>
    Public Function ExistID(ByVal ID As String) As Boolean

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        If _TabNode(i).ID = ID Then Return True
      Next

      Return False

    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
      Return _TabNode.GetEnumerator
    End Function

    ''' <summary>Retourne l'index du node en fonction de l'ID</summary>
    ''' <param name="ID">ID du Node dont l'index est recherché</param>
    ''' <returns>-1 si l'ID est inconue</returns>
    Public Function GetIndexFromID(ByVal ID As String) As Integer

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        If _TabNode(i).ID = ID Then Return i
      Next

      Return -1

    End Function

    Public Function GetTypedEnumerator() As System.Collections.Generic.IEnumerator(Of NodeItem) Implements System.Collections.Generic.IEnumerable(Of NodeItem).GetEnumerator
      Return _TabNode.GetEnumerator
    End Function

    ''' <summary> Informe si tout les element on leur flag à une valeur voulue</summary>
    ''' <param name="Value">Valeur voulu</param>
    ''' <returns>A Boolean value...</returns>
    Public Function IsAllFlagued(ByVal Value As Boolean) As Boolean

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        If _TabNode(i).Flag <> Value Then Return False
      Next

      Return True

    End Function


    Public Sub Remove(ByVal index As Integer)

      _TabNode.RemoveAt(index)

    End Sub

    ''' <summary>Suppression d'un sommet.</summary>
    ''' <param name="item">élément à supprimer</param>
    Public Function Remove(ByVal item As NodeItem) As Boolean Implements System.Collections.Generic.ICollection(Of NodeItem).Remove

      _TabNode.Remove(item)

    End Function

    ''' <summary>Suppression d'un sommet</summary>
    ''' <param name="nodeName">Nom du sommet à supprimer</param>
    Public Sub remove(ByVal nodeName As String)

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        If String.Equals(_TabNode.Item(i).Name, nodeName, StringComparison.OrdinalIgnoreCase) Then
          Me.Remove(i)
          Exit For
        End If
      Next

    End Sub

    ''' <summary>Suppression d'un node en fonction de l'ID</summary>
    ''' <param name="ID">ID du node à supprimé</param>
    Public Sub RemoveByID(ByVal ID As String)

      Dim Index As Integer

      Index = GetIndexFromID(ID)

      If Index >= 0 Then
        Remove(Index)
      End If

    End Sub

    ''' <summary>Place tout les flags des sommets de la collection dans une état défini</summary>
    ''' <param name="Value">Valeur a affecter aux flags</param>
    Public Sub SetFlags(ByVal Value As Boolean)

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        _TabNode(i).Flag = Value
      Next

    End Sub

    ''' <summary>Place tout les flags locaux des sommets de la collection dans une état défini</summary>
    ''' <param name="Value">Valeur a affecter aux flags</param>
    Public Sub SetFlagsLocal(ByVal Value As Boolean)

      Dim i As Integer

      For i = 0 To _TabNode.Count - 1
        _TabNode(i).FlagLocal = Value
      Next

    End Sub
  End Class

  ''' <summary>
  ''' Objet sommet. Le sommet est un point du graph
  ''' </summary>
  ''' <remarks>
  ''' </remarks>

  <DebuggerDisplay("{ToString}")> _
  Public Class NodeItem

    Private _Flag As Boolean
    Private _FlagLocal As Boolean
    ''' <summary>Identification unique du sommet</summary>
    Private _Id As String = String.Empty
    Private _Name As String
    Private _Parent As NodeCollection
    ''' <summary>
    ''' Conteneur multi utilisation
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private _Tag As Object

    Friend Sub New(ByVal parent As NodeCollection)
      _Parent = parent
    End Sub

    Friend Sub New(ByVal name As String, ByVal parent As NodeCollection)
      _Name = name
      _Parent = parent
    End Sub

    ''' <summary>
    ''' Permet d'avoir un constructeur pour pouvoir surcharger l'objet
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Sub New()
      _Parent = Nothing
    End Sub

    ''' <summary>Constructeur de class</summary>
    ''' <param name="name"></param>
    Public Sub New(ByVal name As String)
      _Name = name
      _Parent = Nothing
    End Sub

    ''' <summary> Accesseur a la collection parente du node</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Friend Property Parent() As NodeCollection
      Get
        Return _Parent
      End Get
      Set(ByVal value As NodeCollection)
        _Parent = value
      End Set
    End Property

    ''' <summary> Accesseur au graph parent du node</summary>
    Friend ReadOnly Property ParentGraph() As Graph
      Get
        Return Me.Parent.Parent
      End Get
    End Property

    ''' <summary>Informe/Defini l'état du Flag du node</summary>
    ''' <value><para></para></value>
    ''' <remarks></remarks>
    Public Property Flag() As Boolean
      Get
        Return _Flag
      End Get
      Set(ByVal value As Boolean)
        _Flag = value
      End Set
    End Property

    ''' <summary>
    ''' Informe/Defini l'état du FlagLocal du node.<br />
    ''' Cette variable ne sert que pour des calculs interne à la classe .
    ''' </summary>
    ''' <value><para></para></value>
    Public Property FlagLocal() As Boolean
      Get
        Return _FlagLocal
      End Get
      Set(ByVal value As Boolean)
        _FlagLocal = value
      End Set
    End Property

    ''' <summary>
    ''' Informe sur l'index du node dans la liste des node du graph
    ''' </summary>
    ''' <value>
    ''' Indice de l'élément dans le graph.<br />
    ''' -1 si l'élément n'appartient pas àun graph.
    ''' </value>
    Public Property ID() As String
      <DebuggerStepThrough()> _
      Get
        Return _Id
      End Get
      <DebuggerStepThrough()> _
      Friend Set(ByVal value As String)
        _Id = value
      End Set
    End Property

    ''' <summary>
    ''' Nom du sommet
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    Public Property Name() As String
      <DebuggerStepThrough()> _
      Get
        Return _Name
      End Get
      <DebuggerStepThrough()> _
      Set(ByVal Value As String)
        _Name = Value
      End Set
    End Property

    ''' <summary>
    ''' Conteneur General.
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' Champs permetant de placer une donnée que l'on veut associer au sommet
    ''' </remarks>
    Public Property Tag() As Object
      <DebuggerStepThrough()> _
      Get
        Return _Tag
      End Get
      <DebuggerStepThrough()> _
      Set(ByVal Value As Object)
        _Tag = Value
      End Set
    End Property

    ''' <summary>
    ''' Permet de réaliser un copie d'un arc
    ''' </summary>
    ''' <remarks>
    ''' Aucun donnée n'est passé par reference.
    ''' </remarks>
    Public Function Clone() As NodeItem

      Dim Result As New NodeItem

      With Result
        .Name = Me.Name
        .Tag = Me.Tag
        .ID = Me.ID
        .Flag = Me.Flag
        .FlagLocal = Me.FlagLocal
        .Parent = Me.Parent
      End With

      Return Result

    End Function

    ''' <summary>Liste les aretes ayant un lien avec le sommet</summary>
    ''' <param name="Direction"></param>
    ''' <returns>A MathLib.Graph.EdgeCollection value...</returns>
    Public Function Edges(ByVal Direction As EdgeDirection) As EdgeCollection

      Dim Result As New EdgeCollection
      Dim i As Integer

      With ParentGraph.Edges
        For i = 0 To .Count - 1
          If (Direction = EdgeDirection.Head Or Direction = EdgeDirection.Both) And .Item(i).Tail = Me Then
            Result.Add(.Item(i))
          End If
          If (Direction = EdgeDirection.Tail Or Direction = EdgeDirection.Both) And .Item(i).Head = Me Then
            Result.Add(.Item(i))
          End If
        Next
      End With

      Return Result

    End Function

    ''' <summary>Liste les aretes ayant un lien avec le sommet</summary>
    ''' <param name="Direction"></param>
    ''' <returns>A MathLib.Graph.EdgeCollection value...</returns>
    Public Function Edges(ByVal OtherNode As NodeItem, ByVal Direction As EdgeDirection) As EdgeCollection

      Dim Result As New EdgeCollection
      Dim i As Integer

      With ParentGraph.Edges
        For i = 0 To .Count - 1
          If (Direction = EdgeDirection.Head Or Direction = EdgeDirection.Both) And .Item(i).Tail = Me And .Item(i).Head = OtherNode Then
            Result.Add(.Item(i))
          End If
          If (Direction = EdgeDirection.Tail Or Direction = EdgeDirection.Both) And .Item(i).Head = Me And .Item(i).Tail = OtherNode Then
            Result.Add(.Item(i))
          End If
        Next
      End With

      Return Result

    End Function



    ''' <summary>
    ''' Compare  2 Nodes
    ''' </summary>
    ''' <param name="obj">Objet a comparer avec l'objet en cour</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Public Overloads Function Equals(ByVal obj As NodeItem) As Boolean


      If IsNothing(obj) Then Return False

      If Not String.Equals(Name, obj.Name, StringComparison.OrdinalIgnoreCase) Then Return False
      If Tag.Equals(obj.Tag) Then Return False

      Return True

    End Function

    ''' <summary>Liste les nodes Voisin du node actuel</summary>
    ''' <returns>A MathLib.Graph.NodeCollection value...</returns>
    Public Function Neighbors() As NodeCollection

      Return Neighbors(EdgeDirection.Both)

    End Function

    ''' <summary>Liste les nodes Voisin du node actuel</summary>
    ''' <param name="Direction">DIrection de l'arete</param>
    ''' <returns>A MathLib.Graph.NodeCollection value...</returns>
    Public Function Neighbors(ByVal Direction As EdgeDirection) As NodeCollection

      Dim Result As New NodeCollection '(Me.ParentGraph)
      Dim EdgeCol As EdgeCollection
      Dim i As Integer

      EdgeCol = Me.Edges(Direction)

      For i = 0 To EdgeCol.Count - 1
        If Direction = EdgeDirection.Head Or Direction = EdgeDirection.Both Then
          If EdgeCol.Item(i).Tail = Me Then
            Result.Add(EdgeCol.Item(i).Head, True)
          End If
        End If
        If Direction = EdgeDirection.Tail Or Direction = EdgeDirection.Both Then
          If EdgeCol.Item(i).Head = Me Then
            Result.Add(EdgeCol.Item(i).Tail, True)
          End If
        End If
      Next

      Return Result

    End Function

    ''' <summary>Supprime des Arete ayant un lien avec le node</summary>
    ''' <param name="Direction">Sens des arêtes à supprimer</param>
    Public Sub RemoveEdge(ByVal Direction As EdgeDirection)

      Dim i As Integer
      Dim FlagSuppr As Boolean

      i = 0
      Do While i < Me.ParentGraph.Edges.Count

        FlagSuppr = False

        Select Case Direction
          Case EdgeDirection.Head
            If Me.ParentGraph.Edges(i).Tail = Me Then
              ParentGraph.Edges.Remove(i)
              FlagSuppr = True
            End If

          Case EdgeDirection.Tail
            If Me.ParentGraph.Edges(i).Head = Me Then
              ParentGraph.Edges.Remove(i)
              FlagSuppr = True
            End If

          Case Else
            If Me.ParentGraph.Edges(i).Tail = Me Or Me.ParentGraph.Edges(i).Head = Me Then
              ParentGraph.Edges.Remove(i)
              FlagSuppr = True
            End If
        End Select

        If Not FlagSuppr Then i += 1

      Loop

    End Sub

    Public Overrides Function ToString() As String

      Dim Result As String

      Result = Me.ID.ToString

      If Me.Name <> String.Empty Then Result &= " - [" & Me.Name & "]"
      If Me.Flag Then Result &= " - flag : " & Chr(7)

      Return Result

    End Function

    Public Shared Operator =(ByVal Val1 As NodeItem, ByVal Val2 As NodeItem) As Boolean
      If Val1.ID <> Val2.ID Then Return False
      Return True
    End Operator

    Public Shared Operator <>(ByVal Val1 As NodeItem, ByVal Val2 As NodeItem) As Boolean
      Return Not Val1 = Val2
    End Operator
  End Class

End Class
