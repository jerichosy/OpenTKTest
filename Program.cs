using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameWindow())
            {
                float angle = 0.0f;

                game.Load += (sender, e) =>
                {
                    // Setup OpenGL settings, e.g., GL.ClearColor, GL.Enable...
                    GL.ClearColor(0.1f, 0.2f, 0.3f, 1.0f);
                    GL.Enable(EnableCap.DepthTest); // Enables depth testing for proper occlusion

                    // Set up a projection matrix
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.Width / (float)game.Height, 1.0f, 64.0f);
                    GL.LoadMatrix(ref perspective);
                };

                game.Resize += (sender, e) => GL.Viewport(0, 0, game.Width, game.Height);

                /*
                game.UpdateFrame += (sender, e) =>
                {
                    // Update the state for the frame.
                    angle += 1.5f; // Rotate a little each frame.
                };
                */

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();

                    // Apply transformations
                    GL.Translate(0.0f, 0.0f, -5.0f); // Move back a bit to view the cube
                    angle += 1.5f; // Adjust for desired speed
                    GL.Rotate(angle, 1.0f, 1.0f, 0.0f); // Rotate the cube
                    // GL.Rotate(angle, 0.0, 1.0, 0.0); // Rotate around the Y-axis

                    // Draw your cube here using GL.Begin, GL.Vertex3, GL.End...
                    DrawCube(); // Implement this method based on earlier discussions

                    game.SwapBuffers();
                };

                game.Run(60.0); // Run at 60 FPS
            }
        }

        static void DrawCube()
        {
            // Drawing logic here

            // Front face
            GL.Color3(1.0f, 0.0f, 0.0f); // Red
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.End();

            // Back face
            GL.Color3(0.0f, 1.0f, 0.0f); // Green
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.End();

            // Top face
            GL.Color3(0.0f, 0.0f, 1.0f); // Blue
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.End();

            // Bottom face
            GL.Color3(1.0f, 1.0f, 0.0f); // Yellow
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.End();

            // Right face
            GL.Color3(1.0f, 0.0f, 1.0f); // Magenta
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.End();

            // Left face
            GL.Color3(0.0f, 1.0f, 1.0f); // Cyan
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.End();
        }
    }
}
