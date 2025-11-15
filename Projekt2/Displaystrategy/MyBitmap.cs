using System;
using System.Collections.Generic;
using System.Linq;
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

        public Color[] pixels;
        private int[] z;
        static object[] locks;

        public MyBitmap(Rectangle r)
        {
            minX = r.X;
            minY = r.Y;
            dx = r.Width;
            dy = r.Height;


            int amount = dx * dy;
            pixels = new Color[amount];
            z = new int[amount];
            locks = new object[amount];
            for (int i = 0; i < amount; i++)
            {
                locks[i] = new object();
            }
        }


        // to do lock on every set
        public void SetPixel(int x, int y, Color color)
        {
            int index = (x - minX) + (y - minY) * dx;
            lock (locks[index])
            {
                pixels[index] = color;
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
                pixels[index] = color;
                this.z[index] = z;
            }
        }
    }

}
