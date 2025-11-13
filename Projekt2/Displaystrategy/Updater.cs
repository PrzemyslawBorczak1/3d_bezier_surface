using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Projekt2
{
    public static class Updater
    {
        static float Alfa;
        static float Beta;

        static Matrix2x2? rotationX;
        static Matrix2x2? rotationZ;


        static int precisionU;
        static int precisionV;

        static bool rotationChanged = false;
        static bool precisionChanged = false;

        public static void UpdateAngles(float alfa, float beta)
        {

            if (alfa != Alfa || rotationX == null)
            {
                rotationChanged = true;
                Alfa = alfa;
                float radAlfa = Alfa * (float)Math.PI / 180f;
                float cosAlfa = (float)Math.Cos(radAlfa);
                float sinAlfa = (float)Math.Sin(radAlfa);
                rotationX = new Matrix2x2(
                    cosAlfa, -sinAlfa,
                    sinAlfa, cosAlfa
                    );
            }

            if (beta != Beta || rotationZ == null)
            {
                rotationChanged = true;
                Beta = beta;
                float radBeta = Beta * (float)Math.PI / 180f;
                float cosBeta = (float)Math.Cos(radBeta);
                float sinBeta = (float)Math.Sin(radBeta);
                rotationZ = new Matrix2x2(
                    cosBeta, -sinBeta,
                    sinBeta, cosBeta
                    );
            }
        }
        public static void UpdatePrecision(int precisionU, int precisionV)
        {
            if (precisionU != Updater.precisionU)
            {
                precisionChanged = true;
                Updater.precisionU = precisionU;
            }
            if (precisionV != Updater.precisionV)
            {
                precisionChanged = true;
                Updater.precisionV = precisionV;
            }
        }


        // liczy nowe punkty dla kontrolne po transfomracjach
        // jesli neeedUpdate jest false to ustawia obliczone punkty kontrolne na te startowe bez zmian
        public static void UpdateSurface(Surface surface)
        {
            if (surface.ControlPoints.Count == 0)
                return;


            if (surface.CalculetedPoints.Count == 0)  {
                surface.CalculetedPoints = new(surface.ControlPoints);
            }

            // nic nie sie nie zmienilo
            if (!rotationChanged && !precisionChanged)
                return;


            if(rotationChanged)
                RotateControlPoints(surface);

            SetNewNet(surface);

            SetVertices(surface);


        }


        private static void RotateControlPoints(Surface surface)
        {
           

            if (rotationX == null || rotationZ == null)
            {
                throw new Exception("Rotations not set");

            }


            for (int i = 0; i < surface.ControlPoints.Count; i++)
            {
                var point = surface.ControlPoints[i];

                var rotX = rotationX * new Vector2(point.Y, point.Z);
                point.Y = rotX.X;
                point.Z = rotX.Y;

                var rotZ = rotationZ * new Vector2(point.X, point.Y);
                point.X = rotZ.X;
                point.Y = rotZ.Y;

                surface.CalculetedPoints[i] = point;
            }
        }

        private static void SetNewNet(Surface surface)
        {

            var points = surface.CalculetedPoints;
            if (points.Count != 16)
            {
                throw new Exception("Control points count must be 16");
            }

            var a = CalculateBeizerPoints(
                points[0],
                points[1],
                points[2],
                points[3],
                precisionU
                );

            var b = CalculateBeizerPoints(
               points[0 + 4],
               points[1 + 4],
               points[2 + 4],
               points[3 + 4],
                precisionU
               );
            var c = CalculateBeizerPoints(
               points[0 + 8],
               points[1 + 8],
               points[2 + 8],
               points[3 + 8],
               precisionU
               );
            var d = CalculateBeizerPoints(
               points[0 + 12],
               points[1 + 12],
               points[2 + 12],
               points[3 + 12],
               precisionU
               );


            var bezierPoints = new List<Vector3>();

            for (int i = 0; i < precisionU + 1; i++)
            {
                var col = CalculateBeizerPoints(
                   a[i],
                   b[i],
                   c[i],
                   d[i],
                   precisionV
                   );
                bezierPoints.AddRange(col);
            }

            surface.BezierPoints = bezierPoints;
        }

        private static List<Vector3> CalculateBeizerPoints(Vector3 from, Vector3 cp1, Vector3 cp2, Vector3 to, int precision)
        {
         
            var bezierPoints = new List<Vector3>();
            Vector3 A0 = from;
            Vector3 A1 = 3 * (cp1 - from);
            Vector3 A2 = 3 * (cp2 - 2 * cp1 + from);
            Vector3 A3 = to - 3 * cp2 + 3 * cp1 - from;

            float d = 1.0f / precision;
            float d2 = d * d;
            float d3 = d2 * d;

            var P0 = A0;
            var P1 = A3 * d3 + A2 * d2 + A1 * d;
            var P2 = 6 * A3 * d3 + 2 * A2 * d2;
            var P3 = 6 * A3 * d3;

            for (int i = 0; i <= precision; i++)
            {
                bezierPoints.Add(P0);
                P0 += P1;
                P1 += P2;
                P2 += P3;
            }

            return bezierPoints;
        }


        private static void SetVertices(Surface surface)
        {
            List<Vector3> points = surface.BezierPoints;
            if(points.Count != (precisionU + 1) * (precisionV + 1))
                return;
            List<Vertex> vertices = surface.Vertices;
            vertices.Clear();

            
            for (int i = 0; i < points.Count; i++)
            {
                vertices.Add(new Vertex(points[i]));
            }


            List<Triangle> triangels = surface.Triangles;
            triangels.Clear();
            

            for (int i = 0; i < precisionU; i++)
            {
                for(int j = 0; j < precisionV; j++)
                {
                    int topLeft = i * (precisionV + 1) + j;
                    int topRight = topLeft + 1;
                    int bottomLeft = topLeft + (precisionV + 1);
                    int bottomRight = bottomLeft + 1;

                    triangels.Add(new Triangle(vertices[topLeft], vertices[topRight], vertices[bottomLeft]));
                    triangels.Add(new Triangle(vertices[topRight], vertices[bottomRight], vertices[bottomLeft]));
                }
            }

            surface.Vertices = vertices;
            surface.Triangles = triangels;

        }
    }
}
