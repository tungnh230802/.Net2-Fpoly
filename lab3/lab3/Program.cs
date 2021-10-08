using System;
using static System.Console;
using System.IO;
using System.Text;

namespace lab3
{
    class Program
    {
        static void Bai1_A() // File Stream
        {
            try
            {
                string pathFile = @"D:\csharp\example.txt";
                // create file
                FileStream fs = new FileStream(pathFile, FileMode.Create);
                // add current data and time in file
                byte[] bdata = Encoding.Default.GetBytes(DateTime.Now.ToString());
                fs.Write(bdata, 0, bdata.Length);
                WriteLine("dữ liệu đã được thêm");
                fs.Close();
                //Reading file
                string data;
                FileStream fsRead = new FileStream(pathFile, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fsRead))
                {
                    data = sr.ReadToEnd();
                }
                WriteLine(data);
            }
            catch (Exception e)
            {
                WriteLine(e.Message.ToString());
            }
        }

        static void BAi1_B() // StreamWrite và StreamReader 
        {
            string pathFile = @"D:\csharp\example.txt";
            // create and Writting
            using (StreamWriter writer = new StreamWriter(pathFile))
            {
                writer.Write(DateTime.Now.ToString());
                WriteLine("thêm ngày giờ hiện tại thành công!");
            }
            // read file
            using (StreamReader reader = new StreamReader(pathFile))
            {
                Write("Reading current Time: ");
                WriteLine(reader.ReadToEnd());
            }
        }
        static void Bai1_C() //TextWriter and TextReader
        {
            string pathFile = @"D:\csharp\example.txt";
            //Writting file
            using (TextWriter write = File.CreateText(pathFile))
            {
                write.WriteLine(DateTime.Now.ToString());
                WriteLine("thêm ngày giờ hiện tại thành công!");
            }
            //Reading file
            using (TextReader reader = File.OpenText(pathFile))
            {
                Write("Reading curent Time: ");
                WriteLine(reader.ReadToEnd());
            }
        }

        /*
        Tạo một thư mục D: \ example và sau đó tạo một tệp trong đó D: \ example \
        test.txt và lưu trữ nội dung "Hello File Handing" trong file đó. Sau đó thu thập
        thông tin của Directory và File để xuất ra màn hình.
        */
        static void Bai2()
        {
            CreateDirectory();
            CreateFile();
        }
        static void CreateDirectory()
        {
            // Create Directory
            DirectoryInfo dir = new DirectoryInfo(@"D:\example");
            try
            {
                // check If directory Exists
                if (dir.Exists)
                {
                    WriteLine("Thư mục đã tồn tại");
                    WriteLine($"tên thư mục: {dir.Name}");
                    WriteLine($"đường dẫn đầy đủ: {dir.FullName}");
                    WriteLine($"thời gian tạo thư mục: {dir.CreationTime}");
                    WriteLine($"thời gian được truy vấn lần cuối: {dir.LastAccessTime}");
                }
                //create diretory
                else
                {
                    dir.Create();
                    WriteLine("Thư mục đã tồn tại");
                    WriteLine($"tên thư mục: {dir.Name}");
                    WriteLine($"đường dẫn đầy đủ: {dir.FullName}");
                    WriteLine($"thời gian tạo thư mục: {dir.CreationTime}");
                    WriteLine($"thời gian được truy vấn lần cuối: {dir.LastAccessTime}");
                }
            }
            catch (DirectoryNotFoundException d)
            {
                WriteLine(d.Message.ToString());
            }
        }
        static void CreateFile()
        {
            FileInfo file = new FileInfo(@"D:\example\test.txt");
            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Hello File Handling");
            }
            // Display file info
            WriteLine("\n\n******Display File Info******");
            WriteLine($"Thời gian tạo file: {file.CreationTime}");
            WriteLine($"tên thư mục chứa file: {file.DirectoryName}");
            WriteLine($"đường dẫn đầy đủ: {file.FullName}");
            WriteLine($"thời gian được truy vẫn lần cuối: {file.LastAccessTime}");
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            // Bai1_A();
            // BAi1_B();
            // Bai1_C();
            Bai2();
            ReadKey();
        }
    }
}
