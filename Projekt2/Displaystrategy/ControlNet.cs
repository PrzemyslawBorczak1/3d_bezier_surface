using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;

namespace Projekt2
{
    public class ControlNet : IDisplayStrategy
    {
        

        static ControlNet? instance = null;
        private ControlNet() { }
        public static ControlNet GetInstance()
        {
            if (instance == null)
            {
                instance = new ControlNet();
            }
            return instance;
        }


        

        public void Draw(Surface surface, Graphics g)
        {
            var points = surface.CalculetedPoints;
            if(points == null)
            {
                points = surface.ControlPoints;
                if(points == null)
                {
                    return;
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if(i + surface.Width < points.Count)
                    g.DrawLine(Pens.Green, points[i].X, points[i].Y, points[i + surface.Width].X, points[i + surface.Width].Y);

                if(i + 1 < points.Count && i % surface.Width != 3)
                    g.DrawLine(Pens.Green, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);


                // TODO change into one color
                if (points[i].Z < 0)
                    g.FillEllipse(Brushes.Green, points[i].X - 5, points[i].Y - 5, 10, 10);
                else
                    g.FillEllipse(Brushes.Red, points[i].X - 5, points[i].Y - 5, 10, 10);
            }
        }
    }
}
