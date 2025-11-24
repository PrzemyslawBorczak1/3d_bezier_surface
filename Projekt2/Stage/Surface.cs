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

        // TODO with ocnstrucotr???
        public int U = 10;
        public int V = 10;

        public List<Vector3> ControlPoints;


        public List<Vector3> CalculetedPoints;


        public Color SurfaceColor { get; set; } = Color.Green;

        public Vertex[] Vertices;
        public Triangle[] Triangles;

        public Surface(List<Vector3> ControlPoints, int width, int height, int u, int v)
        {
            this.ControlPoints = ControlPoints;
            CalculetedPoints = new List<Vector3>(ControlPoints);

            Width = width;
            Height = height;

            U = u;
            V = v;

            Vertices = new Vertex[U * V];
            Triangles = new Triangle[U * V * 2];

        }

        public Surface(Surface other) : this(other.ControlPoints, other.Width, other.Height, other.U, other.V)
        {
        }


        public Rectangle GetBounds()
        {
            int minX = CalculetedPoints.Min(p => (int)p.X);
            int minY = CalculetedPoints.Min(p => (int)p.Y);
            int maxX = CalculetedPoints.Max(p => (int)p.X);
            int maxY = CalculetedPoints.Max(p => (int)p.Y);

            return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
        }



        public void RotateControlPoints(int alfa, int beta)
        {
            if (CalculetedPoints.Count == 0)
            {
                CalculetedPoints = new List<Vector3>(ControlPoints);
            }

            CreateRotationMatrices(alfa, beta, out Matrix2x2 rotationX, out Matrix2x2 rotationZ);


            for (int i = 0; i < ControlPoints.Count; i++)
            {
                var point = ControlPoints[i];

                var rotX = rotationX * new Vector2(point.Y, point.Z);
                point.Y = rotX.X;
                point.Z = rotX.Y;

                var rotZ = rotationZ * new Vector2(point.X, point.Y);
                point.X = rotZ.X;
                point.Y = rotZ.Y;

                CalculetedPoints[i] = point;
            }


        }

        private void CreateRotationMatrices(float alfa, float beta, out Matrix2x2 rotationX, out Matrix2x2 rotationZ)
        {

            float radAlfa = alfa * (float)Math.PI / 180f;
            float cosAlfa = (float)Math.Cos(radAlfa);
            float sinAlfa = (float)Math.Sin(radAlfa);
            rotationX = new Matrix2x2(
                cosAlfa, -sinAlfa,
                sinAlfa, cosAlfa
                );


            float radBeta = beta * (float)Math.PI / 180f;
            float cosBeta = (float)Math.Cos(radBeta);
            float sinBeta = (float)Math.Sin(radBeta);
            rotationZ = new Matrix2x2(
                cosBeta, -sinBeta,
                sinBeta, cosBeta
                );
        }


        public void SetPrecision(int u, int v)
        {
            U = u;
            V = v;
        }












        public void MakeRenderReady()
        {

            if (CalculetedPoints.Count != 16)
            {
                CalculetedPoints = new List<Vector3>(ControlPoints);
            }

            Vertices = new Vertex[(U + 1) * (V + 1)];

            float u = (float)1 / U;
            float v = (float)1 / V;
            float uStep = 1f / U;
            float vStep = 1f / V;


            Parallel.For(0, U + 1, i =>
            {
                float ui = uStep * i;
                int rowBase = i * (V + 1);
                for (int j = 0; j < V + 1; j++)
                {
                    Vertices[rowBase + j] = CreateVertex(ui, vStep * j);
                }
            });


            SetTriangles();
        }


        private static float B(int i, int n, float t)
        {
            float s = 1;
            for (int k = 1; k <= i; k++)
                s *= (float)(n - k + 1) / k;

            s *= (float)Math.Pow(t, i);
            s *= (float)Math.Pow(1 - t, n - i);

            return s;
        }

        private Vertex CreateVertex(float u, float v)
        {
            int n = Width - 1;
            int m = Height - 1;

            Vector3 position = new ();
            Vector3 Pu = new ();
            Vector3 Pv = new ();

            for (int i = 0; i <= n; i++)
            {
                float bu = B(i, n, u);
                float bu_1 = (i < n) ? B(i, n - 1, u) : 0f;


                for (int j = 0; j <= m; j++)
                {
                    float bv = B(j, m, v);
                    float bv_1 = (j < m) ? B(j, m - 1, v) : 0f;


                    Vector3 V = CalculetedPoints[j + i * (m + 1)];

                    position += V * bu * bv;

                    if (i < n)
                    {
                        Vector3 diffU = CalculetedPoints[j + (i + 1) * (m + 1)] - V;

                        Pu += diffU * bu_1 * bv;
                    }

                    if (j < m)
                    {
                        Vector3 diffV = CalculetedPoints[(j + 1) + i * (m + 1)] - V;

                        Pv += diffV * bu * bv_1;
                    }


                }
            }

            Pu *= n;
            Pv *= m;



            var ret = new Vertex(position)
            {
                Pu = Pu,
                Pv = Pv,
                U = u,
                V = v,
                Normal = Vector3.Normalize(Vector3.Cross(Pu, Pv)),
            };

            return ret;
        }

        private  void SetTriangles()
        {
            Triangles = new Triangle[U * V * 2];


            Parallel.For(0, U, i =>
            {
                for (int j = 0; j < V; j++)
                {
                    int topLeft = i * (V + 1) + j;
                    int topRight = topLeft + 1;
                    int bottomLeft = topLeft + (V + 1);
                    int bottomRight = bottomLeft + 1;

                    Triangles[(i * V + j) * 2] = new Triangle(Vertices[topLeft], Vertices[topRight], Vertices[bottomLeft]);
                    Triangles[(i * V + j) * 2 + 1] = new Triangle(Vertices[topRight], Vertices[bottomRight], Vertices[bottomLeft]);

                }
            });
            

        }
    }

}



