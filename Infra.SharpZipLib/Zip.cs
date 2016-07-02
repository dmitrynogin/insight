using Infra.ComponentModel;
using Infra.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Infra.Attributes;

namespace Infra.SharpZipLib
{
    [IoC]
    public class Zip : Enumerable<FileName>, IZip
    {
        public Zip(Stream stream)
        {
            Files = new Dictionary<FileName, byte[]>();
            using (var zip = new ZipInputStream(stream))
            {
                ZipEntry e;
                while ((e = zip.GetNextEntry()) != null)                
                    if (e.IsFile)
                        using (var ms = new MemoryStream())
                        {
                            zip.CopyTo(ms);
                            Files[e.Name] = ms.ToArray();
                        }                
            }
        }

        public void Dispose() { }

        public override IEnumerator<FileName> GetEnumerator() => 
            Files.Keys.GetEnumerator();

        public Stream OpenRead(FileName fileName) =>
            new MemoryStream(Files[fileName], false);

        Dictionary<FileName, byte[]> Files { get; }
    }
}
