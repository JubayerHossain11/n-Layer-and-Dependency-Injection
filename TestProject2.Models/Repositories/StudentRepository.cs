using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Models.Models;

namespace TestProject2.Models.Repositories
{
    public class StudentRepository :GenericRepository<TestProject2DBContext, Student>
    {
        public List<Student> GetAll(int fooId)
        {
            var query = GetAll().ToList();
            return query;
        }
    }
}
