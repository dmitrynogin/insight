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

        public Class Classify(double[] input)
        {
            double score;
            return new Class(Machine.Compute(input, out score), score);
        }

        MulticlassSupportVectorMachine Machine { get; }
    }
}
