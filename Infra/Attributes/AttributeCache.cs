using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Attributes
{
    public static class AttributeCache
    {
        public static IEnumerable<T> Attributes<T>(this Type type)
            where T : Attribute => Cache
                .GetOrAdd(type, t => t.GetCustomAttributes(true).OfType<Attribute>().ToArray())
                .OfType<T>();

        static ConcurrentDictionary<Type, Attribute[]> Cache { get; } =
            new ConcurrentDictionary<Type, Attribute[]>();
    }
}
