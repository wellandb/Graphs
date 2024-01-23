using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSTreeEdgesProject
{
    internal class Vertex
    {
        public String name;
        public int state;
        public int predecessor;
        public Vertex(String name)
        {
            this.name = name;
        }
    }
}
