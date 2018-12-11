using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Models.Models;

namespace TestProject2.Models
{
    public class TestProject2DBContext  :IdentityDbContext<ApplicationUser>
    {
        public TestProject2DBContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public IDbSet<Student> Students { get; set; }

        public static TestProject2DBContext Create()
        {
            return new TestProject2DBContext();
        }
    }
}
