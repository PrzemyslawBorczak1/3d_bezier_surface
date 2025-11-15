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
        private Surface? surface;



        public surfaceCanvas()
        {

            this.DoubleBuffered = true;
            this.UpdateStyles();

            // TODO usunac 

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


            UpdateAngles(0, 0);
            UpdatePrecision(5, 5);
            SetControlPoints(pts, 4, 4);
            Refresh();


            // TODO dotad

            InitializeComponent();
        }

        public void SetControlPoints(List<Vector3> points, int width, int height)
        {
            if (surface == null)
            {
                surface = new Surface();

            }
            Triangle.surface = surface;

            surface.SetControlPoints(points, width, height);
        }



        private void surfaceCanvas_Paint(object sender, PaintEventArgs e)
        {

            if (surface == null)
            {
                e.Graphics.DrawString("Load Points", this.Font, Brushes.Black, new PointF(10, 10));
                return;
            }

            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(this.Width / 2, -this.Height / 2);
            DisplayStrategy.DrawAll(surface, g);

        }



        public void UpdateAngles(int alfa, int beta)
        {
            Updater.UpdateAngles(alfa, beta);

            Invalidate();
        }

        public void UpdatePrecision(int U, int V)
        {

            Updater.UpdatePrecision(U, V);

            Invalidate();
        }


        public void AddDisplayStrategy(IDisplayStrategy strategy)
        {
            DisplayStrategy.AddStrategy(strategy);
        }


        public void SetKd(float Kd)
        {

            if (surface == null)
                return;
            lock (surface)
            {
                surface.Kd = Kd;
            }
            Invalidate();
        }
        public void SetKs(float Ks)
        {
            if (surface == null)
                return;

            surface.Ks = Ks;

            Invalidate();
        }

        public void SetM(int m)
        {
            if (surface == null)
                return;


            surface.M = m;

            Invalidate();
        }

        public void SetSurfaceColor(Color color)
        {
            if (surface == null)
                return;
            surface.SurfaceColor = color;
            Invalidate();
        }

        public void SetLightColor(Color color)
        {
            if (surface == null)
                return;
            surface.LightColor = color;
            Invalidate();
        }
    }
}
