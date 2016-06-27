using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comparers
{
    public class CompositeComparer<T> : IComparer<T>
    {
        public static readonly IComparer<T> Empty = new CompositeComparer<T>();

        public CompositeComparer(params IComparer<T>[] comparers)
        {
            Comparers = comparers;
        }

        public int Compare(T x, T y) =>
            Comparers
                .Select(c => c.Compare(x, y))
                .FirstOrDefault(r => r != 0);

        IComparer<T>[] Comparers { get; }
    }
}
