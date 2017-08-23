using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4096
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            A = new GamePanel();
            this.Controls.Add(A);
            label1.Text = label3.Text= "0";
            label4.Visible = false;
        }
        GamePanel A;
        bool L;
        int S;
        int ArgCo=254;
        bool booV = true;
        Random R = new Random();
        private void move(object sender, EventArgs e)
        {
            if (booV)
            {
                ArgCo--;
                if (ArgCo == 0)
                {
                    booV = false;
                }
            }
            else
            {
                ArgCo++;
                if (ArgCo==255)
                {
                    booV = true;
                }
            };
            label4.BackColor = System.Drawing.Color.FromArgb(ArgCo, Color.White);
        }   
        private void WINNER()
        {
            timer1.Enabled = true;
            label4.Visible = true;
        }     
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool D = false;
            bool Lose = false;
            bool WIN = false;
            if (keyData == Keys.Up)
            {
                A.Combine('U',out S, out Lose,out WIN);
                D= true;
            }
            if (keyData == Keys.Down)
            {
                A.Combine('D', out S, out Lose, out WIN);
                D = true;
            }
            if (keyData == Keys.Left)
            {
                A.Combine('L', out S, out Lose, out WIN);
                D = true;
            }
            if (keyData == Keys.Right)
            {
                A.Combine('R', out S, out Lose, out WIN);
                D = true;
            }
            label1.Text = S.ToString();
            label3.Text = Convert.ToString(S , 2);
            if (Lose)
            {
                label2.Text = "GameFailure";
            }
            if(WIN)
            {
                WINNER();
            }
            if (D)
            {
                return D;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(A);
            A = new GamePanel();
            this.Controls.Add(A);
            label1.Text=label3.Text = "0";
            label4.Visible = false;
            timer1.Enabled = false;
        }
        private void sprite(object sender, EventArgs e)
        {
            //Drink Sprite
        }
    }
}
