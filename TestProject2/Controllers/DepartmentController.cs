using DAL.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject2.App.Service.StudentService;
using TestProject2.DDL;

namespace TestProject2.Controllers
{
    public class DepartmentController : Controller
    {


        //DepartmentService service = new DepartmentService();
        //public ActionResult Index()
        //{
        //    var list = service.GetDepartmentList();

        //    return View(list);
        //}

        private IDepartmentRepository _departmentRepository;
        private IStudentAppService _departmentService;
        public DepartmentController(IDepartmentRepository departmentRepository, IStudentAppService departmentService)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
        }


        public ActionResult Index()
        {
            var list = _departmentRepository.GetAll();

            var items = _departmentService.GetStudentList();

            return View(list);
        }
    }
}