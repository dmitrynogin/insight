using Infra.IO.Readers.Tabular;
using Infra.MachineLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Models
{
    public interface IModelFolder : IFolder
    {
        ITabularReader OpenCsv(FileName fileName);
        IModelFolder OpenZip(FileName fileName);
        ISvm OpenSvm(FileName fileName);
    }
}
