using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.Data2;
using CF.Data2.UnitOfWork;

namespace CF.Data2.AModule
{
    public class DataRepositories2Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context.CrowdFundingDbContext>().As<Context.IDbContext>().InstancePerRequest();
            builder.RegisterType<CF.Data2.UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}
