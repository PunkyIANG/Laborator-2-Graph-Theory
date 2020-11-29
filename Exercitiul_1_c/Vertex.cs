using System;
using System.Collections.Generic;

namespace Exercitiul_1_c
{
    public class Vertex
    {
        public int Id;
        public List<Vertex> AdjacentVertices = new List<Vertex>();
        public List<Edge> AdjacentEdges = new List<Edge>();
        public int Distance = 0;
        public List<Vertex> path;

        public int GetVertexDegree()
        {
            return AdjacentVertices.Count;
        }

        public Vertex(int id)
        {
            this.Id = id;
        }
    }
}