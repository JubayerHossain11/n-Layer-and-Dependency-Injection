using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Models.Models;

namespace TestProject2.App.Service.StudentService
{
    public interface IStudentAppService
    {
       List<Student> GetStudentList();
    }
}
