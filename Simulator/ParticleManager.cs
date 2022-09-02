using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo.Particles.Simulator
{
    static class ParticleManager
    {
        public static List<Particle> Particles = new();
        public static Random rnd = new Random();

        public static void Initialize()
        {
            Create(2);
        }

        public static void Create(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Particles.Add(new Particle(rnd.Next(0, Graphics.WIDTH), rnd.Next(0, Graphics.HEIGHT)));
            }
        }

        public static void Update()
        {
            PhysicsRules.BasicAttraction(Particles, Particles);
            foreach (var particle in Particles)
            {
                particle.UpdatePos();
            }
        }
    }
}
