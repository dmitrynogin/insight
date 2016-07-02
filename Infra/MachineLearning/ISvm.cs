using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.MachineLearning
{
    public delegate ISvm SvmFactory(Stream stream);

    public interface ISvm
    {
        Class Classify(double[] input);
    }
}
