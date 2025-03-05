using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Proje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formkullanıcı f = new Formkullanıcı();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formkategori f = new Formkategori();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formürünler f = new Formürünler();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormGeriBildirim f = new FormGeriBildirim();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Formürünresmi f = new Formürünresmi();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(232, 250, 244))
            {
                button1.BackColor = Color.FromArgb(153, 180, 209);
            }
            else
            {
                button1.BackColor = Color.FromArgb(232, 250, 244);
            }
         
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(232, 250, 244))
            {
                button2.BackColor = Color.FromArgb(143, 188, 139);
            }
            else
            {
                button2.BackColor = Color.FromArgb(232, 250, 244);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(172, 170, 233))
            {
                button3.BackColor = Color.FromArgb(232, 250, 244);
            }
            else
            {
                button3.BackColor = Color.FromArgb(172, 170, 233);
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.FromArgb(232, 250, 244))
            {
                button4.BackColor = Color.FromArgb(205, 92, 92);
            }
            else
            {
                button4.BackColor = Color.FromArgb(232, 250, 244);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.FromArgb(153, 180, 209))
            {
                
                button1.BackColor = Color.FromArgb(232, 250, 244);
            }
            else
            {
                button1.BackColor = Color.FromArgb(153, 180, 209);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.FromArgb(143, 188, 139))
            {
                button2.BackColor = Color.FromArgb(232, 250, 244);
            }
            else
            {
                button2.BackColor = Color.FromArgb(143, 188, 139);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.FromArgb(232, 250, 244))
            {
                button3.BackColor = Color.FromArgb(172, 170, 233);
            }
            else
            {
                button3.BackColor = Color.FromArgb(232, 250, 244);
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.FromArgb(205, 92, 92))
            {
                button4.BackColor = Color.FromArgb(232, 250, 244);
            }
            else
            {
                button4.BackColor = Color.FromArgb(205, 92, 92);
            }
        }
    }
}
