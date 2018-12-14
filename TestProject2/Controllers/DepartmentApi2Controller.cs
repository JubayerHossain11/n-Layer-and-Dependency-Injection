using DAL.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestProject2.App.Service.StudentService;
using TestProject2.AuthProvider;
using TestProject2.DDL;
using TestProject2.Models;

namespace TestProject2.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentApi2Controller : ApiController
    {
        private IStudentAppService _departmentService;

        public DepartmentApi2Controller(IStudentAppService departmentService)
        {
            _departmentService = departmentService;
        }


        [Authorize]
        [Route("GetProductList")]
        public IHttpActionResult GetProductList()
        {
            var item = _departmentService.GetStudentList();

            return Ok(item);
        }


        [Route("CreateProxyUser")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateProxyUser(DepartmentOutput input)
        {
            AuthRepository _repo = new AuthRepository();

           await _repo.RegisterUser(new RegisterViewModel() { Email = input.Name, Password = input.Password});

            return Ok();
        }
    }
}
