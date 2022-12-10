using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ПРИ_118_ПКГ_01_Левченко
{
    class Program
    {
        static void Main(string[] args)
        {
            //вывести на экран название проекта
            System.Console.WriteLine("Название проекта:");
            string projectName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            System.Console.WriteLine(projectName);

            // переменная, которая будет хранить команду пользователя
            string user_command = "";
            // бесконечный цикл
            bool Infinity = true;

            // пустой экземпляр класса Man
            Man SomeMan = null;

            while (Infinity) // пока Infinity равно true
            {
                System.Console.WriteLine("Пожалуйста, введите команду. Если вы не знаете команд, введите - help");


                user_command = System.Console.ReadLine();

                switch (user_command)
                {

                    
                    case "exit":
                        {
                            Infinity = false;
                            break;
                        }
                    case "help":
                        {

                            System.Console.WriteLine("Список команд:");
                            System.Console.WriteLine("---");

                            System.Console.WriteLine("create: команда создает человечка, (экземпляр класса Man)");
                            System.Console.WriteLine("kill: команда убивает человечка, если он существует");
                            System.Console.WriteLine("laugh: может рассмешить человечка, если он существует");
                            System.Console.WriteLine("talk: команда заставляет человечка говорить (если создан экземпляр класса)");
                            System.Console.WriteLine("go: команда заставляет человечка идти (если создан экземпляр класса)");
                            System.Console.WriteLine("---");
                            System.Console.WriteLine("---");

                            break;

                        }

                    case "create":
                        {
                            // проверяем, создан ли уже какой либо человек
                            if (SomeMan != null)
                            {
                                SomeMan.Kill();
                            }
                            //создание челоыечка
                            System.Console.WriteLine("Как будут звать этого человечка?\n");
                            user_command = System.Console.ReadLine();
                            SomeMan = new Man(user_command);
                            System.Console.WriteLine("Человек успешно создан \n");
                            break;
                        }

                    case "kill":
                        {
                            //убиваем человечка(
                            //но мы его потом опять создадим))))))
                            if (SomeMan != null)
                            {
                                SomeMan.Kill();
                            }
                            else
                            {
                                System.Console.WriteLine("Человечек не создан. Вы не можете его убить, и вообще, не надо убивать человечков!");
                            }
                            break;
                        }
                    case "laugh":
                        {
                            //рассмешить человечка
                            if (SomeMan != null)
                            {
                                SomeMan.Laugh();
                            }
                            else
                            {
                                System.Console.WriteLine("Человечек не создан. Вы не можете рассмешить того, кого не существует))))");
                            }

                            break;
                        }

                    case "talk":
                        {
                            //разговор с человечком
                            if (SomeMan != null)
                            {
                                SomeMan.Talk();
                            }
                            else
                            {
                                System.Console.WriteLine("Человечек не создан, поэтому поговорить не с кем... Создай человечка)");
                            }
                            break;
                        }

                    case "go":
                        {
                            //позвать человечка прогуляться
                            if (SomeMan != null)
                            {
                                SomeMan.Go();
                            }
                            else
                            {
                                System.Console.WriteLine("Чтобы позвать челочечка погулять, его надо создать)");
                            }
                            break;
                        }
                    default:
                        {

                            System.Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова");
                            System.Console.WriteLine("Для вывода списка команд введите команду help");
                            System.Console.WriteLine("Для завершения программы введите команду exit");
                            break;
                        }
                }
            }

        }

        public class Man
        {
            public Man(string _name)
            {
                Name = _name;
                domicile = "Владимир" ;
                isLife = true;
                isHappy = false;
                Age = (uint)rnd.Next(15, 50);
                Health = (uint)rnd.Next(10, 100);

            }

            private Random rnd = new Random();

            private string Name;

            private uint Age;

            //строка, содержащая место жительства
            private string domicile;

            private uint Health;

            private bool isLife;

            //булево, означающее счастлив ли человек
            private bool isHappy;

            //функция "говорить"
            public void Talk()
            {
                int random_talk = rnd.Next(1,5);
                string tmp_str = "";

                switch (random_talk)
                {
                    case 1: //если 1 - называем своё имя
                        {
                            tmp_str = "Привет, меня зовут " + Name + " ,рад познакомиться";
                            break;
                        }

                    case 2: //если 2 - называем свой возраст
                        {
                            tmp_str = "Мне " + Age;
                            break;
                        }

                    case 3: //если 2 - называем своё месторождение
                        {
                            tmp_str = "Привет, я из города " + domicile;
                            break;
                        }

                    case 4: //если 4 - говорим о своём здоровье
                        {
                            if (Health > 50)
                                tmp_str = "Да я зводоров как бык!";
                            else
                                tmp_str = "Со здоровьем у меня неважно, дожить бы до " + (Age + 10).ToString();
                            break;
                        }
                }
                System.Console.WriteLine(tmp_str);
            }

            //функция "идти"
            public void Go()
            {
                // если человечек жив и счастлив
                if (isLife == true & isHappy == true)
                {
                    // если показатель более 40
                    // считаем объект здоровым
                    if (Health > 40)
                    {
                        string outString = Name + " мирно прогуливается по городу";
                        System.Console.WriteLine(outString);
                    }
                    if (Health < 40)
                    {
                        string outString = Name + " болен и не может гулять по городу";
                        System.Console.WriteLine(outString);
                    }
                }

                //если человечек расстроен
                if (isHappy == false)
                {
                    string outString = Name + " не хочет идти он расстроен, рассмеши его";
                    System.Console.WriteLine(outString);
                }
                //если человечек умер
                if (isLife == false)
                {
                    string outString = Name + " не может идти, он умер...Но ты можешь опять его создать)";
                    System.Console.WriteLine(outString);
                }
            }

            //функция "рассмешить"
            public void Laugh()
            {
                isHappy = true;
                System.Console.WriteLine("Хахахах");
            }

            // функция, возвращающая показатель - жив ли данный человечек.
            public bool IsAlive()
            {
                return isLife;
            }

            public bool IsHappy()
            {
                return isHappy;
            }

            //функция "убить"
            public void Kill()
            {
                isLife = false;
                System.Console.WriteLine("успешно...");
            }

        }
    }
}
