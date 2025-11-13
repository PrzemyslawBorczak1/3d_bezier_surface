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
                        //AET.Add(current.Value);
                        AET.Add(current.Value);
                        AET.Sort((e1, e2) => e1.X.CompareTo(e2.X));
                        //AET = InsertEdge(current.Value,new LinkedList<Edge>(AET)).ToList();
                        current = current.Next;
                    }
                }

                for (int ct = 0; ct < AET.Count; ct++)
                {
                    if (AET[ct].Ymax <= minY + i)
                    {
                        AET.RemoveAt(ct);
                        ct--;
                        continue;
                    }
                }


                for (int ct = 0; ct < AET.Count / 2; ct++)
                {
                    g.DrawLine(Pens.Red, (int)AET[2 * ct].X, minY + i, (int)AET[2 * ct + 1].X, minY + i);
                    AET[2 * ct].X += AET[2 * ct].M;
                    AET[2 * ct + 1].X += AET[2 * ct + 1].M;
                }

            }


        }


        private LinkedList<Edge> InsertEdge(Edge edge, LinkedList<Edge> list)
        {
          
            if (list.Count == 0)
            {
                list.AddFirst(edge);
                return list;
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


            return list;
        }


    }
}
