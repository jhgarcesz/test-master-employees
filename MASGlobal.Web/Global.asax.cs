using MASGlobal.Domain.Contracts;
using MASGlobal.Domain.Dao;
using MASGlobal.Domain.Domain;
using MASGlobal.Domain.Support;
using RestSharp;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MASGlobal.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IRestClient>(() => new RestClient(ConfigurationManager.AppSettings[Constants.EmployeeBaseUrl]), Lifestyle.Scoped);
            container.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Scoped);
            container.Register<IEmployeeFactory, EmployeeFactory>(Lifestyle.Scoped);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
