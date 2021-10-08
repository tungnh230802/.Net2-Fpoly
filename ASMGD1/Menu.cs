using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ASMGD1
{
    public class Menu
    {
        static string connection = @"Server=desktop-2v5f3ca\tungnh230802;Database=Asm_C#2;Trusted_Connection=True;";

        public static void menu()
        {
			Console.OutputEncoding = Encoding.UTF8;
            Yeucau yc = new Yeucau(connection);
            string chon;
            do
            {
                Clear();
                Write("\t\t\t----------------------------------MENU---------------------------------\n" +
                      "\t\t\t|1. nhập dữ liệu                                                       |\n" +
                      "\t\t\t|2. xuất dữ liệu                                                       |\n" +
                      "\t\t\t|3. tìm kiếm học viên                                                  |\n" +
                      "\t\t\t|4. cập nhật thông tin                                                 |\n" +
                      "\t\t\t|5. Xuất học viên theo thứ tự điểm                                     |\n" +
                      "\t\t\t|6. xuất 5 học viên có điểm cao nhất                                   |\n" +
                      "\t\t\t|7. xuất ra file                                                       |\n" +
                      "\t\t\t|8. xóa dữ liệu dữ liệu                                                |\n" +
                      "\t\t\t|0. thoát                                                              |\n" +
                      "\t\t\t------------------------------------------------------------------------\n");


                Write("\t\t\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        NhapDuLieu(yc);
                        break;
                    case "2":
                        XuatDuLieu(yc);
                        break;
                    case "3":
                        TimKiemHocVien(yc);
                        break;
                    case "4":
                        CapNhatDuLieu(yc);
                        break;
                    case "5":
                        XuatTheoDiem(yc);
                        break;
                    case "6":
                        yc.Yeucau06();
                        break;
                    case "7":
                        XuatRaFile(yc);
                        break;
                    case "8":
                        XoaDuLieu(yc);
                        break;
                    case "0":
                        WriteLine("\t\t\tHẹn gặp lại!");
                        ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("\t\t\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);
        }

        static void XuatRaFile(Yeucau yc)
        {

            string chon;
            do
            {
                Clear();
                WriteLine("\n\t------XUẤT RA FILE-------");
                WriteLine("\t1. Ghi dữ liệu bảng lớp ra file\n" +
                          "\t2. Ghi dữ liệu bảng students ra file\n" +
                          "\t3. Tính điểm trung bình từng lớp và xuất ra file\n" +
                          "\t0. thoát\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        Thread FileClass = new Thread(yc.YeuCau7XuatFileLop);
                        FileClass.IsBackground = true;
                        FileClass.Start();
                        WriteLine($"\n\tđã xuất ra file thành công. vui lòng kiểm tra file \"class.txt\" tại ổ \"D\"");
                        ReadKey();
                        break;
                    case "2":
                        Thread FileStudents = new Thread(yc.YeuCau7XuatFileStudents);
                        FileStudents.IsBackground = true;
                        FileStudents.Start();
                        WriteLine($"\n\tđã xuất ra file thành công. vui lòng kiểm tra file \"Studetns.txt\" tại ổ \"D\"");
                        ReadKey();
                        break;
                    case "3":
                        Thread DTB = new Thread(yc.Yeucau07);
                        DTB.IsBackground = true;
                        DTB.Start();
                        WriteLine($"\n\tđã xuất ra file thành công. vui lòng kiểm tra file \"DSDTB.txt\" tại ổ \"D\"");
                        ReadKey();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\t\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }

        static void XoaDuLieu(Yeucau yc)
        {

            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------XÓA DỮ LIỆU-------");
                WriteLine("\t1. xóa dữ liệu trong bảng lớp\n" +
                          "\t2. xóa dữ liệu trong bảng học viên\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.XoaDuLieuBangClass();
                        break;
                    case "2":
                        yc.XoaDuLieuBangStudent();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\t\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }

        static void XuatTheoDiem(Yeucau yc)
        {
            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------XUẤT HỌC VIÊN THEO ĐIỂM-------");
                WriteLine("\t1. Theo thứ tự giảm dần\n" +
                          "\t2. Theo thứ tự tăng dần\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.Yeucau05TuCaoDenThap();
                        break;
                    case "2":
                        yc.Yeucau05TuThapDenCao();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);
        }
        static void TimKiemHocVien(Yeucau yc)
        {

            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------TÌM KIẾM HỌC VIÊN-------");
                WriteLine("\t1. Theo điểm\n" +
                          "\t2. Theo học học lực\n" +
                          "\t3. Theo học Tên Học Viên\n" +
                          "\t4. Theo học Tên Lớp\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.Yeucau03TheoDiem();
                        break;
                    case "2":
                        yc.Yeucau03HocLuc();
                        break;
                    case "3":
                        yc.Yeucau03TimTheoTenHV();
                        break;
                    case "4":
                        yc.Yeucau03TimTheoTenLop();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }
        static void NhapDuLieu(Yeucau yc)
        {

            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------THÊM DỮ LIỆU-------");
                WriteLine("\t1. Thêm lớp\n" +
                          "\t2. Thêm học viên\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.Yeucau01AddClass();
                        break;
                    case "2":
                        yc.Yeucau01AddStudent();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\t\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }
        static void XuatDuLieu(Yeucau yc)
        {
            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------XUẤT DỮ LIỆU-------");
                WriteLine("\t1. Xuất danh sách lớp\n" +
                          "\t2. Xuất danh sách học viên\n" +
                          "\t3. Xuất danh sách học viên với tên lớp\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.Yeucau02GetClass();
                        break;
                    case "2":
                        yc.Yeucau02GetStudents();
                        break;
                    case "3":
                        yc.Yeucau02GetStudentWithNameClass();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }
        static void CapNhatDuLieu(Yeucau yc)
        {
            string chon;
            do
            {
                Clear();
                WriteLine("\n\t-------CẬP NHẬT DỮ LIỆU-------");
                WriteLine("\t1. Cập nhập thông tin lớp\n" +
                          "\t2. cập nhật thông tin học viên\n" +
                          "\t0. Trở lại Menu\n");
                Write("\tchọn chức năng: ");
                chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        yc.Yeucau04UpdateClass();
                        break;
                    case "2":
                        yc.Yeucau04UpdateStudent();
                        break;
                    case "0":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\t\thãy chọn đúng chức năng...");
                        ReadKey();
                        break;
                }
            } while (true);

        }
    }
}
