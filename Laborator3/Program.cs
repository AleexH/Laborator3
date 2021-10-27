using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;
using System.Drawing;

namespace Laborator2
{
    class SimpleWindow : GameWindow
    {
        double r=0, g=0, b=0, a=0;
        Random rand = new Random();
        float size = 0.1f;
        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

            if (e.Key == Key.W)
                size += 0.1f;
            if (e.Key == Key.S)
                size -= 0.1f;
            if (e.Key == Key.R)
                r = rand.NextDouble();
            if (e.Key == Key.G)
                g = rand.NextDouble();
            if (e.Key == Key.B)
                b = rand.NextDouble();
            if (e.Key == Key.A)
                a = rand.NextDouble();

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color4(r, g, b, a);
            GL.Vertex2(size, size);
            GL.Color4(r, g, b, a);
            GL.Vertex2(size, -size);
            GL.Color4(r, g, b, a);
            GL.Vertex2(-size, -size);
            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
