using Infra.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Path;
using static System.IO.File;
using System.Collections;

namespace Infra.IO.Local
{
    public class FileFolder : Enumerable<FileName>, IFolder
    {        
        public FileFolder(string path)
        {
            Path = path;
        }

        public Stream OpenRead(FileName fileName) =>
            Exists(Combine(Path, fileName)) ?
                File.OpenRead(Combine(Path, fileName)) :
                Stream.Null;

        public override IEnumerator<FileName> GetEnumerator() =>
            Directory.GetFiles(Path)
                .Select(f => new FileName(GetFileName(f)))
                .GetEnumerator();

        string Path { get; }
    }
}
