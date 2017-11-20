using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TokenAuth.Interface;

namespace TokenAuth
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var container = new UnityContainer();
            container.RegisterType<ITokenServices, TokenServices>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserServices, UserServices>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
          //  config.Filters.Add(new LoggingFilterAttribute());




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
