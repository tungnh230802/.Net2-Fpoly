using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace Demolab
{
    class Program
    {
        static void Demo1()
        {
            //data source
            string[] names = { "bill", "Steve", "James", "Alice", "Nami", "Naruto" };
            //linq Query
            var myLinqQuery = from name in names
                              where name.Contains("a")
                              select name;
            myLinqQuery.ToList().ForEach(x => WriteLine(x));
        }
        static void Demo2()
        {
            List<int> intergerList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // var QuerySystax = from obj in intergerList
            //                   where obj > 5
            //                   select obj;

            // foreach (var item in QuerySystax)
            // {
            //     Write($"{item} ");
            // }


            // IEnumerable<int> result = intergerList.Where(n => n > 3).ToList();
            
            // result.ToList().ForEach(x => WriteLine($"{x} "));
        
            var MethodSystax = (from obj in intergerList where obj > 5 select obj).Sum();
            WriteLine($"Sum is {MethodSystax}");
        }

        static void Demo3()
        {
            IList<string> stringList = new List<string>() {
                "C# Tutorials",
                "VB.Net Tutorials",
                "Learn C++",
                "MVC Tutorials",
                "Java"
            };

            // var result = from s in stringList
            //              where s.Contains("Tutorials")
            //              select s;
            // result.ToList().ForEach(x => WriteLine(x));

            var result = stringList.Where(s => s.Contains("Tutorials"));
            result.ToList().ForEach(x=>WriteLine(x));
        }

        static void Demo4()
        {
            int[] Num = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> result = from number in Num
                                        where number > 3
                                        select number;
            result.ToList().ForEach(x => Write($"{x} "));
        }

        static void Demo5() {

        }
        static void Main(string[] args)
        {
            // Demo1();
            Demo2();
            // Demo3();
            // Demo4();
        }
    }
}
