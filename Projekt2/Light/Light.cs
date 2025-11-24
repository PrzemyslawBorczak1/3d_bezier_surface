using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Projekt2
{
    public class Light
    {
        public Color LightColor { get; set; } = Color.White;

        public Vector3 Position { get
            {
                float x = radius * (float)Math.Cos(alpha);
                float y = radius * (float)Math.Sin(alpha);



                return new Vector3(
                    (int)x,
                    (int)y,
                    height
                );
            } }

        private float alpha = 0;
        private int height = 100;
        private float radius = 1000;


        public Vector3 ChangeFromLambert() {
            return new Vector3(0, 0, 0);
        }

        public void TimerTick(float val)
        {
            alpha = (float)(val * 2 * Math.PI);

        }
    }
}
