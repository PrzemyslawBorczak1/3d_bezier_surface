using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class WigglySurface : Surface
    {

        private readonly DateTime _start = DateTime.UtcNow;

        public WigglySurface(List<Vector3> ControlPoints, int width, int height, int u, int v) : base(ControlPoints, width, height, u, v)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, e) =>
            {

                double t = (DateTime.UtcNow - _start).TotalSeconds;

                for (int i = 0; i < ControlPoints.Count; i++)
                {
                    CalculetedPoints[i] = new Vector3(
                        CalculetedPoints[i].X,
                        CalculetedPoints[i].Y + (int)(Math.Sin(t * 3 + i) * 5),
                        CalculetedPoints[i].Z
                    );
                }
            };
            timer.Start();
        }


        public WigglySurface(Surface other) : this(other.ControlPoints, other.Width, other.Height, other.U, other.V)
        {

        }
    }
}
