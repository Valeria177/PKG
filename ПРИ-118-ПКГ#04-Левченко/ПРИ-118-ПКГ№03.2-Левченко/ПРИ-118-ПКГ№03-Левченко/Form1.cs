using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;


namespace ПРИ_118_ПКГ_03_Левченко
{
    public partial class Form1 : Form
    {
        float AngleX = 30;
        float AngleY = 30;
        float AngleZ = 0;

        const float AngleDl = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(glControl1);
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);

            glControl1.Invalidate();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0.5f, 0.5f, 0.75f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.Rotate(AngleX, 1.0, 0.0, 0.0);
            GL.Rotate(AngleY, 0.0, 1.0, 0.0);
            GL.Rotate(AngleZ, 0.0, 0.0, 1.0);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(1f, 0f, 0f); GL.Vertex3(-1f, 0f, 0f); GL.Vertex3(1f, 0f, 0f);
            GL.Color3(0f, 1f, 0f); GL.Vertex3(0f, -1f, 0f); GL.Vertex3(0f, 1f, 0f);
            GL.Color3(0f, 0f, 1f); GL.Vertex3(0f, 0f, -1f); GL.Vertex3(0f, 0f, 1f);
            GL.End();
            GL.Flush();
            GL.Finish();
            glControl1.SwapBuffers();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    AngleX += AngleDl;
                    break;
                case Keys.Delete:
                    AngleX -= AngleDl;
                    break;
                case Keys.Home:
                    AngleY += AngleDl;
                    break;
                case Keys.End:
                    AngleY -= AngleDl;
                    break;
                case Keys.Prior:
                    AngleZ += AngleDl;
                    break;
                case Keys.Next:
                    AngleZ -= AngleDl;
                    break;
            }
            glControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            this.Controls.Add(glControl1);
        }
    }
}
