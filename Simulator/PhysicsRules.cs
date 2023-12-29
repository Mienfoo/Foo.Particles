using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo.Particles.Simulator
{
    static class PhysicsRules
    {
        public static void BasicAttraction(List<Particle> p1, List<Particle> p2, float g)
        {
            float MinRange = 2f;
            float MaxRange = 250f;

            for (int i = 0; i < p1.Count; i++)
            {
                float fx = 0;
                float fy = 0;

                Particle a = p1[i];
                Particle particle2;
                for (int j = 0; j < p2.Count; j++)
                {
                    particle2 = p2[j];

                    float dx = particle2.X - a.X;
                    float dy = particle2.Y - a.Y;

                    float d = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (d > MinRange && d < MaxRange)
                    {
                        float F = -g * 1f / d;
                        fx += (F * dx);
                        fy += (F * dy);
                    }
                }
                a.vx = (a.vx + fx)*0.30f;
                a.vy = (a.vy + fy)*0.30f;
                a.X -= a.vx;
                a.Y -= a.vy;

                if (a.X <= 0 || a.X >= Graphics.WIDTH) { a.vx *= -1; }
                if (a.Y <= 0 || a.Y >= Graphics.HEIGHT) { a.vy *= -1; }
            }
        }
        
        public static void BasicRepulsion(List<Particle> p1, List<Particle> p2, float g)
        {
            BasicAttraction(p1, p2, -g);
        }
    }
}
