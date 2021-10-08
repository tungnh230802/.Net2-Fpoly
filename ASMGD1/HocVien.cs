using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace ASMGD1
{
    public class HocVien
    {
        private string _connection;
        public HocVien(string connection)
        {
            _connection = connection;
        }

        ~HocVien()
        {
            _connection = null;
        }

        public void InssertHocVien(string name, double mark, string email, int idClass)
        {
            using (var db = new ASMDBDataContext(_connection))
            {
                var student = new Student() { Name = name,Mark = mark, Email = email, IdClass = idClass };

                db.Students.InsertOnSubmit(student);
                db.SubmitChanges();
            }
            Write("\n\t-> Thêm dữ liệu thành công\n");
        }

        /// <summary>
        /// cập nhật student
        /// </summary>
        /// <returns></returns>
        public void UpdateHocVien(int stid, string name, double mark, string email, int idClass)
        {
            using(var db = new ASMDBDataContext(_connection))
            {
                var item = (from s in db.Students
                            where s.StId == stid
                            select s)
                            .FirstOrDefault();
                item.Name = name;
                item.Mark = mark;
                item.Email = email;
                item.IdClass = idClass;
                db.SubmitChanges();
            }
            WriteLine($"\n\tUpdate dữ liệu thành công.\n");
        }

        /// <summary>
        /// lấy ra danh sách học viên
        /// </summary>
        /// <returns></returns>
        public List<Student> GetListStudents()
        {
            List<Student> list = new List<Student>();
            using (var db = new ASMDBDataContext(_connection))
            {
                list = db.Students.ToList();
            }
            return list;
        }

        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <param name="idClass"></param>
        public void DeleteData(int stId)
        {
            using (var db = new ASMDBDataContext(_connection))
            {
                Student item = (from p in db.Students
                              where p.StId == stId
                              select p).FirstOrDefault();

                db.Students.DeleteOnSubmit(item);
                db.SubmitChanges();
                WriteLine($"\n\txóa thành công học viên có id {stId}");
            }
        }

    }
}
