using System;
using System.Linq;
using Core;

namespace Exercitiul_1_c
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.SetIncidenceMatrixWeights(graph.ParseMatrixFile(@"..\..\..\..\Core\incidenceWeighted.txt"));
            BellmanFord(graph, graph.Vertices.FirstOrDefault());
            graph.PrintGraphStats();
        }

        static void BellmanFord(Graph graph, Vertex source)
        {
            foreach (var vertex in graph.Vertices)
            {
                vertex.Distance = Int32.MaxValue;
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
            var u = edge.ConnectedVertices[0];
            var v = edge.ConnectedVertices[1];

            if (u.Distance + edge.Weight < v.Distance)
            {
                Console.WriteLine($"{u.Distance} + {edge.Weight} < {v.Distance}");
                v.Distance = u.Distance + edge.Weight;
            }
            else if (v.Distance + edge.Weight < u.Distance)
            {
                Console.WriteLine($"{v.Distance} + {edge.Weight} < {u.Distance}");
                u.Distance = v.Distance + edge.Weight;
            }
        }

        static void CheckNegativeCycles(Edge edge)
        {
            var u = edge.ConnectedVertices[0];
            var v = edge.ConnectedVertices[1];

            if (u.Distance + edge.Weight < v.Distance ||
                v.Distance + edge.Weight < u.Distance)
            {
                Console.WriteLine("Graful contine cicluri de lungime negativa");
            }
        }
    }
}