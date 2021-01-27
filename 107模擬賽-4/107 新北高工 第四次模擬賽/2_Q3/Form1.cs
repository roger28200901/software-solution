using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.JScript;

namespace _2_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int hj = 0;
        TextBox[] t;

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new TextBox[20];
            t[0] = textBox1;
            for (int i = 1; i < 10; i++)
            {
                t[i] = new TextBox { Size = t[0].Size, Location = new Point(t[0].Left, t[0].Top + i * (t[0].Height)), Visible = false, Enabled = false };
                this.Controls.Add(t[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hj >= 20)
                return;
            hj++;
            t[hj].Enabled = t[hj].Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);
            Brush bh = Brushes.Black;
            Pen p = new Pen(bh), p2 = new Pen(Color.Blue);
            g.Clear(Color.White);
            g.DrawLine(p, 0, 1, b.Width, 1);
            g.DrawLine(p, 0, b.Height / 2, b.Width, b.Height / 2);
            g.DrawLine(p, b.Width / 2, 0, b.Width / 2, b.Height);
            g.DrawLine(p, 0, b.Height / 2, b.Width, b.Height / 2);
            g.DrawLine(p2, 0, b.Height / 2, b.Width, b.Height / 2);
            for (int i = -10; i <= 10; i += 5)
            {
                g.DrawString(i.ToString(), new Font("新細明體", 12), bh, (i + 10) * (b.Width / 21) + 2, b.Height / 2);
                if (i != 0)
                    g.DrawString(i.ToString(), new Font("新細明體", 12), bh, b.Width / 2 - 25 + (3 - i.ToString().Length) * 5, b.Height - ((i + 10) * (b.Height / 21) + 2) - 20);
            }
            for (int i = 0; i <= hj; i++)
            {
                
            }
            pictureBox1.Image = b;
            //Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
            //MessageBox.Show(Microsoft.JScript.Eval.JScriptEvaluate(t[0].Text, ve).ToString());
        }
    }
}
