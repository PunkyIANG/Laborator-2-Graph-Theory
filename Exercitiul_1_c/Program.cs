using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercitiul_1_c
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new DirectedWeightedGraph();
            graph.SetIncidenceMatrixWeights(graph.ParseMatrixFile(@"..\..\..\..\Exercitiul_1_c\incidenceWeighted.txt"));
            BellmanFord(graph, graph.Vertices.FirstOrDefault());
            graph.PrintGraphStats();
            graph.PrintPath();
        }

        static void BellmanFord(DirectedWeightedGraph graph, Vertex source)
        {
            int totalDistance = 0;

            foreach (var edge in graph.Edges)
            {
                totalDistance += Math.Abs(edge.Weight);
            }
            
            foreach (var vertex in graph.Vertices)
            {
                vertex.Distance = Int32.MaxValue - totalDistance;
                vertex.path = new List<Vertex>{vertex};
            }
            source.Distance = 0;

            for (int i = 0; i < graph.Vertices.Count - 1; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    RelaxEdgeVertices(edge);
                }
            }
            
            foreach (var edge in graph.Edges)
            {
                CheckNegativeCycles(edge);
            }
        }

        static void RelaxEdgeVertices(Edge edge)
        {
            var u = edge.Source;
            var v = edge.Destination;

            if (u.Distance + edge.Weight < v.Distance)
            {
                // Console.WriteLine($"{u.Distance} + {edge.Weight} < {v.Distance}");    //debug
                v.Distance = u.Distance + edge.Weight;
                // v.path = new List<Vertex>(u.path);
                // v.path.Add(v);
                v.path = new List<Vertex>(u.path) {v};
            }
        }

        static void CheckNegativeCycles(Edge edge)
        {
            var u = edge.Source;
            var v = edge.Destination;

            if (u.Distance + edge.Weight < v.Distance)
            {
                Console.WriteLine("Graful contine cicluri de lungime negativa");
            }
        }
    }
}