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

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);

            edges.Add(new Edge(a, b));
            edges.Add(new Edge(a, c));
            edges.Add(new Edge(b, c));
        }

        public void Draw(Graphics g)
        {
            foreach (var edge in edges)
            {
                g.DrawLine(Pens.Black, edge.Start.Cord.X, edge.Start.Cord.Y, edge.End.Cord.X, edge.End.Cord.Y);
            }

        }

        // bucket sort :((
        public void DrawSolidColor(Graphics g)
        {

            // oplaca sie ograniczyc rozmiar ET skoro wiemy ze sa 3 wartosci 
            // gdyby mial byc przyapadek ogolny konieczne byloby podanie wielkosci ET

            int minY = (int)Math.Min(Math.Min(vertices[0].Cord.Y, vertices[1].Cord.Y), vertices[2].Cord.Y);
            int maxY = (int)Math.Max(Math.Max(vertices[0].Cord.Y, vertices[1].Cord.Y), vertices[2].Cord.Y);
            int dy = maxY - minY + 1;


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
                    DrawLine(g, (int)AET[ct].X, (int)AET[ct + 1].X, minY + i);
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

        private void DrawLine(Graphics g, int x1, int x2, int Y)
        {
            g.DrawLine(Pens.Blue, x1, Y, x2, Y);

        }

    }
}
