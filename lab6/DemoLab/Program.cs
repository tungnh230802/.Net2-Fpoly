using System;
using System.Linq;
using static System.Console;
using System.Text;
using System.Collections.Generic;
using System.Collections;


namespace DemoLab
{
    class Program
    {
        static void Demo1()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            IList<string> strList = new List<string>() { null, "true", "Three", "four", "tung", null };
            IList<int> intList2 = new List<int>() { };
            // WriteLine("1st Element in inList: " + intList.First());
            // WriteLine("1st Element in inList: " + intList.First(x=>x%2 == 0));
            // nếu không tìm thấy giá trị thõa đk sẽ trả về exception
            // int result = intList.FirstOrDefault();
            // string val = strList.FirstOrDefault();
            // int val2 = intList2.FirstOrDefault();
            // WriteLine(result);
            // WriteLine(val);
            // WriteLine(val2);

            // int result = (from l in intList select l).FirstOrDefault(i=>i >7);
            // WriteLine(result);
            /*
            ❖Trả về giá trị cuối cùng trong danh sách/tập hợp
            ❖Trả về giá trị mặc định khi tập hợp/ danh sách rỗng
            hoặc giá trị không tìm thấy
            ❖Nếu phần tử cuối cùng trong danh sách/tập hơp là
            null và sử dụng LINQ LastOrDefault có điều kiện sẽ
            gây ra exception
            */
            // WriteLine(strList.LastOrDefault(i=>i.Contains("t")));
            // WriteLine(strList.ElementAtOrDefault(22));
        }
        static void Demo2()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            IList<string> strList = new List<string>() { null, "true", "Three", "four", "tung", null };
            IList<int> intList2 = new List<int>() { };
            IList<int> oneElement = new List<int>() { 7 };
            // WriteLine(oneElement.SingleOrDefault());
            // WriteLine(intList.SingleOrDefault(i=>i<6));
            /*
            Trả về chỉ một phần tử có hoặc không có điều kiện
            trong danh sách/tập hợp
            ❖Trả về exception “InvalidOperationException” nếu có
            nhiều hơn một phần tử thỏa điều kiện hoặc danh
            sách/tập hợp chứa nhiều hơn một phần tử
            ❖Trả về giá trị mặc định khi không có phần tử nào thỏa
            điều kiện
            */
            var result = strList.DefaultIfEmpty();
            result.ToList().ForEach(x => WriteLine(x));
        }

        static void Demo3()
        {
            List<Department> objDep = new List<Department>()
            {
                new Department{DepID = 1, DepName = "SorfWare"},
                new Department{DepID = 2, DepName = "Finance"},
                new Department{DepID = 3, DepName = "Health"},
            };

            List<Employee> objEmp = new List<Employee>()
            {
                new Employee{EmpID = 1, Name = "Suresh Dasari", DepId = 1},
                new Employee{EmpID = 2, Name = "Rohini Alvata", DepId = 1},
                new Employee{EmpID = 3, Name = "Suzu ichinose", DepId = 2},
                new Employee{EmpID = 4, Name = "Yua mikami", DepId = 2},
                new Employee{EmpID = 5, Name = "Fukada"},
            };

            // var result = from d in objDep
            //             join e in objEmp on d.DepID equals e.EmpID
            //             select new {
            //                 EmployeeName = e.Name,
            //                 DepartmentName = d.DepName
            //             };
            // result.ToList().ForEach(x=>WriteLine($"{x.EmployeeName} \t {x.DepartmentName}"));

            // var result = from e in objEmp
            //              join d in objDep
            //              on e.EmpID equals d.DepID into empDept
            //              from ed in empDept.DefaultIfEmpty()
            //              select new
            //              {
            //                  EmployeeName = e.Name,
            //                  DepartmentName = ed == null ? "No Department" : ed.DepName
            //              };
            // result.ToList().ForEach(x => WriteLine($"{x.EmployeeName} \t {x.DepartmentName}"));

            var result = from d in objDep
                         join e in objEmp on d.DepID equals e.DepId into empDept
                         select new
                         {
                             DepartmentName = d.DepName,
                             Employees = from emp2 in empDept
                                         orderby emp2.Name
                                         select emp2
                         };
            int totolItem = 0;
            foreach (var empGroup in result)
            {
                WriteLine(empGroup.DepartmentName);
                foreach (var item in empGroup.Employees)
                {
                    totolItem++;
                    WriteLine("\t{0}", item.Name);
                }
            }

        }
        static void Main(string[] args)
        {
            // Demo1();
            // Demo2();
            Demo3();
        }
    }
}
