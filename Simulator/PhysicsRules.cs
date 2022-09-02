using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo.Particles.Simulator
{
    static class PhysicsRules
    {
        public static void BasicAttraction(List<Particle> p1, List<Particle> p2, int g = -1)
        {
            for (int i = 0; i < p1.Count; i++)
            {
                float fx = 0;
                float fy = 0;

                Particle particle1 = p1[i];
                Particle particle2;
                for (int j = 0; j < p2.Count; j++)
                {
                    particle2 = p2[j];

                    float dx = particle2.X - particle1.X;
                    float dy = particle2.Y - particle1.Y;

                    float d = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (d > 0.9f)
                    {
                        float F = g * 1f / d;
                        fx += (F * dx);
                        fy += (F * dy);
                    }
                }
                particle1.vx = (particle1.vx + fx);
                particle1.vy = (particle1.vy + fy);
                particle1.X -= particle1.vx;
                particle1.Y -= particle1.vy;
            }
        }
    }
}
