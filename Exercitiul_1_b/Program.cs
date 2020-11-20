using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercitiul_1_b
{
    class Program
    {
        // private static List<int[]> allCombos;
        // private static int edgeCount;
        private static int colourCount;
        private static List<List<int>> colouredGraphs;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Graph graph = new Graph();
            graph.SetIncidenceMatrix(graph.ParseMatrixFile(@"..\..\..\..\Exercitiul_1_b\incidence2.txt"));

            //numarul minim de culori este egal cu delta grafului
            colourCount = graph.Vertices.Select(x => x.GetVertexDegree()).Max();  
            StartColourCombos(graph);

            if (!colouredGraphs.Any())
            {
                colourCount++;
                StartColourCombos(graph);
            }
            
            PrintListListInt(colouredGraphs);
        }

        static void StartColourCombos(Graph initGraph)
        {
            colouredGraphs = new List<List<int>>();
            var initCombo = new List<int>();
            
            for (int i = 0; i < initGraph.Edges.Count(); i++)
            {
                initCombo.Add(-1);
            }
            
            GetColourCombos(initGraph, initCombo,0);
        }

        static void GetColourCombos(Graph initGraph, List<int> colourCombo, int edgeColouringId)
        {
            if (edgeColouringId == colourCombo.Count())
            {
                colouredGraphs.Add(colourCombo);
            }
            else
            {
                for (var colour = 0; colour < colourCount; colour++)
                {
                    if (VerifyEdgeColour(initGraph, colourCombo, edgeColouringId, colour))
                    {
                        var newCombo = new List<int>(colourCombo);
                        newCombo[edgeColouringId] = colour;
                        
                        // foreach (var i in newCombo)
                        // {
                        //     Console.Write($"{i} ");
                        // }
                        // Console.WriteLine();
                        
                        GetColourCombos(initGraph, newCombo, edgeColouringId + 1);
                    }
                }
            }
        }
        
        static bool VerifyEdgeColour(Graph initGraph, List<int> colourCombo, int edgeId, int edgeColour)
        {
            foreach (var connectedVertex in initGraph.Edges[edgeId].ConnectedVertices)
            {
                foreach (var adjacentEdge in connectedVertex.AdjacentEdges)
                {
                    if (colourCombo[adjacentEdge.Id] == edgeColour)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        static void PrintListListInt(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var i in row)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }

        }

        /*
        static void StartColourCombos()
        {
            allCombos = new List<int[]>();
            var start = new int[edgeCount];
            GetAllColourCombos(start, 0);
        }

        static void GetAllColourCombos(int[] combo, int position)
        {
            if (position == combo.Length)
            {
                allCombos.Add(combo);
            }
            else
            {
                for (var i = 0; i < colourCount; i++)
                {
                    var newCombo = new int[combo.Length];
                    Array.Copy(combo, newCombo, combo.Count());
                    newCombo[position] = i;
                    GetAllColourCombos(newCombo, position + 1);
                }
            }
        }

        static int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }

            return ret;
        }
    */
    }
}