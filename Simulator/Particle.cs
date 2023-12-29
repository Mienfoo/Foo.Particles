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
        public DX.Color _color;
              
        public float _x;
        public float _y;
        public float vy = 0f;
        public float vx = 0f;

        public float Radius { get; private set; }

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
        //internal float X { get { return _x; } set { _x = value; } }
        //internal float Y { get { return _y; } set { _y = value; } }

        public Particle(int x, int y, DX.Color color, float radius = 4f)
        {
            X = x;
            Y = y;
            _color = color;
            Radius = radius;
        }
    }
}
