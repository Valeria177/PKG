using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПРИ_118_ПКГ_2._2_Левченко
{
    public partial class preview : Form
    {
        Image ToView;
        public preview(Image view)
        {
            ToView = view;
            InitializeComponent();
        }

        private void preview_Load(object sender, EventArgs e)
        {
            // если объект, хранящий изображение неравен null
            if (ToView != null)
            {
                // устанавливаем новые размеры элемента pictureBox1,
                // равные ширине (ToView.Width) и высоте (ToView.Height) загружаемого изображения.
                pictureBox1.Size = new Size(ToView.Width, ToView.Height);
                // устанавливаем изображение для отображения в элементе pictureBox1
                pictureBox1.Image = ToView;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // закрываем диалоговое окно
            Close();
        }
    }
}
