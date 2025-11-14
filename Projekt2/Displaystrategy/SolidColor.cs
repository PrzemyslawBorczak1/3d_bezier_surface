using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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
            var surfaceBounds = surface.GetBounds();

            MyBitmap myBitmap = new MyBitmap(surfaceBounds);


            // TODO parallel
            //Parallel.For(0, surface.Triangles.Count, i =>
            //{
            //    var tr = surface.Triangles[i];
            //    tr.DrawSolidColor(myBitmap);
            //});



            foreach (var tr in surface.Triangles)
            {
                tr.DrawSolidColor(myBitmap);
            }
            //surface.Triangles[0].DrawSolidColor(myBitmap);

            //surface.Triangles[2].DrawSolidColor(myBitmap);
            //surface.Triangles[4].DrawSolidColor(myBitmap);

            //surface.Triangles[1].DrawSolidColor(myBitmap);


            Bitmap final = Blit(myBitmap.pixels, surfaceBounds.Width, surfaceBounds.Height);
            g.DrawImage(final, surfaceBounds.X, surfaceBounds.Y);

        }


        // TODO add marshal
        public Bitmap Blit(Color[] src, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = x + y * width;
                    bitmap.SetPixel(x, y, src[index]);
                }
            }

            return bitmap;
        }

        public void DrawWithShadow(Surface surface, Graphics g)
        {
            Bitmap bmp = new Bitmap(surface.Width, surface.Height);
            Parallel.For(0, surface.Triangles.Count, i =>
            {
                var tr = surface.Triangles[i];
                tr.DrawWithShadow(bmp);
            });
        }


     /*   public static void DrawSolidColor(this Triangle triangle, Bitmap b)
        {
            triangle.Draw(b, triangle.DrawLineSolid);
        }
*/
    }


    public class MyBitmap
    {
        int minX;
        int minY;
        int dx;
        int dy;

        public Color[] pixels;
        object locker = new();

        public MyBitmap(Rectangle r)
        {
            minX = r.X;
            minY = r.Y;
            dx = r.Width;
            dy = r.Height;


            pixels = new Color[dx * dy];
            //locks = new object[dx * dy];
        }

        // to do lock on every set
        public void SetPixel(int x, int y, Color color)
        {
            int index = (x - minX)  + (y - minY) * dx;
            lock (locker)
            {
                pixels[index] = color;
            }
        }
    }
}
