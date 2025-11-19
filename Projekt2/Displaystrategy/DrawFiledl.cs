using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class DrawFiledl : IDisplayStrategy
    {
        static DrawFiledl? instance = null;
        private DrawFiledl() { }
        public static DrawFiledl GetInstance()
        {
            if (instance == null)
            {
                instance = new DrawFiledl();
            }
            return instance;
        }

        public void Draw(Surface surface, Graphics g)
        {
            var surfaceBounds = surface.GetBounds();
            MyBitmap myBitmap = new MyBitmap(surfaceBounds);


            foreach (var tr in surface.Triangles)
            {
                tr.DrawWithShadow(myBitmap);
            }

            Bitmap final = myBitmap.CopyToBitmap();
            g.DrawImage(final, surfaceBounds.X, surfaceBounds.Y);

        }
    }
}
