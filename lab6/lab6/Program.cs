using System;
using System.Linq;
using static System.Console;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace lab6
{
    class Program
    {
        static void Bai1A(IList<int> intList)
        {
            //Tìm số chẵn đầu tiên trong intList
            try
            {
                WriteLine($"Số Chẵn đầu tiên trong intList:{intList.First(x => x % 2 == 11)}");
            }
            catch
            {
                WriteLine("không tìm thấy giá trị phù hợp");
            }
        }
        static void Bai1B(IList<int> intList)
        {
            // phần tử cuối cùng trong intList có giá trị > 200
            try
            {
                WriteLine($"phần tử cuối cùng trong intList có giá trị > 200: {intList.Last(x => x > 200)}");
            }
            catch
            {
                WriteLine("không tìm thấy giá trị phù hợp");
            }
        }
        static void Bai1C(IList<string> strList)
        {
            // phần tử đầu tiên trong strList có giá trị bắt đầu bằng ký tự “T”
          
                WriteLine("phần tử đầu tiên trong strList có giá trị bắt đầu bằng ký tự “T”:"
                        + strList.FirstOrDefault(s =>s != null &&  s.StartsWith("T")));
        }


        static void Bai1D(IList<int> intList)
        {
            //Tính tổng các trị tại vị trí index lẻ trong intList
            int sum = 0;
            for (var i = 0; i < intList.Count; i++)
            {
                if (i % 2 != 0) sum += intList.ElementAt(i);
            }
            WriteLine("Tính tổng các trị tại vị trí index lẻ trong intList:" + sum);
        }

        static void Bai2A(IList<Student> studentsList, IList<Standard> standardsList)
        {
            //Sử dụng Join Query viết chương trình để được kết quả xuất ra màn hình như sau
            var innerJoin = from student in studentsList
                            join standard in standardsList
                            on student.StudentId equals standard.StandardId
                            select new
                            {
                                StudentName = student.StudentName,
                                StandardName = standard.StandardName,
                            };
            innerJoin.ToList().ForEach(x => WriteLine($"{x.StudentName}\t{x.StandardName}"));
        }

        static void Bai2B(IList<Student> studentsList, IList<Standard> standardsList)
        {
            // Sử dụng GroupJoin viết chương trình để được kết quả xuất ra màn hình như sau
            var groupJoin = from std in standardsList
                            join s in studentsList
                            on std.StandardId equals s.StudentId
                            into studentGroup
                            select new
                            {
                                StandardName = std.StandardName,
                                Students = studentGroup,
                            };

            foreach (var item in groupJoin)
            {
                WriteLine(item.StandardName);
                foreach (var stu in item.Students)
                {
                    WriteLine(stu.StudentName);
                }
            }
        }

        static void Bai3(int[] little, int[] big)
        {
            // Bai1A: Sử dụng Union cho nguồn dữ liệu để xuất ra màn hình: 012345678910
            var bai1A = little.Union(big).ToList();
            WriteLine("-----------------Bai1A-----------------");
            bai1A.ForEach(x => Write(x));

            // Bai1B: Sử dụng Intersect cho nguồn dữ liệu để xuất ra màn hình: 56
            var bai1B = little.Intersect(big).ToList();
            WriteLine("\n-----------------Bai1B-----------------");
            bai1B.ForEach(x => Write(x));

            // Bai1C:  Sử dụng Concat cho nguồn dữ liệu để xuất ra màn hình: 01234565678910
            var bai1C = little.Concat(big).ToList();
            WriteLine("\n-----------------Bai1C-----------------");
            bai1C.ForEach(x => Write(x));

            // Bai1D:  Sử dụng Except cho nguồn dữ liệu để xuất ra màn hình: 01234
            var bai1D = little.Except(big).ToList();
            WriteLine("\n-----------------Bai1D-----------------");
            bai1D.ForEach(x => Write(x));
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            //data source
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            IList<Student> studentsList = new List<Student>()
            {
                new Student() {StudentId = 1, StudentName = "Yua Mikami", StandardId = 1},
                new Student() {StudentId = 2, StudentName = "Suzu Ichinose", StandardId = 1},
                new Student() {StudentId = 3, StudentName = "Emiri Suzuhara", StandardId = 1},
                new Student() {StudentId = 4, StudentName = "Nozomi Sasaki", StandardId = 1},
                new Student() {StudentId = 5, StudentName = "Erika momotari"},
            };
            IList<Standard> standardsList = new List<Standard>()
            {
                new Standard{StandardId = 1, StandardName = "Standard 1"},
                new Standard{StandardId = 2, StandardName = "Standard 2"},
                new Standard{StandardId = 3, StandardName = "Standard 3"},
            };

            int[] little = { 0, 1, 2, 3, 4, 5, 6 };
            int[] big = { 5, 6, 7, 8, 9, 10 };

            Bai1A(intList);
            // Bai1B(intList);
            // Bai1C(strList);
            // Bai1D(intList);

            // Bai2A(studentsList, standardsList);
            // Bai2B(studentsList, standardsList);

            // Bai3(little, big);
        }
    }
}
