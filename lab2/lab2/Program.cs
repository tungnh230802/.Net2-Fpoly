// using System;
// using static System.Console;

// namespace cau1_A
// {
//     class Program
//     {
//         static dynamic imp = 15;
//         static void Main(string[] args)
//         {
//             WriteLine(imp);
//         }
//     }
// }

var data = new int[]{23,23,23};

// using System;
// using static System.Console;
// using System.Collections;
// using System.Collections.Generic;

// namespace cau1_B
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var data = new Dictionary<string, int>();
//             data.Add("cat", 2);
//             data.Add("dog", 1);
            
//             WriteLine("cat - dog = {0}",
//             data["cat"] - data["dog"]);
//         }
//     }
// }

// using System;

// namespace cau1_C
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             GetDetail(100);
//             GetDetail("welcome to Fpoly");
//             GetDetail(true);
//             GetDetail(20.50);
//         }

//         static void GetDetail(dynamic d)
//         {
//             WriteLine(d);
//         }
//     }
// }

// using System;
// using static System.Console;

// namespace cau1_D
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             dynamic dobj = new User();
//             dynamic a = 10;
//             dobj.GetDetail(a);
//         }

//     }
//     class User 
//     {
//         public int ID {get;set;}
//         public string Name {get;set;}
//         public void GetDetail(dynamic d) {
//             WriteLine(d);
//         }
//     }
// }

// using System;
// using static System.Console;
// using System.Text;

// namespace cau2_A
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             OutputEncoding = Encoding.UTF8;
//             var UserInfo = new
//             {
//                 Id = 1,
//                 Name = "Nguyễn Hoàng Tùng",
//                 isActive = true
//             };

//             WriteLine($"Id: {UserInfo.Id}");
//             WriteLine($"Name: {UserInfo.Name}");
//             WriteLine($"isActive: {UserInfo.isActive}");
//         }
//     }
// }

// using System;
// using static System.Console;
// using System.Text;

// namespace cau2_B
// {
//     class Program
//     {
//         static void Main(string[] args)
//           {
//             OutputEncoding = Encoding.UTF8;
//             var UserInfo = new
//             {
//                 Id = 1,
//                 Name = "Nguyễn Hoàng Tùng",
//                 isActive = true,
//                 jobInfor = new {Designation = "Lead", Location = "Hyderabad"}
//             };

//             WriteLine($"Id: {UserInfo.Id}");
//             WriteLine($"Name: {UserInfo.Name}");
//             WriteLine($"isActive: {UserInfo.isActive}");
//             WriteLine($"Designation: {UserInfo.jobInfor.Designation}, Location: {UserInfo.jobInfor.Location}");
//         }
//     }
// }

// using System;
// using System.Text;
// using static System.Console;
// namespace cau2_C
// {
//     class Program
//     {
//         public delegate void MathOps(int a);
//         static void Main(string[] args)
//         {
//             OutputEncoding = Encoding.UTF8;
//             int y = 10;

//             MathOps ops = delegate (int x)
//             {
//                 WriteLine("phép cộng: {0}", x + y);
//                 WriteLine("phép trừ: {0}", x - y);
//             };
//             ops(90);
//         }
//     }
// }
