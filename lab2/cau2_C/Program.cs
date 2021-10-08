using System;
using System.Text;
using static System.Console;
namespace cau2_C
{
    class Program
    {
        public delegate void MathOps(int a);
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            int y = 10;

            MathOps ops = delegate (int x)
            {
                WriteLine("phép cộng: {0}", x + y);
                WriteLine("phép trừ: {0}", x - y);
            };
            ops(90);
        }
    }
}
