using System;
using System.Numerics;

namespace Projekt2
{
   
    public class Matrix3x3
    {
        public Vector3 Col1 { get; }
        public Vector3 Col2 { get; }
        public Vector3 Col3 { get; }

        public Matrix3x3(Vector3 col1, Vector3 col2, Vector3 col3)
        {
            Col1 = col1;
            Col2 = col2;
            Col3 = col3;
        }

        public static Vector3 operator *(Matrix3x3 m, Vector3 v)
        {
            return m.Col1 * v.X + m.Col2 * v.Y + m.Col3 * v.Z;
        }

        }
}
