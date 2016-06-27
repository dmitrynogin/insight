using Infra.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Path;

namespace Infra.IO.Local
{
    public class FileStorage : IStorage
    {
        public FileStorage(string root)
        {
            Root = root ?? GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public int Order => 1;

        public IFolder Open(SearchPath path) =>
            new FileFolder(Combine(Root, path));

        string Root { get; }
    }
}
