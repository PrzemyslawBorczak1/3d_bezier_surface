using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
namespace Projekt2
{
    public class Matrix2x2
    {

        float e11;
        float e12;
        float e21;
        float e22;
        public Matrix2x2
            (
            float e11, float e12,
            float e21, float e22
            )
        {
            this.e11 = e11;
            this.e12 = e12;
            this.e21 = e21;
            this.e22 = e22;
        }


        public static Vector2 operator *(Matrix2x2 m, Vector2 vec)
        {
            float x = m.e11 * vec.X + m.e12 * vec.Y;
            float y = m.e21 * vec.X + m.e22 * vec.Y;
            return new Vector2(x, y);
        }

        public static Matrix2x2 operator *(Matrix2x2 a, Matrix2x2 b)
        {
            return new Matrix2x2(
                a.e11 * b.e11 + a.e12 * b.e21,
                a.e11 * b.e12 + a.e12 * b.e22,
                a.e21 * b.e11 + a.e22 * b.e21,
                a.e21 * b.e12 + a.e22 * b.e22
                );
        }

        public static Matrix2x2 Identity()
        {
            return new Matrix2x2(
                1, 0,
                0, 1
                );
        }


    }
}
