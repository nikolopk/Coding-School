using Autofac;
using CF.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Controllers.AModule
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountController>()
                 .InstancePerRequest();
            builder.RegisterType<HomeController>()
                 .InstancePerRequest();
            builder.RegisterType<CategoryController>()
                 .InstancePerRequest();
            builder.RegisterType<ManageController>()
                 .InstancePerRequest();
        }
    }
}
