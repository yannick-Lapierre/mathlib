Namespace Obj.Graph.Node

    <TestClass()>
  Public Class OpEquals

        Private _node1 As MathLib.Graph.NodeItem
        Private _node2 As MathLib.Graph.NodeItem

        <TestInitialize()>
        Public Sub SetUp()

            _node1 = New MathLib.Graph.NodeItem
            _node2 = New MathLib.Graph.NodeItem

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

            _node1 = Nothing
            _node2 = Nothing

        End Sub

        <TestMethod()> _
        Public Sub Test_01()

            Dim edge1 As New MathLib.Graph.EdgeItem
            Dim edge2 As New MathLib.Graph.EdgeItem

            '-- Initialisation des valeurs --------------------------------------
            With edge1
                .Head = _node1
                .Tail = _node2
                .Weight = 1
            End With

            With edge2
                .Head = _node1
                .Tail = _node2
                .Weight = 1
            End With
            '--------------------------------------------------------------------

            Assert.IsTrue(edge1 = edge2)

        End Sub

        <TestMethod()> _
        Public Sub Test_02()

            Dim edge1 As New MathLib.Graph.EdgeItem
            Dim edge2 As New MathLib.Graph.EdgeItem

            '-- Initialisation des valeurs --------------------------------------
            With edge1
                .Head = _node1
                .Tail = _node2
                .Weight = 1
            End With

            With edge2
                .Head = _node2
                .Tail = _node1
                .Weight = 1
            End With
            '--------------------------------------------------------------------

            Assert.IsTrue(edge1 = edge2)

        End Sub

        <TestMethod()> _
        Public Sub Test_03()

            Dim edge As New MathLib.Graph.EdgeItem

            '-- Initialisation des valeurs --------------------------------------
            With edge
                .Head = _node1
                .Tail = _node2
                .Weight = 1
            End With
            '--------------------------------------------------------------------

            Assert.IsFalse(Nothing = edge)

        End Sub

        <TestMethod()> _
        Public Sub Test_04()

            Dim edge As New MathLib.Graph.EdgeItem

            '-- Initialisation des valeurs --------------------------------------
            With edge
                .Head = _node1
                .Tail = _node2
                .Weight = 1
            End With
            '--------------------------------------------------------------------

            Assert.IsFalse(edge = Nothing)

        End Sub

        <TestMethod()> _
        Public Sub Test_05()

            Assert.IsTrue(Nothing = Nothing)

        End Sub

    End Class

End Namespace
