using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Sets
{
    public static class Universe
    {
        public static Set<T> Set<T>() => Set<T>(i => true);
        public static Set<T> Set<T>(Predicate<T> predicate) => new Set<T>(predicate);
        public static Intersection<T> Intersect<T>(this IEnumerable<T> source, Set<T> set) =>
            set[source];
    }
}
