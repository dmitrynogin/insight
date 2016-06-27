using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Models
{
    public interface IModelStorage
    {
        IModelFolder Open(SearchPath path);
    }
}
