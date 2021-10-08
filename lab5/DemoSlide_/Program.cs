using System;
using System.Linq;
using static System.Console;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace DemoSlide_
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // cá màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(", ", Colors)}";
    }

    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Demo1()
        {
            int[] Num = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] charList = { "a", "b", "c", "d" };
            WriteLine("số nhỏ nhất: " + Num.Min());
            WriteLine("tổng: " + Num.Sum());
            WriteLine("tích: " + Num.Aggregate((a, b) => a * b));
            WriteLine("nối chuôi: " + charList.Aggregate((a, b) => a + ", " + b));
        }
        static void Demo2()
        {
            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            // var ProductName = products.OrderBy(x => x.Name);
            // ProductName.ToList().ForEach(x=>WriteLine(x));
            var ProductIDsortDes = products.OrderByDescending(x => x.ID);
            ProductIDsortDes.ToList().ForEach(x => WriteLine(x));
            var ProductSort = products.OrderBy(x => x.Name).ThenBy(x => x.ID);
            ProductSort.ToList().ForEach(x => WriteLine(x));
        }
        static void Demo3()
        {
            string[] words = { "cherry", "apple", "blueberry" };
            // var wordSortByLength = from word in words
            //                         orderby word.Length descending
            //                         select word;
            // wordSortByLength.ToList().ForEach(x=>WriteLine(x)); 

            var result = words.Take(1);
            Display(result);
        }
        static void Display(dynamic result)
        {
            foreach (var item in result)
            {
                WriteLine(item);
            }
        }
        static void Demo4()
        {
            string[] countries = { "US", "UK", "China", "Australia", "Argentina" };

            var result = countries.TakeWhile(x=>x.StartsWith("A"));
            // var result =  countries.Skip(3);
            // var result = countries.SkipWhile(x => x.StartsWith("U"));
            Display(result);
        }

        static void Demo5()
        {
            List<Employee> objEmpoyee = new List<Employee>()
            {
                new Employee() {Name = "tùng", Department ="Marketing", Country="India"},
                new Employee() {Name = "tuấn", Department = "IT", Country = "UK"},
                new Employee() {Name = "oanh", Department = "Sales", Country = "US"},
            };

            // var emp = objEmpoyee.ToLookup(x => x.Department);

            // WriteLine("gộp employee từ Department");
            // WriteLine("----------------------------");
            // foreach (var KeyValuePair in emp)
            // {
            //     WriteLine("Key: " +KeyValuePair.Key);

            //     foreach (var item in emp[KeyValuePair.Key])
            //     {
            //         WriteLine($"\t {item.Name} \t {item.Department} \t {item.Country}");
            //     }
            // }

            var obj = objEmpoyee.ToDictionary(x=>x.Country, x=>x.Name);
            foreach(var item in obj) {
                WriteLine(item.Key + "\t" + item.Value);
            }
        }

        static void Demo6() {
            ArrayList obj = new ArrayList();
            obj.Add("india");
            obj.Add("UK");
            obj.Add("US");
            obj.Add(1);

            // IEnumerable<string> result = obj.Cast<string>();
            IEnumerable<int> result = obj.OfType<int>();
            Display(result);
        }
        static void Demo7() {
            int[] NumArray = new int[] {1,2,3,4,5};

            var result = NumArray.AsEnumerable();

            Display(result);
        }
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            // Demo1();
            // Demo2();
            Demo4();
            // Demo5();
            // Demo7();
        }
    }
}
