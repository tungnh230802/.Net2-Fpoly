using System;
using static System.Console;
using System.IO;
using System.Text;

namespace demoSlide
{
    class Program
    {
        static void test()
        {

            using (FileStream fileStream = new FileStream("test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                for (int i = 1; i <= 20; i++)
                {
                    fileStream.WriteByte((byte)i);
                }
                fileStream.Position = 10;

                for (int i = 0; i <= 19; i++)
                {
                    Console.Write(fileStream.ReadByte() + " ");
                }
            }
        }
        static void demo1()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\1.txt";

            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            using (var fs = File.Create(fpath))
            {
                AddTexttoFile(fs, "hi");
                AddTexttoFile(fs, "\r\nWelcome to fpoly");
                AddTexttoFile(fs, "\r\nFileStream Example");
            }
        }


           static void AddTexttoFile(FileStream fs, string value)
        {
            byte[] info = Encoding.UTF8.GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        static void demo2()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\1.txt";
            if (File.Exists(fpath))
            {
                using (var fs = File.OpenRead(fpath))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding encode = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        WriteLine(encode.GetString(b));
                    }
                }
            }
        }
        static void demo3()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\TestWriter.txt";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            using (TextWriter wr = File.CreateText(fpath))
            {
                wr.WriteLine("Hi");
                wr.WriteLine("\r\nWelcome to FPoly");
                wr.WriteLine("\r\nTextWriter Example");
            }
        }
        static void demo4()
        {
            string filepath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\TestWriter.txt";
            //read on line
            using (TextReader tr = File.OpenText(filepath))
            {
                WriteLine(tr.ReadLine());
            }

            //read 4 character
            using (TextReader tr = File.OpenText(filepath))
            {
                char[] ch = new char[4];
                tr.ReadBlock(ch, 0, 4);
                WriteLine(ch);
            }
            //read full file
            using (TextReader tr = File.OpenText(filepath))
            {
                WriteLine(tr.ReadToEnd());
            }
        }
        static void demo5()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\Test.txt";

            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open(fpath, FileMode.Create)))
            {
                bw.Write(1.25);
                bw.Write("welcome to Fpoly");
                bw.Write(10);
                bw.Write(true);
                bw.Write("test");
            }
            using (BinaryReader br = new BinaryReader(File.Open(fpath, FileMode.Open)))
            {
                WriteLine(br.ReadDouble());
                WriteLine(br.ReadString());
                WriteLine(br.ReadInt32());
                WriteLine(br.ReadBoolean());
                WriteLine(br.ReadString());
            }
        }
        static void demo6()
        {
            string text = "Hello. This is Line 1\n Hello. This is Line 2\nHello. This is Line 3";
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            writer.WriteLine(text);
            writer.Flush();
            writer.Close();

            //read entry
            StringReader reader = new StringReader(sb.ToString());
            //check to End of File
            while (reader.Peek() > -1)
            {
                WriteLine(reader.ReadLine());
            }
        }
        static void demo7()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\TestDirectory.txt";
            DirectoryInfo di = new DirectoryInfo(fpath);
            if (di.Exists)
            {
                WriteLine("Directory Already Exists");
            }
            else
            {
                di.Create();
                WriteLine("directory Created Successfully");
            }
        }
        static void demo8()
        {
            string sourcedir = @"D:\Fpoly";
            string Targetdir = @"D:\Test";

            DirectoryInfo sdi = new DirectoryInfo(sourcedir);
            DirectoryInfo tdi = new DirectoryInfo(Targetdir);

            if (!tdi.Exists)
            {
                tdi.Create();
            }
            //coppy each file into it's new directory
            foreach (FileInfo fi in sdi.GetFiles())
            {
                fi.CopyTo(Path.Combine(tdi.ToString(), fi.Name), true);
                WriteLine(@"Coppying {0} \ {1}", tdi.FullName, fi.Name);
            }
            //coppy each subdirection and it's files
            foreach (DirectoryInfo sourceSubDir in sdi.GetDirectories())
            {
                DirectoryInfo targetSubDir =
                tdi.CreateSubdirectory(sourceSubDir.Name);
                foreach (FileInfo fi in sourceSubDir.GetFiles())
                {
                    fi.CopyTo(Path.Combine(targetSubDir.ToString(), fi.Name), true);
                    WriteLine(@"Coppying {0} \ {1}", targetSubDir.FullName, fi.Name);
                }
            }
        }
        static void demo9()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\Test2.txt";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            FileInfo fi = new FileInfo(fpath);
            using (StreamWriter sw = fi.CreateText())
            {
                sw.WriteLine("hi");
                sw.WriteLine("\r\nWelcome to Fpoly");
                sw.WriteLine("\r\nFileInfo Example");
            }
        }
        static void demo10()
        {
            string fpath = @"C:\Users\tungnh230802\OneDrive\WorkSpace\c#\c#_2\worklab\lab3\demoSlide\Test2.txt";
            if (File.Exists(fpath))
            {
                FileInfo fi = new FileInfo(fpath);
                using (StreamReader sr = fi.OpenText())
                {
                    string txt;
                    while ((txt = sr.ReadLine()) != null)
                    {
                        WriteLine(txt);
                    }
                }
            }
        }
     

        static void Main(string[] args)
        {
            // test();
            // demo1();
            demo2();
            // demo3();
            // demo4();
            // demo5();
            // demo6();
            demo8();
            // demo9();
            // demo10();
            // ReadLine();
        }

    }
}
