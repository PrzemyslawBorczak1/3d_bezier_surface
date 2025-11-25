using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    public class SpotLight : Light
    {
        public SpotLight(Light light) : base(light)
        {
        }



        private Vector3 ChangeIl(Vector3 L, Vector3 Il, int M)
        {
            Vector3 axis = Vector3.Normalize(Position);
            Vector3 toPoint = -L;

            float cosTheta = Vector3.Dot(axis, toPoint);
            cosTheta *= -1;

            cosTheta = MathF.Max(cosTheta, 0);

            float spotEffect = MathF.Pow(cosTheta, M);

            Il *= spotEffect;
            return Vector3.Normalize(Il);
        }


        public override Vector3 CalcDiffuse(Vector3 N, Vector3 L, Vector3 V, Vector3 R, Vector3 Io, Vector3 Il, Light light, Stage stage)
        {
            Il = ChangeIl(L, Il, stage.M);
            return base.CalcDiffuse(N, L, V, R, Io, Il, light, stage);

        }

        public override Vector3 CalcSpectlar(Vector3 N, Vector3 L, Vector3 V, Vector3 R, Vector3 Io, Vector3 Il, Light light, Stage stage)
        {
            Il = ChangeIl(L, Il, stage.M);
            return base.CalcSpectlar(N, L, V, R, Io, Il, light, stage);
        }
    }
}
