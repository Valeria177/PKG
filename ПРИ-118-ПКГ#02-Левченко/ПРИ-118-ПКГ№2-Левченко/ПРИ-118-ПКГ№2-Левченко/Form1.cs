using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПРИ_118_ПКГ_2_Левченко
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        Point tmp_location;

        int _w = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
        int _h = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            textBox1.Text = e.X.ToString();
            textBox2.Text = e.Y.ToString();
            
            if (e.X > 75 && e.X < 190 && e.Y > 150 && e.Y < 210)
            {

                // запоминаем текущее положение окна
                tmp_location = this.Location;
                // генерируем перемещения по осям X и Y и прибавляем их к хранимому значению текущего положения окна
                // числа генерируются в диапазоне от -100 до 100.
                tmp_location.X += rnd.Next(-100, 100);
                tmp_location.Y += rnd.Next(-100, 100);

                // если окно вышло за пределы экрана по одной из осей
                if (tmp_location.X < 0 || tmp_location.X > (_w - this.Width / 2) || tmp_location.Y < 0 || tmp_location.Y > (_h - this.Height / 2))
                {
                    // новыми координатами станет центр окна
                    tmp_location.X = _w / 2;
                    tmp_location.Y = _h / 2;
                }

                // обновляем положение окна на новое сгенерированное
                this.Location = tmp_location;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ой, да не ври)");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оно и видно", "Ну вы поглядите...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
