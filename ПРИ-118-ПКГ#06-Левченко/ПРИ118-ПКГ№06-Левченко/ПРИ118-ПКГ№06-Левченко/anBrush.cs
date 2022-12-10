using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ПРИ118_ПКГ_06_Левченко
{
    class anBrush
    {
        public Bitmap myBrush;
        private bool IsErase = false;

        public anBrush(int Value, bool Special)
        {
            if (!Special)
            {
                myBrush = new Bitmap(Value, Value);

                for (int ax = 0; ax < Value; ax++)
                    for (int bx = 0; bx < Value; bx++)
                        myBrush.SetPixel(0, 0, Color.Black);

                IsErase = false;
            }
            else
            {
                switch (Value)
                {
                    default:
                        {
                            myBrush = new Bitmap(100, 100);

                            for (int ax = 0; ax < 100; ax++)
                                for (int bx = 0; bx < 100; bx++)
                                    myBrush.SetPixel(ax, bx, Color.Red);
                            ////П
                            //myBrush.SetPixel(0, 16, Color.Black);
                            //myBrush.SetPixel(0, 15, Color.Black);
                            //myBrush.SetPixel(0, 14, Color.Black);
                            //myBrush.SetPixel(0, 13, Color.Black);
                            //myBrush.SetPixel(0, 12, Color.Black);
                            //myBrush.SetPixel(0, 11, Color.Black);
                            //myBrush.SetPixel(0, 10, Color.Black);
                            //myBrush.SetPixel(0, 9, Color.Black);
                            //myBrush.SetPixel(0, 8, Color.Black);
                            //myBrush.SetPixel(0, 7, Color.Black);
                            //myBrush.SetPixel(0, 6, Color.Black);
                            //myBrush.SetPixel(0, 5, Color.Black);
                            //myBrush.SetPixel(0, 4, Color.Black);
                            //myBrush.SetPixel(0, 3, Color.Black);
                            //myBrush.SetPixel(0, 2, Color.Black);
                            //myBrush.SetPixel(0, 1, Color.Black);
                            //myBrush.SetPixel(1, 16, Color.Black);
                            //myBrush.SetPixel(2, 16, Color.Black);
                            //myBrush.SetPixel(3, 16, Color.Black);
                            //myBrush.SetPixel(4, 16, Color.Black);
                            //myBrush.SetPixel(5, 16, Color.Black);
                            //myBrush.SetPixel(6, 16, Color.Black);
                            //myBrush.SetPixel(6, 1, Color.Black);
                            //myBrush.SetPixel(6, 2, Color.Black);
                            //myBrush.SetPixel(6, 3, Color.Black);
                            //myBrush.SetPixel(6, 4, Color.Black);
                            //myBrush.SetPixel(6, 5, Color.Black);
                            //myBrush.SetPixel(6, 6, Color.Black);
                            //myBrush.SetPixel(6, 7, Color.Black);
                            //myBrush.SetPixel(6, 8, Color.Black);
                            //myBrush.SetPixel(6, 9, Color.Black);
                            //myBrush.SetPixel(6, 10, Color.Black);
                            //myBrush.SetPixel(6, 11, Color.Black);
                            //myBrush.SetPixel(6, 12, Color.Black);
                            //myBrush.SetPixel(6, 13, Color.Black);
                            //myBrush.SetPixel(6, 14, Color.Black);
                            //myBrush.SetPixel(6, 15, Color.Black);
                            //myBrush.SetPixel(6, 16, Color.Black);

                            ////Р

                            //myBrush.SetPixel(10, 16, Color.Black);
                            //myBrush.SetPixel(11, 16, Color.Black);
                            //myBrush.SetPixel(12, 16, Color.Black);
                            //myBrush.SetPixel(13, 16, Color.Black);
                            //myBrush.SetPixel(14, 16, Color.Black);
                            //myBrush.SetPixel(15, 16, Color.Black);
                            //myBrush.SetPixel(16, 16, Color.Black);
                            //myBrush.SetPixel(10, 8, Color.Black);
                            //myBrush.SetPixel(10, 1, Color.Black);
                            //myBrush.SetPixel(10, 2, Color.Black);
                            //myBrush.SetPixel(10, 3, Color.Black);
                            //myBrush.SetPixel(10, 4, Color.Black);
                            //myBrush.SetPixel(10, 5, Color.Black);
                            //myBrush.SetPixel(10, 6, Color.Black);
                            //myBrush.SetPixel(10, 7, Color.Black);
                            //myBrush.SetPixel(10, 8, Color.Black);
                            //myBrush.SetPixel(10, 9, Color.Black);
                            //myBrush.SetPixel(10, 10, Color.Black);
                            //myBrush.SetPixel(10, 11, Color.Black);
                            //myBrush.SetPixel(10, 12, Color.Black);
                            //myBrush.SetPixel(10, 13, Color.Black);
                            //myBrush.SetPixel(10, 14, Color.Black);
                            //myBrush.SetPixel(10, 15, Color.Black);
                            //myBrush.SetPixel(10, 16, Color.Black);
                            //myBrush.SetPixel(10, 10, Color.Black);
                            //myBrush.SetPixel(11, 10, Color.Black);
                            //myBrush.SetPixel(12, 10, Color.Black);
                            //myBrush.SetPixel(13, 10, Color.Black);
                            //myBrush.SetPixel(14, 10, Color.Black);
                            //myBrush.SetPixel(15, 10, Color.Black);
                            //myBrush.SetPixel(16, 10, Color.Black);
                            //myBrush.SetPixel(16, 16, Color.Black);
                            //myBrush.SetPixel(16, 15, Color.Black);
                            //myBrush.SetPixel(16, 14, Color.Black);
                            //myBrush.SetPixel(16, 13, Color.Black);
                            //myBrush.SetPixel(16, 12, Color.Black);
                            //myBrush.SetPixel(16, 11, Color.Black);
                            //myBrush.SetPixel(16, 10, Color.Black);

                            ////И
                            //myBrush.SetPixel(10, 1, Color.Black);
                            //myBrush.SetPixel(19, 2, Color.Black);
                            //myBrush.SetPixel(19, 3, Color.Black);
                            //myBrush.SetPixel(19, 4, Color.Black);
                            //myBrush.SetPixel(19, 5, Color.Black);
                            //myBrush.SetPixel(19, 6, Color.Black);
                            //myBrush.SetPixel(19, 7, Color.Black);
                            //myBrush.SetPixel(19, 8, Color.Black);
                            //myBrush.SetPixel(19, 9, Color.Black);
                            //myBrush.SetPixel(19, 10, Color.Black);
                            //myBrush.SetPixel(19, 11, Color.Black);
                            //myBrush.SetPixel(19, 12, Color.Black);
                            //myBrush.SetPixel(19, 13, Color.Black);
                            //myBrush.SetPixel(19, 14, Color.Black);
                            //myBrush.SetPixel(19, 15, Color.Black);
                            //myBrush.SetPixel(19, 16, Color.Black);
                            //myBrush.SetPixel(19, 1, Color.Black);
                            //myBrush.SetPixel(20, 2, Color.Black);
                            //myBrush.SetPixel(21, 3, Color.Black);
                            //myBrush.SetPixel(22, 3, Color.Black);
                            //myBrush.SetPixel(23, 5, Color.Black);
                            //myBrush.SetPixel(24, 6, Color.Black);
                            //myBrush.SetPixel(25, 7, Color.Black);
                            //myBrush.SetPixel(26, 8, Color.Black);
                            //myBrush.SetPixel(27, 9, Color.Black);
                            //myBrush.SetPixel(28, 10, Color.Black);
                            //myBrush.SetPixel(29, 11, Color.Black);
                            //myBrush.SetPixel(30, 12, Color.Black);
                            //myBrush.SetPixel(31, 13, Color.Black);
                            //myBrush.SetPixel(32, 14, Color.Black);
                            //myBrush.SetPixel(33, 15, Color.Black);
                            //myBrush.SetPixel(34, 16, Color.Black);
                            //myBrush.SetPixel(34, 16, Color.Black);
                            //myBrush.SetPixel(34, 15, Color.Black);
                            //myBrush.SetPixel(34, 14, Color.Black);
                            //myBrush.SetPixel(34, 13, Color.Black);
                            //myBrush.SetPixel(34, 12, Color.Black);
                            //myBrush.SetPixel(34, 11, Color.Black);
                            //myBrush.SetPixel(34, 10, Color.Black);
                            //myBrush.SetPixel(34, 9, Color.Black);
                            //myBrush.SetPixel(34, 8, Color.Black);
                            //myBrush.SetPixel(34, 7, Color.Black);
                            //myBrush.SetPixel(34, 6, Color.Black);
                            //myBrush.SetPixel(34, 5, Color.Black);
                            //myBrush.SetPixel(34, 4, Color.Black);
                            //myBrush.SetPixel(34, 3, Color.Black);
                            //myBrush.SetPixel(34, 2, Color.Black);
                            //myBrush.SetPixel(34, 1, Color.Black);

                            ////-
                            //myBrush.SetPixel(36, 8, Color.Black);
                            //myBrush.SetPixel(37, 8, Color.Black);
                            //myBrush.SetPixel(38, 8, Color.Black);
                            //myBrush.SetPixel(39, 8, Color.Black);
                            //myBrush.SetPixel(40, 8, Color.Black);
                            //myBrush.SetPixel(41, 8, Color.Black);
                            //myBrush.SetPixel(42, 8, Color.Black);
                            //myBrush.SetPixel(43, 8, Color.Black);
                            //myBrush.SetPixel(44, 8, Color.Black);
                            //myBrush.SetPixel(45, 8, Color.Black);

                            ////1 1
                            //myBrush.SetPixel(48, 1, Color.Black);
                            //myBrush.SetPixel(48, 2, Color.Black);
                            //myBrush.SetPixel(48, 3, Color.Black);
                            //myBrush.SetPixel(48, 4, Color.Black);
                            //myBrush.SetPixel(48, 5, Color.Black);
                            //myBrush.SetPixel(48, 6, Color.Black);
                            //myBrush.SetPixel(48, 7, Color.Black);
                            //myBrush.SetPixel(48, 8, Color.Black);
                            //myBrush.SetPixel(48, 9, Color.Black);
                            //myBrush.SetPixel(48, 10, Color.Black);
                            //myBrush.SetPixel(48, 11, Color.Black);
                            //myBrush.SetPixel(48, 12, Color.Black);
                            //myBrush.SetPixel(48, 13, Color.Black);
                            //myBrush.SetPixel(48, 14, Color.Black);
                            //myBrush.SetPixel(48, 15, Color.Black);
                            //myBrush.SetPixel(48, 16, Color.Black);

                            //myBrush.SetPixel(52, 1, Color.Black);
                            //myBrush.SetPixel(52, 2, Color.Black);
                            //myBrush.SetPixel(52, 3, Color.Black);
                            //myBrush.SetPixel(52, 4, Color.Black);
                            //myBrush.SetPixel(52, 5, Color.Black);
                            //myBrush.SetPixel(52, 6, Color.Black);
                            //myBrush.SetPixel(52, 7, Color.Black);
                            //myBrush.SetPixel(52, 8, Color.Black);
                            //myBrush.SetPixel(52, 9, Color.Black);
                            //myBrush.SetPixel(52, 10, Color.Black);
                            //myBrush.SetPixel(52, 11, Color.Black);
                            //myBrush.SetPixel(52, 12, Color.Black);
                            //myBrush.SetPixel(52, 13, Color.Black);
                            //myBrush.SetPixel(52, 14, Color.Black);
                            //myBrush.SetPixel(52, 15, Color.Black);
                            //myBrush.SetPixel(52, 16, Color.Black);
                            //// 8
                            //myBrush.SetPixel(56, 1, Color.Black);
                            //myBrush.SetPixel(56, 2, Color.Black);
                            //myBrush.SetPixel(56, 3, Color.Black);
                            //myBrush.SetPixel(56, 4, Color.Black);
                            //myBrush.SetPixel(56, 5, Color.Black);
                            //myBrush.SetPixel(56, 6, Color.Black);
                            //myBrush.SetPixel(56, 7, Color.Black);
                            //myBrush.SetPixel(56, 8, Color.Black);
                            //myBrush.SetPixel(56, 9, Color.Black);
                            //myBrush.SetPixel(56, 10, Color.Black);
                            //myBrush.SetPixel(56, 11, Color.Black);
                            //myBrush.SetPixel(56, 12, Color.Black);
                            //myBrush.SetPixel(56, 13, Color.Black);
                            //myBrush.SetPixel(56, 14, Color.Black);
                            //myBrush.SetPixel(56, 15, Color.Black);
                            //myBrush.SetPixel(56, 16, Color.Black);

                            //myBrush.SetPixel(64, 1, Color.Black);
                            //myBrush.SetPixel(64, 2, Color.Black);
                            //myBrush.SetPixel(64, 3, Color.Black);
                            //myBrush.SetPixel(64, 4, Color.Black);
                            //myBrush.SetPixel(64, 5, Color.Black);
                            //myBrush.SetPixel(64, 6, Color.Black);
                            //myBrush.SetPixel(64, 7, Color.Black);
                            //myBrush.SetPixel(64, 8, Color.Black);
                            //myBrush.SetPixel(64, 9, Color.Black);
                            //myBrush.SetPixel(64, 10, Color.Black);
                            //myBrush.SetPixel(64, 11, Color.Black);
                            //myBrush.SetPixel(64, 12, Color.Black);
                            //myBrush.SetPixel(64, 13, Color.Black);
                            //myBrush.SetPixel(64, 14, Color.Black);
                            //myBrush.SetPixel(64, 15, Color.Black);
                            //myBrush.SetPixel(64, 16, Color.Black);

                            //myBrush.SetPixel(56, 16, Color.Black);
                            //myBrush.SetPixel(57, 16, Color.Black);
                            //myBrush.SetPixel(58, 16, Color.Black);
                            //myBrush.SetPixel(59, 16, Color.Black);
                            //myBrush.SetPixel(60, 16, Color.Black);
                            //myBrush.SetPixel(61, 16, Color.Black);
                            //myBrush.SetPixel(62, 16, Color.Black);
                            //myBrush.SetPixel(63, 16, Color.Black);
                            //myBrush.SetPixel(64, 16, Color.Black);

                            //myBrush.SetPixel(56, 8, Color.Black);
                            //myBrush.SetPixel(57, 8, Color.Black);
                            //myBrush.SetPixel(58, 8, Color.Black);
                            //myBrush.SetPixel(59, 8, Color.Black);
                            //myBrush.SetPixel(60, 8, Color.Black);
                            //myBrush.SetPixel(61, 8, Color.Black);
                            //myBrush.SetPixel(62, 8, Color.Black);
                            //myBrush.SetPixel(63, 8, Color.Black);
                            //myBrush.SetPixel(64, 8, Color.Black);

                            //myBrush.SetPixel(56, 1, Color.Black);
                            //myBrush.SetPixel(57, 1, Color.Black);
                            //myBrush.SetPixel(58, 1, Color.Black);
                            //myBrush.SetPixel(59, 1, Color.Black);
                            //myBrush.SetPixel(60, 1, Color.Black);
                            //myBrush.SetPixel(61, 1, Color.Black);
                            //myBrush.SetPixel(62, 1, Color.Black);
                            //myBrush.SetPixel(63, 1, Color.Black);
                            //myBrush.SetPixel(64, 1, Color.Black);


                            //IsErase = false;

                            //break;

                            myBrush = new Bitmap(5, 5);

                            for (int ax = 0; ax < 5; ax++)
                                for (int bx = 0; bx < 5; bx++)
                                    myBrush.SetPixel(ax, bx, Color.Red);

                            myBrush.SetPixel(0, 2, Color.Black);
                            myBrush.SetPixel(1, 2, Color.Black);

                            myBrush.SetPixel(2, 0, Color.Black);
                            myBrush.SetPixel(2, 1, Color.Black);
                            myBrush.SetPixel(2, 2, Color.Black);
                            myBrush.SetPixel(2, 3, Color.Black);
                            myBrush.SetPixel(2, 4, Color.Black);

                            myBrush.SetPixel(3, 2, Color.Black);
                            myBrush.SetPixel(4, 2, Color.Black);

                            break;
                        }
                    case 1:
                        {
                            myBrush = new Bitmap(5, 5);

                            for (int ax = 0; ax < Value; ax++)
                                for (int bx = 0; bx < Value; bx++)
                                    myBrush.SetPixel(0, 0, Color.Black);

                            IsErase = true;
                            break;
                        }

                
                }
            }
        }

        public anBrush(string FromFile)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\" + FromFile;

            myBrush = new Bitmap(path);
        }

        public bool IsBrushErase()
        {
            return IsErase;
        }
    }
}
