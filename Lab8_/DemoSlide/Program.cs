using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Text;

namespace DemoSlide
{
    class Program
    {
        static void MethodA()
        {
            for (var i = 0; i < 1000; i++)
                Write("0");
        }
        static void MethodB()
        {
            for (var i = 0; i < 1000; i++)
            {
                Write("1");
                Thread.Sleep(1000);
            }
        }
        static void Demo1()
        {
            Thread t = new Thread(new ThreadStart(MethodA));
            Thread t2 = new Thread(new ThreadStart(MethodB));
            t.Start();
            t2.Start();
        }
        static void Demo2()
        {
            Thread t = new Thread(new ThreadStart(MethodB));
            t.Start();
        }
        static void LetGo()
        {
            for (var i = 0; i < 50; i++)
            {
                WriteLine("Code of " + Thread.CurrentThread.Name);
                Thread.Sleep(100);
            }
        }
        static void Demo3()
        {
            Thread.CurrentThread.Name = "Main";

            WriteLine("Code of " + Thread.CurrentThread.Name);
            WriteLine("create thread: ");

            Thread letgoThread = new Thread(LetGo);
            letgoThread.IsBackground = true;
            letgoThread.Name = "Let's Go!";
            letgoThread.Start();

            for (var i = 0; i < 50; i++)
            {
                WriteLine("Code of " + Thread.CurrentThread.Name);
                Thread.Sleep(100);
            }
        }
        static object syscObj1 = new object();
        static object syscObj2 = new object();

        static void Foo()
        {
            WriteLine("Bên trong Foo Method");
            lock (syscObj1)
            {
                WriteLine("Foo: khóa(object1)");
                Thread.Sleep(100);
                lock (syscObj2)
                {
                    WriteLine("Foo: Khóa(object2)");
                }
            }
        }

        static void Bar()
        {
            WriteLine("Bên trong Bar method");
            lock (syscObj2)
            {
                WriteLine("Bar: lock(object2)");
                Thread.Sleep(100);
                if (Monitor.TryEnter(syscObj2, 1000))
                {
                    try
                    {
                        WriteLine("Bar: lock(object1");

                    }
                    finally
                    {
                        Monitor.Exit(syscObj2);
                    }
                }
                lock (syscObj1)
                {
                }
            }
        }
        static void Main(string[] args)
        {
            // Demo1();
            // Demo2();
            // Demo3();

            WriteLine("Main Thread Started");
            Thread t1 = new Thread(Foo);
            Thread t2 = new Thread(Bar);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            WriteLine("Main Thread completed");
        }
    }
}
