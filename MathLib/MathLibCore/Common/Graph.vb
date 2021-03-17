Option Explicit On

Namespace Common

  Public Class Graph

    ''' <summary>Calcul du chemin le plus court selon la methode de Dijkstra.</summary>
    ''' <returns>
    ''' Graphe de chemin le plus court entre le somet de départ et le sommet
    ''' d'arrivé.
    ''' </returns>
    ''' <remarks>
    ''' Les indice des node du graphe de resultat sont dans l'ordre de parcoure du
    ''' chemin
    ''' </remarks>
    ''' <param name="graphSource">Graphe de base</param>
    ''' <param name="startNode">Sommet de départ</param>
    ''' <param name="endNode">Sommet d'arrivé</param>
    Public Shared Function Dijkstra(ByVal graphSource As MathLib.Graph, ByVal startNode As MathLib.Graph.NodeItem, ByVal endNode As MathLib.Graph.NodeItem) As MathLib.Graph

      Dim WorkingGarph As New MathLib.Graph("WorkingGraph", True)
      Dim Result As New MathLib.Graph("Dijkstra Result", True)
      Dim CurrentNode As MathLib.Graph.NodeItem
      Dim TmpNode As MathLib.Graph.NodeItem
      Dim TmpEdge As MathLib.Graph.EdgeItem
      Dim NeighborsNode As MathLib.Graph.NodeCollection
      Dim TmpWeight As Double
      Dim MinWeight As Double
      Dim i As Integer

      MinWeight = Double.PositiveInfinity

      ' Point de depart
      CurrentNode = startNode.Clone
      CurrentNode.Tag = 0.0#
      CurrentNode.Flag = False
      WorkingGarph.Nodes.Add(CurrentNode, True)

      Do While Not WorkingGarph.Nodes.IsAllFlagued(True)

        ' Recherche le node dispo ayant la poid Min 
        TmpWeight = Double.PositiveInfinity
        For i = 0 To WorkingGarph.Nodes.Count - 1
          If WorkingGarph.Nodes.Item(i).Flag = False And CDbl(WorkingGarph.Nodes.Item(i).Tag) <= TmpWeight Then
            CurrentNode = WorkingGarph.Nodes.Item(i)
            TmpWeight = CDbl(WorkingGarph.Nodes.Item(i).Tag)
          End If
        Next

        ' On flag le node pour ne pas le retraiter par la suite
        CurrentNode.Flag = True

        ' On traite les nodes lié au node actuel
        NeighborsNode = graphSource.Nodes.ItemByID(CurrentNode.ID).Neighbors(MathLib.Graph.EdgeDirection.Head)
        For i = 0 To NeighborsNode.Count - 1
          ' In evite le les boucles sur le meme node
          If NeighborsNode(i).ID <> CurrentNode.ID Then
            ' On verifi si le node es deja dans notre Graph de resultat
            If Not WorkingGarph.Nodes.ExistID(NeighborsNode(i).ID) Then
              TmpNode = NeighborsNode(i).Clone
              TmpNode.Tag = Double.PositiveInfinity
              TmpNode.Flag = False
              WorkingGarph.Nodes.Add(TmpNode, True)
            End If

            ' On recupere un pointeur sur le node
            TmpNode = WorkingGarph.Nodes.ItemByID(NeighborsNode(i).ID)
            ' On cré l'arête et On recupere un pointeur sur celle-ci
            TmpEdge = graphSource.Edges.Item(CurrentNode, TmpNode)
            WorkingGarph.Edges.Add(TmpEdge)
            TmpWeight = CDbl(CurrentNode.Tag) + TmpEdge.Weight
            If TmpWeight < MinWeight Then   ' Optimisation de vitesse
              If CDbl(TmpNode.Tag) > TmpWeight Then
                TmpNode.RemoveEdge(MathLib.Graph.EdgeDirection.Both)
                WorkingGarph.Edges.Add(TmpEdge)
                TmpNode.Tag = TmpWeight
                If TmpNode = endNode Then MinWeight = TmpWeight
              End If
            End If
          End If
        Next
      Loop

      '-- Création du graph resultat --------------------------------------
      Dim TabNode As New System.Collections.Generic.Stack(Of MathLib.Graph.NodeItem)
      Dim NodeTail As MathLib.Graph.NodeItem
      Dim NodeHead As MathLib.Graph.NodeItem

      '-- On alimente un tableau de node en remontant vers le point de depart --

      NodeTail = endNode
      TabNode.Push(NodeTail)
      Do
        NodeHead = NodeTail.Clone
        TmpEdge = WorkingGarph.Nodes.ItemByID(NodeHead.ID).Edges(MathLib.Graph.EdgeDirection.Tail).Item(0)
        NodeTail = graphSource.Nodes.ItemByID(TmpEdge.Tail.ID)
        TabNode.Push(NodeTail)
      Loop Until NodeTail = startNode

      '-- On crer le graph dans le bon sens --
      NodeHead = TabNode.Pop
      Result.Nodes.Add(NodeHead)
      Do While TabNode.Count > 0
        NodeTail = NodeHead.Clone
        NodeHead = TabNode.Pop
        Result.Nodes.Add(NodeHead)
        Result.Edges.Add(graphSource.Edges(NodeTail, NodeHead))
      Loop
      '--------------------------------------------------------------------

      Return Result

    End Function

    ''' <summary>Calcul du chemin le plus court selon la methode de Dijkstra.</summary>
    ''' <returns>
    ''' Graphe de chemin le plus court entre le somet de départ et le sommet
    ''' d'arrivé.
    ''' </returns>
    ''' <remarks>
    ''' Les indice des node du graphe de resultat sont dans l'ordre de parcoure du
    ''' chemin
    ''' </remarks>
    ''' <param name="graph">Graphe de base</param>
    ''' <param name="startNode">Sommet de départ</param>
    ''' <param name="endNode">Sommet d'arrivé</param>
    ''' <param name="HiddenEdge">Arete a ne pas utiliser lors du calcul</param>
    Public Shared Function Dijkstra(ByVal graph As MathLib.Graph, ByVal startNode As MathLib.Graph.NodeItem, ByVal endNode As MathLib.Graph.NodeItem, ByVal HiddenEdge As MathLib.Graph.EdgeCollection) As MathLib.Graph

      Dim TmpGrah As MathLib.Graph
      Dim TmpHiddenEdge As New MathLib.Graph.EdgeCollection
      Dim i As Integer


      TmpGrah = graph.Clone(True)

      If Not graph.Directed Then
        For i = 0 To HiddenEdge.Count - 1
          TmpHiddenEdge.Add(HiddenEdge(i))
          TmpHiddenEdge.Add(New MathLib.Graph.EdgeItem(HiddenEdge(i).Head, HiddenEdge(i).Tail))
        Next
      Else
        TmpHiddenEdge = HiddenEdge.Clone
      End If

      For i = 0 To TmpHiddenEdge.Count - 1
        If TmpGrah.Edges.Exist(TmpHiddenEdge(i)) Then
          TmpGrah.Edges.Remove(TmpHiddenEdge(i))
        End If
      Next

      Return Dijkstra(TmpGrah, startNode, endNode)

    End Function


    '''' <summary>
    '''' Calcul le chemin le plus court (en terme de cout) entre 2 sommets
    '''' </summary>
    '''' <param name="Start">Sommet de départ</param>
    '''' <param name="Finish">Sommet d'arrivé</param>
    '''' <param name="Excluded_Edge">Arete à supprimer</param>
    '''' <returns></returns>
    '''' <remarks>
    '''' </remarks>
    'Public Function FastPath(ByVal start As NodeItem, ByVal finish As NodeItem, ByVal excludedEdge As EdgeCollection) As NodeCollection

    '  Dim Flag_Dijkstra As Boolean
    '  Dim Flag As Boolean
    '  Dim i As Integer
    '  Dim oGraphe As New Graph(Directed)

    '  ' On supprime les arete non desirées
    '  oGraphe = DirectCast(Me.Clone, Graph)
    '  If Not IsNothing(excludedEdge) Then
    '    For i = 0 To excludedEdge.Count - 1
    '      oGraphe.Edges.Remove(excludedEdge(i).Index)
    '    Next
    '  End If

    '  Flag_Dijkstra = True

    '  '-- Le graphe doit-il etre connexe? ------------
    '  If Not Isconnected Then
    '    Flag_Dijkstra = False
    '  End If

    '  '-- Les cout doivent il etre Positif ou nul? --
    '  For i = 0 To Edges.Count - 1
    '    If Edges(i).Weight < 0 Then Flag = True
    '  Next
    '  ' Il y a du negatif
    '  If Flag = True Then
    '    Flag_Dijkstra = False
    '  End If

    '  ' on choisi le mode de traitement le mieu adapté
    '  If Flag_Dijkstra = True Then Return Dijkstra(start, finish, oGraphe)

    '  'Si on a pas trouvé de traitement possible, On retourne rien
    '  Return Nothing

    'End Function

    '''' <summary>
    '''' Calcul le chemin le plus court (en terme de cout) entre 2 sommets
    '''' </summary>
    '''' <param name="Start">Sommet de depart</param>
    '''' <param name="Finish">Sommet d'arrivé</param>
    '''' <returns></returns>
    '''' <remarks>
    '''' </remarks>
    'Public Function FastPath(ByVal Start As NodeItem, ByVal Finish As NodeItem) As NodeCollection

    '  Return FastPath(Start, Finish, Nothing)

    'End Function


  End Class

End Namespace