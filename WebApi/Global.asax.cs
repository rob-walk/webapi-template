using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using WebApi.Configuration;

namespace WebApi
{
    public class WebApiApplication : HttpApplication
    {
        private static IContainer _container;

        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            Bootstrap();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            CreateMaps();
        }

        private static void Bootstrap()
        {
            var bootstrap = new Bootstrapper();

            _container = bootstrap.BuildContainer();
        }

        private static void CreateMaps()
        {
        }
    }
}
