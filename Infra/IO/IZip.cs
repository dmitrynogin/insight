using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public delegate IZip ZipFactory(Stream stream);

    public interface IZip : IFolder, IDisposable
    {

    }
}
