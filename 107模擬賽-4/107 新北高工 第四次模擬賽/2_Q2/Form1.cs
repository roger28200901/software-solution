using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2_Q2
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            pictureBox1.Image = null;
            textBox2.Text = "";
            if (o.ShowDialog() != DialogResult.OK)
                return;
            try { pictureBox1.Image = new Bitmap(o.FileName); }
            catch { MessageBox.Show("請載入圖片檔!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b;
            try
            {
                b = new Bitmap(pictureBox1.Image);
            }
            catch
            {
                MessageBox.Show("請載入圖片!");
                return;
            }
            int t = 0;
            string p = string.Join("", Encoding.Unicode.GetBytes(textBox1.Text).Select(v => Convert.ToString(v, 2).PadLeft(8, '0')));
            for (int j = 0; j < b.Height; j++)
            {
                for (int i = 0; i < b.Width; i++)
                {
                    Color c = b.GetPixel(i, j);
                    int wr, wg;
                    if (t == p.Length)
                    {
                        wr = Convert.ToInt32(Convert.ToString(c.R, 2).PadLeft(8, '0').Substring(0, 7) + "0", 2);
                        b.SetPixel(i, j, Color.FromArgb(wr, c.G, c.B));
                    }
                    else if (t < p.Length)
                    {
                        wr = Convert.ToInt32(Convert.ToString(c.R, 2).PadLeft(8, '0').Substring(0, 7) + "1", 2);
                        wg = Convert.ToInt32(Convert.ToString(c.G, 2).PadLeft(8, '0').Substring(0, 7) + p.Substring(t, 1), 2);
                        b.SetPixel(i, j, Color.FromArgb(wr, wg, c.B));
                    }
                    t++;
                    if (t > p.Length)
                        break;
                }
                if (t > p.Length)
                    break;
            }
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "*.bmp|*.bmp";
            if (sa.ShowDialog() != DialogResult.OK)
                return;
            b.Save(sa.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b;
            try
            {
                b = new Bitmap(pictureBox1.Image);
            }
            catch
            {
                MessageBox.Show("請載入圖片!");
                return;
            }
            string p = "";
            List<byte> li = new List<byte>();
            bool bb = true;
            for (int j = 0; j < b.Height; j++)
            {
                for (int i = 0; i < b.Width; i++)
                {
                    Color c = b.GetPixel(i, j);
                    if (Convert.ToString(c.R, 2).PadLeft(8, '0').Substring(7, 1) == "1")
                        p += Convert.ToString(c.G, 2).PadLeft(8, '0').Substring(7, 1);
                    else
                        bb = false;
                    if (!bb)
                        break;
                }
                if (!bb)
                    break;
            }
            try
            {
                if (p.Length == 0)
                    throw new Exception();
                while (p.Length != 0)
                {
                    li.Add(Convert.ToByte(p.Substring(0, 8), 2));
                    p = p.Substring(8);
                }
            }
            catch
            {
                textBox2.Text = "無隱碼";
                return;
            }
            textBox2.Text = Encoding.Unicode.GetString(li.ToArray());
        }
    }
}
