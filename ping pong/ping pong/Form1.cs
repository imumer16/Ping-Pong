using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ping_pong
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int point = 0;
        
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;

            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;


            racket.Top = playground.Bottom - (playground.Bottom / 10);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X -(racket.Width / 2);
            bal.Left += speed_left;
            bal.Top += speed_top;

            if (bal.Bottom>=racket.Top && bal.Bottom<=racket.Bottom && bal.Left>=racket.Left && bal.Right<=racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                point += 1;
                label1.Text = $"Score: { point}";
            }


            if (bal.Left<=playground.Left)
            {
                speed_left = -speed_left;
            }

            if (bal.Right>=playground.Right)
            {
                speed_left = -speed_left;
            }

            if (bal.Top<=playground.Top)
            {
                speed_top = -speed_top;
            }

            if (bal.Bottom>=playground.Bottom)
            {

                timer1.Enabled = false;
                replay.Visible = true;
                button1.Visible = true;
                Cursor.Show();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
                
        }

        private void replay_Click(object sender, EventArgs e)
        {
                Application.Restart();
                
        }

 

        private void Click1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
 