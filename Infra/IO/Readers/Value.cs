using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Readers
{
    public class Value
    {
        public Value(object obj)
        {
            Obj = obj;
        }

        object Obj { get; }

        public static implicit operator string(Value value) =>
            value.Obj?.ToString();

        public static implicit operator double(Value value) =>
            Convert.ToDouble(value.Obj);

        public static implicit operator double?(Value value) =>
            value.Obj == null ? (double?)null : (double)value;
    }
}
