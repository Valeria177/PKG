using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ПРИ118_ПКГ_08_Левченко
{
    public partial class Form1 : Form
    {
        private float[,] DrawingArray = new float[64, 2];
        private int count_points = 0;

        double ScreenW, ScreenH;

        private float devX;
        private float devY;

        float lineX, lineY;

        float Mcoord_X = 0, Mcoord_Y = 0;

        int captured = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);


            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 500.0;
                ScreenH = 500.0 * (float)AnT.Height / (float)AnT.Width;

                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 500.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 500.0;

                Glu.gluOrtho2D(0.0, 500.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 500.0);
            }

            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            RenderTimer.Start();

            comboBox1.SelectedIndex = 0;
        }

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;

                count_points++;
            }
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;
                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                DrawingArray[count_points, 0] = lineX;
                DrawingArray[count_points, 1] = lineY;
            }
            else
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                float _lastX = lineX;
                float _lastY = lineY;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                if (captured != -1)
                {
                    DrawingArray[captured, 0] -= _lastX - lineX;
                    DrawingArray[captured, 1] -= _lastY - lineY;
                }
            }
        }

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                for (int ax = 0; ax < count_points; ax++)
                {
                    if (lineX < DrawingArray[ax, 0] + 5 && lineX > DrawingArray[ax, 0] - 5 && lineY < DrawingArray[ax, 1] + 5 && lineY > DrawingArray[ax, 1] - 5)
                    {
                        captured = ax;
                        break;
                    }
                }
            }
        }

        private void AnT_MouseUp(object sender, MouseEventArgs e)
        {
            captured = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RenderTimer.Stop();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 255);
            Gl.glLineWidth((float)1.1);

            
            //ОБОЛОЧКА
            Gl.glBegin(Gl.GL_LINE_LOOP);
            
            Gl.glVertex2d(100, 20);
            //Gl.glVertex2d(240, 20);//закругление
            //Gl.glVertex2d(280, 60);//закругление

            float[,] PointArray = new float[9, 2];
            PointArray[0, 0] = 240; PointArray[0, 1] = 20;
            PointArray[1, 0] = 245; PointArray[1, 1] = 22;
            PointArray[2, 0] = 252; PointArray[2, 1] = 24;
            PointArray[3, 0] = 258; PointArray[3, 1] = 26;
            PointArray[4, 0] = 263; PointArray[4, 1] = 30; 
            PointArray[5, 0] = 268; PointArray[5, 1] = 35;
            PointArray[6, 0] = 273; PointArray[6, 1] = 45;
            PointArray[7, 0] = 280; PointArray[7, 1] = 55;
            PointArray[8, 0] = 280; PointArray[8, 1] = 60;



            RoundOff(PointArray);

            Gl.glVertex2d(280, 260);
            Gl.glVertex2d(180, 260);
            Gl.glVertex2d(180, 280);//6
            Gl.glVertex2d(280, 280); //7
            //Gl.glVertex2d(180, 260); //
            Gl.glVertex2d(280, 400);
            Gl.glVertex2d(20, 400);
            Gl.glVertex2d(20, 280);
            Gl.glVertex2d(100, 280);
            Gl.glVertex2d(100, 260);
            Gl.glVertex2d(20, 260);
            Gl.glVertex2d(20, 180);
            Gl.glVertex2d(100, 180);
            Gl.glVertex2d(100, 160);
            Gl.glVertex2d(20, 160);
            Gl.glVertex2d(20, 100);
            Gl.glVertex2d(60, 100);
            Gl.glVertex2d(60, 80);
            Gl.glVertex2d(100, 80);
            Gl.glVertex2d(100, 20);
            Gl.glEnd();


            //круги
            Gl.glBegin(Gl.GL_LINE_LOOP);
            float[,] CircleArray = new float[7, 2];
            CircleArray[0, 0] = 60; CircleArray[0, 1] = 380;
            CircleArray[1, 0] = 20; CircleArray[1, 1] = 340;
            CircleArray[2, 0] = 60; CircleArray[2, 1] = 300;
            CircleArray[3, 0] = 100; CircleArray[3, 1] = 340;
            CircleArray[4, 0] = 60; CircleArray[4, 1] = 380;
            CircleArray[5, 0] = 20; CircleArray[5, 1] = 340;
            CircleArray[6, 0] = 60; CircleArray[6, 1] = 300;
            RoundOff(CircleArray);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);
            CircleArray = new float[7, 2];
            CircleArray[0, 0] = 240; CircleArray[0, 1] = 100;
            CircleArray[1, 0] = 200; CircleArray[1, 1] = 60;
            CircleArray[2, 0] = 240; CircleArray[2, 1] = 20;
            CircleArray[3, 0] = 280; CircleArray[3, 1] = 60;
            CircleArray[4, 0] = 240; CircleArray[4, 1] = 100;
            CircleArray[5, 0] = 200; CircleArray[5, 1] = 60;
            CircleArray[6, 0] = 240; CircleArray[6, 1] = 20;
            RoundOff(CircleArray);
            Gl.glEnd();

            AnT.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RenderTimer.Start();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            DrawingArray = new float[64, 2];
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void PrintText2D(float x, float y, string text)
        {
            Gl.glRasterPos2f(x, y);

            foreach (char char_for_draw in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, char_for_draw);
            }
        }

        private void Draw()
        {
            int N = 30;
            double X, Y;

            int eps = 4, i, j, n = count_points + 1, first;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glLoadIdentity();

            Gl.glColor3f(0, 0, 0);

            Gl.glPushMatrix();

            Gl.glPointSize(5.0f);
            Gl.glBegin(Gl.GL_POINTS);

            Gl.glVertex2d(0, 0);

            Gl.glEnd();
            Gl.glPointSize(1.0f);

            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, "[ x: " + (devX * Mcoord_X).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y).ToString() + "]");

            for (i = 0; i < n; i++)
            {
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];

                if (i == captured)
                {
                    Gl.glLineWidth(3.0f);
                }

                Gl.glBegin(Gl.GL_LINE_LOOP);

                Gl.glVertex2d(X - eps, Y - eps);
                Gl.glVertex2d(X + eps, Y - eps);
                Gl.glVertex2d(X + eps, Y + eps);
                Gl.glVertex2d(X - eps, Y + eps);

                Gl.glEnd();

                if (i == captured)
                {
                    Gl.glLineWidth(1.0f);
                }
            }

            for (i = 0; i < n; i++)
            {
                X = DrawingArray[i, 0];
                Y = DrawingArray[i, 1];

                PrintText2D((float)(X - 20), (float)(Y - 20), "P " + i.ToString() + ": " + X.ToString() + ", " + Y.ToString());
            }

            Gl.glBegin(Gl.GL_LINE_STRIP);

            for (i = 1; i < n - 1; i++)
            {
                first = 1;
                xA = DrawingArray[i - 1, 0];
                xB = DrawingArray[i, 0];
                xC = DrawingArray[i + 1, 0];
                xD = DrawingArray[i + 2, 0];

                yA = DrawingArray[i - 1, 1];
                yB = DrawingArray[i, 1];
                yC = DrawingArray[i + 1, 1];
                yD = DrawingArray[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;
                a2 = (xA - 2 * xB + xC) / 2.0;
                a1 = (xC - xA) / 2.0;
                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;
                b2 = (yA - 2 * yB + yC) / 2.0;
                b1 = (yC - yA) / 2.0;
                b0 = (yA + 4 * yB + yC) / 6.0;

                for (j = 0; j <= N; j++)
                {
                    t = (double)j / (double)N;

                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);

                    if (first == 1)
                    {
                        first = 0;
                        Gl.glVertex2d(X, Y);
                    }
                    else
                        Gl.glVertex2d(X, Y);
                }
            }
            Gl.glEnd();

            Gl.glFlush();
            AnT.Invalidate();

        }

        private void RoundOff(float[,] PointArray)
        {
            int i, j, N = 4, end = PointArray.Length / 2 - 2;
            double xA, xB, xC, xD, yA, yB, yC, yD, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;
            double X, Y;

            for (i = 1; i < end; i++)
            {
                xA = PointArray[i - 1, 0];
                xB = PointArray[i, 0];
                xC = PointArray[i + 1, 0];
                xD = PointArray[i + 2, 0];

                yA = PointArray[i - 1, 1];
                yB = PointArray[i, 1];
                yC = PointArray[i + 1, 1];
                yD = PointArray[i + 2, 1];

                a3 = (-xA + 3 * (xB - xC) + xD) / 6.0;
                a2 = (xA - 2 * xB + xC) / 2.0;
                a1 = (xC - xA) / 2.0;
                a0 = (xA + 4 * xB + xC) / 6.0;

                b3 = (-yA + 3 * (yB - yC) + yD) / 6.0;
                b2 = (yA - 2 * yB + yC) / 2.0;
                b1 = (yC - yA) / 2.0;
                b0 = (yA + 4 * yB + yC) / 6.0;

                for (j = 0; j <= end; j++)
                {
                    t = (double)j / (double)N;
                    X = (((a3 * t + a2) * t + a1) * t + a0);
                    Y = (((b3 * t + b2) * t + b1) * t + b0);
                    Gl.glVertex2d(X, Y);
                }
            }
        }
    }
}