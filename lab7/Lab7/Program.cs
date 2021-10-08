using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Text;

namespace Lab7
{
    class Program
    {     

       

        //static void Bai2c()
        //{
        //    using (var db = new lab7DBDataContext(@"Data Source=desktop-2v5f3ca\tungnh230802;Initial Catalog=northwind;
        //         Integrated Security=true"))
        //    {
        //        var customer = db.Customers
        //                            .Where(c=>c.CustomerID == "Fpoly")
        //                            .FirstOrDefault();
        //        if (customer != null)
        //        {
        //            customer.CompanyName = "FE";
        //            db.SubmitChanges();

        //            WriteLine("Cập nhật dữ liệu thành công");

        //            var customers = db.Customers.ToList().Where(x => x.CustomerID == "Fpoly");

        //            foreach (var item in customers)
        //            {
        //                WriteLine(item.CustomerID + "\t" + item.CompanyName);
        //            }
        //        }
        //        else
        //        {
        //            WriteLine("không tìm thấy id Fpoly");
        //        }
        //    }
        //}

        //static void Bai2d()
        //{
        //    using (var db = new lab7DBDataContext(@"Data Source=desktop-2v5f3ca\tungnh230802;Initial Catalog=northwind;
        //         Integrated Security=true"))
        //    {
        //        var customer = db.Customers
        //                            .Where(c => c.CustomerID == "ALFKI")
        //                            .FirstOrDefault();
        //        if (customer != null)
        //        {
        //            db.Customers.DeleteOnSubmit(customer);
        //            try
        //            {
        //                db.SubmitChanges();
        //                WriteLine("xóa dữ liệu thành công");

        //            }
        //            catch
        //            {
        //                WriteLine("không thể xóa!");
        //            }
        //        }
        //        else
        //        {
        //            WriteLine("không tìm thấy customer id alfki");
        //        }
        //        }
        //}

        static void Bai1_1(List<Contact> contacts)
        {
            // 1. In danh sách những người ở “Da Nang”
            var result = contacts.Where(x => x.Address == "Đà Nẵng" || x.Address == "Sài Gòn");

            foreach (var item in result)
            {
                WriteLine($"Full Name:{item.FirstName,10} {item.LastName}, Age:{item.Age}, Address:{item.Address}");
            }
        }

        static void Bai1_2(List<Contact> contacts)
        {
            //2.In tổng số người trong danh sác
            var result = contacts.Count();
            WriteLine($"tổng số người trong danh sách là: {result}");
            
        }

        static void Bai1_3(List<Contact> contacts)
        {
            // 3. In sách sách theo thứ tự tuổi từ lớn đến nhỏ
            var result = contacts.OrderByDescending(x => x.Age);

            foreach (var item in result)
            {
                WriteLine($"Full Name:{item.FirstName,10} {item.LastName}, Age:{item.Age}, Address:{item.Address}");
            }
        }

        static void Bai1_4(List<Contact> contacts)
        {
            // 4. In người nhỏ tuổi nhất trong danh sách
            var result = contacts.OrderBy(x => x.Age).Take(1);

            foreach (var item in result)
            {
                WriteLine($"Full Name:{item.FirstName,10} {item.LastName}, Age:{item.Age}, Address:{item.Address}");
            }
        }

        static void Bai1_5(List<Contact> contacts)
        {
            // 5. In những người có tên bắt đầu bằng chữ “T”.
            var result = contacts.Where(x => x.FirstName.StartsWith("T"));

            foreach (var item in result)
            {
                WriteLine($"Full Name:{item.FirstName,10} {item.LastName}, Age:{item.Age}, Address:{item.Address}");
            }
        }

        static void Bai2_1()
        {
            using (var db = new lab7DBDataContext(@"Data Source=desktop-2v5f3ca\tungnh230802;Initial Catalog=northwind;
                 Integrated Security=true"))
            {
                var customers = db.Customers.ToList();

                foreach (var item in customers)
                {
                    WriteLine($"Contact Name: {item.ContactName}");
                }
            }
        }

        static void Bai2_2()
        {
            using (var db = new lab7DBDataContext(@"Data Source=desktop-2v5f3ca\tungnh230802;Initial Catalog=northwind;
                 Integrated Security=true"))
            {

                var customer = new Customer()
                {
                    CustomerID = "Fpoly",
                    CompanyName = "FPT",
                };

                try
                {

                    db.Customers.InsertOnSubmit(customer);
                    db.SubmitChanges();
                }
                catch
                {
                }

                WriteLine("thêm dữ liệu thành công");

                var customers = db.Customers.ToList().Where(x => x.CustomerID == "Fpoly");

                    foreach (var item in customers)
                    {
                        WriteLine(item.CustomerID + "\t" + item.CompanyName);
                    }
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
                new Contact {Age = 81, FirstName = "Toàng Đình", LastName = "Tuấn", Address = "Đà Nẵng"},
                new Contact {Age = 22, FirstName = "Boàng Đình", LastName = "Tỵ", Address = "Đà Nẵng"},
                new Contact {Age = 41, FirstName = "Ngô Thị", LastName = "Tân", Address = "HCM"},
            };

            //Bai1_1(contacts);
            //Bai1_2(contacts);
            //Bai1_3(contacts);
            //Bai1_4(contacts);
            //Bai1_5(contacts);

            Bai2_1();
            Bai2_2();
            ReadLine();
        }
    }
}
