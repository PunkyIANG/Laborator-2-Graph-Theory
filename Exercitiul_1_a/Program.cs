using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercitiul_1_a
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph graph = new WeightedGraph();
            graph.SetIncidenceMatrixWeights(graph.ParseMatrixFile(@"..\..\..\..\Exercitiul_1_a\incidenceWeighted.txt"));
            
            PrimAlgorithm(graph).PrintGraphStats();
        }

        static WeightedGraph PrimAlgorithm(WeightedGraph graph)
        {
            var tree = new WeightedGraph();
            var start = graph.Vertices.First();
            tree.Vertices.Add(start);

            var eligibleEdges = GetEligibleEdges(graph, tree);
            while (eligibleEdges.Any())
            {
                var minEdge = eligibleEdges.OrderBy(e => e.Weight).First();
                tree.Edges.Add(minEdge);
                tree.Vertices.AddRange(minEdge.ConnectedVertices.Except(tree.Vertices));
                
                eligibleEdges = GetEligibleEdges(graph, tree);
            }

            return tree;
        }

        static List<Edge> GetEligibleEdges(WeightedGraph initGraph, WeightedGraph tree)
        {
            List<Edge> result = new List<Edge>();

            result.AddRange(initGraph.Edges.Where(edge => tree.Vertices.Intersect(edge.ConnectedVertices).Count() == 1));

            return result;
        }
    }
}