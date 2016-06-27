using Autofac;
using Autofac.Integration.WebApi;
using SolutionConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Infra.Attributes;
using System.Web.Hosting;
using static Infra.Sets.Universe;
using Infra.IO.Local;
using Infra.IO;

namespace Insight.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();            
            builder.RegisterApiControllers(Solution.Assemblies.ToArray());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterHttpRequestMessage(config);

            var concrete = Set<Type>(t => !t.IsAbstract);
            var generic = Set<Type>(t => t.IsGenericTypeDefinition);

            var registerable = concrete & Set<Type>(t => t.Attributes<IoCAttribute>().Any());
            var asSelf = Set<Type>(t => t.Attributes<IoCAttribute>().Any(a => a.AsSelf));

            var singleton = Set<Type>(t => t.Attributes<IoCAttribute>().Any(a => a.LifeScope == LifeScope.Singleton));
            var perRequest = Set<Type>(t => t.Attributes<IoCAttribute>().Any(a => a.LifeScope == LifeScope.PerRequest));

            var types = Solution.Assemblies.IoCTypes();

            foreach (var t in types.Intersect(registerable))
                if (generic[t])
                {
                    var g = builder.RegisterGeneric(t);
                    if (asSelf[t])
                    {
                        var s = g.AsSelf();
                        if (singleton[t])
                            s.SingleInstance();

                        if (perRequest[t])
                            s.InstancePerRequest();
                    }
                    else
                    {
                        var i = g.AsImplementedInterfaces();
                        if (singleton[t])
                            i.SingleInstance();

                        if (perRequest[t])
                            i.InstancePerRequest();
                    }
                }
                else
                {
                    var ng = builder.RegisterType(t);
                    if (asSelf[t])
                    {
                        var s = ng.AsSelf();
                        if (singleton[t])
                            s.SingleInstance();

                        if (perRequest[t])
                            s.InstancePerRequest();
                    }
                    else
                    {
                        var i = ng.AsImplementedInterfaces();
                        if (singleton[t])
                            i.SingleInstance();

                        if (perRequest[t])
                            i.InstancePerRequest();
                    }
                }

            builder.RegisterType<FileFolder>()
                .WithParameter("path", HostingEnvironment.MapPath("~/DB"))
                .AsImplementedInterfaces();

            builder.RegisterType<FileStorage>()
                .WithParameter("root", HostingEnvironment.MapPath("~/DB"))
                .As<IStorage>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
