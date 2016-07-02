using Infra.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.MachineLearning
{
    public interface ITrainer
    {
        Task<double> TrainAsync(Classification classification);
    }
}
