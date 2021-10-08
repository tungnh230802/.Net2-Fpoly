using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ASMGD1
{
    public class Yeucau
    {
        private string _connection;
        public Yeucau(string connection)
        {
            _connection = connection;
        }
        ~Yeucau()
        {
            _connection = null;
        }

        /// <summary>
        /// thêm lớp học
        /// </summary>
        public void Yeucau01AddClass()
        {
            Console.Clear();

            var lophoc = new Lophoc(_connection);

            do
            {
                WriteLine("\n\t------------THÊM LỚP------------");


                string nameClass;
				
				// kiểm tra rỗng
                do
                {
                    Write("\tTên Lớp:");
                    nameClass = ReadLine();
                    if (string.IsNullOrEmpty(nameClass)) WriteLine("\tVui lòng không để trống...");
                } while (string.IsNullOrEmpty(nameClass));
    
            
                lophoc.InsertLophoc(nameClass);

                WriteLine("\n\t----------------------------------------------------");
                WriteLine("\t1. Nhập tiếp    2. Nhập học viên    3. Quay lại menu");
                do
                {
                    Write("\tchọn chức năng: ");

                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau01AddClass();
                            break;
                        case "2":
                            Yeucau01AddStudent();
                            break;
                        case "3":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);
        }

        /// <summary>
        /// thêm học viên
        /// </summary>
        public void Yeucau01AddStudent()
        {
            Console.Clear();

            var hocvien = new HocVien(_connection);

            do
            {
                WriteLine("\n\t------------THÊM HỌC VIÊN------------");

                bool isSimilar;
                string name;
                double mark;
                string email;
                int classId_;
                bool isNum;
                bool isEmail;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
				
				
				// kiểm tra tên hv có rỗng hoặc giống nhau
                do
                {
                    Write("\tTên Học Viên:");
                    name = ReadLine();

                    // Kiểm tra tên trung nhau
                    using (var db = new ASMDBDataContext(_connection))
                    {
                        var student = db.Students.ToList();

                        try {
                            var result = (from s in student
                                          where s.Name == name
                                          select s)
                                         .First();
                            isSimilar = true;
                        }
                        catch {
                            isSimilar = false;
                        }
                        }
                    if (string.IsNullOrEmpty(name)) 
                    {
                        WriteLine("\tVui lòng không để trống tên...");
                    }
                    else if (isSimilar)
                    {
                        WriteLine("\tTên này đã có trong dữ liệu");
                    }

                } while (string.IsNullOrEmpty(name) || isSimilar);
				
				// kiểm tra điểm 
                do
                {
                    Write("\tĐiểm:");
                    isNum = double.TryParse(ReadLine(), out mark);

                    if (isNum == false)
                    {
                        WriteLine("\tvui lòng đúng định dạng số");
                    }
                    else if (mark > 10 || mark < 0)
                    {
                        WriteLine("\tvui lòng nhập điểm từ 1 - 10");
                        isNum = false;
                    }
                } while (!isNum);

				// kiểm tra có đúng định dạng email không
                do
                {
                    isEmail = true;
                    Write("\tEmail:");
                    email = ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        WriteLine("\tVui lòng không để trống...");
                        isEmail = false;
                    }else if (!re.IsMatch(email))
                    {
                        WriteLine("\tvui lòng nhập đúng email");
                        isEmail = false;
                    }
                  
                } while (!isEmail);

				// kiểm tra id phải là số không
                do
                {
                    Write("\tID lớp:");
                    isNum = int.TryParse(ReadLine(), out classId_);

                    // kiểm tra xem idclass hợp lệ không
                    using (var db = new ASMDBDataContext(_connection))
                    {
                        var _class = db.Classes.ToList();

                        try
                        {
                            var result = (from c in _class
                                          where c.IdClass == classId_
                                          select c)
                                         .First();
                            isSimilar = true;
                        }
                        catch
                        {
                            isSimilar = false;
                        }
                    }
                    if (!isNum)
                    {
                        WriteLine("\tvui lòng nhập đúng định dạng số...");
                    }
                    else if (!isSimilar)
                    {
                        WriteLine("\tIdClass này không có trong bảng class");
                    }
                } while (!isNum || !isSimilar);


				// thêm dữ liệu vào bảng
                hocvien.InssertHocVien(name, mark, email, classId_);
				
				// chọn các chức năng khác
                WriteLine("\n\t-----------------------------------------------");
                WriteLine("\t1. Nhập tiếp    2. Nhập Lớp    3. Quay lại menu");

                do
                {
                    Write("\tchọn chức năng: ");
                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau01AddStudent();
                            break;
                        case "2":
                            Yeucau01AddClass();
                            break;
                        case "3":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng");
                            break;
                    }
                } while (true);
            } while (true);
        }

        
        /// <summary>
        /// xuất ra Class
        /// </summary>
        public void Yeucau02GetClass()
        {
            Console.Clear();
            var lophoc = new Lophoc(_connection);
            var list = lophoc.GetListLophoc();

            Console.WriteLine("\n\t----------------DANH SÁCH LỚP----------------");
            Console.WriteLine($"\t{"Mã số",-20} | {"Tên lớp",-40}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.IdClass,-20} | {item.NameClass,-40}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        /// <summary>
        /// xuất ra học viên
        /// </summary>
        public void Yeucau02GetStudents()
        {
            Console.Clear();
            var hocvien = new HocVien(_connection);
            var list = hocvien.GetListStudents();

            Console.WriteLine("\n\t-------------------------------------------DANH SÁCH HỌC VIÊN------------------------------------------");
            Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm", -5} | {"Học lực",-10} | {"Email",-30} | {"Id Lớp", -10}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// lấy ra bảng student với tên class
        /// </summary>
        public void Yeucau02GetStudentWithNameClass()
        {
            Console.Clear();
            var hocvien = new HocVien(_connection);
            var lop = new Lophoc(_connection);
            var list = from s in hocvien.GetListStudents()
                       join l in lop.GetListLophoc()
                       on s.IdClass equals l.IdClass
                       select new
                       {
                           StId = s.StId,
                           Name = s.Name,
                           Mark = s.Mark,
                           Email = s.Email,
                           l.NameClass,
                       };

            Console.WriteLine("\n\t-------------------------------------------DANH SÁCH HỌC VIÊN------------------------------------------");
            Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-10} | {"Email",-30} | {"Tên Lớp",-10}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.NameClass,-10}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// tìm sv theo điểm
        /// </summary>
        public void Yeucau03TheoDiem()
        {
            Clear();
            bool isNum;
            double min;
            double max;
            do
            {
                WriteLine("\n\t------------TÌM SINH VIÊN THEO ĐIỂM------------");

                do
                {
                    Write("\tNhập min điểm:");
                    isNum = double.TryParse(ReadLine(), out min);
                    if (isNum == false)
                    {
                        WriteLine("\tvui lòng đúng định dạng số");
                    }
                    else if (min > 10 || min < 0)
                    {
                        WriteLine("\tvui lòng nhập điểm từ 1 - 10");
                        isNum = false;
                    }

                } while (!isNum);
                do
                {
                    Write("\tNhập max điểm:");
                    isNum = double.TryParse(ReadLine(), out max);
                    if (isNum == false)
                    {
                        WriteLine("\tvui lòng đúng định dạng số");
                    }
                    else if (max > 10 || max < 0)
                    {
                        WriteLine("\tvui lòng nhập điểm từ 1 - 10");
                        isNum = false;
                    }

                } while (!isNum);
                if(min > max)
                {
                    WriteLine($"\n\tmax phải lơn hơn min! vui lòng nhập lại..");
                    ReadKey();
                    Clear();
                }
            } while (min > max);

            var hocvien = new HocVien(_connection);
            var list = hocvien.GetListStudents().Where(x => x.Mark >= min && x.Mark <= max);

            if (list.Count() == 0)
            {
                WriteLine($"\n\tKhông tìm thấy kết quả phù hợp trong khoãng {min} đến {max}.");
            }
            else
            {

                WriteLine($"\n\tDanh sách học viên có điểm từ {min} đến {max}:");
                Console.WriteLine("\n\t---------------------------------------DANH SÁCH HỌC VIÊN--------------------------------------");
                Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-8} | {"Email",-30} | {"Id Lớp",-10}");
                foreach (var item in list)
                {
                    Thread.Sleep(1);
                    Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
                }
            }
            do { 
            Console.WriteLine();
            Console.ReadLine();
            WriteLine("\t-----------------------------------------------------");
            WriteLine("\t1. tiếp tục sử dụng chức năng này    2. Quay lại menu");

            do
            {
                Write("\tchọn chức năng: ");
                string chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        Yeucau03TheoDiem();
                        break;
                    case "2":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy nhập đúng chức năng.");
                        break;
                }
            } while (true);
        } while(true);

        }

        /// <summary>
        /// tìm học viên theo tên hv
        /// </summary>
        public void Yeucau03TimTheoTenHV()
        {
            Clear();
            string findName;

            WriteLine("\n\t------------TÌM SINH VIÊN THEO TÊN------------");

                do
                {
                    Write("\tNhập tên học viên muốn tìm:");
                    findName = ReadLine();
                if (string.IsNullOrEmpty(findName))
                {
                    WriteLine("vui lòng không để trống phần này!");
                }else
                {
                    break;
                }
                } while (true);
         

            var hocvien = new HocVien(_connection);
            var list = hocvien.GetListStudents().Where(x => x.Name == findName);

            if (list.Count() == 0)
            {
                WriteLine($"\n\tKhông tìm thấy học viên nào có tên là {findName}");
            }
            else
            {

                WriteLine($"\n\tđã tìm thấy thông tin học viên có tên là {findName}");
                Console.WriteLine("\n\t---------------------------------------DANH SÁCH HỌC VIÊN--------------------------------------");
                Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-8} | {"Email",-30} | {"Id Lớp",-10}");
                foreach (var item in list)
                {
                    Thread.Sleep(1);
                    Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
                }
            }
            do
            {
                Console.WriteLine();
                Console.ReadLine();
                WriteLine("\t-----------------------------------------------------");
                WriteLine("\t1. tiếp tục sử dụng chức năng này    2. Quay lại menu");

                do
                {
                    Write("\tchọn chức năng: ");
                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau03TimTheoTenHV();
                            break;
                        case "2":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);

        }

        /// <summary>
        /// tìm học viên theo tên lớp
        /// </summary>
        public void Yeucau03TimTheoTenLop()
        {
            Clear();
            string findNameClass;

            WriteLine("\n\t------------TÌM SINH VIÊN THEO TÊN LỚP------------");

            do
            {
                Write("\tNhập tên lớp:");
                findNameClass = ReadLine();
                if (string.IsNullOrEmpty(findNameClass))
                {
                    WriteLine("vui lòng không để trống phần này!");
                }
                else
                {
                    break;
                }
            } while (true);


            var hocvien = new HocVien(_connection);
            var lop = new Lophoc(_connection);
            var list = from s in hocvien.GetListStudents()
                       join l in lop.GetListLophoc()
                       on s.IdClass equals l.IdClass
                       where l.NameClass == findNameClass
                       select new
                       {
                           StId = s.StId,
                           Name = s.Name,
                           Mark = s.Mark,
                           Email = s.Email,
                           NameClass = l.NameClass,
                       };

            if (list.Count() == 0)
            {
                WriteLine($"\n\tKhông tìm thấy học viên nào trong lớp {findNameClass}");
            }
            else
            {

                WriteLine($"\n\tđã tìm thấy thông tin học viên các học viên trong lớp \"{findNameClass}\"");
                Console.WriteLine("\n\t---------------------------------------DANH SÁCH HỌC VIÊN--------------------------------------");
                Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-8} | {"Email",-30} | {"Tên Lớp",-10}");
                foreach (var item in list)
                {
                    Thread.Sleep(1);
                    Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.NameClass,-10}");
                }
            }
            do
            {
                Console.WriteLine();
                Console.ReadLine();
                WriteLine("\t-----------------------------------------------------");
                WriteLine("\t1. tiếp tục sử dụng chức năng này    2. Quay lại menu");

                do
                {
                    Write("\tchọn chức năng: ");
                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau03TimTheoTenLop();
                            break;
                        case "2":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);

        }

        /// <summary>
        /// tìm hoc viên theo học lực
        /// </summary>
        public void Yeucau03HocLuc()
        {
            Clear();
            string chon;
            do
            {
                WriteLine("\n\t------------TÌM SINH HOC LUC------------");
                WriteLine("\n\t1. Xuất sắc" +
                          "\n\t2. Giỏi" +
                          "\n\t3. Khá" +
                          "\n\t4. Trung bình"+
                          "\n\t5. Yếu");
                Write("\n\tMời chọn học lực:"); chon = ReadLine();
                switch(chon)
                {
                    case "1":
                        TimHocVienTheoHocLuc(_connection, "Xuất sắc");
                        break;
                    case "2":
                        TimHocVienTheoHocLuc(_connection, "Giỏi");
                        break;
                    case "3":
                        TimHocVienTheoHocLuc(_connection, "Khá");
                        break;
                    case "4":
                        TimHocVienTheoHocLuc(_connection, "Trung bình");
                        break;
                    case "5":
                        TimHocVienTheoHocLuc(_connection, "Yếu");
                        break;
                    default:
                        WriteLine("vui lòng nhập đúng chức năng!");
                        break;
                }
            } while (true);

            
        }


        /// <summary>
        /// Sửa lớp học
        /// </summary>
        public void Yeucau04UpdateClass()
        {

            Console.Clear();

            var lophoc = new Lophoc(_connection);

            do
            {
                int Idclass_;
                bool isId;
                bool isFindId;
                int dem = 0;
                do
                {
                    WriteLine("\n\t------------CẬP NHẬT THÔNG TIN LỚP------------");

                    isFindId = true;
                    Write("\tNhập ID lớp cần tìm: ");
                    isId = int.TryParse(ReadLine(), out Idclass_);
                    if (!isId)
                    {
                        WriteLine("\n\tvui lòng nhập đúng định dạng số");
                    }else 
                    {
                        using (var db = new ASMDBDataContext(_connection))
                        {
                            var item = (from p in db.Classes
                                        where p.IdClass == Idclass_
                                        select p).FirstOrDefault();
                            if (item == null)
                            {
                                WriteLine($"\n\tKhông tìm thấy id:{Idclass_} trong dữ liệu\n");
                                isFindId = false;
                                dem++;
                                // nếu nhập sai quá 3 lần sẽ khỏi động chương trình này
                                if (dem % 3 == 0)
                                {
                                    Clear();
                                    WriteLine("\tBạn đã nhập sai ID nhiều lần!" +
                                              "\n\tBạn có muốn xem lại bảng class không?");
                                    WriteLine("\n\t-------------------------------------------------------------------");
                                    WriteLine("\t1. Xem dữ liệu bảng Class    2. Quay về menu    3. Tiếp tục cập nhật");
                                    do
                                    {
                                        Write("\tchọn chức năng: ");

                                        string chon = ReadLine();
                                        switch (chon)
                                        {
                                            case "1":
                                                Yeucau02GetClass();
                                                Yeucau04UpdateClass();
                                                break;
                                            case "2":
                                                Menu.menu();
                                                break;
                                            case "3":
                                                Yeucau04UpdateClass();
                                                break;
                                            default:
                                                WriteLine("\thãy nhập đúng chức năng.");
                                                break;
                                        }
                                    } while (true);
                                }
                                ReadKey();
                                Clear();
                            }
                            else
                            {
                                WriteLine($"\n\tĐã tìm thấy ID cần cập nhật!\n\tMời bạn cập nhật dữ liệu.\n");
                            }
                        }
                    }

                    
                    } while (!isId || !isFindId);

                string nameClass;


                do
                {
                    Write("\tTên Lớp:");
                    nameClass = ReadLine();
                    if (string.IsNullOrEmpty(nameClass)) WriteLine("\tVui lòng không để trống...");
                } while (string.IsNullOrEmpty(nameClass));

                lophoc.UpdateLophoc(Idclass_, nameClass);
                
                WriteLine("\n\t----------------------------------------------------------------------------------");
                WriteLine("\t1. Tiếp tục cập nhật    2. Cập nhật học viên    3. Xem bảng Lớp    4. Quay lại menu");
                do
                {
                    Write("\tchọn chức năng: ");

                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau04UpdateClass();
                            break;
                        case "2":
                            Yeucau04UpdateStudent();
                            break;
                        case "3":
                            Yeucau02GetClass();
                            ReadKey();
                            Clear();
                            WriteLine("\n\t----------------------------------------------------------------------------------");
                            WriteLine("\t1. Tiếp tục cập nhật    2. Cập nhật học viên    3. Xem bảng Lớp    4. Quay lại menu");
                            break;
                        case "4":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);
        }
        /// <summary>
        /// sửa học sinh
        /// </summary>

        public void Yeucau04UpdateStudent()
        {
            Console.Clear();

            var hocvien = new HocVien(_connection);

            do
            {
                bool isSimilar;
                int StId_;
                bool isId;
                bool isFindId;
                string name;
                double mark;
                string email;
                int classId_;
                bool isNum;
                bool isEmail;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                int dem = 0;
                do
                {
                    WriteLine("\n\t------------CẬP NHẬT THÔNG TIN HỌC VIÊN------------");

                    isFindId = true;
                    Write("\tNhập ID Học Viên cần tìm: ");
                    isId = int.TryParse(ReadLine(), out StId_);
                    if (!isId) WriteLine("\tvui lòng nhập đúng định dạng số");

                    using (var db = new ASMDBDataContext(_connection))
                    {
                        var item = (from p in db.Students
                                    where p.StId == StId_
                                    select p).FirstOrDefault();
                        if (item == null)
                        {
                            WriteLine($"\n\tKhông tìm thấy id:{StId_} trong dữ liệu\n");
                            isFindId = false;
                            dem++;
                            // nếu nhập sai quá 3 lần sẽ khỏi động chương trình này
                            if (dem % 3 == 0)
                            {
                                Clear();
                                WriteLine("\tBạn đã nhập sai ID nhiều lần!" +
                                          "\n\tBạn có muốn xem lại bảng Students không?");
                                WriteLine("\n\t-------------------------------------------------------------------");
                                WriteLine("\t1. Xem dữ liệu bảng Students    2. Quay về menu    3. Tiếp tục cập nhật");
                                do
                                {
                                    Write("\tchọn chức năng: ");

                                    string chon = ReadLine();
                                    switch (chon)
                                    {
                                        case "1":
                                            Yeucau02GetStudents();
                                            Yeucau04UpdateStudent();
                                            break;
                                        case "2":
                                            Menu.menu();
                                            break;
                                        case "3":
                                            Yeucau04UpdateStudent();
                                            break;
                                        default:
                                            WriteLine("\thãy nhập đúng chức năng.");
                                            break;
                                    }
                                } while (true);
                            }
                            ReadKey();
                            Clear();
                        }
                        else
                        {
                            WriteLine($"\n\tĐã tìm thấy ID cần cập nhật!\n\tMời bạn cập nhật dữ liệu.\n");
                        }
                    }
                } while (!isId || !isFindId);


                // kiểm tra tên hv có rỗng hoặc giống nhau
                do
                {
                    Write("\tTên Học Viên:");
                    name = ReadLine();

                    // Kiểm tra tên trung nhau
                    using (var db = new ASMDBDataContext(_connection))
                    {
                        var student = db.Students.ToList();

                        try
                        {
                            var result = (from s in student
                                          where s.Name == name
                                          select s)
                                         .First();
                            isSimilar = true;
                        }
                        catch
                        {
                            isSimilar = false;
                        }
                    }
                    if (string.IsNullOrEmpty(name))
                    {
                        WriteLine("\tVui lòng không để trống tên...");
                    }
                    else if (isSimilar)
                    {
                        WriteLine("\tTên này đã có trong dữ liệu");
                    }

                } while (string.IsNullOrEmpty(name) || isSimilar);

                // kiểm tra điểm 
                do
                {
                    Write("\tĐiểm:");
                    isNum = double.TryParse(ReadLine(), out mark);

                    if (isNum == false)
                    {
                        WriteLine("\tvui lòng đúng định dạng số");
                    }
                    else if (mark > 10 || mark < 0)
                    {
                        WriteLine("\tvui lòng nhập điểm từ 1 - 10");
                        isNum = false;
                    }
                } while (!isNum);

                // kiểm tra có đúng định dạng email không
                do
                {
                    isEmail = true;
                    Write("\tEmail:");
                    email = ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        WriteLine("\tVui lòng không để trống...");
                        isEmail = false;
                    }
                    else if (!re.IsMatch(email))
                    {
                        WriteLine("\tvui lòng nhập đúng email");
                        isEmail = false;
                    }

                } while (!isEmail);

                // kiểm tra id phải là số không
                do
                {
                    Write("\tID lớp:");
                    isNum = int.TryParse(ReadLine(), out classId_);

                    // kiểm tra xem idclass hợp lệ không
                    using (var db = new ASMDBDataContext(_connection))
                    {
                        var _class = db.Classes.ToList();

                        try
                        {
                            var result = (from c in _class
                                          where c.IdClass == classId_
                                          select c)
                                         .First();
                            isSimilar = true;
                        }
                        catch
                        {
                            isSimilar = false;
                        }
                    }
                    if (!isNum)
                    {
                        WriteLine("\tvui lòng nhập đúng định dạng số...");
                    }
                    else if (!isSimilar)
                    {
                        WriteLine("\tIdClass này không có trong bảng class");
                    }
                } while (!isNum || !isSimilar);

                hocvien.UpdateHocVien(StId_, name, mark, email, classId_);

                WriteLine("\n\t---------------------------------------------------------------");
                WriteLine("\t1. Tiếp tục cập nhật    2. Cập nhật lớp   3. Quay lại menu");
                do
                {
                    Write("\tchọn chức năng: ");

                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau04UpdateStudent();
                            break;
                        case "2":
                            Yeucau04UpdateClass();
                            break;
                        case "3":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);
        }

        /// <summary>
        /// xóa dữ liệu bảng class
        /// </summary>
        public void XoaDuLieuBangClass()
        {
            Clear();
            WriteLine("\t------------------------XÓA DỮ LIỆU BẢNG CLASS------------------------");

            bool isNum;
            int classId_;
            bool isSimilar;
            bool containsOnStudent;
            do
            {
                Write("\tmời nhập id class cần xóa:");
                isNum = int.TryParse(ReadLine(), out classId_);

                // kiểm tra xem idclass hợp lệ không
                using (var db = new ASMDBDataContext(_connection))
                {
                    var _class = db.Classes.ToList();
                    var _student = db.Students.ToList();

                    try
                    {
                        var result = (from c in _class
                                      where c.IdClass == classId_
                                      select c)
                                     .First();
                        isSimilar = true;
                    }
                    catch
                    {
                        isSimilar = false;
                    }

                    try
                    {
                        var result = (from c in _student
                                      where c.IdClass == classId_
                                      select c)
                                     .First();
                        containsOnStudent = true;
                    }
                    catch
                    {
                        containsOnStudent = false;
                    }
                }
                if (!isNum)
                {
                    WriteLine("\tvui lòng nhập đúng định dạng số...\n");
                }
                else if (!isSimilar)
                {
                    WriteLine("\tIdClass này không có trong bảng class\n");
                }else if (containsOnStudent)
                {
                    WriteLine("\tId class này hiện đang liên kết với bảng student nên không thể xóa!\n");
                }
            } while (!isNum || !isSimilar || containsOnStudent);

            var lop = new Lophoc(_connection);
            lop.DeleteData(classId_);


            WriteLine("\n\t---------------------------------------------------------------");
            WriteLine("\t1. Tiếp tục Xóa\t\t2. Quay lại menu");
            do
            {
                Write("\tchọn chức năng: ");

                string chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        XoaDuLieuBangClass();
                        break;
                    case "2":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy nhập đúng chức năng.");
                        break;
                }
            } while (true);
        }


        public void XoaDuLieuBangStudent()
        {
            Clear();
            WriteLine("\t------------------------XÓA DỮ LIỆU BẢNG STUDENT------------------------");

            bool isNum;
            int stId;
            bool containsOnStudent;
            do
            {
                Write("\tmời nhập id studen cần xóa:");
                isNum = int.TryParse(ReadLine(), out stId);

                // kiểm tra xem idclass hợp lệ không
                using (var db = new ASMDBDataContext(_connection))
                {
                    var _student = db.Students.ToList();

                    try
                    {
                        var result = (from c in _student
                                      where c.StId == stId
                                      select c)
                                     .First();
                        containsOnStudent = true;
                    }
                    catch
                    {
                        containsOnStudent = false;
                    }
                }
                if (!isNum)
                {
                    WriteLine("\tvui lòng nhập đúng định dạng số...\n");
                }
                else if (!containsOnStudent)
                {
                    WriteLine("\tId student này không tồn tại trong bảng students\n");
                }
            } while (!isNum || !containsOnStudent);

            var hocvien = new HocVien(_connection);
            hocvien.DeleteData(stId);


            WriteLine("\n\t---------------------------------------------------------------");
            WriteLine("\t1. Tiếp tục Xóa\t\t2. Quay lại menu");
            do
            {
                Write("\tchọn chức năng: ");

                string chon = ReadLine();
                switch (chon)
                {
                    case "1":
                        XoaDuLieuBangStudent();
                        break;
                    case "2":
                        Menu.menu();
                        break;
                    default:
                        WriteLine("\thãy nhập đúng chức năng.");
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// xuất học sinh theo điểm từ tháp điến cao
        /// </summary>
        public void Yeucau05TuThapDenCao()
        {
            Console.Clear();
            var hocvien = new HocVien(_connection);
            var listStudent = hocvien.GetListStudents();
            var list = listStudent.OrderBy(x => x.Mark);

            WriteLine("\n\tSắp xếp từ điểm học viên từ thấp đến cao.");
            Console.WriteLine("\n\t-------------------------------------------DANH SÁCH HỌC VIÊN------------------------------------------");
            Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-10} | {"Email",-30} | {"Id Lớp",-10}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        
        /// <summary>
        /// xuất thông tin sinh viên sinh viên từ cao đến thấp
        /// </summary>
        public void Yeucau05TuCaoDenThap()
        {
            Console.Clear();
            var hocvien = new HocVien(_connection);
            var listStudent = hocvien.GetListStudents();
            var list = listStudent.OrderByDescending(x => x.Mark);

            WriteLine("\n\tSắp xếp từ điểm học viên từ cao đến thấp.");
            Console.WriteLine("\n\t-------------------------------------------DANH SÁCH HỌC VIÊN------------------------------------------");
            Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-10} | {"Email",-30} | {"Id Lớp",-10}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// xuất ra 5 học viên có điểm cao nhất
        /// </summary>
        public void Yeucau06()
        {
            Console.Clear();
            var hocvien = new HocVien(_connection);
            var listStudent = hocvien.GetListStudents();
            var list = listStudent.OrderByDescending(x => x.Mark).Take(5);

            WriteLine("\n\t5 Học viên có điểm cao nhất");
            Console.WriteLine("\n\t-------------------------------------------DANH SÁCH HỌC VIÊN------------------------------------------");
            Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-10} | {"Email",-30} | {"Id Lớp",-10}");
            foreach (var item in list)
            {
                Thread.Sleep(1);
                Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public void Yeucau07()
        {
            string fpath = @"D:\DSDTB.text";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }


            using (var db = new ASMDBDataContext(_connection))
            {
                var listStudent = db.Students;
                var listClass = db.Classes;

                var groupJoin = listClass.GroupJoin(listStudent,
                                                    std => std.IdClass,
                                                    cls => cls.IdClass,
                                                    (std, studentgroup) => new 
                                                    {
                                                        Students = studentgroup,
                                                        ClassName = std.NameClass,
                                                    });
                foreach(var item in groupJoin)
                {

                    double sum = 0;
                    int dem = 0;
                    double diemtb = 0;
                    foreach(var stu in item.Students)
                    {
                        sum += stu.Mark;
                        dem++;
                    }
                    diemtb = sum / dem;
                    if(item.Students.Count() != 0) 
                    {
                        using (TextWriter wr = File.AppendText(fpath))
                        {
                            wr.WriteLine($"\tLớp {item.ClassName} có điểm trung bình là:{diemtb}\n");
                        }
                    }
                }
            }
        }

        public void YeuCau7XuatFileLop()
        {
            string fpath = @"D:\Class.text";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }


            using (var db = new ASMDBDataContext(_connection))
            {

                var listClass = db.Classes.ToList();

                foreach (var item in listClass)
                {
                        using (TextWriter wr = File.AppendText(fpath))
                        {
                            wr.WriteLine($"\tId Lớp: {item.IdClass} |\tTên Lớp {item.NameClass}\n");
                        }
                }
            }
        }

        public void YeuCau7XuatFileStudents()
        {
            string fpath = @"D:\Students.text";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }


            using (var db = new ASMDBDataContext(_connection))
            {

                var listStudents = db.Students.ToList();

                foreach (var item in listStudents)
                {
                    using (TextWriter wr = File.AppendText(fpath))
                    {
                        wr.WriteLine($"\tId hv:{item.StId} |\tTên hv:{item.Name} |\tEmail:{item.Email} |\tĐiểm:{item.Mark} |\tid class:{item.IdClass} \n");
                    }
                }
            }
        }


        /// <summary>
        /// get học lực
        /// </summary>
        /// <returns></returns>
        public static string getHocLuc(double diem)
            {
            if (diem >= 9.5) return "Xuất sắc";
            if (diem >= 7.5) return "Giỏi";
            if (diem >= 6.5) return "Khá";
            if (diem >= 5) return "Trung bình";
            return "Yếu";
            }

        /// <summary>
        /// tìm học viên theo học lực
        /// </summary>
        /// <param name="_connection"></param>
        /// <param name="hocluc"></param>
        void TimHocVienTheoHocLuc(string _connection, string hocluc)
        {
            var hocvien = new HocVien(_connection);
            var list = hocvien.GetListStudents().Where(x => getHocLuc(x.Mark) == hocluc);

            if (list.Count() == 0)
            {
                WriteLine($"\n\tKhông tìm thấy học viên nào có học lực {hocluc}");
            }
            else
            {

                WriteLine($"\n\tDanh sách học viên có học lực {hocluc}");
                WriteLine("\n\t---------------------------------------DANH SÁCH HỌC VIÊN--------------------------------------");
                Console.WriteLine($"\t{"IDSV",-5} | {"Tên SV",-30} | { "Điểm",-5} | {"Học lực",-8} | {"Email",-30} | {"Id Lớp",-10}");
                foreach (var item in list)
                {
                    Thread.Sleep(1);
                    Console.WriteLine($"\t{item.StId,-5} | {item.Name,-30} | {item.Mark,-5} | {getHocLuc(item.Mark),-10} | {item.Email,-30} | {item.IdClass,-10}");
                }
            }
            do
            {
                Console.WriteLine();
                Console.ReadLine();
                WriteLine("\t-----------------------------------------------------");
                WriteLine("\t1. tiếp tục sử dụng chức năng này    2. Quay lại menu");

                do
                {
                    Write("\tchọn chức năng: ");
                    string chon = ReadLine();
                    switch (chon)
                    {
                        case "1":
                            Yeucau03HocLuc();
                            break;
                        case "2":
                            Menu.menu();
                            break;
                        default:
                            WriteLine("\thãy nhập đúng chức năng.");
                            break;
                    }
                } while (true);
            } while (true);
        }
    }
}
