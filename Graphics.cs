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

        /*public static int WIDTH = 2200; 
        public static int HEIGHT = 1200;*/
        public static int WIDTH = 1280;
        public static int HEIGHT = 720;
        public static int TARGET_FPS = 90;

        private static Stopwatch stopwatch;

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

            stopwatch = new Stopwatch();
            stopwatch.Start();
            ParticleManager.Initialize();
        }

        public static bool Idle()
        {
            int millisecondsPerFrame = 1000 / TARGET_FPS;

            ParticleManager.Update();

            _screen.RenderTargetView.Clear(GorgonColor.Black);
            _graphics.SetRenderTarget(_screen.RenderTargetView);
            _renderer.Begin();

            foreach (var particle in ParticleManager.Particles)
            {
                _renderer.DrawFilledEllipse(new DX.RectangleF(particle.X, particle.Y, 4, 4), particle._color, 2);
            }

            _renderer.End();
            _screen.Present(3);

            int elapsedMilliseconds = (int)stopwatch.ElapsedMilliseconds;
            int sleepTime = millisecondsPerFrame - elapsedMilliseconds;

            if (sleepTime > 0)
            {   
                Thread.Sleep(sleepTime);
            }

            stopwatch.Restart();

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
