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
            builder.RegisterType<ProjectManager>().As<IManageProject>();
            builder.RegisterType<ProjectBackManager>().As<IBackProject>();
            builder.RegisterType<ProjectCommentManager>().As<IManageProjectComment>();
            builder.RegisterType<ProjectRewardManager>().As<IManageProjectReward>();
            builder.RegisterType<ProjectUpdateIManager>().As<IManageProjectUpdate>();
            builder.RegisterType<UserProfileManager>().As<IManageUserProfile>();
        }
    }
}
