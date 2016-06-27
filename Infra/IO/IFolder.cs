using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public interface IFolder : IEnumerable<FileName>
    {
        TextReader OpenText(FileName fileName);
    }
}
