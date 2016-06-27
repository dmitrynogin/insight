using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comparers
{
    public static class ComparerComposition
    {
        public static IComparer<T> Invert<T>(this IComparer<T> comparer) =>
            new InvertedComparer<T>(comparer);

        public static IComparer<T> ThenBy<T>(this IComparer<T> first, IComparer<T> second) =>
            new CompositeComparer<T>(first, second);

        public static IComparer<T> ThenByDescending<T>(this IComparer<T> first, IComparer<T> second) =>
            new CompositeComparer<T>(first, second.Invert());

        public static IComparer<T> Prefer<T>(this IComparer<T> first, Predicate<T> test) =>
            first.ThenBy(new TestComparer<T>(test));

        public static IComparer<T> Defer<T>(this IComparer<T> first, Predicate<T> test) =>
            first.ThenByDescending(new TestComparer<T>(test));
    }
}
