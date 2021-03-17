'Namespace Math.Graph.Edge

'#Region "Clone"
'	<TestClass(),<TestCategory("Graph.Edge")> _
'	Public Class Clone

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Public Sub _Normal()

'      Dim E1 As MathLib.Graph.S_Edge
'      Dim E2 As MathLib.Graph.S_Edge

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      E1 = oGraph.Edge_ADD("N1", "N2", 3)

'      E2 = E1.Clone

'      Assert.IsTrue(E2.Equals(E1))

'    End Sub

'  End Class

'#End Region

'#Region "Equals"
'  <TestClass(),<TestCategory("Graph.Edge")> _
'  Public Class Equals

'    Private E1 As MathLib.Graph.S_Edge
'    Private E2 As MathLib.Graph.S_Edge
'    Private Node1 As MathLib.Graph.Node
'    Private Node2 As MathLib.Graph.Node
'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      E1 = Nothing
'      E2 = Nothing
'      Node1 = Nothing
'      Node2 = Nothing
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Public Sub Egalité_non_orienté()

'      oGraph = New MathLib.Graph(False)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node1
'      E2.Tail = Node2
'      E2.Weight = 1

'      Assert.IsTrue(E1.Equals(E2, False))

'    End Sub

'    <Testmethod()> _
'   Public Sub Egalité_orienté()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node1
'      E2.Tail = Node2
'      E2.Weight = 1

'      Assert.IsTrue(E1.Equals(E2, False))

'    End Sub

'    <Testmethod()> _
'   Public Sub Egalité_Inverse_orienté()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node2
'      E2.Tail = Node1
'      E2.Weight = 1

'      ' cas d'un graphe orienté
'      Assert.IsFalse(E1.Equals(E2, True))

'    End Sub

'    <Testmethod()> _
'   Public Sub Egalité_Inverse_non_orienté()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node2
'      E2.Tail = Node1
'      E2.Weight = 1

'      ' cas d'un graphe non orienté
'      Assert.IsTrue(E1.Equals(E2, False))

'    End Sub

'    <Testmethod()> _
'   Public Sub Difference_sur_les_couts_orienté()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node1
'      E2.Tail = Node2
'      E2.Weight = 2

'      ' cas d'un graphe orienté
'      Assert.IsFalse(E1.Equals(E2, True))

'    End Sub

'    <Testmethod()> _
'   Public Sub Difference_sur_les_couts_non_orienté()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      E1.Head = Node1
'      E1.Tail = Node2
'      E1.Weight = 1

'      E2.Head = Node1
'      E2.Tail = Node2
'      E2.Weight = 2

'      ' cas d'un graphe non orienté
'      Assert.IsFalse(E1.Equals(E2, False))

'    End Sub

'  End Class

'#End Region

'End Namespace

'Namespace Math.Graph

'#Region "Add"
'  <TestClass()> _
'  Public Class add

'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal()

'      Dim N1 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")

'      Assert.IsTrue(N1.Equals(oGraph.Item(CShort(0))))

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'   Sub Vide()

'      oGraph.ADD("")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'   Sub _Nothing()

'      oGraph.ADD(Nothing)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub _Doublon_Debut()

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N1")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub _Doublon_Millieu()

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N2")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub _Doublon_Fin()

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N3")

'    End Sub

'  End Class
'#End Region

'#Region "Directed"
'  <TestClass()> _
'  Public Class Directed

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Non_Oriente()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Oriente()
'      oGraph = New MathLib.Graph(True)
'    End Sub

'  End Class
'#End Region

'#Region "Item"
'  <TestClass()> _
'  Public Class Item

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(True)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal_seul()

'      Call oGraph.ADD("N1")
'      Assert.AreEqual("N1", oGraph.Item(CShort(0)).Name)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal_Par_Nom()

'      Call oGraph.ADD("N1")
'      Assert.AreEqual("N1", oGraph.Item("N1").Name)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal_Premier()

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Assert.AreEqual("N1", oGraph.Item(CShort(0)).Name)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal_Dernier()

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Assert.AreEqual("N3", oGraph.Item(CShort(2)).Name)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub sans_sommet_defini()

'      Dim oNode As MathLib.Graph.Node
'      oNode = oGraph.Item(CShort(0))

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Item_Negatif()

'      Dim oNode As MathLib.Graph.Node
'      oNode = oGraph.Item(CShort(-1))

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Item_Superieur_max()

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      Dim oNode As MathLib.Graph.Node
'      oNode = oGraph.Item(CShort(3))

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Item_Nothing_Sur_String()

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Dim i As String = Nothing

'      Dim oNode As MathLib.Graph.Node
'      oNode = oGraph.Item(i)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Item_Nom_inexistant()

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      Dim oNode As MathLib.Graph.Node
'      oNode = oGraph.Item("N3")

'    End Sub

'  End Class
'#End Region

'#Region "Count"
'  <TestClass()> _
'  Public Class Count

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal()

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      Assert.AreEqual(3, oGraph.Count)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Sans_sommet()
'      Assert.AreEqual(0, oGraph.Count)
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Sans_sommet_apres_Suppression()
'      oGraph.ADD("N1")
'      oGraph.Suppr("N1")

'      Assert.AreEqual(0, oGraph.Count)
'    End Sub

'  End Class
'#End Region

'#Region "Suppr"

'  <TestClass()> _
'  Public Class Suppr

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_String()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.Suppr("N2")

'      If oGraph.Item(CShort(0)).Name <> "N1" Then Assert.Fail()
'      If oGraph.Item(CShort(1)).Name <> "N3" Then Assert.Fail()
'      If oGraph.Count <> 2 Then Assert.Fail("Erreur dans le comptage")

'    End Sub


'    <Testmethod(),<TestCategory("Graph")> _
'   Sub _Normal_Short()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.Suppr(CShort(1))

'      If oGraph.Item(CShort(0)).Name <> "N1" Then Assert.Fail()
'      If oGraph.Item(CShort(1)).Name <> "N3" Then Assert.Fail()
'      If oGraph.Count <> 2 Then Assert.Fail("Erreur dans le comptage")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Premier_String()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.Suppr("N1")

'      If oGraph.Item(CShort(0)).Name <> "N2" Then Assert.Fail()

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Dernier_String()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.Suppr("N2")

'      If oGraph.Item(CShort(0)).Name <> "N1" Then Assert.Fail()

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Unique_String()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.Suppr("N1")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Premier_Short()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.Suppr(CShort(0))

'      If oGraph.Item(CShort(0)).Name <> "N2" Then Assert.Fail()

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Dernier_Short()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.Suppr(CShort(1))

'      If oGraph.Item(CShort(0)).Name <> "N1" Then Assert.Fail()

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Unique_Short()

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.Suppr(CShort(0))

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Sans_sommet_string()

'      oGraph = New MathLib.Graph(False)
'      oGraph.Suppr("N1")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Sans_sommet_Short()

'      oGraph = New MathLib.Graph(False)
'      oGraph.Suppr(CShort(0))

'    End Sub

'    ' Test la suppression des arc du Graph lié au sommet supprimé
'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Suppr_Edge_non_Ordonne()

'      Dim Node1 As MathLib.Graph.Node
'      Dim Node2 As MathLib.Graph.Node
'      Dim Node3 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))
'      Node3 = oGraph.Item(CShort(2))

'      Call oGraph.Edge_ADD(Node1, Node2, 1)
'      Call oGraph.Edge_ADD(Node2, Node3, 1)
'      Call oGraph.Edge_ADD(Node3, Node1, 1)

'      Call oGraph.Suppr("N2")

'      Assert.AreEqual(1, oGraph.Edge_List().Length, "Nb arc restant")

'    End Sub

'    ' Test la suppression des arc du Graph lié au sommet supprimé
'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub Suppr_Edge_Ordonne()

'      Dim Node1 As MathLib.Graph.Node
'      Dim Node2 As MathLib.Graph.Node
'      Dim Node3 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))
'      Node3 = oGraph.Item(CShort(2))

'      Call oGraph.Edge_ADD(Node1, Node2, 1)
'      Call oGraph.Edge_ADD(Node2, Node1, 1)
'      Call oGraph.Edge_ADD(Node2, Node3, 1)
'      Call oGraph.Edge_ADD(Node3, Node2, 1)
'      Call oGraph.Edge_ADD(Node3, Node1, 1)
'      Call oGraph.Edge_ADD(Node1, Node3, 1)

'      Call oGraph.Suppr("N2")

'      Assert.AreEqual(2, oGraph.Edge_List().Length, "Nb arc restant")

'    End Sub

'  End Class

'#End Region

'#Region "Edge_ADD"
'  <TestClass()> _
'  Public Class Edge_ADD

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'    End Sub

'    <Testmethod(),<TestCategory("Graphe")> _
'    Sub _Normal_Non_Oriente()

'      Dim Node1 As MathLib.Graph.Node
'      Dim Node2 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      oGraph.Edge_ADD("N1", "N2", 2)
'      oGraph.Edge_ADD(Node2, Node1, 3)

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'   Sub _Normal_Oriente()

'      Dim Node1 As MathLib.Graph.Node
'      Dim Node2 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))
'      Node2 = oGraph.Item(CShort(1))

'      oGraph.Edge_ADD("N1", "N2", 2)
'      oGraph.Edge_ADD(Node2, Node1, 3)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'   Sub Sans_sommet()

'      oGraph = New MathLib.Graph(False)
'      oGraph.Edge_ADD("N1", "N2", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_inexistant()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")

'      oGraph.Edge_ADD("N3", "N2", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_Nothing()

'      Dim Node1 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Node1 = oGraph.Item(CShort(0))

'      oGraph.Edge_ADD(Nothing, "N2", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_vide()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")

'      oGraph.Edge_ADD("", "N2", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_inexistant()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")

'      oGraph.Edge_ADD("N1", "N3", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_Nothing()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")

'      oGraph.Edge_ADD(Nothing, "N3", 2)

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_vide()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")

'      oGraph.Edge_ADD("", "N3", 2)

'    End Sub

'  End Class
'#End Region

'#Region "Edge_Existe"
'  <TestClass()> _
'  Public Class Edge_Existe

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_non_Oriente()

'      Dim E1 As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(False)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      Call oGraph.Edge_ADD("N1", "N2", 1)
'      E1 = oGraph.Edge_ADD("N2", "N3", 2)
'      Call oGraph.Edge_ADD("N3", "N1", 3)

'      Assert.IsTrue(oGraph.Edge_Existe(E1))
'      Call oGraph.Edge_Suppr(E1)
'      Assert.IsFalse(oGraph.Edge_Existe(E1))

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_Oriente()

'      Dim E1 As MathLib.Graph.S_Edge
'      Dim E2 As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      E1 = oGraph.Edge_ADD("N1", "N2", 1)
'      E2 = oGraph.Edge_ADD("N2", "N1", 2)

'      Assert.IsTrue(oGraph.Edge_Existe(E1), "Test 1,1")
'      Assert.IsTrue(oGraph.Edge_Existe(E2), "Test 1,2")

'      Call oGraph.Edge_Suppr(E2)

'      Assert.IsTrue(oGraph.Edge_Existe(E1), "Test 2,1")
'      Assert.IsFalse(oGraph.Edge_Existe(E2), "Test 2,2")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Sans_Aretes()

'      Dim E1 As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      E1 = oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_Suppr(E1)
'      Assert.IsFalse(oGraph.Edge_Existe(E1))

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Nothing()

'      Dim E1 As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      Call oGraph.Edge_ADD("N1", "N2", 1)
'      E1 = oGraph.Edge_ADD("N2", "N3", 2)
'      Call oGraph.Edge_ADD("N3", "N1", 3)

'      Assert.IsFalse(Nothing)

'    End Sub


'  End Class
'#End Region

'#Region "Edge_Count"
'  <TestClass()> _
'  Public Class Edge_Count

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_non_Oriente()

'      oGraph = New MathLib.Graph(False)
'      'Dim j As Short
'      'Dim TabEdge() As BLM.Tools.Math.Graph.S_Edge
'      'Dim Ok As Boolean

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_ADD("N2", "N3", 2)
'      oGraph.Edge_ADD("N3", "N4", 3)
'      oGraph.Edge_ADD("N4", "N1", 3)

'      Assert.AreEqual(4, oGraph.Edge_Count)

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_Oriente()

'      oGraph = New MathLib.Graph(False)
'      'Dim i, j As Short
'      'Dim TabEdge() As BLM.Tools.Math.Graph.S_Edge
'      'Dim Ok As Boolean

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_ADD("N2", "N3", 2)
'      oGraph.Edge_ADD("N3", "N4", 3)
'      oGraph.Edge_ADD("N4", "N1", 4)

'      Assert.AreEqual(4, oGraph.Edge_Count, "1er partie")

'      oGraph.Edge_ADD("N2", "N1", 5)
'      Assert.AreEqual(5, oGraph.Edge_Count, "2ème partie")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Sans_Aretes()

'      oGraph = New MathLib.Graph(False)
'      'Dim i, j As Short
'      'Dim TabEdge() As BLM.Tools.Math.Graph.S_Edge
'      'Dim Ok As Boolean

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      Assert.AreEqual(0, oGraph.Edge_Count)

'    End Sub

'  End Class
'#End Region

'#Region "Edge_Suppr"
'  <TestClass()> _
'  Public Class Edge_Suppr

'    Private oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_non_Oriente()

'      oGraph = New MathLib.Graph(False)

'      Dim E1, E2, E3, E4, E5 As MathLib.Graph.S_Edge

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      E1 = oGraph.Edge_ADD("N1", "N2", 1)
'      E2 = oGraph.Edge_ADD("N2", "N3", 2)
'      E3 = oGraph.Edge_ADD("N3", "N4", 3)
'      E4 = oGraph.Edge_ADD("N4", "N1", 4)
'      E5 = oGraph.Edge_ADD("N2", "N4", 5)

'      oGraph.Edge_Suppr("N2", "N3")
'      oGraph.Edge_Suppr(E5)

'      Assert.IsTrue(oGraph.Edge_Existe(E1), "E1 supprimé a tord")
'      Assert.IsFalse(oGraph.Edge_Existe(E2), "E2 Non supprimé")
'      Assert.IsTrue(oGraph.Edge_Existe(E3), "E3 supprimé a tord")
'      Assert.IsTrue(oGraph.Edge_Existe(E4), "E4 supprimé a tord")
'      Assert.IsFalse(oGraph.Edge_Existe(E5), "E5 non supprimé")
'      Assert.AreEqual(3, oGraph.Edge_Count(), "Nb d'aretes incorrectent")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_Oriente()

'      oGraph = New MathLib.Graph(True)

'      Dim E1, E2, E3, E4, E5, E6, E7 As MathLib.Graph.S_Edge

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      E1 = oGraph.Edge_ADD("N1", "N2", 1)
'      E2 = oGraph.Edge_ADD("N2", "N3", 2)
'      E3 = oGraph.Edge_ADD("N3", "N4", 3)
'      E4 = oGraph.Edge_ADD("N4", "N1", 4)
'      E5 = oGraph.Edge_ADD("N2", "N1", 5)
'      E6 = oGraph.Edge_ADD("N4", "N2", 6)
'      E7 = oGraph.Edge_ADD("N2", "N4", 7)

'      oGraph.Edge_Suppr("N2", "N3")
'      oGraph.Edge_Suppr("N1", "N2")
'      oGraph.Edge_Suppr(E6)

'      Assert.IsFalse(oGraph.Edge_Existe(E1), "E1 non supprimé")
'      Assert.IsFalse(oGraph.Edge_Existe(E2), "E2 Non supprimé")
'      Assert.IsTrue(oGraph.Edge_Existe(E3), "E3 supprimé a tord")
'      Assert.IsTrue(oGraph.Edge_Existe(E4), "E4 supprimé a tord")
'      Assert.IsTrue(oGraph.Edge_Existe(E5), "E5 supprimé a tord")
'      Assert.IsFalse(oGraph.Edge_Existe(E6), "E6 non supprimé")
'      Assert.IsTrue(oGraph.Edge_Existe(E7), "E7 supprimé a tord")
'      Assert.AreEqual(4, oGraph.Edge_Count(), "Nb d'aretes incorrectent")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_inexistant()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("N3", "N2")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_Nothing()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr(Nothing, "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_vide()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("", "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_inexistant()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("N2", "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_Nothing()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("N2", Nothing)


'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_vide()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("N2", "")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Edge_inexistant()

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr("N2", "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graph"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Edge_Nothing()

'      Dim E1 As MathLib.Graph.S_Edge = Nothing

'      oGraph = New MathLib.Graph(True)

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      Call oGraph.Edge_ADD("N1", "N2", 1)

'      Call oGraph.Edge_Suppr(E1)

'    End Sub

'  End Class
'#End Region

'#Region "Edge_List"
'  <TestClass()> _
'  Public Class Edge_List
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_non_Ordonne()

'      oGraph = New MathLib.Graph(False)
'      Dim j As Short
'      Dim TabEdge() As MathLib.Graph.S_Edge
'      Dim Ok As Boolean

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_ADD("N2", "N3", 3)

'      TabEdge = oGraph.Edge_List

'      Ok = False
'      For j = 0 To TabEdge.Length - 1
'        With TabEdge(j)
'          If .Head.Name = "N1" And .Tail.Name = "N2" And .Weight = 1 Then Ok = True
'          If .Head.Name = "N2" And .Tail.Name = "N1" And .Weight = 1 Then Ok = True
'        End With
'      Next
'      If Not Ok Then Assert.Fail("1er arc non trouvé")

'      Ok = False
'      For j = 0 To TabEdge.Length - 1
'        With TabEdge(j)
'          If .Head.Name = "N2" And .Tail.Name = "N3" And .Weight = 3 Then Ok = True
'          If .Head.Name = "N3" And .Tail.Name = "N2" And .Weight = 3 Then Ok = True
'        End With
'      Next
'      If Not Ok Then Assert.Fail("2eme arc non trouvé")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub _Normal_Ordonne()

'      oGraph = New MathLib.Graph(False)
'      Dim j As Short
'      Dim TabEdge() As MathLib.Graph.S_Edge
'      Dim Ok As Boolean

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_ADD("N2", "N3", 3)

'      TabEdge = oGraph.Edge_List

'      Ok = False
'      For j = 0 To TabEdge.Length - 1
'        With TabEdge(j)
'          If .Head.Name = "N1" And .Tail.Name = "N2" And .Weight = 1 Then Ok = True
'          If .Head.Name = "N2" And .Tail.Name = "N1" And .Weight = 1 Then Ok = True
'        End With
'      Next
'      If Not Ok Then Assert.Fail("1er arc non trouvé", TabEdge)

'      Ok = False
'      For j = 0 To TabEdge.Length - 1
'        With TabEdge(j)
'          If .Head.Name = "N2" And .Tail.Name = "N3" And .Weight = 3 Then Ok = True
'          If .Head.Name = "N3" And .Tail.Name = "N2" And .Weight = 3 Then Ok = True
'        End With
'      Next
'      If Not Ok Then Assert.Fail("2eme arc non trouvé")

'    End Sub

'    <Testmethod(),<TestCategory("Graph")> _
'    Sub Sommet_non_Defini()

'      oGraph = New MathLib.Graph(False)
'      'Dim TabEdge() As BLM.Tools.Math.Graph.S_Edge

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.ADD("N4")

'      Assert.AreEqual(Nothing, oGraph.Edge_List)

'    End Sub

'  End Class
'#End Region

'#Region "Equals"
'  <TestClass(),<TestCategory("Graph")> _
'  Public Class Equals

'    Dim oGraph1 As MathLib.Graph
'    Dim oGraph2 As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph1 = Nothing
'      oGraph2 = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Non_Ordonne()

'      oGraph1 = New MathLib.Graph(False)
'      oGraph2 = New MathLib.Graph(False)
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 1")
'      '--
'      With oGraph1
'        .ADD("N1")
'        .ADD("N2")
'        .ADD("N3")
'      End With
'      With oGraph2
'        .ADD("N1")
'        .ADD("N2")
'        .ADD("N3")
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 2")
'      '--
'      With oGraph1
'        .Item(CShort(0)).Tag = "Test"
'      End With
'      With oGraph2
'        .Item(CShort(0)).Tag = "Test"
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 3")
'      '--
'      With oGraph1
'        .Edge_ADD("N1", "N2", 1)
'        .Edge_ADD("N2", "N3", 2)
'        .Edge_ADD("N3", "N1", 3)
'      End With
'      With oGraph2
'        .Edge_ADD("N1", "N2", 1)
'        .Edge_ADD("N2", "N3", 2)
'        .Edge_ADD("N3", "N1", 3)
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 4")
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Ordonne()

'      oGraph1 = New MathLib.Graph(False)
'      oGraph2 = New MathLib.Graph(False)
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 1")
'      '--
'      With oGraph1
'        .ADD("N1")
'        .ADD("N2")
'        .ADD("N3")
'      End With
'      With oGraph2
'        .ADD("N1")
'        .ADD("N2")
'        .ADD("N3")
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 2")
'      '--
'      With oGraph1
'        .Item(CShort(0)).Tag = "Test"
'      End With
'      With oGraph2
'        .Item(CShort(0)).Tag = "Test"
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 3")
'      '--
'      With oGraph1
'        .Edge_ADD("N1", "N2", 1)
'        .Edge_ADD("N2", "N3", 2)
'        .Edge_ADD("N3", "N1", 3)
'      End With
'      With oGraph2
'        .Edge_ADD("N1", "N2", 1)
'        .Edge_ADD("N2", "N3", 2)
'        .Edge_ADD("N3", "N1", 3)
'      End With
'      Assert.IsTrue(oGraph1.Equals(oGraph2), "Step 4")
'    End Sub

'  End Class

'#End Region

'#Region "Set_Global_Weight"
'  <TestClass(),<TestCategory("Graphe")> _
'  Public Class Set_Global_Weight

'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal()

'      Dim i As Short
'      Dim TabEdge() As MathLib.Graph.S_Edge

'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'      oGraph.Edge_ADD("N1", "N2", 0)
'      oGraph.Edge_ADD("N2", "N3", 1)
'      oGraph.Edge_ADD("N3", "N1", 2)

'      oGraph.Set_Global_Weight(10)

'      TabEdge = oGraph.Edge_List

'      For i = 0 To TabEdge.Length - 1
'        Assert.AreEqual(10, TabEdge(i).Weight)
'      Next

'    End Sub

'    <Testmethod()> _
'    Sub Sans_sommet()

'      oGraph.Set_Global_Weight(10)

'    End Sub

'    <Testmethod()> _
'    Sub Sans_Arcs()


'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")

'      oGraph.Set_Global_Weight(10)

'    End Sub

'  End Class
'#End Region

'#Region "Weight"
'  <TestClass(),<TestCategory("Graph")> _
' Public Class Weight

'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node
'      Dim N3 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")
'      N3 = oGraph.ADD("N3")
'      oGraph.Edge_ADD("N1", "N2", 0)
'      oGraph.Edge_ADD("N2", "N3", 1)
'      oGraph.Edge_ADD("N3", "N1", 2)

'      Assert.AreEqual(0, oGraph.Weight("N1", "N2"))
'      Assert.AreEqual(1, oGraph.Weight(N2, N3))
'      Assert.AreEqual(2, oGraph.Weight(N3, N1))

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Sans_Sommet()

'      Call oGraph.Weight("N1", "N2")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_inexistant()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Edge_ADD("N1", "N2", 0)

'      Call oGraph.Weight("N1", "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_Nothing_String()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight(Nothing, "N2")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_Nothing_Node()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight(Nothing, N2)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Tail_vide()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight("", "N2")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_inexistant()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight("N1", "N3")

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_Nothing_String()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight("N1", Nothing)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_Nothing_Node()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight(N1, Nothing)

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_vide()

'      Dim N1 As MathLib.Graph.Node
'      Dim N2 As MathLib.Graph.Node

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      oGraph.Weight("N1", "")

'    End Sub


'  End Class
'#End Region

'#Region "Clone"
'  <TestClass(),<TestCategory("Graph")> _
'  Public Class Clone

'    Dim oGraph As MathLib.Graph
'    Dim oGraphC As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'      oGraphC = Nothing
'    End Sub

'    Private Sub step1()
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      oGraph.ADD("N3")
'    End Sub

'    Private Sub step2()
'      oGraph.Edge_ADD("N1", "N2", 1)
'      oGraph.Edge_ADD("N2", "N3", 1)
'      oGraph.Edge_ADD("N3", "N1", 1)
'    End Sub

'    Private Sub step3()
'      oGraph.Item(CShort(0)).Tag = "Tag N1"
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_non_Ordone()
'      oGraph = New MathLib.Graph(False)

'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 0")
'      '--
'      Call step1()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 1")
'      '--
'      Call step2()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 2")
'      '--
'      Call step3()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 3")

'    End Sub

'    <Testmethod()> _
'   Sub _Normal_Ordone()

'      oGraph = New MathLib.Graph(True)

'      Call step1()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 1")
'      '--
'      Call step2()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 2")
'      '--
'      Call step3()
'      oGraphC = oGraph.Clone
'      Assert.IsTrue(oGraph.Equals(oGraphC), "Step 3")
'      '--

'    End Sub

'  End Class
'#End Region

'  <TestClass(), Ignore("TEST non fait")> _
'  Public Class Path_Fast

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'    Sub _Normal_non_Ordone()


'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'    Sub _Normal_Ordone()


'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'    Sub Start_inexistant()

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'     Sub Start_Nothing()

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'    Sub Finish_inexistant()

'    End Sub

'    <Testmethod(),<TestCategory("Graphe"), Ignore("Test d'execption non declaré")> _
'    Sub Finish_Nothing()

'    End Sub

'  End Class

'  <TestClass(),<TestCategory("Graph"), Ignore("TEST non fait")> _
'  Public Class Isconnected

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_non_ordone()

'    End Sub

'    <Testmethod()> _
'    Sub _Normal_ordone()

'    End Sub

'  End Class

'End Namespace

'Namespace Math.Graph.Node

'  <TestClass(),<TestCategory("Graph.Node")> _
'  Public Class Suppr
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'   Sub _Normal_Non_Oriente()

'      Dim N3 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      N3 = oGraph.ADD("N3")

'      oGraph.Edge_ADD("N1", "N2", 0)
'      oGraph.Edge_ADD("N2", "N3", 0)
'      oGraph.Edge_ADD("N3", "N1", 0)

'      oGraph.Item("N1").Suppr("N2")
'      Assert.AreEqual(2, oGraph.Edge_Count, "Arc restant")
'      oGraph.Item("N1").Suppr(N3)
'      Assert.AreEqual(1, oGraph.Edge_Count, "Arc restant")

'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Oriente()

'      Dim N3 As MathLib.Graph.Node

'      Dim E1 As MathLib.Graph.S_Edge
'      Dim E2 As MathLib.Graph.S_Edge
'      Dim E3 As MathLib.Graph.S_Edge
'      Dim E4 As MathLib.Graph.S_Edge
'      Dim E5 As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      N3 = oGraph.ADD("N3")

'      E1 = oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2 
'      E2 = oGraph.Edge_ADD("N2", "N3", 0)     ' 2 --> 3 
'      E3 = oGraph.Edge_ADD("N3", "N2", 0)     ' 3 --> 2  
'      E4 = oGraph.Edge_ADD("N3", "N1", 0)     ' 3 --> 1  
'      E5 = oGraph.Edge_ADD("N1", "N3", 0)     ' 1 --> 3  

'      oGraph.Item("N2").Suppr("N3", MathLib.Graph.E_Direction.Head)
'      Assert.AreEqual(4, oGraph.Edge_Count, "Arc restant")
'      Assert.IsFalse(oGraph.Edge_Existe(E2), "E2 non supprimé")

'      oGraph.Item("N1").Suppr(N3, MathLib.Graph.E_Direction.Head)
'      Assert.AreEqual(3, oGraph.Edge_Count, "Arc restant")
'      Assert.IsFalse(oGraph.Edge_Existe(E2), "E5 non supprimé")

'    End Sub

'    <Testmethod()> _
'   Sub arete_existe_pas()

'      oGraph = New MathLib.Graph(True)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2 

'      oGraph.Item("N1").Suppr("N3", MathLib.Graph.E_Direction.Head)

'    End Sub

'    <Testmethod(), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub _Sommet_existe_pas()

'      oGraph = New MathLib.Graph(True)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2 

'      oGraph.Item("N1").Suppr("N3", MathLib.Graph.E_Direction.Head)
'    End Sub

'    <Testmethod(), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Sommet_Vide()


'      Dim E1 As MathLib.Graph.S_Edge
'      Dim E2 As MathLib.Graph.S_Edge
'      oGraph = New MathLib.Graph(True)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2 

'      oGraph.Item("N2").Suppr("", MathLib.Graph.E_Direction.Head)

'    End Sub

'    <Testmethod(), ExpectedException(GetType(BLM.Tools.BLMException))> _
'   Sub Sommet_Nothing()

'      Dim N1 As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)

'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2 

'      N1 = Nothing
'      oGraph.Item("N2").Suppr(N1, MathLib.Graph.E_Direction.Head)

'    End Sub

'  End Class

'#Region "Equals"
'  <TestClass()> _
'  Public Class Equals

'    Dim N1 As MathLib.Graph.Node
'    Dim N2 As MathLib.Graph.Node
'    Dim N3 As MathLib.Graph.Node
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'      N1 = Nothing
'      N2 = Nothing
'      N3 = Nothing
'    End Sub

'    <Testmethod(),<TestCategory("Graph.Node")> _
'    Sub _Normal_non_Oriente()

'      oGraph = New MathLib.Graph(False)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      N1 = oGraph.Item(CShort(0))
'      N2 = oGraph.Item(CShort(1))
'      N3 = oGraph.Item(CShort(0))
'      oGraph.Edge_ADD(N1, N2, 1)

'      Assert.IsFalse(N1.Equals(N2), "mauvaise reconnaissance de non égalité entre 2 nodes dans un graph non orienté")
'      Assert.IsTrue(N1.Equals(N3), "mauvaise reconnaissance d'égalité entre 2 nodes dans un graph non orienté")

'    End Sub

'    <Testmethod(),<TestCategory("Graph.Node")> _
'    Sub _Normal_Oriente()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      N1 = oGraph.Item(CShort(0))
'      N2 = oGraph.Item(CShort(1))
'      N3 = oGraph.Item(CShort(0))
'      oGraph.Edge_ADD(N1, N2, 1)

'      Assert.IsFalse(N1.Equals(N2), "mauvaise reconnaissance de non égalité entre 2 nodes dans un graph orienté")
'      Assert.IsTrue(N1.Equals(N3), "mauvaise reconnaissance d'egalité entre 2 nodes dans un graphe orienté")

'    End Sub

'    <Testmethod(),<TestCategory("Graph.Node")> _
'    Sub _Nothing()

'      oGraph = New MathLib.Graph(True)
'      oGraph.ADD("N1")
'      oGraph.ADD("N2")
'      N1 = oGraph.Item(CShort(0))

'      Assert.IsFalse(N1.Equals(Nothing), "mauvaise reconnaissance d'egalité entre 2 nodes dans un graphe orienté")

'    End Sub

'  End Class
'#End Region

'#Region "Name"
'  <TestClass(),<TestCategory("Graph.Node")> _
'  Public Class Name
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal()

'      oGraph.ADD("N1")
'      Assert.AreEqual("N1", oGraph.Item(CShort(0)).Name)

'    End Sub

'    <Testmethod()> _
'    Sub Casse()

'      oGraph.ADD("N1")
'      Dim N1 As MathLib.Graph.Node = oGraph.Item("N1")
'      Dim N2 As MathLib.Graph.Node = oGraph.Item("n1")

'      Assert.IsTrue(N1.Equals(N2))

'    End Sub

'  End Class
'#End Region

'#Region "Edge_ADD"
'  <TestClass(),<TestCategory("Graphe")> _
'  Public Class Edge_ADD
'    Dim oGraph As MathLib.Graph
'    Dim N1 As MathLib.Graph.Node
'    Dim N2 As MathLib.Graph.Node
'    Dim N3 As MathLib.Graph.Node

'    <TestInitialize>
'    Public Sub SetUp()
'      oGraph = New MathLib.Graph(False)
'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'      N1 = Nothing
'      N2 = Nothing
'      N3 = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal()

'      Dim E1 As MathLib.Graph.S_Edge
'      Dim E2 As MathLib.Graph.S_Edge

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")
'      N3 = oGraph.ADD("N3")

'      E1 = N1.Edge_ADD(N2, 1)
'      E2 = N1.Edge_ADD("N3", 1)

'      Assert.AreEqual(2, oGraph.Edge_Count)
'      Assert.IsTrue(oGraph.Edge_Existe(E1))
'      Assert.IsTrue(oGraph.Edge_Existe(E2))

'    End Sub

'    <Testmethod(), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_inexistant()

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")

'      Call N1.Edge_ADD("N3", 1)

'    End Sub

'    <Testmethod(), ExpectedException(GetType(BLM.Tools.BLMException))> _
'    Sub Head_Nothing()

'      N1 = oGraph.ADD("N1")
'      N2 = oGraph.ADD("N2")
'      N3 = Nothing

'      Call N1.Edge_ADD(N3, 1)

'    End Sub

'  End Class
'#End Region

'#Region "Edge_List"
'  <TestClass(),<TestCategory("Graph.Node")> _
'  Public Class Edge_List
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_non_Oriente()

'      Dim ELst() As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)     ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)     ' 2 --> 4

'      With oGraph.Item("N1")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(1, ELst.Length, "N1.Edge_List(Tail)")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(1, ELst.Length, "N1.Edge_List(Head)")
'      End With

'      With oGraph.Item("N2")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(3, ELst.Length, "N2.Edge_List(Tail)")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(3, ELst.Length, "N2.Edge_List(Head)")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Both)
'        Assert.AreEqual(3, ELst.Length, "N2.Edge_List(Both)")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Oriente()

'      Dim ELst() As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")
'      Call oGraph.ADD("N5")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)     ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)     ' 2 --> 4
'      Call oGraph.Edge_ADD("N5", "N2", 0)     ' 5 --> 2

'      With oGraph.Item("N1")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Tail)
'        Assert.IsTrue(IsNothing(ELst), "N1.Edge_List(Tail) devrait etre a 'Nothing'")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(1, ELst.Length, "N1.Edge_List(Head).Length")
'        Assert.AreEqual("N2", ELst(0).Head.Name, "sommet de destination de la 1ere arete de N1")
'      End With

'      With oGraph.Item("N2")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(2, ELst.Length, "N2.Edge_List(Tail).Length")
'        Assert.AreEqual("N1", ELst(0).Tail.Name, "sommet de depart de la 1ere arete de N2")
'        Assert.AreEqual("N5", ELst(1).Tail.Name, "sommet de depart de la 2eme arete de N2")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(2, ELst.Length, "N2.Edge_List(Head).Length")
'        Assert.AreEqual("N3", ELst(0).Head.Name, "sommet de destination de la 1ere arete de N2")
'        Assert.AreEqual("N4", ELst(1).Head.Name, "sommet de destination de la 2eme arete de N2")
'        ELst = .Edge_List(MathLib.Graph.E_Direction.Both)
'        Assert.AreEqual(4, ELst.Length, "N2.Edge_List(Both).Length")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub Sans_Arete()

'      Dim ELst() As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      ELst = oGraph.Item("N1").Edge_List(MathLib.Graph.E_Direction.Tail)
'      Assert.AreEqual(Nothing, ELst, "N1.Edge_List(Tail)")
'      ELst = oGraph.Item("N1").Edge_List(MathLib.Graph.E_Direction.Head)
'      Assert.AreEqual(Nothing, ELst, "N1.Edge_List(Head)")
'      ELst = oGraph.Item("N1").Edge_List(MathLib.Graph.E_Direction.Both)
'      Assert.AreEqual(Nothing, ELst, "N1.Edge_List(Both)")

'    End Sub

'  End Class
'#End Region

'#Region "Edge_Count"
'  <TestClass(),<TestCategory("Graph.Node")> _
'  Public Class Edge_Count
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    Sub _Normal_non_Oriente()

'      Dim ELst() As MathLib.Graph.S_Edge

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)     ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)     ' 2 --> 4



'      With oGraph.Item("N1")
'        Assert.AreEqual(1, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N1\Tail")
'        Assert.AreEqual(1, .Edge_Count(MathLib.Graph.E_Direction.Head), "N1\Head")
'        Assert.AreEqual(1, .Edge_Count(MathLib.Graph.E_Direction.Both), "N1\both")
'      End With

'      With oGraph.Item("N2")
'        Assert.AreEqual(3, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N2\Tail")
'        Assert.AreEqual(3, .Edge_Count(MathLib.Graph.E_Direction.Head), "N2\Head")
'        Assert.AreEqual(3, .Edge_Count(MathLib.Graph.E_Direction.Both), "N2\both")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Oriente()

'      ' Dim ELst() As BLM.Tools.Math.Graph.S_Edge

'      oGraph = New MathLib.Graph(True)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")
'      Call oGraph.ADD("N5")
'      Call oGraph.ADD("N6")

'      Call oGraph.Edge_ADD("N1", "N2", 0)     ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)     ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)     ' 2 --> 4
'      Call oGraph.Edge_ADD("N2", "N6", 0)     ' 2 --> 6
'      Call oGraph.Edge_ADD("N5", "N2", 0)     ' 5 --> 2

'      With oGraph.Item("N1")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N1\Tail")
'        Assert.AreEqual(1, .Edge_Count(MathLib.Graph.E_Direction.Head), "N1\Head")
'        Assert.AreEqual(1, .Edge_Count(MathLib.Graph.E_Direction.Both), "N1\both")
'      End With

'      With oGraph.Item("N2")
'        Assert.AreEqual(2, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N2\Tail")
'        Assert.AreEqual(3, .Edge_Count(MathLib.Graph.E_Direction.Head), "N2\Head")
'        Assert.AreEqual(5, .Edge_Count(MathLib.Graph.E_Direction.Both), "N2\both")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub Sans_Arete()

'      ' Dim ELst() As BLM.Tools.Math.Graph.S_Edge

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      With oGraph.Item("N1")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N1\Tail")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Head), "N1\Head")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Both), "N1\both")
'      End With

'      With oGraph.Item("N1")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Tail), "N1\Tail")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Head), "N1\Head")
'        Assert.AreEqual(0, .Edge_Count(MathLib.Graph.E_Direction.Both), "N1\both")
'      End With

'    End Sub

'  End Class
'#End Region

'#Region "Node_List"
'  <TestClass(),<TestCategory("Graph.Node")> _
'  Public Class Node_List
'    Dim oGraph As MathLib.Graph

'    <TestInitialize>
'    Public Sub SetUp()

'    End Sub

'    <TestCleanup >
'    Public Sub TearDown()
'      oGraph = Nothing
'    End Sub

'    <Testmethod()> _
'    Sub _Normal_non_Oriente()

'      Dim ELst() As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")

'      Call oGraph.Edge_ADD("N1", "N2", 0)      ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)      ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)      ' 2 --> 4

'      With oGraph.Item("N1")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(1, ELst.Length, "N1.Node_List(Tail)")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(1, ELst.Length, "N1.Node_List(Head)")
'      End With

'      With oGraph.Item("N2")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(3, ELst.Length, "N2.Node_List(Tail)")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(3, ELst.Length, "N2.Node_List(Head)")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Both)
'        Assert.AreEqual(3, ELst.Length, "N2.Node_List(Both)")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub _Normal_Oriente()

'      Dim ELst() As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(True)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")
'      Call oGraph.ADD("N3")
'      Call oGraph.ADD("N4")
'      Call oGraph.ADD("N5")

'      Call oGraph.Edge_ADD("N1", "N2", 0)      ' 1 --> 2
'      Call oGraph.Edge_ADD("N2", "N3", 0)      ' 2 --> 3
'      Call oGraph.Edge_ADD("N2", "N4", 0)      ' 2 --> 4
'      Call oGraph.Edge_ADD("N5", "N2", 0)      ' 5 --> 2

'      With oGraph.Item("N1")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Tail)
'        Assert.IsTrue(IsNothing(ELst), "N1.Node_List(Tail) devrait etre a 'Nothing'")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(1, ELst.Length, "N1.Node_List(Head).Length")
'        Assert.AreEqual("N2", ELst(0).Name, "sommet voisin de N1")
'      End With

'      With oGraph.Item("N2")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Tail)
'        Assert.AreEqual(2, ELst.Length, "N2.Node_List(Tail).Length")
'        Assert.AreEqual("N1", ELst(0).Name, "sommet voisin de N2")
'        Assert.AreEqual("N5", ELst(1).Name, "sommet voisin de N2")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Head)
'        Assert.AreEqual(2, ELst.Length, "N2.Edge_List(Head).Length")
'        Assert.AreEqual("N3", ELst(0).Name, "sommet voisin de N2")
'        Assert.AreEqual("N4", ELst(1).Name, "sommet voisin de N2")
'        ELst = .Node_List(MathLib.Graph.E_Direction.Both)
'        Assert.AreEqual(4, ELst.Length, "N2.Node_List(Both).Length")
'      End With

'    End Sub

'    <Testmethod()> _
'    Sub Sans_Arete()

'      Dim ELst() As MathLib.Graph.Node

'      oGraph = New MathLib.Graph(False)
'      Call oGraph.ADD("N1")
'      Call oGraph.ADD("N2")

'      ELst = oGraph.Item("N1").Node_List(MathLib.Graph.E_Direction.Tail)
'      Assert.AreEqual(Nothing, ELst, "N1.Node_List(Tail)")
'      ELst = oGraph.Item("N1").Node_List(MathLib.Graph.E_Direction.Head)
'      Assert.AreEqual(Nothing, ELst, "N1.Node_List(Head)")
'      ELst = oGraph.Item("N1").Node_List(MathLib.Graph.E_Direction.Both)
'      Assert.AreEqual(Nothing, ELst, "N1.Node_List(Both)")

'    End Sub

'  End Class
'#End Region

'End Namespace

'Namespace Math.Graph

'  <TestClass(), Ignore("Non developpé")> _
'  Public Class Senarios


'    <Testmethod()> _
'    Sub Senario_01()

'    End Sub

'  End Class

'End Namespace