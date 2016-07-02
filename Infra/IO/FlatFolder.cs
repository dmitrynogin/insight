using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO
{
    public class FlatFolder : Enumerable<FileName>, IFolder
    {
        public FlatFolder(IEnumerable<IFolder> folders)
        {
            Folders = folders;
        }

        public override IEnumerator<FileName> GetEnumerator() =>
            Folders
                .SelectMany(f => f)
                .Distinct()
                .GetEnumerator();

        public Stream OpenRead(FileName fileName) =>
            Folders
                .Select(f => f.OpenRead(fileName))
                .Where(s => s != Stream.Null)
                .DefaultIfEmpty(Stream.Null)
                .First();

        IEnumerable<IFolder> Folders { get; }
    }
}
