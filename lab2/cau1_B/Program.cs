using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

namespace cau1_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, int>();
            data.Add("cat", 2);
            data.Add("dog", 1);
            
            WriteLine("cat - dog = {0}",
            data["cat"] - data["dog"]);
        }
    }
}
