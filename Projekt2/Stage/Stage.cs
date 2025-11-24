using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class Stage
    {

        public Surface? surface;

        public List<Light> Lights { get; set; } = new() { new() };

        private int _alfa = 0;
        public int Alfa
        {
            get => _alfa;
            set
            {
                if (_alfa == value)
                    return;

                _alfa = value;
                surface?.RotateControlPoints(_alfa, _beta);
            }
        }
        private int _beta = 0;
        public int Beta
        {
            get => _beta;
            set
            {
                if (_beta == value)
                    return;
                _beta = value;

                surface?.RotateControlPoints(_alfa, _beta);
            }
        }

        private int _u = 5;
        public int U
        {
            get => _u;
            set
            {
                if (_u == value)
                    return;
                _u = value;

                surface?.SetPrecision(_u, _v);
            }
        }
        public int _v = 5;
        public int V
        {
            get => _v;
            set
            {
                if (_v == value)
                    return;
                _v = value;

                surface?.SetPrecision(_u, _v);
            }
        }


        public float Kd { get; set; } = .5f;
        public float Ks { get; set; } = .5f;
        public int M { get; set; } = 1;

        public Color SurfaceColor { get; set; } = Color.Green;

        public MyBitmap? Map { get; set; } = null;
        public bool UseMap { get; set; } = false;
        public MyBitmap? Texture { get; set; } = null;
        public bool UseTexture { get; set; } = false;

        public void SetControlPoints(List<Vector3> points, int width, int height)
        {
            surface = new Surface(points, width, height, U, V);
            //surface = new WigglySurface(surface);
        }

        public void Paint(Graphics g)
        {
            if (surface == null)
            {
                g.ScaleTransform(1f, -1f);
                g.DrawString("Load Points", SystemFonts.DefaultFont, Brushes.White, new PointF(10, 10));

                return;
            }


            surface.MakeRenderReady();
            DisplayStrategy.DrawAll(surface, g);

        }

        public void SetLightColor(Color color)
        {
            Lights[0].LightColor = color;
        }


        public List<Light> GetLights() => Lights;

        public void LightTick(float val)
        {
            foreach (var light in Lights)
            {
                light.TimerTick(val);
            }
        }


        public void SetMovingSurface(bool moving)
        {
            if (surface == null)
                return;

            if (moving)
                surface = new WigglySurface(surface);
            else
                surface = new Surface(surface);
        }



        public void SetSpotlight(bool spotlight)
        {
            Light l = Lights[0];
            Lights.Clear();
            if (!spotlight)
                Lights.Add(new Light(l));
            else
                Lights.Add(new SpotLight(l));
        }
    }
}
