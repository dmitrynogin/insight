using Accord.MachineLearning.VectorMachines;
using Infra.Attributes;
using Infra.MachineLearning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.AccordNet
{
    [IoC]
    public class Svn : ISvm
    {
        public Svn(Stream stream)
        {
            Machine = MulticlassSupportVectorMachine.Load(stream);
        }

        public IList<Class> Classify(double[] input, double min, int top)
        {            
            var scores = new double[Machine.Classes];
            Machine.Compute(input, out scores);
            return scores
                .Select((s, n) => new Class(n, s))
                .OrderByDescending(c => c.Score)
                .Where(c => c.Score >= min)
                .Take(top)
                .ToArray();               
        }

        MulticlassSupportVectorMachine Machine { get; }
    }
}
