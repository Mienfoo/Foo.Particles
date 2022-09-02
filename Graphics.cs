using System.Numerics;
using System.Diagnostics;
using DX = SharpDX;
using Gorgon.Core;
using Gorgon.Graphics;
using Gorgon.Graphics.Core;
using Gorgon.Graphics.Imaging.Codecs;
using Gorgon.Renderers;
using Gorgon.UI;
using Gorgon.Timing;
using Foo.Particles.Simulator;

namespace Foo.Particles
{
    static class Graphics
    {
        private static GorgonGraphics? _graphics;
        private static GorgonSwapChain? _screen;
        private static Gorgon2D? _renderer;

        public static int WIDTH = 1920; 
        public static int HEIGHT = 1080;

        public static void Initialize(Form form)
        {
            IReadOnlyList<IGorgonVideoAdapterInfo> videoDevices = GorgonGraphics.EnumerateAdapters();
            _graphics = new GorgonGraphics(videoDevices[0]);
            form.ClientSize = new Size(WIDTH, HEIGHT);
            _screen = new GorgonSwapChain(_graphics, form, new GorgonSwapChainInfo(form.ClientSize.Width, form.ClientSize.Height, BufferFormat.R8G8B8A8_UNorm)
            {
                Name = "meowmeow"
            });
            _renderer = new Gorgon2D(_graphics);

            ParticleManager.Initialize();
        }
        
        public static bool Idle()
        {
            ParticleManager.Update();
            _screen.RenderTargetView.Clear(GorgonColor.Black);
            _graphics.SetRenderTarget(_screen.RenderTargetView);
            _renderer.Begin();

            foreach (var particle in ParticleManager.Particles)
            {
                _renderer.DrawTriangle(particle.p1, particle.p2, particle.p3);
            }

            _renderer.End();
            _screen.Present(3);
            return true;
        }

        public static void Dispose()
        {
            _renderer?.Dispose();
            _screen?.Dispose();
            _graphics?.Dispose();
        }
    }
}
