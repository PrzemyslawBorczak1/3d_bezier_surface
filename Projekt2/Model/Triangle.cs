using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using System.Numerics;

namespace Projekt2
{
    public class Triangle
    {
        public static Surface? surface = null;

        List<Vertex> vertices = new List<Vertex>();

        List<Edge> edges = new List<Edge>();

        public int minY;
        int maxY;
        public int dy;

        public int minX;
        int maxX;
        public int dx;


        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);

            edges.Add(new Edge(a, b));
            edges.Add(new Edge(a, c));
            edges.Add(new Edge(b, c));

            // ograniczenia dla bitmap i potem do algorytmu
            minY = (int)Math.Min(Math.Min(vertices[0].Cord.Y, vertices[1].Cord.Y), vertices[2].Cord.Y);
            maxY = (int)Math.Max(Math.Max(vertices[0].Cord.Y, vertices[1].Cord.Y), vertices[2].Cord.Y);
            dy = maxY - minY + 1;

            minX = (int)Math.Min(Math.Min(vertices[0].Cord.X, vertices[1].Cord.X), vertices[2].Cord.X);
            maxX = (int)Math.Max(Math.Max(vertices[0].Cord.X, vertices[1].Cord.X), vertices[2].Cord.X);
            dx = maxX - minX + 1;
        }

        public void DrawEdges(Graphics g)
        {
            foreach (var edge in edges)
            {
                g.DrawLine(Pens.Green, edge.Start.Cord.X, edge.Start.Cord.Y, edge.End.Cord.X, edge.End.Cord.Y);
            }

        }
        public void DrawSolidColor(MyBitmap myBitmap) => Fill(myBitmap, DrawLineSolid);
        public void DrawWithShadow(MyBitmap myBitmap) => Fill(myBitmap, ShadesLine);




        // bucket sort :((
        private void Fill(MyBitmap myBitmap,  Action<MyBitmap, int, int, int, float, float>DrawLine)
        {

            LinkedList<Edge>[] ET = new LinkedList<Edge>[dy];

            foreach (var edge in edges)
            {
                int index = edge.Ymin - minY;

                if (ET[index] == null)
                {
                    ET[index] = new LinkedList<Edge>();
                }
                InsertEdge(edge, ET[index]);

            }


            List<Edge> AET = new();

            for (int i = 0; i < dy; i++)
            {

                if (ET[i] != null)
                {
                    var current = ET[i].First;
                    while (current != null)
                    {
                        InsertEdge(current.Value, AET);
                        current = current.Next;
                    }
                }

                AET.RemoveAll(edge => edge.Ymax <= minY + i);


                for (int ct = 0; ct < AET.Count; ct += 2)
                {
                    DrawLine(myBitmap,(int)AET[ct].X, (int)AET[ct + 1].X,  i + minY, AET[ct].Z, AET[ct + 1].Z);
                    AET[ct].X += AET[ct].M;
                    AET[ct + 1].X += AET[ct + 1].M;

                    AET[ct].Z += AET[ct].ZM;
                    AET[ct + 1].Z += AET[ct + 1].ZM;
                }

            }


        }

        // nie ma sensu dla trojaktow ale wyglada fajnie
        private void InsertEdge(Edge edge, List<Edge> list)
        {
            int index = list.BinarySearch(edge, Comparer<Edge>.Create((e1, e2) => e1.X.CompareTo(e2.X)));
            if (index < 0)
            {
                index = ~index;
            }
            list.Insert(index, edge);
        }

        private void InsertEdge(Edge edge, LinkedList<Edge> list)
        {

            if (list.Count == 0)
            {
                list.AddFirst(edge);
                return;
            }

            var current = list.First;
            while (current != null && edge.X > current.Value.X)
            {
                current = current.Next;
            }

            if (current == null)
            {
                list.AddLast(edge);
            }
            else
            {
                list.AddBefore(current, edge);
            }


            return;
        }


        // TODO test but probaly doesnt need any changes
        private void DrawLineSolid(MyBitmap myBitmap, int x1, int x2, int y, float z1, float z2)
        {


            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
            }
            

            for (int x = x1; x <= x2; x++)
            {
                myBitmap.SetPixel(x, y, Color.Magenta);
            }

        }


        private void ShadesLine(MyBitmap myBitmap, int x1, int x2, int y, float z1, float z2)
        {
            if (x1 > x2)
            {
                (x1, x2) = (x2, x1);
                (z1, z2) = (z2, z1);
            }

            float z = z1;
            float zM = (x2 - x1) == 0 ? 0 : (z2 - z1) / (x2 - x1);
            for (int x = x1; x <= x2; x++)
            {
                PutPixelWithShade(myBitmap, x, y, (int)z);
                z += zM;
            }

        }
        private void PutPixelWithShade(MyBitmap myBitmap, int x, int y, int z)
        {
            // TODO wyliczanie tego
            if (surface == null)
            {
                throw new InvalidOperationException("Surface is not set for Triangle");
            }
            
            Vector3 LightSource = new(0, 0, 500);

            float kd = surface.Kd;
            float ks = surface.Ks;
            int m = surface.M;

            Vector3 Il = new(
                surface.LightColor.R / 255.0f,
                surface.LightColor.G / 255.0f,
                surface.LightColor.B / 255.0f);
            Vector3 Io = new(
                surface.SurfaceColor.R / 255.0f,
                surface.SurfaceColor.G / 255.0f,
                surface.SurfaceColor.B / 255.0f);


            Func<Vector3, Vector3, Vector3, float> Area = (a, b, c) =>
            {
                return Math.Abs((b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X)) * 0.5f;
            };

            float totalArea = Area(vertices[0].Cord, vertices[1].Cord, vertices[2].Cord);

            var p = new Vector3(x, y, 0);
            float alfa = Area(vertices[0].Cord, vertices[1].Cord, p) / totalArea;
            float beta = Area(vertices[0].Cord, p, vertices[2].Cord) / totalArea;
            float gamma = Area(p, vertices[1].Cord, vertices[2].Cord) / totalArea;


            var N = (alfa * vertices[2].Normal + beta * vertices[1].Normal + gamma * vertices[0].Normal);
            N = Vector3.Normalize(N);
            if(surface.Map != null && surface.UseMap)
            {
                double u = (alfa * vertices[2].U + beta * vertices[1].U + gamma * vertices[0].U);
                double v = (alfa * vertices[2].V + beta * vertices[1].V + gamma * vertices[0].V);

                u = Math.Clamp(u, 0f, 1f);
                v = Math.Clamp(v, 0f, 1f);

                var map = surface.Map;

                int ix = Math.Clamp((int)(u * map.Width), 0, map.Width - 1);
                int iy = Math.Clamp((int)(v * map.Height), 0, map.Height - 1);

                var color = map.GetPixel(ix, iy);

                float nx = color.R / 255f * 2f - 1f;
                float ny = color.G / 255f * 2f - 1f;
                float nz = Math.Abs(color.B / 255f * 2f - 1f);

                Vector3 NB = new Vector3(nx, ny, nz);

                var Pu = (alfa * vertices[2].Pu + beta * vertices[1].Pu + gamma * vertices[0].Pu);
                var Pv = (alfa * vertices[2].Pv + beta * vertices[1].Pv + gamma * vertices[0].Pv);

                

                Matrix3x3 M = new Matrix3x3(Vector3.Normalize(Pu), Vector3.Normalize(Pv), Vector3.Normalize(N));
                N = Vector3.Normalize(M * NB);
            }



            Vector3 L = Vector3.Normalize(LightSource - p);
            float cosNL = Vector3.Dot(N, L);
            var I = kd * Il * Io * cosNL;

            Vector3 V = new(0, 0, 1);
            Vector3 R = 2 * Vector3.Dot(N, L) * (N - L);
            float cosVR = Vector3.Dot(V, R);
            I += ks * Il * Io * (float)Math.Pow(cosVR, m);

            I.X = I.X < 0 ? 0 : I.X;
            I.Y = I.Y < 0 ? 0 : I.Y;
            I.Z = I.Z < 0 ? 0 : I.Z;

            myBitmap.SetPixel(x, y, z, Color.FromArgb(
                Math.Min((int)(I.X * 255), 255),
                Math.Min((int)(I.Y * 255), 255),
                Math.Min((int)(I.Z * 255), 255)
                ));
        }


    }
}
