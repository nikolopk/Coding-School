using Autofac;
using Autofac.Integration.Mvc;
using CF.Controllers.AModule;
using CF.Data2.AModule;
using CF.EntityManagers.AModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System;
using System.IO;
using System.Text;
using Autofac.Configuration.Core;
using CF.Models.AModule;

namespace CF.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string AutofacModulesFileName = "modules.xml";

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterModule<DataRepositories2Module>();
            builder.RegisterModule<EntityManagersModule>();
            builder.RegisterModule<ControllersModule>();
            builder.RegisterModule<ModelsModule>();
            //builder.RegisterModule<AutofacWebTypesModule>();
            

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
            

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
