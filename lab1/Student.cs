using System;
using static System.Console;

namespace lab1
{
    public class Student
    {
        public static string StudentName;
        public static string Course;

        public void SetStudentDetail(string _StudentName, string _Course)
        {
            StudentName = _StudentName;
            Course = _Course;
        }

        public void DisplayStudentDetail()
        {
            WriteLine($"{StudentName} {Course}");
        }

        static string CollegeName = "FPT Polytechnic";
        static string CollegeAddress = "391A Nam Kỳ Khởi Nghĩa, Q. 3, TP. Hồ Chí Minh";

        public static void DisplayCollegeDetails()
        {
            WriteLine(CollegeName);
            WriteLine(CollegeAddress);
        }
    }
}