using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class Mesh : IDisplayStrategy
    {

        static Mesh? instance = null; 
        private Mesh()
        {
        }
        public static Mesh GetInstance()
        {
            if(instance == null)
                instance = new Mesh();
            return instance;
        }

        public void Draw(Surface surface, Graphics g)
        {
            if (surface.Triangles == null)
                return;

           
            foreach (var triangle in surface.Triangles)
            {
                triangle.DrawEdges(g);
            }
        }

    }
}