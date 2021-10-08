using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using System.Text;


namespace lab4
{
    class Program
    {
        static void Bai1()
        {
            /*
             Sử dụng Lambda Expressions viết chương trình xuất ra màn hình các số chẵn trong
            một danh sách các số nguyên cho sẵn
             */
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> eventNumber = list.FindAll(x => (x % 2) == 0);
            eventNumber.ForEach(x => WriteLine(x));
        }

        static void Bai2()
        {
            List<Dog> dogs = new List<Dog>()
            {
                new Dog {Name = "Rex", Age = 4},
                new Dog {Name = "Sean", Age = 0},
                new Dog {Name = "Stacy", Age = 3}
            };

            /*
            a/ Xuất thông tin Name và Age của danh sách dogs (dùng phương thức
            Select)
            */
            WriteLine("câu 2-A:");
            var result = from dog in dogs
                         select dog;
            result.ToList().ForEach(x => WriteLine($"Name: {x.Name,0}, Age: {x.Age,0}"));

            /*
            b/ Xắp xếp lại danh sách dogs theo thứ tự giảm dần Age (dùng phương thức
            OrderByDescending)
            */
            WriteLine("câu 2-B:");

            var result2 = from dog in dogs
                          orderby dog.Age descending
                          select dog;
            result2.ToList().ForEach(x => WriteLine($"Name: {x.Name,0}, Age: {x.Age,0}"));
        }

        static void Bai3()
        {
            IList<Student> studentsList = new List<Student>() {
                new Student() {StudentID = 1, StudentName = "John", Age = 13},
                new Student() {StudentID = 2, StudentName = "Moin", Age = 21},
                new Student() {StudentID = 3, StudentName = "Bill", Age = 18},
                new Student() {StudentID = 4, StudentName = "Ram", Age = 20},
                new Student() {StudentID = 5, StudentName = "Rom", Age = 15},
            };

            /*
            a/ Xuất ra màn hình các student có Age > 12 và Age <20 bằng cách dùng LINQ
            Query Syntax và LINQ Method Syntax
            */

            WriteLine("-------------User LINQ Query Systax-------------");
            var QuerySystax = from student in studentsList
                              where student.Age > 12 && student.Age < 20
                              select new
                              {
                                  StudentID = student.StudentID,
                                  StudentName = student.StudentName,
                                  Age = student.Age,
                              };
            QuerySystax.ToList().ForEach(x => WriteLine(x));
            WriteLine("-------------User LINQ Method Systax-------------");

            studentsList.Where(s => s.Age > 12 && s.Age < 20)
            .Select(s =>
            {
                return new
                {
                    StudentID = s.StudentID,
                    StudentName = s.StudentName,
                    Age = s.Age,
                };
            })
            .ToList().ForEach(s => WriteLine(s));
        }

        static void Bai4() {
            //data source
            List<int> intergerList = new List<int>() 
            {
                1,2,3,4,5,6,7,8,9,10
            };

            var MethodSystax = (from obj in intergerList
                                where obj > 5
                                select obj).Sum();
            Write($"tổng là: {MethodSystax}");
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            //Bai1();
            // Bai2();
            //Bai3();
            //Bai4();
        }
    }
}
