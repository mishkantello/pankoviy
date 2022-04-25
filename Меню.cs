using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace try1
{
    public partial class Меню : Form
    {
        public Меню()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) //открытие окна об игре
        {
            AboutBox1 программа = new AboutBox1();
            программа.Show();
        }

        private void Меню_Load(object sender, EventArgs e) //настройки стиля окна
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //открытие окна игры и скрывание меню
        {
            EPISODE_1 E1 = new EPISODE_1(this);
            E1.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //закрытие игры по нажатию на кнопку выход
        {
            Application.Exit();
        }
    }
}
