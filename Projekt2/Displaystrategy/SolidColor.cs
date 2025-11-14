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
            List<(Bitmap, (int,int))> bitmaps = new List<(Bitmap, (int,int))>();


            Parallel.For(0, surface.Triangles.Count, i =>
            {
                var tr = surface.Triangles[i];
                Bitmap triBmp = new Bitmap(tr.dx, tr.dy);
                tr.DrawSolidColor(triBmp);
                lock (bitmaps)
                {
                    bitmaps.Add((triBmp, (tr.minX, tr.minY)));
                }
            });

            Parallel.For(0, surface.Triangles.Count, i =>
            {
                var tr = surface.Triangles[(int)i];
                tr.DrawSolidColor(bitmaps[i].Item1);
            });



            Bitmap final = new Bitmap(1600, 1600);

            foreach (var bmp in bitmaps)
            {
                Blit(bmp.Item1, final, 800 + bmp.Item2.Item1, 800 + bmp.Item2.Item2);
                //g.DrawImage(bmp, 0, 0);
            }
           g.DrawImage(final, -800, -800);

        }

        public static void Blit(Bitmap src, Bitmap dst, int x, int y)
        {
            int width = Math.Min(src.Width, dst.Width - x);
            int height = Math.Min(src.Height, dst.Height - y);

            if (width <= 0 || height <= 0)
            {
                return;
            }

            var srcRect = new Rectangle(0, 0, width, height);
            var dstRect = new Rectangle(x, y, width, height);

            var srcData = src.LockBits(srcRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var dstData = dst.LockBits(dstRect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try
            {
                int bytesPerPixel = 4; 
                int srcStride = srcData.Stride;
                int dstStride = dstData.Stride;

                byte[] rowBuffer = new byte[width * bytesPerPixel];

                for (int row = 0; row < height; row++)
                {
                    IntPtr srcRowPtr = srcData.Scan0 + row * srcStride;
                    Marshal.Copy(srcRowPtr, rowBuffer, 0, rowBuffer.Length);

                    IntPtr dstRowPtr = dstData.Scan0 + row * dstStride;
                    Marshal.Copy(rowBuffer, 0, dstRowPtr, rowBuffer.Length);
                }
            }
            finally
            {
                src.UnlockBits(srcData);
                dst.UnlockBits(dstData);
            }
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
    }
}
