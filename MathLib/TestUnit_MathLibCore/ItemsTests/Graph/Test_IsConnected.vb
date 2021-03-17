Namespace Obj.Graph
    <TestClass()>
  Public Class IsConnected

        Private _Graph As MathLib.Graph

        <TestInitialize()>
        Public Sub SetUp()

            _Graph = New MathLib.Graph(True)

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _Graph = Nothing

        End Sub

        <TestMethod()> <Description("Carré connexe")> _
        Public Sub Test_01()

            Dim i As Integer

            '-- Initialisation des valeurs --------------------------------------
            With _Graph.Nodes
                For i = 0 To 3
                    .Add(New MathLib.Graph.NodeItem)
                Next
            End With
            With _Graph.Edges
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(0), _Graph.Nodes(1)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(1), _Graph.Nodes(2)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(2), _Graph.Nodes(3)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(3), _Graph.Nodes(0)))
            End With
            '--------------------------------------------------------------------

            Assert.IsTrue(_Graph.Isconnected)

        End Sub

        <TestMethod()> <Description("Carré non connexe (Manque une arete)")> _
        Public Sub Test_02()

            Dim i As Integer

            '-- Initialisation des valeurs --------------------------------------
            With _Graph.Nodes
                For i = 0 To 3
                    .Add(New MathLib.Graph.NodeItem)
                Next
            End With
            With _Graph.Edges
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(0), _Graph.Nodes(1)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(1), _Graph.Nodes(2)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(3), _Graph.Nodes(0)))
            End With
            '--------------------------------------------------------------------

            Assert.IsFalse(_Graph.Isconnected)

        End Sub

        <TestMethod()> _
        Public Sub Test_03()

            Dim i As Integer

            '-- Initialisation des valeurs --------------------------------------
            With _Graph.Nodes
                For i = 0 To 3
                    .Add(New MathLib.Graph.NodeItem)
                Next
            End With
            With _Graph.Edges
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(0), _Graph.Nodes(1)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(1), _Graph.Nodes(2)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(2), _Graph.Nodes(3)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(2), _Graph.Nodes(0)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(3), _Graph.Nodes(0)))
            End With
            '--------------------------------------------------------------------

            Assert.IsTrue(_Graph.Isconnected)

        End Sub

        <TestMethod()> _
        Public Sub Test_04()

            Dim i As Integer

            '-- Initialisation des valeurs --------------------------------------
            With _Graph.Nodes
                For i = 0 To 3
                    .Add(New MathLib.Graph.NodeItem)
                Next
            End With
            With _Graph.Edges
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(0), _Graph.Nodes(1)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(1), _Graph.Nodes(3)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(3), _Graph.Nodes(2)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(2), _Graph.Nodes(1)))
                .Add(New MathLib.Graph.EdgeItem(_Graph.Nodes(3), _Graph.Nodes(0)))
            End With
            '--------------------------------------------------------------------

            Assert.IsTrue(_Graph.Isconnected)

        End Sub

    End Class

End Namespace
