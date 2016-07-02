using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.MachineLearning
{
    public struct Class
    {
        public Class(int number, double score)
        {
            Number = number;
            Score = score;
        }

        public int Number { get; }
        public double Score { get; }
    }
}
