using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class Surface
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Vector3> ControlPoints = new();


        public int Alfa { get; set; } = 0;
        public int Beta { get; set; } = 0;
        public List<Vector3> CalculetedPoints = new();


       // public List<Vector3> BezierPoints = new();

        public List<Vertex> Vertices = new();
        public List<Triangle> Triangles = new();

        public float Kd { get; set; }
        public float Ks { get; set; }
        public int M { get; set; }

        public Color SurfaceColor { get; set; } = Color.Blue;
        public Color LightColor { get; set; } = Color.White;



        public void SetControlPoints(List<Vector3> points, int width, int height)
        {
            ControlPoints = points;
            Width = width;
            Height = height;
        }

        // TODO mayby fsater?
        public Rectangle GetBounds()
        {
            int minX = CalculetedPoints.Min(p => (int)p.X);
            int minY = CalculetedPoints.Min(p => (int)p.Y);
            int maxX = CalculetedPoints.Max(p => (int)p.X);
            int maxY = CalculetedPoints.Max(p => (int)p.Y);

            return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
        }
    }
}
