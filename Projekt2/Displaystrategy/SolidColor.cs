using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class SolidColor : IDisplayStrategy
    {
        static SolidColor? instance = null;
        private SolidColor() { }
        public static SolidColor GetInstance()
        {
            if (instance == null)
            {
                instance = new SolidColor();
            }
            return instance;
        }

        public void Draw(Surface surface, Graphics g)
        {
           
            foreach (var tr in surface.Triangles)
            {
           //     var tr = surface.Triangles[0];
                tr.DrawSolidColor(g);
            }
        }
    }
}
