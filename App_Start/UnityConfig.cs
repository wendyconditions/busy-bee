using System.Configuration;
using System.Web.Http;
using TestingList.Interfaces;
using TestingList.Providers;
using TestingList.Services;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace TestingList
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IListService, ListService>();
            container.RegisterType<ISystemDictionaryService, SystemDictionaryService>();
            container.RegisterType<IDataProvider, SqlDataProvider>(
                new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}