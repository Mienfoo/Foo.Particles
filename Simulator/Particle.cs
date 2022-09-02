using System.Numerics;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX = SharpDX;
using Gorgon.Core;
using Gorgon.Graphics;
using Gorgon.Graphics.Core;
using Gorgon.Graphics.Imaging.Codecs;
using Gorgon.Renderers;
using Gorgon.UI;
using Gorgon.Timing;


namespace Foo.Particles.Simulator
{
    internal class Particle
    {
        public GorgonTriangleVertex p1;
        public GorgonTriangleVertex p2;
        public GorgonTriangleVertex p3;
              
        public float _x;
        public float _y;
        public float vy = 0f;
        public float vx = 0f;

        internal float X
        {
            get { return _x; }
            set
            {
                if (value >= Graphics.WIDTH || value < 0) { return; }
                _x = value;
            }
        }
        internal float Y
        {
            get { return _y; }
            set
            {
                if (value >= Graphics.HEIGHT || value < 0) { return; }
                _y = value;
            }
        }

        public Particle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void UpdatePos()
        {
            p1 = new GorgonTriangleVertex(new Vector2(_x, _y), DX.Color.DarkRed);
            p2 = new GorgonTriangleVertex(new Vector2(_x + 6, _y), DX.Color.DarkRed);
            p3 = new GorgonTriangleVertex(new Vector2(_x + 3, _y + 5), DX.Color.DarkRed);
        }
    }
}
