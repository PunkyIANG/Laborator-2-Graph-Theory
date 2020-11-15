using System.Collections.Generic;

namespace Core
{
    public class Edge
    {
        public int Id;
        public List<Vertex> ConnectedVertices = new List<Vertex>();
        public int Weight = 0;

        public Edge(int id)
        {
            this.Id = id;
        }
        
        public Edge(Vertex firstVertex, Vertex secondVertex)
        {
            ConnectedVertices.Add(firstVertex);
            ConnectedVertices.Add(secondVertex);
        }
    }
}