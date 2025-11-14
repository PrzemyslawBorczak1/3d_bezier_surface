using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class Triangle
    {
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

        public void Draw(Graphics g)
        {
            foreach (var edge in edges)
            {
                g.DrawLine(Pens.Black, edge.Start.Cord.X, edge.Start.Cord.Y, edge.End.Cord.X, edge.End.Cord.Y);
            }

        }

        // bucket sort :((
        public void Draw(MyBitmap myBitmap,  Action<MyBitmap, int, int, int>DrawLine)
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
                    DrawLine(myBitmap,(int)AET[ct].X, (int)AET[ct + 1].X,  i     + minY);
                    AET[ct].X += AET[ct].M;
                    AET[ct + 1].X += AET[ct + 1].M;
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








        private void DrawLineSolid(MyBitmap myBitmap, int x1, int x2, int y)
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

        public void DrawSolidColor(MyBitmap myBitmap)
        {
            Draw(myBitmap, DrawLineSolid);
        }



        public void DrawWithShadow(Bitmap b)
        {


        }
        public void PutPixel(Bitmap b, int x, int y)
        {
            if (x >= 0 && x < b.Width && y >= 0 && y < b.Height)
            {
                b.SetPixel(x, y, Color.Red);
            }
        }

    }
}
