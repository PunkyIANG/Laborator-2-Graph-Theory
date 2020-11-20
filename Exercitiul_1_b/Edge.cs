using System.Collections.Generic;

namespace Exercitiul_1_b
{
    public class Edge
    {
        public int Id;
        public List<Vertex> ConnectedVertices = new List<Vertex>();
        public int Colour = -1;

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