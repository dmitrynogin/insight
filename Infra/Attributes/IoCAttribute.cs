using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class IoCAttribute : Attribute
    {
        public bool AsSelf { get; set; } = false;
        public LifeScope LifeScope { get; set; } = LifeScope.Transient;
        public int Order { get; set; } = 1;
    }

    public enum LifeScope
    {
        Transient,
        PerRequest,
        Singleton
    }

    public static class Registration
    {
        public static IEnumerable<Type> IoCTypes(this IEnumerable<Assembly> assemblies) =>
            assemblies
                .SelectMany(a => a.DefinedTypes)
                .Select(t => new
                {
                    Type = t,
                    IoC = t.Attributes<IoCAttribute>().FirstOrDefault()
                })
                .Where(x => x.IoC != null)
                .OrderBy(x => x.IoC.Order)
                .Select(x => x.Type);
    }
}
