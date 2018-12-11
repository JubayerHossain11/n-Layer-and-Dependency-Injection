using DAL.Departments;
using System.Web.Mvc;
using TestProject2.App.Service.StudentService;
using Unity;
using Unity.Mvc5;

namespace TestProject2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IStudentAppService, StudentService>();
        }
    }
}