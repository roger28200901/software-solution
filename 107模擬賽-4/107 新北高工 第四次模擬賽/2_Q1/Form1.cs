using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int min;
        string sw;

        private void button1_Click(object sender, EventArgs e)
        {
            string[] ipt = textBox1.Text.ToUpper().Replace("\r\n", "\n").Split('\n').Where(v => v != "").ToArray();
            int[,] map = new int[ipt[0].Length, ipt.Length];
            Point p = new Point(0, 0);
            List<Point> li = new List<Point>();
            for (int i = 0; i < ipt.Length; i++)
            {
                string[] st = ipt[i].ToCharArray().Select(v => v.ToString()).ToArray();
                if(st.Length!=map.GetLength(0))
                {
                    textBox2.Text = "無解";
                    return;
                }
                for (int j = 0; j < ipt[0].Length; j++)
                {
                    try
                    {
                        if (st[j] == "Z" || st[j] == "Y" || st[j] == "X")
                        {
                            map[j, i] = Convert.ToChar(st[j]) - 85;
                            li.Add(new Point(j, i));
                        }
                        else if (st[j] == "C")
                        {
                            map[j, i] = 0;
                            p = new Point(j, i);
                        }
                        else
                            map[j, i] = Convert.ToInt32(st[j]);
                    }
                    catch
                    {
                        textBox2.Text = "無解";
                        return;
                    }
                }
            }
            min = 5000;
            go(map, p, li, "", 0);
            if (min == 5000)
                textBox2.Text = "無解";
            else
                textBox2.Text = sw;
        }

        public void go(int[,] map, Point p, List<Point> li, string st, int t)
        {
            if (li.Count == 0)
            {
                if (t < min)
                {
                    min = t;
                    sw = st;
                }
            }
            for (int i = 0; i < li.Count; i++)
            {
                int idx = run(map, p.X, p.Y, li[i]);
                if (idx == -1)
                    continue;
                int[,] map2 = (int[,])map.Clone();
                map2[li[i].X, li[i].Y] = 0;
                List<Point> li2 = li.ToList();
                li2.RemoveAt(i);
                go(map2, li[i], li2, st + idx.ToString() + Convert.ToChar(map[li[i].X, li[i].Y] + 85).ToString(), t + idx);
            }
        }

        public int run(int[,] map, int x, int y, Point over)
        {
            int t = 0;
            List<Point> pp = new List<Point>();
            pp.Add(new Point(x, y));
            int[,] map2 = (int[,])map.Clone();
            map2[x, y] = 1;
            int[,] move = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            while (pp.Count != 0)
            {
                List<Point> pp2 = new List<Point>();
                for (int i = 0; i < pp.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int xx = pp[i].X + move[j, 0], yy = pp[i].Y + move[j, 1];
                        if (xx >= 0 && xx < map.GetLength(0) && yy >= 0 && yy < map.GetLength(1))
                        {
                            if (map2[xx, yy] == 0)
                            {
                                pp2.Add(new Point(xx, yy));
                                map2[xx, yy] = 1;
                            }
                            else if (over.X == xx && over.Y == yy)
                            {
                                return t;
                            }
                        }
                    }
                }
                pp = pp2.ToList();
                t++;
            }
            return -1;
        }
    }
}
