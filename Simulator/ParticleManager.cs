using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX = SharpDX;

namespace Foo.Particles.Simulator
{
    static class ParticleManager
    {
        public static Dictionary<string, List<Particle>> ParticleTypes = new();
        public static List<Particle> Particles = new();
        public static Random rnd = new Random();

        public static void Create(int num, string key, DX.Color color)
        {
            var particles = new List<Particle>();
            for (int i = 0; i < num; i++)
            {
                var p = new Particle(rnd.Next(0, Graphics.WIDTH), rnd.Next(0, Graphics.HEIGHT), color);
                Particles.Add(p);
                particles.Add(p);
            }
            ParticleTypes.Add(key, particles);
        }

        public static void Initialize()
        {
            Create(300, "Red", DX.Color.DarkRed);
            Create(300, "Blue", DX.Color.DarkBlue);
        }

        public static void Update()
        {
            PhysicsRules.BasicRepulsion(ParticleTypes["Blue"], ParticleTypes["Red"]);
            PhysicsRules.BasicAttraction(ParticleTypes["Blue"], ParticleTypes["Blue"]);
            PhysicsRules.BasicAttraction(ParticleTypes["Red"], ParticleTypes["Red"]);
            

            foreach (var particle in Particles)
            {
                particle.UpdatePos();
            }
        }
    }
}
