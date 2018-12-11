using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Models;
using TestProject2.Models.Models;

namespace TestProject2.App.Service.StudentService
{
    public class StudentService : IStudentAppService
    {
        TestProject2DBContext db = new TestProject2DBContext();

        public List<Student> GetStudentList()
        {
           return db.Students.ToList();
        }
    }
}
