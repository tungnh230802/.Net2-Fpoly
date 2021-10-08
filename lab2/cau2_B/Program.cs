using System;
using static System.Console;
using System.Text;

namespace cau2_B
{
    class Program
    {
        static void Main(string[] args)
          {
            OutputEncoding = Encoding.UTF8;
            var UserInfo = new
            {
                Id = 1,
                Name = "Nguyễn Hoàng Tùng",
                isActive = true,
                jobInfor = new {Designation = "Lead", Location = "Hyderabad"}
            };

            WriteLine($"Id: {UserInfo.Id}");
            WriteLine($"Name: {UserInfo.Name}");
            WriteLine($"isActive: {UserInfo.isActive}");
            WriteLine($"Designation: {UserInfo.jobInfor.Designation}, Location: {UserInfo.jobInfor.Location}");
        }
    }
}
