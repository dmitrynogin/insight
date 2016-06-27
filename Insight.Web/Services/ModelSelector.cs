using Insight.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.IO;
using System.Web;
using System.Net.Http;
using Infra.Attributes;
using System.Web.Http.Hosting;
using System.Web.Http;

namespace Insight.Web.Services
{
    [IoC(LifeScope=LifeScope.PerRequest)]
    class ModelSelector : IModelSelector
    {
        public ModelSelector(HttpRequestMessage request)
        {
            Request = request;
        }

        public SearchPath Path =>Request.RequestUri.LocalPath.Replace("/parsing", "");
        HttpRequestMessage Request { get; }
    }
}
