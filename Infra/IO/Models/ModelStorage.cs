using Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Models
{
    [IoC]
    public class ModelStorage : IModelStorage
    {
        public ModelStorage(IEnumerable<IStorage> storages, ModelFolderFactory modelFolder)
        {
            Storages = storages.OrderBy(s => s.Order);
            ModelFolder = modelFolder;
        }

        public IModelFolder Open(SearchPath path) =>
            ModelFolder(new FlatFolder(Storages.SelectMany(
                s => path.Select(p => s.Open(p)))));

        IEnumerable<IStorage> Storages { get; }
        ModelFolderFactory ModelFolder { get; }
    }
}
