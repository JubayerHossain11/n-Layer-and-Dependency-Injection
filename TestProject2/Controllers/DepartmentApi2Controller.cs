using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject2.DDL;

namespace TestProject2.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentApi2Controller : ApiController
    {
        DepartmentService service = new DepartmentService();

        [Authorize]
        [Route("GetProductList")]
        public IHttpActionResult GetProductList()
        {
            var item = service.GetDepartmentList();

            return Ok(item);
        }
    }
}
