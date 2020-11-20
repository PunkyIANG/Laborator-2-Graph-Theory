using System.Collections.Generic;

namespace Exercitiul_1_c
{
    public class Edge
    {
        public int Id;
        public Vertex Source;
        public Vertex Destination;
        public int Weight = 0;

        public Edge(int id)
        {
            this.Id = id;
        }
        
        public Edge(Vertex source, Vertex destination)
        {
            this.Source = source;
            this.Destination = destination;
        }
    }
}