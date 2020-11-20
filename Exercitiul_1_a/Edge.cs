using System.Collections.Generic;

namespace Exercitiul_1_a
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
        
        public Edge(Vertex source, Vertex destination)
        {
            ConnectedVertices.Add(source);
            ConnectedVertices.Add(destination);
        }
    }
}