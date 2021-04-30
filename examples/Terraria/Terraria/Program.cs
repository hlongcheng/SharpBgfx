using System;
using System.Runtime.InteropServices;
using Common;
using SharpBgfx;

namespace Terraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Terraria!");
            var sample = new Sample("Hello Terraria!", 1280, 720);
            sample.Run(RenderThread);
        }

        static void RenderThread(Sample sample) {
            Bgfx.Init();
            Bgfx.Reset(sample.WindowWidth, sample.WindowHeight, ResetFlags.Vsync);

            Bgfx.SetDebugFeatures(DebugFeatures.DisplayText);

            Bgfx.SetViewClear(0, ClearTargets.Color | ClearTargets.Depth, 0x000000ff);

            while (sample.ProcessEvents(ResetFlags.Vsync))
            {
                Bgfx.SetViewRect(0, 0, 0, sample.WindowWidth, sample.WindowHeight);

                Bgfx.Touch(0);

                Bgfx.DebugTextClear();

                //Bgfx.DebugTextImage(
                //    Math.Max(sample.WindowWidth / 2 / 8, 20) - 20,
                //    Math.Max(sample.WindowHeight / 2 / 16, 6) - 6,
                //    40, 12,
                //    Bg.Bytes, 160);

                Bgfx.DebugTextWrite(0, 1, DebugColor.White, DebugColor.Blue, "SharpBgfx/Terraria");
                Bgfx.DebugTextWrite(0, 2, DebugColor.White, DebugColor.Cyan, "Description:Terraria");


                Bgfx.Frame();
            }

            Bgfx.Shutdown();
        }
    }
}
