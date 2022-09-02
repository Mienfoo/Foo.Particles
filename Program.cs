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

namespace Foo.Particles
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var form = new Form1();

                Graphics.Initialize(form);

                GorgonApplication.Run(form, Graphics.Idle);
            }
            catch (Exception ex)
            {
                ex.Catch(_ => GorgonDialogs.ErrorBox(null, ex));
            }
            finally
            {
                Graphics.Dispose();
            }
        }
    }
}