using System;

namespace cau1_C
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDetail(100);
            GetDetail("welcome to Fpoly");
            GetDetail(true);
            GetDetail(20.50);
        }

        static void GetDetail(dynamic d)
        {
            WriteLine(d);
        }
    }
}
