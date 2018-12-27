using Autofac;
using Autofac.Integration.Mvc;
using Pizza_Maker.Data.Repo;
using Pizza_Maker.Domain;
using Pizza_Maker.Domain.Models;
using Pizza_Maker.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pizza_Maker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer<PizzaMakerEntities>(null);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAutoFac();
        }

        private void ConfigureAutoFac()
        {


            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<Building>().As<IBuilding>();
            builder.RegisterType<Upgrade>().As<IUpgrade>();
            builder.RegisterType<TotalBuildings>().As<ITotalBuildings>();
            builder.RegisterType<PlayerBuildings>().As<IPlayerBuildings>();
            builder.RegisterType<PlayerUpgrades>().As<IPlayerUpgrades>();
            builder.RegisterType<AllUpgrades>().As<IAllUpgrades>();
            builder.RegisterType<BuildRepo>().As<IBuildRepo>();
            builder.RegisterType<UpgradesRepo>().As<IUpgradesRepo>();
            builder.RegisterType<PlayerRepo>().As<IPlayerRepo>();
            builder.RegisterType<LogicServices>().AsSelf();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
