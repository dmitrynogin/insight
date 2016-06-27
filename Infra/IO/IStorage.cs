using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public interface IStorage
    {
        int Order { get; }
        IFolder Open(SearchPath path);
    }
}
