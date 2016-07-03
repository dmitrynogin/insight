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
        IList<Class> Classify(double[] input, double min = 0, int top = int.MaxValue);
    }
}
