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


        public void ChangeFromLambert() { }


        public Light()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); timer.Interval = 100;
            timer.Tick += (s, e) =>
            {
                TimerTick();
            };
            timer.Start();
        }


        public void TimerTick()
        {
            alpha += (float)Math.PI / 16;
            alpha %= (float)(2 * Math.PI);



            //Position = new Vector3(this.Position.X + 1, this.Position.Y, this.Position.Z);
        }
    }
}
