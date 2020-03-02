using Buisness_Layer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AngularJS
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
            container.RegisterType<IUserRepo,UserRepo>();
            container.RegisterType<ICompany, CompanyRepo>();
        }
    }
}