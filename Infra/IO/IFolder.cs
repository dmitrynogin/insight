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
        Stream OpenRead(FileName fileName);        
    }

    public static class Folder
    {
        public static TextReader OpenText(this IFolder folder, FileName fileName) =>
            new StreamReader(folder.OpenRead(fileName));
    }
}
