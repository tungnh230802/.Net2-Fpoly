using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Lab8_
{
    class Program
    {
        static int num = 0;
        static void RamdomNum()
        {
            for(int i = 0; i<=100;i++)
            {
                Random rd = new Random();
                num = rd.Next(1, 20);
                WriteLine($"num:{num}");
                Thread.Sleep(2000);

            }
        }
        static void BinhPhuongNum()
        {
            for(int i = 0;i<=100;i++)
            {
                var tmp = num;
                var numBinh = num * num;
                WriteLine($"bình phương của {tmp} là {numBinh}");
                Thread.Sleep(1000);
            }
        }

        static void Bai1()
        {
            Thread t1 = new Thread(RamdomNum);
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(BinhPhuongNum);
            t2.IsBackground = true;
            t2.Start();
        }

        static object obj1 = new object();
        static object obj2 = new object();

        static void Foo()
        {
            WriteLine("bên trong phương thức foo");
            lock(obj1)
            {
                WriteLine("foo: lock(obj1)");
                Thread.Sleep(100);
                lock (obj2)
                {
                    WriteLine("foo: lock(obj2)");
                }
            }
        }

        static void Bar()
        {
            WriteLine("bên trong phương thức bar");
            lock (obj2)
            {
                WriteLine("bar: lock(obj2)");
                Thread.Sleep(100);
                if (Monitor.TryEnter(obj2, 10000))
                {
                    try
                    {
                        WriteLine("Bar:lock(obj1)");
                    }
                    finally {
                        Monitor.Exit(obj2);
                    }
                }
            }
        }

        static void bai2()
        {
            Thread t1 = new Thread(Foo);
            Thread t2 = new Thread(Bar);

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            WriteLine("Main thread completed");
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            //Bai1();
            bai2();
            ReadKey();
        }
    }
}
