using System;
using System.Text;
using static System.Console;

namespace ASM
{
    class Program
    {
        static void menu()
        {
            int chon;
            QuanLyHocSinh qlhs = new QuanLyHocSinh();
            do
            {
                Clear();
                Write("------------------------------------------------------------------------\n" +
                              "|1. nhập danh sách học viên                                            |\n" +
                              "|2. xuất danh sách học viên                                            |\n" +
                              "|3. tìm kiếm học viên theo điểm                                        |\n" +
                              "|4. tìm kiếm học viên theo học lực                                     |\n" +
                              "|5. tìm học viên theo mã số và cập nhật thông tin                      |\n" +
                              "|6. sắp xếp học viên theo1 điểm                                        |\n" +
                              "|7. xuất 5 học viên có điểm cao nhất                                   |\n" +
                              "|8. tính điểm trung bình lớp                                           |\n" +
                              "|9. xuất danh sách học viên có điểm trên trung bình                    |\n" +
                              "|10. tổng hợp số học viên theo học lực                                 |\n" +
                              "|0. thoát                                                              |\n" +
                              "------------------------------------------------------------------------\n");


                Write("chọn: ");
                var chose = Int32.TryParse(ReadLine(), out chon);
                chon = chose == false ? -1 : chon;
                if (chon == -1)
                {
                    WriteLine("-> Vui lòng chọn các chức năng từ 0 -> 10!!!");
                    ReadKey();
                }
                switch (chon)
                {
                    case 1:
                        qlhs.nhap();
                        break;
                    case 2:
                        qlhs.xuat();
                        ReadLine();
                        break;
                    case 3:
                        qlhs.TimKiemHocVienTheoDiem();
                        ReadLine();
                        break;
                    case 4:
                        qlhs.TimKiemHocVienTheoHocLuc();
                        ReadLine();
                        break;
                    case 5:
                        qlhs.TimHocVienTheoMaVaCapNhat();
                        ReadLine();
                        break;
                    case 6:
                        qlhs.SapXepHocVienTheoDiem();
                        ReadLine();
                        break;
                    case 7:
                        qlhs.Xuat5HocVienCoDiemCaoNhat();
                        ReadLine();
                        break;
                    case 8:
                        qlhs.TinhDiemTrungBinhCuaLop();
                        ReadLine();
                        break;
                    case 9:
                        qlhs.XuatDanhSachHocVienCoDiemTrenTB();
                        ReadLine();
                        break;
                    case 10:
                        qlhs.TongHopSoHocVienTheoHocLuc();
                        ReadLine();
                        break;
                    case 0:
                        WriteLine("Hẹn gặp lại!");
                        ReadKey();
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
        static void Main(string[] args)
        {

            OutputEncoding = Encoding.UTF8;
            menu();
        }
    }
}
