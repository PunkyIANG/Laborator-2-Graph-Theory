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

            Console.WriteLine("Indicele cromatic: " + colourCount);
            
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
                if (IsUnique(colouredGraphs, colourCombo))
                {
                    colouredGraphs.Add(colourCombo);
                }
            }
            else
            {
                for (var colour = 0; colour < colourCount; colour++)
                {
                    if (VerifyEdgeColour(initGraph, colourCombo, edgeColouringId, colour))
                    {
                        var newCombo = new List<int>(colourCombo);
                        newCombo[edgeColouringId] = colour;
                        
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

        static bool IsUnique(List<List<int>> colouredGraphs, List<int> colourCombo)
        {
            var normalizedColourCombo = GetNormalizedList(colourCombo);

            foreach (var colouredGraph in colouredGraphs)
            {
                if (CompareLists(GetNormalizedList(colouredGraph), normalizedColourCombo))
                // if (GetNormalizedList(colouredGraph).Intersect(normalizedColourCombo).Any())
                {
                    return false;
                }
            }

            return true;
        }

        static bool CompareLists(List<int> firstList, List<int> secondList)
        {
            if (firstList.Count() != secondList.Count())
            {
                return false;
            }

            for (int i = 0; i < firstList.Count(); i++)
            {
                if (firstList[i] != secondList[i])
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> GetNormalizedList(List<int> inputList)
        {
            Dictionary<int, int> normalizedValues = new Dictionary<int, int>();
            var actualValue = new List<int>();
            int iterator = 0;

            foreach (var i in inputList)
            {
                if (!normalizedValues.ContainsKey(i))
                {
                    normalizedValues.Add(i, iterator);
                    iterator++;
                }
                
                actualValue.Add(normalizedValues[i]);
            }

            return actualValue;
        }
    }
}