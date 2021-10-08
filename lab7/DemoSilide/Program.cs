using System;
using System.Linq;
using static System.Console;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace DemoSilide
{
	   static void Demo1()
        {
            using (var db = new DataClasses1DataContext(@"Data Source=DESKTOP-2V5F3CA\TUNGNH23082002;
            Initial Catalog=Asm_C#2;Integrated Security=True"))
            {
                var myClass = db.Classes.ToList();

                foreach (var myCl in myClass)
                {
                    Console.WriteLine(myCl.IdClass + "\t" + myCl.NameClass);
                }
            }
        }

        static void Demo2()
        {
            using (var db = new DataClasses1DataContext(@"Data Source=DESKTOP-2V5F3CA\TUNGNH23082002;
            Initial Catalog=Asm_C#2;Integrated Security=True"))
            {
                var student_ = new Student()
                {
                    StId = 1,
                    Name = "nguyen hoang tung",
                    Mark = 10,
                    Email = "tungnh230802@gmail.com",
                    IdClass = 2,
                };
                db.Students.InsertOnSubmit(student_);
                db.SubmitChanges();
            }
        }

        static void Demo3()
        {
            using (var db = new DataClasses1DataContext(@"Data Source=DESKTOP-2V5F3CA\TUNGNH23082002;
            Initial Catalog=Asm_C#2;Integrated Security=True"))
            {
                var class_ = db.Classes
                              .Where(c => c.IdClass == 1)
                              .FirstOrDefault();
                class_.NameClass = "Name already changed";
                db.Classes.DeleteOnSubmit(class_);
                db.SubmitChanges();
            }
        }

        static void Demo4()
        {

            using (var db = new DataClasses1DataContext(@"Data Source=DESKTOP-2V5F3CA\TUNGNH23082002;
            Initial Catalog=Asm_C#2;Integrated Security=True"))
            {
                var result = from c in db.Classes
                             join s in db.Students
                             on c.IdClass equals s.IdClass
                             select new
                             {
                                 ClassName = c.NameClass,
                                 studentName = s.Name,
                             };
                result.ToList().ForEach(x => Console.WriteLine(x.studentName + "\t" + x.ClassName));
            }
        }
    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    class Program
    {
        static void Demo1()
        {
            string str = "Welcome to Fpoly";
            var result = from s in str.ToLowerInvariant().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                         select s;
            result.ToList().ForEach(x => WriteLine(x));
        }
        static void Demo2()
        {
            string[] arr = { "FPT", "Aptech", "Fpoly", "FU" };
            IEnumerable<string> result = from a in arr
                                         where a.ToLowerInvariant().StartsWith('f')
                                         select a;
            result.ToList().ForEach(x => WriteLine(x));
        }
        static void Demo3()
        {
            DirectoryInfo filedir = new DirectoryInfo(@"D:\Images");
            var files = from file in filedir.GetFiles()
                        select new { FileName = file.Name, FileSize = (file.Length / 1024) + "KB" };
            WriteLine("FileName" + "\t | " + "FileSize");
            WriteLine("-------------------------------");
            foreach (var item in files)
            {
                WriteLine(item.FileName + "\t | " + item.FileSize);
            }
        }

        static void Demo4()
        {
            List<Employee> objEmp = new List<Employee>()
            {
                new Employee {EmpId = 1, Name = "Suresh Dasari", Location = "Chennai"},
                new Employee {EmpId = 2, Name = "Suresh Dasari", Location = "Chennai"},
                new Employee {EmpId = 3, Name = "Suresh Dasari", Location = "Chennai"},
                new Employee {EmpId = 4, Name = "Suresh Dasari", Location = "Chennai"},
            };

            var result = from e in objEmp
                         where e.Location.Equals("Chennai")
                         select new
                         {
                             Name = e.Name,
                             Location = e.Location,
                         };
            foreach (var item in result)
            {
                WriteLine(item.Name + "\t | " + item.Location);
            }
        }
        static void Main(string[] args)
        {
            // Demo1();
            // Demo2();
            // Demo3();
            Demo4();
        }
    }
}
