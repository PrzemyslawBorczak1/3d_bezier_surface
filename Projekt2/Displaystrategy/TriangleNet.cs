using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class TriangleNet : IDisplayStrategy
    {

        static TriangleNet? instance = null; 
        private TriangleNet()
        {
        }
        public static TriangleNet GetInstance()
        {
            if(instance == null)
                instance = new TriangleNet();
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
            //foreach (var ver in surface.Vertices)
            //{
            //    g.DrawLine(Pens.Black, ver.Cord.X, ver.Cord.Y, ver.Cord.X + ver.Normal.X, ver.Cord.Y + ver.Normal.Y);
            //}
        }

    }
}