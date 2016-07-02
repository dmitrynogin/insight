using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.IO.Readers.Tabular;
using Infra.ComponentModel;
using Infra.Attributes;

namespace Infra.IO.Models
{
    public delegate IModelFolder ModelFolderFactory(IFolder folder);

    [IoC]
    public class ModelFolder : Enumerable<FileName>, IModelFolder
    {
        public ModelFolder(IFolder folder, CsvReaderFactory csvReader, ZipFactory zip)
        {
            Folder = folder;
            CsvReader = csvReader;
            Zip = zip;
        }

        public override IEnumerator<FileName> GetEnumerator() =>
            Folder.GetEnumerator();

        public ITabularReader OpenCsv(FileName fileName) =>
            CsvReader(Folder.OpenText(fileName));

        public Stream OpenRead(FileName fileName) =>
            Folder.OpenRead(fileName);

        public IModelFolder OpenZip(FileName fileName) =>
            new ModelFolder(Zip(OpenRead(fileName)), CsvReader, Zip);
        
        IFolder Folder { get; }
        CsvReaderFactory CsvReader { get; }
        ZipFactory Zip { get; }
    }
}
