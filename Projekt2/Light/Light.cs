using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Projekt2
{
    public class Light
    {
        public Color LightColor { get; set; } = Color.White;


        public Light()
        {
        }

        public Light(Light light)
        {
            this.LightColor = light.LightColor;
            this.alpha = light.alpha;

        }

        public Vector3 Position { get
            {
                float x = radius * (float)Math.Cos(alpha);
                float y = radius * (float)Math.Sin(alpha);

                return new Vector3(
                    (int)x,
                    (int)y,
                    height
                );
            } }

        public float alpha = 0;
        public int height = 100;
        public float radius = 100;


        public void TimerTick(float val)
        {
            alpha = (float)(val * 2 * Math.PI);

        }



        public virtual Vector3 CalcDiffuse(Vector3 N, Vector3 L, Vector3 V, Vector3 R, Vector3 Io,Vector3 Il, Light light, Stage stage)
        {
            if (stage == null)
            {
                throw new InvalidOperationException("Surface is not set for Triangle");
            }


            float kd = stage.Kd;
            float ks = stage.Ks;
            int m = stage.M;

            

            float cosNL = Vector3.Dot(N, L);

            var I = kd * Il * Io * cosNL;

            return I;
        }

        public virtual Vector3 CalcSpectlar(Vector3 N, Vector3 L, Vector3 V, Vector3 R, Vector3 Io,Vector3 Il, Light light, Stage stage)
        {
            if (stage == null)
            {
                throw new InvalidOperationException("Surface is not set for Triangle");
            }


            float kd = stage.Kd;
            float ks = stage.Ks;
            int m = stage.M;

            float cosVR = Vector3.Dot(V, R);


            var I = ks * Il * Io * (float)Math.Pow(cosVR, m);

            return I;

        }



    }
}
