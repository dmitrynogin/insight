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
        public ModelFolder(IFolder folder, CsvReaderFactory csvReader)
        {
            Folder = folder;
            CsvReader = csvReader;
        }

        public override IEnumerator<FileName> GetEnumerator() =>
            Folder.GetEnumerator();

        public ITabularReader OpenCsv(FileName fileName) =>
            CsvReader(OpenText(fileName));

        public TextReader OpenText(FileName fileName) =>
            Folder.OpenText(fileName);

        IFolder Folder { get; }
        CsvReaderFactory CsvReader { get; }
    }
}
