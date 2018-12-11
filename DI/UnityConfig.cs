using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace DI
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //container.RegisterType<ICustomerRepository, CustomerRepository>();
            //container.RegisterType<ICustomerService, CustomerService>();
        }
    }
}
