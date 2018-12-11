using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject2.Models;

namespace TestProject2.DDL
{
    public class DepartmentService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public List<Department> GetDepartmentList()
        {
            var item = db.departments.ToList();
            return item;
        }
    }
}