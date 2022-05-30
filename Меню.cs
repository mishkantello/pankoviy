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
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        bool music = false;
        public Меню()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            menuStrip1.Parent = pictureBox1;
            menuStrip1.BackColor = Color.Transparent;
            WMP.URL = "Resources/menu.mp3";
            WMP.controls.play();
            WMP.settings.volume = 100;
        }

        private void оПрограмме(object sender, EventArgs e) //открытие окна об игре
        {
            AboutBox1 программа = new AboutBox1();
            программа.Show();
        }

        private void новаяИгра(object sender, EventArgs e) //открытие окна игры и скрывание меню
        {
            EPISODE_1 E1 = new EPISODE_1(this);
            E1.Show();
            this.Hide();
            //WMP.controls.stop();
        }

        private void выход(object sender, EventArgs e) //закрытие игры по нажатию на кнопку выход
        {
            Application.Exit();
        }

        private void Меню_VisibleChanged(object sender, EventArgs e)
        {
            switch (music)
            {
                case true:
                    music = false;
                    WMP.controls.stop();
                    break;
                case false:
                    music = true;
                    WMP.controls.play();
                    break;
            }
        }
    }
}
