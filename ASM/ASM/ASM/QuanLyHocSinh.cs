using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ASM
{
    class QuanLyHocSinh
    {
        List<HocSinh> dsHS = new List<HocSinh>();


        public void nhap()
        {
            int continueImport;
            bool Exit;
            do
            {
                HocSinh hs = new HocSinh();
                var isDiem = false;

                WriteLine("-----------------------NHẬP THÔNG TIN SINH VIÊN-------------------------");

                do
                {
                    Write("Mã: ");
                    hs.ma = ReadLine();
                    if (string.IsNullOrEmpty(hs.ma)) WriteLine("Vui lòng không để trống...");
                } while (string.IsNullOrEmpty(hs.ma));

                do
                {
                    Write("Họ tên:");
                    hs.hoTen = ReadLine();
                    if (string.IsNullOrEmpty(hs.hoTen)) WriteLine("Vui lòng không để trống...");
                } while (string.IsNullOrEmpty(hs.hoTen));

                double diem;
                do
                {

                    Write("Điểm: ");
                    isDiem = Double.TryParse(ReadLine(), out diem);
                    diem = !isDiem ? -1 : diem;

                    if (!isDiem || diem > 10 || diem < 0)
                    {
                        WriteLine("Vui lòng nhập đúng điểm..");
                    }
                    else
                    {
                        hs.diem = diem;
                    }

                } while (!isDiem || diem > 10 || diem < 0);

                do
                {
                    Write("Email: ");
                    hs.email = ReadLine();
                    if (string.IsNullOrEmpty(hs.email)) WriteLine("Vui lòng không để trống...");
                } while (string.IsNullOrEmpty(hs.email));
                dsHS.Add(hs);
                do
                {
                    WriteLine("------------------------------------------------------------------------");
                    WriteLine("1. Nhập tiếp\t\t\t\t\t2.Thoát và lưu danh sách");
                    Exit = Int32.TryParse(ReadLine(), out continueImport);
                    if (!Exit) WriteLine("-> vui lòng chọn 1 hoặc 2!!!\n");
                } while (!Exit);
            } while (continueImport == 1);

        }

        public void xuat()
        {
            topTTSV();
            foreach (HocSinh hs in dsHS)
            {
                hs.xuat();
            }
            bottonTTSV();
        }

        public void TimKiemHocVienTheoDiem()
        {
            int hshl = 0;
            WriteLine("->Nhập khoảng điểm cần tìm");
            WriteLine("->Min: ");
            double min = double.Parse(ReadLine());
            WriteLine("->Max: ");
            double max = double.Parse(ReadLine());

            topTTSV();
            foreach (HocSinh hs in dsHS)
            {
                if (hs.diem >= min && hs.diem <= max)
                {
                    hs.xuat();
                    hshl++;
                }
            }
            bottonTTSV();
            if (hshl == 0)
            {
                WriteLine("->Không tìm thấy sinh viên nào trong khoãng {0} - {1}", min, max);
            }
        }

        public void TimKiemHocVienTheoHocLuc()
        {
            Write("Chọn học lực cần tìm:\n" +
                    "1. Xuất sác\t2. Giỏi\t3. Khá\t4. Trung bình\t5. Yếu\n" +
                    "Chọn: ");
            int ChonHocLuc = int.Parse(ReadLine());
            string HocLuc = null;
            int hshl = 0;
            switch (ChonHocLuc)
            {
                case 1:
                    HocLuc = "Xuất sắc";
                    break;
                case 2:
                    HocLuc = "Giỏi";
                    break;
                case 3:
                    HocLuc = "Khá";
                    break;
                case 4:
                    HocLuc = "Trung bình";
                    break;
                case 5:
                    HocLuc = "Yếu";
                    break;
            }
            topTTSV();
            foreach (HocSinh hs in dsHS)
            {
                if (hs.getHocLuc() == HocLuc)
                {
                    hs.xuat();
                    hshl++;
                }
            }
            bottonTTSV();
            if (hshl == 0)
            {
                WriteLine("-> Không tìm thấy học viên phù hợp");
            }
        }

        int compare(HocSinh hs1, HocSinh hs2)
        {
            if (hs1.diem < hs2.diem) return 1;
            if (hs1.diem > hs2.diem) return -1;
            return 0;

        }
        public void SapXepHocVienTheoDiem()
        {
            WriteLine("-> Đã sắp xếp học viên theo điểm");
            dsHS.Sort(compare);
        }

        public void TimHocVienTheoMaVaCapNhat()
        {
            int hshl = 0;
            string maCanTim;
            do
            {
                Write("nhập mã cần tìm: ");
                maCanTim = ReadLine();
                if (string.IsNullOrEmpty(maCanTim)) WriteLine("Vui lòng không để trống!");
            } while (string.IsNullOrEmpty(maCanTim));
            foreach (HocSinh hs in dsHS)
            {
                if (maCanTim == hs.ma)
                {

                    hshl++;
                    var isDiem = false;
                    do
                    {
                        Write("Mã: ");
                        hs.ma = ReadLine();
                        if (string.IsNullOrEmpty(hs.ma)) WriteLine("Vui lòng không để trống...");
                    } while (string.IsNullOrEmpty(hs.ma));

                    do
                    {
                        Write("Họ tên:");
                        hs.hoTen = ReadLine();
                        if (string.IsNullOrEmpty(hs.hoTen)) WriteLine("Vui lòng không để trống...");
                    } while (string.IsNullOrEmpty(hs.hoTen));

                    double diem;
                    do
                    {

                        Write("Điểm: ");
                        isDiem = Double.TryParse(ReadLine(), out diem);
                        diem = !isDiem ? -1 : diem;

                        if (!isDiem || diem > 10 || diem < 0)
                        {
                            WriteLine("Vui lòng nhập đúng điểm..");
                        }
                        else
                        {
                            hs.diem = diem;
                        }

                    } while (!isDiem || diem > 10 || diem < 0);

                    do
                    {
                        Write("Email: ");
                        hs.email = ReadLine();
                        if (string.IsNullOrEmpty(hs.email)) WriteLine("Vui lòng không để trống...");
                    } while (string.IsNullOrEmpty(hs.email));
                    WriteLine("-> đã cập nhật thông tin!");
                }
                break;
            }
            if (hshl == 0) WriteLine("-> Không tìm thấy sinh viên có mã: " + maCanTim);
        }

        public void Xuat5HocVienCoDiemCaoNhat()
        {
            int soLanXuat = 0;
            SapXepHocVienTheoDiem();
            WriteLine("-> 5 Sinh viên có điểm cao nhất");
            topTTSV();
            foreach (HocSinh hs in dsHS)
            {
                hs.xuat();
                soLanXuat++;
                if (soLanXuat == 5)
                    break;
            }
            bottonTTSV();
        }

        public void TinhDiemTrungBinhCuaLop()
        {
            double sum = 0;
            double diemTB = 0;
            int dem = 0;
            foreach (HocSinh hs in dsHS)
            {
                sum += hs.diem;
                dem++;
            }
            diemTB = sum / dem;
            WriteLine("-> điểm trung bình của lớp là: " + diemTB);
        }

        public void XuatDanhSachHocVienCoDiemTrenTB()
        {
            WriteLine("-> danh sách học viên có điểm trên trung bình");
            topTTSV();
            foreach (HocSinh hs in dsHS)
            {
                if (hs.diem >= 5)
                {
                    hs.xuat();
                }
            }
            bottonTTSV();
        }

        public void TongHopSoHocVienTheoHocLuc()
        {
            int xuatSac = 0, gioi = 0, kha = 0, trungBinh = 0, yeu = 0;
            WriteLine("tổng hợp số học viên theo học lực");
            foreach (HocSinh hs in dsHS)
            {
                if (hs.getHocLuc() == "Xuất sắc")
                {
                    xuatSac++;
                }
                if (hs.getHocLuc() == "Giỏi")
                {
                    gioi++;
                }
                if (hs.getHocLuc() == "Khá")
                {
                    kha++;
                }
                if (hs.getHocLuc() == "Trung bình")
                {
                    trungBinh++;
                }
                if (hs.getHocLuc() == "Yếu")
                {
                    yeu++;
                }
            }
            WriteLine("có {0} Học viên xuất sắc:\n" +
                              "->có {1} Học viên giỏi\n" +
                              "->có {2} học viên khá\n" +
                              "->có {3} học viên trung bình\n" +
                              "->có {4} học viên yếu", xuatSac, gioi, kha, trungBinh, yeu);
        }
        static void topTTSV()
        {
            WriteLine("----------------------------------------------THÔNG TIN SINH VIÊN----------------------------------------------");
            WriteLine($"| {"Mã",10} | {"Họ Tên",40} | {"Điểm",5} | {"Email",30} | {"Học lực",10} |");
        }
        static void bottonTTSV()
        {
            WriteLine("---------------------------------------------------------------------------------------------------------------");
        }

    }
}

