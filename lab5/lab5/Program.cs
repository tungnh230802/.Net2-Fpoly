using System;
using System.Linq;
using static System.Console;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace lab5
{
    class Program
    {
        static void Bai1A(List<Contact> contacts)
        {
            //a/ Xuất ra màn hình danh sách các người có Address là “Ha Noi”
            var result = contacts.Where(x => x.Address == "Hà Nội");
            Display(result);
        }
        static void Bai1B(List<Contact> contacts)
        {
            //Tìm người có Age lớn nhất
            var MaxAge = contacts.Max(x => x.Age);
            var result = contacts.Where(x => x.Age == MaxAge);
            Display(result);
        }
        static void Bai1C(List<Contact> contacts)
        {
            //Cho biết danh sách contacts có bao nhiêu người?
            var Bai1C = contacts.Count();
            WriteLine($"danh sách có {Bai1C} người");
        }
        static void Bai2A(List<Contact> contacts)
        {
            //Sắp xếp danh sách contacts theo đô tuổi tăng dầ
            var result = contacts.OrderBy(x => x.Age);
            Display(result);
        }

        static void Bai2B(List<Contact> contacts)
        {
            //Sắp xếp danh sách contacts theo đô tuổi và Firstname giảm dần
            var result = contacts.OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);
            Display(result);
        }
        static void Bai2C(List<Contact> contacts) {
            //Liệt kê danh sách các người có FirstName băt đầu bằng ký tự “B
            var result = contacts.FindAll(x=>x.FirstName.StartsWith("B"));
            Display(result);
        }

        static void Bai3(List<Contact> contacts) {
            //Dùng LINQ ToLookup() Operator chuyển danh sách List<Contact> về định
            //dạng kiểu key/value và xuất toàn bộ thông tin ra màn hình
            var tlk = contacts.ToLookup(x=>x.Address);

            foreach(var KeyValuePair in tlk) {
                WriteLine($"Key value pair:{KeyValuePair.Key}");

                foreach(var item in tlk[KeyValuePair.Key]){
                    WriteLine($"\t-Full Name:{item.FirstName} {item.LastName}\t Tuổi:{item.Age}\tĐịa Chỉ:{item.Address}");
                }
            }
        }
        static void Display(dynamic result)
        {
            foreach (var item in result)
            {
                WriteLine($"Full Name:{item.FirstName,10} {item.LastName}, Age:{item.Age}, Address:{item.Address}");
            }
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;

            var contacts = new List<Contact>()
            {
                new Contact {Age = 11, FirstName = "Nguyễn Hoàng", LastName = "Tùng", Address = "Bình thuận"},
                new Contact {Age = 21, FirstName = "Nguyễn Trung Nhân", LastName = "Nhân", Address = "Mỹ Tho"},
                new Contact {Age = 51, FirstName = "Nguyễn Thị Kim", LastName = "Liên", Address = "Chợ Lầu"},
                new Contact {Age = 81, FirstName = "Hoàng Đình", LastName = "Tuấn", Address = "Bình An"},
                new Contact {Age = 22, FirstName = "Boàng Đình", LastName = "Tỵ", Address = "Hà Nội"},
                new Contact {Age = 41, FirstName = "Ngô Thị", LastName = "Tân", Address = "HCM"},
            };

            // Bai1A(contacts);
            // Bai1B(contacts);
            // Bai1C(contacts);
            // Bai2A(contacts);
            // Bai2B(contacts);
            Bai2C(contacts);
            // Bai3(contacts);
        }
    }
}
