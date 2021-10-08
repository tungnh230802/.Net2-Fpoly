using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ASM
{
    class HocSinh
    {
        public string ma { set; get; }
        public string hoTen { get; set; }
        public double diem { get; set; }
        public string email { get; set; }
        public HocSinh() { }

        public HocSinh(string hoTen, double diem, string email)
        {
            this.hoTen = hoTen;
            this.diem = diem;
            this.email = email;
        }
        public string getHocLuc()
        {
            if (diem >= 9.5) return "Xuất sắc";
            if (diem >= 7.5) return "Giỏi";
            if (diem >= 6.5) return "Khá";
            if (diem >= 5) return "Trung bình";
            return "Yếu";
        }

        public void xuat()
        {
            WriteLine($"| {ma,10} | {hoTen,40} | {diem,5} | {email, 30} | {getHocLuc(),10} |");
        }
    }
}
