using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПРИ_118_ПКГ_3_Левченко
{
    class Program
    {
        static void WriteString(object _Data)
        {
            System.Console.WriteLine("Название проекта:");
            string str_for_out = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            System.Console.WriteLine(str_for_out);
        }

        static double a = 0;
        static double b = 6;
        static int n = 35;

        static double[] h = new double[n + 1]; //для вычисления шага
        static double[] x = new double[n + 1]; //для вычисления x
        static double[] y = new double[n + 1]; //для вычисления y
        static object locker = new object(); //взаимоисключающая блокировка

        static void step(object _del)
        {
            double del = (double)_del;
            lock (locker)
            {

                for (int i = 0; i <= n; i++)
                {
                    h[i] = del / n;
                }
            }
        }

        static void X(object _a)
        {
            double a = (double)_a;
            lock (locker)
            {

                for (int i = 0; i <= n; i++)
                {
                    x[i] = a + i * h[i];
                }
            }
        }
        private static void Y()
        {
            lock (locker)
            {

                for (int i = 0; i <= n; i++)
                {
                    y[i] = 1 / ((Math.Exp(x[i]) - 4 * x[i] + 4) - x[i] - 1) + Math.Log(5 * Math.Tan(x[i])) - Math.Exp(7 * Math.Sqrt(x[i])) + 0.3 * (Math.Pow(x[i], 3) + Math.Exp(x[i]) - 1);
                }
            }
        }
        static void Main(string[] args)
        {


            //создаём потоки, в качестве параметров передаём имя выполняемой функции
            Thread th_1 = new Thread(WriteString);
            Thread stepThread = new Thread(step);
            Thread xThread = new Thread(X);
            Thread yThread = new Thread(Y);


            //приоритеты 
            th_1.Priority = ThreadPriority.Highest; //название проекта- самый высокий
            stepThread.Priority = ThreadPriority.BelowNormal; //вычисление шага - выше среднего
            xThread.Priority = ThreadPriority.Normal; //вычисление х - средний
            yThread.Priority = ThreadPriority.Lowest; //результат - низкий


            
            //запускаем каждый поток
            th_1.Start();
            stepThread.Start(b - a);
            xThread.Start(a);
            yThread.Start();

            th_1.Join();
            stepThread.Join();
            xThread.Join();
            yThread.Join();
            for (int i = 0; i <= n; i++)

                Console.WriteLine($"Y[{i}] = {y[i]}");

            Console.ReadKey();
        }

    }
}
