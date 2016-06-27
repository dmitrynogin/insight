using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Sets
{
    public class Set<T>
    {
        public static implicit operator Set<T>(T value) =>
            new Set<T>(value);

        public Set(params T[] values)
            : this(values.AsEnumerable())
        {
        }

        public Set(IEnumerable<T> values)
            : this(i => values.Contains(i))
        {
        }

        public Set(Predicate<T> predicate)
        {
            Predicate = predicate;
        }

        public Intersection<T> this[T value] =>
            Predicate(value) ? new Intersection<T>(value) : Intersection<T>.Empty;

        public Intersection<T> this[IEnumerable<T> values] =>
            new Intersection<T>(values.Where(i => Predicate(i)));

        public static Set<T> operator &(Set<T> left, Set<T> right) =>
            new Set<T>(i => left.Predicate(i) && right.Predicate(i));

        public static Set<T> operator &(Set<T> left, IEnumerable<T> right) =>
            left & new Set<T>(right);

        public static Set<T> operator &(IEnumerable<T> left, Set<T> right) =>
            new Set<T>(left) & right;

        public static Set<T> operator |(Set<T> left, Set<T> right) =>
            new Set<T>(i => left.Predicate(i) || right.Predicate(i));

        public static Set<T> operator |(Set<T> left, IEnumerable<T> right) =>
            left | new Set<T>(right);

        public static Set<T> operator |(IEnumerable<T> left, Set<T> right) =>
            new Set<T>(left) | right;

        public static Set<T> operator -(Set<T> left, Set<T> right) =>
            new Set<T>(i => left.Predicate(i) && !right.Predicate(i));

        public static Set<T> operator -(Set<T> left, IEnumerable<T> right) =>
            left - new Set<T>(right);

        public static Set<T> operator -(IEnumerable<T> left, Set<T> right) =>
            new Set<T>(left) - right;

        public static Set<T> operator !(Set<T> set) =>
            new Set<T>(i => !set.Predicate(i));

        Predicate<T> Predicate { get; }
    }
}
