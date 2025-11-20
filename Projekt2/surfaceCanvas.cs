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
        public Stage stage = new ();



        public surfaceCanvas()
        {

            this.DoubleBuffered = true;
            this.UpdateStyles();

            // TODO usunac 
            // bardzo wazne z tym program nie dziala

            var path = "C:\\Users\\przem\\Pulpit\\BezierSurfacePoints.txt";

            var amount = 16;
            List<Vector3> pts = new(amount);

            var lines = File.ReadAllLines(path);
            if (lines.Length != amount) throw new InvalidDataException("Plik musi zawierać 16 linii.");

            for (int i = 0; i < amount; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    throw new InvalidDataException($"Pusta linia: {i}");

                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3)
                    throw new InvalidDataException($"Linia {i + 1} nie ma 3 wartości.");

                var x = float.Parse(parts[0], CultureInfo.InvariantCulture);
                var y = float.Parse(parts[1], CultureInfo.InvariantCulture);
                var z = float.Parse(parts[2], CultureInfo.InvariantCulture);


                pts.Add(new Vector3(x, y, z));
            }


            SetControlPoints(pts, 4, 4);

            Refresh();


            // TODO dotad

            InitializeComponent();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, e) =>
            {
                Invalidate();
            };
            timer.Start();


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
        

    
    
    }
}
