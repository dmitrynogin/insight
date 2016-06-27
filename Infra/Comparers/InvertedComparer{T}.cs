using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comparers
{
    public class InvertedComparer<T> : IComparer<T>
    {
        public InvertedComparer(IComparer<T> inner)
        {
            Inner = inner;
        }

        public int Compare(T x, T y) =>
            Inner.Compare(y, x);

        IComparer<T> Inner { get; }
    }
}
