using Autofac;
using Autofac.Integration.Mvc;
using ChaosCC.BusinessLayer;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.DataLayer.EntityFramework;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

//using Autofac.Integration.WebApi;

namespace ChaosCC.UIYonetim
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper();

        }

        private void Bootstrapper()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<KullaniciManager>().As<IKullaniciManager>().WithParameter("dal", new EfKullaniciDal()).InstancePerLifetimeScope();
            //containerBuilder.RegisterType<IKullaniciDal>().As<EfKullaniciDal>().InstancePerLifetimeScope();

            //containerBuilder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            //containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = containerBuilder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
