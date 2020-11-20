using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercitiul_1_b
{
    public class Graph
    {
        public List<Vertex> Vertices;
        public List<Edge> Edges;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public Graph(Graph graph)
        {
            Vertices = new List<Vertex>(graph.Vertices);
            Edges = new List<Edge>(graph.Edges);
        }
        
        public void SetIncidenceMatrix(List<List<int>> matrix)
        {
            var height = matrix.Count;
            var width = matrix[0].Count;
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();


            for (var i = 0; i < height; i++)
            {
                if (matrix[i].Count != width)
                {
                    Console.WriteLine("Error: wrong num count on row " + i); //rewrite this in a separate function
                    return;
                }
            }

            for (var i = 0; i < height; i++)
            {
                Vertices.Add(new Vertex(i)); //rewrite this as well
            }

            for (var j = 0; j < width; j++)
            {
                Edges.Add(new Edge(j)); //you get it
            }

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        Edges[j].ConnectedVertices.Add(Vertices[i]); //just setting the edges for now
                        Vertices[i].AdjacentEdges.Add(Edges[j]);
                    }
                }
            }

            foreach (var edge in Edges)
            {
                edge.ConnectedVertices[0].AdjacentVertices.Add(edge.ConnectedVertices[1]);
                edge.ConnectedVertices[1].AdjacentVertices.Add(edge.ConnectedVertices[0]);
            }

            PrintGraphStats();
        }


        /*
        public void PrintIncidenceMatrix()
        {
            var height = Vertices.Count;
            var width = Edges.Count;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Edges[j].ConnectedVertices.Contains(Vertices[i]))
                    {
                        Console.Write("1  ");
                    }
                    else
                    {
                        Console.Write("0  ");
                    }
                }

                Console.WriteLine();
            }
        }
        */

        public void PrintGraphStats()
        {
            Console.WriteLine("There are " + Vertices.Count + " vertices and " + Edges.Count + " edges");

            Console.Write("Vertex IDs: ");
            foreach (var vertex in Vertices)
            {
                Console.Write(vertex.Id + " ");
            }

            Console.WriteLine();


            Console.Write("Adjacency: ");
            foreach (var vertex in Vertices)
            {
                Console.Write(vertex.GetVertexDegree() + " ");
            }

            Console.WriteLine();

            // Console.Write("Distance: ");
            // foreach (var vertex in Vertices)
            // {
            //     Console.Write(vertex.Distance + " ");
            // }
            //
            // Console.WriteLine();

            Console.Write("Edges: ");
            foreach (var edge in Edges)
            {
                Console.Write("(" + edge.ConnectedVertices[0].Id + ", " + edge.ConnectedVertices[1].Id + ") ");
            }

            Console.WriteLine();


            Console.Write("Edge IDs: ");
            foreach (var edge in Edges)
            {
                Console.Write(edge.Id + " ");
            }

            Console.WriteLine();
            
            Console.Write("Colour: ");
            foreach (var edge in Edges)
            {
                Console.Write(edge.Colour + " ");
            }

            Console.WriteLine();
            
            Console.WriteLine();
        }


        public List<List<int>> ParseMatrixFile(string path)
        {
            string line;
            List<List<int>> matrix = new List<List<int>>();

            // Read the file and display it line by line.  
            var file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                matrix.Add(Array.ConvertAll(line.Split(' '), int.Parse).ToList());
            }

            foreach (var row in matrix)
            {
                foreach (var number in row)
                {
                    Console.Write(number + "  ");
                }

                Console.WriteLine();
            }

            file.Close();

            return matrix;
        }
    }
}