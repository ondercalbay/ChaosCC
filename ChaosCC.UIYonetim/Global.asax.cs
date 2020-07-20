using Autofac;
using Autofac.Core;
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

            AutoMapperConfiguration.Initialize();

            Bootstrapper();

        }

        private void Bootstrapper()
        {
            var containerBuilder = new ContainerBuilder();

           // List<string> listClasslar = new List<string> { "Kullanici", "Duyuru", "Etkinlik","Marka","Model","Motosiklet" };

            //foreach (string item in listClasslar)
            //{
            //    var manager = Activator.CreateInstance("AssemblyName", "TypeName");
            //}



            containerBuilder.RegisterType<KullaniciManager>().As<IKullaniciManager>().WithParameter("dal", new EfKullaniciDal()).InstancePerLifetimeScope();
            
            containerBuilder.RegisterType<DuyuruManager>().As<IDuyuruManager>().WithParameter("dal", new EfDuyuruDal()).InstancePerLifetimeScope();

            List<Parameter> prms = new List<Parameter>();
            prms.Add(new NamedParameter("dal", new EfEtkinlikDal()));
            prms.Add(new NamedParameter("dalKullanici", new EfKullaniciDal()));
            containerBuilder.RegisterType<EtkinlikManager>().As<IEtkinlikManager>().WithParameters(prms).InstancePerLifetimeScope();

            containerBuilder.RegisterType<MarkaManager>().As<IMarkaManager>().WithParameter("dal", new EfMarkaDal()).InstancePerLifetimeScope();
            containerBuilder.RegisterType<ModelManager>().As<IModelManager>().WithParameter("dal", new EfModelDal()).InstancePerLifetimeScope();
            containerBuilder.RegisterType<MotosikletManager>().As<IMotosikletManager>().WithParameter("dal", new EfMotosikletDal()).InstancePerLifetimeScope();


            //containerBuilder.RegisterType<EtkinlikManager>().As<IEtkinlikManager>().WithParameter("dal", new EfEtkinlikDal()).InstancePerLifetimeScope();

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
