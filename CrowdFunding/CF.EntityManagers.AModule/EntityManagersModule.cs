using Autofac;
using CF.EntityManagers;
using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.EntityManagers.AModule
{
    public class EntityManagersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryManager>().As<IManageCategory>();
        }
    }
}
