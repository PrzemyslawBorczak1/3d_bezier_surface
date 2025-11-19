using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Projekt2
{
    public class Stage
    {

        public Surface surface;

        public List<Light> Lights { get; set; } = new List<Light>();

        private int _alfa = 0;
        public int Alfa { 
            get => _alfa;
            set
            {
                if (_alfa == value)
                    return;

                _alfa = value;
               // Updater.UpdateAngles(_alfa, _beta);
            }
        }
        private int _beta = 0;
        public int Beta {
            get => _beta;
            set {
                if (_beta == value)
                    return;
                _beta = value;
              //  Updater.UpdateAngles(_alfa, _beta);
            }
        }

        private int _u = 5;
        public int U { 
            get => _u;
            set {
                if(_u == value)
                    return;
                _u = value;
               // Updater.UpdatePrecision(_u, _v);
            }
        }
        public int _v = 5;
        public int V
        {
            get => _v;
            set  {
                if(_v == value)
                    return;
                _v = value;
             //   Updater.UpdatePrecision(_u, _v);
            }
        }


        public float Kd { get; set; } = .5f;
        public float Ks { get; set; } = .5f;
        public int M { get; set; } = 1;

        public Color SurfaceColor { get; set; } = Color.Green;
        public Color LightColor { get; set; } = Color.White;

        public MyBitmap? Map { get; set; } = null;
        public bool UseMap { get; set; } = false;
        public MyBitmap? Texture { get; set; } = null;
        public bool UseTexture { get; set; } = false;

        public Stage()
        {
           surface = new Surface();
        }

        public void SetControlPoints(List<Vector3> points, int width, int height)
        {
            surface.SetControlPoints(points, width, height);
        }

        public void Paint(Graphics g)
        {
            // TODO change (not give surface)
            DisplayStrategy.DrawAll(surface, g);

        }




        public void SetAlfa(int alfa)
        {
            Alfa = alfa;

            Updater.UpdateAngles(_alfa,_beta);

        }

        public void SetBeta(int beta)
        {
            Beta = beta;
            Updater.UpdateAngles(_alfa, _beta);
        }

        public void SetU(int U)
        {
            this.U = U;
            Updater.UpdatePrecision(_u, _v);
        }
        public void SetV(int V)
        {
            this.V = V;
            Updater.UpdatePrecision(_u, _v);
        }
    }
}
