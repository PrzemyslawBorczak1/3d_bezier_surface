using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class Fill : IDisplayStrategy
    {
        static Fill? instance = null;
        private Fill() { }
        public static Fill GetInstance()
        {
            if (instance == null)
            {
                instance = new Fill();
            }
            return instance;
        }

        public void Draw(Surface surface, Graphics g)
        {


            var surfaceBounds = surface.GetBounds();

            MyBitmap myBitmap = new MyBitmap(surfaceBounds);


            //Parallel.For(0, surface.Triangles.Count, i =>
            //{
            //    var tr = surface.Triangles[i];
            //    tr.DrawWithShadow(myBitmap);
            //});

            //TODO parallel
            //var tr = surface.Triangles[0];
            //tr.DrawWithShadow(myBitmap);

            //tr = surface.Triangles[1];
            //tr.DrawWithShadow(myBitmap);

            foreach (var tr in surface.Triangles)
            {
                tr.DrawWithShadow(myBitmap);
            }

            Bitmap final = Blit(myBitmap.pixels, surfaceBounds.Width, surfaceBounds.Height);
            g.DrawImage(final, surfaceBounds.X, surfaceBounds.Y);

        }

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


    }
}
