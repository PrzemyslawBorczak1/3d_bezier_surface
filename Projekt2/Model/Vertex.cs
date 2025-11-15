using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Projekt2
{
    public class Vertex
    {
        public Vector3 Cord;
        public Vector3 Normal;

        public Vector3 Pu;
        public Vector3 Pv;

        public float U;
        public float V;

        public Vertex(Vector3 a)
        {
            Cord = a;
        }
    }
}
