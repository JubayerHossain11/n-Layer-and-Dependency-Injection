using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //private ApplicationDbContext _ctx;
        public DepartmentRepository()
        {
            //_ctx = new ApplicationDbContext();
        }

        public List<Department> GetAll()
        {
             return new List<Department>(){
                new Department { Id = 1, Name = "Visakhapatnam" },
                new Department { Id = 2, Name = "Hyderabad"},
                new Department { Id = 3, Name = "Bangalore" },
                new Department { Id = 4, Name = "Chennai"},
            };
            
        }

    }
}
