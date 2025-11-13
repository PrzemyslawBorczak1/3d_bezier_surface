using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Projekt2
{
    public class Edge
    {
        public Vertex Start;
        public Vertex End;

        public int Ymin;
        public int Ymax;

        public float M;
        public float X;

        public Edge(Vertex start, Vertex end)
        {
            Start = start;
            End = end;

            if(Start.Cord.Y > End.Cord.Y)
            {
                var tmp = Start;
                Start = End;
                End = tmp;

            }

            Ymin = (int)Start.Cord.Y;
            Ymax = (int)End.Cord.Y;

            if (End.Cord.Y - Start.Cord.Y == 0)
                M = 0;
            else
                M = (End.Cord.X - Start.Cord.X) / (End.Cord.Y - Start.Cord.Y);

            X = Start.Cord.X;
        }

    }
}
