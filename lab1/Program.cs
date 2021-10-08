using System;
using System.Collections;
using System.Text;
using static System.Console;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace lab1
{

    class Program
    {
        static void bai1()
        {

            WriteLine(MyCollege.CollegeName);
            WriteLine(MyCollege.Address);
            Read();
        }

        static void bai2()
        {
            Student.DisplayCollegeDetails();

            WriteLine();
            Student s1 = new Student();
            Student s2 = new Student();

            s1.SetStudentDetail("Thepv", "phd");
            s2.SetStudentDetail("nghiem", "mba");

            s1.DisplayStudentDetail();
            s2.DisplayStudentDetail();

            Read();
        }

        static void bai3()
        {
            clsCalculation objCal = new clsCalculation();
            objCal.Addition(2, 3);
        }

        static void bai4A()
        {
            int times = 10000000;

            for (int listSize = 1; listSize < 10; listSize++)
            {
                List<string> list = new List<string>();
                HashSet<string> hashset = new HashSet<string>();
                for (int i = 0; i < listSize; i++)
                {
                    list.Add("String " + i.ToString());
                    hashset.Add("String " + i.ToString());
                }
                Stopwatch timer = new Stopwatch();

                timer.Start();

                for (int i = 0; i < times; i++)
                {
                    list.Remove("string0");
                    list.Add("string0");
                }
                timer.Stop();
                Console.WriteLine(listSize.ToString() + " item LIST strs time: " + timer.ElapsedMilliseconds.ToString() + "ms");

                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    hashset.Remove("string0");
                    hashset.Add("string0");
                }

                timer.Stop();
                Console.WriteLine(listSize.ToString() + "item HASHSET strs time: " + timer.ElapsedMilliseconds.ToString() + "ms");
                Console.WriteLine();
            }
        }

        static void bai4B()
        {
            int times = 10000000;
            for (int listSize = 1; listSize < 10; listSize += 3)
            {
                List<object> list = new List<object>();
                HashSet<object> hashset = new HashSet<object>();
                for (int i = 0; i < listSize; i++)
                {
                    list.Add(new object());
                    hashset.Add(new object());
                }

                object objToAddRem = list[0];
                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    list.Remove(objToAddRem);
                    list.Add(objToAddRem);
                }
                timer.Stop();
                Console.WriteLine(listSize.ToString() + "item LIST obj time: " + timer.ElapsedMilliseconds.ToString() + "ms");

                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    hashset.Remove(objToAddRem);
                    hashset.Add(objToAddRem);
                }

                timer.Stop();
                Console.WriteLine(listSize.ToString() + "item HASHSET obj time: " + timer.ElapsedMilliseconds.ToString() + "ms");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            // bai1();
            // bai2();
            // bai3();
            // bai4A();
            // bai4B();
            var bien1 = 3.14;                                           // biến sẽ có kiểu double
            var bien2 = 3;                                              // biến sẽ có kiểu int
            var bien3 = "Biến khai báo với var phải khởi tạo ngay";     // string
            var bien4 = (5 < 4);
        }
    }
}
