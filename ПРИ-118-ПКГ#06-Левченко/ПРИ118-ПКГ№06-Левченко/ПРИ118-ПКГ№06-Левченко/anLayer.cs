using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tao.OpenGl;

namespace ПРИ118_ПКГ_06_Левченко
{
    class anLayer
    {
        public int Width, Heigth;
        private int[,,] DrawPlace;
        private bool isVisible;
        private Color ActiveColor;
        private int ListNom;

        public int[,,] GetDrawingPlace()
        {
            return DrawPlace;
        }

        public anLayer(int s_W, int s_H)
        {
            Width = s_W;
            Heigth = s_H;

            DrawPlace = new int[Width, Heigth, 4];

            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
                    DrawPlace[ax, bx, 3] = 1;
                }
            }

            isVisible = true;

            ActiveColor = Color.Black;
        }

        public void SetVisibility(bool visiblityState)
        {
            isVisible = visiblityState;
        }

        public bool GetVisibility()
        {
            return isVisible;
        }

        public void Draw(anBrush BR, int x, int y)
        {

            int real_pos_draw_start_x = x - BR.myBrush.Width / 2;
            int real_pos_draw_start_y = y - BR.myBrush.Height / 2;

            if (real_pos_draw_start_x < 0)
                real_pos_draw_start_x = 0;

            if (real_pos_draw_start_y < 0)
                real_pos_draw_start_y = 0;

            int boundary_x = real_pos_draw_start_x + BR.myBrush.Width;
            int boundary_y = real_pos_draw_start_y + BR.myBrush.Height;


            if (boundary_x > Width)
                boundary_x = Width;

            if (boundary_y > Heigth)
                boundary_y = Heigth;

            int count_x = 0, count_y = 0;

            for (int ax = real_pos_draw_start_x; ax < boundary_x; ax++, count_x++)
            {
                count_y = 0;
                for (int bx = real_pos_draw_start_y; bx < boundary_y; bx++, count_y++)
                {
                    if (BR.IsBrushErase())
                    {
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);

                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                            DrawPlace[ax, bx, 3] = 1;
                        }
                    }
                    else
                    {
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);

                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                            DrawPlace[ax, bx, 0] = ActiveColor.R;
                            DrawPlace[ax, bx, 1] = ActiveColor.G;
                            DrawPlace[ax, bx, 2] = ActiveColor.B;
                            DrawPlace[ax, bx, 3] = 0;
                        }
                    }
                }
            }
        }

        public void RenderImage()
        {
            Gl.glBegin(Gl.GL_POINTS);

            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
                    if (DrawPlace[ax, bx, 3] != 1)
                    {
                        Gl.glColor3f(DrawPlace[ax, bx, 0], DrawPlace[ax, bx, 1], DrawPlace[ax, bx, 2]);
                        Gl.glVertex2i(ax, bx);
                    }
                }
            }

            Gl.glEnd();
        }

        public void SetColor(Color NewColor)
        {
            ActiveColor = NewColor;
        }

        public Color GetColor()
        {
            return ActiveColor;
        }

        public void ClearList()
        {
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
                Gl.glDeleteLists(ListNom, 1);
            }
        }

        public void CreateNewList()
        {
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
                Gl.glDeleteLists(ListNom, 1);
                ListNom = Gl.glGenLists(1);
            }
            Gl.glNewList(ListNom, Gl.GL_COMPILE);
            RenderImage(false);
            Gl.glEndList();
        }


        public void Invers()
        {
            for (int Y = 0; Y < Heigth; Y++)
            {
                for (int X = 0; X < Width; X++)
                {
                    DrawPlace[X, Y, 0] = 255 - DrawPlace[X, Y, 0];
                    DrawPlace[X, Y, 1] = 255 - DrawPlace[X, Y, 1];
                    DrawPlace[X, Y, 2] = 255 - DrawPlace[X, Y, 2];
                }
            }
        }

        public void RenderImage(bool FromList)
        {
            if (FromList)
            {
                Gl.glCallList(ListNom);
            }
            else
            {
                int count = 0;
                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Heigth; bx++)
                    {
                        if (DrawPlace[ax, bx, 3] != 1)
                        {
                            count++;
                        }
                    }
                }

                int[] arr_date_vertex = new int[count * 2];

                float[] arr_date_colors = new float[count * 3];

                int now_element = 0;

                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Heigth; bx++)
                    {

                        if (DrawPlace[ax, bx, 3] != 1)
                        {

                            arr_date_vertex[now_element * 2] = ax;
                            arr_date_vertex[now_element * 2 + 1] = bx;

                            arr_date_colors[now_element * 3] = (float)DrawPlace[ax, bx, 0] / 255.0f;
                            arr_date_colors[now_element * 3 + 1] = (float)DrawPlace[ax, bx, 1] / 255.0f;
                            arr_date_colors[now_element * 3 + 2] = (float)DrawPlace[ax, bx, 2] / 255.0f;

                            now_element++;
                        }
                    }
                }

                Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

                Gl.glColorPointer(3, Gl.GL_FLOAT, 0, arr_date_colors);
                Gl.glVertexPointer(2, Gl.GL_INT, 0, arr_date_vertex);

                Gl.glDrawArrays(Gl.GL_POINTS, 0, count);

                Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
            }
        }

        public void PixelTransformation(float[] mat, int corr, float COEFF, bool need_count_correction)
        {
            // массив для получения результирующего пикселя
            float[] resault_RGB = new float[3];
            int count = 0;
            // проходим циклом по всем пикселям слоя
            for (int Y = 0; Y < Heigth; Y++)
            {
                for (int X = 0; X < Width; X++)
                {
                    // цикл по всем составляющим (0-2, т.е. R G B)
                    for (int c = 0, ax = 0, bx = 0; c < 3; c++)
                    {
                        // обнуление составляющей результата
                        resault_RGB[c] = 0;
                        // обнуление счетчика обработок
                        count = 0;

                        // два цикла для захвата области 3х3 вокруг обрабатываемого пикселя
                        for (bx = -1; bx < 2; bx++)
                        {
                            for (ax = -1; ax < 2; ax++)
                            {
                                // если мы не попали в рамки, просто используем центральный пиксель, и продолжаем цикл
                                if (X + ax < 0 || X + ax > Width - 1 || Y + bx < 0 || Y + bx > Heigth - 1)
                                {
                                    // считаем составляющую в одной из точек, используем коэфицент в матрице (под номером текущей итерации), коэфицент усиления (COEFF) и прибовляем коррекцию (corr)
                                    resault_RGB[c] += (float)(DrawPlace[X, Y, c]) * mat[count] * COEFF + corr;
                                    // счетчик обработок = ячейке матрицы с необходимым коэфицентом
                                    count++;
                                    // продолжаем цикл
                                    continue;
                                }

                                // иначе, если мы укладываемся в изображение (не пересекаем границы), используем соседние пиксели, корректируем ячейку массива параметрами ax, bx
                                resault_RGB[c] += (float)(DrawPlace[X + ax, Y + bx, c]) * mat[count] * COEFF + corr;
                                // счетчик обработок = ячейке матрицы с необходимым коэфицентом
                                count++;
                            }
                        }

                    }

                    // теперь для всех составляющих корректируем цвет
                    for (int c = 0; c < 3; c++)
                    {
                        // если требуется разделить результат до приведения к 0-255, разделив на количество проведенных операций
                        if (count != 0 && need_count_correction)
                        {
                            // выполняем данное деление
                            resault_RGB[c] /= count;
                        }

                        // если значение меньше нуля
                        if (resault_RGB[c] < 0)
                        {
                            // - приравниваем к нулю
                            resault_RGB[c] = 0;
                        }

                        // если больше 255
                        if (resault_RGB[c] > 255)
                        {
                            // приравниваем к 255
                            resault_RGB[c] = 255;
                        }
                        // записываем в массив цветов слоя новое значение
                        DrawPlace[X, Y, c] = (int)resault_RGB[c];
                    }
                }
            }

        }

    }
}
