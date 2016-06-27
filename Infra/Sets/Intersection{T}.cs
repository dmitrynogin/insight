using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Sets
{
    public class Intersection<T> : IEnumerable<T>
    {
        public static readonly Intersection<T> Empty = new Intersection<T>();
        public static implicit operator bool(Intersection<T> intersection) => intersection.Any();

        public Intersection(params T[] items)
        {
            Items = items;
        }

        public Intersection(IEnumerable<T> items)
        {
            Items = items;
        }

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerable<T> Items { get; }
    }
}
