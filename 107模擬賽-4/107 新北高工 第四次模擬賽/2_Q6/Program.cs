using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = new string[32];
            Console.WriteLine("請輸入:");
            for (int i = 0; i < 26; i++)
                s[i] = Convert.ToChar(i + 65).ToString();
            for (int i = 26; i <= 31; i++)
                s[i] = (i - 24).ToString();
            string b = string.Join("", Encoding.ASCII.GetBytes(Console.ReadLine()).Select(v => Convert.ToString(v, 2).PadLeft(8, '0')));
            if (b.Length % 5 != 0)
                b = b.PadRight(b.Length + (5 - b.Length % 5), '0');
            Console.Write("結果:");
            while (b.Length != 0)
            {
                int idx = Convert.ToInt32(b.Substring(0, 5), 2);
                Console.Write(s[idx]);
                b = b.Substring(5);
            }
            Console.ReadKey();
        }
    }
}
