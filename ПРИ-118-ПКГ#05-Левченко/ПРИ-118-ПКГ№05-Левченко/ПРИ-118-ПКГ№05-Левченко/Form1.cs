using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// для работы с библиотекой OpenGL
using Tao.OpenGl;
using Tao.FreeGlut;
// для работы с библиотекой FreeGLUT

namespace ПРИ_118_ПКГ_05_Левченко
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Height / (float)AnT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(18.5, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(13.2, 16);

            Gl.glEnd();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();

            Gl.glLineWidth(1);

            // л
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(1, 1);
            Gl.glVertex2d(2, 6);
            Gl.glVertex2d(4, 6);
            Gl.glVertex2d(5, 1);
            Gl.glVertex2d(4, 1);
            Gl.glVertex2d(3, 5);
            Gl.glVertex2d(2, 1);
            Gl.glVertex2d(1, 1);
            Gl.glEnd();

            //е
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(6, 1);
            Gl.glVertex2d(6, 6);
            Gl.glVertex2d(9, 6);
            Gl.glVertex2d(9, 5);
            Gl.glVertex2d(7, 5);
            Gl.glVertex2d(7, 4);
            Gl.glVertex2d(9, 4);
            Gl.glVertex2d(9, 3);
            Gl.glVertex2d(7, 3);
            Gl.glVertex2d(7, 2);
            Gl.glVertex2d(9, 2);
            Gl.glVertex2d(9, 1);
            Gl.glVertex2d(6, 1);
            Gl.glEnd();

            //в
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(10, 1);
            Gl.glVertex2d(10, 6);
            Gl.glVertex2d(13, 6);
            Gl.glVertex2d(13, 4);
            Gl.glVertex2d(11, 4);
            Gl.glVertex2d(11, 3);
            Gl.glVertex2d(13, 3);
            Gl.glVertex2d(13, 1);
            Gl.glVertex2d(10, 1);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(11, 4.5);
            Gl.glVertex2d(11, 5.5);
            Gl.glVertex2d(12.5, 5.5);
            Gl.glVertex2d(12.5, 4.5);
            Gl.glVertex2d(11, 4.5);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(11, 1.5);
            Gl.glVertex2d(11, 2.5);
            Gl.glVertex2d(12.5, 2.5);
            Gl.glVertex2d(12.5, 1.5);
            Gl.glVertex2d(11, 1.5);
            Gl.glEnd();

            //ч
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(16, 1);
            Gl.glVertex2d(17, 1);
            Gl.glVertex2d(17, 6);
            Gl.glVertex2d(16, 6);
            Gl.glVertex2d(16, 5);
            Gl.glVertex2d(15, 5);
            Gl.glVertex2d(15, 6);
            Gl.glVertex2d(14, 6);
            Gl.glVertex2d(14, 4);
            Gl.glVertex2d(16, 4);
            Gl.glVertex2d(16, 1);
            Gl.glEnd();

            //е
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(19, 1);
            Gl.glVertex2d(19, 6);
            Gl.glVertex2d(22, 6);
            Gl.glVertex2d(22, 5);
            Gl.glVertex2d(20, 5);
            Gl.glVertex2d(20, 4);
            Gl.glVertex2d(22, 4);
            Gl.glVertex2d(22, 3);
            Gl.glVertex2d(20, 3);
            Gl.glVertex2d(20, 2);
            Gl.glVertex2d(22, 2);
            Gl.glVertex2d(22, 1);
            Gl.glVertex2d(19, 1);
            Gl.glEnd();

            //н
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(23, 1);
            Gl.glVertex2d(23, 6);
            Gl.glVertex2d(24, 6);
            Gl.glVertex2d(24, 4);
            Gl.glVertex2d(26, 4);
            Gl.glVertex2d(26, 6);
            Gl.glVertex2d(27, 6);
            Gl.glVertex2d(27, 1);
            Gl.glVertex2d(26, 1);
            Gl.glVertex2d(26, 3);
            Gl.glVertex2d(24, 3);
            Gl.glVertex2d(24, 1);
            Gl.glVertex2d(23, 1);
            Gl.glEnd();

            //к
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(28, 1);
            Gl.glVertex2d(28, 6);
            Gl.glVertex2d(29, 6);
            Gl.glVertex2d(29, 4);
            Gl.glVertex2d(30, 6);
            Gl.glVertex2d(31, 6);
            Gl.glVertex2d(30, 3.5);
            Gl.glVertex2d(31, 1);
            Gl.glVertex2d(30, 1);
            Gl.glVertex2d(29, 3);
            Gl.glVertex2d(29, 1);
            Gl.glVertex2d(28, 1);
            Gl.glEnd();

            //о
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(34, 1);
            Gl.glVertex2d(33, 2);
            Gl.glVertex2d(33, 4);
            Gl.glVertex2d(34, 6);
            Gl.glVertex2d(35, 6);
            Gl.glVertex2d(36, 4);
            Gl.glVertex2d(36, 2);
            Gl.glVertex2d(35, 1);
            Gl.glVertex2d(34, 1);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(34, 2);
            Gl.glVertex2d(33.5, 3.5);
            Gl.glVertex2d(34, 4.5);
            Gl.glVertex2d(35, 4.5);
            Gl.glVertex2d(35.5, 3.5);
            Gl.glVertex2d(35, 2);
            Gl.glVertex2d(34, 2);
            Gl.glEnd();

            //в
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(38, 1);
            Gl.glVertex2d(38, 6);
            Gl.glVertex2d(41, 6);
            Gl.glVertex2d(41, 4);
            Gl.glVertex2d(39, 4);
            Gl.glVertex2d(39, 3);
            Gl.glVertex2d(41, 3);
            Gl.glVertex2d(41, 1);
            Gl.glVertex2d(38, 1);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(39, 4.5);
            Gl.glVertex2d(39, 5.5);
            Gl.glVertex2d(40.5, 5.5);
            Gl.glVertex2d(40.5, 4.5);
            Gl.glVertex2d(39, 4.5);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(39, 1.5);
            Gl.glVertex2d(39, 2.5);
            Gl.glVertex2d(40, 2.5);
            Gl.glVertex2d(40, 1.5);
            Gl.glVertex2d(39, 1.5);
            Gl.glEnd();

            //п
            Gl.glColor3f(0, 0, 255);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(42, 1);
            Gl.glVertex2d(42, 6);
            Gl.glVertex2d(45, 6);
            Gl.glVertex2d(45, 1);
            Gl.glVertex2d(44, 1);
            Gl.glVertex2d(44, 5);
            Gl.glVertex2d(43, 5);
            Gl.glVertex2d(43, 1);
            Gl.glVertex2d(42, 1);
            Gl.glEnd();

            AnT.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.Show();
        }
    }
}
