using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Comparers
{
    public class TestComparer<T> : IComparer<T>
    {
        public TestComparer(Predicate<T> test)
        {
            Test = test;
        }

        public int Compare(T x, T y)
        {
            var testX = Test(x);
            var testY = Test(y);
            return testX
                ? (testY ? 0 : -1)
                : (testY ? 1 : 0);
        }

        Predicate<T> Test { get; }
    }
}
