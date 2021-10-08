using System;
using static System.Console;

namespace cau1_D
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dobj = new User();
            dynamic a = 10;
            dobj.GetDetail(a);
        }

    }
    class User 
    {
        public int ID {get;set;}
        public string Name {get;set;}
        public void GetDetail(dynamic d) {
            WriteLine(d);
        }
    }
}
