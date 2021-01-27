using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool ck = true;
        Label[,] l;

        private void Form1_Load(object sender, EventArgs e)
        {
            l = new Label[,] { { label1, label2, label3 }, { label4, label5, label6 }, { label7, label8, label9 } };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ck = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    l[i, j].BackColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!ck)
                return;
            int idx = -1, idy = -1;
            Label ll = (Label)sender;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (l[i, j] == ll)
                    {
                        idx = i;
                        idy = j;
                        break;
                    }
                }
                if (idx != -1)
                    break;
            }
            int[,] p = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }, { 0, 0 } };
            for (int i = 0; i < 5; i++)
            {

                int xx = idx + p[i, 0], yy = idy + p[i, 1];
                if (xx >= 0 && xx < 3 && yy >= 0 && yy < 3)
                    l[xx, yy].BackColor = l[xx, yy].BackColor == Color.Black ? Color.Yellow : Color.Black;
            }
            bool bb = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (l[i, j].BackColor == Color.Black)
                        bb = false;
            if (bb)
            {
                ck = false;
                MessageBox.Show("遊戲完成", "WindowsApplicati");
            }
        }
    }
}
