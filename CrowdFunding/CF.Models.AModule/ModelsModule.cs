using Autofac;
using System;
using System.Linq;

namespace CF.Models.AModule
{
    public class ModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // a little reflection to get implementations of ICachableModel
            var typeOfInterface = typeof(ICachableModel);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(p => typeOfInterface.IsAssignableFrom(p) && p.IsClass && p.IsPublic && !p.IsAbstract);

            //register implementations to Autofac
            foreach (Type type in types)
            {
                builder.RegisterType(type).As<ICachableModel>();
            }
        }
    }
}
