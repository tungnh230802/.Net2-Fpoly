using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ASMGD1
{
    public class Lophoc
    {
        private string _connection;
        public Lophoc(string connection)
        {
            _connection = connection;
        }

        ~Lophoc()
        {
            _connection = null;
        }
        /// <summary>
        /// thêm lớp
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="nameClass"></param>
        public void InsertLophoc(string nameClass)
        {
            using (var db = new ASMDBDataContext(_connection))
            {
                var item = new Class() { NameClass = nameClass };
                db.Classes.InsertOnSubmit(item);
                db.SubmitChanges();
            }
            Console.Write("\n\t-> Thêm dữ liệu thành công.\n");
        }
        /// <summary>
        /// cập nhật lớp
        /// </summary>
        /// <param name="idClass"></param>
        /// <param name="nameClass"></param>

        public void UpdateLophoc(int idClass, string nameClass)
        {
            using (var db = new ASMDBDataContext(_connection))
            {
                var item = (from p in db.Classes
                            where p.IdClass == idClass
                            select p).FirstOrDefault();


                if (!string.IsNullOrEmpty(nameClass))
                {
                    item.NameClass = nameClass;
                    db.SubmitChanges();
                    Console.Write("\n\tUpdate dữ liệu thành công.");
                }
            }
        }

        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <param name="idClass"></param>
        public void DeleteData(int idClass)
        {
            using (var db = new ASMDBDataContext(_connection))
            {
                Class item = (from p in db.Classes
                            where p.IdClass == idClass
                            select p).FirstOrDefault();

                db.Classes.DeleteOnSubmit(item);
                db.SubmitChanges();
                WriteLine($"\n\txóa thành công lớp có id {idClass}");
            }
        }


        /// <summary>
        /// xuất lớp
        /// </summary>
        /// <returns></returns>
        public List<Class> GetListLophoc()
        {
            List<Class> list = new List<Class>();
            using (var db = new ASMDBDataContext(_connection))
            {
                list = db.Classes.ToList();
            }
            return list;
        }
    }
}
