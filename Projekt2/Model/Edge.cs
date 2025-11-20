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

        public float Z;
        public float ZM;

        public Edge(Vertex start, Vertex end)
        {
            Start = start;
            End = end;

            if(Start.Cord.Y > End.Cord.Y)
                (Start , End) = (End, Start);


            Ymin = (int)Start.Cord.Y;
            Ymax = (int)End.Cord.Y;

            M = End.Cord.Y - Start.Cord.Y == 0 ?
                0 :
                (End.Cord.X - Start.Cord.X) / (End.Cord.Y - Start.Cord.Y);

            ZM = End.Cord.Z - Start.Cord.Z == 0 ?
                0 :
                (End.Cord.Z - Start.Cord.Z) / (End.Cord.Y - Start.Cord.Y);

            X = Start.Cord.X;
            Z = Start.Cord.Z;
        }

    }
}
