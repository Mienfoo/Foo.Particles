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
            Create(200, "Red", DX.Color.DarkRed);
            Create(400, "Blue", DX.Color.DarkBlue);
            Create(800, "Orange", DX.Color.DarkOrange);
        }

        public static void Update()
        {
            PhysicsRules.BasicAttraction(ParticleTypes["Red"], ParticleTypes["Red"], 0.6f);
            PhysicsRules.BasicRepulsion(ParticleTypes["Red"], ParticleTypes["Blue"], 0.005f);

            PhysicsRules.BasicRepulsion(ParticleTypes["Blue"], ParticleTypes["Blue"], 0.3f);
            PhysicsRules.BasicAttraction(ParticleTypes["Blue"], ParticleTypes["Orange"], 0.005f);

            PhysicsRules.BasicRepulsion(ParticleTypes["Orange"], ParticleTypes["Orange"], 0.2f);
            PhysicsRules.BasicAttraction(ParticleTypes["Orange"], ParticleTypes["Red"], 0.005f);
        }
    }
}
