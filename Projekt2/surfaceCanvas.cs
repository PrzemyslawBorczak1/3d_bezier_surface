using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Numerics;
using System.Globalization;

namespace Projekt2
{
    public partial class surfaceCanvas : UserControl
    {
        public Stage stage = new();


        System.Windows.Forms.Timer refreshTimer;


        public surfaceCanvas()
        {

            this.DoubleBuffered = true;
            this.UpdateStyles();

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 100;
            refreshTimer.Tick += (s, e) =>
            {
                Invalidate();
            };
            refreshTimer.Start();



            InitializeComponent();




        }

        public void SetControlPoints(List<Vector3> points, int width, int height)
        {
            Triangle.stage = stage;

            stage.SetControlPoints(points, width, height);
        }



        private void surfaceCanvas_Paint(object sender, PaintEventArgs e)
        {

            if (stage == null)
            {
                e.Graphics.DrawString("Load Points", this.Font, Brushes.White, new PointF(10, 10));
                return;
            }

            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(this.Width / 2, -this.Height / 2);

            stage.Paint(g);

        }


        public void SetAlfa(int alfa)
        {
            stage.Alfa = alfa;
            Invalidate();
        }
        public void SetBeta(int beta)
        {
            stage.Beta = beta;
            Invalidate();
        }

        public void SetU(int U)
        {
            stage.U = U;
            Invalidate();
        }
        public void SetV(int V)
        {
            stage.V = V;
            Invalidate();
        }



        public void AddDisplayStrategy(IDisplayStrategy strategy)
        {
            DisplayStrategy.AddStrategy(strategy);
        }


        public void SetKd(float Kd)
        {
            stage.Kd = Kd;

            Invalidate();
        }
        public void SetKs(float Ks)
        {
            stage.Ks = Ks;

            Invalidate();
        }

        public void SetM(int m)
        {
            stage.M = m;

            Invalidate();
        }

        public void SetSurfaceColor(Color color)
        {
            stage.SurfaceColor = color;
            Invalidate();
        }

        // TODO change light
        public void SetLightColor(Color color)
        {
            stage.SetLightColor(color);
            Invalidate();
        }

        public void SetMap(MyBitmap bitmap)
        {
            stage.Map = bitmap;
            Invalidate();
        }

        public void UseMap(bool use)
        {
            stage.UseMap = use;
            Invalidate();
        }

        public void SetTexture(MyBitmap bitmap)
        {
            stage.Texture = bitmap;
            Invalidate();
        }

        public void UseTexture(bool use)
        {
            stage.UseTexture = use;
            Invalidate();
        }

        public void LightTick(float val)
        {
            stage.LightTick(val);
        }

        public void SetMovingSurface(bool moving)
        {
            stage.SetMovingSurface(moving);
        }

        public void SetSpotlight(bool spotlight)
        {
            stage.SetSpotlight(spotlight);
        }
    }
}
