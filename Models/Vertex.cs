using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    class Vertex
    {

        public Vertex(char c)
        {
            Name = c;
        }
        public char Name { get; set; }

        public bool Visited { get; set; }

        public List<Vertex> Adjacent = new List<Vertex>();

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
