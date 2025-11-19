using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class MyBitmap
    {
        int minX;
        int minY;
        int dx;
        int dy;

        private int[] pixels;
        private int[] z;
        private object[] locks;

        public MyBitmap(Rectangle r)
        {
            minX = r.X;
            minY = r.Y;
            dx = r.Width;
            dy = r.Height;


            int amount = dx * dy;
            pixels = new int[amount];
            z = new int[amount];
            locks = new object[amount];
            for (int i = 0; i < amount; i++)
            {
                locks[i] = new object();
                z[i] = int.MinValue;
            }
        }
        public MyBitmap(Bitmap bmp)
        {
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            bmp = bmp.PixelFormat == PixelFormat.Format32bppArgb
                ? bmp
                : bmp.Clone(rect, PixelFormat.Format32bppArgb);

            minX = 0;
            minY = 0;
            dx = bmp.Width;
            dy = bmp.Height;


            int amount = dx * dy;
            pixels = new int[amount];
            z = new int[amount];
            locks = new object[amount];
            for (int i = 0; i < amount; i++)
            {
                locks[i] = new object();
                z[i] = int.MinValue;
            }

            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(data.Scan0, pixels, 0, dx * dy);

            bmp.UnlockBits(data);

        }


        public void SetPixel(int x, int y, Color color)
        {
            int index = (x - minX) + (y - minY) * dx;
            lock (locks[index])
            {
                pixels[index] = color.ToArgb();
            }
        }

        public void SetPixel(int x, int y, int z, Color color)
        {
            int index = (x - minX) + (y - minY) * dx;
            if (z < this.z[index])
            {
                return;
            }

            lock (locks[index])
            {
                pixels[index] = color.ToArgb();
                this.z[index] = z;
            }
        }

      
        public Color GetPixel(int x, int y)
        {
            int index = (x - minX) + (y - minY) * dx;
            return Color.FromArgb(pixels[index]);
        }
        public Color GetPixel(float u, float v)
        {
            var x = (int)(u * (dx - 1));
            var y = (int)(v * (dy - 1));

            return GetPixel(x, y);
        }
        
        public Bitmap CopyToBitmap()
        {
            Bitmap bitmap = new Bitmap(dx, dy, PixelFormat.Format32bppArgb);

            var rect = new Rectangle(0, 0, dx, dy);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr ptr = bitmapData.Scan0;

                Marshal.Copy(pixels, 0, ptr, pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            return bitmap;
        }

    }

}


