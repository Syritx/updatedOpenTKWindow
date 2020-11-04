using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

using OpenTK.Graphics.OpenGL;

namespace testappl
{
    class Program {

        static void Main(string[] args) {

            GameWindowSettings gameWindowSettings = new GameWindowSettings();
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1000, 720),
                Title = "Hello",
                APIVersion = new Version(3, 2),
                Flags = ContextFlags.ForwardCompatible,
                Profile = ContextProfile.Core,
                StartVisible = true,
                StartFocused = true
            };

            new MainWindow(gameWindowSettings, nativeWindowSettings);
        }
    }

    class MainWindow : GameWindow
    {
        NativeWindowSettings nativeWindowSettings;
        public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :
            base(gameWindowSettings, nativeWindowSettings) {

            this.nativeWindowSettings = nativeWindowSettings;
            Run();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            int width = nativeWindowSettings.Size.X;
            int height = nativeWindowSettings.Size.Y;

            Console.WriteLine(width + " " + height);

            GL.Viewport(0, 0, width, height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 perspectiveMatrix =
                Matrix4.CreatePerspectiveFieldOfView(1, width / height, 1.0f, 2000.0f);

            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.End();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0, 0, 0, 0);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
