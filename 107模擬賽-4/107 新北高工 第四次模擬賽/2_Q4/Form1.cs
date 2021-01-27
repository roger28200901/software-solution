using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int idx;
        int[,] map;
        string[,] p;
        Label[,] l;
        Bitmap b;

        private void Form1_Load(object sender, EventArgs e)
        {
            idx = 0;
            map = new int[6, 6];
            p = new string[6, 6];
            l = new Label[6, 6];
            l[0, 0] = label1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    l[i, j] = new Label
                    {
                        AutoSize = false,
                        Size = l[0, 0].Size,
                        Location = new Point(l[0, 0].Left + i * (l[0, 0].Width), l[0, 0].Top + j * (l[0, 0].Height)),
                        BorderStyle = l[0, 0].BorderStyle
                    };
                    l[i, j].Click += label1_Click;
                    this.Controls.Add(l[i, j]);
                }
            }
            Label[] la = { label4, label2, label3, label5, label6, label7 };
            for (int i = 0; i < 6; i++)
            {
                la[i].Image = draw(i, new int[] { }, 0);   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            map = new int[6, 6];
            p = new string[6, 6];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    l[i, j].Image = label4.Image;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            bool ck = true;
            Label ll = (Label)sender;
            ll.Image = b;
            p = new string[6, 6];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    p[i, j] = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (ll == l[i, j])
                    {
                        map[i, j] = idx;
                        ck = false;
                        break;
                    }
                }
                if (!ck)
                    break;
            }
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    l[i, j].Image = draw(map[i, j], new int[] { }, 0);
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (map[i, j] == 1)
                    {
                        run(new Point(i, j), 1, new List<Point>());
                    }
                }
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    int[] hh = new int[4];
                    if (map[i, j] == 5)
                    {
                        for (int k = 0; k < 4; k++)
                            if (p[i, j].IndexOf(k.ToString()) != -1)
                                hh[k] = 1;
                    }
                    l[i, j].Image = draw(map[i, j], hh, p[i, j] != "" ? 1 : 0);
                }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Label[] la = { label4, label2, label3, label5, label6, label7 };
            Label ll = (Label)sender;
            b = new Bitmap(ll.Image);
            for (int i = 0; i < la.Length; i++)
            {
                if (la[i] == ll)
                {
                    idx = i;
                    return;
                }
            }
        }

        public void run(Point pp, int idx, List<Point>li)
        {
            List<Point> li2 = li.ToList();
            li2.Add(pp);
            if (idx == 2)
            {
                p[pp.X, pp.Y] = "1";
                for (int i = 0; i < li2.Count; i++)
                {
                    switch (map[li2[i].X, li2[i].Y])
                    {
                        case 2:
                        case 3:
                        case 4:
                            p[li2[i].X, li2[i].Y] = "1";
                            break;
                        case 5:
                            int iif = ccf(li2[i - 1], li[i]);
                            p[li2[i].X, li2[i].Y] += iif.ToString() + " ";
                            iif = ccf(li2[i + 1], li[i]);
                            p[li2[i].X, li2[i].Y] += iif.ToString() + " ";
                            break;
                        default:
                            break;
                    }
                }
                return;
            }
            int[][] go = new int[6][];
            go[0] = new int[] { };
            go[1] = new int[] { 2, 3, 4, 5 };
            go[2] = new int[] { };
            go[3] = new int[] { 2, 3, 5 };
            go[4] = new int[] { 2, 4, 5 };
            go[5] = new int[] { 2, 3, 4, 5 };
            int[][,] move = new int[6][,];
            move[0] = new int[,] { };
            move[1] = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            move[2] = new int[,] { };
            move[3] = new int[,] { { 1, 0 }, { -1, 0 } };
            move[4] = new int[,] { { 0, 1 }, { 0, -1 } };
            move[5] = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int i = 0; i < move[idx].GetLength(0); i++)
            {
                int xx = pp.X + move[idx][i, 0], yy = pp.Y + move[idx][i, 1];
                if (xx >= 0 && xx < 6 && yy >= 0 && yy < 6 && Array.IndexOf(li.ToArray(), new Point(xx, yy)) == -1)
                {
                    if (Array.IndexOf(go[idx], map[xx, yy]) != -1)
                    {
                        run(new Point(xx, yy), map[xx, yy], li2);
                    }
                }
            }
        }

        public int ccf(Point p1,Point p2)
        {
            if (p1.X == p2.X)
            {
                if (p1.Y > p2.Y)
                    return 1;
                else 
                    return 0;
            }
            else
            {
                if (p1.X > p2.X)
                    return 3;
                else
                    return 2;
            }
        }

        public Bitmap draw(int st, int[] p, int ii)
        {
            Bitmap bb = new Bitmap(label1.Width, label1.Height);
            Graphics g = Graphics.FromImage(bb);
            Brush c = ii == 0 ? Brushes.Black : Brushes.Red;
            Pen pp = new Pen(c, 6);
            switch (st)
            {
                case 0:
                    break;
                case 1:
                    g.DrawString("AC", new Font("標楷體", 35), c, 5, 15);
                    break;
                case 2:
                    g.DrawString("LED", new Font("標楷體", 25), c, 5, 20);
                    break;
                case 3:
                    g.DrawLine(pp, 0, bb.Height / 2, bb.Width, bb.Height / 2);
                    break;
                case 4:
                    g.DrawLine(pp, bb.Width / 2, 0, bb.Width / 2, bb.Height);
                    break;
                case 5:
                    if (p.Length == 0)
                    {
                        g.DrawLine(pp, 0, bb.Height / 2, bb.Width, bb.Height / 2);
                        g.DrawLine(pp, bb.Width / 2, 0, bb.Width / 2, bb.Height);
                    }
                    else
                    {
                        g.DrawLine(p[2] == 1 ? new Pen(Brushes.Red, 6) : new Pen(Brushes.Black, 6), 0, bb.Height / 2, bb.Width / 2, bb.Height / 2);
                        g.DrawLine(p[3] == 1 ? new Pen(Brushes.Red, 6) : new Pen(Brushes.Black, 6), bb.Width / 2, bb.Height / 2, bb.Width, bb.Height / 2);
                        g.DrawLine(p[0] == 1 ? new Pen(Brushes.Red, 6) : new Pen(Brushes.Black, 6), bb.Width / 2, 0, bb.Width / 2, bb.Height / 2);
                        g.DrawLine(p[1] == 1 ? new Pen(Brushes.Red, 6) : new Pen(Brushes.Black, 6), bb.Width / 2, bb.Height / 2, bb.Width / 2, bb.Height);
                    }
                    break;
                default:
                    break;
            }
            return bb;
        }
    }
}
