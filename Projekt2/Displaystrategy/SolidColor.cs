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
            Parallel.For(0, surface.Triangles.Count, i =>
            {
                var tr = surface.Triangles[i];
                tr.DrawSolidColor(myBitmap);
            });



            //foreach (var tr in surface.Triangles)
            //{
            //    tr.DrawSolidColor(myBitmap);
            //}
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
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            var rect = new Rectangle(0, 0, width, height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr ptr = bitmapData.Scan0;

                int bytesPerPixel = 4; 
                byte[] pixelData = new byte[width * height * bytesPerPixel];

                for (int i = 0; i < src.Length; i++)
                {
                    int offset = i * bytesPerPixel;
                    pixelData[offset] = src[i].B;     
                    pixelData[offset + 1] = src[i].G; 
                    pixelData[offset + 2] = src[i].R; 
                    pixelData[offset + 3] = src[i].A; 
                }

                Marshal.Copy(pixelData, 0, ptr, pixelData.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
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
        static object[] locks;

        public MyBitmap(Rectangle r)
        {
            minX = r.X;
            minY = r.Y;
            dx = r.Width;
            dy = r.Height;


            int amount = dx * dy;
            pixels = new Color[amount];
            locks = new object[amount];
            for (int i = 0; i < amount; i++)
            {
                locks[i] = new object();
            }
        }


        // to do lock on every set
        public void SetPixel(int x, int y, Color color)
        {
            int index = (x - minX)  + (y - minY) * dx;
            lock (locks[index])
            {
                pixels[index] = color;
            }
        }
    }
}
