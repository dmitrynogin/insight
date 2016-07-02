using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.IO.Readers.Tabular;
using Infra.Attributes;
using Infra.MachineLearning;

namespace Infra.IO.Models
{
    public delegate IModelFolder ModelFolderFactory(IFolder folder);

    [IoC]
    public class ModelFolder : Enumerable<FileName>, IModelFolder
    {
        public ModelFolder(IFolder folder, CsvReaderFactory csvReader, ZipFactory zip, SvmFactory svm)
        {
            Folder = folder;
            CsvReader = csvReader;
            Zip = zip;
            Svm = svm;
        }

        public override IEnumerator<FileName> GetEnumerator() =>
            Folder.GetEnumerator();

        public ITabularReader OpenCsv(FileName fileName) =>
            CsvReader(Folder.OpenText(fileName));

        public Stream OpenRead(FileName fileName) =>
            Folder.OpenRead(fileName);

        public IModelFolder OpenZip(FileName fileName) =>
            new ModelFolder(Zip(OpenRead(fileName)), CsvReader, Zip, Svm);

        public ISvm OpenSvm(FileName fileName) =>
            Svm(OpenRead(fileName));

        IFolder Folder { get; }
        CsvReaderFactory CsvReader { get; }
        ZipFactory Zip { get; }
        SvmFactory Svm { get; }
    }
}
